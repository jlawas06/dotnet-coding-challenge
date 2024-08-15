using CsvHelper.Configuration.Attributes;

namespace PizzaXYZ.Backend.Application.Dtos;
public class PizzaDto
{
    [Name("pizza_id")]
    public required string Id { get; set; }
    [Name("size")]
    public required string Size { get; set; }
    [Name("price")]
    public decimal Price { get; set; }
    [Name("pizza_type_id")]
    public required string PizzaTypeId { get; set; }
}
