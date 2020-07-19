using MediatR;
using MediatRPattern.Models;

namespace MediatRPattern.Queries
{
    public class GetSingleCustomerQuery : IRequest<Customer>
    {
        public readonly int _id;

        public GetSingleCustomerQuery(int id)
        {
            _id = id;
        }
    }
}
