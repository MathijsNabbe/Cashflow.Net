using CashflowNet.Server.Domain.Dtos.Transactions;

namespace CashflowNet.Server.Domain.Interfaces;

public interface ITransactionService
{
    public Task CreateTransaction(CreateTransactionDto bankAccount);
    public List<GetTransactionsDto> GetTransactions(Guid requestBankAccountId);
    public Task DeleteTransaction(Guid id);
}