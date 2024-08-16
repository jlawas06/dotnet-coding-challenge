using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace PizzaXYZ.Backend.Infrastructure.Services;
internal class BulkInsertService(AppDbContext context) : IBulkInsertService
{
    public async Task BulkInsertAsync<T>(IList<T> entities, string tableName)
    {
        using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            var connection = context.Database.GetDbConnection();

            using var bulkCopy = new SqlBulkCopy((SqlConnection)connection, SqlBulkCopyOptions.Default, (SqlTransaction)transaction.GetDbTransaction());
            bulkCopy.DestinationTableName = tableName;
            bulkCopy.BatchSize = 1000;

            var dataTable = CreateDataTable(entities);
            dataTable.TableName = tableName;

            foreach (DataColumn column in dataTable.Columns)
            {
                bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
            }

            await bulkCopy.WriteToServerAsync(dataTable);

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    private static DataTable CreateDataTable<T>(IEnumerable<T> data)
    {
        var dataTable = new DataTable();
        var properties = typeof(T).GetProperties()
            .Where(p => p.PropertyType.IsValueType || p.PropertyType == typeof(string))
            .ToList();

        foreach (var prop in properties)
        {
            dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        }

        foreach (var item in data)
        {
            var row = dataTable.NewRow();
            foreach (var prop in properties)
            {
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            }
            dataTable.Rows.Add(row);
        }

        return dataTable;
    }
}
