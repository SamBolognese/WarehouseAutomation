using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseAutomation.Data.Interfaces;

namespace WarehouseAutomation.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly WarehouseDBContext context;

        public ProductRepository(WarehouseDBContext context)
        {
            this.context = context;
        }

        public async Task<Product> AddAsync(Product entity)
        {
            context.Products.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetOutOfStockAsync()
        {
            return await context.Products.Where(p => p.Stock == 0).ToListAsync();
        }

        public async Task<DateTime> GetRestockingDateAsync(Product product)
        {
            product.RestockingDate = DateTime.Now.AddDays(10);
            await context.SaveChangesAsync();
            return product.RestockingDate;
        }

        public async Task<Product> RemoveAsync(Product entity)
        {
            context.Products.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
