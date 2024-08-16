namespace PizzaXYZ.Backend.Domain.Entities;
public class PizzaType : BaseEntity<string>
{
    public required string Name { get; set; }
    public required string Category { get; set; }
    public required string Ingredients { get; set; }
    public virtual ICollection<Pizza> Pizzas { get; set; } = [];
}
