using CashflowNet.Server.Domain.Interfaces;
using FastEndpoints;

namespace CashflowNet.Server.Communication.Endpoints.BankAccounts.Get;

public class GetBankAccountsEndpoint(IBankAccountService bankAccountService) : EndpointWithoutRequest<IEnumerable<GetBankAccountsResponse>>
{
    public override void Configure()
    {
        Get("/bankaccounts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await bankAccountService.GetBankAccounts();

        await Send.OkAsync(result.Select(x => new GetBankAccountsResponse
        {
            Id = x.Id,
            Name = x.Name,
        }), cancellation: ct);
    }
}