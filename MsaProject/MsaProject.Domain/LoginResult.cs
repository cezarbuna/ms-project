using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Domain
{
    public class LoginResult
    {
        public string Token { get; set; }
        public bool UserType { get; set; } // false = customer, true = restaurant owner
    }
}
