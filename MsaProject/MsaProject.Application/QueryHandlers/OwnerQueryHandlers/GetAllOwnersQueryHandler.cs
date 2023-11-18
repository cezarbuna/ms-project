using MediatR;
using MsaProject.Application.Queries.OwnerQueries;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.QueryHandlers.OwnerQueryHandlers
{
    public class GetAllOwnersQueryHandler : IRequestHandler<GetAllOwnersQuery, List<Owner>>
    {
        private readonly IOwnerRepository repository;

        public GetAllOwnersQueryHandler(IOwnerRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<Owner>> Handle(GetAllOwnersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.FindAll().ToList());
        }
    }
}
