namespace CashflowNet.Server.Domain.Dtos.BankAccounts;

public class GetBankAccountsDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Iban { get; set; }
}