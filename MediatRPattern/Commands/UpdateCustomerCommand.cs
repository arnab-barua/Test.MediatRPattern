using MediatR;
using MediatRPattern.Models;

namespace MediatRPattern.Commands
{
    public class UpdateCustomerCommand : IRequest<Customer>
    {
        public readonly Customer _customer;

        public UpdateCustomerCommand(Customer customer)
        {
            _customer = customer;
        }
    }
}
