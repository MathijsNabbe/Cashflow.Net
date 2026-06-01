using CashflowNet.Server.Communication.Endpoints.BankAccounts.Get;
using CashflowNet.Server.Domain.Interfaces;
using CashflowNet.Shared.Enums;
using CashflowNet.Shared.RequestModels.Transactions;
using CashflowNet.Shared.ViewModels.Transactions;
using FastEndpoints;

namespace CashflowNet.Server.Communication.Endpoints.Transactions;

public class GetTransactionsByBankAccountEndpoint(ITransactionService transactionService) : 
    Endpoint<GetTransactionsRequest, IEnumerable<GetTransactionsViewModel>>
{
    public override void Configure()
    {
        Get("/transactions");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetTransactionsRequest request, CancellationToken ct)
    {
        var result = transactionService.GetTransactions(request.BankAccountId);

        await Send.OkAsync(result.Select(x => new GetTransactionsViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Value = x.Value,
            Currency = x.Currency,
            Type = x.Type,
            BankAccountId = x.BankAccountId,
            TargetBankAccountId = x.TargetBankAccountId
        }), cancellation: ct);
    }
}