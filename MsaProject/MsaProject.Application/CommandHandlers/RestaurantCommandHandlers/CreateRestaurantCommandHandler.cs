using MediatR;
using MsaProject.Application.Commands.RestaurantCommands;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.CommandHandlers.RestaurantCommandHandlers
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, Restaurant>
    {
        private readonly IRestaurantRepository repository;

        public CreateRestaurantCommandHandler(IRestaurantRepository repository)
        {
            this.repository = repository;
        }

        public Task<Restaurant> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var newRestaurant = new Restaurant
            {
                Name = request.Name,
                Rating = request.Rating,
                OpeningHour = request.OpeningHour,
                ClosingHour = request.ClosingHour,
                NumberOfTables = request.NumberOfTables
            };

            repository.Insert(newRestaurant);
            repository.SaveChanges();

            return Task.FromResult(newRestaurant);
        }
    }
}
