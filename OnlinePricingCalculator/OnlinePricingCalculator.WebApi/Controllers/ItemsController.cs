using Microsoft.AspNetCore.Mvc;
using OnlinePricingCalculator.Domain.Interfaces;
using OnlinePricingCalculator.Domain.Entities;
using OnlinePricingCalculator.WebApi.Models;

namespace OnlinePricingCalculator.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
        {
            var items = await _itemRepository.GetAllActiveAsync();
            return Ok(items);
        }

        [HttpGet]
        public async Task<ActionResult<GetItemsResponse>> GetItems()
        {
            var items = await _itemRepository.GetAllActiveAsync();

            var result = new GetItemsResponse
            {
                Items = items.Select(i => new ItemDto
                {
                    Id = i.Id,
                    Name = i.Name
                })
            };

            return Ok(result);
        }


    }
}
