
namespace PizzaXYZ.Backend.Application.CQRS.Order.GetOrders;
public class GetOrdersQuery : IRequest<IEnumerable<OrderDto>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

internal class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<OrderDto>>
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public GetOrdersQueryHandler(IOrderService orderService)
    {
        _orderService = orderService;

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Domain.Entities.Order, OrderDto>();
        });

        _mapper = config.CreateMapper();
    }

    public async Task<IEnumerable<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<OrderDto>>(await _orderService.GetOrdersAsync(request.Page, request.PageSize));
    }
}