using Media_Bazaar_app.Classes;
using Media_Bazaar_app.Views;
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

namespace Media_Bazaar_app
{
    public partial class ScheduleOverview : Form
    {
        private int weekNumber;
        private int dayMeter = 0;
        private Department departmentControl;
        private Shift shiftControl;
        private ScheduleLogic automatedSchedule;
        private ScheduleMeter scheduleMeter;

        public ScheduleOverview()
        {
            InitializeComponent();
            shiftControl = new Shift();
            shiftControl.GetShiftsOverview(weekNumber, cbDepartment.Text);
            PopulateComboBoxes();
            SetScheduleGUI();
            UpdateListboxes();
            LoadDates();
        }

        private void cbWeekNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            shiftControl.GetShiftsOverview(weekNumber, cbDepartment.Text);
            UpdateListboxes();
            weekNumber = Convert.ToInt32(cbWeekNumber.Text.ToString());
            LoadDates();
            SetScheduleGUI();
            MeterColor();

        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            shiftControl.GetShiftsOverview(weekNumber, cbDepartment.Text);
            UpdateListboxes();
            SetScheduleGUI();
            MeterColor();          
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (dayMeter < 7)
            {

                if (dayMeter == 0)
                {
                    dayMeter++;
                    scheduleMeter.SaveMeterValue(Convert.ToInt32(cbWeekNumber.Text), cbDepartment.Text, dayMeter);

                }
                else
                {
                    dayMeter++;
                    scheduleMeter.UpdateMeterValue(Convert.ToInt32(cbWeekNumber.Text), cbDepartment.Text, dayMeter);
                }
                GenerateSchedule(dayMeter);
                MeterColor();
                shiftControl.GetShiftsOverview(weekNumber, cbDepartment.Text);
                UpdateListboxes();
                if (dayMeter > 6)
                {
                    btnGenerate.Visible = false;
                    btnWeekSchedule.Visible = false;
                }
                else
                {
                    btnGenerate.Visible = true;
                    btnWeekSchedule.Visible = true;
                }
            }
        }

        private void MeterColor()
        {
            if(dayMeter == 0)
            {
                pnl1.BackColor = Color.Maroon;
                pnl2.BackColor = Color.Maroon;
                pnl3.BackColor = Color.Maroon;
                pnl4.BackColor = Color.Maroon;
                pnl5.BackColor = Color.Maroon;
                pnl6.BackColor = Color.Maroon;
                pnl7.BackColor = Color.Maroon;
            }

            if(dayMeter == 1)
            {
                pnl1.BackColor = Color.DarkGreen;
                pnl2.BackColor = Color.Maroon;
                pnl3.BackColor = Color.Maroon;
                pnl4.BackColor = Color.Maroon;
                pnl5.BackColor = Color.Maroon;
                pnl6.BackColor = Color.Maroon;
                pnl7.BackColor = Color.Maroon;
            }
            if (dayMeter == 2)
            {
                pnl1.BackColor = Color.DarkGreen;
                pnl2.BackColor = Color.DarkGreen;
                pnl3.BackColor = Color.Maroon;
                pnl4.BackColor = Color.Maroon;
                pnl5.BackColor = Color.Maroon;
                pnl6.BackColor = Color.Maroon;
                pnl7.BackColor = Color.Maroon;
            }
            if (dayMeter == 3)
            {
                pnl1.BackColor = Color.DarkGreen;
                pnl2.BackColor = Color.DarkGreen;
                pnl3.BackColor = Color.DarkGreen;
                pnl4.BackColor = Color.Maroon;
                pnl5.BackColor = Color.Maroon;
                pnl6.BackColor = Color.Maroon;
                pnl7.BackColor = Color.Maroon;
            }
            if (dayMeter == 4)
            {
                pnl1.BackColor = Color.DarkGreen;
                pnl2.BackColor = Color.DarkGreen;
                pnl3.BackColor = Color.DarkGreen;
                pnl4.BackColor = Color.DarkGreen;
                pnl5.BackColor = Color.Maroon;
                pnl6.BackColor = Color.Maroon;
                pnl7.BackColor = Color.Maroon;
            }
            if (dayMeter == 5)
            {
                pnl1.BackColor = Color.DarkGreen;
                pnl2.BackColor = Color.DarkGreen;
                pnl3.BackColor = Color.DarkGreen;
                pnl4.BackColor = Color.DarkGreen;
                pnl5.BackColor = Color.DarkGreen;
                pnl6.BackColor = Color.Maroon;
                pnl7.BackColor = Color.Maroon;
            }
            if (dayMeter == 6)
            {
                pnl1.BackColor = Color.DarkGreen;
                pnl2.BackColor = Color.DarkGreen;
                pnl3.BackColor = Color.DarkGreen;
                pnl4.BackColor = Color.DarkGreen;
                pnl5.BackColor = Color.DarkGreen;
                pnl6.BackColor = Color.DarkGreen;
                pnl7.BackColor = Color.Maroon;
            }
            if (dayMeter == 7)
            {
                pnl1.BackColor = Color.DarkGreen;
                pnl2.BackColor = Color.DarkGreen;
                pnl3.BackColor = Color.DarkGreen;
                pnl4.BackColor = Color.DarkGreen;
                pnl5.BackColor = Color.DarkGreen;
                pnl6.BackColor = Color.DarkGreen;
                pnl7.BackColor = Color.DarkGreen;
            }
        }

