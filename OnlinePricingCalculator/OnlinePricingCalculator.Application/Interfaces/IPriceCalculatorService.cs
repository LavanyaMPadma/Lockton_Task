using OnlinePricingCalculator.Application.DTOs;

namespace OnlinePricingCalculator.Application.Interfaces
{
    public interface IPriceCalculatorService
    {
        Task<BasketPriceResponseDto> CalculateAsync(BasketPriceRequestDto request);
    }
}
