using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseAutomation.Data.Interfaces
{
    interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Order> GetArchivedOrders();
        IEnumerable<Order> GetActiveOrders();
    }
}
