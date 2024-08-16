
namespace PizzaXYZ.Backend.Application.CQRS.Pizzas.GetPizzaById;
public class GetPizzaByIdQuery : IRequest<PizzaDto>
{
    public required string Id { get; set; }
}

internal class GetPizzaByIdQueryHandler : IRequestHandler<GetPizzaByIdQuery, PizzaDto>
{
    private readonly IPizzaService _pizzaService;
    private readonly IMapper _mapper;

    public GetPizzaByIdQueryHandler(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Pizza, PizzaDto>();
        });

        _mapper = config.CreateMapper();
    }

    public async Task<PizzaDto> Handle(GetPizzaByIdQuery request, CancellationToken cancellationToken)
    {
        var pizza = await _pizzaService.GetPizzaByIdAsync(request.Id) ?? throw new NotFoundException($"Pizza {request.Id} not exists.");
        return _mapper.Map<PizzaDto>(pizza);
    }
}
