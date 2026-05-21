using CashflowNet.Server.Domain.Dtos.BankAccounts;

namespace CashflowNet.Server.Domain.Interfaces;

public interface IBankAccountService
{
    public Task CreateBankAccount(CreateBankAccountDto bankAccount);
}