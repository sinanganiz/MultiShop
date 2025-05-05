using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeaturedDtos;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.FeaturedServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FeaturedsController : ControllerBase
    {
        private readonly IFeaturedService _featuredService;

        public FeaturedsController(IFeaturedService featuredService)
        {
            _featuredService = featuredService;
        }

        [HttpGet]
        public async Task<IActionResult> FeaturedList()
        {
            var values = await _featuredService.GetAllFeaturedAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeaturedById(string id)
        {
            var value = await _featuredService.GetByIdFeaturedAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatured(CreateFeaturedDto createFeaturedDto)
        {
            await _featuredService.CreateFeaturedAsync(createFeaturedDto);
            return Ok("Featured added.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeatured(string id)
        {
            await _featuredService.DeleteFeaturedAsync(id);
            return Ok("Featured deleted.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeatured(UpdateFeaturedDto updateFeaturedDto)
        {
            await _featuredService.UpdateFeaturedAsync(updateFeaturedDto);
            return Ok("Featured updated.");
        }
    }
}
