using IokaPayment.General.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IokaPayment.Accounts.Extensions;

internal class ServiceCollection : IIokaService
{
    public void ConfigureServices(IServiceCollection services, Action<IokaPaymentConfiguration> configure)
    {
        services.AddScoped<IAccounts, IokaAccounts>();
    }
}