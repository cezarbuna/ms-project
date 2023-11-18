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
    public class GetAllReservationsByCustomerIdQueryHandler : IRequestHandler<GetAllReservationsByCustomerIdQuery, List<Reservation>>
    {
        private readonly IReservationRepository repository;

        public GetAllReservationsByCustomerIdQueryHandler(IReservationRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<Reservation>> Handle(GetAllReservationsByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.GetAllByCustomerId(request.CustomerId).ToList());
        }
    }
}
