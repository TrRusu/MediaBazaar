using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_app.Classes
{
    class DatabaseConnection
    {
        readonly private string connectionString = "Server=<server name>;Uid=<username>;Database=<databasename>;Pwd=<password>;";

        public DatabaseConnection()
        {}

        public DataTable GetDataFromDatabase(string table, List<string> toSelect, List<string> whereValues, List<string> whereNames)
        {
            string query = "SELECT";

            DataTable results = new DataTable();

            if (toSelect == null)
            {
                query += " * "; 
            }
            else
            {
                if (toSelect.Count == 1)
                {
                    foreach (string s in toSelect)
                    {
                        query += $" {s} ";
                    }
                }
                else
                {
                    string last = toSelect.Last();

                    foreach(string s in toSelect)
                    {
                        if (s.Equals(last) == false)
                        {
                            query += $" {s}, ";
                        }
                        else
                        {
                            query += $" {s} ";
                        }
                    }
                }
            }

            query += $" FROM {table}";

            if(whereValues != null)
            {
                query += " WHERE ";
                if (whereNames.Count == 1)
                {
                    foreach (string s in whereNames)
                    {
                        query += $"{s}=@{s}";
                    }
                }
                else
                {
                   string last = whereNames.Last();
                   foreach(string s in whereNames)
                    {
                        if (s.Equals(last) == false)
                        {
                            query += $"{s}=@{s} AND ";
                        }
                        else
                        {
                            query += $"{s}=@{s} ";
                        }
                    }
                }
            }

            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sendCommand = new MySqlCommand(query, sqlConnection)
            {
                CommandTimeout = 1
            };

            if(whereNames != null)
            {
                for(int i = 0; i < whereNames.Count; i++)
                {
                    if (int.TryParse(whereValues[i], out int convertedValue))
                    {
                        sendCommand.Parameters.AddWithValue($"{whereNames[i]}", convertedValue);
                    }
                    else
                    {
                        sendCommand.Parameters.AddWithValue($"{whereNames[i]}", whereValues[i]);
                    }
                }
            }
            try
            {
                sqlConnection.Open();
                MySqlDataAdapter reader = new MySqlDataAdapter(sendCommand);
                reader.Fill(results);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }

            return results;
        }

        public DataTable GetDataFromDatabaseExtra(string table, List<string> toSelect, List<string> whereValues, List<string> whereNames, string extra)
        {
            string query = "SELECT";

            DataTable results = new DataTable();

            if (toSelect == null)
            {
                query += " * ";
            }
            else
            {
                if (toSelect.Count == 1)
                {
                    foreach (string s in toSelect)
                    {
                        query += $" {s} ";
                    }
                }
                else
                {
                    string last = toSelect.Last();

                    foreach (string s in toSelect)
                    {
                        if (s.Equals(last) == false)
                        {
                            query += $" {s}, ";
                        }
                        else
                        {
                            query += $" {s} ";
                        }
                    }
                }
            }

            query += $" FROM {table}";

            if (whereValues != null)
            {
                query += " WHERE ";
                if (whereNames.Count == 1)
                {
                    foreach (string s in whereNames)
                    {
                        query += $"{s}=@{s}";
                    }
                }
                else
                {
                    string last = whereNames.Last();

                    foreach (string s in whereNames)
                    {
                        if (s.Equals(last) == false)
                        {
                            query += $"{s}=@{s} AND ";
                        }
                        else
                        {
                            query += $"{s}=@{s} ";
                        }
                    }
                }
            }

            query += extra;

            

            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sendCommand = new MySqlCommand(query, sqlConnection)
            {
                CommandTimeout = 1
            };

            if (whereNames != null)
            {
                for (int i = 0; i < whereNames.Count; i++)
                {
                    if (int.TryParse(whereValues[i], out int convertedValue))
                    {
                        sendCommand.Parameters.AddWithValue($"{whereNames[i]}", convertedValue);
                    }
                    else
                    {
                        sendCommand.Parameters.AddWithValue($"{whereNames[i]}", whereValues[i]);
                    }
                }
            }
            try
            {
                sqlConnection.Open();
                MySqlDataAdapter reader = new MySqlDataAdapter(sendCommand);
                reader.Fill(results);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }

            return results;
        }

        public void InsertIntoDatabase(string table, List<string> columnValues, List<string> columnNames)
        {
            string query = $"INSERT INTO {table} SET ";


            if (columnNames.Count == 1)
            {
                foreach (string s in columnNames)
                {
                    query += $"{s}=@{s}";
                }
            }
            else
            {
                string last = columnNames.Last();

                foreach (string s in columnNames)
                {
                    if (s.Equals(last) == false)
                    {
                        query += $"{s}=@{s}, ";
                    }
                    else
                    {
                        query += $"{s}=@{s} ";
                    }
                }
            }

            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sendCommand = new MySqlCommand(query, sqlConnection)
            {
                CommandTimeout = 1
            };

            if (columnNames.Count != 0)
            {
                for (int i = 0; i < columnNames.Count; i++)
                {
                    sendCommand.Parameters.AddWithValue($"{columnNames[i]}", columnValues[i]);
                }
            }
            try
            {
                sqlConnection.Open();
                MySqlDataReader reader;
                reader = sendCommand.ExecuteReader();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void UpdateInDatabase(string table, List<string> setColumnName, List<string> setColumnValue, List<string> whereValues, List<string> whereNames)
        {
            string query = $"UPDATE {table} SET ";

            /*Counters are to assign dynamic variable names in case the 
            column in the SET is the same with the column in the WHERE in the SQL query*/

            if (setColumnName.Count == 1)
            {
                int counter = 0;
                foreach (string s in setColumnName)
                {
                    counter++;
                    query += $"{s}=@{s}{counter} ";
                }
            }
            else
            {
                string last = setColumnName.Last();
                int i = 0;
                foreach (string s in setColumnName)
                {
                    i++;
                    if (s.Equals(last) == false)
                    {
                        query += $"{s}=@{s}{i}, ";
                    }
                    else
                    {
                        query += $"{s}=@{s}{i} ";
                    }
                }
            }


            if (whereValues != null)
            {
                query += "WHERE ";
                if (whereNames.Count == 1)
                {
                    foreach (string s in whereNames)
                    {
                        query += $"{s}=@{s}{501}";
                    }
                }
                else
                {
                    string last = whereNames.Last();
                    int counter = 500;
                    foreach (string s in whereNames)
                    {
                        counter++;
                        if (s.Equals(last) == false)
                        {
                            query += $"{s}=@{s}{counter} AND ";
                        }
                        else
                        {
                            query += $"{s}=@{s}{counter}";
                        }
                    }
                }
            }

            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sendCommand = new MySqlCommand(query, sqlConnection)
            {
                CommandTimeout = 500
            };

            if (whereNames != null)
            {
                int counter = 500;
                for (int i = 0; i < whereNames.Count; i++)
                {
                    counter++;
                    sendCommand.Parameters.AddWithValue($"{whereNames[i]}{counter}", whereValues[i]);
                    
                }
            }
            int count = 0;
            for (int i = 0; i < setColumnName.Count; i++)
            {
                count++;
                if (int.TryParse(setColumnValue[i], out int convertedValue))
                {
                    sendCommand.Parameters.AddWithValue($"{setColumnName[i]}{count}", convertedValue);
                }
                else
                {
                    sendCommand.Parameters.AddWithValue($"{setColumnName[i]}{count}", setColumnValue[i]);
                }
            }

            try
            {
                sqlConnection.Open();
                MySqlDataReader reader;
                reader = sendCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void DeleteFromDatabase(string table, List<string> columnValues, List<string> columnNames)
        {
            string query = $"DELETE FROM {table} WHERE ";

            if (columnNames.Count == 1)
            {
                foreach (string s in columnNames)
                {
                    query += $"{s}=@{s}";
                }
            }
            else
            {
                string last = columnNames.Last();

                foreach (string s in columnNames)
                {
                    if (s.Equals(last) == false)
                    {
                        query += $"{s}=@{s} AND ";
                    }
                    else
                    {
                        query += $"{s}=@{s} ";
                    }
                }
            }


            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sendCommand = new MySqlCommand(query, sqlConnection)
            {
                CommandTimeout = 1
            };

            for (int i = 0; i < columnNames.Count; i++)
            {
                sendCommand.Parameters.AddWithValue($"{columnNames[i]}", $"{columnValues[i]}");
            }

            try
            {
                sqlConnection.Open();
                MySqlDataReader reader;
                reader = sendCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public int GetFromSchema(string table)
        {
            string connection = "Server=<servername>;Uid=<username>;Database=information_schema;Pwd=<password>;";
            string query = "SELECT AUTO_INCREMENT FROM TABLES WHERE TABLE_SCHEMA = 'dbi438993' AND TABLE_NAME = @table ";
            int value = 0;

            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand sendCommand = new MySqlCommand(query, conn);
            sendCommand.Parameters.AddWithValue("table", table);
            sendCommand.CommandTimeout = 60;

            try
            {
                conn.Open();
                MySqlDataReader reader = sendCommand.ExecuteReader();

                while (reader.Read())
                {
                    value = Convert.ToInt32(reader[0].ToString());
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

            return value;
        }
    }
}
