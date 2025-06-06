using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_app.Classes
{
    public class Shift
    {
        private string tableName = "schedule";

        private DatabaseConnection database;

        private List<string> toSelect;
        private List<string> whereValues;
        private List<string> whereNames;
        private List<string> setColumnName;
        private List<string> setColumnValue;

        private List<Shift> localShifts;

        public int ID
        {
            get;
            private set;
        }

        public int Week
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public string Department
        {
            get;
            private set;
        }

        public string ShiftType
        {
            get;
            private set;
        }

        public int Day
        {
            get;
            private set;
        }

        public string Position
        {
            get;
            private set;
        }

        public string ContractType
        {
            get;
            private set;
        }

        public  Shift() { localShifts = new List<Shift>(); }

        public Shift(int id, string name, int day, int week, string shiftType, string department, string position, string contract)
        {
            this.ID = id;
            this.Week = week;
            this.Name = name;
            this.Department = department;
            this.ShiftType = shiftType;
            this.Day = day;
            this.Position = position;
            this.ContractType = contract;
        }

        public Shift(string shiftType, string position)
        {
            this.ShiftType = shiftType;
            this.Position = position;
        }

        public void GetAllShiftsFromDatabase()
        {
            database = new DatabaseConnection();

            foreach (DataRow reader in database.GetDataFromDatabase(tableName, toSelect, whereValues, whereNames).Rows)
            {
                localShifts.Add(new Shift(Convert.ToInt32(reader[0].ToString()), reader[2].ToString(), Convert.ToInt32(reader[5].ToString()), Convert.ToInt32(reader[1].ToString()), reader[4].ToString(), reader[3].ToString(), reader[6].ToString(), reader[7].ToString()));
            }          
        }

        public List<Shift> GetShiftsOverview(int weekNo, string department)
        {
            localShifts = new List<Shift>();
            database = new DatabaseConnection();
            toSelect = new List<string>()
            {
                "Shift",
                "Position"
            };

            whereValues = new List<string>()
            {
                weekNo.ToString(),
                department
            };

            whereNames = new List<string>()
            {
                "Week",
                "Department"
            };

            foreach (DataRow result in database.GetDataFromDatabase(tableName, toSelect, whereValues, whereNames).Rows)
            {
                localShifts.Add(new Shift(result[0].ToString(), result[1].ToString()));

            }
            return localShifts;
        }

        public void GetShiftsForAutomatedSchedule(string department)
        {
            localShifts = new List<Shift>();
            database = new DatabaseConnection();

            whereValues = new List<string>()
            {
                department,
            };

            whereNames = new List<string>()
            {
                "Department",
            };



            foreach (DataRow reader in database.GetDataFromDatabase(tableName, toSelect, whereValues, whereNames).Rows)
            {
                localShifts.Add(new Shift(Convert.ToInt32(reader[0].ToString()), reader[2].ToString(), Convert.ToInt32(reader[5].ToString()), Convert.ToInt32(reader[1].ToString()), reader[4].ToString(), reader[3].ToString(), reader[6].ToString(), reader[7].ToString()));
            }
        }

        public void RegisterShiftInDatabase(int week, string name, string department, string shift, int day, string position, string contract)
        {

            database = new DatabaseConnection();


            setColumnName = new List<string>()
            {
                "Week",
                "Name",
                "Department",
                "Shift",
                "Day",
                "Position",
                "contractType"
            };

            setColumnValue = new List<string>()
            {
                week.ToString(),
                name,
                department,
                shift,
                day.ToString(),
                position,
                contract
            };

            database.InsertIntoDatabase(tableName, setColumnValue, setColumnName);
            RegisterShiftInLocalList(week, name, department, shift, day, position, contract);
        }

        private void RegisterShiftInLocalList(int week, string name, string department, string shift, int day, string position, string contract)
        {
            int nextID = NextShiftIdFromDatabase();
            localShifts.Add(new Shift(nextID, name, day, week, shift, department, position, contract));
        }

        public void RemoveShiftFromDatabase(int week, string name, string department, string shift, int day)
        {

            database = new DatabaseConnection();

            setColumnValue = new List<string>
            {
                week.ToString(),
                name,
                department,
                shift,
                day.ToString()
            };

            setColumnName = new List<string>()
            {
                "Week",
                "Name",
                "Department",
                "Shift",
                "Day"
            };

            database.DeleteFromDatabase(tableName, setColumnValue, setColumnName);
            RemoveShiftFromLocalList(week, name, department, shift, day);
        }

        private void RemoveShiftFromLocalList(int week, string name, string department, string shift, int day)
        {
            for (int i = 0; i < localShifts.Count; i++)
            {
                if (localShifts[i].Week == week)
                {
                    if (localShifts[i].Name == name)
                    {
                        if (localShifts[i].Department == department)
                        {
                            if (localShifts[i].Day == day)
                            {
                                if (localShifts[i].ShiftType == shift)
                                {
                                    localShifts.Remove(localShifts[i]);
                                }
                            }
                        }
                    }
                }
            }
        }

        public List<Shift> ReturnAllShiftsLocalList()
        {
            return localShifts;
        }

        public List<Shift> FilterShiftLocalListByDepartment(string department)
        {
            List<Shift> shiftsByDepartment = new List<Shift>();

            foreach(Shift shift in localShifts)
            {
                if(shift.Department == department)
                {
                    shiftsByDepartment.Add(shift);
                }
            }
            return shiftsByDepartment;          
        }

        public int NextShiftIdFromDatabase()
        {
            // I subtract 1 because message is already added to database
            return database.GetFromSchema("shift") - 1;
        }

        public List<string> GetMorningOverview()
        {
            List<string> morningOverview = new List<string>();

            int totalSecurity = 0;
            int totalSales = 0;
            int totalCashiers = 0;
            int totalDepot = 0;


            foreach (Shift shift in ReturnAllShiftsLocalList())
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
            List<string> afternoonOverview = new List<string>();

            int totalSecurity = 0;
            int totalSales = 0;
            int totalCashiers = 0;
            int totalDepot = 0;

            foreach (Shift shift in ReturnAllShiftsLocalList())
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
            List<string> eveningOverview = new List<string>();

            int totalSecurity = 0;
            int totalSales = 0;
            int totalCashiers = 0;
            int totalDepot = 0;

            foreach (Shift shift in ReturnAllShiftsLocalList())
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
    }
}
