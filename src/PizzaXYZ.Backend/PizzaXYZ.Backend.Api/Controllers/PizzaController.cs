using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaXYZ.Backend.Application.CQRS.Pizzas.AddPizza;

namespace PizzaXYZ.Backend.Api.Controllers;
[Route("api/pizza")]
[ApiController]
public class PizzaController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    [Route("add-pizza")]
    public async Task<IActionResult> AddPizza([FromBody] AddPizzaCommand command)
    {
        await _mediator.Send(command);
        return Ok();

    }
}
