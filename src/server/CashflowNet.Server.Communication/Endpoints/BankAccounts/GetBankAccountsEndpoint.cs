using CashflowNet.Server.Domain.Interfaces;
using CashflowNet.Shared.ViewModels.BankAccounts;
using FastEndpoints;

namespace CashflowNet.Server.Communication.Endpoints.BankAccounts;

public class GetBankAccountsEndpoint(IBankAccountService bankAccountService) : EndpointWithoutRequest<IEnumerable<GetBankAccountsViewModel>>
{
    public override void Configure()
    {
        Get("/bankaccounts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await bankAccountService.GetBankAccounts();

        await Send.OkAsync(result.Select(x => new GetBankAccountsViewModel
        {
            Id = x.Id,
            Name = x.Name,
        }), cancellation: ct);
    }
}