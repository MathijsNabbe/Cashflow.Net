using CashflowNet.Shared.Serialization;
using FastEndpoints;
using Microsoft.AspNetCore.Builder;

namespace CashflowNet.Server.Communication.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseCommunicationLayer(this WebApplication app)
    {
        app.UseFastEndpoints(options =>
            CashflowJsonSerializerOptions.ApplyTo(options.Serializer.Options));
        
        return app;
    }
}