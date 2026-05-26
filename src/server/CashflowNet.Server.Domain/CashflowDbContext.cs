using CashflowNet.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashflowNet.Server.Domain;

public class CashflowDbContext : DbContext
{
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    public string DbPath { get; }

    public CashflowDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "cashflow.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}