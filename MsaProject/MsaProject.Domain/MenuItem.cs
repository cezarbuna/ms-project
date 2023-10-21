using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Domain
{
    public class MenuItem : Entity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Guid MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
