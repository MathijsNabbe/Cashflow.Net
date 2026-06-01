using CashflowNet.Server.Domain.Interfaces;
using CashflowNet.Shared.RequestModels.BankAccounts;
using FastEndpoints;

namespace CashflowNet.Server.Communication.Endpoints.BankAccounts;

public class CreateBankAccountEndpoint(IBankAccountService bankAccountService) : Endpoint<CreateBankAccountRequestModel>
{
    public override void Configure()
    {
        Post("/bankaccounts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateBankAccountRequestModel requestModel, CancellationToken ct)
    {
        await bankAccountService.CreateBankAccount(new Domain.Dtos.BankAccounts.CreateBankAccountDto
        {
            Name = requestModel.Name
        });

        await Send.OkAsync(cancellation: ct);
    }
}