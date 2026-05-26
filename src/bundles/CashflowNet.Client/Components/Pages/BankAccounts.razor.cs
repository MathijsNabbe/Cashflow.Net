using CashflowNet.Client.Communication.Scaffolds;
using CashflowNet.Client.Communication.ViewModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CashflowNet.Client.Components.Pages;

public partial class BankAccounts
{
    private MudTable<GetBankAccountsViewModel> _bankAccountsTable = null!;
    
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
}