using MediatR;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MsaProject.Application.Commands.TableCommands;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.CommandHandlers.TableCommandHandlers
{
    public class DeleteTableCommandHandler : IRequestHandler<DeleteTableCommand, Table>
    {
        private readonly ITableRepository repository;

        public DeleteTableCommandHandler(ITableRepository repository)
        {
            this.repository = repository;
        }

        public Task<Table> Handle(DeleteTableCommand request, CancellationToken cancellationToken)
        {
            var table = repository.GetEntityByID(request.TableId);

            repository.Delete(table);
            repository.SaveChanges();

            return Task.FromResult(table);
        }
    }
}
