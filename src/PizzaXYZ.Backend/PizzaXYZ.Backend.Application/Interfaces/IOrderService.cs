namespace PizzaXYZ.Backend.Application.Interfaces;
public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<IEnumerable<Order>> GetOrdersAsync(int page, int pageSize);
    Task<Order> GetOrderByIdAsync(int id);
    Task AddOrderAsync(Order order);
    Task DeleteOrderAsync(int id);
    Task UpdateOrderAsync(Order order);
}
