using legalsys.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legalsys.Database
{
    public class ContextManager
    {
        private readonly InvoiceContext context;

        public ContextManager(InvoiceContext context)
        {
            this.context = context;
        }

        public void Add(InvoiceEntity entity)
        {
            this.context.InvoiceSet.Add(entity);
            this.context.SaveChanges();
        }

        public List<InvoiceEntity> GetAll()
        {
            return this.context.InvoiceSet.ToList();
        }
    }
}
