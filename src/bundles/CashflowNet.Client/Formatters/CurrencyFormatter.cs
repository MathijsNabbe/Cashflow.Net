using CashflowNet.Shared.Enums;

namespace CashflowNet.Client.Formatters;

public static class CurrencyFormatter
{
    public static string GetCurrencySymbol(Currency currency)
    {
        switch (currency)
        {
            case Currency.Euro:
                return "€";
            case Currency.Dollar:
                return "$";
            default:
                return "?";
        }
    }
}