using PizzaXYZ.Backend.Domain.Enumerations;

namespace PizzaXYZ.Backend.Application.Dtos;

public class DailySalesReport
{
    public string? PizzaName { get; set; }
    public int TotalQuantity { get; set; }
    public decimal TotalRevenue { get; set; }
}

public class MonthlySalesReport
{
    public string? PizzaName { get; set; }
    public int TotalQuantity { get; set; }
    public decimal TotalRevenue { get; set; }
}

public class TopSellingPizza
{
    public string? PizzaName { get; set; }
    public int TotalQuantity { get; set; }
}

public class SalesByCategory
{
    public string? Category { get; set; }
    public int TotalQuantity { get; set; }
    public decimal TotalRevenue { get; set; }
}

public class SalesBySize
{
    public PizzaSize Size { get; set; }
    public int TotalQuantity { get; set; }
    public decimal TotalRevenue { get; set; }
}
