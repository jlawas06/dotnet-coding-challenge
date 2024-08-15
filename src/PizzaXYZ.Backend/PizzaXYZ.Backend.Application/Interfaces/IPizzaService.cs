namespace PizzaXYZ.Backend.Application.Interfaces;
public interface IPizzaService
{
    Task<Pizza> GetPizzaByIdAsync(string id);
    Task<IEnumerable<Pizza>> GetPizzasAsync();
    Task AddPizzaAsync(Pizza pizza);
    Task UpdatePizzaAsync(Pizza pizza);
    Task DeletePizzaAsync(string id);
    Task BulkInsertPizzasAsync(IList<Pizza> pizzas);
}
