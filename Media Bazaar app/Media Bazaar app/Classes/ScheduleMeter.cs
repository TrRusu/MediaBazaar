using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_app.Classes
{
    class ScheduleMeter
    {
        private string tableName = "schedulemeter";
        private List<string> toSelect;
        private List<string> whereValues;
        private List<string> whereNames;
        private List<string> setColumnName;
        private List<string> setColumnValue;

        private DatabaseConnection database;

        public string Department
        {
            get;
            private set;
        }

        public int Week
        {
            get;
            private set;
        }

        public int Day
        {
            get;
            private set;
        }

        public ScheduleMeter() { }

        public int GetMeterValue(int week, string department)
        {
            database = new DatabaseConnection();
            int meter = 0;

            toSelect = new List<string>()
            {
                "day"
            };

            whereNames = new List<string>()
            {
                "week",
                "department"
            };

            whereValues = new List<string>()
            {
                week.ToString(),
                department
            };

            foreach(DataRow row in database.GetDataFromDatabase(tableName, toSelect, whereValues, whereNames).Rows)
            {
                meter = Convert.ToInt32(row[0].ToString());
            }
           
            return meter;

        }

        public void SaveMeterValue(int week, string department, int meter)
        {

            database = new DatabaseConnection();

            setColumnName = new List<string>()
            {
                "week",
                "day",
                "department"
            };

            setColumnValue = new List<string>()
            {
                week.ToString(),
                meter.ToString(),
                department
            };

            database.InsertIntoDatabase(tableName, setColumnValue, setColumnName);           
        }

        public void UpdateMeterValue(int week, string department, int meter)
        {

            setColumnValue = new List<string>()
            {
                meter.ToString()
            };

            setColumnName = new List<string>()
            {
                "day"
            };

            whereNames = new List<string>()
            {
                "week",
                "department"
            };

            whereValues = new List<string>()
            {
                week.ToString(),
                department
            };


            database = new DatabaseConnection();
            database.UpdateInDatabase(tableName, setColumnName, setColumnValue, whereValues, whereNames);
        }
    }
}
