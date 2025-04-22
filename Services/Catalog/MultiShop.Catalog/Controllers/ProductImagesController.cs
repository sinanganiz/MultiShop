using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
//[Authorize]
public class ProductImagesController : ControllerBase
{ private readonly IProductImageService _productImageService;

    public ProductImagesController(IProductImageService productImageService)
    {
        _productImageService = productImageService;
    }

    [HttpGet]
    public async Task<IActionResult> ProductImageList()
    {
        var categories = await _productImageService.GetAllProductImageAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductImageById(string id)
    {
        var ProductImage = await _productImageService.GetByIdProductImageAsync(id);
        return Ok(ProductImage);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
    {
        await _productImageService.CreateProductImageAsync(createProductImageDto);
        return Ok("ProductImage added.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProductImage(string id)
    {
        await _productImageService.DeleteProductImageAsync(id);
        return Ok("ProductImage deleted.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
    {
        await _productImageService.UpdateProductImageAsync(updateProductImageDto);
        return Ok("ProductImage updated.");
    }

}