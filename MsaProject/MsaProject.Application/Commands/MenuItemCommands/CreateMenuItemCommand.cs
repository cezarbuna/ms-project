using MediatR;
using MsaProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.Commands.MenuItemCommands
{
    public class CreateMenuItemCommand : IRequest<MenuItem>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Guid MenuId { get; set; }
    }
}
