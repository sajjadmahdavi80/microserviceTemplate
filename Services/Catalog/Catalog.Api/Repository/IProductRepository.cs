using Catalog.Api.Entities;

namespace Catalog.Api.Repository;

public interface IProductRepository
{
    Task<bool> DeleteProduct(string id);

    Task InsertProduct(Product product);

    Task<IEnumerable<Product>> ProductsList();

    Task<bool> UpdateProduct(Product product);

    Task<Product> GetProduct(string id);
}
