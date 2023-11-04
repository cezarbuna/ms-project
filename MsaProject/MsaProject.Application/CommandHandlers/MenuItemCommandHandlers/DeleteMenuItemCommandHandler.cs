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
    public class DeleteMenuItemCommandHandler : IRequestHandler<DeleteMenuItemCommand, MenuItem>
    {
        private readonly IMenuItemRepository menuItemRepository;

        public DeleteMenuItemCommandHandler(IMenuItemRepository menuItemRepository)
        {
            this.menuItemRepository = menuItemRepository;
        }

        public Task<MenuItem> Handle(DeleteMenuItemCommand request, CancellationToken cancellationToken)
        {
            var menuItem = menuItemRepository.GetEntityByID(request.MenuItemId);

            menuItemRepository.Delete(menuItem);
            menuItemRepository.SaveChanges();

            return Task.FromResult(menuItem);
        }
    }
}
