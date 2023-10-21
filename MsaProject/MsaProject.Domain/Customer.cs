using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Domain
{
    public class Customer : User
    {
        public string Username { get; set; }
        public int Age { get; set; }
    }
}
