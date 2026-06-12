using System.Text.Json;
using CashflowNet.Client.Communication.Scaffolds;
using CashflowNet.Client.Interfaces;
using CashflowNet.Shared.Enums;
using CashflowNet.Shared.RequestModels.Transactions;
using CashflowNet.Shared.ViewModels.BankAccounts;
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
    [Inject] private ISnackbar Snackbar { get; set; } = null!;

    private List<GetBankAccountsViewModel> _availableBankAccounts = new();

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

        _availableBankAccounts = await CashflowApi.GetBankAccounts();

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

    private async Task UpdateTransaction()
    {
        if (_selectedTransaction is null)
            return;

        await CashflowApi.UpdateTransaction(new UpdateTransactionRequestModel
        {
            Id = _selectedTransaction.Id,
            Name = _selectedTransaction.Name,
            Value = _selectedTransaction.Value,
            Currency = _selectedTransaction.Currency,
            StartDate = _selectedTransaction.StartDate,
            Type = _selectedTransaction.Type,
            BankAccountId = _selectedTransaction.BankAccount.Id,
            TargetBankAccountId = _selectedTransaction.TargetBankAccount?.Id
        });

        await _transactionTable.ReloadServerData();
        
        Snackbar.Add("Transaction updated", Severity.Success);
    }

    private void PrepareTransactionEdit(object? transaction)
    {
        if (transaction is null)
            return;

        var t = (GetTransactionsViewModel)transaction;
        _transactionBackup = new GetTransactionsViewModel
        {
            Id = t.Id,
            Name = t.Name,
            Value = t.Value,
            Currency = t.Currency,
            StartDate = t.StartDate,
            Type = t.Type,
            BankAccount = t.BankAccount,
            TargetBankAccount = t.TargetBankAccount
        };
    }

    private void ResetTransactionEdit(object? transaction)
    {
        if (transaction is null || _transactionBackup is null || _transactionBackup.Id != ((GetTransactionsViewModel)transaction).Id)
            return;
        
        ((GetTransactionsViewModel)transaction).Name = _transactionBackup.Name;
        ((GetTransactionsViewModel)transaction).Value = _transactionBackup.Value;
        ((GetTransactionsViewModel)transaction).Currency = _transactionBackup.Currency;
        ((GetTransactionsViewModel)transaction).StartDate = _transactionBackup.StartDate;
        ((GetTransactionsViewModel)transaction).Type = _transactionBackup.Type;
        ((GetTransactionsViewModel)transaction).BankAccount = _transactionBackup.BankAccount;
        ((GetTransactionsViewModel)transaction).TargetBankAccount = _transactionBackup.TargetBankAccount;
    }
}