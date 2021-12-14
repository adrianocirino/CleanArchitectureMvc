using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitectureMvc.Domain.Entities;

namespace CleanArchitectureMvc.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetByIdAsync(int? id);

        Task<Product> GetProductCategoryAsync(int? id);

        Task<Product> CreateAsync(Product category);
        Task<Product> UpdateAsync(Product category);
        Task<Product> RemoveAsync(Product category);
    }
}
