using FastEndpoints;
using Microsoft.AspNetCore.Builder;

namespace CashflowNet.Server.Communication.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseCommunicationLayer(this WebApplication app)
    {
        app.UseFastEndpoints();
        
        return app;
    }
}