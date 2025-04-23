using MultiShop.Catalog.Dtos.FeaturedDtos;

namespace MultiShop.Catalog.Services.FeaturedServices
{
    public interface IFeaturedService
    {
        Task<List<ResultFeaturedDto>> GetAllFeaturedAsync();
        Task CreateFeaturedAsync(CreateFeaturedDto createFeaturedDto);
        Task UpdateFeaturedAsync(UpdateFeaturedDto updateFeaturedDto);
        Task DeleteFeaturedAsync(string id);
        Task<GetByIdFeaturedDto> GetByIdFeaturedAsync(string id);
    }
}
