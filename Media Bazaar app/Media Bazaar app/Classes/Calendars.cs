using Media_Bazaar_app.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Media_Bazaar_app.Classes
{
    public class Calendars
    {
        readonly private string connectionString = "Server=studmysql01.fhict.local;Uid=dbi438993;Database=dbi438993;Pwd=blabla;";

        private readonly List<Shifts> entries = new List<Shifts>();
        private readonly List<Users> users = new List<Users>();
        private readonly List<Shifts> morning = new List<Shifts>();
        private readonly List<Shifts> afternoon = new List<Shifts>();
        private readonly List<Shifts> evening = new List<Shifts>();
        private readonly List<Shifts> shiftOverview = new List<Shifts>();
        private readonly List<string> morningOverview = new List<string>();
        private readonly List<string> afternoonOverview = new List<string>();
        private readonly List<string> eveningOverview = new List<string>();

        public Calendars() { }

        public void GetCalendarEntries()
        {
            string query = "SELECT * FROM schedule";
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sendCommand = new MySqlCommand(query, sqlConnection)
            {
                CommandTimeout = 60
            };

            try
            {
                sqlConnection.Open();
                MySqlDataReader reader = sendCommand.ExecuteReader();

                while (reader.Read())
                {
                    entries.Add(new Shifts(reader[2].ToString(), Convert.ToInt32(reader[5].ToString()), Convert.ToInt32(reader[1].ToString()), reader[4].ToString(), reader[3].ToString(), reader[6].ToString(), reader[7].ToString()));
                }
            }
            catch
            {

            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void GetUsersForCalendar()
        {
            string query = "SELECT firstName, lastName, contractType, position, department, id FROM user WHERE AccountType ='Floor' AND active='1'";
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sendCommand = new MySqlCommand(query, sqlConnection)
            {
                CommandTimeout = 60
            };

            try
            {
                sqlConnection.Open();
                MySqlDataReader reader = sendCommand.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new Users(Convert.ToInt32(reader[5].ToString()), reader[4].ToString(), reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString()));
                }
            }
            catch
            {

            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<Users> FilterUsers(string department)
        {
            List<Users> filteredUsers = new List<Users>();
            foreach (Users user in users)
            {
                if (user.Department == department)
                {
                    filteredUsers.Add(user);
                }
            }
            return filteredUsers;
        }

        public bool CheckValidity(string selected, int week, int day)
        {
            foreach (Shifts entry in entries)
            {
                if (day == 1)
                {
                    int lastDay = 7;
                    int lastWeek = week - 1;
                    if (selected.Contains(entry.Name))
                    {
                        if (entry.Week == lastWeek)
                        {
                            if (entry.Day == lastDay)
                            {
                                if (entry.ShiftType == "Evening")
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                else if (day == 7)
                {
                    if (selected.Contains(entry.Name))
                    {
                        if (entry.Week == week)
                        {
                            if (entry.Day == day - 1)
                            {
                                if (entry.ShiftType == "Evening")
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (selected.Contains(entry.Name))
                    {
                        if (entry.Week == week)
                        {
                            if (entry.Day == day - 1)
                            {
                                if (entry.ShiftType == "Evening")
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool CheckValidityReverse(string selected, int week, int day)
        {
            foreach (Shifts entry in entries)
            {
                if (day == 1)
                {
                    int newDay = 2;
                    if (selected.Contains(entry.Name))
                    {
                        if (entry.Week == week)
                        {
                            if (entry.Day == newDay)
                            {
                                if (entry.ShiftType == "Morning")
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                else if (day == 7)
                {



                    int nextDay = 1;
                    int nextWeek = week + 1;
                    if (selected.Contains(entry.Name))
                    {
                        if (entry.Week == nextWeek)
                        {
                            if (entry.Day == nextDay)
                            {
                                if (entry.ShiftType == "Morning")
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (selected.Contains(entry.Name))
                    {
                        if (entry.Week == week)
                        {
                            if (entry.Day == day + 1)
                            {
                                if (entry.ShiftType == "Morning")
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool HasReachedLimit(string selected, int week)
        {
            foreach (Shifts shift in entries)
            {
                if (shift.Week == week)
                {
                    if (shift.Name == selected)
                    {
                        if (shift.ContractType == "Full-Time 1.0 fte (40h)")
                        {
                            if (CalculateShifts(selected, week) > 36)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Full-Time 0.9 fte (36h)")
                        {
                            if (CalculateShifts(selected, week) > 32)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Part-Time 0.8 fte (32h)")
                        {
                            if (CalculateShifts(selected, week) > 28)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Part-Time 0.7 fte (28h)")
                        {
                            if (CalculateShifts(selected, week) > 24)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Part-Time 0.6 fte (24h)")
                        {
                            if (CalculateShifts(selected, week) > 20)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Part-Time 0.5 fte (20h)")
                        {
                            if (CalculateShifts(selected, week) > 16)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Part-Time 0.4 fte (16h)")
                        {
                            if (CalculateShifts(selected, week) > 12)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Part-Time 0.3 fte (12h)")
                        {
                            if (CalculateShifts(selected, week) > 8)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Part-Time 0.2 fte (8h)")
                        {
                            if (CalculateShifts(selected, week) > 4)
                            {
                                return true;
                            }
                        }
                        else if (shift.ContractType == "Part-Time 0.1 fte (4h)")
                        {
                            if (CalculateShifts(selected, week) > 0)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public void AddToLocalEntries(Shifts shift)
        {
            entries.Add(shift);
        }

        public void RemoveFromLocalEntries(int week, string name, string department, string sh, int day)
        {
            for (int i = 0; i < entries.Count(); i++)
            {
                if (entries[i].Week == week)
                {
                    if (entries[i].Name == name)
                    {
                        if (entries[i].Department == department)
                        {
                            if (entries[i].Day == day)
                            {
                                if (entries[i].ShiftType == sh)
                                {
                                    entries.Remove(entries[i]);
                                }
                            }
                        }
                    }
                }
            }
        }

        public List<Shifts> GetMorningShifts(int week, int day, string department)
        {
            morning.Clear();

            foreach (Shifts shift in entries)
            {
                if (shift.Department == department)
                {
                    if (shift.Week == week)
                    {
                        if (shift.Day == day)
                        {
                            if (shift.ShiftType == "Morning")
                            {
                                morning.Add(shift);
                            }
                        }
                    }
                }
            }
            return morning;
        }

        public List<Shifts> GetAfternoonShifts(int week, int day, string department)
        {
            afternoon.Clear();

            foreach (Shifts shift in entries)
            {
                if (shift.Department == department)
                {
                    if (shift.Week == week)
                    {
                        if (shift.Day == day)
                        {
                            if (shift.ShiftType == "Afternoon")
                            {
                                afternoon.Add(shift);
                            }
                        }
                    }
                }
            }
            return afternoon;
        }

        public List<Shifts> GetEveningShits(int week, int day, string department)
        {
            evening.Clear();

            foreach (Shifts shift in entries)
            {
                if (shift.Department == department)
                {
                    if (shift.Week == week)
                    {
                        if (shift.Day == day)
                        {
                            if (shift.ShiftType == "Evening")
                            {
                                evening.Add(shift);
                            }
                        }
                    }
                }
            }
            return evening;
        }

        public List<Shifts> GetScheduleOverview(int weekNo, string department)
        {
            shiftOverview.Clear();
            string query = "SELECT Shift, Position FROM schedule WHERE Week= @weekNo AND Department= @department";
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sendCommand = new MySqlCommand(query, sqlConnection)
            {
                CommandTimeout = 60
            };
            sendCommand.Parameters.AddWithValue("weekNo", weekNo);
            sendCommand.Parameters.AddWithValue("department", department);

            try
            {
                sqlConnection.Open();
                MySqlDataReader reader = sendCommand.ExecuteReader();

                while (reader.Read())
                {
                    shiftOverview.Add(new Shifts(reader[0].ToString(), reader[1].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
            return shiftOverview;
        }

        public List<string> GetMorningOverview()
        {
            morningOverview.Clear();
            int totalSecurity = 0;
            int totalSales = 0;
            int totalCashiers = 0;
            int totalDepot = 0;

            foreach (Shifts shift in shiftOverview)
            {
                if (shift.ShiftType == "Morning")
                {
                    if (shift.Position == "Cashier")
                    {
   
                            totalCashiers++;
                    }
                    else if (shift.Position == "Sales Agent")
                    {

                            totalSales++;

                    }
                    else if (shift.Position == "Security Guard")
                    {

                            totalSecurity++;
                    }
                    else if (shift.Position == "Depot Worker")
                    {

                            totalDepot++;

                    }
                }
            }
            morningOverview.Add("Cashiers - " + totalCashiers.ToString());
            morningOverview.Add("Sales Agents - " + totalSales.ToString());
            morningOverview.Add("Security Guards - " + totalSecurity.ToString());
            morningOverview.Add("Depot Workers - " + totalDepot.ToString());
            return morningOverview;
        }

        public List<string> GetAfternoonOverview()
        {
            afternoonOverview.Clear();
            int totalSecurity = 0;
            int totalSales = 0;
            int totalCashiers = 0;
            int totalDepot = 0;

            foreach (Shifts shift in shiftOverview)
            {
                if (shift.ShiftType == "Afternoon")
                {
                    if (shift.Position == "Cashier")
                    {
                        totalCashiers++;
                    }
                    else if (shift.Position == "Sales Agent")
                    {
                        totalSales++;
                    }
                    else if (shift.Position == "Security Guard")
                    {
                        totalSecurity++;
                    }
                    else if (shift.Position == "Depot Worker")
                    {
                        totalDepot++;
                    }
                }
            }
            afternoonOverview.Add("Cashiers - " + totalCashiers.ToString());
            afternoonOverview.Add("Sales Agents - " + totalSales.ToString());
            afternoonOverview.Add("Security Guards - " + totalSecurity.ToString());
            afternoonOverview.Add("Depot Workers - " + totalDepot.ToString());
            return afternoonOverview;
        }

        public List<string> GetEveningOverview()
        {
            eveningOverview.Clear();
            int totalSecurity = 0;
            int totalSales = 0;
            int totalCashiers = 0;
            int totalDepot = 0;

            foreach (Shifts shift in shiftOverview)
            {
                if (shift.ShiftType == "Evening")
                {
                    if (shift.Position == "Cashier")
                    {
                        totalCashiers++;
                    }
                    else if (shift.Position == "Sales Agent")
                    {
                        totalSales++;
                    }
                    else if (shift.Position == "Security Guard")
                    {
                        totalSecurity++;
                    }
                    else if (shift.Position == "Depot Worker")
                    {
                        totalDepot++;
                    }
                }
            }
            eveningOverview.Add("Cashiers - " + totalCashiers.ToString());
            eveningOverview.Add("Sales Agents - " + totalSales.ToString());
            eveningOverview.Add("Security Guards - " + totalSecurity.ToString());
            eveningOverview.Add("Depot Workers - " + totalDepot.ToString());
            return eveningOverview;
        }

        public string GetDepartment(string selected)
        {
            string department = null;

            foreach (Users user in users)
            {
                string fullName = user.FirstName + " " + user.LastName;

                if (selected.Contains(fullName))
                {
                    department = user.Department;
                }
            }

            return department;
        }


        public string GetPosition(string selected)
        {
            string position = null;

            foreach (Users user in users)
            {
                string fullName = user.FirstName + " " + user.LastName;

                if (selected.Contains(fullName))
                {
                    position = user.Position;
                }
            }
            return position;
        }

        public string GetContract(string selected)
        {
            string contractType = null;
            foreach (Users user in users)
            {
                string fullName = user.FirstName + " " + user.LastName;

                if (selected.Contains(fullName))
                {
                    contractType = user.ContractType;
                }
            }
            return contractType;
        }

        public List<string> GetEmployeeInfo(string selected)
        {
            List<string> details = new List<string>();

            foreach (Users user in users)
            {
                string fullName = user.FirstName + " " + user.LastName;
                if (selected == fullName)
                {
                    details.Add("Contract: " + user.ContractType);
                    details.Add("Position: " + user.Position);
                }
            }

            return details;
        }

        public int CalculateShifts(string name, int week)
        {
            int day = 0;
            int totalHours;
            
            foreach(Shifts shift in entries)
            {
                if (shift.Name == name && shift.Week == week)
                {
                    day++;
                }
            }

            totalHours = day * 4;
            return totalHours;
        }

    }
}

