using MediatR;
using MsaProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.Commands.RestaurantCommands
{
    public class CreateRestaurantCommand : IRequest<Restaurant>
    {
        public string Name { get; set; }
        public int NumberOfTables { get; set; }
        public double Rating { get; set; }
        public int OpeningHour { get; set; }
        public int ClosingHour { get; set; }
    }
}
