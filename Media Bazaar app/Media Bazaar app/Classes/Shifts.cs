using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_app.Classes
{
    public class Shifts
    {
        readonly private string connectionString = "Server=studmysql01.fhict.local;Uid=dbi438993;Database=dbi438993;Pwd=blabla;";

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

        public Shifts() { }

        public Shifts(string name, int day, int week, string shiftType, string department, string position, string contract)
        {
            this.Week = week;
            this.Name = name;
            this.Department = department;
            this.ShiftType = shiftType;
            this.Day = day;
            this.Position = position;
            this.ContractType = contract;
        }

        public Shifts(string shiftType, string position)
        {
            this.ShiftType = shiftType;
            this.Position = position;
        }

        public void AddShift(int week, string name, string department, string shift, int day, string position, string contract)
        {
            string query = "INSERT INTO schedule SET EntryID = NULL, Week = @Week, Name=@Name, Department =@Department, Shift=@Shift, Day=@Day, Position=@Position, contractType=@Contract";

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, conn);
            commandDatabase.Parameters.AddWithValue("Week", week);
            commandDatabase.Parameters.AddWithValue("Name", name);
            commandDatabase.Parameters.AddWithValue("Department", department);
            commandDatabase.Parameters.AddWithValue("Shift", shift);
            commandDatabase.Parameters.AddWithValue("Day", day);
            commandDatabase.Parameters.AddWithValue("Position", position);
            commandDatabase.Parameters.AddWithValue("Contract", contract);
            MySqlDataReader reader;

            try
            {
                conn.Open();
                reader = commandDatabase.ExecuteReader();
            }

            catch
            {

            }
            finally
            {
                conn.Close();
            }

        }

        public void RemoveShift(int week, string name, string department, string shift, int day)
        {
            string query = "DELETE from schedule WHERE Week = @Week AND Name=@Name AND Department =@Department AND Shift=@Shift AND Day=@Day";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, conn);
            commandDatabase.Parameters.AddWithValue("Name", name);
            commandDatabase.Parameters.AddWithValue("Week", week);
            commandDatabase.Parameters.AddWithValue("Day", day);
            commandDatabase.Parameters.AddWithValue("Department", department);
            commandDatabase.Parameters.AddWithValue("Shift", shift);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                conn.Open();
                reader = commandDatabase.ExecuteReader();
            }

            catch
            {

            }
            finally
            {
                conn.Close();
            }

        }

    }
}
