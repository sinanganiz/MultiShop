using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeaturedSliderDtos;
using MultiShop.Catalog.Services.FeaturedSliderServices;

namespace MultiShop.Catalog.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FeaturedSlidersController : ControllerBase
{
    private readonly IFeaturedSliderService _featuredSliderService;

    public FeaturedSlidersController(IFeaturedSliderService featuredSliderService)
    {
        _featuredSliderService = featuredSliderService;
    }

    [HttpGet]
    public async Task<IActionResult> FeaturedSliderList()
    {
        var featuredSliders = await _featuredSliderService.GetAllFeaturedSliderAsync();
        return Ok(featuredSliders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFeaturedSliderById(string id)
    {
        var featuredSlider = await _featuredSliderService.GetByIdFeaturedSliderAsync(id);
        return Ok(featuredSlider);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeaturedSlider(CreateFeaturedSliderDto createFeaturedSliderDto)
    {
        await _featuredSliderService.CreateFeaturedSliderAsync(createFeaturedSliderDto);
        return Ok("FeaturedSlider added.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFeaturedSlider(string id)
    {
        await _featuredSliderService.DeleteFeaturedSliderAsync(id);
        return Ok("FeaturedSlider deleted.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFeaturedSlider(UpdateFeaturedSliderDto updateFeaturedSliderDto)
    {
        await _featuredSliderService.UpdateFeaturedSliderAsync(updateFeaturedSliderDto);
        return Ok("FeaturedSlider updated.");
    }

}