using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaXYZ.Backend.Application.CQRS.Pizzas.AddPizza;
using PizzaXYZ.Backend.Application.CQRS.Pizzas.DeletePizza;
using PizzaXYZ.Backend.Application.CQRS.Pizzas.GetPizzaById;
using PizzaXYZ.Backend.Application.CQRS.Pizzas.GetPizzas;
using PizzaXYZ.Backend.Application.CQRS.Pizzas.UpdatePizza;

namespace PizzaXYZ.Backend.Api.Controllers;
[Route("api/pizza")]
[ApiController]
public class PizzaController(IMediator mediator) : ControllerBase
{

    [HttpGet]
    [Route("get-pizzas")]
    public async Task<IActionResult> GetPizzas()
    {
        return Ok(await mediator.Send(new GetPizzasQuery()));
    }

    [HttpGet]
    [Route("get-pizza/{id}")]
    public async Task<IActionResult> GetPizzaById(string id)
    {
        return Ok(await mediator.Send(new GetPizzaByIdQuery { Id = id }));
    }

    [HttpPost]
    [Route("add-pizza")]
    public async Task<IActionResult> AddPizza([FromBody] AddPizzaCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    [HttpPost]
    [Route("update-pizza")]
    public async Task<IActionResult> UpdatePizza([FromBody] UpdatePizzaCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }

    [HttpPost]
    [Route("delete-pizza")]
    public async Task<IActionResult> DeletePizza([FromBody] DeletePizzaCommand command)
    {
        await mediator.Send(command);
        return Ok();
    }
}
