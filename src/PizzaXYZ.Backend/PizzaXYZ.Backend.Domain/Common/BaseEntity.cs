namespace PizzaXYZ.Backend.Domain.Common;
public abstract class BaseEntity<T>
{
    public required virtual T Id { get; set; }
}
