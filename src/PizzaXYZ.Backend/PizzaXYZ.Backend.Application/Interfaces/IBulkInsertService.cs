namespace PizzaXYZ.Backend.Application.Interfaces;
public interface IBulkInsertService<T> where T : class
{
    Task BulkInsertAsync(IList<T> entities, string tableName);
}
