using ButcherShop.Data;
using ButcherShop.Models;
using ButcherShop.Repository.IRepository;

namespace ButcherShop.Repository
{
    public class MeatTypeRepository : Repository<MeatType>, IMeatTypeRepository
    {

        private readonly ApplicationDbContext _db;

        public MeatTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public Task<MeatType> UpdateAsync(MeatType meatType)
        {
            throw new NotImplementedException();
        }
    }
}
