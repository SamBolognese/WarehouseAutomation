namespace WarehouseAutomation.Data
{
    public interface ICustomer
    {
        int Id { get; set; }
        string Name { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
    }
}