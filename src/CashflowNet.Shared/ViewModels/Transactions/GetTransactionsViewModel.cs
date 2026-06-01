using CashflowNet.Shared.Enums;
using CashflowNet.Shared.ViewModels.BankAccounts;

namespace CashflowNet.Shared.ViewModels.Transactions;

public class GetTransactionsViewModel
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required decimal Value { get; set; }
    public required Currency Currency { get; set; }
    public DateTime? StartDate { get; set; }
    public required TransactionType Type { get; set; }
        
    public GetBankAccountsViewModel BankAccount { get; set; }
    public GetBankAccountsViewModel? TargetBankAccount { get; set; }
}