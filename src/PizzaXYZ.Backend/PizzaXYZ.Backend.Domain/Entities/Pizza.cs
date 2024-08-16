namespace PizzaXYZ.Backend.Domain.Entities;
public class Pizza : BaseEntity<string>
{
    public PizzaSize Size { get; set; }
    public decimal Price { get; set; }
    public required string PizzaTypeId { get; set; }
    public virtual PizzaType PizzaType { get; set; } = default!;
    public virtual ICollection<OrderDetails> OrderDetails { get; set; } = [];
}
