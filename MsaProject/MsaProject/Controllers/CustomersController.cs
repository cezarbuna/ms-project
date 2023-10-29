using MediatR;
using Microsoft.AspNetCore.Mvc;
using MsaProject.Application.Commands.CustomerCommands;
using MsaProject.Domain;
using MsaProject.Dtos.CustomerDtos;
using AutoMapper;
using MsaProject.Application.Queries.CustomerQueries;

namespace MsaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public CustomersController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerPostDto newCustomer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateCustomerCommand
            {
                Email = newCustomer.Email,
                Password = newCustomer.Password,
                Age = newCustomer.Age,
                Username = newCustomer.Username,
                FullName = newCustomer.FullName
            };

            var customer = _mapper.Map<CustomerPostDto, Customer>(newCustomer);
            var createdCustomer = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCustomerById), new { customerId = customer.Id }, createdCustomer);
        }
        [HttpGet]
        [Route("get-customer-by-id/{customerId}")]
        public async Task<IActionResult> GetCustomerById(Guid customerId)
        {
            var query = new GetCustomerByIdQuery { Id = customerId };
            var customer = await _mediator.Send(query);

            if (customer == null)
                return NotFound();

            var foundCustomer = _mapper.Map<CustomerGetDto>(customer);
            return Ok(foundCustomer);
        }
        [HttpGet]
        [Route("get-all-customers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _mediator.Send(new GetAllCustomersQuery());

            var foundCustomers = _mapper.Map<List<CustomerGetDto>>(customers);
            return Ok(foundCustomers);
        }
        [HttpDelete]
        [Route("delete-customer/{customerId}")]
        public async Task<IActionResult> DeleteCustomer(Guid customerId)
        {
            var command = new DeleteCustomerCommand { Id = customerId };
            var foundCustomer = await _mediator.Send(command);

            if (foundCustomer == null)
                return NotFound();

            return NoContent();
        }
    }
}
