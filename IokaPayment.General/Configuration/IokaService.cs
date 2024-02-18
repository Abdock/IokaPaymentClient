using Microsoft.Extensions.DependencyInjection;

namespace IokaPayment.General.Configuration;

public interface IIokaService
{
    void ConfigureServices(IServiceCollection services, Action<IokaPaymentConfiguration> configure);
}