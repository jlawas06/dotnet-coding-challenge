
namespace PizzaXYZ.Backend.Application.CQRS.Pizzas.DeletePizza;
public class DeletePizzaCommand : IRequest<Unit>
{
    public required string Id { get; set; }
}

internal class DeletePizzaCommandHandler(IPizzaService pizzaService) : IRequestHandler<DeletePizzaCommand, Unit>
{
    public async Task<Unit> Handle(DeletePizzaCommand request, CancellationToken cancellationToken)
    {
        var pizza = await pizzaService.GetPizzaByIdAsync(request.Id) ?? throw new NotFoundException($"Pizza {request.Id} does not exits.");

        await pizzaService.DeletePizzaAsync(request.Id);
        return Unit.Value;
    }
}