using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context,ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.ProductBrands.Any())
                {
                    var brandsdata=File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands=JsonSerializer.Deserialize<List<ProductBrand>>(brandsdata);
                    foreach(var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if(!context.ProductTypes.Any())
                {
                    var typesdata=File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types=JsonSerializer.Deserialize<List<ProductType>>(typesdata);
                    foreach(var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if(!context.Products.Any())
                {
                    var productsdata=File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products=JsonSerializer.Deserialize<List<Product>>(productsdata);
                    foreach(var item in products)
                    {
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

            }
            catch(Exception ex)
            {
                var logger=loggerFactory.CreateLogger<StoreContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}