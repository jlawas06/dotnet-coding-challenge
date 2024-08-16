using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaXYZ.Backend.Application.CQRS.Order.ImportOrderDetails;
using PizzaXYZ.Backend.Application.CQRS.Order.ImportOrders;
using PizzaXYZ.Backend.Application.CQRS.Pizzas.ImportPizzas;
using PizzaXYZ.Backend.Application.CQRS.Pizzas.ImportPizzaTypes;
using PizzaXYZ.Backend.Application.Exceptions;

namespace PizzaXYZ.Backend.Api.Controllers;
[Route("api/csv-import")]
[ApiController]
public class CSVImportController : ControllerBase
{
    private readonly IMediator _mediator;

    public CSVImportController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("upload-pizzas")]
    public async Task<IActionResult> ImportPizzas([FromForm] IFormFile file)
    {
        var filePath = await ValidateAndGetFilePath(file);
        await _mediator.Send(new ImportPizzasCommand { FilePath = filePath });
        return Ok();
    }

    [HttpPost]
    [Route("upload-pizza-types")]
    public async Task<IActionResult> ImportPizzaTypes([FromForm] IFormFile file)
    {
        var filePath = await ValidateAndGetFilePath(file);
        await _mediator.Send(new ImportPizzaTypesCommand { FilePath = filePath });
        return Ok();
    }

    [HttpPost]
    [Route("upload-orders")]
    public async Task<IActionResult> ImportOrders([FromForm] IFormFile file)
    {
        var filePath = await ValidateAndGetFilePath(file);
        await _mediator.Send(new ImportOrdersCommand { FilePath = filePath });
        return Ok();
    }

    [HttpPost]
    [Route("upload-orderdetails")]
    public async Task<IActionResult> ImportOrderDetails([FromForm] IFormFile file)
    {
        var filePath = await ValidateAndGetFilePath(file);
        await _mediator.Send(new ImportOrderDetailsCommand { FilePath = filePath });
        return Ok();
    }

    private static async Task<string> ValidateAndGetFilePath(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new BadRequestException("File is empty");

        if (!file.FileName.EndsWith(".csv"))
            throw new BadRequestException("File is not a CSV");

        var filePath = Path.GetTempFileName();

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return filePath;
    }
}
