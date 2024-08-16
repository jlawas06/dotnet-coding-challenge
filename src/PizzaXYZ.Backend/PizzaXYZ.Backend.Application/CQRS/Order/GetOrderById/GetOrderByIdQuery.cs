namespace PizzaXYZ.Backend.Application.CQRS.Order.GetOrderById;
public class GetOrderByIdQuery : IRequest<OrderDto>
{
    public int Id { get; set; }
}

internal class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public GetOrderByIdQueryHandler(IOrderService orderService)
    {
        _orderService = orderService;

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Domain.Entities.Order, OrderDto>();
        });

        _mapper = config.CreateMapper();
    }

    public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderService.GetOrderByIdAsync(request.Id) ?? throw new NotFoundException($"Order {request.Id} not exists.");
        return _mapper.Map<OrderDto>(order);
    }
}
