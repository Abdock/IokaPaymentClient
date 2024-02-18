using Microsoft.Extensions.DependencyInjection;

namespace IokaPayment.Payments.Extensions;

public class ServiceCollection : IIokaService
{
    public void ConfigureServices(IServiceCollection services, Action<IokaPaymentConfiguration> configure)
    {
        services.AddScoped<IPayments, IokaPayments>();
    }
}