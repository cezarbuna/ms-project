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
            if(restaurantRepository.Any(x => x.Id == request.RestaurantId))
            {
                var menu = new Menu
                {
                    RestaurantId = request.RestaurantId
                };

                menuRepository.Insert(menu);
                menuRepository.SaveChanges();

                return Task.FromResult(menu);
            }

            return Task.FromResult<Menu>(null);

        }
    }
}
