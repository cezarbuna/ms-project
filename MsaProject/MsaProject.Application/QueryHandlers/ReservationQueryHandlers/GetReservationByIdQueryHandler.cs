using MediatR;
using MsaProject.Application.Queries.ReservationQueries;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.QueryHandlers.ReservationQueryHandlers
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, Reservation>
    {
        private readonly IReservationRepository repository;

        public GetReservationByIdQueryHandler(IReservationRepository repository)
        {
            this.repository = repository;
        }

        public Task<Reservation> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.GetEntityByID(request.ReservationId));
        }
    }
}
