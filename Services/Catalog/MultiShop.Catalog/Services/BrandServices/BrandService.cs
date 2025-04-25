using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMapper _mapper;

        public BrandService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _brandCollection = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var brand = _mapper.Map<Brand>(createBrandDto);
            await _brandCollection.InsertOneAsync(brand);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brandCollection.DeleteOneAsync(c => c.BrandId == id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var brands = await _brandCollection.Find(c => true).ToListAsync();
            return _mapper.Map<List<ResultBrandDto>>(brands);
        }

        public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        {
            var brand = await _brandCollection.Find<Brand>(c => c.BrandId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdBrandDto>(brand);
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var brand = _mapper.Map<Brand>(updateBrandDto);
            await _brandCollection.FindOneAndReplaceAsync(c => c.BrandId == updateBrandDto.BrandId, brand);
        }
    }
}
