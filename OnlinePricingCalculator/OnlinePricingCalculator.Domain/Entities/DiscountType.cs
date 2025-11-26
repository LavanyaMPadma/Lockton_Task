namespace OnlinePricingCalculator.Domain.Entities
{
    public class DiscountType
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty; // "Percentage", "BuyXGetY"

        public ICollection<Discount> Discounts { get; set; } = new List<Discount>();
    }
}
