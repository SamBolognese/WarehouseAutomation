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
        private readonly WarehouseDBContext context;

        public CustomerRepository(WarehouseDBContext context)
        {
            this.context = context;
        }
        public async Task<Customer> AddAsync(Customer entity)
        {
            context.Customers.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetActiveOrdersAsync(Customer customer)
        {
            return await context.Orders.Where(o => o.CustomerId == customer.Id && o.Dispatched == false).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetArchivedOrdersAsync(Customer customer)
        {
            return await context.Orders.Where(o => o.CustomerId == customer.Id && o.Dispatched == true).ToListAsync();
        }

        public async Task<Customer> RemoveAsync(Customer entity)
        {
            context.Customers.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<Customer> UpdateAsync(Customer entity)
        {
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
