using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatRPattern.Models;
using MediatR;
using MediatRPattern.Queries;
using MediatRPattern.Commands;
using System;

namespace MediatRPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var query = new GetAllCustomersQuery();
            var response = await _mediator.Send(query);

            return Ok(response);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var query = new GetSingleCustomerQuery(id);
            var response = await _mediator.Send(query);

            return response != null ? (ActionResult) Ok(response) : NotFound();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            var command = new UpdateCustomerCommand(customer);            

            try
            {
                var response = await _mediator.Send(command);
                if(response == null)
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return NoContent(); 
        }



        [HttpPost]
        public async Task<IActionResult> PostCustomer(Customer customer)
        {
            var command = new CreateCustomerCommand(customer);
            var response = await _mediator.Send(command);

            return CreatedAtAction("GetCustomer", new { id = response }, customer);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var query = new GetSingleCustomerQuery(id);
            var customer = await _mediator.Send(query);

            if (customer == null)
            {
                return NotFound();
            }

            var command = new DeleteCustomerCommand(id);
            var response = await _mediator.Send(command);

            return response != null ? (ActionResult)Ok(response) : NotFound();
        }
    }
}
