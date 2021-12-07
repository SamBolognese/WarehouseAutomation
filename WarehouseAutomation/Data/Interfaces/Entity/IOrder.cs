using System;

namespace WarehouseAutomation.Data
{
   
    public interface IOrder
    {
      
        Customer Customer { get; set; }
        int CustomerId { get; set; }
        string DeliveryAddress { get; set; }
        bool Dispatched { get; set; }
        int Id { get; set; }
        DateTime OrderDate { get; set; }
        bool PaymentCompleted { get; set; }
    }
}