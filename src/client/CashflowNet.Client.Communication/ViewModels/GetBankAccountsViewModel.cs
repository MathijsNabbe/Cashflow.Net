namespace CashflowNet.Client.Communication.ViewModels;

public class GetBankAccountsViewModel
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Iban { get; set; }  
}