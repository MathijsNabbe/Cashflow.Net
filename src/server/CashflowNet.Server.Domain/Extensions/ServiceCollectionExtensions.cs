using CashflowNet.Server.Domain.Interfaces;
using CashflowNet.Server.Domain.Services;
using CashflowNet.Server.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace CashflowNet.Server.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainLayer(this IServiceCollection services)
    {
        services
            .AddDbContext<CashflowDbContext>()
            .AddScoped<IBankAccountService, BankAccountService>()
            .AddScoped<ITransactionService, TransactionService>();
        
        return services;
    }
}