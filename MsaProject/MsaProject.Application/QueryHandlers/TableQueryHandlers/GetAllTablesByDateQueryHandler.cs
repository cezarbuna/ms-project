using MediatR;
using MsaProject.Application.Queries.TableQueries;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.QueryHandlers.TableQueryHandlers
{
    public class GetAllTablesByDateQueryHandler : IRequestHandler<GetAllTablesByDateQuery, List<Table>>
    {
        private readonly ITableRepository tableRepository;
        private readonly IReservationRepository reservationRepository;

        public GetAllTablesByDateQueryHandler(ITableRepository tableRepository, IReservationRepository reservationRepository)
        {
            this.tableRepository = tableRepository;
            this.reservationRepository = reservationRepository;
        }

        public Task<List<Table>> Handle(GetAllTablesByDateQuery request, CancellationToken cancellationToken)
        {
            List<Table> result = new List<Table>();

            var tables = tableRepository.FindAll(x => x.RestaurantId == request.RestaurantId);

            foreach (var table in tables)
            {
                var reservation = reservationRepository.GetEntityBy(x => x.TableId == table.Id && x.ReservationDate.Date == request.Date.Date);
                if(reservation != null)
                {
                    result.Add(new Table
                    {
                        Id = table.Id,
                        Restaurant = table.Restaurant,
                        RestaurantId = table.RestaurantId,
                        NumberOfSeats = table.NumberOfSeats,
                        IsBooked = true
                    });
                }
                else
                {
                    result.Add(new Table
                    {
                        Id = table.Id,
                        Restaurant = table.Restaurant,
                        RestaurantId = table.RestaurantId,
                        NumberOfSeats = table.NumberOfSeats,
                        IsBooked = false
                    });
                }
            }
            return Task.FromResult(result.ToList());
        }
    }
}
