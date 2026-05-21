namespace CashflowNet.Client.Communication.Requests;

public class CreateBankAccountRequest
{
    public required string Name { get; set; }
    public required string Iban { get; set; }  
}