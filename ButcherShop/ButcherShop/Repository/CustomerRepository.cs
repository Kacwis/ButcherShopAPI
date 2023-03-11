using ButcherShop.Data;
using ButcherShop.Models;
using ButcherShop.Repository.IRepository;

namespace ButcherShop.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            dbSet.Update(customer);
            await _db.SaveChangesAsync();
            return customer;                     
        }
    }
}
