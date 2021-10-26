using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseAutomation.Data.Interfaces;

namespace WarehouseAutomation.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly WarehouseDBContext context;

        public OrderRepository(WarehouseDBContext context)
        {
            this.context = context;
        }
        public async Task<Order> AddAsync(Order entity)
        {
            context.Orders.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await context.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetDispatchedOrdersAsync()
        {
            return await context.Orders.Where(o => o.Dispatched == true).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetPendingOrdersAsync()
        {
            return await context.Orders.Where(o => o.Dispatched == false).ToListAsync();
        }

        public async Task<Order> RemoveAsync(Order entity)
        {
            context.Orders.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<Order> UpdateAsync(Order entity)
        {
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> ItemsInStockAsync(Order entity)
        {
            List<Product> products = await context.Products.ToListAsync();

            //FUNGERAR???
            return context.Products.All(p => !entity.Items.Where(i => i.Product == p && i.Quantity > p.Stock).Any());

            //return await context.Products.Where(p => p.Stock == 0).ToListAsync();

            //return context.Products.All(p => p.Stock >= entity.Items.Where(i => i.Product == p));

            //from 
            //select p.Stock from p in products && select i.Quantity from i in Items
            //join p on 

            //if(products[i].Stock <= entity.Items[i].Quantity)
           
        }

        public async Task<Order> UpdateDispatchStatusAsync(Order order)
        {
            context.Orders.Where(o => o.Id == order.Id).ToList().ForEach(o => o.Dispatched = true);
            return order;
        }
    }
}
