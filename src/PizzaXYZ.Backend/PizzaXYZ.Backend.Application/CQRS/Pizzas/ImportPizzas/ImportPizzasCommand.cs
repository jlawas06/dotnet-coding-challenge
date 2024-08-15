
namespace PizzaXYZ.Backend.Application.CQRS.Pizzas.ImportPizzas;
public class ImportPizzasCommand : IRequest<Unit>
{
    public required string FilePath { get; set; }
}

internal class ImportPizzasCommandHandler(IBulkInsertService bulkInsertService) : IRequestHandler<ImportPizzasCommand, Unit>
{
    public async Task<Unit> Handle(ImportPizzasCommand request, CancellationToken cancellationToken)
    {
        var pizzas = await PizzaDataParserHelper.ParseCsvFileToPizzaAsync(request.FilePath);
        await bulkInsertService.BulkInsertAsync(pizzas, "Pizzas");
        return Unit.Value;
    }
}