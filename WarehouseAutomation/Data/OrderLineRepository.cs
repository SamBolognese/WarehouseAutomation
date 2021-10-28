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

        public OrderLineRepository(WarehouseDBContext context)
        {
            this.context = context;
        }
        public async Task<OrderLine> AddAsync(OrderLine entity)
        {
            context.OrderLines.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<OrderLine>> GetAllAsync()
        {
            return await context.OrderLines.ToListAsync();
        }

        public async Task<OrderLine> RemoveAsync(OrderLine entity)
        {
            context.OrderLines.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<OrderLine> UpdateAsync(OrderLine entity)
        {
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<OrderLine>> GetOrderLinesOrderIdAsync(int orderId)
        {
            return await context.OrderLines.Where(o => o.OrderId == orderId).ToListAsync();
        }
    }
}
