using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices;

public class ProductImageService : IProductImageService
{
    private readonly IMongoCollection<ProductImage> _ProductImageCollection;
    private readonly IMapper _mapper;

    public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);

        _ProductImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
    {
        var ProductImage = _mapper.Map<ProductImage>(createProductImageDto);
        await _ProductImageCollection.InsertOneAsync(ProductImage);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await _ProductImageCollection.DeleteOneAsync(c => c.ProductImageId == id);
    }

    public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
    {
        var values = await _ProductImageCollection.Find(c => true).ToListAsync();
        return _mapper.Map<List<ResultProductImageDto>>(values);
    }

    public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
    {
        var ProductImage = await _ProductImageCollection.Find<ProductImage>(c => c.ProductImageId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductImageDto>(ProductImage);
    }

    public async Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id)
    {
        var value = await _ProductImageCollection.Find(c => c.ProductId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductImageDto>(value);
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
    {
        var ProductImage = _mapper.Map<ProductImage>(updateProductImageDto);
        await _ProductImageCollection.FindOneAndReplaceAsync(c => c.ProductImageId == updateProductImageDto.ProductImageId, ProductImage);
    }
}