namespace CashflowNet.Server.Communication.Endpoints.BankAccounts.Update;

public class UpdateBankAccountRequest
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}