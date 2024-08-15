using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaXYZ.Backend.Application.CQRS.Pizzas.ImportPizzas;

namespace PizzaXYZ.Backend.Api.Controllers;
[Route("api/csv-import")]
[ApiController]
public class CSVImportController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Route("upload-pizzas")]
    public async Task<IActionResult> ImportPizzas([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("File is empty");

        if (!file.FileName.EndsWith(".csv"))
            return BadRequest("File is not a CSV");

        var filePath = Path.GetTempFileName();

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        await mediator.Send(new ImportPizzasCommand { FilePath = filePath });
        return Ok();
    }
}
