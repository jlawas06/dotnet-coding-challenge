using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Reflection;

namespace PizzaXYZ.Backend.Infrastructure.Services;
internal class BulkInsertService<T>(AppDbContext context) : IBulkInsertService<T> where T : class
{
    public async Task BulkInsertAsync(IList<T> entities, string tableName)
    {
        using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            var connection = context.Database.GetDbConnection();

            using var bulkCopy = new SqlBulkCopy((SqlConnection)connection, SqlBulkCopyOptions.Default, (SqlTransaction)transaction.GetDbTransaction());
            bulkCopy.DestinationTableName = tableName;
            bulkCopy.BatchSize = 1000;

            var dataTable = ToDataTable(entities);
            await bulkCopy.WriteToServerAsync(dataTable);

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    private static DataTable ToDataTable(IList<T> items)
    {
        var dataTable = new DataTable(typeof(T).Name);
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties)
        {
            dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
        }

        foreach (var item in items)
        {
            var values = new object[properties.Length];
            for (var i = 0; i < properties.Length; i++)
            {
                values[i] = properties[i].GetValue(item, null)!;
            }
            dataTable.Rows.Add(values);
        }

        return dataTable;
    }
}
