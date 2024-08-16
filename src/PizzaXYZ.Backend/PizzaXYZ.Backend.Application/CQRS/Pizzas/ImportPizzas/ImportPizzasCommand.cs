using PizzaXYZ.Backend.Domain.Enumerations;

namespace PizzaXYZ.Backend.Application.CQRS.Pizzas.ImportPizzas;
public class ImportPizzasCommand : IRequest<Unit>
{
    public required string FilePath { get; set; }
}

internal class ImportPizzasCommandHandler : IRequestHandler<ImportPizzasCommand, Unit>
{
    private readonly IBulkInsertService _bulkInsertService;
    private readonly IMapper _mapper;

    public ImportPizzasCommandHandler(IBulkInsertService bulkInsertService)
    {
        _bulkInsertService = bulkInsertService;

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<PizzaDto, Pizza>().ForMember(dest => dest.Size, opt => opt.MapFrom(src => Enum.Parse<PizzaSize>(src.Size)));
        });

        _mapper = config.CreateMapper();
    }
    public async Task<Unit> Handle(ImportPizzasCommand request, CancellationToken cancellationToken)
    {
        var records = CsvParserHelper.Parse<PizzaDto>(request.FilePath);
        var pizzas = _mapper.Map<List<Pizza>>(records);
        await _bulkInsertService.BulkInsertAsync(pizzas, TableNamesConstants.Pizzas);
        return Unit.Value;
    }
}