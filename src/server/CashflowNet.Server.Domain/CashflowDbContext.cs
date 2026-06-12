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
    {
        options.UseSqlite($"Data Source={DbPath}");
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        await Database.ExecuteSqlRawAsync("PRAGMA foreign_keys = ON;", cancellationToken);
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.BankAccount)
            .WithMany()
            .HasForeignKey(t => t.BankAccountId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.TargetBankAccount)
            .WithMany()
            .HasForeignKey(t => t.TargetBankAccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}