using CashflowNet.Server.Domain.Dtos.Transactions;
using CashflowNet.Server.Domain.Interfaces;
using CashflowNet.Shared.RequestModels.Transactions;
using FastEndpoints;

namespace CashflowNet.Server.Communication.Endpoints.Transactions;

public class UpdateTransactionEndpoint(ITransactionService transactionService) : Endpoint<UpdateTransactionRequestModel>
{
    public override void Configure()
    {
        Put("/transactions");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateTransactionRequestModel request, CancellationToken ct)
    {
        await transactionService.UpdateTransaction(new UpdateTransactionDto
        {
            Id = request.Id,
            Name = request.Name,
            Value = request.Value,
            Currency = request.Currency,
            StartDate = request.StartDate,
            Type = request.Type,
            BankAccountId = request.BankAccountId,
            TargetBankAccountId = request.TargetBankAccountId
        });

        await Send.OkAsync(cancellation: ct);
    }
}
