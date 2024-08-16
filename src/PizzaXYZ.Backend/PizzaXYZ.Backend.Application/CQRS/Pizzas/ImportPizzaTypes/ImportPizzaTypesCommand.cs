namespace PizzaXYZ.Backend.Application.CQRS.Pizzas.ImportPizzaTypes;
public class ImportPizzaTypesCommand : IRequest<Unit>
{
    public required string FilePath { get; set; }
}

internal class ImportPizzaTypesCommandHandler : IRequestHandler<ImportPizzaTypesCommand, Unit>
{
    private readonly IBulkInsertService _bulkInsertService;
    private readonly IMapper _mapper;

    public ImportPizzaTypesCommandHandler(IBulkInsertService bulkInsertService)
    {
        _bulkInsertService = bulkInsertService;

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<PizzaTypeDto, PizzaType>();
        });

        _mapper = config.CreateMapper();
    }

    public async Task<Unit> Handle(ImportPizzaTypesCommand request, CancellationToken cancellationToken)
    {
        var records = CsvParserHelper.Parse<PizzaTypeDto>(request.FilePath);
        var pizzaTypes = _mapper.Map<List<PizzaTypeDto>>(records);
        await _bulkInsertService.BulkInsertAsync(pizzaTypes, TableNamesConstants.PizzaTypes);
        return Unit.Value;

    }
}
