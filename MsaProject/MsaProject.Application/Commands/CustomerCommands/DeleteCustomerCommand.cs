using MediatR;
using MsaProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.Commands.CustomerCommands
{
    public class DeleteCustomerCommand : IRequest<Customer>
    {
        public Guid Id { get; set; }
    }
}
