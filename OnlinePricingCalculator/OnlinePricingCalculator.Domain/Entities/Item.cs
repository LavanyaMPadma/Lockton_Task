namespace OnlinePricingCalculator.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<DiscountItem> DiscountItems { get; set; } = new List<DiscountItem>();
    }
}
