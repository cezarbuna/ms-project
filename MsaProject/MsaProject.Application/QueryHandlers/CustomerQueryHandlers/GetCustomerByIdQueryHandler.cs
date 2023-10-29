using MediatR;
using MsaProject.Application.Queries.CustomerQueries;
using MsaProject.Domain;
using MsaProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Application.QueryHandlers.CustomerQueryHandlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly ICustomerRepository customerRepository;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(customerRepository.GetEntityByID(request.Id));
        }
    }
}
