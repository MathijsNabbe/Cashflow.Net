using CashflowNet.Client.Interfaces;
using Microsoft.JSInterop;

namespace CashflowNet.Client.Services;

public class BankAccountService(ILocalStorageService localStorageService) : IBankAccountService
{
    private const string StorageKey = "selected-bank-account-id";

    private Guid? _selectedBankAccountId;
    
    public async Task SetSelectedBankAccount(Guid? bankAccountId)
    {
        _selectedBankAccountId = bankAccountId;
        
        if (bankAccountId is null)
        {
            await localStorageService.RemoveItemAsync(StorageKey);
            return;
        }

        await localStorageService.SetItemAsync(StorageKey, bankAccountId);
    }
    
    public async Task<Guid?> GetSelectedBankAccount()
    {
        if (_selectedBankAccountId is not null)
            return _selectedBankAccountId;

        _selectedBankAccountId = await localStorageService.GetItemAsync<Guid>(StorageKey);

        return _selectedBankAccountId;
    }
}