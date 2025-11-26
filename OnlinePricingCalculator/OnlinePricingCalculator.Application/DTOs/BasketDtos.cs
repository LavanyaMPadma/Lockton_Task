namespace OnlinePricingCalculator.Application.DTOs
{
    public class BasketItemDto
    {
        public int ItemId { get; set; }

        public int Quantity { get; set; }
    }

    public class BasketPriceRequestDto
    {
        public IList<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    }

    public class BasketPriceItemResultDto
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public int ChargeableQuantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal LineTotal { get; set; }

        public decimal DiscountAmount { get; set; }
    }

    public class BasketPriceResponseDto
    {
        public IList<BasketPriceItemResultDto> Lines { get; set; } = new List<BasketPriceItemResultDto>();

        public decimal SubTotal { get; set; }

        public decimal DiscountTotal { get; set; }

        public decimal GrandTotal { get; set; }
    }
}
