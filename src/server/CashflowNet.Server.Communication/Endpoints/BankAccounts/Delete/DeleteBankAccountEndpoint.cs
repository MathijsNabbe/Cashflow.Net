using CashflowNet.Server.Domain.Interfaces;
using FastEndpoints;

namespace CashflowNet.Server.Communication.Endpoints.BankAccounts.Delete;

public class DeleteBankAccountEndpoint(IBankAccountService bankAccountService) : Endpoint<DeleteBankAccountRequest>
{
    public override void Configure()
    {
        Delete("/bankaccounts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteBankAccountRequest bankAccount, CancellationToken ct)
    {
        await bankAccountService.DeleteBankAccount(bankAccount.Id);

        await Send.OkAsync(cancellation: ct);
    }
}