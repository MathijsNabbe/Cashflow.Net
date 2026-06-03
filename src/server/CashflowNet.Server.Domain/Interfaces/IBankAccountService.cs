using CashflowNet.Server.Domain.Dtos.BankAccounts;

namespace CashflowNet.Server.Domain.Interfaces;

public interface IBankAccountService
{
    public Task<GetBankAccountsDto> CreateBankAccount(CreateBankAccountDto bankAccount);
    public Task<List<GetBankAccountsDto>> GetBankAccounts();
    public Task DeleteBankAccount(Guid id);
    public Task UpdateBankAccount(UpdateBankAccountDto bankAccount);
}