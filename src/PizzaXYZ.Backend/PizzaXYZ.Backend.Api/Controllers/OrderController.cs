using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaXYZ.Backend.Application.CQRS.Order.AddOrder;
using PizzaXYZ.Backend.Application.CQRS.Order.DeleteOrder;
using PizzaXYZ.Backend.Application.CQRS.Order.GetOrderById;
using PizzaXYZ.Backend.Application.CQRS.Order.GetOrders;

namespace PizzaXYZ.Backend.Api.Controllers;
[Route("api/order")]
[ApiController]
public class OrderController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Route("get-orders")]
    public async Task<IActionResult> GetOrders([FromQuery] GetOrdersQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [HttpGet]
    [Route("get-order/{id}")]
    public async Task<IActionResult> GetOrders(int id)
    {
        return Ok(await mediator.Send(new GetOrderByIdQuery { Id = id}));
    }

    [HttpPost]
    [Route("add-order")]
    public async Task<IActionResult> AddOrder(AddOrderCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    [HttpPost]
    [Route("update-order")]
    public async Task<IActionResult> UpdateOrder(AddOrderCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    [HttpPost]
    [Route("delete-order")]
    public async Task<IActionResult> DeleteOrder(DeleteOrderCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }
}
