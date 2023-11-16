using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MsaProject.Application.Commands.RestaurantCommands;
using MsaProject.Application.Queries.RestaurantQueries;

namespace MsaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public RestaurantsController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(RestaurantPostDto newRestaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateRestaurantCommand
            {
                 Name = newRestaurant.Name,
                 Rating = newRestaurant.Rating,
                  NumberOfTables = newRestaurant.NumberOfTables,
                  OpeningHour = newRestaurant.OpeningHour,
                  ClosingHour = newRestaurant.ClosingHour
            };

            var restaurant = await _mediator.Send(command);

            if (restaurant != null)
            {
                var createdRestaurant= _mapper.Map<RestaurantGetDto>(restaurant);
                return CreatedAtAction(nameof(GetRestaurantById), new { restaurantId = restaurant.Id }, createdRestaurant);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new menu item");
        }

        [HttpGet]
        [Route("get-restaurant-by-id/{restaurantId}")]
        public async Task<IActionResult> GetRestaurantById(Guid restaurantId)
        {
            var query = new GetRestaurantByIdQuery { RestaurantId = restaurantId };
            var restaurant = await _mediator.Send(query);

            if (restaurant == null)
                return NotFound();

            var foundRestaurant = _mapper.Map<RestaurantGetDto>(restaurant);
            return Ok(foundRestaurant);
        }
        [HttpGet]
        [Route("get-all-restaurants")]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var query = new GetAllRestaurantsQuery();
            var restaurants = await _mediator.Send(query);

            if (restaurants == null)
                return NotFound();

            var foundRestaurants = _mapper.Map<List<RestaurantGetDto>>(restaurants);
            return Ok(foundRestaurants);
        }
        [HttpDelete]
        [Route("delete-restaurant/{restaurantId}")]
        public async Task<IActionResult> DeleteRestaurant(Guid restaurantId)
        {
            var command = new DeleteRestaurantCommand { RestaurantId = restaurantId };
            var foundRestaurant = await _mediator.Send(command);

            if (foundRestaurant == null)
                return NotFound();

            return NoContent();
        }
    }
}
