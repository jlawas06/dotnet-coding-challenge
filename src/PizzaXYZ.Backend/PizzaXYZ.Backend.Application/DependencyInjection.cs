using Microsoft.Extensions.DependencyInjection;

namespace PizzaXYZ.Backend.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddAutoMapper(assembly);
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly)
        );

        services.AddServices();

        return services;
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPizzaService, PizzaService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ISalesService, SalesService>();
    }
}
