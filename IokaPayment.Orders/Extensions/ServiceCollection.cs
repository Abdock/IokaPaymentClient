using Microsoft.Extensions.DependencyInjection;

namespace IokaPayment.Orders.Extensions;

public class ServiceCollection : IIokaService
{
    public void ConfigureServices(IServiceCollection services, Action<IokaPaymentConfiguration> configure)
    {
        
        services.AddScoped<IOrders, IokaOrders>();
    }
}