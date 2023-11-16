using MediatR;
using MsaProject.Domain;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.Queries.TableQueries
{
    public class GetTableByIdQuery : IRequest<Table>
    {
        public Guid TableId { get; set; }
    }
}
