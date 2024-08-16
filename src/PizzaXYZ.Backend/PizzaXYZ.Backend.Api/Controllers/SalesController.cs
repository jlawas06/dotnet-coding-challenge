using Microsoft.AspNetCore.Mvc;
using PizzaXYZ.Backend.Application.Interfaces;

namespace PizzaXYZ.Backend.Api.Controllers;
[Route("api/sales")]
[ApiController]
public class SalesController(ISalesService salesService) : ControllerBase
{
    [HttpGet("daily/{date}")]
    public async Task<IActionResult> GetDailySalesReport(DateOnly date)
    {
        var result = await salesService.GetDailySalesReportAsync(date);
        return Ok(result);
    }

    [HttpGet("monthly/{year}/{month}")]
    public async Task<IActionResult> GetMonthlySalesReport(int year, int month)
    {
        var result = await salesService.GetMonthlySalesReportAsync(year, month);
        return Ok(result);
    }

    [HttpGet("top-selling")]
    public async Task<IActionResult> GetTopSellingPizzas([FromQuery] int top = 10)
    {
        var result = await salesService.GetTopSellingPizzasAsync(top);
        return Ok(result);
    }

    [HttpGet("by-category")]
    public async Task<IActionResult> GetSalesByCategory()
    {
        var result = await salesService.GetSalesByCategoryAsync();
        return Ok(result);
    }

    [HttpGet("by-size")]
    public async Task<IActionResult> GetSalesBySize()
    {
        var result = await salesService.GetSalesBySizeAsync();
        return Ok(result);
    }
}
