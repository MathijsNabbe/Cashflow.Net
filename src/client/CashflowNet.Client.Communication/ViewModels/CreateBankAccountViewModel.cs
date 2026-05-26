namespace CashflowNet.Client.Communication.ViewModels;

public class CreateBankAccountViewModel
{
    public required string Name { get; set; }
    public required string Iban { get; set; }  
}