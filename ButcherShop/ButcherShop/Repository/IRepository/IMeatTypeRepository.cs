using ButcherShop.Models;

namespace ButcherShop.Repository.IRepository
{
    public interface IMeatTypeRepository : IRepository<MeatType>
    {
        public Task<MeatType> UpdateAsync(MeatType meatType);
    }
}
