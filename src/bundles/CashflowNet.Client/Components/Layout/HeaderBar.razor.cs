using CashflowNet.Client.Communication.Scaffolds;
using CashflowNet.Client.Communication.ViewModels;
using Microsoft.AspNetCore.Components;

namespace CashflowNet.Client.Components.Layout;

public partial class HeaderBar
{
    private IEnumerable<GetBankAccountsViewModel> _bankAccounts = [];

    [Inject] private ICashflowApi CashflowApi { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        _bankAccounts = await CashflowApi.GetBankAccounts();
    }
}