using CashflowNet.Client.Communication.Scaffolds;
using CashflowNet.Shared.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace CashflowNet.Client.Communication.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommunicationLayer(this IServiceCollection services)
    {
        var refitSettings = new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(CashflowJsonSerializerOptions.Options)
        };

        services.AddRefitClient<ICashflowApi>(refitSettings)
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:5237"));
        
        return services;
    }
}