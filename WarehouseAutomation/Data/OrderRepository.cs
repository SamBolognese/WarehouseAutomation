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
        private WarehouseDBContext context;
        private DbSet<Order> dbSet;

        public OrderRepository(WarehouseDBContext context)
        {
            this.context = context;
            dbSet = context.Orders;
        }
        public void Add(Order entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<Order> GetAll()
        {
            /*
            IEnumerable<Order> query = from order in context.Orders
                                       join orderLine in context.OrderLines
                                       on order.Id equals orderLine.OrderId
            */
            return context.Orders.ToList();
        }

        public IEnumerable<Order> GetDispatchedOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetPendingOrders()
        {
            throw new NotImplementedException();
        }

        public void Remove(Order entity)
        {
            dbSet.Remove(entity);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
