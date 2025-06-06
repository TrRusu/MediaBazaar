using Media_Bazaar_app.Classes;
using Media_Bazaar_app.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Bazaar_app.Views
{
    public partial class FloorCashierView : Form
    {
        private Product productControl;

        public FloorCashierView()
        {
            InitializeComponent();
            LoadGUI();            
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string partial = tbSearch.Text;

            if (string.IsNullOrEmpty(partial) || string.IsNullOrWhiteSpace(partial))
            {
                PopulateProductListBox();
            }
            else
            {
                SearchProducts(partial);
            }
        }

        private void lbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbProducts.SelectedIndex != -1)
            {
                GetProductInfo(lbProducts.SelectedItem.ToString());
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            int index = lbProducts.SelectedIndex;
            try
            {
                productControl.RegisterSaleInDatabase(tbProductID.Text, tbSell.Text, Convert.ToInt32(tbQuantity.Text), Convert.ToInt32(DateTime.Now.ToString("MM")), tbName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            PopulateProductListBox();
            lbProducts.SelectedIndex = index;
        }

        private void SearchProducts(string partial)
        {
            string department = "All";
            lbProducts.Items.Clear();

            foreach (Product p in productControl.SearchProduct(partial, department))
            {
                lbProducts.Items.Add(p.Name);
            }
        }

        private void GetProductInfo(string name)
        {
            Product fetchedProduct = productControl.GetProductInfo(name);
            tbProductID.Text = fetchedProduct.ProductID;
            tbName.Text = fetchedProduct.Name;
            tbPrice.Text = fetchedProduct.Price.ToString();
            tbQuantity.Text = fetchedProduct.ShelfQuantity.ToString();
            rbDescription.Text = fetchedProduct.Description;
        }

        private void PopulateProductListBox()
        {
            lbProducts.Items.Clear();
            foreach (Product products in productControl.ReturnProductsLocalList())
            {
                lbProducts.Items.Add(products.Name);
            }
        }

        private void LoadGUI()
        {
            productControl = new Product();
            productControl.GetProductsFromDatabase();
            PopulateProductListBox();
        }
    }
}
