namespace WarehouseAutomation.Data
{
    public interface IOrderLine
    {
        int Id { get; set; }
        Order Order { get; set; }
        int OrderId { get; set; }
        Product Product { get; set; }
        int ProductId { get; set; }
        int Quantity { get; set; }
    }
}