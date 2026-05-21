namespace CashflowNet.Server.Communication.Endpoints.BankAccounts.Create;

public class CreateBankAccountRequest
{
    public required string Name { get; set; }
    public required string Iban { get; set; }   
}