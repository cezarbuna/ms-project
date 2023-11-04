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
    public class GetAllByMenuIdQueryHandler : IRequestHandler<GetAllByMenuIdQuery, List<MenuItem>>
    {
        private readonly IMenuItemRepository menuItemRepository;

        public GetAllByMenuIdQueryHandler(IMenuItemRepository menuItemRepository)
        {
            this.menuItemRepository = menuItemRepository;
        }

        public Task<List<MenuItem>> Handle(GetAllByMenuIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(menuItemRepository.FindAll(m => m.MenuId == request.MenuId).ToList());
        }
    }
}
