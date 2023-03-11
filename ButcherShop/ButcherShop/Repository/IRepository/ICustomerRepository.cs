using ButcherShop.Models;

namespace ButcherShop.Repository.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>    
    {
        Task<Customer> UpdateAsync(Customer customer);

    }
}
