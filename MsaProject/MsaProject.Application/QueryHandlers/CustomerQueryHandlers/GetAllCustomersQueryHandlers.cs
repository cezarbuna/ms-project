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
    public class GetAllCustomersQueryHandlers : IRequestHandler<GetAllCustomersQuery, List<Customer>>
    {
        private readonly ICustomerRepository customerRepository;

        public GetAllCustomersQueryHandlers(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Task<List<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(customerRepository.FindAll().ToList());
        }
    }
}
