using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dto;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DiscountsController : ControllerBase
{
    private readonly IDiscountService _discountService;

    public DiscountsController(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    [HttpGet]
    public async Task<IActionResult> DiscountCouponList()
    {
        var coupons = await _discountService.GetAllCouponAsync();
        return Ok(coupons);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDiscountCouponById(int id)
    {
        var coupon = await _discountService.GetByIdCouponAsync(id);
        return Ok(coupon);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDiscountCoupon(CreateCouponDto createCouponDto)
    {
        await _discountService.CreateCouponAsync(createCouponDto);
        return Ok("Discount coupon created.");
    }


    [HttpPut]
    public async Task<IActionResult> UpdateDiscountCoupon(UpdateCouponDto updateCouponDto)
    {
        await _discountService.UpdateCouponAsync(updateCouponDto);
        return Ok("Discount coupon updated.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDiscount(int id)
    {
        await _discountService.DeleteCouponAsync(id);
        return Ok("Discount coupon deleted.");
    }
}