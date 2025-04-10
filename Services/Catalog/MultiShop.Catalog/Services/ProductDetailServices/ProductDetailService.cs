using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices;

public class ProductDetailService : IProductDetailService
{
 private readonly IMongoCollection<ProductDetail> _ProductDetailCollection;
    private readonly IMapper _mapper;

    public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);

        _ProductDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
    {
        var ProductDetail = _mapper.Map<ProductDetail>(createProductDetailDto);
        await _ProductDetailCollection.InsertOneAsync(ProductDetail);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _ProductDetailCollection.DeleteOneAsync(c => c.ProductDetailId == id);
    }

    public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
    {
        var categories = await _ProductDetailCollection.Find(c => true).ToListAsync();
        return _mapper.Map<List<ResultProductDetailDto>>(categories);
    }

    public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
    {
        var ProductDetail = await _ProductDetailCollection.Find<ProductDetail>(c => c.ProductDetailId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDetailDto>(ProductDetail);
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        var ProductDetail = _mapper.Map<ProductDetail>(updateProductDetailDto);
        await _ProductDetailCollection.FindOneAndReplaceAsync(c => c.ProductDetailId == updateProductDetailDto.ProductDetailId, ProductDetail);
    }
}