using MediatR;
using MsaProject.Application.Queries.TableQueries;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.QueryHandlers.TableQueryHandlers
{
    public class GetAllTablesByRestaurantIdQueryHandler : IRequestHandler<GetAllTablesByRestaurantIdQuery, List<Table>>
    {
        private readonly ITableRepository repository;

        public GetAllTablesByRestaurantIdQueryHandler(ITableRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<Table>> Handle(GetAllTablesByRestaurantIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.FindAll(x => x.RestaurantId == request.RestaurantId).ToList());
        }
    }
}
