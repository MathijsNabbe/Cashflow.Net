namespace CashflowNet.Shared.RequestModels.BankAccounts;

public class UpdateBankAccountRequestModel
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}