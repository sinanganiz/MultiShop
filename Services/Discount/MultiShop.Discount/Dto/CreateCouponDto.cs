namespace MultiShop.Discount.Dto;

public class CreateCouponDto
{
    public string Code { get; set; }
    public int Rate { get; set; }
    // public bool IsActive { get; set; }
    public DateTime ValidDate { get; set; }
}