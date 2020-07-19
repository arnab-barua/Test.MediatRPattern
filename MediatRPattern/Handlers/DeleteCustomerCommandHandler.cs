using MediatR;
using MediatRPattern.Commands;
using MediatRPattern.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRPattern.Handlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Customer>
    {
        private readonly ApplicationDbContext _context;

        public DeleteCustomerCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(request._id);

            if (customer == null)
            {
                return null;
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }
    }
}
