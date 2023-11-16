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
    public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, Restaurant>
    {
        private readonly IRestaurantRepository repository;

        public DeleteRestaurantCommandHandler(IRestaurantRepository repository)
        {
            this.repository = repository;
        }

        public Task<Restaurant> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = repository.GetEntityByID(request.RestaurantId);

            repository.Delete(restaurant);
            repository.SaveChanges();

            return Task.FromResult(restaurant);
        }
    }
}
