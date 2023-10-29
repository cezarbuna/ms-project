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
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Email = request.Email,
                Age = request.Age,
                FullName = request.FullName,
                Username = request.Username,
                Password = request.Password
            };

            customerRepository.Insert(customer);
            customerRepository.SaveChanges();

            return Task.FromResult(customer);
        }
    }
}
