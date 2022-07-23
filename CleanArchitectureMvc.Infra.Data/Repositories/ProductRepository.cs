using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Interfaces;
using CleanArchitectureMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            return await _context.Products.Include(c => c.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> CreateAsync(Product category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Product> UpdateAsync(Product category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Product> RemoveAsync(Product category)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }
}
