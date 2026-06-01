namespace CashflowNet.Shared.RequestModels.Transactions;

public class GetTransactionsRequestModel
{
    public required Guid BankAccountId { get; set; }
}