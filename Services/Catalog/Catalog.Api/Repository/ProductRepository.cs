using Catalog.Api.Data;
using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Repository;

public class ProductRepository : IProductRepository
{
    private readonly IProductContext _context;

    public ProductRepository(IProductContext context)
    {
        _context = context;
    }

    public async Task<bool> DeleteProduct(string id)
    {
        FilterDefinition<Product> filterDefination = Builders<Product>.Filter.Eq(f => f.Id, id);
        var result = await _context.Product.DeleteOneAsync(filterDefination);

        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<Product> GetProduct(string id)
    {
        return (await _context.Product.FindAsync(f => f.Id == id)).FirstOrDefault();
    }

    public async Task InsertProduct(Product product)
    {
        await _context.Product.InsertOneAsync(product);
    }

    public async Task<IEnumerable<Product>> ProductsList()
    {
        return (await _context.Product.FindAsync(f => true)).ToList();
    }

    public async Task<bool> UpdateProduct(Product product)
    {

        var result = await _context.Product.ReplaceOneAsync(f => f.Id == product.Id, product);

        return result.IsAcknowledged && result.UpsertedId > 0;
    }
}
