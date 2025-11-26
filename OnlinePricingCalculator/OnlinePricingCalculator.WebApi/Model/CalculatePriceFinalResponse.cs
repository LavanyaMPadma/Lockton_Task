namespace OnlinePricingCalculator.WebApi.Models
{
    public class CalculatePriceFinalResponse
    {
        public List<CalculateResultItem> Item { get; set; } = new();
    }
}
