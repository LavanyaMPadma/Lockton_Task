using Microsoft.EntityFrameworkCore;
using OnlinePricingCalculator.Domain.Entities;
using OnlinePricingCalculator.Domain.Interfaces;
using OnlinePricingCalculator.Infrastructure.Persistence;

namespace OnlinePricingCalculator.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly PricingDbContext _context;

        public ItemRepository(PricingDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Item>> GetAllActiveAsync()
        {
            return await _context.Items
                .Where(i => i.IsActive)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Item>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.Items
                .Where(i => ids.Contains(i.Id) && i.IsActive)
                .ToListAsync();
        }
    }
}
