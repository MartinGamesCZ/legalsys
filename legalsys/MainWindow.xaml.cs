using legalsys.Database;
using legalsys.Database.Models;
using legalsys.Invoice;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace legalsys
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private InvoiceContext invoiceContext = new InvoiceContext();
        private ContextManager invoiceContextManager;

        private InvoiceGenerator invoiceGenerator;

        public MainWindow()
        {
            this.invoiceContextManager = new ContextManager(this.invoiceContext);
            this.invoiceGenerator = new InvoiceGenerator(this.invoiceContextManager);

            InitializeComponent();

            this.LoadInvoiceList();
        }

        private void LoadInvoiceList()
        {
            invList.ItemsSource = this.invoiceContextManager.GetAll();
            invList.Items.Refresh();
        }

        private void invList_DoubleClick(object sender, RoutedEventArgs e)
        {
            InvoiceEntity? entity = invList.SelectedItem as InvoiceEntity;

            this.invoiceGenerator.generate(entity);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewInvoice(this.invoiceContextManager);

            window.Closed += (s, e) =>
            {
                this.LoadInvoiceList();
            };

            window.Show();
        }
    }
}