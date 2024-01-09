using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Domain
{
    public class Reservation : Entity
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        //public Guid RestaurantId { get; set; }
        //public Restaurant Restaurant { get; set; }
        public Guid TableId { get; set; }
        public Table Table { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
