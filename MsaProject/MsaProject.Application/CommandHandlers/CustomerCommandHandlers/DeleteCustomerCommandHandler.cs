using MediatR;
using MsaProject.Application.Commands.CustomerCommands;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.CommandHandlers.CustomerCommandHandlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Customer>
    {
        private readonly ICustomerRepository customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Task<Customer> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = customerRepository.GetEntityByID(request.Id);

            customerRepository.Delete(customer);
            customerRepository.SaveChanges();

            return Task.FromResult(customer);
        }
    }
}
