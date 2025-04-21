using System.Text.Json;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;

namespace MultiShop.Basket.Services;

public class BasketService : IBasketService
{
    private readonly RedisService _redisService;

    public BasketService(RedisService redisService)
    {
        _redisService = redisService;
    }

    public async Task DeleteBasket(string userId)
    {
        await _redisService.GetDb().KeyDeleteAsync(userId);
    }

    public async Task<BasketTotalDto> GetBasket(string userId)
    {
        var basket = await _redisService.GetDb().StringGetAsync(userId);
        return JsonSerializer.Deserialize<BasketTotalDto>(basket);
    }

    public async Task SaveBasket(BasketTotalDto basketTotalDto)
    {
        await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
    }
}
