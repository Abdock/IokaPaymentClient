using Microsoft.Extensions.DependencyInjection;

namespace IokaPayment.Refunds.Extensions;

public class ServiceCollection : IIokaService
{
    public void ConfigureServices(IServiceCollection services, Action<IokaPaymentConfiguration> configure)
    {
        services.AddScoped<IRefunds, IokaRefunds>();
    }
}