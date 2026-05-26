namespace CashflowNet.Server.Domain.Entities;

public class BankAccount
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
}