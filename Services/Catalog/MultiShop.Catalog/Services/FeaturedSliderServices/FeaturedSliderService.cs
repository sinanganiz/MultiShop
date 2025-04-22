using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeaturedSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeaturedSliderServices
{
    public class FeaturedSliderService : IFeaturedSliderService
    {
        private readonly IMongoCollection<FeaturedSlider> _featuredSliderCollection;
        private readonly IMapper _mapper;

        public FeaturedSliderService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _featuredSliderCollection = database.GetCollection<FeaturedSlider>(databaseSettings.FeaturedSliderCollectionName);
            _mapper = mapper;
        }


        public async Task CreateFeaturedSliderAsync(CreateFeaturedSliderDto createFeaturedSliderDto)
        {
            var featuredSlider = _mapper.Map<FeaturedSlider>(createFeaturedSliderDto);
            await _featuredSliderCollection.InsertOneAsync(featuredSlider);
        }

        public async Task DeleteFeaturedSliderAsync(string id)
        {
            await _featuredSliderCollection.DeleteOneAsync(c => c.FeaturedSliderId == id);
        }

        public Task FeaturedSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeaturedSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeaturedSliderDto>> GetAllFeaturedSliderAsync()
        {
            var featuredSliders = await _featuredSliderCollection.Find(f => true).ToListAsync();
            return _mapper.Map<List<ResultFeaturedSliderDto>>(featuredSliders);
        }

        public async Task<GetByIdFeaturedSliderDto> GetByIdFeaturedSliderAsync(string id)
        {
            var featuredSlider = await _featuredSliderCollection.Find<FeaturedSlider>(f => f.FeaturedSliderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeaturedSliderDto>(featuredSlider);
        }

        public async Task UpdateFeaturedSliderAsync(UpdateFeaturedSliderDto updateFeaturedSliderDto)
        {
            var featuredSlider = _mapper.Map<FeaturedSlider>(updateFeaturedSliderDto);
            await _featuredSliderCollection.FindOneAndReplaceAsync(f => f.FeaturedSliderId == updateFeaturedSliderDto.FeaturedSliderId, featuredSlider);
        }
    }
}
