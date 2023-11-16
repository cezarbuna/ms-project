using MediatR;
using MsaProject.Application.Commands.TableCommands;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.CommandHandlers.TableCommandHandlers
{
    public class CreateTableCommandHandler : IRequestHandler<CreateTableCommand, Table>
    {
        private readonly ITableRepository tableRepository;
        private readonly IRestaurantRepository restaurantRepository;

        public CreateTableCommandHandler(ITableRepository tableRepository, IRestaurantRepository restaurantRepository)
        {
            this.tableRepository = tableRepository;
            this.restaurantRepository = restaurantRepository;
        }

        public Task<Table> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            if (restaurantRepository.Any(x => x.Id == request.RestaurantId))
            {
                var table = new Table
                {
                    RestaurantId = request.RestaurantId,
                    NumberOfSeats = request.NumberOfSeats,
                    IsBooked = request.IsBooked
                };

                tableRepository.Insert(table);
                tableRepository.SaveChanges();

                return Task.FromResult(table);
            }

            return Task.FromResult<Table>(null);

        }
    }
}
