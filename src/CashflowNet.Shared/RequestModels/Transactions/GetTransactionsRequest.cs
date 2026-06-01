namespace CashflowNet.Shared.RequestModels.Transactions;

public class GetTransactionsRequest
{
    public required Guid BankAccountId { get; set; }
}