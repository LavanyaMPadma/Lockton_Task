using Microsoft.EntityFrameworkCore;
using OnlinePricingCalculator.Domain.Entities;
using OnlinePricingCalculator.Domain.Interfaces;
using OnlinePricingCalculator.Infrastructure.Persistence;

namespace OnlinePricingCalculator.Infrastructure.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly PricingDbContext _context;

        public DiscountRepository(PricingDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Discount>> GetActiveDiscountsAsync()
        {
            return await _context.Discounts
                .Where(d => d.IsActive)
                .Include(d => d.DiscountType)
                .Include(d => d.DiscountItems)
                .ToListAsync();
        }
    }
}
