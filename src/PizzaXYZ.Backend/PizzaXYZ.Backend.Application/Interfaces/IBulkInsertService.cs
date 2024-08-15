namespace PizzaXYZ.Backend.Application.Interfaces;
public interface IBulkInsertService
{
    Task BulkInsertAsync<T>(IList<T> entities, string tableName);
}
