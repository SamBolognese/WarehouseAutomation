using System;

namespace WarehouseAutomation.Data
{
    public interface IProduct
    {
        string Description { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        DateTime RestockingDate { get; set; }
        int Stock { get; set; }
    }
}