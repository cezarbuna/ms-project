using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MsaProject.Application.Commands.TableCommands;
using MsaProject.Application.Queries.TableQueries;

namespace MsaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public TablesController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTable(TablePostDto newTable)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateTableCommand
            {
                RestaurantId = newTable.RestaurantId,
                NumberOfSeats = newTable.NumberOfSeats,
                IsBooked = newTable.IsBooked
            };
            var table = await _mediator.Send(command);

            if (table != null)
            {
                var createdTable = _mapper.Map<TableGetDto>(table);
                return CreatedAtAction(nameof(GetTableById), new { tableId = table.Id }, createdTable);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new customer");
        }
        [HttpGet]
        [Route("get-table-by-id/{tableId}")]
        public async Task<IActionResult> GetTableById(Guid tableId)
        {
            var query = new GetTableByIdQuery { TableId = tableId };
            var table = await _mediator.Send(query);

            if (table == null)
                return NotFound();

            var foundTable = _mapper.Map<TableGetDto>(table);
            return Ok(foundTable);
        }
        [HttpGet]
        [Route("get-all-tables-by-restaurant-id/{restaurantId}")]
        public async Task<IActionResult> GetAllTablesByRestaurantId(Guid restaurantId)
        {
            var query = new GetAllTablesByRestaurantIdQuery { RestaurantId = restaurantId };
            var tables = await _mediator.Send(query);

            if (tables == null)
                return NotFound();

            var foundTables = _mapper.Map<List<TableGetDto>>(tables);
            return Ok(foundTables);
        }
        [HttpDelete]
        [Route("delete-table/{tableId}")]
        public async Task<IActionResult> DeleteTable(Guid tableId)
        {
            var command = new DeleteTableCommand { TableId = tableId };
            var foundTable = await _mediator.Send(command);

            if (foundTable == null)
                return NotFound();

            return NoContent();
        }
    }
}
