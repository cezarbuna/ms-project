using MediatR;
using MsaProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.Queries.MenuQueries
{
    public class GetMenuByIdQuery : IRequest<Menu>
    {
        public Guid RestaurantId { get; set; }
    }
}
