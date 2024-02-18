using IokaPayment.General.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IokaPayment.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIokaPaymentClient(this IServiceCollection services, Action<IokaPaymentConfiguration> configure)
    {
        services.AddHttpClient();
        var iokaServices = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(e => e.DefinedTypes)
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