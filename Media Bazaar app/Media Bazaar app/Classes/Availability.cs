using Media_Bazaar_app.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_app.Classes
{
    public class Availability
    {

        private List<string> toSelect;
        private List<string> whereValues;
        private List<string> whereNames;
        private DatabaseConnection database;
        private string tableName = "schedulepreferences";

        private List<Availability> localAvailabilities;


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

        public string Shift
        {
            get;
            private set;
        }

        public int Day
        {
            get;
            private set;
        }

        public int Value
        {
            get;
            private set;
        }

        public Availability()
        {
            localAvailabilities = new List<Availability>();
        }

        public Availability(string Name, string Shift, int Week, int Day)
        {
            this.Day = Day;
            this.Week = Week;
            this.Name = Name;
            this.Shift = Shift;
        }

        public void RemoveAvailabilityFromDatabase(string name, string shift, int week, int day)
        {
            database = new DatabaseConnection();

            whereNames = new List<string>()
            {
                "fullName",
                "Shift",
                "a_week",
                "a_weekDay"
            };

            whereValues = new List<string>()
            {
                name,
                shift,
                week.ToString(),
                day.ToString()
            };

            database.DeleteFromDatabase(tableName, whereValues, whereNames);

        }

        public void GetAvailabilitesFromDatabaseByWeek(int week)
        {
            database = new DatabaseConnection();
            toSelect = new List<string>()
            {
                "fullName",
                "Shift",
                "a_week",
                "a_weekday"
            };

            whereNames = new List<string>()
            {
                "a_week"
            };

            whereValues = new List<string>()
            {
                week.ToString()
            };

            foreach(DataRow row in database.GetDataFromDatabase(tableName, toSelect, whereValues, whereNames).Rows)
            {
                localAvailabilities.Add(new Availability(row[0].ToString(), row[1].ToString(), Convert.ToInt32(row[2].ToString()), Convert.ToInt32(row[3].ToString())));
            }           
        }

        public List<Availability> FilterAvailabilitesByDay(int day)
        {
            List<Availability> availabilitiesByDay = new List<Availability>();
            foreach(Availability availability in localAvailabilities)
            {
                if(availability.Day == day)
                {
                    availabilitiesByDay.Add(availability);
                }
            }

            return availabilitiesByDay;
        }
    }
}
