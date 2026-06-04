using CashflowNet.Server.Domain.Interfaces;
using CashflowNet.Shared.RequestModels.Transactions;
using FastEndpoints;

namespace CashflowNet.Server.Communication.Endpoints.Transactions;

public class DeleteTransactionEndpoint(ITransactionService transactionService) : Endpoint<DeleteTransactionRequestModel>
{
    public override void Configure()
    {
        Delete("/transactions");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteTransactionRequestModel transaction, CancellationToken ct)
    {
        await transactionService.DeleteTransaction(transaction.TransactionId);

        await Send.OkAsync(cancellation: ct);
    }
}