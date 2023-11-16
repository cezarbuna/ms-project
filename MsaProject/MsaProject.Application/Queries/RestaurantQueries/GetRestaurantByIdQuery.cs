using MediatR;
using MsaProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.Queries.RestaurantQueries
{
    public class GetRestaurantByIdQuery : IRequest<Restaurant>
    {
        public Guid RestaurantId { get; set; }
    }
}
