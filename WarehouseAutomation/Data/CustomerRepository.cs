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

        /// <summary>
        /// CustomerRepository constructor that takes a WarehouseDBContext as input paramater
        /// </summary>
        /// <param name="context">sets the parameter WarehouseDBContext to the class readonly variable of the same type</param>
        public CustomerRepository(WarehouseDBContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Takes a customer object and adds it to the database
        /// </summary>
        /// <param name="entity">Customer object as input parameter</param>
        /// <returns>Returns the customer object</returns>
        public async Task<Customer> AddAsync(Customer entity)
        {
            context.Customers.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Takes all the customers in the database and returns them as a list of customer objects
        /// </summary>
        /// <returns>list of customer objects</returns>
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await context.Customers.ToListAsync();
        }

        /// <summary>
        /// Returns a list of orders that are still active (not dispatched)
        /// </summary>
        /// <param name="customer">A customer object</param>
        /// <returns>list of orders that are not dispatched</returns>
        public async Task<IEnumerable<Order>> GetActiveOrdersAsync(Customer customer)
        {
            return await context.Orders.Where(o => o.CustomerId == customer.Id && o.Dispatched == false).ToListAsync();
        }

        /// <summary>
        /// Returns a list of orders that are archived (dispatched)
        /// </summary>
        /// <param name="customer">A customer object</param>
        /// <returns>list of dispatched orders</returns>
        public async Task<IEnumerable<Order>> GetArchivedOrdersAsync(Customer customer)
        {
            return await context.Orders.Where(o => o.CustomerId == customer.Id && o.Dispatched == true).ToListAsync();
        }

        /// <summary>
        /// Removes the customer from the database
        /// </summary>
        /// <param name="entity">A Customer object</param>
        /// <returns>The Customer object</returns>
        public async Task<Customer> RemoveAsync(Customer entity)
        {
            context.Customers.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Updates the database with the customer object
        /// </summary>
        /// <param name="entity">A Customer object</param>
        /// <returns>The Customer object</returns>
        public async Task<Customer> UpdateAsync(Customer entity)
        {
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
