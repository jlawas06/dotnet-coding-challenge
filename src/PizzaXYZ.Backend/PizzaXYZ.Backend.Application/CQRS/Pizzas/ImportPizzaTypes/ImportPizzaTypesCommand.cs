using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using PizzaXYZ.Backend.Application.Extensions;

namespace PizzaXYZ.Backend.Application.CQRS.Pizzas.ImportPizzaTypes;
public class ImportPizzaTypesCommand : IRequest<Unit>
{
    public required string FilePath { get; set; }
}

internal class ImportPizzaTypesCommandHandler(IBulkInsertService bulkInsertService) : IRequestHandler<ImportPizzaTypesCommand, Unit>
{
    public async Task<Unit> Handle(ImportPizzaTypesCommand request, CancellationToken cancellationToken)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        };
        using var reader = new StreamReader(request.FilePath);
        using var csv = new CsvReader(reader, config);
        var records = csv.GetRecords<PizzaTypeDto>().ToList();
        var pizzaTypes = records.ToDomainList();
        await bulkInsertService.BulkInsertAsync(pizzaTypes, "PizzaTypes");
        return Unit.Value;

    }
}
