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

        /// <summary>
        /// ProductRepository constructor that takes a WarehouseDBContext as input paramater
        /// </summary>
        /// <param name="context">sets the parameter WarehouseDBContext to the class readonly variable of the same type</param>
        public ProductRepository(WarehouseDBContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Add the Product object to the database
        /// </summary>
        /// <param name="entity">Product object</param>
        /// <returns>The Product object</returns>
        public async Task<Product> AddAsync(Product entity)
        {
            context.Products.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Gets all Product objects from the database and returns them as a list
        /// </summary>
        /// <returns>A list of Product objects</returns>
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Products.ToListAsync();
        }

        /// <summary>
        /// Gets all Product objects from the database where the product stock value is 0
        /// </summary>
        /// <returns>A list of Product objects</returns>
        public async Task<IEnumerable<Product>> GetOutOfStockAsync()
        {
            return await context.Products.Where(p => p.Stock == 0).ToListAsync();
        }

        /// <summary>
        /// Sets the restocking date of the input product object
        /// </summary>
        /// <param name="product">A product object</param>
        /// <returns>The product object</returns>
        public async Task<DateTime> GetRestockingDateAsync(Product product)
        {
            product.RestockingDate = DateTime.Now.AddDays(10);
            await context.SaveChangesAsync();
            return product.RestockingDate;
        }

        /// <summary>
        /// Removes the product object from the database  
        /// </summary>
        /// <param name="entity">A product object</param>
        /// <returns>The product object</returns>
        public async Task<Product> RemoveAsync(Product entity)
        {
            context.Products.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Updates the database with the product object
        /// </summary>
        /// <param name="entity">A product object</param>
        /// <returns>The product object</returns>
        public async Task<Product> UpdateAsync(Product entity)
        {
            await context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Updates the stock variable so that quantity is removed from stock (ordered quantity - stock)
        /// </summary>
        /// <param name="order">An order object</param>
        /// <returns>The order object</returns>
        public async Task<Order> UpdateStockAsync(Order order)
        {
            await context.OrderLines.ToListAsync();
            List<Product> products = await context.Products.ToListAsync();
            foreach (OrderLine item in order.Items)
            {
                context.Products.Where(p => p == item.Product).ToList().ForEach(p => p.Stock -= item.Quantity);
            }
            await context.SaveChangesAsync();
            return order;
        }

        /// <summary>
        /// Checks if items are in stock
        /// </summary>
        /// <param name="order">An order object</param>
        /// <returns>Returns true if items are in stock, false if they are not in stock</returns>
        public async Task<bool> ItemInStock(Order order)
        {
            await context.Products.ToListAsync();
            foreach (OrderLine item in order.Items)
            {
                if (item.Product.Stock < item.Quantity)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
