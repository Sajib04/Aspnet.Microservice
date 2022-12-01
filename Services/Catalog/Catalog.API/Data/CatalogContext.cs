using Catalog.API.Entitities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration.GetValue<string>(
                "DatabaseSettings:ConnectionString"));
            var datbase = mongoClient.GetDatabase(configuration.GetValue<string>(
                "DatabaseSettings:DatabaseName"));
            Products = datbase.GetCollection<Product>(configuration.GetValue<string>(
                "DatabaseSettings:CollectionName"));
            //CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }

    }
}
