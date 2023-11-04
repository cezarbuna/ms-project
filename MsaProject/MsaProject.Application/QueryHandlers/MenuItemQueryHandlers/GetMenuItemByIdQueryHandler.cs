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
    public class GetMenuItemByIdQueryHandler : IRequestHandler<GetMenuItemByIdQuery, MenuItem>
    {
        private readonly IMenuItemRepository menuItemRepository;

        public GetMenuItemByIdQueryHandler(IMenuItemRepository menuItemRepository)
        {
            this.menuItemRepository = menuItemRepository;
        }

        public Task<MenuItem> Handle(GetMenuItemByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(menuItemRepository.GetEntityByID(request.MenuItemId));
        }
    }
}
