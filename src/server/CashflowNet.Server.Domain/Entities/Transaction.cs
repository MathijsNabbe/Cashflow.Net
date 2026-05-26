using CashflowNet.Server.Domain.Enums;

namespace CashflowNet.Server.Domain.Entities;

public class Transaction
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required decimal Value { get; set; }
    public required string Currency { get; set; }
    public required DateTime StartDate { get; set; }
    public required TransactionType Type { get; set; }
    
    public required Guid BankAccountId { get; set; }
    public required BankAccount BankAccount { get; set; }
    
    public Guid? TargetBankAccountId { get; set; }
    public BankAccount? TargetBankAccount { get; set; }
}