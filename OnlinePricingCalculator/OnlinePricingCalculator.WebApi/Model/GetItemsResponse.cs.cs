namespace OnlinePricingCalculator.WebApi.Models
{
    public class GetItemsResponse
    {
        public IEnumerable<ItemDto> Items { get; set; } = new List<ItemDto>();
    }
}
