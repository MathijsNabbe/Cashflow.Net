using CashflowNet.Client.Communication.Scaffolds;
using CashflowNet.Client.Communication.ViewModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CashflowNet.Client.Components.Pages;

public partial class BankAccounts
{
    private MudTable<GetBankAccountsViewModel> _bankAccountsTable = null!;
    private GetBankAccountsViewModel? _selectedBankAccount;
    private GetBankAccountsViewModel? _bankAccountBackup;

    [Inject] private ICashflowApi CashflowApi { get; set; } = null!;

    private async Task<TableData<GetBankAccountsViewModel>> LoadBankAccounts(
        TableState state,
        CancellationToken cancellationToken)
    {
        var bankAccounts = await CashflowApi.GetBankAccounts();

        return new TableData<GetBankAccountsViewModel>
        {
            Items = bankAccounts,
            TotalItems = bankAccounts.Count
        };
    }

    private async Task CreateBankAccount()
    {
        await CashflowApi.CreateBankAccount(new CreateBankAccountViewModel
        {
            Name = "New Bank Account"
        });

        await _bankAccountsTable.ReloadServerData();
    }

    private async Task DeleteBankAccount(GetBankAccountsViewModel context)
    {
        await CashflowApi.DeleteBankAccount(new DeleteBankAccountViewModel
        {
            Id = context.Id
        });
        
        await _bankAccountsTable.ReloadServerData();
    }

    private async Task UpdateBankAccount()
    {
        if (_selectedBankAccount is null)
            return;
        
        await CashflowApi.UpdateBankAccount(new UpdateBankAccountViewModel
        {
            Id = _selectedBankAccount.Id,
            Name = _selectedBankAccount.Name
        });

        await _bankAccountsTable.ReloadServerData();
    }

    private void PrepareBankAccountEdit(object? bankAccount)
    {
        if (bankAccount is null)
            return;

        _bankAccountBackup = new GetBankAccountsViewModel
        {
            Id = ((GetBankAccountsViewModel)bankAccount).Id,
            Name = ((GetBankAccountsViewModel)bankAccount).Name
        };
    }

    private void ResetBankAccountEdit(object? bankAccount)
    {
        if (bankAccount is null || _bankAccountBackup is null || _bankAccountBackup.Id != ((GetBankAccountsViewModel)bankAccount).Id)
            return;
        
        ((GetBankAccountsViewModel)bankAccount).Id = _bankAccountBackup.Id;
        ((GetBankAccountsViewModel)bankAccount).Name = _bankAccountBackup.Name;
    }
}