using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureMvc.Application.Products.Commands;
using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
                throw new ApplicationException("Error could not be found.");

            product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image,request.CategoryId);
            
            return await _productRepository.UpdateAsync(product);
        }
    }
}
