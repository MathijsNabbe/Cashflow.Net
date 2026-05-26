using CashflowNet.Client.Communication.Scaffolds;
using CashflowNet.Client.Communication.ViewModels;
using CashflowNet.Client.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CashflowNet.Client.Components.Layout;

public partial class HeaderBar
{
    private IEnumerable<GetBankAccountsViewModel> _bankAccounts = [];
    private GetBankAccountsViewModel? _selectedBankAccount;

    [Inject] private ICashflowApi CashflowApi { get; set; } = null!;
    [Inject] private IBankAccountService BankAccountService { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        _bankAccounts = await CashflowApi.GetBankAccounts();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
            return;

        var persistedId = await BankAccountService.GetSelectedBankAccount();
        _selectedBankAccount = _bankAccounts.FirstOrDefault(x => x.Id == persistedId);

        StateHasChanged();
    }

    private async Task OnBankAccountChanged(GetBankAccountsViewModel bankAccount)
    {
        _selectedBankAccount = bankAccount;
        
        await BankAccountService.SetSelectedBankAccount(bankAccount.Id);
    }
}