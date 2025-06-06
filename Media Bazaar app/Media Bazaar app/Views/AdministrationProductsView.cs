using Media_Bazaar_app.Classes;
using Media_Bazaar_app.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Media_Bazaar_app
{
    public partial class AdministrationProductsView : Form
    {
        private Product productControl;
        private ProductMessage productMessage;
        private Department departmentsControl;

        public AdministrationProductsView()
        {
            InitializeComponent();
            LoadGUI();
        }

        private void lbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbProducts.SelectedIndex != -1)
            {
               string name = lbProducts.SelectedItem.ToString();
               GetProductInfo(name);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (productControl.EditExistingProduct(tbName.Text, tbQuantity.Text, tbPrice.Text, rbDescription.Text, cbDepartment.Text, tbProductID.Text) == false)
                {
                    MessageBox.Show("Duplicate Product ID or Name not allowed");
                }
                else
                {

                    MessageBox.Show("Product details changed");
                    PopulateProductListBox();
                    cbSearchDepartmetn.SelectedIndex = 0;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (productControl.AddNewProduct(tbName.Text, tbQuantity.Text, tbPrice.Text, rbDescription.Text, cbDepartment.Text, tbProductID.Text) == false)
                {
                    MessageBox.Show("Duplicate Product ID or Name not allowed");
                }
                else
                {
                    if (cbSearchDepartmetn.SelectedIndex == 0)
                    {
                        PopulateProductListBox();
                    }
                    else
                    {
                       ProductsByDepartment(cbSearchDepartmetn.Text);
                    }
                    pnlSide.Controls.Clear();
                    GenerateAutoMessage();
                    ShowMessages();
                    tbName.Clear();
                    tbPrice.Clear();
                    tbProductID.Clear();
                    tbQuantity.Clear();
                    cbDepartment.SelectedIndex = -1;
                    rbDescription.Clear();
                    MessageBox.Show("Product entry created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }        
        }

        private void cbSearchDepartmetn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchDepartmetn.SelectedIndex == 0)
            {
                PopulateProductListBox();
            }
            else
            {
               ProductsByDepartment(cbSearchDepartmetn.Text);
            }
        }

        private void Cb_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                productMessage.DeleteMessage(Convert.ToInt32((sender as CheckBox).Name));
            }
            pnlSide.Controls.Clear();
            ShowMessages();
        }
              
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string partial = tbSearch.Text;
            string department = cbSearchDepartmetn.Text;
            if (string.IsNullOrEmpty(partial) || string.IsNullOrWhiteSpace(partial))
            {
                if (cbSearchDepartmetn.SelectedIndex == 0)
                {
                    PopulateProductListBox();
                }
                else
                {
                    ProductsByDepartment(department);
                }
            }
            else
            {
                  SearchProducts(partial, department);
            }
        }

        private void GetProductInfo(string name)
        {
            Product fetchedProduct = productControl.GetProductInfo(name);
            tbProductID.Text = fetchedProduct.ProductID;
            tbName.Text = fetchedProduct.Name;
            tbPrice.Text = fetchedProduct.Price.ToString();
            tbQuantity.Text = fetchedProduct.DepoQuantity.ToString();
            rbDescription.Text = fetchedProduct.Description;
            cbDepartment.Text = fetchedProduct.Department;
        }

        private void SearchProducts(string partial, string department)
        {
            lbProducts.Items.Clear();

            foreach (Product p in productControl.SearchProduct(partial, department))
            {
                lbProducts.Items.Add(p.Name);
            }
        }

        private void ProductsByDepartment(string department)
        {
            lbProducts.Items.Clear();
            foreach (Product p in productControl.FilterLocalProductsListByDepartment(department))
            {
                if (p.Department == department)
                {
                    lbProducts.Items.Add(p.Name);
                }
            }
        }

        private void PopulateProductListBox()
        {
            lbProducts.Items.Clear();
            foreach (Product products in productControl.ReturnProductsLocalList())
            {
                lbProducts.Items.Add(products.Name);
            }
        }

        private void GenerateAutoMessage()
        {
            string messageType = "New Product";
            productMessage.CreateNewProductMessage(cbDepartment.Text, tbProductID.Text, tbName.Text, Convert.ToInt32(tbQuantity.Text), messageType);
        }

        private void ShowMessages()
        {

            Panel pnl;
            CheckBox cb;
            TextBox tb;

            int heightofpanels = 10;

            foreach (ProductMessage message in productMessage.ReturnLocalMessagesList())
            {
                pnl = new Panel
                {
                    Name = message.MessageID.ToString()
                };
                cb = new CheckBox
                {
                    Name = message.MessageID.ToString()
                };
                tb = new TextBox
                {
                    Text = $"New product has been added: {message.ProductID} - {message.ProductName} - {message.Department}",
                    Enabled = false,
                    ForeColor = Color.Maroon
                };

                int msgLength = tb.Lines.Where(line => !String.IsNullOrWhiteSpace(line)).Count();

                pnl.Parent = pnlSide;
                pnl.Width = pnlSide.Size.Width - 35;
                pnl.Height = msgLength + 90;
                pnl.BackColor = Color.Transparent;
                pnl.Left = 7;
                pnl.Top = heightofpanels;
                pnl.BorderStyle = BorderStyle.FixedSingle;
                heightofpanels += pnl.Height + 20;

                cb.Parent = pnl;
                cb.Text = "Cancel";
                cb.Top = msgLength + 60;
                cb.Width = 120;
                cb.Left = pnl.Size.Width - (cb.Size.Width + 10);
                cb.TextAlign = ContentAlignment.MiddleCenter;
                cb.Font = new Font("Century Gothic", 8, FontStyle.Regular);
                cb.ForeColor = Color.FromKnownColor(KnownColor.ButtonFace);
                cb.CheckedChanged += new System.EventHandler(Cb_CheckedChanged);

                tb.Parent = pnl;
                tb.Multiline = true;
                tb.Width = pnl.Size.Width - 20;
                tb.Height = msgLength + 40;
                tb.Top = 10;
                tb.Left = 10;
                tb.Font = new Font("Century Gothic", 9, FontStyle.Regular);
                tb.ForeColor = Color.Black;
                tb.TextAlign = HorizontalAlignment.Left;
                tb.BackColor = Color.FromKnownColor(KnownColor.ButtonFace); ;
                tb.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void LoadGUI()
        {
            productControl = new Product();
            productControl.GetProductsFromDatabase();

            departmentsControl = new Department();
            departmentsControl.GetDeparmentsFromDatabase();

            productMessage = new ProductMessage();
            productMessage.GetAdministrationProductMessagesFromDatabase();

            foreach(Department department in departmentsControl.ReturnDepartmentLocalList())
            {
                cbDepartment.Items.Add(department.ToString());
                cbSearchDepartmetn.Items.Add(department.ToString());
            }

            PopulateProductListBox();
            panel1.BringToFront();
            cbSearchDepartmetn.SelectedIndex = 0;
            ShowMessages();
        }
    }
}

