using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Domain
{
    public class Table : Entity
    {
        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int NumberOfSeats { get; set; }
        public bool IsBooked { get; set; }
    }
}
