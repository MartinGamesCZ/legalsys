using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legalsys
{
    static class Config
    {
        public static readonly Dictionary<ServiceName, string> ServiceNames = new()
        {
            [ServiceName.FinancialAdvisory] = "Finanční poradenství",
            [ServiceName.LegalAdvisory] = "Právní poradenství"
        };

        public static readonly Dictionary<Currency, string> CurrencyNames = new()
        {
            [Currency.CZK] = "Česká koruna",
            [Currency.USD] = "Americký dolar"
        };

        public static readonly Dictionary<Currency, int> Prices = new()
        {
 
            [Currency.CZK] = 3000,
            [Currency.USD] = 145
        };
    }
}
