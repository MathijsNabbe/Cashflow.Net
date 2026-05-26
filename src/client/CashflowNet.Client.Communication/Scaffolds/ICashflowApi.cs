using CashflowNet.Client.Communication.ViewModels;
using Refit;

namespace CashflowNet.Client.Communication.Scaffolds;

public interface ICashflowApi
{
    [Post("/bankaccounts")]
    Task CreateBankAccount(CreateBankAccountViewModel bankAccount);
    
    [Get("/bankaccounts")]
    Task<List<GetBankAccountsViewModel>> GetBankAccounts();
    
    [Delete("/bankaccounts")]
    Task DeleteBankAccount(DeleteBankAccountViewModel bankAccount);
}