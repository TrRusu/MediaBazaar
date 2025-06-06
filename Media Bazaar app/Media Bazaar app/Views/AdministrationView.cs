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
    public partial class AdministrationView : Form
    {
        Form activeForm;

        public AdministrationView()
        {
            InitializeComponent();
            LoadGUI();
        }

        private void AdministrationView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginView f6 = new LoginView();
            f6.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSchedule_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnEmpl_Click_1(object sender, EventArgs e)
        {
            AdministrationEmployeeView f1 = new AdministrationEmployeeView();
            openChildForm(f1);
        }

        private void btnProducts_Click_1(object sender, EventArgs e)
        {
            AdministrationProductsView f3 = new AdministrationProductsView();
            openChildForm(f3);
        }

        private void btnMngDep_Click_1(object sender, EventArgs e)
        {
            AdministrationCreateDepartmentView f4 = new AdministrationCreateDepartmentView();
            openChildForm(f4);
        }

        private void btnMessages_Click_1(object sender, EventArgs e)
        {
            AdministrationMessages f5 = new AdministrationMessages();
            openChildForm(f5);
        }

        private void btnOverview_Click_1(object sender, EventArgs e)
        {
            AdministrationOverviewView f5 = new AdministrationOverviewView();
            openChildForm(f5);
        }

        private void btnScheduleEditor_Click(object sender, EventArgs e)
        {
            AdministrationShiftsView f2 = new AdministrationShiftsView();
            openChildForm(f2);
        }

        private void btnAutoSchedule_Click(object sender, EventArgs e)
        {
            ScheduleOverview so = new ScheduleOverview();
            openChildForm(so);
        }

        private void btnHoliday_Click(object sender, EventArgs e)
        {
            AdministrationVacationRequestView vr = new AdministrationVacationRequestView();
            openChildForm(vr);
        }

        private void LoadGUI()
        {
            this.Width = 1392;
            this.Height = 782;
            panel1.Visible = false;
        }

        private void openChildForm(Form childForm)
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

        private void hideSubMenu()
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }
    }
}
