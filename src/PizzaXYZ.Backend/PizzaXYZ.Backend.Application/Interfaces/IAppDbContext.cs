using Microsoft.EntityFrameworkCore;

namespace PizzaXYZ.Backend.Application.Interfaces;
public interface IAppDbContext
{
    DbSet<Pizza> Pizzas { get; set; }
    DbSet<PizzaType> PizzaTypes { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<OrderDetails> OrderDetails { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
