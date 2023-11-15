using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Domain
{
    public class Owner : User
    {
        public string OwnerId { get; set; }
        //public ICollection<Restaurant> Restaurants { get; set; }
    }
}
