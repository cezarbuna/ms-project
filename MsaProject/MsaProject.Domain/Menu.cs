using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Domain
{
    public class Menu : Entity
    {
        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
