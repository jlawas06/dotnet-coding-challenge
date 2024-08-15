namespace PizzaXYZ.Backend.Application.Extensions;
public static class PizzaTypesExtensions
{
    public static List<PizzaType> ToDomainList(this List<PizzaTypeDto> pizzaTypesDto)
    {
        return pizzaTypesDto.Select(pizzaTypeDto => new PizzaType
        {
            Id = pizzaTypeDto.Id,
            Name = pizzaTypeDto.Name,
            Category = pizzaTypeDto.Category,
            Ingredients = pizzaTypeDto.Ingredients
        }).ToList();
    }

    public static PizzaType ToDomain(this PizzaTypeDto pizzaTypeDto)
    {
        return new PizzaType
        {
            Id = pizzaTypeDto.Id,
            Name = pizzaTypeDto.Name,
            Category = pizzaTypeDto.Category,
            Ingredients = pizzaTypeDto.Ingredients

        };
    }
}
