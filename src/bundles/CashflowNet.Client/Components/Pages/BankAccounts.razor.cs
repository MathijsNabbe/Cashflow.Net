using CashflowNet.Client.Communication.Requests;
using CashflowNet.Client.Communication.Scaffolds;
using Microsoft.AspNetCore.Components;

namespace CashflowNet.Client.Components.Pages;

public partial class BankAccounts
{
    [Inject] private ICashflowApi CashflowApi { get; set; } = null!;
    
    private async Task CreateBankAccount()
    {
        await CashflowApi.CreateBankAccount(new CreateBankAccountRequest
        {
            Name = "New Bank Account",
            Iban = "DE12345678901234567890"
        });
    }
}