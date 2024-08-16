
namespace PizzaXYZ.Backend.Application.CQRS.Order.ImportOrderDetails;
public class ImportOrderDetailsCommand : IRequest<Unit>
{
    public required string FilePath { get; set; }
}

internal class ImportOrderDetailsCommandHandler : IRequestHandler<ImportOrderDetailsCommand, Unit>
{
    private readonly IBulkInsertService _bulkInsertService;
    private readonly IMapper _mapper;

    public ImportOrderDetailsCommandHandler(IBulkInsertService bulkInsertService)
    {
        _bulkInsertService = bulkInsertService;

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<OrderDetailsDto, OrderDetails>();
        });

        _mapper = config.CreateMapper();
    }

    public async Task<Unit> Handle(ImportOrderDetailsCommand request, CancellationToken cancellationToken)
    {
        var records = CsvParserHelper.Parse<OrderDetailsDto>(request.FilePath);
        var orders = _mapper.Map<List<OrderDetails>>(records);
        await _bulkInsertService.BulkInsertAsync(orders, TableNamesConstants.OrderDetails);
        return Unit.Value;
    }
}