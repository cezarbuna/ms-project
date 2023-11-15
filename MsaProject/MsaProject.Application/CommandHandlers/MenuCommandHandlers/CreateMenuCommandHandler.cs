using MediatR;
using MsaProject.Application.Commands.MenuCommands;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.CommandHandlers.MenuCommandHandlers
{

    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, Menu>
    {
        private readonly IMenuRepository menuRepository;
        private readonly IRestaurantRepository restaurantRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository, IRestaurantRepository restaurantRepository)
        {
            this.menuRepository = menuRepository;
            this.restaurantRepository = restaurantRepository;
        }

        public Task<Menu> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            if (menuRepository.Any(x => x.Id == request.RestaurantId))
            {
                var newMenu = new Menu
                {
                    RestaurantId = request.RestaurantId
                };
                //newMenu.MenuItems = menuItemRepository.FindAll(x => x.MenuId == newMenu.Id).ToList();

                menuRepository.Insert(newMenu);
                menuRepository.SaveChanges();

                return Task.FromResult(newMenu);
            }
            return Task.FromResult<Menu>(null);

        }
    }
}
