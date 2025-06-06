using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Media_Bazaar_app.Classes;

namespace Media_Bazaar_app.Views
{
    public partial class AdministrationCreateDepartmentView : Form
    {
        private User userControl;
        private Department departmentControl;
        private Product productControl;

        public AdministrationCreateDepartmentView()
        {
            InitializeComponent();
            UpdateGUI();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            departmentControl.CreateNewDepartment(tbName.Text);
            PopulateDepartmentGUI();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (lbDepartments.SelectedIndex != -1)
            {
                departmentControl.EditExistingDepartmentName(tbName.Text, lbDepartments.SelectedItem.ToString());
                productControl.MoveAllProductsToDepartment(lbDepartments.SelectedItem.ToString(), tbName.Text);
                userControl.MoveAllFloorToDepartment(lbDepartments.SelectedItem.ToString(), tbName.Text);
                PopulateDepartmentGUI();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbDepartments.SelectedIndex != -1)
            {
                if (lbEmployees.Items.Count < 1 && lbProducts.Items.Count < 1)
                {
                    departmentControl.RemoveDepartmentFromDatabase(lbDepartments.SelectedItem.ToString());
                    PopulateDepartmentGUI();
                }
                else
                {
                    MessageBox.Show("Department must not contain any records");
                }
            }
        }

        private void lbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbDepartments.SelectedIndex != -1)
            {
                lbEmployees.Items.Clear();
                lbProducts.Items.Clear();
                tbName.Text = lbDepartments.SelectedItem.ToString();
                PopulateUserListbox(lbDepartments.SelectedItem.ToString());
                PopulateProductListbox(lbDepartments.SelectedItem.ToString());
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (lbProducts.SelectedIndex != -1)
            {
                productControl.DeleteProductFromDatabase(lbProducts.SelectedItem.ToString());
                lbProducts.Items.Clear();
                PopulateProductListbox(lbDepartments.SelectedItem.ToString());
            }

        }

        private void btnMoveEmployee_Click(object sender, EventArgs e)
        {

            if (lbEmployees.SelectedIndex != -1)
            {
                if (cbDepartments.SelectedItem.ToString() == lbDepartments.SelectedItem.ToString())
                {
                    MessageBox.Show("Please select diferent destination department");
                }
                else
                {
                    userControl.MoveFloorEmployeeToDepartemnt(cbDepartments.SelectedItem.ToString(), lbEmployees.SelectedItem.ToString());
                    PopulateUserListbox(lbDepartments.SelectedItem.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please select employee");
            }
        }

        private void btnMoveAllEmployees_Click(object sender, EventArgs e)
        {
            if (cbDepartments.SelectedItem.ToString() == lbDepartments.SelectedItem.ToString())
            {
                MessageBox.Show("Please select diferent destination department");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to move all employees?", "WARNING", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (lbDepartments.SelectedIndex != -1)
                    {

                        userControl.MoveAllFloorToDepartment(lbDepartments.SelectedItem.ToString(), cbDepartments.SelectedItem.ToString());
                        PopulateUserListbox(lbDepartments.SelectedItem.ToString());

                    }
                    else
                    {
                        MessageBox.Show("Please select department");
                    }
                }
            }
        }

        private void btnMoveProduct_Click(object sender, EventArgs e)
        {
            if (lbProducts.SelectedIndex != -1)
            {
                if (cbDepartments.SelectedItem.ToString() == lbDepartments.SelectedItem.ToString())
                {
                    MessageBox.Show("Please select diferent destination department");
                }
                else
                {
                    productControl.MoveProductInDatabase(cbDepartments.SelectedItem.ToString(), lbProducts.SelectedItem.ToString());
                    lbProducts.Items.Clear();
                    PopulateProductListbox(lbDepartments.SelectedItem.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please select a product.");
            }
        }

        private void btnMoveAllProducts_Click(object sender, EventArgs e)
        {
            if (cbDepartments.SelectedItem.ToString() == lbDepartments.SelectedItem.ToString())
            {
                MessageBox.Show("Please select diferent destination department");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to move all products?", "WARNING", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (lbDepartments.SelectedIndex != -1)
                    {

                        productControl.MoveAllProductsToDepartment(lbDepartments.SelectedItem.ToString(), cbDepartments.SelectedItem.ToString());
                        lbProducts.Items.Clear();
                        PopulateProductListbox(lbDepartments.SelectedItem.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Please select department");
                    }
                }
            }
        }

        private void btnRemoveAllProducts_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete all products?", "WARNING", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                lbProducts.Items.Clear();
                productControl.DeleteAllProductsFromDatabase(lbDepartments.SelectedItem.ToString());
                PopulateProductListbox(lbDepartments.SelectedItem.ToString());
            }
        }

        private void PopulateUserListbox(string department)
        {
            lbEmployees.Items.Clear();

            foreach (User user in userControl.FilterLocalUsersListByDepartment(department))
            {
                lbEmployees.Items.Add(user.ToString());
            }
        }

        private void PopulateProductListbox(string department)
        {
            lbProducts.Items.Clear();
            foreach(Product product in productControl.FilterLocalProductsListByDepartment(department))
            {
                lbProducts.Items.Add(product.ToString());
            }
        }

        private void PopulateDepartmentGUI()
        {
            lbDepartments.Items.Clear();
            cbDepartments.Items.Clear();

            foreach(Department department in departmentControl.ReturnDepartmentLocalList())
            {
                lbDepartments.Items.Add(department.ToString());
                cbDepartments.Items.Add(department.ToString());
            }

            cbDepartments.SelectedIndex = 0;
        }

        private void UpdateGUI()
        {
            userControl = new Classes.User();
            userControl.GetAllUsersFromDatabase();

            departmentControl = new Department();
            departmentControl.GetDeparmentsFromDatabase();

            productControl = new Product();
            productControl.GetProductsFromDatabase();

            lbDepartments.Items.Clear();
            cbDepartments.Items.Clear();
            PopulateDepartmentGUI();
            cbDepartments.SelectedIndex = 0;
        }
    }
}
