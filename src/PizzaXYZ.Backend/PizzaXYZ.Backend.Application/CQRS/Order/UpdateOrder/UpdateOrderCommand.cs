
namespace PizzaXYZ.Backend.Application.CQRS.Order.UpdateOrder;
public class UpdateOrderCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public IEnumerable<UpdateOrderDetails> Details { get; set; } = [];
}

public class UpdateOrderDetails
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public required string PizzaId { get; set; }
    public int Quantity { get; set; }
}

internal class UpdateOrderCommandHandler(IOrderService orderService) : IRequestHandler<UpdateOrderCommand, Unit>
{
    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await orderService.GetOrderByIdAsync(request.Id) ?? throw new NotFoundException($"Order {request.Id} not exists.");

        order.OrderDetails = request.Details.Select(od => new OrderDetails
        {
            Id = od.Id,
            OrderId = order.Id,
            PizzaId = od.PizzaId,
            Quantity = od.Quantity,

        }).ToList();

        await orderService.UpdateOrderAsync(order);

        return Unit.Value;
    }
}