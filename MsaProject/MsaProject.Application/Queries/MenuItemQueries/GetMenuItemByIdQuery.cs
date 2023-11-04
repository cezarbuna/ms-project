using MediatR;
using MsaProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.Queries.MenuItemQueries
{
    public class GetMenuItemByIdQuery : IRequest<MenuItem>
    {
        public Guid MenuItemId { get; set; }
    }
}
