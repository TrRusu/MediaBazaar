using Media_Bazaar_app.Classes;
using Media_Bazaar_app.Views;
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
    public partial class FloorView : Form
    {
        private User saved;
        private Department departmentControl;
        private Button btn;
        private Form activeForm;

        public FloorView(User user)
        {
            InitializeComponent();
            UpdateGUI(user);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            FloorDepartmentsView f20 = new FloorDepartmentsView(saved, ((Button)sender).Text) ;
            OpenChildForm(f20);
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            HideSubMenu();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            FloorScheduleView f2 = new FloorScheduleView(saved);
            OpenChildForm(f2);
        }

        private void btnMessages_Click(object sender, EventArgs e)
        {
            FloorMessages f3 = new FloorMessages();
            OpenChildForm(f3);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginView f12 = new LoginView();
            f12.Show();
            this.Hide();

        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            FloorCashierView f10 = new FloorCashierView();
            OpenChildForm(f10);
        }

        private void UpdateGUI(User user)
        {
            saved = user;
            int counter = 0;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            departmentControl = new Department();
            departmentControl.GetDeparmentsFromDatabase();

            foreach (Department department in departmentControl.ReturnDepartmentLocalList())
            {
                btn = new Button();
                btn.Click += Btn_Click;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseDownBackColor = Color.Maroon;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 39, 40);
                btn.Font = new Font("Century Gothic", 10.2f, FontStyle.Bold);
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Padding = new Padding(20, 0, 0, 0);
                btn.Name = department.ToString();
                btn.Text = department.ToString();
                btn.Height = 33;
                btn.Parent = pnlSubDepartments;
                btn.Dock = DockStyle.Top;
                counter++;
            }

            if (saved.Position == "Cashier")
            {
                btnSales.Visible = true;
                btnDepartments.Visible = false;
            }


            pnlSubDepartments.Height = 33 * counter;
            label2.Text = "Welcome " + saved.FirstName;
        }

        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)

                activeForm.Hide();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlChildContainer.Controls.Add(childForm);
            pnlChildContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void HideSubMenu()
        {
            if (pnlSubDepartments.Visible == true)
            {
                pnlSubDepartments.Visible = false;
            }
            else
            {
                pnlSubDepartments.Visible = true;
            }
        }
    }
}
