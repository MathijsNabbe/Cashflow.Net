using CashflowNet.Server.Communication.Extensions;
using CashflowNet.Server.Domain;
using CashflowNet.Server.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomainLayer()
    .AddCommunicationLayer();

var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CashflowDbContext>();
    await dbContext.Database.MigrateAsync();
}

app.UseCommunicationLayer();

await app.RunAsync();
