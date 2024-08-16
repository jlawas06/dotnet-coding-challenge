using CsvHelper.Configuration.Attributes;

namespace PizzaXYZ.Backend.Application.Dtos;
public class OrderDto
{
    [Name("order_id")]
    public int Id { get; set; }
    [Name("date")]
    public DateOnly Date { get; set; }
    [Name("time")]
    public TimeOnly Time { get; set; }
}
