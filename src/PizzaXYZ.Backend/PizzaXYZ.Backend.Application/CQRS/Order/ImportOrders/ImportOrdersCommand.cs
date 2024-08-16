
namespace PizzaXYZ.Backend.Application.CQRS.Order.ImportOrders;
public class ImportOrdersCommand : IRequest<Unit>
{
    public required string FilePath { get; set; }
}

internal class ImportOrdersCommandHandler : IRequestHandler<ImportOrdersCommand, Unit>
{
    private readonly IBulkInsertService _bulkInsertService;
    private readonly IMapper _mapper;

    public ImportOrdersCommandHandler(IBulkInsertService bulkInsertService)
    {
        _bulkInsertService = bulkInsertService;

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<OrderDto, Domain.Entities.Order>();
        });

        _mapper = config.CreateMapper();
    }
    public async Task<Unit> Handle(ImportOrdersCommand request, CancellationToken cancellationToken)
    {
        var records = CsvParserHelper.Parse<OrderDto>(request.FilePath);
        var orders = _mapper.Map<List<Domain.Entities.Order>>(records);
        await _bulkInsertService.BulkInsertAsync(orders, TableNamesConstants.Orders);
        return Unit.Value;
    }
}