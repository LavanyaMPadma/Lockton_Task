namespace OnlinePricingCalculator.WebApi.Models
{
    public class CalculateResultItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int ChargeableQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
