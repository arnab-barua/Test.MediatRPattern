using MediatR;
using MediatRPattern.Models;

namespace MediatRPattern.Commands
{
    public class DeleteCustomerCommand : IRequest<Customer>
    {
        public readonly int _id;

        public DeleteCustomerCommand(int id)
        {
            _id = id;
        }
    }
}
