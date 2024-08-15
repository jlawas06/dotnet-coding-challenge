namespace PizzaXYZ.Backend.Domain.Entities;
public class OrderDetails : BaseEntity<int>
{
    public int OrderId { get; set; }
    public required string PizzaId { get; set; }
    public int Quantity { get; set; }
}
