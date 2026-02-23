using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Data;

public class ProductContext : IProductContext
{
    public IMongoCollection<Product> Product { get; }
    public ProductContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:MongoDbSetting:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:MongoDbSetting:Database"));
        Product = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:MongoDbSetting:Collection"));
    }
}
