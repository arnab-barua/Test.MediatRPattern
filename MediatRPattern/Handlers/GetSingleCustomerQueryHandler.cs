using MediatR;
using MediatRPattern.Models;
using MediatRPattern.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRPattern.Handlers
{
    public class GetSingleCustomerQueryHandler : IRequestHandler<GetSingleCustomerQuery, Customer>
    {
        private readonly ApplicationDbContext _context;

        public GetSingleCustomerQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Customer> Handle(GetSingleCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(request._id);
            return customer;
        }
    }
}
