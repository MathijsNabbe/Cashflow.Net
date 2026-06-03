using CashflowNet.Server.Domain.Interfaces;
using CashflowNet.Shared.RequestModels.BankAccounts;
using CashflowNet.Shared.ViewModels.BankAccounts;
using FastEndpoints;

namespace CashflowNet.Server.Communication.Endpoints.BankAccounts;

public class CreateBankAccountEndpoint(IBankAccountService bankAccountService) : Endpoint<CreateBankAccountRequestModel, GetBankAccountsViewModel>
{
    public override void Configure()
    {
        Post("/bankaccounts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateBankAccountRequestModel requestModel, CancellationToken ct)
    {
        var result = await bankAccountService.CreateBankAccount(new Domain.Dtos.BankAccounts.CreateBankAccountDto
        {
            Name = requestModel.Name
        });

        await Send.OkAsync(new GetBankAccountsViewModel
        {
            Id = result.Id,
            Name = result.Name
        }, cancellation: ct);
    }
}