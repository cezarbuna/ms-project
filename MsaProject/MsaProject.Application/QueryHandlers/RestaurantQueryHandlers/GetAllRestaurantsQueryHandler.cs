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
    public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, List<Restaurant>>
    {
        private readonly IRestaurantRepository repository;

        public GetAllRestaurantsQueryHandler(IRestaurantRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<Restaurant>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.FindAll().ToList());
        }
    }
}
