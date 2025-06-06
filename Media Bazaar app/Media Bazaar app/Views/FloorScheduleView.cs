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
using Media_Bazaar_app.Classes;
using Media_Bazaar_app.Views;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Media_Bazaar_app
{
    public partial class FloorScheduleView : Form
    {
        private int weekNumber;
        private int weekDay;
        private ScheduleLogic calendarControl;

        public FloorScheduleView(User user)
        {
            InitializeComponent();
            GUISetup(user);
        }

        private void cbWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            weekNumber = Convert.ToInt32(cbWeek.Text);
            LoadDates();
            PopulateShiftsListboxes();
        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateShiftsListboxes();
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

        private void PopulateDepartmentComboBox()
        {
            foreach (Department department in calendarControl.ReturnLocalDepartmentList())
            {
                cbDepartment.Items.Add(department.ToString());
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

            if (wk == "Monday")
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
            else if (weekNumber == 7)
            {
                lblDateFrom.Text = "February 17, 2020";
                lblDateTo.Text = "February 23, 2020";
            }
            else if (weekNumber == 8)
            {
                lblDateFrom.Text = "February 24, 2020";
                lblDateTo.Text = "March 1, 2020";
            }
            else if (weekNumber == 9)
            {
                lblDateFrom.Text = "March 2, 2020";
                lblDateTo.Text = "March 8, 2020";
            }
            else if (weekNumber == 10)
            {
                lblDateFrom.Text = "March 9, 2020";
                lblDateTo.Text = "March 15, 2020";
            }
            else if (weekNumber == 11)
            {
                lblDateFrom.Text = "March 16, 2020";
                lblDateTo.Text = "March 22, 2020";
            }
            else if (weekNumber == 12)
            {
                lblDateFrom.Text = "March 23, 2020";
                lblDateTo.Text = "March 29, 2020";
            }
            else if (weekNumber == 13)
            {
                lblDateFrom.Text = "March 30, 2020";
                lblDateTo.Text = "April 5, 2020";
            }
            else if (weekNumber == 14)
            {
                lblDateFrom.Text = "April 6, 2020";
                lblDateTo.Text = "April 12, 2020";
            }
            else if (weekNumber == 15)
            {
                lblDateFrom.Text = "April 13, 2020";
                lblDateTo.Text = "April 19, 2020";
            }
            else if (weekNumber == 16)
            {
                lblDateFrom.Text = "April 20, 2020";
                lblDateTo.Text = "April 26, 2020";
            }
            else if (weekNumber == 17)
            {
                lblDateFrom.Text = "April 27, 2020";
                lblDateTo.Text = "May 3, 2020";
            }
            else if (weekNumber == 18)
            {
                lblDateFrom.Text = "May 4, 20209";
                lblDateTo.Text = "May 10, 2020";
            }
            else if (weekNumber == 19)
            {
                lblDateFrom.Text = "May 11, 2020";
                lblDateTo.Text = "May 17, 2020";
            }
            else if (weekNumber == 20)
            {
                lblDateFrom.Text = "May 18, 2020";
                lblDateTo.Text = "May 24, 2020";
            }
            else if (weekNumber == 21)
            {
                lblDateFrom.Text = "May 25, 2020";
                lblDateTo.Text = "May 31, 2020";
            }
            else if (weekNumber == 22)
            {
                lblDateFrom.Text = "June 1, 2020";
                lblDateTo.Text = "June 7, 2020";
            }
            else if (weekNumber == 23)
            {
                lblDateFrom.Text = "June 8, 2020";
                lblDateTo.Text = "June 14, 2020";
            }
            else if (weekNumber == 24)
            {
                lblDateFrom.Text = "June 15, 2020";
                lblDateTo.Text = "June 21, 2020";
            }
            else if (weekNumber == 25)
            {
                lblDateFrom.Text = "June 22, 2020";
                lblDateTo.Text = "June 28, 2020";
            }
            else if (weekNumber == 26)
            {
                lblDateFrom.Text = "June 29, 2020";
                lblDateTo.Text = "July 5, 2020";
            }
            else if (weekNumber == 27)
            {
                lblDateFrom.Text = "July 6, 2020";
                lblDateTo.Text = "July 12, 2020";
            }
            else if (weekNumber == 28)
            {
                lblDateFrom.Text = "July 13, 2020";
                lblDateTo.Text = "July 19, 2020";
            }
            else if (weekNumber == 29)
            {
                lblDateFrom.Text = "July 20, 2020";
                lblDateTo.Text = "July 26, 2020";
            }
            else if (weekNumber == 30)
            {
                lblDateFrom.Text = "July 27, 2020";
                lblDateTo.Text = "August 2, 2020";
            }
            else if (weekNumber == 31)
            {
                lblDateFrom.Text = "August 3, 2020";
                lblDateTo.Text = "August 9, 2020";
            }
            else if (weekNumber == 32)
            {
                lblDateFrom.Text = "August 10, 2020";
                lblDateTo.Text = "August 16, 2020";
            }
            else if (weekNumber == 33)
            {
                lblDateFrom.Text = "August 17, 2020";
                lblDateTo.Text = "August 23, 2020";
            }
            else if (weekNumber == 34)
            {
                lblDateFrom.Text = "August 24, 2020";
                lblDateTo.Text = "August 30, 2020";
            }
            else if (weekNumber == 35)
            {
                lblDateFrom.Text = "August 31, 2020";
                lblDateTo.Text = "September 6, 2020";
            }
            else if (weekNumber == 36)
            {
                lblDateFrom.Text = "September 7, 2020";
                lblDateTo.Text = "September 13, 2020";
            }
            else if (weekNumber == 37)
            {
                lblDateFrom.Text = "September 14, 2020";
                lblDateTo.Text = "September 20, 2020";
            }
            else if (weekNumber == 38)
            {
                lblDateFrom.Text = "September 21, 2020";
                lblDateTo.Text = "September 27, 2020";
            }
            else if (weekNumber == 39)
            {
                lblDateFrom.Text = "September 28, 2020";
                lblDateTo.Text = "October 4, 2020";
            }
            else if (weekNumber == 40)
            {
                lblDateFrom.Text = "October 5, 2020";
                lblDateTo.Text = "October 11, 2020";
            }
            else if (weekNumber == 41)
            {
                lblDateFrom.Text = "October 12, 2020";
                lblDateTo.Text = "October 18, 2020";
            }
            else if (weekNumber == 42)
            {
                lblDateFrom.Text = "October 19, 2020";
                lblDateTo.Text = "October 25, 2020";
            }
            else if (weekNumber == 43)
            {
                lblDateFrom.Text = "October 26, 2020";
                lblDateTo.Text = "November 1, 2020";
            }
            else if (weekNumber == 44)
            {
                lblDateFrom.Text = "November 2, 2020";
                lblDateTo.Text = "November 8, 2020";
            }
            else if (weekNumber == 45)
            {
                lblDateFrom.Text = "November 9, 20209";
                lblDateTo.Text = "November 15, 2020";
            }
            else if (weekNumber == 46)
            {
                lblDateFrom.Text = "November 16, 2020";
                lblDateTo.Text = "November 22, 2020";
            }
            else if (weekNumber == 47)
            {
                lblDateFrom.Text = "November 23, 2020";
                lblDateTo.Text = "November 29, 2020";
            }
            else if (weekNumber == 48)
            {
                lblDateFrom.Text = "November 30, 2020";
                lblDateTo.Text = "December 6, 2020";
            }
            else if (weekNumber == 49)
            {
                lblDateFrom.Text = "December 7, 2019";
                lblDateTo.Text = "December 13, 2020";
            }
            else if (weekNumber == 50)
            {
                lblDateFrom.Text = "December 14, 2019";
                lblDateTo.Text = "December 20, 2020";
            }
            else if (weekNumber == 51)
            {
                lblDateFrom.Text = "December 21, 2019";
                lblDateTo.Text = "December 27, 2020";
            }
            else if (weekNumber == 52)
            {
                lblDateFrom.Text = "December 28, 2019";
                lblDateTo.Text = "January 3, 2021";
            }
        }

        private void GUISetup(User user)

        {
            calendarControl = new ScheduleLogic("Floor");

            PopulateDepartmentComboBox();

            cbDepartment.Text = user.Department;

            weekNumber = ConvertDateToWeekNumber();
            cbWeek.Text = weekNumber.ToString();
            ConvertDateToWeekDayNumber();
            WeekDayLabelColoring();

            LoadDates();
            WindowState = FormWindowState.Maximized;
        }
    }
}
