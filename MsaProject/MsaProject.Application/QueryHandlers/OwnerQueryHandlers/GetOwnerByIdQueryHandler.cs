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
    public class GetOwnerByIdQueryHandler : IRequestHandler<GetOwnerByIdQuery, Owner>
    {
        private readonly IOwnerRepository repository;

        public GetOwnerByIdQueryHandler(IOwnerRepository repository)
        {
            this.repository = repository;
        }

        public Task<Owner> Handle(GetOwnerByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.GetEntityByID(request.OwnerId));
        }
    }
}
