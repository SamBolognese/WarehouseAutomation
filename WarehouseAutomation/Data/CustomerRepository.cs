using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseAutomation.Data.Interfaces;

namespace WarehouseAutomation.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private WarehouseDBContext context;
        private DbSet<Customer> dbSet;

        public CustomerRepository(WarehouseDBContext context)
        {
            this.context = context;
            dbSet = context.Customers;
        }
        public void Add(Customer entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<Order> GetActiveOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetArchivedOrders()
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer entity)
        {
            dbSet.Remove(entity);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
