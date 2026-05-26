namespace CashflowNet.Server.Domain.Dtos.BankAccounts;

public class UpdateBankAccountDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}