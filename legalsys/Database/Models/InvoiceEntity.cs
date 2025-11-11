using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum ServiceName
{
    FinancialAdvisory = 0,
    LegalAdvisory = 1
};

enum Currency
{
    USD = 0,
    CZK = 1
}

namespace legalsys.Database.Models
{
    class InvoiceEntity : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCIN {  get; set; }
        public ServiceName ServiceName { get; set; }
        public int Hours { get; set; }
        public int Rate { get; set; }
        public Currency Currency { get; set; }
        public DateTime CreatedAt { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString()
        {
            return $"{this.CustomerName} - {Config.ServiceNames[this.ServiceName]} - {this.Hours}h @ {this.Rate} {this.Currency}";
        }
    }
}
