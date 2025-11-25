using legalsys.Database;
using legalsys.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace legalsys
{
    /// <summary>
    /// Interakční logika pro NewInvoice.xaml
    /// </summary>
    public partial class NewInvoice : Window
    {
        private readonly ContextManager _contextManager;
        private List<ServiceName> services = new List<ServiceName>();
        private Currency? currency = null;

        public NewInvoice(ContextManager contextManager)
        {
            InitializeComponent();
            this._contextManager = contextManager;

            this.sService.ItemsSource = Config.ServiceNames;
            this.sCurrency.ItemsSource = Config.CurrencyNames;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = this.iName.Text;
            string address = this.iAddress.Text;
            string cin = this.iCIN.Text;
            int price = int.Parse(this.iPrice.Text);
            int hours = int.Parse(this.iHours.Text);

            // Get selected services from the ListBox
            this.services.Clear();
            foreach (var item in this.sService.SelectedItems)
            {
                if (item is KeyValuePair<ServiceName, string> pair)
                {
                    this.services.Add(pair.Key);
                }
            }

            if (this.services.Count == 0 || this.currency is null)
            {
                MessageBox.Show("Please select at least one service and a currency.");
                return;
            }

            // Create an invoice entity for each selected service
            foreach (var service in this.services)
            {
                var entity = new InvoiceEntity
                {
                    CustomerName = name,
                    CustomerAddress = address,
                    CustomerCIN = cin,
                    ServiceName = service,
                    Rate = price,
                    Hours = hours,
                    Currency = this.currency.Value,
                    CreatedAt = DateTime.Now
                };
                this._contextManager.Add(entity);
            }

            this.Close();
        }

        private void sCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object? currency = this.sCurrency.SelectedItem;

            if (currency is KeyValuePair<Currency, string> pair)
            {
                this.currency = pair.Key;
            }
            else if (currency is null)
            {
                this.currency = null;
            }

            this.FillInTaxRate();
        }

        private void FillInTaxRate()
        {
            if (this.currency is not null)
            {
                this.iPrice.Text = Config.Prices[this.currency.Value].ToString();
            }
        }
    }
}
