using System;

namespace MultiShop.Basket.Dtos;

public class BasketTotalDto
{
    public string UserId { get; set; }
    public string DiscountCode { get; set; }
    public int DiscountRate { get; set; }
    public List<BasketItemDto> BasketItems { get; set; }
    public decimal TotalPrice { get => BasketItems.Sum(bi => bi.Price * bi.Quantity); }
}