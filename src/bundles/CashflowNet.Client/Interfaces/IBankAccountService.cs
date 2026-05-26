using CashflowNet.Client.Communication.ViewModels;

namespace CashflowNet.Client.Interfaces;

public interface IBankAccountService
{
    public Task SetSelectedBankAccount(Guid? bankAccountId);
    public Task<Guid?> GetSelectedBankAccount();
}