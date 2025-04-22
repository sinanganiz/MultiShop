using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeaturedSliderDtos;

namespace MultiShop.Catalog.Services.FeaturedSliderServices
{
    public interface IFeaturedSliderService
    {
        Task<List<ResultFeaturedSliderDto>> GetAllFeaturedSliderAsync();
        Task CreateFeaturedSliderAsync(CreateFeaturedSliderDto createFeaturedSliderDto);
        Task UpdateFeaturedSliderAsync(UpdateFeaturedSliderDto updateFeaturedSliderDto);
        Task DeleteFeaturedSliderAsync(string id);
        Task<GetByIdFeaturedSliderDto> GetByIdFeaturedSliderAsync(string id);
        Task FeaturedSliderChangeStatusToTrue(string id);
        Task FeaturedSliderChangeStatusToFalse(string id);
    }
}
