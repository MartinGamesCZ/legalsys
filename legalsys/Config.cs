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
    }
}
