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
    public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, Owner>
    {
        private readonly IOwnerRepository repository;

        public CreateOwnerCommandHandler(IOwnerRepository repository)
        {
            this.repository = repository;
        }

        public Task<Owner> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = new Owner
            {
                OwnerId = request.OwnerId,
                Email = request.Email,
                Password = request.Password,
                FullName = request.FullName
            };

            repository.Insert(owner);
            repository.SaveChanges();

            return Task.FromResult(owner);
        }
    }
}
