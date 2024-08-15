using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PizzaXYZ.Backend.Api.Controllers;
public abstract class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;
    public BaseController(IMediator mediator) => _mediator = mediator;
}