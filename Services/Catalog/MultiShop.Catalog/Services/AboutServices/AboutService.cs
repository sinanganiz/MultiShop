using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;
        private readonly IMapper _mapper;

        public AboutService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _aboutCollection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var about = _mapper.Map<About>(createAboutDto);
            await _aboutCollection.InsertOneAsync(about);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _aboutCollection.DeleteOneAsync(c => c.AboutId == id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var abouts = await _aboutCollection.Find(c => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(abouts);
        }

        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            var about = await _aboutCollection.Find<About>(c => c.AboutId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdAboutDto>(about);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var about = _mapper.Map<About>(updateAboutDto);
            await _aboutCollection.FindOneAndReplaceAsync(c => c.AboutId == updateAboutDto.AboutId, about);
        }
    }
}
