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
        /// <summary>
        /// Adds an order entity to the database 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns> 
        public async Task<Order> AddAsync(Order entity)
        {
            context.Orders.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        /// <summary>
        /// Returns a list of an order from the database 
        /// </summary>
        /// <returns></returns> 
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await context.Orders.ToListAsync();
        }
        /// <summary>
        /// returns a list of dispatched orders from the database
        /// </summary>
        /// <returns></returns> 

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            List<Order> order = await context.Orders.Where(o => o.Id == orderId).ToListAsync();
            return order[0];
        }

        /// <summary>
        /// returns a list of dispatched orders from the database
        /// </summary>
        /// <returns></returns> 
        public async Task<IEnumerable<Order>> GetDispatchedOrdersAsync()
        {
            return await context.Orders.Where(o => o.Dispatched == true).ToListAsync();
        }

        /// <summary>
        /// overloaded method that returns a list of dispatched orders from the database using customerId
        /// </summary>
        /// <param name="customerId">The id of a customer</param>
        /// <returns></returns>

        public async Task<IEnumerable<Order>> GetDispatchedOrdersAsync(int customerId)
        {
            return await context.Orders.Where(o => o.Dispatched == true && o.CustomerId == customerId).ToListAsync();
        }
        /// <summary>
        /// returns a list of pending orders
        /// </summary>
        /// <returns></returns> 
        public async Task<IEnumerable<Order>> GetPendingOrdersAsync()
        {
            return await context.Orders.Where(o => o.Dispatched == false).ToListAsync();
        }
        /// <summary>
        /// overloaded method that returns a list of pending orders using customer id
        /// </summary>
        /// <param name="customerId">id of a customer</param>
        /// <returns></returns> 
        public async Task<IEnumerable<Order>> GetPendingOrdersAsync(int customerId)
        {
            return await context.Orders.Where(o => o.Dispatched == false && o.CustomerId == customerId).ToListAsync();
        }
        /// <summary>
        /// removes an order from the database and saves database
        /// </summary>
        /// <param name="entity">an order</param>
        /// <returns></returns>
        public async Task<Order> RemoveAsync(Order entity)
        {
            context.Orders.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        /// <summary>
        /// is used to update an entity in the database
        /// </summary>
        /// <param name="entity">an order</param>
        /// <returns></returns> 
        public async Task<Order> UpdateAsync(Order entity)
        {
            await context.SaveChangesAsync();
            return entity;
        }
        /// <summary>
        /// Updates the dispatch status of an order
        /// </summary>
        /// <param name="order">an order</param>
        /// <returns></returns> 
        public async Task<Order> UpdateDispatchStatusAsync(Order order)
        {
            order.Dispatched = true;
            await context.SaveChangesAsync();
            return order;
        }
        /// <summary>
        /// sets the value to true when an order has been paid for
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns> 
        public async Task<Order> PayOrderAsync(Order order)
        {
            order.PaymentCompleted = true;
            await context.SaveChangesAsync();
            return order;
        }
    }
}
