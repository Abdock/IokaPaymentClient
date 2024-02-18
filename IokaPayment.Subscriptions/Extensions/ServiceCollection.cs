using Microsoft.Extensions.DependencyInjection;

namespace IokaPayment.Subscriptions.Extensions;

public class ServiceCollection : IIokaService
{
    public void ConfigureServices(IServiceCollection services, Action<IokaPaymentConfiguration> configure)
    {
        services.AddScoped<ISubscriptions, IokaSubscriptions>();
    }
}