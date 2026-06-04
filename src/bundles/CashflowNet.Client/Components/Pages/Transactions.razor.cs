using System.Text.Json;
using CashflowNet.Client.Communication.Scaffolds;
using CashflowNet.Client.Interfaces;
using CashflowNet.Shared.Enums;
using CashflowNet.Shared.RequestModels.Transactions;
using CashflowNet.Shared.ViewModels.Transactions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CashflowNet.Client.Components.Pages;

public partial class Transactions
{
    private MudTable<GetTransactionsViewModel> _transactionTable = null!;
    private GetTransactionsViewModel? _selectedTransaction;
    private GetTransactionsViewModel? _transactionBackup;

    private TableGroupDefinition<GetTransactionsViewModel>? _groupDefinition = new()
    {
        GroupName = "Group",
        Indentation = false,
        Expandable = false,
        Selector = (e) => e.Type
    };

    [Inject] private ICashflowApi CashflowApi { get; set; } = null!;
    [Inject] private IBankAccountService BankAccountService { get; set; } = null!;

    private async Task<TableData<GetTransactionsViewModel>> LoadTransactions(
        TableState state,
        CancellationToken cancellationToken)
    {
        var selectedBankAccountId = await BankAccountService.GetSelectedBankAccount();
        if (selectedBankAccountId == null)
        {
            // TODO: Handle gracefully & show toast
            return new TableData<GetTransactionsViewModel>
            {
                Items = new List<GetTransactionsViewModel>(),
                TotalItems = 0
            };
        }

        var incomeItems = await CashflowApi.GetTransactions(new GetTransactionsRequestModel
            {
                BankAccountId = selectedBankAccountId.Value
            }
        );

        return new TableData<GetTransactionsViewModel>
        {
            Items = incomeItems,
            TotalItems = incomeItems.Count
        };
    }

    private async Task CreateTransaction()
    {
        await CashflowApi.CreateTransaction(new CreateTransactionRequestModel
        {
            Name = "New income",
            Value = 2000,
            Currency = Currency.Euro,
            Type = TransactionType.Income,
            BankAccountId = (await BankAccountService.GetSelectedBankAccount()).Value,
        });

        await _transactionTable.ReloadServerData();
    }

    private async Task DeleteTransaction(GetTransactionsViewModel context)
    {
        await CashflowApi.DeleteTransaction(new DeleteTransactionRequestModel
        {
            TransactionId = context.Id
        });

        await _transactionTable.ReloadServerData();
    }

    // private async Task UpdateBankAccount()
    // {
    //     if (_selectedTransaction is null)
    //         return;
    //     
    //     await CashflowApi.UpdateBankAccount(new UpdateBankAccountViewModel
    //     {
    //         Id = _selectedTransaction.Id,
    //         Name = _selectedTransaction.Name
    //     });
    //
    //     await _transactionTable.ReloadServerData();
    // }
    //
    // private void PrepareBankAccountEdit(object? bankAccount)
    // {
    //     if (bankAccount is null)
    //         return;
    //
    //     _bankAccountBackup = new GetBankAccountsViewModel
    //     {
    //         Id = ((GetBankAccountsViewModel)bankAccount).Id,
    //         Name = ((GetBankAccountsViewModel)bankAccount).Name
    //     };
    // }
    //
    // private void ResetBankAccountEdit(object? bankAccount)
    // {
    //     if (bankAccount is null || _bankAccountBackup is null || _bankAccountBackup.Id != ((GetBankAccountsViewModel)bankAccount).Id)
    //         return;
    //     
    //     ((GetBankAccountsViewModel)bankAccount).Id = _bankAccountBackup.Id;
    //     ((GetBankAccountsViewModel)bankAccount).Name = _bankAccountBackup.Name;
    // }
}