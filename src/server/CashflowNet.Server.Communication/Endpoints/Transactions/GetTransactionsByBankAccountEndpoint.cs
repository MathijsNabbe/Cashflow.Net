using CashflowNet.Server.Domain.Interfaces;
using CashflowNet.Shared.RequestModels.Transactions;
using CashflowNet.Shared.ViewModels.BankAccounts;
using CashflowNet.Shared.ViewModels.Transactions;
using FastEndpoints;

namespace CashflowNet.Server.Communication.Endpoints.Transactions;

public class GetTransactionsByBankAccountEndpoint(ITransactionService transactionService) :
    Endpoint<GetTransactionsRequestModel, IEnumerable<GetTransactionsViewModel>>
{
    public override void Configure()
    {
        Get("/transactions");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetTransactionsRequestModel request, CancellationToken ct)
    {
        var result = transactionService.GetTransactions(request.BankAccountId);

        await Send.OkAsync(result.Select(x => new GetTransactionsViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Value = x.Value,
            Currency = x.Currency,
            StartDate = x.StartDate,
            Type = x.Type,
            Interval = x.Interval,
            BankAccount = new GetBankAccountsViewModel
            {
                Id = x.BankAccount.Id,
                Name = x.BankAccount.Name
            },
            TargetBankAccount =
                x.TargetBankAccount != null
                    ? new GetBankAccountsViewModel
                    {
                        Id = x.TargetBankAccount.Id,
                        Name = x.TargetBankAccount.Name
                    }
                    : null
        }), cancellation: ct);
    }
}