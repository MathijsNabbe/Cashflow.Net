using CashflowNet.Server.Domain.Interfaces;
using CashflowNet.Shared.RequestModels.BankAccounts;
using FastEndpoints;

namespace CashflowNet.Server.Communication.Endpoints.BankAccounts;

public class UpdateBankAccountEndpoint(IBankAccountService bankAccountService) : Endpoint<UpdateBankAccountRequestModel>
{
    public override void Configure()
    {
        Put("/bankaccounts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateBankAccountRequestModel requestModel, CancellationToken ct)
    {
        await bankAccountService.UpdateBankAccount(new Domain.Dtos.BankAccounts.UpdateBankAccountDto
        {
            Id = requestModel.Id,
            Name = requestModel.Name
        });

        await Send.OkAsync(cancellation: ct);
    }
}