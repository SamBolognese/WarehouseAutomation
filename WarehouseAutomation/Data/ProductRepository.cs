using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseAutomation.Data.Interfaces;

namespace WarehouseAutomation.Data
{
    public class ProductRepository : IProductRepository
    {
        //Unqiqique Id add
        private WarehouseDBContext context;
        private DbSet<Product> dbSet;

        public ProductRepository(WarehouseDBContext context)
        {
            this.context = context;
            dbSet = context.Products;
        }

        public void Add(Product entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetOutOfStock()
        {
            throw new NotImplementedException();
        }

        public DateTime GetRestockingDate()
        {
            throw new NotImplementedException();
        }

        public void Remove(Product entity)
        {
            dbSet.Remove(entity);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
