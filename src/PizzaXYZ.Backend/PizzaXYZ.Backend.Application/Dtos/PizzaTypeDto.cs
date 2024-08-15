using CsvHelper.Configuration.Attributes;

namespace PizzaXYZ.Backend.Application.Dtos;
public class PizzaTypeDto
{
    [Name("pizza_type_id")]
    public required string Id { get; set; }
    [Name("name")]
    public required string Name { get; set; }
    [Name("category")]
    public required string Category { get; set; }
    [Name("ingredients")]
    public required string Ingredients { get; set; }
}
