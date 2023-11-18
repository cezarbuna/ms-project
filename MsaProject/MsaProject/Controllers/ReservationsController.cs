using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MsaProject.Application.Commands.ReservationCommands;
using MsaProject.Application.Queries.ReservationQueries;
using MsaProject.Domain;

namespace MsaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public ReservationsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservation(ReservationPostDto newReservation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateReservationCommand
            {
                CustomerId = newReservation.CustomerId,
                TableId = newReservation.TableId,
                ReservationTime = newReservation.ReservationTime
            };

            var reservation = await _mediator.Send(command);

            if(reservation != null)
            {
                var createdReservation = _mapper.Map<ReservationGetDto>(reservation);
                return CreatedAtAction(nameof(GetReservationById), new { reservationId = reservation.Id }, createdReservation);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new reservation");
        }
        [HttpGet]
        [Route("get-reservation-by-id/{reservationId}")]
        public async Task<IActionResult> GetReservationById(Guid reservationId)
        {
            var query = new GetReservationByIdQuery
            {
                ReservationId = reservationId
            };
            var reservation = await _mediator.Send(query);

            if (reservation != null)
            {
                return NotFound();
            }
            var foundReservation = _mapper.Map<ReservationGetDto>(reservation);
            return Ok(foundReservation);
        }
    }
    
}
