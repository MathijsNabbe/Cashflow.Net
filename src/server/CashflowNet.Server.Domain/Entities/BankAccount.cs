namespace CashflowNet.Server.Domain.Entities;

public class BankAccount
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Iban { get; set; }
}