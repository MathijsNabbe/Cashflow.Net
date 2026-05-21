using CashflowNet.Client.Communication.Scaffolds;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace CashflowNet.Client.Communication.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommunicationLayer(this IServiceCollection services)
    {
        services.AddRefitClient<ICashflowApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:5237"));
        
        return services;
    }
}