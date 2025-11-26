namespace OnlinePricingCalculator.Domain.Entities
{
    public class DiscountItem
    {
        public int Id { get; set; }

        public int DiscountId { get; set; }

        public Discount? Discount { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }
    }
}
