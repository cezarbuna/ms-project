using MediatR;
using MsaProject.Application.Commands.MenuCommands;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.CommandHandlers.MenuCommandHandlers
{
    public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand, Menu>
    {
        private readonly IMenuRepository menuRepository;

        public DeleteMenuCommandHandler(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public Task<Menu> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = menuRepository.GetEntityByID(request.MenuId);

            menuRepository.Delete(menu);
            menuRepository.SaveChanges();

            return Task.FromResult(menu);
        }
    }
}
