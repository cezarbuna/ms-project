using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MsaProject.Application.Commands.MenuItemCommands;
using MsaProject.Application.Queries.MenuItemQueries;
using MsaProject.Domain;
using MsaProject.Dtos.MenuItemDto;

namespace MsaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public MenuItemController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateMenuItem(MenuItemPostDto newMenuItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateMenuItemCommand
            {
                MenuId = newMenuItem.MenuId,
                Name = newMenuItem.Name,
                 Price = newMenuItem.Price
            };

            var menuItem = _mapper.Map<MenuItemPostDto, MenuItem>(newMenuItem);
            var createdMenuItem = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetMenuItemById), new { menuItemId = menuItem.Id }, createdMenuItem);
        }
        [HttpGet]
        [Route("get-menuitem-by-id/{menuItemId}")]
        public async Task<IActionResult> GetMenuItemById(Guid menuItemId)
        {
            var query = new GetMenuItemByIdQuery { MenuItemId = menuItemId };
            var menuItem = await _mediator.Send(query);

            if (menuItem == null)
                return NotFound();

            var foundMenuItem = _mapper.Map<MenuItemGetDto>(menuItem);
            return Ok(foundMenuItem);
        }
        [HttpDelete]
        [Route("delete-menu-item/{menuItemId}")]
        public async Task<IActionResult> DeleteMenuItem(Guid menuItemId)
        {
            var command = new DeleteMenuItemCommand { MenuItemId = menuItemId };
            var foundMenuItem = await _mediator.Send(command);

            if (foundMenuItem == null)
                return NotFound();

            return NoContent();
        }
    }
}
