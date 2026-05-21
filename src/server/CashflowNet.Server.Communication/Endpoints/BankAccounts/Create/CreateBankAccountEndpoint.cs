using CashflowNet.Server.Domain.Dtos.BankAccounts;
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
        await bankAccountService.CreateBankAccount(new CreateBankAccountDto
        {
            Name = request.Name,
            Iban = request.Iban
        });

        await Send.OkAsync(cancellation: ct);
    }
}