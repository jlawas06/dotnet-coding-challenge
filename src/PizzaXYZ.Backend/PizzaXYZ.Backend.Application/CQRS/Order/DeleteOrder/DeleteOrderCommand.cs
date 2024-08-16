
namespace PizzaXYZ.Backend.Application.CQRS.Order.DeleteOrder;
public class DeleteOrderCommand : IRequest<Unit>
{
    public int Id { get; set; }
}


internal class DeleteOrderCommandHandler(IOrderService orderService) : IRequestHandler<DeleteOrderCommand, Unit>
{
    public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await orderService.GetOrderByIdAsync(request.Id) ?? throw new NotFoundException($"Order {request.Id} not exists.");
        await orderService.DeleteOrderAsync(request.Id);
        return Unit.Value;
    }
}