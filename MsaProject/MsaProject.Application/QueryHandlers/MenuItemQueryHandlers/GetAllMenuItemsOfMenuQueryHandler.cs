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
    public class GetAllMenuItemsOfMenuQueryHandler : IRequestHandler<GetAllMenuItemsOfMenuQuery, List<MenuItem>>
    {
        private readonly IMenuRepository menuRepository;

        public GetAllMenuItemsOfMenuQueryHandler(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public Task<List<MenuItem>> Handle(GetAllMenuItemsOfMenuQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(menuRepository.GetEntityByID(request.MenuId).MenuItems.ToList());
        }
    }
}
