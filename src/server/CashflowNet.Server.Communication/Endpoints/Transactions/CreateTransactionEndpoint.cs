using CashflowNet.Server.Domain.Dtos.Transactions;
using CashflowNet.Server.Domain.Interfaces;
using CashflowNet.Shared.RequestModels.Transactions;
using FastEndpoints;

namespace CashflowNet.Server.Communication.Endpoints.Transactions;

public class CreateTransactionEndpoint(ITransactionService transactionService) : Endpoint<CreateTransactionRequestModel>
{
    public override void Configure()
    {
        Post("/transactions");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateTransactionRequestModel request, CancellationToken ct)
    {
        await transactionService.CreateTransaction(new CreateTransactionDto
        {
            Name = request.Name,
            Value = request.Value,
            Currency = request.Currency,
            Type = request.Type,
            StartDate = request.StartDate,
            BankAccountId = request.BankAccountId,
            TargetBankAccountId = request.TargetBankAccountId
        });

        await Send.OkAsync(cancellation: ct);
    }
}