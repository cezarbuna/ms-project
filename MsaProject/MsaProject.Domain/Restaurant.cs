using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Domain
{
    public class Restaurant : Entity
    {
        public string Name { get; set; }
        public int NumberOfTables { get; set; }
        //public ICollection<Table> Tables { get; set; }
        public double Rating { get; set; }
        public int OpeningHour { get; set; }
        public int ClosingHour { get; set; }
        public string ImageUrl { get; set; }

    }
}
