﻿namespace PizzaXYZ.Backend.Application.Services;
internal class PizzaService(IAppDbContext context) : IPizzaService
{

    public async Task AddPizzaAsync(Pizza pizza)
    {
        await context.Pizzas.AddAsync(pizza);
        await context.SaveChangesAsync();
    }

    public async Task DeletePizzaAsync(string id)
    {
        var pizza = await context.Pizzas.FindAsync(id) ?? throw new NotFoundException($"Pizza with id {id} does not exist.");
        context.Pizzas.Remove(pizza);
        await context.SaveChangesAsync();
    }

    public async Task<Pizza> GetPizzaByIdAsync(string id)
    {
        return await context.Pizzas.FindAsync(id) ?? default!;
    }

    public async Task<IEnumerable<Pizza>> GetPizzasAsync()
    {
        return await context.Pizzas.AsNoTracking().ToListAsync();
    }

    public Task UpdatePizzaAsync(Pizza pizza)
    {
        context.Pizzas.Update(pizza);
        return context.SaveChangesAsync();
    }
}
