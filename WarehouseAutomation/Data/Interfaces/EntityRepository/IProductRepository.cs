using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseAutomation.Data.Interfaces
{
    interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetOutOfStockAsync();
        Task<DateTime> GetRestockingDateAsync(Product product);
    }
}
