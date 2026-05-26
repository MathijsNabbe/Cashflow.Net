using CashflowNet.Server.Communication.Endpoints.BankAccounts.Create;
using CashflowNet.Server.Domain.Dtos.BankAccounts;
using CashflowNet.Server.Domain.Interfaces;
using FastEndpoints;

namespace CashflowNet.Server.Communication.Endpoints.BankAccounts.Update;

public class UpdateBankAccountEndpoint(IBankAccountService bankAccountService) : Endpoint<UpdateBankAccountRequest>
{
    public override void Configure()
    {
        Put("/bankaccounts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateBankAccountRequest request, CancellationToken ct)
    {
        await bankAccountService.UpdateBankAccount(new UpdateBankAccountDto
        {
            Id = request.Id,
            Name = request.Name
        });

        await Send.OkAsync(cancellation: ct);
    }
}