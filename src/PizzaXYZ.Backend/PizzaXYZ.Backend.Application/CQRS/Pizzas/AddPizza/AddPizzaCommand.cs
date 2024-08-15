using PizzaXYZ.Backend.Domain.Enumerations;

namespace PizzaXYZ.Backend.Application.CQRS.Pizzas.AddPizza;
public class AddPizzaCommand : IRequest<Unit>
{
    public required string Id { get; set; }
    public required string Size { get; set; }
    public decimal Price { get; set; }
    public required string PizzaTypeId { get; set; }
}

internal class AddPizzaCommandHandler(IPizzaService pizzaService) : IRequestHandler<AddPizzaCommand, Unit>
{
    public async Task<Unit> Handle(AddPizzaCommand request, CancellationToken cancellationToken)
    {

        var existingPizza = await pizzaService.GetPizzaByIdAsync(request.Id);

        if (existingPizza != null) throw new BadRequestException($"Pizza with {request.Id} already exists");

        var pizza = new Pizza
        {
            Id = request.Id,
            Size = Enum.Parse<PizzaSize>(request.Size),
            Price = request.Price,
            PizzaTypeId = request.PizzaTypeId
        };

        await pizzaService.AddPizzaAsync(pizza);
        return Unit.Value;
    }
}
