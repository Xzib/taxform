using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows;
using System.Data;

namespace TaxCalculatorForImportItem
{
    public class DataBase
    {

        public static void SendToDataBase()
        {
            BaseViewModel items = new BaseViewModel();
            String itemName = items.ItemName;
            String vendorName = items.VendorName;
            String manufacturer = " ";
            String origin = " ";
            String itemCost = items.ItemCost.ToString();
            String totalTax = items.TotalTax.ToString();
            String grandTotal = items.GrandTotal.ToString();

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = F:\ItemCalculation.accdb;
            Persist Security Info = False;";
            OleDbCommand cmd = new OleDbCommand("INSERT INTO ItemList(ItemName) " +
                "Values(@itemName)");
            if (connection.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@itemName", OleDbType.VarChar).Value = itemName;


                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Added");
                    connection.Close();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Connection Failed");
            }

        }


    }
}
