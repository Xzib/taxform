using System;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;


namespace TaxCalculatorForImportItem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new BaseViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =C:\TaxCalculation\TaxCalculation.accdb;
            Persist Security Info = False;";
            connection.Open();
            MessageBox.Show("Established");
            connection.Close();

            try
            {
                connection.Open();
                String itemName = ItemName.Text.ToString();
                String vendorName = VendorName.Text.ToString();
                String itemCost = ItemCost.Text.ToString();
                String totalTax = Totaltax.Text.ToString();
                String grandTotal = Grandtotal.Text.ToString();

                String dataCommand = "INSERT INTO ItemTax (ItemName,VendorName,ItemCost,TotalTax,GrandTotal) VALUES('" + itemName + "','" + vendorName + "','" + itemCost + "','"+totalTax+"','"+grandTotal+"')";
                OleDbCommand command = new OleDbCommand(dataCommand, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Data saved successfuly...!");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed due to" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}


