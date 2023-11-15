using MediatR;
using MsaProject.Application.Commands.MenuItemCommands;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.CommandHandlers.MenuItemCommandHandlers
{
    public class CreateMenuItemCommandHandler : IRequestHandler<CreateMenuItemCommand, MenuItem>
    {
        private readonly IMenuItemRepository menuItemRepository;
        private readonly IMenuRepository menuRepository;

        public CreateMenuItemCommandHandler(IMenuItemRepository menuItemRepository, IMenuRepository menuRepository)
        {
            this.menuItemRepository = menuItemRepository;
            this.menuRepository = menuRepository;
        }

        public Task<MenuItem> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
        {
            var newMenuItem = new MenuItem
            {
                Name = request.Name,
                Price = request.Price,
                MenuId = request.MenuId
            };

            var menu = menuRepository.GetEntityByID(request.MenuId);

            if (menu != null)
            {
                //menu.MenuItems.Add(newMenuItem);
                menuRepository.Update(menu);
                menuRepository.SaveChanges();
                menuItemRepository.Insert(newMenuItem);
                menuItemRepository.SaveChanges();

                return Task.FromResult(newMenuItem);
            }
            return Task.FromResult<MenuItem>(null);
        }
    }
}
