using MediatR;
using MsaProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.Commands.MenuCommands
{
    public class DeleteMenuCommand : IRequest<Menu>
    {
        public Guid MenuId { get; set; }
    }
}
