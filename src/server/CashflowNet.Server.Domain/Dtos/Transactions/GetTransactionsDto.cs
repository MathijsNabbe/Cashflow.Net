using CashflowNet.Server.Domain.Dtos.BankAccounts;
using CashflowNet.Shared.Enums;

namespace CashflowNet.Server.Domain.Dtos.Transactions;

public class GetTransactionsDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required decimal Value { get; set; }
    public required Currency Currency { get; set; }
    public required DateTime StartDate { get; set; }
    public required TransactionType Type { get; set; }
    public required TransactionInterval Interval { get; set; }
    public required GetBankAccountsDto BankAccount { get; set; }
    public GetBankAccountsDto? TargetBankAccount { get; set; }
}