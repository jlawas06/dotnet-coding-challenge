using PizzaXYZ.Backend.Domain.Enumerations;

namespace PizzaXYZ.Backend.Application.Helpers;
public static class PizzaDataParserHelper
{
    public static async Task<List<Pizza>> ParseCsvFileToPizzaAsync(string filePath)
    {
        var data = new List<Pizza>();

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
                    data.Add(new Pizza
                    {
                        Id = values[0],
                        PizzaTypeId = values[1],
                        Size = Enum.Parse<PizzaSize>(values[2]),
                        Price = decimal.Parse(values[3])
                    });
                }
            }
        }

        return data;
    }

    public static async Task<List<PizzaType>> ParseCsvFileToPizzaTypeAsync(string filePath)
    {
        var data = new List<PizzaType>();

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
                    data.Add(new PizzaType
                    {
                        Id = values[0],
                        Name = values[1],
                        Category = values[2],
                        Ingredients = values[3]
                    });
                }
            }
        }

        return data;
    }
}
