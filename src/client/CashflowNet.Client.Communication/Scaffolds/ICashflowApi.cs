using CashflowNet.Shared.RequestModels.BankAccounts;
using CashflowNet.Shared.RequestModels.Transactions;
using CashflowNet.Shared.ViewModels.BankAccounts;
using CashflowNet.Shared.ViewModels.Transactions;
using Refit;

namespace CashflowNet.Client.Communication.Scaffolds;

public interface ICashflowApi
{
    [Post("/bankaccounts")]
    Task<GetBankAccountsViewModel> CreateBankAccount(CreateBankAccountRequestModel bankAccount);
    
    [Get("/bankaccounts")]
    Task<List<GetBankAccountsViewModel>> GetBankAccounts();
    
    [Delete("/bankaccounts")]
    Task DeleteBankAccount(DeleteBankAccountRequestModel bankAccount);
    
    [Put("/bankaccounts")]
    Task UpdateBankAccount(UpdateBankAccountRequestModel bankAccount);
    
    [Post("/transactions")]
    Task CreateTransaction(CreateTransactionRequestModel transaction);
    
    [Get("/transactions")]
    Task<List<GetTransactionsViewModel>> GetTransactions(GetTransactionsRequestModel request);
    
    [Delete("/transactions")]
    Task DeleteTransaction(DeleteTransactionRequestModel transaction);
}