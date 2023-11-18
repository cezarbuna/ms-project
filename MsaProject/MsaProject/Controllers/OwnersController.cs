using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MsaProject.Application.Commands.OwnerCommands;
using MsaProject.Application.Queries.OwnerQueries;
using MsaProject.Domain;
using MsaProject.Dtos.OwnerDto;

namespace MsaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public OwnersController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOwner(OwnerPostDto newOwner)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateOwnerCommand
            {
                OwnerId = newOwner.OwnerId,
                Email = newOwner.Email,
                Password = newOwner.Password,
                FullName = newOwner.FullName
            };
            var owner = await _mediator.Send(command);

            if (owner != null)
            {
                var createdOwner = _mapper.Map<OwnerGetDo>(owner);
                return CreatedAtAction(nameof(GetOwnerById), new { ownerId = owner.Id }, createdOwner);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new owner");
        }
        [HttpGet]
        [Route("get-owner-by-id/{ownerId}")]
        public async Task<IActionResult> GetOwnerById(Guid ownerId)
        {
            var query = new GetOwnerByIdQuery { OwnerId = ownerId };
            var owner = await _mediator.Send(query);

            if (owner == null)
                return NotFound();

            var foundOwner = _mapper.Map<OwnerGetDo>(owner);
            return Ok(foundOwner);
        }
        [HttpGet]
        [Route("get-all-owners")]
        public async Task<IActionResult> GetAllOwners()
        {
            var query = new GetAllOwnersQuery();
            var owners = await _mediator.Send(query);

            if (owners == null)
                return NotFound();

            var foundOwners = _mapper.Map<List<OwnerGetDo>>(owners);
            return Ok(foundOwners);
        }
        [HttpDelete]
        [Route("delete-owner/{ownerId}")]
        public async Task<IActionResult> DeleteOwner(Guid ownerId)
        {
            var command = new DeleteOwnerCommand { OwnerId = ownerId };
            var foundOwner = await _mediator.Send(command);

            if (foundOwner == null)
                return NotFound();

            return NoContent();
        }
    }
}
