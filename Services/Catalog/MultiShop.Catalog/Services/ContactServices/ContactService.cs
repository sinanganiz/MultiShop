using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _contactCollection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            var contact = _mapper.Map<Contact>(createContactDto);
            await _contactCollection.InsertOneAsync(contact);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(c => c.ContactId == id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var contacts = await _contactCollection.Find(c => true).ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(contacts);
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var contact = await _contactCollection.Find<Contact>(c => c.ContactId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdContactDto>(contact);
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var contact = _mapper.Map<Contact>(updateContactDto);
            await _contactCollection.FindOneAndReplaceAsync(c => c.ContactId == updateContactDto.ContactId, contact);
        }
    }
}
