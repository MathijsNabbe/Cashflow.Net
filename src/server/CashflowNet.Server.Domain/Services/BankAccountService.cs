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
    
    public async Task<List<GetBankAccountsDto>> GetBankAccounts()
    {
        return _dbContext.BankAccounts.Select(x => new GetBankAccountsDto
        {
            Id = x.Id,
            Name = x.Name,
            Iban = x.Iban
        }).ToList();
    }
    
    public async Task DeleteBankAccount(Guid id)
    {
        _dbContext.BankAccounts.Remove(_dbContext.BankAccounts.First(x => x.Id == id));
        
        await _dbContext.SaveChangesAsync();
    }
}