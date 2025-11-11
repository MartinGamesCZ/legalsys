using legalsys.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legalsys.Database
{
    class ContextManager
    {
        private readonly InvoiceContext context;

        public ContextManager(InvoiceContext context)
        {
            this.context = context;
        }

        public void Add(InvoiceEntity entity)
        {
            context.Add(entity);
        }

        public List<InvoiceEntity> GetAll()
        {
            return this.context.InvoiceSet.ToList();
        }
    }
}
