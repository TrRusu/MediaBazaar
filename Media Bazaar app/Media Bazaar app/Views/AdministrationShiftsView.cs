using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Media_Bazaar_app.Classes;
using Media_Bazaar_app.Views;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Media_Bazaar_app
{

    public partial class AdministrationShiftsView : Form
    {
        private int weekNumber;
        private int weekDay;
        private string shift;
        private string department;
        private string selected;
        private ScheduleLogic calendarControl;

        public AdministrationShiftsView()
        {
            InitializeComponent();
            GUISetup();
        }

        private void cbWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbMorning.Items.Clear();
            lbEvening.Items.Clear();
            lbAfternoon.Items.Clear();
            weekNumber = Convert.ToInt32(cbWeek.Text.ToString());
            LoadDates();
            lbInfo.Items.Clear();
        }

        private void lblMonday_Click(object sender, EventArgs e)
        {
            weekDay = 1;
            WeekDayLabelColoring();
        }

        private void lblTuesday_Click(object sender, EventArgs e)
        {
            weekDay = 2;
            WeekDayLabelColoring();
        }

        private void lblWednesday_Click(object sender, EventArgs e)
        {
            weekDay = 3;
            WeekDayLabelColoring();
        }

        private void lblThursday_Click(object sender, EventArgs e)
        {
            weekDay = 4;
            WeekDayLabelColoring();
        }

        private void lblFriday_Click(object sender, EventArgs e)
        {
            weekDay = 5;
            WeekDayLabelColoring();
        }

        private void lblSaturday_Click(object sender, EventArgs e)
        {
            weekDay = 6;
            WeekDayLabelColoring();
        }

        private void lblSunday_Click(object sender, EventArgs e)
        {
            weekDay = 7;
            WeekDayLabelColoring();
        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            department = cbDepartment.Text;
            PopulateShiftsListboxes();
            PopulateUserListbox();
            lbInfo.Items.Clear();
        }

        private void lbMorning_SelectedIndexChanged(object sender, EventArgs e)
        {
            shift = "Morning";
            if (lbMorning.SelectedIndex != -1)
            {
                string name = lbMorning.SelectedItem.ToString();
                GetUserOverview(name);
            }
        }

        private void lbAfternoon_SelectedIndexChanged(object sender, EventArgs e)
        {
            shift = "Afternoon";
            if (lbAfternoon.SelectedIndex != -1)
            {
                string name = lbAfternoon.SelectedItem.ToString();
                GetUserOverview(name);
            }
        }

        private void lbEvening_SelectedIndexChanged(object sender, EventArgs e)
        {
            shift = "Evening";
            if (lbEvening.SelectedIndex != -1)
            {
                string name = lbEvening.SelectedItem.ToString();
                GetUserOverview(name);
            }
        }

        private void lbMorning_Click(object sender, EventArgs e)
        {
            shift = "Morning";
            ShiftListboxesBehaviour(shift);
        }

        private void lbAfternoon_Click(object sender, EventArgs e)
        {
            shift = "Afternoon";
            ShiftListboxesBehaviour(shift);
        }

        private void lbEvening_Click(object sender, EventArgs e)
        {
            shift = "Evening";
            ShiftListboxesBehaviour(shift);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (lbAccounts.SelectedIndex != -1)
            {
                if (lbMorning.BackColor == Color.Maroon)
                {
                    MorningShiftAssignment();
                }
                else if (lbAfternoon.BackColor == Color.Maroon)
                {
                    AfternoonShiftAssignment();              
                }
                else
                {
                    EveningShiftAssignment();
                }
            }
            else
            {
                MessageBox.Show("Please select an account");
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {

            if (lbMorning.BackColor == Color.Maroon)
            {
                MorningShiftRemoval();
            }
            else if (lbAfternoon.BackColor == Color.Maroon)
            {
                AfternoonShiftRemoval();
            }

            else if (lbEvening.BackColor == Color.Maroon)
            {
                EveningShiftRemoval();
            }
        }

        private void lbAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAccounts.SelectedIndex != -1)
            {
                selected = lbAccounts.SelectedItem.ToString();
                GetUserOverview(selected);
            }
        }

        private void cbAllEmp_CheckedChanged(object sender, EventArgs e)
        {
            PopulateUserListbox();
        }

        private void PopulateUserListbox()
        {
            lbAccounts.Items.Clear();
            if (cbAllEmp.Checked)
            {
                foreach (User employee in calendarControl.ReturnLocalUserList())
                {
                    lbAccounts.Items.Add(employee.ToString());
                }
            }
            else
            {
                foreach (User employee in calendarControl.ReturnLocalUserListByDepartment(cbDepartment.SelectedItem.ToString()))
                {
                    lbAccounts.Items.Add(employee.ToString());
                }
            }

        }

        private void PopulateDepartmentComboBox()
        {
            foreach (Department department in calendarControl.ReturnLocalDepartmentList())
            {
                cbDepartment.Items.Add(department.ToString());
            }
        }

        private void PopulateShiftsListboxes()
        {
            lbMorning.Items.Clear();
            lbAfternoon.Items.Clear();
            lbEvening.Items.Clear();

            foreach (Shift shift in calendarControl.ReturnShiftsByType(weekNumber, weekDay, cbDepartment.Text, "Morning"))
            {
                lbMorning.Items.Add(shift.Name);
            }

            foreach (Shift shift in calendarControl.ReturnShiftsByType(weekNumber, weekDay, cbDepartment.Text, "Afternoon"))
            {
                lbAfternoon.Items.Add(shift.Name);
            }

            foreach (Shift shift in calendarControl.ReturnShiftsByType(weekNumber, weekDay, cbDepartment.Text, "Evening"))
            {
                lbEvening.Items.Add(shift.Name);
            }
        }

        private void MorningShiftAssignment()
        {
            if (lbMorning.Items.Contains(lbAccounts.SelectedItem.ToString()) == false)
            {
                if (calendarControl.ManualScheduleMorningShiftAssignment(weekNumber, lbAccounts.SelectedItem.ToString(), cbDepartment.Text, "Morning", weekDay))
                {
                    lbMorning.Items.Add(lbAccounts.SelectedItem.ToString());
                    lbInfo.Items.Clear();
                }
            }
            else
            {
                MessageBox.Show("Employee already assigned to this shift");
            }
        }

        private void AfternoonShiftAssignment()
        {
            if (lbAfternoon.Items.Contains(lbAccounts.SelectedItem.ToString()) == false)
            {
                if (calendarControl.ManualScheduleAfternoonShiftAssignment(weekNumber, lbAccounts.SelectedItem.ToString(), cbDepartment.Text, "Afternoon", weekDay))
                {
                    lbAfternoon.Items.Add(lbAccounts.SelectedItem.ToString());
                    lbInfo.Items.Clear();
                }
            }
            else
            {
                MessageBox.Show("Employee already assigned to this shift");
            }
        }

        private void EveningShiftAssignment()
        {
            if (lbEvening.Items.Contains(lbAccounts.SelectedItem.ToString()) == false)
            {
                if (calendarControl.ManualScheduleEveningShiftAssignment(weekNumber, lbAccounts.SelectedItem.ToString(), cbDepartment.Text, "Evening", weekDay))
                {
                    lbEvening.Items.Add(lbAccounts.SelectedItem.ToString());
                    lbInfo.Items.Clear();
                }
            }
            else
            {
                MessageBox.Show("Employee already assigned to this shift");
            }
        }

        private void MorningShiftRemoval()
        {
            if (lbMorning.SelectedIndex == -1)
            {
                MessageBox.Show("Please select account");
            }
            else
            {
                calendarControl.RemoveShift(weekNumber, lbMorning.SelectedItem.ToString(), department, shift, weekDay);
                lbMorning.Items.Remove(lbMorning.SelectedItem.ToString());
                lbInfo.Items.Clear();
            }
        }

        private void AfternoonShiftRemoval()
        {
            if (lbAfternoon.SelectedIndex == -1)
            {
                MessageBox.Show("Please select account");
            }
            else
            {
                calendarControl.RemoveShift(weekNumber, lbAfternoon.SelectedItem.ToString(), department, shift, weekDay);
                lbAfternoon.Items.Remove(lbAfternoon.SelectedItem.ToString());
                lbInfo.Items.Clear();
            }
        }

        private void EveningShiftRemoval()
        {
            if (lbEvening.SelectedIndex == -1)
            {
                MessageBox.Show("Please select account");
            }
            else
            {
                calendarControl.RemoveShift(weekNumber, lbMorning.SelectedItem.ToString(), department, shift, weekDay);
                lbEvening.Items.Remove(lbEvening.SelectedItem.ToString());
                lbInfo.Items.Clear();
            }
        }

        private void GetUserOverview(string selected)
        {
            lbInfo.Items.Clear();
            foreach (string details in calendarControl.FetchEmployeeOverview(selected, weekNumber, weekDay))
            {
                lbInfo.Items.Add(details);
            }
        }

        private void ShiftListboxesBehaviour(string shift)
        {
            if(shift == "Morning")
            {
                lbAfternoon.SelectedIndex = -1;
                lbEvening.SelectedIndex = -1;
                lbMorning.BackColor = Color.Maroon;
                lbMorning.ForeColor = Color.White;
                lbAfternoon.BackColor = Color.White;
                lbAfternoon.ForeColor = Color.Black;
                lbEvening.BackColor = Color.White;
                lbEvening.ForeColor = Color.Black;
            }
            else if( shift == "Afternoon")
            {
                lbMorning.SelectedIndex = -1;
                lbEvening.SelectedIndex = -1;
                lbAfternoon.BackColor = Color.Maroon;
                lbAfternoon.ForeColor = Color.White;
                lbMorning.BackColor = Color.White;
                lbMorning.ForeColor = Color.Black;
                lbEvening.BackColor = Color.White;
                lbEvening.ForeColor = Color.Black;
            }
            else
            {
                lbMorning.SelectedIndex = -1;
                lbAfternoon.SelectedIndex = -1;
                lbEvening.BackColor = Color.Maroon;
                lbEvening.ForeColor = Color.White;
                lbAfternoon.BackColor = Color.White;
                lbAfternoon.ForeColor = Color.Black;
                lbMorning.BackColor = Color.White;
                lbMorning.ForeColor = Color.Black;
            }
        }

        private int ConvertDateToWeekNumber()
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        private void ConvertDateToWeekDayNumber()
        {
            string wk = DateTime.Today.DayOfWeek.ToString();

            if(wk == "Monday")
            {
                weekDay = 1;
            }
            else if (wk == "Tuesday")
            {
                weekDay = 2;
            }
            else if (wk == "Wednesday")
            {
                weekDay = 3;
            }
            if (wk == "Thursday")
            {
                weekDay = 4;
            }
            if (wk == "Friday")
            {
                weekDay = 5;
            }
            if (wk == "Saturday")
            {
                weekDay = 6;
            }
            if (wk == "Sunday")
            {
                weekDay = 7;
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
                lblDateFrom.Text = "January 6, 20209";
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
                lblDateFrom.Text = "May 4, 20209";
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

        private void WeekDayLabelColoring()
        {
            if (weekDay == 1)
            {
                PopulateShiftsListboxes();
                lblMonday.ForeColor = Color.FromArgb(7, 173, 135);
                lblTuesday.ForeColor = Color.White;
                lblWednesday.ForeColor = Color.White;
                lblThursday.ForeColor = Color.White;
                lblFriday.ForeColor = Color.White;
                lblSaturday.ForeColor = Color.White;
                lblSunday.ForeColor = Color.White;
                lbInfo.Items.Clear();
            }
            else if (weekDay == 2)
            {
                PopulateShiftsListboxes();
                lblMonday.ForeColor = Color.White;
                lblTuesday.ForeColor = Color.FromArgb(7, 173, 135);
                lblWednesday.ForeColor = Color.White;
                lblThursday.ForeColor = Color.White;
                lblFriday.ForeColor = Color.White;
                lblSaturday.ForeColor = Color.White;
                lblSunday.ForeColor = Color.White;
                lbInfo.Items.Clear();
            }
            else if (weekDay == 3)
            {
                PopulateShiftsListboxes();
                lblMonday.ForeColor = Color.White;
                lblTuesday.ForeColor = Color.White;
                lblWednesday.ForeColor = Color.FromArgb(7, 173, 135);
                lblThursday.ForeColor = Color.White;
                lblFriday.ForeColor = Color.White;
                lblSaturday.ForeColor = Color.White;
                lblSunday.ForeColor = Color.White;
                lbInfo.Items.Clear();
            }
            else if (weekDay == 4)
            {
                PopulateShiftsListboxes();
                lblMonday.ForeColor = Color.White;
                lblTuesday.ForeColor = Color.White;
                lblWednesday.ForeColor = Color.White;
                lblThursday.ForeColor = Color.FromArgb(7, 173, 135);
                lblFriday.ForeColor = Color.White;
                lblSaturday.ForeColor = Color.White;
                lblSunday.ForeColor = Color.White;
                lbInfo.Items.Clear();
            }

            else if (weekDay == 5)
            {
                PopulateShiftsListboxes();
                lblMonday.ForeColor = Color.White;
                lblTuesday.ForeColor = Color.White;
                lblWednesday.ForeColor = Color.White;
                lblThursday.ForeColor = Color.White;
                lblFriday.ForeColor = Color.FromArgb(7, 173, 135);
                lblSaturday.ForeColor = Color.White;
                lblSunday.ForeColor = Color.White;
                lbInfo.Items.Clear();
            }

            else if (weekDay == 6)
            {
                PopulateShiftsListboxes();
                lblMonday.ForeColor = Color.White;
                lblTuesday.ForeColor = Color.White;
                lblWednesday.ForeColor = Color.White;
                lblThursday.ForeColor = Color.White;
                lblFriday.ForeColor = Color.White;
                lblSaturday.ForeColor = Color.FromArgb(7, 173, 135);
                lblSunday.ForeColor = Color.White;
                lbInfo.Items.Clear();
            }
            else
            {
                PopulateShiftsListboxes();
                lblMonday.ForeColor = Color.White;
                lblTuesday.ForeColor = Color.White;
                lblWednesday.ForeColor = Color.White;
                lblThursday.ForeColor = Color.White;
                lblFriday.ForeColor = Color.White;
                lblSaturday.ForeColor = Color.White;
                lblSunday.ForeColor = Color.FromArgb(7, 173, 135);
                lbInfo.Items.Clear();
            }
        }

        private void GUISetup()

        {
            calendarControl = new ScheduleLogic("Administration");

            PopulateDepartmentComboBox();

            cbDepartment.SelectedIndex = 0;
            department = cbDepartment.SelectedItem.ToString();

            PopulateUserListbox();

            weekNumber = ConvertDateToWeekNumber();
            cbWeek.Text = weekNumber.ToString();
            ConvertDateToWeekDayNumber();
            WeekDayLabelColoring();
        }
    }
}





