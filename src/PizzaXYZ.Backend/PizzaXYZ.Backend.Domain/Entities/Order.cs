namespace PizzaXYZ.Backend.Domain.Entities;
public class Order : BaseEntity<int>
{
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public virtual ICollection<OrderDetails> OrderDetails { get; set; } = [];
}
