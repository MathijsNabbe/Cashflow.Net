namespace CashflowNet.Shared.RequestModels.Transactions;

public class DeleteTransactionRequestModel
{
    public required Guid TransactionId { get; set; }
}