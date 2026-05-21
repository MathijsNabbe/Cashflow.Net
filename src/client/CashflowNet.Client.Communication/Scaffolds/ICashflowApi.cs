using CashflowNet.Client.Communication.Requests;
using Refit;

namespace CashflowNet.Client.Communication.Scaffolds;

public interface ICashflowApi
{
    [Post("/bankaccounts")]
    Task CreateBankAccount(CreateBankAccountRequest bankAccount);
}