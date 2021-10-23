using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseAutomation.Data.Interfaces
{
    interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Order>> GetArchivedOrdersAsync(Customer customer);
        Task<IEnumerable<Order>> GetActiveOrdersAsync(Customer customer);
    }
}
