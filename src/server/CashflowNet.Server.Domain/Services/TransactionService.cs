using CashflowNet.Server.Domain.Dtos.Transactions;
using CashflowNet.Server.Domain.Entities;
using CashflowNet.Server.Domain.Interfaces;
using CashflowNet.Shared.Enums;

namespace CashflowNet.Server.Domain.Services;

public class TransactionService : ITransactionService
{
    private readonly CashflowDbContext _dbContext = new();
    
    public async Task CreateTransaction(CreateTransactionDto transaction)
    {
        if (transaction.Type == TransactionType.Transfer && transaction.TargetBankAccountId == null)
            throw new ArgumentNullException(nameof(transaction.TargetBankAccountId), "A transfer must always have a target bank account");
        
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
        return _dbContext.Transactions.Select(x => new GetTransactionsDto
        {
            Id = x.Id,
            Name = x.Name,
            Value = x.Value,
            Currency = x.Currency,
            StartDate = x.StartDate,
            Type = x.Type,
            BankAccountId = x.BankAccountId,
            TargetBankAccountId = x.TargetBankAccountId
        }).ToList();
    }
}