
using PizzaXYZ.Backend.Domain.Enumerations;

namespace PizzaXYZ.Backend.Application.CQRS.Pizzas.UpdatePizza;
public class UpdatePizzaCommand : IRequest<Unit>
{
    public required string Id { get; set; }
    public required string Size { get; set; }
    public decimal Price { get; set; }
    public required string PizzaTypeId { get; set; }
}

internal class UpdatePizzaCommandHandler(IPizzaService pizzaService) : IRequestHandler<UpdatePizzaCommand, Unit>
{
    public async Task<Unit> Handle(UpdatePizzaCommand request, CancellationToken cancellationToken)
    {
        var existingPizza = await pizzaService.GetPizzaByIdAsync(request.Id) ?? throw new NotFoundException($"Pizza {request.Id} not exists.");

        existingPizza.Size = Enum.Parse<PizzaSize>(request.Size);
        existingPizza.PizzaTypeId = request.PizzaTypeId;
        existingPizza.Price = request.Price;

        await pizzaService.UpdatePizzaAsync(existingPizza);

        return Unit.Value;
    }
}
