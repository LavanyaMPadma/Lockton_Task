namespace OnlinePricingCalculator.Domain.Entities
{
    public class Discount
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int DiscountTypeId { get; set; }

        public DiscountType? DiscountType { get; set; }

        public decimal? PercentageValue { get; set; }

        public int? BuyQuantity { get; set; }

        public int? FreeQuantity { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<DiscountItem> DiscountItems { get; set; } = new List<DiscountItem>();
    }
}
