using IokaPayment.General.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IokaPayment.General.Extensions;

public class ServiceCollection : IIokaService
{
    public void ConfigureServices(IServiceCollection services, Action<IokaPaymentConfiguration> configure)
    {
        var configuration = new IokaPaymentConfiguration();
        configure(configuration);
        services.AddTransient<IokaConfiguration>(_ => new IokaConfiguration
        {
            ApiKey = configuration.ApiKey,
            Environment = configuration.Environment
        });
    }
}