using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Domain
{
    public class ReservationInfo : Entity
    {
        public Guid CustomerId { get; set; }
        public Guid TableId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfSeats { get; set; }
        public string RestaurantName { get; set; }
    }
}
