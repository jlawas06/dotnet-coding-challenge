
namespace PizzaXYZ.Backend.Application.CQRS.Order.AddOrder;
public class AddOrderDetails
{
    public required string PizzaId { get; set; }
    public int Quantity { get; set; }
}
public class AddOrderCommand : IRequest<Unit>
{
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public IEnumerable<AddOrderDetails> Details { get; set; } = [];
}

internal class AddOrderCommandHandler(IOrderService orderService) : IRequestHandler<AddOrderCommand, Unit>
{
    public async Task<Unit> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Domain.Entities.Order
        {
            Id = default,
            Date = request.Date,
            Time = request.Time,
            OrderDetails = request.Details.Select(od => new OrderDetails
            {
                Id = default,
                PizzaId = od.PizzaId,
                Quantity = od.Quantity,
            }).ToList()
        };

        await orderService.AddOrderAsync(order);

        return Unit.Value;
    }
}