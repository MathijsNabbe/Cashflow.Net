using CashflowNet.Server.Domain.Interfaces;
using FastEndpoints;

namespace CashflowNet.Server.Communication.Endpoints.BankAccounts.Create;

public class CreateBankAccountEndpoint(IBankAccountService bankAccountService) : Endpoint<CreateBankAccountRequest>
{
    public override void Configure()
    {
        Post("/bankaccounts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateBankAccountRequest request, CancellationToken ct)
    {
        await bankAccountService.CreateBankAccount(new Domain.Dtos.BankAccounts.CreateBankAccountDto
        {
            Name = request.Name
        });

        await Send.OkAsync(cancellation: ct);
    }
}