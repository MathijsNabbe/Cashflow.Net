using CashflowNet.Client.Communication.Scaffolds;
using CashflowNet.Client.Communication.ViewModels;
using Microsoft.AspNetCore.Components;

namespace CashflowNet.Client.Components.Pages;

public partial class BankAccounts
{
    private IEnumerable<GetBankAccountsViewModel>? _bankAccounts;
    
    [Inject] private ICashflowApi CashflowApi { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        _bankAccounts = await CashflowApi.GetBankAccounts();
    }

    private async Task CreateBankAccount()
    {
        await CashflowApi.CreateBankAccount(new CreateBankAccountViewModel
        {
            Name = "New Bank Account",
            Iban = "DE12345678901234567890"
        });
    }

    private async Task DeleteBankAccount(GetBankAccountsViewModel context)
    {
        await CashflowApi.DeleteBankAccount(new DeleteBankAccountViewModel
        {
            Id = context.Id
        });
    }
}