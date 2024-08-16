namespace PizzaXYZ.Backend.Application.Services;
internal class OrderService(IAppDbContext context) : IOrderService
{
    public async Task AddOrderAsync(Order order)
    {
        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(int id)
    {
        var order = await context.Orders.FindAsync(id) ?? throw new NotFoundException($"Order with id {id} does not exist.");
        context.Orders.Remove(order);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await context.Orders.AsNoTracking().ToListAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        return await context.Orders.FindAsync(id) ?? default!;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync(int page, int pageSize)
    {
        if (pageSize == 0) {
            page = 1;
        }

        var skip = (page - 1) * pageSize;


        return await context.Orders.AsNoTracking().Skip(skip).Take(pageSize).ToListAsync();
    }

    public async Task UpdateOrderAsync(Order order)
    {
        context.Orders.Update(order);
        await context.SaveChangesAsync();
    }
}
