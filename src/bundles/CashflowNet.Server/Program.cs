using CashflowNet.Server.Communication.Extensions;
using CashflowNet.Server.Domain.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomainLayer()
    .AddCommunicationLayer();

var app = builder.Build();

app.UseCommunicationLayer();

await app.RunAsync();
