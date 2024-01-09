using MediatR;
using MsaProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.Queries.TableQueries
{
    public class GetAllTablesByDateQuery : IRequest<List<Table>>
    {
        public DateOnly Date { get; set; }
        public Guid RestaurantId { get; set; }
    }
}
