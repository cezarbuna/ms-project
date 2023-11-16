using MediatR;
using MsaProject.Domain;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.Commands.TableCommands
{
    public class DeleteTableCommand : IRequest<Table>
    {
        public Guid TableId { get; set; }
    }
}
