using System.Reflection;
using IokaPayment.General.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IokaPayment.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIokaPaymentClient(this IServiceCollection services, Action<IokaPaymentConfiguration> configure)
    {
        services.AddHttpClient();
        var assemblies = new[]
        {
            Assembly.Load("IokaPayment.General"), Assembly.Load("IokaPayment.Orders"),
            Assembly.Load("IokaPayment.Payments"), Assembly.Load("IokaPayment.Refunds"),
            Assembly.Load("IokaPayment.Subscriptions"), Assembly.Load("IokaPayment.Customers"), 
        };
        var iokaServices = assemblies
            .SelectMany(e=>e.DefinedTypes)
            .Where(e => e.IsAssignableTo(typeof(IIokaService)) && e is { IsAbstract: false, IsInterface: false })
            .Select(Activator.CreateInstance)
            .Cast<IIokaService>()
            .ToList();
        foreach (var iokaService in iokaServices)
        {
            iokaService.ConfigureServices(services, configure);
        }

        return services;
    }
}