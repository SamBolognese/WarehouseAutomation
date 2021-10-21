using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseAutomation.Data.Interfaces
{
    interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetOutOfStock();
        DateTime GetRestockingDate();
    }
}
