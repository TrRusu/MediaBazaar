using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Bazaar_app.Classes
{
    class Announcements
    {
        private readonly string connectionString = "Server=studmysql01.fhict.local;Uid=dbi438993;Database=dbi438993;Pwd=blabla;";
        List<Announcements> announcements;
        
        public string Title
        {
            get;
            private set;
        }

        public int MessageID
        {
            get;
            private set;
        }

        public string Department
        {
            get;
            private set;
        }

        public string Content
        {
            get;
            private set;
        }

        public string State
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

        public string Type
        {
            get;
            private set;
        }

        public string MessageBody
        {
            get;
            private set;
        }

        public Announcements() { }

        public Announcements(string title, string msgBody)
        {
            this.Title = title;
            this.MessageBody = msgBody;
        }

        public Announcements(int messageID, string title, string msgBody)
        {
            this.MessageID = messageID;
            this.Title = title;
            this.MessageBody = msgBody;
        }

        public Announcements(int messageID, string productID, string productName, int productQuantity)
        {
            this.MessageID = messageID;
            this.ProductName = productName;
            this.Quantity = productQuantity;
            this.ProductID = productID;           
        }

        public Announcements(int messageID, string productID, string productName, int productQuantity, string type)
        {           
            this.MessageID = messageID;
            this.ProductName = productName;
            this.Quantity = productQuantity;
            this.ProductID = productID;
            this.Type = type;
        }

        public Announcements(int msgID, string department, string productID, string productName, int productQuantity)
        {
            this.MessageID = msgID;
            this.Department = department;
            this.ProductID = productID;
            this.ProductName = productName;
            this.Quantity = productQuantity;
        }

        public Announcements(int messageID, string department, string productID, string productName, int productQuantity, string msgRead, string type)
        {
            this.Department = department;
            this.MessageID = messageID;
            this.State = msgRead;
            this.ProductName = productName;
            this.Quantity = productQuantity;
            this.ProductID = productID;
            this.Type = type;
        }

        public void GenerateAutoMessage(string department, string productID, string productName, int productQuantity)
        {            
            string query = "INSERT INTO announcements SET msgID=NULL,department=@department,title=NULL, msgBody=NULL, productID=@productID, productName=@productName, productQuantity=@productQuantity, msgRead='False', type='New Product'";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, conn);
            commandDatabase.Parameters.AddWithValue("department", department);
            commandDatabase.Parameters.AddWithValue("productID", productID);
            commandDatabase.Parameters.AddWithValue("productName", productName);
            commandDatabase.Parameters.AddWithValue("productQuantity", productQuantity);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                conn.Open();
                reader = commandDatabase.ExecuteReader();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public void GenerateRestockMessage(string department, string productID, string productName, int productQuantity)
        {
            string query = "INSERT INTO announcements SET msgID= NULL, department=@department, title=NULL, msgBody=NULL, productID=@productID, productName=@productName, productQuantity=@productQuantity, msgRead='False', type='Restock'";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, conn);
            commandDatabase.Parameters.AddWithValue("department", department);
            commandDatabase.Parameters.AddWithValue("productID", productID);
            commandDatabase.Parameters.AddWithValue("productName", productName);
            commandDatabase.Parameters.AddWithValue("productQuantity", productQuantity);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                conn.Open();
                reader = commandDatabase.ExecuteReader();              
            }

            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public void CreateGeneralMessage(string title, string date, string body)
        {
            string query = "INSERT INTO announcements SET msgID=NULL, title=@title, msgBody=@body, msgRead='False', type='General', Date=@date";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, conn);
            commandDatabase.Parameters.AddWithValue("title", title);
            commandDatabase.Parameters.AddWithValue("body", body);
            commandDatabase.Parameters.AddWithValue("date", date);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                conn.Open();
                reader = commandDatabase.ExecuteReader();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Announcements> GetFloorMessages(string position, string department)
        {
            announcements = new List<Announcements>();
            if (position == "Sales Agent")
            {
                string query = "SELECT msgID, productID, productName, productQuantity, type FROM announcements WHERE msgRead = 'False' AND department=@department";
                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand sendCommand = new MySqlCommand(query, conn);
                sendCommand.Parameters.AddWithValue("department", department);
                sendCommand.CommandTimeout = 60;

                try
                {
                    conn.Open();
                    MySqlDataReader reader = sendCommand.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        announcements.Add(new Announcements(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), Convert.ToInt32(reader[3].ToString()), reader[4].ToString()));
                    }
                }

                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }

            else if(position == "Depot Worker")
            {
                string query = "SELECT msgID, productID, productName, productQuantity FROM announcements WHERE msgRead = 'False' AND department=@department AND type='Restock'";
                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand sendCommand = new MySqlCommand(query, conn);
                sendCommand.Parameters.AddWithValue("department", department);
                sendCommand.CommandTimeout = 60;

                try
                {
                    conn.Open();
                    MySqlDataReader reader = sendCommand.ExecuteReader();
                    announcements.Clear();
                    while (reader.Read())
                    {
                        announcements.Add(new Announcements(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), Convert.ToInt32(reader[3].ToString())));
                    }
                }

                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }                     
            return announcements;
        }
       
        public List<Announcements> GetAdministrationMessages()
        {
            announcements = new List<Announcements>();
            string query = "SELECT msgID, department, productID, productName, productQuantity FROM announcements WHERE msgRead = 'False' AND type='New Product'";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand sendCommand = new MySqlCommand(query, conn)
            {
                CommandTimeout = 60
            };

            try
            {
                conn.Open();
                MySqlDataReader reader = sendCommand.ExecuteReader();
                
                while (reader.Read())
                {                
                   announcements.Add(new Announcements(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString())));                 
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return announcements;
        }

        public List<Announcements> GetFloorGeneral(string date)
        {
            announcements = new List<Announcements>();
            string query = "SELECT title, msgBody FROM announcements WHERE msgRead = 'False' AND type='General' AND Date=@date";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand sendCommand = new MySqlCommand(query, conn)
            {
                CommandTimeout = 60
            };
            sendCommand.Parameters.AddWithValue("date", date);

            try
            {
                conn.Open();
                MySqlDataReader reader = sendCommand.ExecuteReader();
                announcements.Clear();
                while (reader.Read())
                {
                    announcements.Add(new Announcements(reader[0].ToString(), reader[1].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return announcements;
        }

        public List<Announcements> GetAdministratorGeneral()
        {
            announcements = new List<Announcements>();
            string query = "SELECT msgID, title, msgBody FROM announcements WHERE msgRead = 'False' AND type='General'";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand sendCommand = new MySqlCommand(query, conn)
            {
                CommandTimeout = 60
            };

            try
            {
                conn.Open();
                MySqlDataReader reader = sendCommand.ExecuteReader();
                

                while (reader.Read())
                {
                    announcements.Add(new Announcements(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return announcements;
        }

        public void MarkMessageAsComplete(int id)
        {
            string query = "UPDATE announcements SET msgRead= 'True' WHERE msgID=@msgID";

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, conn);
            commandDatabase.Parameters.AddWithValue("msgID", id);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                conn.Open();
                reader = commandDatabase.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public void MarkMEssageAsRead(string title)
        {
            string query = "UPDATE announcements SET msgRead= 'True' WHERE title=@title";

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, conn);
            commandDatabase.Parameters.AddWithValue("title", title);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                conn.Open();
                reader = commandDatabase.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public string GetMessageBody(string title)
        {
            string msgBody = null;

            foreach (Announcements message in announcements)
            {
                if (message.Title == title)
                {
                    msgBody = message.MessageBody;
                }
            }
            return msgBody;
        }

    }
}
