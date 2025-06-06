using Media_Bazaar_app.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Bazaar_app.Views
{
    public partial class AdministrationVacationRequestView : Form
    {

        private Vacation vacationControl;

        public AdministrationVacationRequestView()
        {
            InitializeComponent();
            LoadGUI();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
                int index = lbRequests.SelectedIndex;
                vacationControl.ApproveVacationInDatabase(index);
                PopulateList();
        }

        private void btnDismiss_Click(object sender, EventArgs e)
        {
            int index = lbRequests.SelectedIndex;
            vacationControl.DismissVacationInDatabase(index);
            PopulateList();
        }

        private void PopulateList()
        {
            lbRequests.Items.Clear();
            foreach (Vacation vacation in vacationControl.GetVacationLocalListByWeek(Convert.ToInt32(cbWeekNumber.Text)))
            {
                lbRequests.Items.Add(vacation.ToString());
            }
        }

        private int GetWeekNumber()
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        private void cbWeekNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateList();
        }

        private void LoadGUI()
        {
            vacationControl = new Vacation();
            vacationControl.GetVacationsFromDatabase();
            cbWeekNumber.Text = GetWeekNumber().ToString();
            PopulateList();
        }
    }
}