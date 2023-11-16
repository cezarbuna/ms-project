using MediatR;
using MsaProject.Application.Queries.TableQueries;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.QueryHandlers.TableQueryHandlers
{
    public class GetTableByIdQueryHandler : IRequestHandler<GetTableByIdQuery, Table>
    {
        private readonly ITableRepository repository;

        public GetTableByIdQueryHandler(ITableRepository repository)
        {
            this.repository = repository;
        }

        public Task<Table> Handle(GetTableByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.GetEntityByID(request.TableId));
        }
    }
}
