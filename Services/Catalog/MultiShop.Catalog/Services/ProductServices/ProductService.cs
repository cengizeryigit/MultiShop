using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        public ProductService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;

        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(product => product.ProductID == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var values = await _productCollection.Find(product => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIDProductDto> GetProductByIdAsync(string id)
        {
            var values = await _productCollection.Find(product => product.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIDProductDto>(values);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var values = await _productCollection.Find(x=>true).ToListAsync();
            foreach(var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(c => c.CategoryID == item.CategoryID).FirstOrDefaultAsync();
            }

            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);

           
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(product => product.ProductID == updateProductDto.ProductID, values);
        }
    }
}
