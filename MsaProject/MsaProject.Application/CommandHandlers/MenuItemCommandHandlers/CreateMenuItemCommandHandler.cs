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

        public CreateMenuItemCommandHandler(IMenuItemRepository menuItemRepository)
        {
            this.menuItemRepository = menuItemRepository;
        }

        public Task<MenuItem> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
        {
            var newMenuItem = new MenuItem
            {
                Name = request.Name,
                Price = request.Price,
                MenuId = request.MenuId
            };

            menuItemRepository.Insert(newMenuItem);
            menuItemRepository.SaveChanges();

            return Task.FromResult(newMenuItem);
        }
    }
}
