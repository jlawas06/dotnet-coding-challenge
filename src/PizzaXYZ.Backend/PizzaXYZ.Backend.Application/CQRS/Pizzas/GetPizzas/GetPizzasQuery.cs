
namespace PizzaXYZ.Backend.Application.CQRS.Pizzas.GetPizzas;
public class GetPizzasQuery : IRequest<IEnumerable<PizzaDto>>
{
}

internal class GetPizzasQueryHandler : IRequestHandler<GetPizzasQuery, IEnumerable<PizzaDto>>
{
    private readonly IPizzaService _pizzaService;
    private readonly IMapper _mapper;

    public GetPizzasQueryHandler(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Pizza, PizzaDto>();
        });

        _mapper = config.CreateMapper();
    }

    public async Task<IEnumerable<PizzaDto>> Handle(GetPizzasQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<PizzaDto>>(await _pizzaService.GetPizzasAsync());
    }
}