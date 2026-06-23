using CashflowNet.Shared.Enums;

namespace CashflowNet.Shared.RequestModels.Transactions;

public class CreateTransactionRequestModel
{
    public required string Name { get; set; }
    public required decimal Value { get; set; }
    public required Currency Currency { get; set; }
    public DateTime? StartDate { get; set; }
    public required TransactionType Type { get; set; }
    public required TransactionInterval Interval { get; set; }
        
    public required Guid BankAccountId { get; set; }
    public Guid? TargetBankAccountId { get; set; }
}