using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Data;

public class ProductContext : IProductContext
{
	public ProductContext(IConfiguration configuration)
	{
		var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:MongoDbSetting:ConnectionString"));
		var database =client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:MongoDbSetting:Database"));
		Product = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:MongoDbSetting:Collection"));
	}
    public IMongoCollection<Product> Product { get; }
}
