using CashflowNet.Client.Interfaces;
using CashflowNet.Client.Services;

namespace CashflowNet.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUILayer(this IServiceCollection services)
    {
        services.AddScoped<IBankAccountService, BankAccountService>();

        services.AddLocalStorageServices();
        
        return services;
    }
}