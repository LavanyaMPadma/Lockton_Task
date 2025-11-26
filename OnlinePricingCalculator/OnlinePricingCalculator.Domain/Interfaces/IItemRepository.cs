using OnlinePricingCalculator.Domain.Entities;

namespace OnlinePricingCalculator.Domain.Interfaces
{
    public interface IItemRepository
    {
        Task<IReadOnlyList<Item>> GetByIdsAsync(IEnumerable<int> ids);

        Task<IReadOnlyList<Item>> GetAllActiveAsync();
    }
}
