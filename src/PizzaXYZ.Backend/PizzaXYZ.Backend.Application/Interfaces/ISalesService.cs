namespace PizzaXYZ.Backend.Application.Interfaces;
public interface ISalesService
{
    Task<IEnumerable<DailySalesReport>> GetDailySalesReportAsync(DateOnly date);
    Task<IEnumerable<MonthlySalesReport>> GetMonthlySalesReportAsync(int year, int month);
    Task<IEnumerable<TopSellingPizza>> GetTopSellingPizzasAsync(int top);
    Task<IEnumerable<SalesByCategory>> GetSalesByCategoryAsync();
    Task<IEnumerable<SalesBySize>> GetSalesBySizeAsync();

}
