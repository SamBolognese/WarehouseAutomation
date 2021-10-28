using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseAutomation.Data.Interfaces;

namespace WarehouseAutomation.Data
{
    public class OrderLineRepository : IOrderLineRepository
    {
        private readonly WarehouseDBContext context;

        /// <summary>
        /// OrderLineRepository constructor that takes a WarehouseDBContext as input paramater
        /// </summary>
        /// <param name="context">sets the parameter WarehouseDBContext to the class readonly variable of the same type</param>
        public OrderLineRepository(WarehouseDBContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds the OrderLine object to the database
        /// </summary>
        /// <param name="entity">OrderLine object</param>
        /// <returns>The OrderLine object</returns>
        public async Task<OrderLine> AddAsync(OrderLine entity)
        {
            context.OrderLines.Add(entity);
            await context.SaveChangesAsync(); //Denna
            return entity;
        }
        
        /// <summary>
        /// Gets all OrderLine objects from the database and returns them as a list
        /// </summary>
        /// <returns>A list of OrderLine objects</returns>
        public async Task<IEnumerable<OrderLine>> GetAllAsync()
        {
            return await context.OrderLines.ToListAsync();
        }

        /// <summary>
        /// Removes the OrderLine object from the database
        /// </summary>
        /// <param name="entity">OrderLine object</param>
        /// <returns>The OrderLine object</returns>
        public async Task<OrderLine> RemoveAsync(OrderLine entity)
        {
            context.OrderLines.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Updates the database with the OrderLine object
        /// </summary>
        /// <param name="entity">An OrderLine object</param>
        /// <returns>The OrderLine object</returns>
        public async Task<OrderLine> UpdateAsync(OrderLine entity)
        {
            await context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Gets the orderline based on order id
        /// </summary>
        /// <param name="orderId">An integer that represents orderid</param>
        /// <returns>List of order lines by id</returns> 
        public async Task<IEnumerable<OrderLine>> GetOrderLinesOrderIdAsync(int orderId)
        {
            return await context.OrderLines.Where(o => o.OrderId == orderId).ToListAsync();
        }
    }
}
