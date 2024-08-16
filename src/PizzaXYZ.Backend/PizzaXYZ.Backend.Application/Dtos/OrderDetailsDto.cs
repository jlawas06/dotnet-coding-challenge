using CsvHelper.Configuration.Attributes;

namespace PizzaXYZ.Backend.Application.Dtos;
public class OrderDetailsDto
{
    [Name("order_details_id")]
    public int Id { get; set; }
    [Name("order_id")]
    public int OrderId { get; set; }
    [Name("pizza_id")]
    public required string PizzaId { get; set; }
    [Name("quantity")]
    public int Quantity { get; set; }
}
