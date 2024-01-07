using MediatR;
using MsaProject.Application.Queries.MenuItemQueries;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.QueryHandlers.MenuItemQueryHandlers
{
    public class GetAllMenuItemsByRestaurantIdQueryHandler : IRequestHandler<GetAllMenuItemsByRestaurantIdQuery, List<MenuItem>>
    {
        private readonly IMenuRepository menuRepository;
        private readonly IMenuItemRepository menuItemRepository;

        public GetAllMenuItemsByRestaurantIdQueryHandler(IMenuRepository menuRepository, IMenuItemRepository menuItemRepository)
        {
            this.menuRepository = menuRepository;
            this.menuItemRepository = menuItemRepository;
        }

        public Task<List<MenuItem>> Handle(GetAllMenuItemsByRestaurantIdQuery request, CancellationToken cancellationToken)
        {
            var menu = menuRepository.GetEntityBy(x => x.RestaurantId == request.RestaurantId);

            return Task.FromResult(menuItemRepository.FindAll(x => x.MenuId == menu.Id).ToList());
        }
    }
}
