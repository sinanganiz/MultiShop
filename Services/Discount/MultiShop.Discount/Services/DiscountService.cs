using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dto;

namespace MultiShop.Discount.Services;

public class DiscountService : IDiscountService
{
    private DapperContext _context;

    public DiscountService(DapperContext context)
    {
        _context = context;
    }

    public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
    {
        var query = "INSERT INTO Coupons (Code,Rate,IsActive,ValidDate) VALUES (@code,@rate,@isActive,@validDate)";
        var parameters = new DynamicParameters();
        parameters.Add("@code", createCouponDto.Code);
        parameters.Add("@rate", createCouponDto.Rate);
        parameters.Add("@isActive", "true");
        parameters.Add("@validDate", createCouponDto.ValidDate);

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteCouponAsync(int id)
    {
        var query = "DELETE FROM Coupons WHERE CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("couponId", id);

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultCouponDto>> GetAllCouponAsync()
    {
        var query = "SELECT * FROM Coupons";

        using (var connection = _context.CreateConnection())
        {
            var coupons = await connection.QueryAsync<ResultCouponDto>(query);
            return coupons.ToList();
        }
    }

    public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
    {
        var query = "SELECT * FROM Coupons WHERE CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("couponId", id);

        using (var connection = _context.CreateConnection())
        {
            var coupon = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, parameters);
            return coupon;
        }
    }

    public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
    {
        var query = "UPDATE Coupons SET Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate WHERE CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId", updateCouponDto.CouponId);
        parameters.Add("@code", updateCouponDto.Code);
        parameters.Add("@rate", updateCouponDto.Rate);
        parameters.Add("@isActive", "true");
        parameters.Add("@validDate", updateCouponDto.ValidDate);

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}