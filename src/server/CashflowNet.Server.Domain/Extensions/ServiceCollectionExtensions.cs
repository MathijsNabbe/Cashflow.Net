using CashflowNet.Server.Domain.Interfaces;
using CashflowNet.Server.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CashflowNet.Server.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainLayer(this IServiceCollection services)
    {
        services.AddScoped<IBankAccountService, BankAccountService>();
        
        return services;
    }
}