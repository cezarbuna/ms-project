using MediatR;
using MsaProject.Application.Commands.OwnerCommands;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.CommandHandlers.OwnerCommandHandlers
{
    public class DeleteOwnerCommandHandler : IRequestHandler<DeleteOwnerCommand, Owner>
    {
        private readonly IOwnerRepository repository;

        public DeleteOwnerCommandHandler(IOwnerRepository repository)
        {
            this.repository = repository;
        }

        public Task<Owner> Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = repository.GetEntityByID(request.OwnerId);
            
            repository.Delete(owner);
            repository.SaveChanges(); ;

            return Task.FromResult(owner);
        }
    }
}
