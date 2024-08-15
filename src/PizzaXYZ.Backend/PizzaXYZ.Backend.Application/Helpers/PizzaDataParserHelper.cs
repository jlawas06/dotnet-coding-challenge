using PizzaXYZ.Backend.Domain.Enumerations;

namespace PizzaXYZ.Backend.Application.Helpers;
public static class PizzaDataParserHelper
{
    public static async Task<List<Pizza>> ParseCsvFileAsync(string filePath)
    {
        var pizzas = new List<Pizza>();

        using (var reader = new StreamReader(filePath))
        {
            // Skip the header line
            await reader.ReadLineAsync();

            string line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                var values = line.Split(',');
                if (values.Length == 4)
                {
                    var pizza = new Pizza
                    {
                        Id = values[0],
                        PizzaTypeId = values[1],
                        Size = Enum.Parse<PizzaSize>(values[2]),
                        Price = decimal.Parse(values[3])
                    };
                    pizzas.Add(pizza);
                }
            }
        }

        return pizzas;
    }
}
