using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Dal.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(MsaProjectDbContext context) : base(context)
        {
        }

        public IEnumerable<Reservation> GetAllByCustomerId(Guid customerId)
        {
            return context.Reservations.Where(r => r.CustomerId == customerId);
        }

        public IEnumerable<Reservation> GetAllByTableId(Guid tableId)
        {
            return context.Reservations.Where(r => r.TableId == tableId);
        }
    }
}