        private void UpdateListboxes()
        { 
            lbAfternoon.Items.Clear();
            lbEvening.Items.Clear();
            lbMorning.Items.Clear();
            foreach (string s in shiftControl.GetMorningOverview())
            {
                lbMorning.Items.Add(s);
            }

            foreach (string s in shiftControl.GetAfternoonOverview())
            {
                lbAfternoon.Items.Add(s);
            }

            foreach (string s in shiftControl.GetEveningOverview())
            {
                lbEvening.Items.Add(s);
            }
        }

        private int GetWeekNumber()
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        private void GenerateSchedule(int day)
        {
            int morningCashier = Convert.ToInt32(tbMorningCashier.Text);
            int morningSales = Convert.ToInt32(tbMorningSalesA.Text);
            int morningDepot = Convert.ToInt32(tbMorningDepotWorker.Text);
            int morningSecurity = Convert.ToInt32(tbMorningSecurityGuard.Text);

            int afternoonCashier = Convert.ToInt32(tbAfternoonCashier.Text);
            int afternoonSales = Convert.ToInt32(tbAfternoonSalesA.Text);
            int afternoonDepot = Convert.ToInt32(tbAfternoonDepotWorker.Text);
            int afternoonSecurity = Convert.ToInt32(tbAfternoonSecurityGuard.Text);

            int eveningCashier = Convert.ToInt32(tbEveningCashier.Text);
            int eveingSales = Convert.ToInt32(tbEveningSalesA.Text);
            int eveningDepot = Convert.ToInt32(tbEveningDepotWorker.Text);
            int eveingSecurity = Convert.ToInt32(tbEveningSecurityGuard.Text);


            automatedSchedule = new ScheduleLogic(cbDepartment.Text, Convert.ToInt32(cbWeekNumber.Text));
            automatedSchedule.CreateInitialListOfAvailabilitiesForDay(day);
            automatedSchedule.RemoveEmployeesWhoHaveVacation();
            automatedSchedule.RemoveEmployeesWhoHadEveningShiftYesterday();
            automatedSchedule.RemoveEmployeesWhoHaveMorningShiftTomorrow();
            automatedSchedule.RemoveEmployeesWhoHaveReachedLimit();
            automatedSchedule.AutomatedScheduleMorningShiftAssignment(morningCashier, morningSales, morningDepot, morningSecurity);
            automatedSchedule.AutomatedScheduleAfternoonShiftAssignment(afternoonCashier, afternoonSales, afternoonDepot, afternoonSecurity);
            automatedSchedule.AutomatedScheduleEveningShiftAssignment(eveningCashier, eveingSales, eveningDepot, eveingSecurity);

        }

        private void PopulateComboBoxes()
        {
            departmentControl = new Department();
            departmentControl.GetDeparmentsFromDatabase();
            foreach (Department department in departmentControl.ReturnDepartmentLocalList())
            {
                cbDepartment.Items.Add(department.Name);
            }
            weekNumber = GetWeekNumber();
            cbWeekNumber.Text = weekNumber.ToString();
            cbDepartment.SelectedIndex = 0;
        }

        private void SetScheduleGUI()
        {
            scheduleMeter = new ScheduleMeter();
            dayMeter = scheduleMeter.GetMeterValue(Convert.ToInt32(cbWeekNumber.Text), cbDepartment.Text.ToString());
            if (dayMeter > 6)
            {
                btnGenerate.Visible = false;
                btnWeekSchedule.Visible = false;
        
            }
            else
            {
                btnGenerate.Visible = true;
                btnWeekSchedule.Visible = true;
            }
        }

