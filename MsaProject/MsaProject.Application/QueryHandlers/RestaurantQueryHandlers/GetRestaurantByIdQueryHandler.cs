using MediatR;
using MsaProject.Application.Queries.RestaurantQueries;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.QueryHandlers.RestaurantQueryHandlers
{
    public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, Restaurant>
    {
        private readonly IRestaurantRepository repository;

        public GetRestaurantByIdQueryHandler(IRestaurantRepository repository)
        {
            this.repository = repository;
        }

        public Task<Restaurant> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.GetEntityByID(request.RestaurantId));
        }
    }
}
