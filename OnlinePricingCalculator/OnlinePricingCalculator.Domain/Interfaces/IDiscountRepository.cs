using OnlinePricingCalculator.Domain.Entities;

namespace OnlinePricingCalculator.Domain.Interfaces
{
    public interface IDiscountRepository
    {
        Task<IReadOnlyList<Discount>> GetActiveDiscountsAsync();
    }
}