        private void LoadDates()
        {
            if (weekNumber == 1)
            {
                lblDateFrom.Text = "December 30, 2019";
                lblDateTo.Text = "January 5, 2020";
            }

            else if (weekNumber == 2)
            {
                lblDateFrom.Text = "January 6, 2020";
                lblDateTo.Text = "January 12, 2020";
            }

            else if (weekNumber == 3)
            {
                lblDateFrom.Text = "January 13, 2020";
                lblDateTo.Text = "January 19, 2020";
            }
            else if (weekNumber == 4)
            {
                lblDateFrom.Text = "January 20, 2020";
                lblDateTo.Text = "January 26, 2020";
            }
            else if (weekNumber == 5)
            {
                lblDateFrom.Text = "January 27, 2020";
                lblDateTo.Text = "February 2, 2020";
            }
            else if (weekNumber == 6)
            {
                lblDateFrom.Text = "February 3, 2020";
                lblDateTo.Text = "February 9, 2020";
            }
            else if (weekNumber == 7)
            {
                lblDateFrom.Text = "February 10, 2020";
                lblDateTo.Text = "February 16, 2020";
            }
            else if (weekNumber == 8)
            {
                lblDateFrom.Text = "February 17, 2020";
                lblDateTo.Text = "February 23, 2020";
            }
            else if (weekNumber == 9)
            {
                lblDateFrom.Text = "February 24, 2020";
                lblDateTo.Text = "March 1, 2020";
            }
            else if (weekNumber == 10)
            {
                lblDateFrom.Text = "March 2, 2020";
                lblDateTo.Text = "March 8, 2020";
            }
            else if (weekNumber == 11)
            {
                lblDateFrom.Text = "March 9, 2020";
                lblDateTo.Text = "March 15, 2020";
            }
            else if (weekNumber == 12)
            {
                lblDateFrom.Text = "March 16, 2020";
                lblDateTo.Text = "March 22, 2020";
            }
            else if (weekNumber == 13)
            {
                lblDateFrom.Text = "March 23, 2020";
                lblDateTo.Text = "March 29, 2020";
            }
            else if (weekNumber == 14)
            {
                lblDateFrom.Text = "March 30, 2020";
                lblDateTo.Text = "April 5, 2020";
            }
            else if (weekNumber == 15)
            {
                lblDateFrom.Text = "April 6, 2020";
                lblDateTo.Text = "April 12, 2020";
            }
            else if (weekNumber == 16)
            {
                lblDateFrom.Text = "April 13, 2020";
                lblDateTo.Text = "April 19, 2020";
            }
            else if (weekNumber == 17)
            {
                lblDateFrom.Text = "April 20, 2020";
                lblDateTo.Text = "April 26, 2020";
            }
            else if (weekNumber == 18)
            {
                lblDateFrom.Text = "April 27, 2020";
                lblDateTo.Text = "May 3, 2020";
            }
            else if (weekNumber == 19)
            {
                lblDateFrom.Text = "May 4, 2020";
                lblDateTo.Text = "May 10, 2020";
            }
            else if (weekNumber == 20)
            {
                lblDateFrom.Text = "May 11, 2020";
                lblDateTo.Text = "May 17, 2020";
            }
            else if (weekNumber == 21)
            {
                lblDateFrom.Text = "May 18, 2020";
                lblDateTo.Text = "May 24, 2020";
            }
            else if (weekNumber == 22)
            {
                lblDateFrom.Text = "May 25, 2020";
                lblDateTo.Text = "May 31, 2020";
            }
            else if (weekNumber == 23)
            {
                lblDateFrom.Text = "June 1, 2020";
                lblDateTo.Text = "June 7, 2020";
            }
            else if (weekNumber == 24)
            {
                lblDateFrom.Text = "June 8, 2020";
                lblDateTo.Text = "June 14, 2020";
            }
            else if (weekNumber == 25)
            {
                lblDateFrom.Text = "June 15, 2020";
                lblDateTo.Text = "June 21, 2020";
            }
            else if (weekNumber == 26)
            {
                lblDateFrom.Text = "June 22, 2020";
                lblDateTo.Text = "June 28, 2020";
            }
            else if (weekNumber == 27)
            {
                lblDateFrom.Text = "June 29, 2020";
                lblDateTo.Text = "July 5, 2020";
            }
            else if (weekNumber == 28)
            {
                lblDateFrom.Text = "July 6, 2020";
                lblDateTo.Text = "July 12, 2020";
            }
            else if (weekNumber == 29)
            {
                lblDateFrom.Text = "July 13, 2020";
                lblDateTo.Text = "July 19, 2020";
            }
            else if (weekNumber == 30)
            {
                lblDateFrom.Text = "July 20, 2020";
                lblDateTo.Text = "July 26, 2020";
            }
            else if (weekNumber == 31)
            {
                lblDateFrom.Text = "July 27, 2020";
                lblDateTo.Text = "August 2, 2020";
            }
            else if (weekNumber == 32)
            {
                lblDateFrom.Text = "August 3, 2020";
                lblDateTo.Text = "August 9, 2020";
            }
            else if (weekNumber == 33)
            {
                lblDateFrom.Text = "August 10, 2020";
                lblDateTo.Text = "August 16, 2020";
            }
            else if (weekNumber == 34)
            {
                lblDateFrom.Text = "August 17, 2020";
                lblDateTo.Text = "August 23, 2020";
            }
            else if (weekNumber == 35)
            {
                lblDateFrom.Text = "August 24, 2020";
                lblDateTo.Text = "August 30, 2020";
            }
            else if (weekNumber == 36)
            {
                lblDateFrom.Text = "August 31, 2020";
                lblDateTo.Text = "September 6, 2020";
            }
            else if (weekNumber == 37)
            {
                lblDateFrom.Text = "September 7, 2020";
                lblDateTo.Text = "September 13, 2020";
            }
            else if (weekNumber == 38)
            {
                lblDateFrom.Text = "September 14, 2020";
                lblDateTo.Text = "September 20, 2020";
            }
            else if (weekNumber == 39)
            {
                lblDateFrom.Text = "September 21, 2020";
                lblDateTo.Text = "September 27, 2020";
            }
            else if (weekNumber == 40)
            {
                lblDateFrom.Text = "September 28, 2020";
                lblDateTo.Text = "October 4, 2020";
            }
            else if (weekNumber == 41)
            {
                lblDateFrom.Text = "October 5, 2020";
                lblDateTo.Text = "October 11, 2020";
            }
            else if (weekNumber == 42)
            {
                lblDateFrom.Text = "October 12, 2020";
                lblDateTo.Text = "October 18, 2020";
            }
            else if (weekNumber == 43)
            {
                lblDateFrom.Text = "October 19, 2020";
                lblDateTo.Text = "October 25, 2020";
            }
            else if (weekNumber == 44)
            {
                lblDateFrom.Text = "October 26, 2020";
                lblDateTo.Text = "November 1, 2020";
            }
            else if (weekNumber == 45)
            {
                lblDateFrom.Text = "November 2, 2020";
                lblDateTo.Text = "November 8, 2020";
            }
            else if (weekNumber == 46)
            {
                lblDateFrom.Text = "November 9, 2020";
                lblDateTo.Text = "November 15, 2020";
            }
            else if (weekNumber == 47)
            {
                lblDateFrom.Text = "November 16, 2020";
                lblDateTo.Text = "November 22, 2020";
            }
            else if (weekNumber == 48)
            {
                lblDateFrom.Text = "November 23, 2020";
                lblDateTo.Text = "November 29, 2020";
            }
            else if (weekNumber == 49)
            {
                lblDateFrom.Text = "November 30, 2020";
                lblDateTo.Text = "December 6, 2020";
            }
            else if (weekNumber == 50)
            {
                lblDateFrom.Text = "December 7, 2020";
                lblDateTo.Text = "December 13, 2020";
            }
            else if (weekNumber == 51)
            {
                lblDateFrom.Text = "December 14, 2020";
                lblDateTo.Text = "December 20, 2020";
            }
            else if (weekNumber == 52)
            {
                lblDateFrom.Text = "December 21, 2020";
                lblDateTo.Text = "December 27, 2020";
            }
            else if (weekNumber == 53)
            {
                lblDateFrom.Text = "December 28, 2020";
                lblDateTo.Text = "January 3, 2021";
            }
        }

        private void btnWeekSchedule_Click(object sender, EventArgs e)
        {
            while (dayMeter < 7)
            {
                if (dayMeter == 0)
                {
                    dayMeter++;
                    scheduleMeter.SaveMeterValue(Convert.ToInt32(cbWeekNumber.Text), cbDepartment.Text, dayMeter);

                }
                else
                {
                    dayMeter++;
                    scheduleMeter.UpdateMeterValue(Convert.ToInt32(cbWeekNumber.Text), cbDepartment.Text, dayMeter);
                }
                GenerateSchedule(dayMeter);
                MeterColor();
                shiftControl.GetShiftsOverview(weekNumber, cbDepartment.Text);
                UpdateListboxes();
                if (dayMeter > 6)
                {
                    btnGenerate.Visible = false;
                    btnWeekSchedule.Visible = false;
                }
                else
                {
                    btnGenerate.Visible = true;
                    btnWeekSchedule.Visible = true;

                }
            }
        }
    }
}
