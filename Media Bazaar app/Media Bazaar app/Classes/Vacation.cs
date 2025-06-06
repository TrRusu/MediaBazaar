using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_app.Classes
{
    public class Vacation
    {
        DatabaseConnection database;

        private string tableName = "vacation";

        private List<string> toSelect;
        private List<string> whereValues;
        private List<string> whereNames;
        private List<string> setColumnName;
        private List<string> setColumnValue;

        private List<Vacation> localVacations;
        private List<Vacation> vacationsByWeek;

        public int ID
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public int Day
        {
            get;
            private set;
        }

        public int Week
        {
            get;
            private set;
        }

        public Vacation()
        {
            localVacations = new List<Vacation>();
        }

        public Vacation(int id, string name, int day, int week)
        {
            this.ID = id;
            this.Name = name;
            this.Day = day;
            this.Week = week;
        }

        public List<Vacation> GetVacationLocalListByWeek(int week)
        {
            vacationsByWeek = new List<Vacation>();

            foreach(Vacation vacation in localVacations)
            {
                if(vacation.Week == week)
                {
                    vacationsByWeek.Add(vacation);
                }
            }
            return vacationsByWeek;
        }

        public void GetVacationsFromDatabase()
        {
            database = new DatabaseConnection();

            toSelect = new List<string>()
            {
                "id",
                "fullName",
                "a_week",
                "a_weekday"
            };


            whereValues = new List<string>
            {
                "Pending"
            };

            whereNames = new List<string>
            {
                "status"
            };

            foreach(DataRow row in database.GetDataFromDatabase(tableName, toSelect, whereValues, whereNames).Rows)
            {
                localVacations.Add(new Vacation(Convert.ToInt32(row[0].ToString()), row[1].ToString(), Convert.ToInt32(row[3].ToString()), Convert.ToInt32(row[2].ToString())));
            }
        }

        public void GetApprovedVacationsFromDatabase()
        {
            database = new DatabaseConnection();

            toSelect = new List<string>()
            {
                "id",
                "fullName",
                "a_week",
                "a_weekday"
            };


            whereValues = new List<string>
            {
                "Approved"
            };

            whereNames = new List<string>
            {
                "status"
            };

            foreach (DataRow row in database.GetDataFromDatabase(tableName, toSelect, whereValues, whereNames).Rows)
            {
                localVacations.Add(new Vacation(Convert.ToInt32(row[0].ToString()), row[1].ToString(), Convert.ToInt32(row[3].ToString()), Convert.ToInt32(row[2].ToString())));
            }
        }

        public void GetApprovedVacationsForAutomatedSchedule(int week)
        {
            database = new DatabaseConnection();

            toSelect = new List<string>()
            {
                "id",
                "fullName",
                "a_week",
                "a_weekday"
            };


            whereValues = new List<string>
            {
                "Approved",
                week.ToString()
            };

            whereNames = new List<string>
            {
                "status",
                 "a_week"
            };

            foreach (DataRow row in database.GetDataFromDatabase(tableName, toSelect, whereValues, whereNames).Rows)
            {
                localVacations.Add(new Vacation(Convert.ToInt32(row[0].ToString()), row[1].ToString(), Convert.ToInt32(row[3].ToString()), Convert.ToInt32(row[2].ToString())));
            }
        }

        public void DismissVacationInDatabase(int index)
        {
            database = new DatabaseConnection();

            setColumnName = new List<string>()
            {
                "status"
            };

            setColumnValue = new List<string>()
            {
                "Dismissed"
            };

            whereNames = new List<string>()
            {
                "id"
            };

            whereValues = new List<string>
            {
                GetVacationID(index).ToString()
            };

            database.UpdateInDatabase(tableName, setColumnName, setColumnValue, whereValues, whereNames);
            RemoveVacationFromLocalList(GetVacationID(index));

        }

        public void ApproveVacationInDatabase(int index)
        {
            database = new DatabaseConnection();

            setColumnName = new List<string>()
            {
                "status"
            };

            setColumnValue = new List<string>()
            {
                "Approved"
            };

            whereNames = new List<string>()
            {
                "id"
            };

            whereValues = new List<string>
            {
                GetVacationID(index).ToString()
            };

            database.UpdateInDatabase(tableName, setColumnName, setColumnValue, whereValues, whereNames);
            RemoveVacationFromLocalList(GetVacationID(index));
        }

        private void RemoveVacationFromLocalList(int id)
        {
            for(int i = 0; i < localVacations.Count; i++)
            {
                if(localVacations[i].ID == id)
                {
                    localVacations.Remove(localVacations[i]);
                }
            }
        }

        private int GetVacationID(int listboxIndex)
        {
            int vacationID = 0;

            for(int i = 0; i < vacationsByWeek.Count; i++)
            {
                if(vacationsByWeek.IndexOf(vacationsByWeek[i]) == listboxIndex)
                {
                    vacationID = vacationsByWeek[i].ID;
                }
            }

            return vacationID;
        }

        public override string ToString()
        {
            string day = "";
            if(Day == 1)
            {
                day = "Monday";
            }
            else if (Day == 2)
            {
                day = "Tuesday";
            }
            else if (Day == 3)
            {
                day = "Wednesday";
            }
            else if (Day == 4)
            {
                day = "Thursday";
            }
            else if(Day == 5)
            {
                day = "Friday";
            }
            else if(Day == 6)
            {
                day = "Saturday";
            }
            else if(Day == 7)
            {
                day = "Sunday";
            }

            return $"\t \t \t \t \t{this.Name}: {day}";
        }
    }
}
