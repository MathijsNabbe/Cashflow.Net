namespace CashflowNet.Server.Communication.Endpoints.BankAccounts.Get;

public class GetBankAccountsResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Iban { get; set; }   
}