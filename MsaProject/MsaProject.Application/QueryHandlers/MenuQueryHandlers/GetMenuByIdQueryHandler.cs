using MediatR;
using MsaProject.Application.Queries.MenuQueries;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.QueryHandlers.MenuQueryHandlers
{
    public class GetMenuByIdQueryHandler : IRequestHandler<GetMenuByIdQuery, Menu>
    {
        private readonly IMenuRepository menuRepository;

        public GetMenuByIdQueryHandler(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public Task<Menu> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(menuRepository.GetEntityBy(x => x.RestaurantId == request.RestaurantId));
        }
    }
}
