using Microsoft.EntityFrameworkCore;
using OnlinePricingCalculator.Domain.Entities;

namespace OnlinePricingCalculator.Infrastructure.Persistence
{
    public class PricingDbContext : DbContext
    {
        public PricingDbContext(DbContextOptions<PricingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items => Set<Item>();
        
        public DbSet<DiscountType> DiscountTypes => Set<DiscountType>();

        public DbSet<Discount> Discounts => Set<Discount>();

        public DbSet<DiscountItem> DiscountItems => Set<DiscountItem>();
    }
}
