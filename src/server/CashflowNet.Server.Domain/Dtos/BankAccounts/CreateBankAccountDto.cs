namespace CashflowNet.Server.Domain.Dtos.BankAccounts;

public class CreateBankAccountDto
{
    public required string Name { get; set; }
    public required string Iban { get; set; }
}