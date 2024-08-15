namespace PizzaXYZ.Backend.Infrastructure.Data;
internal class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<PizzaType> PizzaTypes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
}
