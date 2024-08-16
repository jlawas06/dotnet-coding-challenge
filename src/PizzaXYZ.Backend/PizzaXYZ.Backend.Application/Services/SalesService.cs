namespace PizzaXYZ.Backend.Application.Services;
internal class SalesService(IAppDbContext context) : ISalesService
{
    public async Task<IEnumerable<DailySalesReport>> GetDailySalesReportAsync(DateOnly date)
    {
        return await context.Orders
            .Where(o => o.Date == date)
            .SelectMany(o => o.OrderDetails)
            .GroupBy(od => od.Pizza.PizzaType.Name)
            .Select(g => new DailySalesReport
            {
                PizzaName = g.Key,
                TotalQuantity = g.Sum(od => od.Quantity),
                TotalRevenue = g.Sum(od => od.Quantity * od.Pizza.Price)
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<MonthlySalesReport>> GetMonthlySalesReportAsync(int year, int month)
    {
        return await context.Orders
            .Where(o => o.Date.Year == year && o.Date.Month == month)
            .SelectMany(o => o.OrderDetails)
            .GroupBy(od => od.Pizza.PizzaType.Name)
            .Select(g => new MonthlySalesReport
            {
                PizzaName = g.Key,
                TotalQuantity = g.Sum(od => od.Quantity),
                TotalRevenue = g.Sum(od => od.Quantity * od.Pizza.Price)
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<TopSellingPizza>> GetTopSellingPizzasAsync(int top)
    {
        return await context.OrderDetails
            .GroupBy(od => od.Pizza.PizzaType.Name)
            .Select(g => new TopSellingPizza
            {
                PizzaName = g.Key,
                TotalQuantity = g.Sum(od => od.Quantity)
            })
            .OrderByDescending(x => x.TotalQuantity)
            .Take(top)
            .ToListAsync();
    }

    public async Task<IEnumerable<SalesByCategory>> GetSalesByCategoryAsync()
    {
        return await context.OrderDetails
            .GroupBy(od => od.Pizza.PizzaType.Category)
            .Select(g => new SalesByCategory
            {
                Category = g.Key,
                TotalQuantity = g.Sum(od => od.Quantity),
                TotalRevenue = g.Sum(od => od.Quantity * od.Pizza.Price)
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<SalesBySize>> GetSalesBySizeAsync()
    {
        return await context.OrderDetails
            .GroupBy(od => od.Pizza.Size)
            .Select(g => new SalesBySize
            {
                Size = g.Key,
                TotalQuantity = g.Sum(od => od.Quantity),
                TotalRevenue = g.Sum(od => od.Quantity * od.Pizza.Price)
            })
            .ToListAsync();
    }
}
