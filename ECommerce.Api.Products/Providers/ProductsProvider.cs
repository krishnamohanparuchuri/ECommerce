using AutoMapper;
using ECommerce.Api.Products.Db;
using ECommerce.Api.Products.Interface;
using ECommerce.Api.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Providers
{
    public class ProductsProvider : IProductsProvider
    {
        private readonly ProductsDbContext dbContext;
        private readonly ILogger<ProductsProvider> logger;
        private readonly IMapper mapper;

        public ProductsProvider(ProductsDbContext dbContext, ILogger<ProductsProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
            SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.Products.Any())
            {
                dbContext.Products.Add(
                    new Db.Product() { Id = 1, Name = "KeyBoard", Price = 20, Inventory = 100 }
                    );
                dbContext.Products.Add(
                    new Db.Product() { Id = 2, Name = "Mouse", Price = 30, Inventory = 100 }
                    );
                dbContext.Products.Add(
                    new Db.Product() { Id = 3, Name = "Mobile Phone", Price = 10, Inventory = 100 }
                    );
                dbContext.Products.Add(
                    new Db.Product() { Id = 4, Name = "Hard Drive", Price = 120, Inventory = 100 }
                    );
                dbContext.Products.Add(
                    new Db.Product() { Id = 5, Name = "Disc", Price = 5, Inventory = 100 }
                    );
                dbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Product> Products, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                var products = await dbContext.Products.ToListAsync();
                if(products != null && products.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Product>, IEnumerable<Models.Product>>(products);
                    return (true, result, null);
                }

                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Models.Product Product, string ErrorMessage)> GetProductAsync(int id)
        {
            try
            {
                var product = await dbContext.Products.FirstOrDefaultAsync(product => product.Id == id);
                if(product != null)
                {
                    var result = mapper.Map<Db.Product, Models.Product>(product);
                    return (true, result,null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);                
            }

        }
    }
}
