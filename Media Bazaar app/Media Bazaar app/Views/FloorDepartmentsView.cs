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

namespace Media_Bazaar_app
{
    public partial class FloorDepartmentsView : Form
    {
        private User saved;
        private Product productControl;
        private ProductMessage productMessage;

        public FloorDepartmentsView(User name, string department)
        {
            InitializeComponent();
            LoadGUI(department, name);
        }

        private void lbProducts_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lbProducts.SelectedIndex != -1)
            {
                GetProductInfo(lbProducts.SelectedItem.ToString());
            }
        }

        private void btnRestockReq_Click(object sender, EventArgs e)
        {
            GenerateRestockAutoMessage();
            ShowMessages();
        }

        private void Cb_CheckedChanged(object sender, EventArgs e)
        {
            int id;
            int amount;
            string productID;
            int shelfQuantity;
            int depotQuantity;



            if ((sender as CheckBox).Checked)
            {
                for (int i = 0; i < productMessage.ReturnLocalMessagesList().Count; i++)
                {
                    if (saved.Position == "Sales Agent")
                    {
                        if (Convert.ToInt32((sender as CheckBox).Name) == productMessage.ReturnLocalMessagesList()[i].MessageID)
                        {
                            id = ((ProductMessage)productMessage.ReturnLocalMessagesList()[i]).MessageID;
                            productMessage.DeleteMessage(id);
                            pnlSide.Controls.Clear();
                            ShowMessages();
                        }
                    }
                    else
                    {
                        SearchProducts(((ProductMessage)productMessage.ReturnLocalMessagesList()[i]).ProductName, lblDepartment.Text);
                        lbProducts.SelectedIndex = 0;
                        productID = tbProductID.Text;
                        shelfQuantity = Convert.ToInt32(tbQuantity.Text);
                        depotQuantity = Convert.ToInt32(tbDeposit.Text);

                        if (Convert.ToInt32((sender as CheckBox).Name) == productMessage.ReturnLocalMessagesList()[i].MessageID)
                        {
                            id = ((ProductMessage)productMessage.ReturnLocalMessagesList()[i]).MessageID;
                            amount = ((ProductMessage)productMessage.ReturnLocalMessagesList()[i]).Quantity;
                            productMessage.DeleteMessage(id);
                            try
                            {
                                productControl.UpdateProductQuantitiesInDatabase(productID, shelfQuantity, depotQuantity, amount);
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            tbProductID.Clear();
                            tbName.Clear();
                            tbPrice.Clear();
                            tbQuantity.Clear();
                            tbDeposit.Clear();
                            rbDescription.Clear();
                            pnlSide.Controls.Clear();
                            ShowMessages();
                            PopulateProductListBox();
                            break;
                        }
                    }
                }
            }
        }

        private void Cb_CheckedCancelChanged(object sender, EventArgs e)
        {
            int id = 0;

            if ((sender as CheckBox).Checked)
            {
                for (int i = 0; i < productMessage.ReturnLocalMessagesList().Count; i++)
                {
                    if (Convert.ToInt32((sender as CheckBox).Name) == productMessage.ReturnLocalMessagesList()[i].MessageID)
                    {
                        id = productMessage.ReturnLocalMessagesList()[i].MessageID;
                    }
                }

                productMessage.DeleteMessage(id);
            }

            pnlSide.Controls.Clear();
            ShowMessages();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string partial = tbSearch.Text;
            string department = lblDepartment.Text;

            if (string.IsNullOrEmpty(partial) || string.IsNullOrWhiteSpace(partial))
            {
               PopulateProductListBox();
            }
            else
            {
                SearchProducts(partial, department);
            }
        }

        private void FormConfiguration()
        {
            if (saved.Position == "Cashier")
            {
                label3.Visible = false;
                lblDeposit.Visible = false;
                tbDeposit.Visible = false;
                lblReplenish.Visible = false;
                tbRestock.Visible = false;
                lblCU.Visible = false;
                btnRestockReq.Visible = false;
                pnlSide.Visible = false;
            }
            else if (saved.Position == "Depot Worker")
            {

                lblReplenish.Visible = false;
                tbRestock.Visible = false;
                lblCU.Visible = false;
                btnRestockReq.Visible = false;
                ShowMessages();
            }
            else
            {
                ShowMessages();
            }
        }

        private void PopulateProductListBox()
        {
            lbProducts.Items.Clear();
            foreach (Product products in productControl.ReturnProductsByDepartmentLocalList())
            {
                lbProducts.Items.Add(products.Name);
            }
        }

        private void GenerateRestockAutoMessage()
        {
            try
            {
                string type = "Restock";
                productMessage.CreateRestockMessage(lblDepartment.Text, tbProductID.Text, tbName.Text, tbRestock.Text, type, tbDeposit.Text);
                pnlSide.Controls.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowMessages()
        {
            Panel pnl;
            CheckBox cb;
            CheckBox cancelcb;
            TextBox tb;
            int heightofpanels = 10;

            foreach (ProductMessage message in productMessage.ReturnLocalMessagesList())
            {
                if (saved.Position == "Sales Agent")
                {
                    pnl = new Panel
                    {
                        Name = message.MessageID.ToString()
                    };
                    cb = new CheckBox
                    {
                        Name = message.MessageID.ToString()
                    };
                    cancelcb = new CheckBox
                    {
                        Name = message.MessageID.ToString()
                    };
                    tb = new TextBox();
                    if (message.Type == "New Product")
                    {
                        tb.Text = $"New product has been added: {message.ProductID} - {message.ProductName} - {lblDepartment.Text}";
                    }

                    if (message.Type == "Restock")
                    {
                        tb.Text = $"Please restock: {message.ProductID} - {message.ProductName} - {lblDepartment.Text} - with {message.Quantity} - CU";
                    }
                    tb.Enabled = false;
                    tb.ForeColor = Color.Maroon;

                    int msgLength = tb.Lines.Where(line => !String.IsNullOrWhiteSpace(line)).Count();

                    pnl.Parent = pnlSide;
                    pnl.Width = pnlSide.Size.Width - 35;
                    pnl.Height = msgLength + 90;
                    pnl.BackColor = Color.Transparent;
                    pnl.Left = 7;
                    pnl.Top = heightofpanels;
                    pnl.BorderStyle = BorderStyle.FixedSingle;
                    heightofpanels += pnl.Height + 20;

                    if (message.Type == "New Product")
                    {
                        cb.Parent = pnl;
                        cb.Text = "Completed";
                        cb.Top = msgLength + 60;
                        cb.Width = 120;
                        cb.Left = pnl.Size.Width - (cb.Size.Width + 10);
                        cb.TextAlign = ContentAlignment.MiddleCenter;
                        cb.Font = new Font("Century Gothic", 8, FontStyle.Regular);
                        cb.ForeColor = Color.FromKnownColor(KnownColor.ButtonFace);
                        cb.CheckedChanged += new System.EventHandler(Cb_CheckedChanged);
                    }

                    if (message.Type == "Restock")
                    {
                        cancelcb.Parent = pnl;
                        cancelcb.Text = "Cancel";
                        cancelcb.Top = msgLength + 60;
                        cancelcb.Width = 100;
                        cancelcb.Left = pnl.Size.Width - (cancelcb.Size.Width + 25);
                        cancelcb.TextAlign = ContentAlignment.MiddleCenter;
                        cancelcb.Font = new Font("Century Gothic", 8, FontStyle.Regular);
                        cancelcb.ForeColor = Color.FromKnownColor(KnownColor.ButtonFace);
                        cancelcb.CheckedChanged += new System.EventHandler(Cb_CheckedCancelChanged);
                    }

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

                else if (saved.Position == "Depot Worker")
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
                        Text = $"Please restock: {message.ProductID} - {message.ProductName} - {lblDepartment.Text} - with {message.Quantity} - CU",
                        Enabled = false,
                        ForeColor = Color.Maroon
                    };

                    int msgLength = tb.Lines.Where(line => !String.IsNullOrWhiteSpace(line)).Count();

                    pnl.Parent = pnlSide;
                    pnl.Width = pnlSide.Size.Width - 35;
                    pnl.Height = msgLength +90;
                    pnl.BackColor = Color.Transparent;
                    pnl.Left = 7;
                    pnl.Top = heightofpanels;
                    pnl.BorderStyle = BorderStyle.FixedSingle;
                    heightofpanels += pnl.Height + 20;

                    cb.Parent = pnl;
                    cb.Text = "Completed";
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
        }

        private void GetProductInfo(string name)
        {
            Product fetchedProduct = productControl.GetProductInfoFilteredByDepartment(name);
            tbProductID.Text = fetchedProduct.ProductID;
            tbName.Text = fetchedProduct.Name;
            tbPrice.Text = fetchedProduct.Price.ToString();
            tbQuantity.Text = fetchedProduct.ShelfQuantity.ToString();
            rbDescription.Text = fetchedProduct.Description;
            tbDeposit.Text = fetchedProduct.DepoQuantity.ToString();
        }

        private void SearchProducts(string partial, string department)
        {
            lbProducts.Items.Clear();

            foreach (Product p in productControl.SearchProductFilteredByDepartment(partial, department))
            {
                lbProducts.Items.Add(p.Name);
            }
        }

        private void LoadGUI(string department, User user)
        {
            lblDepartment.Text = department;
            saved = user;

            productControl = new Product();
            productControl.GetProductsByDepartmentFromDatabase(lblDepartment.Text);

            productMessage = new ProductMessage();
            productMessage.GetFloorProductMessagesFromDatabase(saved.Position, department);

            PopulateProductListBox();
            FormConfiguration();
            panel1.BringToFront();
        }
    }
}


