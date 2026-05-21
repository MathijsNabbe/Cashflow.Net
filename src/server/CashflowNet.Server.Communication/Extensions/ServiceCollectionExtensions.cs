using FastEndpoints;
using Microsoft.Extensions.DependencyInjection;

namespace CashflowNet.Server.Communication.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommunicationLayer(this IServiceCollection services)
    {
        services.AddFastEndpoints();
        
        return services;
    }
}