using MediatR;
using MsaProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.Commands.CustomerCommands
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
    }
}
