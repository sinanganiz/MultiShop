using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
//[Authorize]

public class ProductDetailsController : ControllerBase
{
    private readonly IProductDetailService _productDetailService;

    public ProductDetailsController(IProductDetailService productDetailService)
    {
        _productDetailService = productDetailService;
    }

    [HttpGet]
    public async Task<IActionResult> ProductDetailList()
    {
        var values = await _productDetailService.GetAllProductDetailAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetailById(string id)
    {
        var productDetail = await _productDetailService.GetByIdProductDetailAsync(id);
        return Ok(productDetail);
    }

    [HttpGet("GetProductDetailByProductId")]
    public async Task<IActionResult> GetProductDetailByProductId(string id)
    {
        var productDetail = await _productDetailService.GetByProductIdProductDetailAsync(id);
        return Ok(productDetail);
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