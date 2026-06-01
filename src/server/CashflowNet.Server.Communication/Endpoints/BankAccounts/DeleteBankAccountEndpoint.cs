using CashflowNet.Server.Domain.Interfaces;
using CashflowNet.Shared.RequestModels.BankAccounts;
using FastEndpoints;

namespace CashflowNet.Server.Communication.Endpoints.BankAccounts;

public class DeleteBankAccountEndpoint(IBankAccountService bankAccountService) : Endpoint<DeleteBankAccountRequestModel>
{
    public override void Configure()
    {
        Delete("/bankaccounts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteBankAccountRequestModel bankAccount, CancellationToken ct)
    {
        await bankAccountService.DeleteBankAccount(bankAccount.Id);

        await Send.OkAsync(cancellation: ct);
    }
}