using IokaPayment.Accounts;
using IokaPayment.Client.Configurations;
using IokaPayment.General.Configuration;
using IokaPayment.Orders;
using IokaPayment.Payments;
using IokaPayment.Refunds;
using IokaPayment.Subscriptions;
using Microsoft.Extensions.DependencyInjection;

namespace IokaPayment.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIokaPaymentClient(this IServiceCollection services, Action<IokaPaymentConfiguration> configure)
    {
        var configuration = new IokaPaymentConfiguration();
        configure(configuration);
        services.AddTransient<IokaConfiguration>(_ => new IokaConfiguration
        {
            ApiKey = configuration.ApiKey,
            Environment = configuration.Environment
        });
        services.AddScoped<IAccounts, IokaAccounts>();
        services.AddScoped<IOrders, IokaOrders>();
        services.AddScoped<IPayments, IokaPayments>();
        services.AddScoped<IRefunds, IokaRefunds>();
        services.AddScoped<ISubscriptions, IokaSubscriptions>();
        return services;
    }
}