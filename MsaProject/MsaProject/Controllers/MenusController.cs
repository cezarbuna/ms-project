using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MsaProject.Application.Commands.MenuCommands;
using MsaProject.Application.Commands.MenuItemCommands;
using MsaProject.Application.Queries.MenuItemQueries;
using MsaProject.Application.Queries.MenuQueries;
using MsaProject.Domain;
using MsaProject.Dtos.MenuDtos;
using MsaProject.Dtos.MenuItemDto;


namespace MsaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public MenusController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody] MenuPostDto newMenu)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateMenuCommand
            {
                RestaurantId = newMenu.RestaurantId
            };

            var menu = await _mediator.Send(command);

            //if(menu != null)
            //{
            //    var createdMenu = _mapper.Map<MenuGetDto>(menu);
            //    return CreatedAtAction(nameof(GetMenuById), new { menuId = menu.Id }, createdMenu);
            //}

            return Ok(menu);

            //return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new menu");
        }
        [HttpGet]
        [Route("get-menu-by-id/{restaurantId}")]
        public async Task<IActionResult> GetMenuById(Guid  restaurantId)
        {
            var query = new GetMenuByIdQuery { RestaurantId = restaurantId };
            var menu = await _mediator.Send(query);

            if (menu == null)
                return NotFound();

            var foundMenu = _mapper.Map<MenuGetDto>(menu);
            return Ok(foundMenu);
        }
        [HttpDelete]
        [Route("delete-menu/{menuId}")]
        public async Task<IActionResult> DeleteMenu(Guid menuId)
        {
            var command = new DeleteMenuCommand { MenuId = menuId };
            var foundMenu = await _mediator.Send(command);

            if (foundMenu == null)
                return NotFound();

            return NoContent();
        }
    }
}
