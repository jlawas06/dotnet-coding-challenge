
namespace PizzaXYZ.Backend.Application.CQRS.Pizzas.ImportPizzas;
public class ImportPizzasCommand : IRequest<Unit>
{
    public required string FilePath { get; set; }
}

internal class ImportPizzasCommandHandler(IPizzaService pizzaService) : IRequestHandler<ImportPizzasCommand, Unit>
{
    public async Task<Unit> Handle(ImportPizzasCommand request, CancellationToken cancellationToken)
    {
        var pizzas = await PizzaDataParserHelper.ParseCsvFileAsync(request.FilePath);
        await pizzaService.BulkInsertPizzasAsync(pizzas);
        return Unit.Value;
    }
}