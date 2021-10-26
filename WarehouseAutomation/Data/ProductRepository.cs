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

        public async Task<Order> UpdateStockAsync(Order order)
        {
            List<Product> products = await context.Products.ToListAsync();
            foreach (OrderLine item in order.Items)
            {
                context.Products.Where(p => p == item.Product).ToList().ForEach(s => s.Stock -= item.Quantity);
                //context.Products.Where(p => p == item.Product).Select(p => { p.Stock -= item.Quantity; return p; });
                //List<OrderLine> querylist = context.Products.Where(p => p == item.Product);
                //var query = context.Products.Where(p => p == item.Product);
                //query.Select(q => q.Stock -= item.Quantity);
                //query.Stock = query.Product.Stock - item.Quantity;
            }
            await context.SaveChangesAsync();
            return order;
        }
    }
}
