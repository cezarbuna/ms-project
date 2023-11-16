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
    public class CreateTableCommand : IRequest<Table>
    {
        public Guid RestaurantId { get; set; }
        public int NumberOfSeats { get; set; }
        public bool IsBooked { get; set; }
    }
}
