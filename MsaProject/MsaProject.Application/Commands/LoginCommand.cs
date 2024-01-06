using MediatR;
using MsaProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.Commands
{
    public class LoginCommand : IRequest<LoginResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
