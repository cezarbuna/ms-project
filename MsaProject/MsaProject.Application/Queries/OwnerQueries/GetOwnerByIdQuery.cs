using MediatR;
using MsaProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.Queries.OwnerQueries
{
    public class GetOwnerByIdQuery : IRequest<Owner>
    {
        public Guid OwnerId { get; set; }
    }
}
