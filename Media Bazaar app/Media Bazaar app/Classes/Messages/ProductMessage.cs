using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_app.Classes
{
    class ProductMessage : Message
    {
        public string Department
        {
            get;
            private set;
        }

        public string ProductID
        {
            get;
            private set;
        }

        public string ProductName
        {
            get;
            private set;
        }

        public int Quantity
        {
            get;
            private set;
        }

        public ProductMessage()
        { }

        public ProductMessage(int id, string department, string productID, string productName)
        {
            MessageID = id;
            Department = department;
            ProductID = productID;
            ProductName = productName;
        }

        public ProductMessage(int id, string productID, string productName, int quantity, string type, string department)
        {
            MessageID = id;
            ProductID = productID;
            ProductName = productName;
            Quantity = quantity;
            Type = type;
            Department = department;
        }

        public void CreateNewProductMessage(string department, string productID, string productName, int quantity, string type)
        {
            setColumnName = new List<string>()
            {
                "department",
                "productID",
                "productName",
                "productQuantity",
                "type"
            };

            setColumnValue = new List<string>()
            {
                department,
                productID,
                productName,
                quantity.ToString(),
                type
            };

            database = new DatabaseConnection();
            database.InsertIntoDatabase(tableName, setColumnValue, setColumnName);
            CreateMessageInLocalList(productID, productName, quantity, type, department);
        }

        public void CreateRestockMessage(string department, string productID, string productName, string quantity, string type, string depotQuantity)
        {
            ValidationManager applicationManager = new ValidationManager();
            if(applicationManager.ValidateProductRestockRequest(quantity, depotQuantity))
            setColumnName = new List<string>()
            {
                "department",
                "productID",
                "productName",
                "productQuantity",
                "type"
            };

            setColumnValue = new List<string>()
            {
                department,
                productID,
                productName,
                quantity,
                type
            };

            database = new DatabaseConnection();
            database.InsertIntoDatabase(tableName, setColumnValue, setColumnName);
            CreateMessageInLocalList(productID, productName, Convert.ToInt32(quantity), type, department);
        }

        private void CreateMessageInLocalList(string productID, string productName, int quantity, string type, string department)
        {
            localMessages.Add(new ProductMessage(NextMessageIdFromDatabase(), productID, productName, quantity, type, department));
        }

        public void GetAdministrationProductMessagesFromDatabase()
        {
            string messageType = "New Product";
            database = new DatabaseConnection();

            localMessages.Clear();

            toSelect = new List<string>()
            {
                "msgID",
                "department",
                "productID",
                "productName"
            };

            whereNames = new List<string>()
            {
                "type"
            };

            whereValues = new List<string>()
            {
                messageType
            };

            foreach (DataRow reader in database.GetDataFromDatabase(tableName, toSelect, whereValues, whereNames).Rows)
            {
                localMessages.Add(new ProductMessage(Convert.ToInt32(reader[0].ToString()),
                                  reader[1].ToString(), reader[2].ToString(), reader[3].ToString()));
            }
        }

        public void GetFloorProductMessagesFromDatabase(string position, string department)
        {

            localMessages.Clear();

            database = new DatabaseConnection();

            if (position == "Sales Agent")
            {

                toSelect = new List<string>
                {
                    "msgID",
                    "productID",
                    "productName",
                    "productQuantity",
                    "type",
                    "department"
                };

                whereNames = new List<string>()
                {
                    "department"
                };

                whereValues = new List<string>()
                {
                    department
                };

                foreach (DataRow result in database.GetDataFromDatabase(tableName, toSelect, whereValues, whereNames).Rows)
                {
                    localMessages.Add(new ProductMessage(Convert.ToInt32(result[0].ToString()), result[1].ToString(), result[2].ToString(),
                                                         Convert.ToInt32(result[3].ToString()), result[4].ToString(), result[5].ToString()));
                }
            }

            else if (position == "Depot Worker")
            {
                string messageType = "Restock";

                toSelect = new List<string>
                {
                    "msgID",
                    "productID",
                    "productName",
                    "productQuantity",
                    "type",
                    "department"
                };

                whereNames = new List<string>()
                {
                    "department",
                    "type"
                };

                whereValues = new List<string>()
                {
                    department,
                    messageType
                };

                foreach (DataRow result in database.GetDataFromDatabase(tableName, toSelect, whereValues, whereNames).Rows)
                {
                    localMessages.Add(new ProductMessage(Convert.ToInt32(result[0].ToString()), result[1].ToString(), result[2].ToString(), 
                                                         Convert.ToInt32(result[3].ToString()), result[4].ToString(), result[5].ToString()));
                }
            }
        }
    }
}
