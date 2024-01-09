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
                //    if (reservationRepository.GetEntityBy(x => x.TableId == table.Id).ReservationDate == request.Date)
                //    {
                //        result.Add(new Table
                //        {
                //            Id = table.Id,
                //            NumberOfSeats = table.NumberOfSeats,
                //            Restaurant = table.Restaurant,
                //            RestaurantId = table.RestaurantId,
                //            IsBooked = true
                //        });
                //    }
                //    else
                //    {
                //        result.Add(new Table
                //        {
                //            Id = table.Id,
                //            NumberOfSeats = table.NumberOfSeats,
                //            Restaurant = table.Restaurant,
                //            RestaurantId = table.RestaurantId,
                //            IsBooked = false
                //        });
                //    }
                //}
            }
            return Task.FromResult(result.ToList());
        }
    }
}
