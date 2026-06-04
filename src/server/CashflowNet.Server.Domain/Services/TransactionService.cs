using CashflowNet.Server.Domain.Dtos.BankAccounts;
using CashflowNet.Server.Domain.Dtos.Transactions;
using CashflowNet.Server.Domain.Entities;
using CashflowNet.Server.Domain.Interfaces;
using CashflowNet.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace CashflowNet.Server.Domain.Services;

public class TransactionService : ITransactionService
{
    private readonly CashflowDbContext _dbContext = new();

    public async Task CreateTransaction(CreateTransactionDto transaction)
    {
        if (transaction.Type == TransactionType.Transfer && transaction.TargetBankAccountId == null)
            throw new ArgumentNullException(nameof(transaction.TargetBankAccountId),
                "A transfer must always have a target bank account");

        if (transaction.Type != TransactionType.Transfer && transaction.TargetBankAccountId != null)
            throw new InvalidOperationException("A non-transfer transaction cannot have a target bank account");

        _dbContext.Transactions.Add(new Transaction
        {
            Id = Guid.NewGuid(),
            Name = transaction.Name,
            Value = transaction.Value,
            Currency = transaction.Currency,
            StartDate = transaction.StartDate ?? DateTime.UtcNow,
            Type = transaction.Type,
            BankAccountId = transaction.BankAccountId
        });

        await _dbContext.SaveChangesAsync();
    }

    public List<GetTransactionsDto> GetTransactions(Guid bankAccountId)
    {
        return _dbContext.Transactions
            .Where(x => 
                x.BankAccountId == bankAccountId ||
                x.TargetBankAccountId == bankAccountId)
            .Include(x => x.BankAccount)
            .Include(x => x.TargetBankAccount)
            .Select(x => new GetTransactionsDto
            {
                Id = x.Id,
                Name = x.Name,
                Value = x.Value,
                Currency = x.Currency,
                StartDate = x.StartDate,
                Type = x.Type,
                BankAccount = new GetBankAccountsDto
                {
                    Id = x.BankAccount.Id,
                    Name = x.BankAccount.Name
                },
                TargetBankAccount =
                    x.TargetBankAccount != null
                        ? new GetBankAccountsDto
                        {
                            Id = x.TargetBankAccount.Id,
                            Name = x.TargetBankAccount.Name
                        }
                        : null
            }).ToList();
    }
    
    public async Task DeleteTransaction(Guid id)
    {
        var target = await _dbContext.Transactions.FindAsync(id);
        if (target is null)
            throw new Exception("Transaction not found");
        
        _dbContext.Transactions.Remove(target);
        
        await _dbContext.SaveChangesAsync();
    }
}