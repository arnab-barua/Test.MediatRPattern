using MediatR;
using MediatRPattern.Models;

namespace MediatRPattern.Commands
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public readonly Customer _customer;

        public CreateCustomerCommand(Customer customer)
        {
            _customer = customer;
        }
    }
}
