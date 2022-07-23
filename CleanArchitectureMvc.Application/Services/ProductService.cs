using AutoMapper;
using CleanArchitectureMvc.Application.DTOs;
using CleanArchitectureMvc.Application.Interfaces;
using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository ??
                throw new ArgumentException(nameof(produtoRepository));
            _mapper = mapper;
        }
        public async Task<ProductDTO> GetById(int? id)
        {
            var productEntity = await _produtoRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var productEntity = await _produtoRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _produtoRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task Remove(int? id)
        {
            var productEntity = _produtoRepository.GetByIdAsync(id).Result;
            await _produtoRepository.RemoveAsync(productEntity);
        }
        public async Task Add(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _produtoRepository.CreateAsync(productEntity);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _produtoRepository.UpdateAsync(productEntity);
        }
    }
}
