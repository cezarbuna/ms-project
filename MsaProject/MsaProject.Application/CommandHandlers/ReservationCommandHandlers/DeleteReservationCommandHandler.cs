using MediatR;
using MsaProject.Application.Commands.ReservationCommands;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.CommandHandlers.ReservationCommandHandlers
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, Reservation>
    {
        private readonly IReservationRepository reservationRepository;

        public DeleteReservationCommandHandler(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        public Task<Reservation> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = reservationRepository.GetEntityByID(request.ReservationId);

            reservationRepository.Delete(reservation);
            reservationRepository.SaveChanges();

            return Task.FromResult(reservation);
        }
    }
}
