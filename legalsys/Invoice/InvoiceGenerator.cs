using legalsys.Database;
using legalsys.Database.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace legalsys.Invoice
{
    class InvoiceGenerator
    {
        private ContextManager invoiceContextManager;

        public InvoiceGenerator(ContextManager invoiceContextManager)
        {
            this.invoiceContextManager = invoiceContextManager;
        }

        public void generate(InvoiceEntity entity)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string filename = $"Invoice_{entity.CustomerName}_{timestamp}.txt";
            
            StringBuilder content = new StringBuilder();
            content.AppendLine("FAKTURA / INVOICE");
            content.AppendLine("==================");
            content.AppendLine();
            content.AppendLine($"Zákazník / Customer: {entity.CustomerName}");
            content.AppendLine($"Adresa / Address: {entity.CustomerAddress}");
            content.AppendLine($"IČO / CIN: {entity.CustomerCIN}");
            content.AppendLine();
            content.AppendLine($"Služba / Service: {entity.ServiceName}");
            content.AppendLine($"Hodiny / Hours: {entity.Hours}");
            content.AppendLine($"Sazba / Rate: {entity.Rate} {entity.Currency}");
            content.AppendLine($"Celkem / Total: {entity.Hours * entity.Rate} {entity.Currency}");
            content.AppendLine();
            content.AppendLine($"Datum vytvoření / Created: {entity.CreatedAt:dd.MM.yyyy HH:mm}");
            
            try
            {
                using (FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    writer.Write(content.ToString());
                }

                Process.Start(new ProcessStartInfo
                {
                    FileName = filename,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při generování faktury: {ex.Message}", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
