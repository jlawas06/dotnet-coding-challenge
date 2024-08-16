
namespace PizzaXYZ.Backend.Application.CQRS.Order.ImportOrders;
public class ImportOrdersCommand : IRequest<Unit>
{
    public required string FilePath { get; set; }
}

internal class ImportOrdersCommandHandler(IBulkInsertService bulkInsertService) : IRequestHandler<ImportOrdersCommand, Unit>
{
    public async Task<Unit> Handle(ImportOrdersCommand request, CancellationToken cancellationToken)
    {

        return Unit.Value;
    }
}