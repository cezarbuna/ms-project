using MediatR;
using MsaProject.Application.Queries.ReservationQueries;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.QueryHandlers.ReservationQueryHandlers
{
    public class GetAllReservationsWithInfoQueryHandler : IRequestHandler<GetAllReservationsWithInfoQuery, List<ReservationInfo>>
    {
        private readonly IReservationRepository reservationRepository;
        private readonly ITableRepository tableRepository;
        private readonly IRestaurantRepository restaurantRepository;

        public GetAllReservationsWithInfoQueryHandler(IReservationRepository reservationRepository, ITableRepository tableRepository, IRestaurantRepository restaurantRepository)
        {
            this.reservationRepository = reservationRepository;
            this.tableRepository = tableRepository;
            this.restaurantRepository = restaurantRepository;
        }

        public Task<List<ReservationInfo>> Handle(GetAllReservationsWithInfoQuery request, CancellationToken cancellationToken)
        {
            var reservations = reservationRepository.GetAllByCustomerId(request.CustomerId);

            var result = new List<ReservationInfo>();

            foreach (var reservation in reservations)
            {
                var table = tableRepository.GetEntityByID(reservation.TableId);
                var restaurant = restaurantRepository.GetEntityByID(table.RestaurantId);

                result.Add(new ReservationInfo
                {
                    Id = reservation.Id,
                    CustomerId = reservation.CustomerId,
                    TableId = reservation.TableId,
                    ReservationDate = reservation.ReservationDate,
                    NumberOfSeats = table.NumberOfSeats,
                    RestaurantName = restaurant.Name
                });
            }

            return Task.FromResult(result);
        }
    }
}
