using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Product> _productCollection;

    public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;

        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
    }

    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        var product = _mapper.Map<Product>(createProductDto);
        await _productCollection.InsertOneAsync(product);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _productCollection.DeleteOneAsync(p => p.ProductId == id);
    }

    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        var products = await _productCollection.Find(p => true).ToListAsync();
        return _mapper.Map<List<ResultProductDto>>(products);
    }

    public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
    {
        var product = await _productCollection.Find<Product>(p => p.ProductId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDto>(product);
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        var product = _mapper.Map<Product>(updateProductDto);
        await _productCollection.FindOneAndReplaceAsync(p => p.ProductId == updateProductDto.ProductId, product);
    }
}