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
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Reservation>
    {
        private readonly IReservationRepository reservationRepository;
        private readonly ITableRepository tableRepository;
        private readonly ICustomerRepository customerRepository;

        public CreateReservationCommandHandler(IReservationRepository reservationRepository, ITableRepository tableRepository, ICustomerRepository customerRepository)
        {
            this.reservationRepository = reservationRepository;
            this.tableRepository = tableRepository;
            this.customerRepository = customerRepository;
        }

        public Task<Reservation> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            if(tableRepository.Any(x => x.Id == request.TableId) && customerRepository.Any(x => x.Id == request.CustomerId))
            {
                var reservation = new Reservation
                {
                    TableId = request.TableId,
                    CustomerId = request.CustomerId,
                    ReservationTime = request.ReservationTime
                };

                reservationRepository.Insert(reservation);
                reservationRepository.SaveChanges();

                return Task.FromResult(reservation);
            }
            return Task.FromResult<Reservation>(null);
        }
    }
}
