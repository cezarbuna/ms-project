using MediatR;
using MsaProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.Commands.RestaurantCommands
{
    public class DeleteRestaurantCommand : IRequest<Restaurant>
    {
        public Guid RestaurantId { get; set; }
    }
}
