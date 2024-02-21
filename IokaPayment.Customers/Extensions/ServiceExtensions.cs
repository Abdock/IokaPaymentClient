using IokaPayment.General.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IokaPayment.Customers.Extensions;

public class ServiceExtensions : IIokaService
{
    public void ConfigureServices(IServiceCollection services, Action<IokaPaymentConfiguration> configure)
    {
        services.AddScoped<ICustomers, IokaCustomers>();
    }
}