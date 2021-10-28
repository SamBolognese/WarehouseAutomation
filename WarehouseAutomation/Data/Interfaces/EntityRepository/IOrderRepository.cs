using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseAutomation.Data.Interfaces
{
    interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetDispatchedOrdersAsync();
        Task<IEnumerable<Order>> GetPendingOrdersAsync();
        Task<bool> ItemsInStockAsync(Order entity);
        Task<Order> UpdateDispatchStatusAsync(Order entity);
    }
}
