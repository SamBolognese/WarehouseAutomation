using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseAutomation.Data.Interfaces
{
    interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetDispatchedOrdersAsync();
        Task<IEnumerable<Order>> GetDispatchedOrdersAsync(int customerId);
        Task<IEnumerable<Order>> GetPendingOrdersAsync();
        Task<IEnumerable<Order>> GetPendingOrdersAsync(int customerId);
        Task<Order> UpdateDispatchStatusAsync(Order entity);
        Task<Order> PayOrderAsync(Order entity);
    }
}
