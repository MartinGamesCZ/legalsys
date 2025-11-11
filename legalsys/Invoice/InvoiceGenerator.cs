using legalsys.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legalsys.Invoice
{
    class InvoiceGenerator
    {
        private ContextManager invoiceContextManager;

        public InvoiceGenerator(ContextManager invoiceContextManager)
        {
            this.invoiceContextManager = invoiceContextManager;
        }
    }
}
