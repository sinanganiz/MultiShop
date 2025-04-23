using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeaturedDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeaturedServices
{
    public class FeaturedService : IFeaturedService
    {
        private readonly IMongoCollection<Featured> _featuredCollection;
        private readonly IMapper _mapper;

        public FeaturedService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _featuredCollection = database.GetCollection<Featured>(databaseSettings.FeaturedCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeaturedAsync(CreateFeaturedDto createFeaturedDto)
        {
            var value = _mapper.Map<Featured>(createFeaturedDto);
            await _featuredCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeaturedAsync(string id)
        {
            await _featuredCollection.DeleteOneAsync(f => f.FeaturedId == id);
        }

        public async Task<List<ResultFeaturedDto>> GetAllFeaturedAsync()
        {
            var values = await _featuredCollection.Find(f => true).ToListAsync();
            return _mapper.Map<List<ResultFeaturedDto>>(values);
        }

        public async Task<GetByIdFeaturedDto> GetByIdFeaturedAsync(string id)
        {
            var value = await _featuredCollection.Find<Featured>(f => f.FeaturedId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeaturedDto>(value);
        }

        public async Task UpdateFeaturedAsync(UpdateFeaturedDto updateFeaturedDto)
        {
            var value = _mapper.Map<Featured>(updateFeaturedDto);
            await _featuredCollection.FindOneAndReplaceAsync(f => f.FeaturedId == updateFeaturedDto.FeaturedId, value);
        }
    }
}
