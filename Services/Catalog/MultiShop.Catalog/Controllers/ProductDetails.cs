using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductDetails : ControllerBase
{
    private readonly IProductDetailService _productDetailService;

    public ProductDetails(IProductDetailService productDetailService)
    {
        _productDetailService = productDetailService;
    }

    [HttpGet]
    public async Task<IActionResult> ProductDetailList()
    {
        var categories = await _productDetailService.GetAllProductDetailAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetailById(string id)
    {
        var ProductDetail = await _productDetailService.GetByIdProductDetailAsync(id);
        return Ok(ProductDetail);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
    {
        await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
        return Ok("ProductDetail added.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        await _productDetailService.DeleteProductDetailAsync(id);
        return Ok("ProductDetail deleted.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
    {
        await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
        return Ok("ProductDetail updated.");
    }

}