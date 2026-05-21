using CashflowNet.Server.Domain.Dtos.BankAccounts;
using CashflowNet.Server.Domain.Entities;
using CashflowNet.Server.Domain.Interfaces;

namespace CashflowNet.Server.Domain.Services;

public class BankAccountService : IBankAccountService
{
    private readonly CashflowDbContext _dbContext = new();
    
    public async Task CreateBankAccount(CreateBankAccountDto bankAccount)
    {
        _dbContext.BankAccounts.Add(new BankAccount
        {
            Id = Guid.NewGuid(),
            Name = bankAccount.Name,
            Iban = bankAccount.Iban
        });
        
        await _dbContext.SaveChangesAsync();
    }
}