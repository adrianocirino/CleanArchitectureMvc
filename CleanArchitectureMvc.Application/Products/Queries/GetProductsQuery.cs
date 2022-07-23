using System.Collections.Generic;
using CleanArchitectureMvc.Domain.Entities;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>, IRequest<Unit>
    {

    }
}
