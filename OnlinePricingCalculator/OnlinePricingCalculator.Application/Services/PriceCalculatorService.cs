using OnlinePricingCalculator.Application.DTOs;
using OnlinePricingCalculator.Application.Interfaces;
using OnlinePricingCalculator.Domain.Entities;
using OnlinePricingCalculator.Domain.Interfaces;

namespace OnlinePricingCalculator.Application.Services
{
    public class PriceCalculatorService : IPriceCalculatorService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IDiscountRepository _discountRepository;

        public PriceCalculatorService(
            IItemRepository itemRepository,
            IDiscountRepository discountRepository)
        {
            _itemRepository = itemRepository;
            _discountRepository = discountRepository;
        }

        public async Task<BasketPriceResponseDto> CalculateAsync(BasketPriceRequestDto request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var itemIds = request.Items.Select(i => i.ItemId).Distinct().ToList();
            var items = await _itemRepository.GetByIdsAsync(itemIds);
            var discounts = await _discountRepository.GetActiveDiscountsAsync();

            var response = new BasketPriceResponseDto();

            foreach (var basketItem in request.Items)
            {
                var item = items.Single(i => i.Id == basketItem.ItemId);
                var quantity = basketItem.Quantity;

                var applicableDiscounts = discounts
                    .Where(d => d.DiscountItems.Any(di => di.ItemId == item.Id))
                    .ToList();

                var chargeableQuantity = quantity;
                decimal discountAmount = 0m;

                foreach (var discount in applicableDiscounts)
                {
                    if (discount.DiscountType?.Name == "Percentage" && discount.PercentageValue.HasValue)
                    {
                        var subtotal = item.Price * quantity;
                        discountAmount += subtotal * (discount.PercentageValue.Value / 100m);
                    }
                    else if (discount.DiscountType?.Name == "BuyXGetY"
                             && discount.BuyQuantity.HasValue
                             && discount.FreeQuantity.HasValue)
                    {
                        var buy = discount.BuyQuantity.Value;
                        var free = discount.FreeQuantity.Value;
                        var groupSize = buy + free;
                        var fullGroups = quantity / groupSize;
                        var freeItems = fullGroups * free;

                        chargeableQuantity = quantity - freeItems;
                        discountAmount += freeItems * item.Price;
                    }
                }

                var lineTotal = chargeableQuantity * item.Price;

                response.Lines.Add(new BasketPriceItemResultDto
                {
                    ItemId = item.Id,
                    ItemName = item.Name,
                    Quantity = quantity,
                    ChargeableQuantity = chargeableQuantity,
                    UnitPrice = item.Price,
                    LineTotal = lineTotal,
                    DiscountAmount = discountAmount
                });
            }

            response.SubTotal = response.Lines.Sum(l => l.UnitPrice * l.Quantity);
            response.DiscountTotal = response.Lines.Sum(l => l.DiscountAmount);
            response.GrandTotal = response.SubTotal - response.DiscountTotal;

            return response;
        }
    }
}
