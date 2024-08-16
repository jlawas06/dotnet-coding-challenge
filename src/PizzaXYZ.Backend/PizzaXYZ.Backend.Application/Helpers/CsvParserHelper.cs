using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

namespace PizzaXYZ.Backend.Application.Helpers;
public static class CsvParserHelper
{
    public static IEnumerable<T> Parse<T>(string filePath)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        };

        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, config);
        return csv.GetRecords<T>().ToList();
    }
}