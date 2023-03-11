using ButcherShop.Models;
using System.Linq.Expressions;

namespace ButcherShop.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> UpdateAsync(Product product);
    }
}
