using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_app.Classes
{
    class Statistic
    {

        private List<string> toSelect;
        private List<string> whereValues;
        private List<string> whereNames;

        private DatabaseConnection database;

        public string Name
        {
            get;
            private set;
        }

        public int Value
        {
            get;
            private set;
        }


        public Statistic()
        {

        }

        public Statistic(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public List<Statistic> GetTopSalesCurrentMonth(int month, string department)
        {
            List<Statistic> statistics = new List<Statistic>();

            toSelect = new List<string>()
            {
                "productName",
                "SUM(amount) AS total"
            };

            whereNames = new List<string>()
            {
                "month",
                "department"
            };

            whereValues = new List<string>()
            {
                month.ToString(),
                department
            };

            string extra = "GROUP BY productName ORDER BY total DESC LIMIT 5";

            database = new DatabaseConnection();
            foreach(DataRow row in database.GetDataFromDatabaseExtra("sales", toSelect, whereValues, whereNames, extra).Rows)
            {
                statistics.Add(new Statistic(row[0].ToString(), Convert.ToInt32(row[1].ToString())));
            }

            return statistics;
        }

        public List<Statistic> GetTotalStock(string name)
        {
            List<Statistic> statistics = new List<Statistic>();

            toSelect = new List<string>()
            {
                "name",
                "depoQuantity AS TOTAL"
            };

            whereNames = new List<string>()
            {
                "name"
            };

            whereValues = new List<string>()
            {
                name
            };

            database = new DatabaseConnection();
            foreach (DataRow row in database.GetDataFromDatabase("products", toSelect, whereValues, whereNames).Rows)
            {
                statistics.Add(new Statistic(row[0].ToString(), Convert.ToInt32(row[1].ToString())));
            }

            return statistics;
        }
    }
}
