using MediatR;
using MsaProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.Commands.OwnerCommands
{
    public class DeleteOwnerCommand : IRequest<Owner>
    {
        public Guid OwnerId { get; set; }
    }
}
