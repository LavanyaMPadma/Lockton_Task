using Microsoft.AspNetCore.Mvc;
using OnlinePricingCalculator.Application.DTOs;
using OnlinePricingCalculator.Application.Interfaces;
using OnlinePricingCalculator.WebApi.Models;

namespace OnlinePricingCalculator.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricingController : ControllerBase
    {
        private readonly IPriceCalculatorService _priceCalculatorService;

        public PricingController(IPriceCalculatorService priceCalculatorService)
        {
            _priceCalculatorService = priceCalculatorService;
        }

        [HttpPost("calculate")]
        public async Task<ActionResult<CalculatePriceFinalResponse>> Calculate([FromBody] BasketPriceRequestDto request)
        {
            if (request == null || request.Items == null || !request.Items.Any())
                return BadRequest("Basket must contain at least one item.");

            var result = await _priceCalculatorService.CalculateAsync(request);

            var response = new CalculatePriceFinalResponse();

            foreach (var line in result.Lines)
            {
                response.Item.Add(new CalculateResultItem
                {
                    ItemId = line.ItemId,
                    ItemName = line.ItemName,
                    Quantity = line.Quantity,
                    ChargeableQuantity = line.ChargeableQuantity,
                    UnitPrice = line.UnitPrice,
                    LineTotal = line.LineTotal,
                    DiscountAmount = line.DiscountAmount,
                    SubTotal = result.SubTotal,
                    GrandTotal = result.GrandTotal
                });
            }

            return Ok(response);
        }


    }
}
