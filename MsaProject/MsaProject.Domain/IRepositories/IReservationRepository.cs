using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Domain.IRepositories
{
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
        public IEnumerable<Reservation> GetAllByCustomerId(Guid customerId);
        public IEnumerable<Reservation> GetAllByTableId(Guid tableId);
    }
}
