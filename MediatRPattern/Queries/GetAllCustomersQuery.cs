using MediatR;
using MediatRPattern.Models;
using System.Collections.Generic;

namespace MediatRPattern.Queries
{
    public class GetAllCustomersQuery : IRequest<List<Customer>>
    {
    }
}
