using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Media_Bazaar_app.Classes
{
    public class Products
    {

        private readonly string connectionString = "Server=studmysql01.fhict.local;Uid=dbi438993;Database=dbi438993;Pwd=blabla;";
        private readonly List<Products> pByDepartment = new List<Products>();
        private readonly List<Products> localProducts = new List<Products>();
        private readonly List<Products> topProductsCurrent = new List<Products>();
        private readonly List<Products> topProductsStock = new List<Products>();
        private List<Products> searchedProduct;
        private Products product;

        public string ProductID
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public double Price
        {
            get;
            private set;
        }

        public int ShelfQuantity
        {
            get;
            private set;
        }

        public int DepoQuantity
        {
            get;
            private set;
        }

        public string Department
        {
            get;
            private set;
        }

        public string Description
        {
            get;
            private set;
        }

        public int SoldUnits
        {
            get;
            private set;
        }

        public Products(string productID, string name, double price, int shelfQuantity, string description, string department, int depoQuantity)
        {
            this.ProductID = productID;
            this.Name = name;
            this.Price = price;
            this.ShelfQuantity = shelfQuantity;
            this.Description = description;
            this.Department = department;
            this.DepoQuantity = depoQuantity;
        }

        public Products() { }

        public Products(string name, int soldUnits)
        {
            this.Name = name;
            this.SoldUnits = soldUnits;
        }

        public void MoveProduct(string newDepartment, string pName)
        {
            string query = "UPDATE products SET Department=@newDepartment WHERE name=@pName";

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, conn);
            commandDatabase.Parameters.AddWithValue("pName", pName);
            commandDatabase.Parameters.AddWithValue("newDepartment", newDepartment);
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

        public void RegisterSale(int month, string pName, int qtySold, string department)
        {
           
            string query = "INSERT INTO sales SET date=@month, product=@pName, amount=@qtySold, department=@department";

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, conn);
            commandDatabase.Parameters.AddWithValue("month", month);
            commandDatabase.Parameters.AddWithValue("pName", pName);
            commandDatabase.Parameters.AddWithValue("qtySold", qtySold);
            commandDatabase.Parameters.AddWithValue("department", department);
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

        public List<Products> GetTopSalesCurrentMonth(int month, string department)
        {

            string query = "SELECT product, SUM(amount) AS total FROM sales WHERE date=@month AND department=@department GROUP BY product ORDER BY total DESC LIMIT 5";

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, conn);
            commandDatabase.Parameters.AddWithValue("month", month);
            commandDatabase.Parameters.AddWithValue("department", department);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            topProductsCurrent.Clear();

            try
            {
                conn.Open();
                reader = commandDatabase.ExecuteReader();
                while (reader.Read())
                {
                    topProductsCurrent.Add(new Products(reader[0].ToString(), Convert.ToInt32(reader[1].ToString())));
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

            return topProductsCurrent;
        }

        public List<Products> GetTotalStock(string product)
        {
            string query = "SELECT name, depoQuantity AS total FROM products WHERE name=@product";

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, conn);
            commandDatabase.Parameters.AddWithValue("product", product);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            topProductsStock.Clear();

            try
            {
                conn.Open();
                reader = commandDatabase.ExecuteReader();
                while (reader.Read())
                {
                    topProductsStock.Add(new Products(reader[0].ToString(), Convert.ToInt32(reader[1])));                 
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
            return topProductsStock;
        }


        public void DeleteAllProducts(string department)
        {
            string query = "DELETE FROM products WHERE Department=@department";

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, conn);
            commandDatabase.Parameters.AddWithValue("department", department);
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

        public void DeleteProduct(string name)
        {
            string query = "DELETE FROM products WHERE name=@name";

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, conn);
            commandDatabase.Parameters.AddWithValue("name", name);
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

        public void MoveAllProducts(string oldDepartment, string newDepartment)
        {
            string query = "UPDATE products SET Department=@newDepartment WHERE Department=@oldDepartment";

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, conn);
            commandDatabase.Parameters.AddWithValue("newDepartment", newDepartment);
            commandDatabase.Parameters.AddWithValue("oldDepartment", oldDepartment);
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

        public List<Products> GetProductsFromDatabase()
        {
            string query = "SELECT * FROM products";
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sendCommand = new MySqlCommand(query, sqlConnection)
            {
                CommandTimeout = 60
            };
            localProducts.Clear();

            try
            {
                sqlConnection.Open();
                MySqlDataReader reader = sendCommand.ExecuteReader();

                while (reader.Read())
                {                    
                    localProducts.Add(new Products(reader[0].ToString(), reader[1].ToString(), Convert.ToDouble(reader[2].ToString()), Convert.ToInt32(reader[3].ToString()), reader[4].ToString(), reader[5].ToString(), Convert.ToInt32(reader[6].ToString())));
                }

            }
            catch
            {

            }
            finally
            {
                sqlConnection.Close();
            }
            return localProducts;
        }

        public List<Products> GetProductsFromDatabaseByDepartment(string department)
        {
            string query = "SELECT * FROM products WHERE Department=@department";
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sendCommand = new MySqlCommand(query, sqlConnection)
            {
                CommandTimeout = 60
            };
            sendCommand.Parameters.AddWithValue("department", department);
            localProducts.Clear();

            try
            {
                sqlConnection.Open();
                MySqlDataReader reader = sendCommand.ExecuteReader();

                while (reader.Read())
                {
                    localProducts.Add(new Products(reader[0].ToString(), reader[1].ToString(), Convert.ToDouble(reader[2].ToString()), Convert.ToInt32(reader[3].ToString()), reader[4].ToString(), reader[5].ToString(), Convert.ToInt32(reader[6].ToString())));
                }

            }
            catch
            {

            }
            finally
            {
                sqlConnection.Close();
            }
            return localProducts;
        }

        public List<Products> ProductsByDepartment(string department)
        {
            pByDepartment.Clear();

            foreach (Products product in localProducts)
            {
                if (product.Department == department)
                {
                    pByDepartment.Add(product);
                }
            }
            return pByDepartment;
        }

        public List<Products> AllProducts()
        {
            return localProducts;
        }

        public bool AddProducts(string productid, string name, string price, string description, string department, string depoQuantity)
        {

            if (double.TryParse(price, out double dbPrice) == false)
            {
                throw new Exception("Please enter a valid price value");
            }

            else if (int.TryParse(depoQuantity, out int depoQuantityDB) == false)
            {
                throw new Exception("Please enter a valid quantity");
            }

            else if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Please insert name");
            }
            else if (string.IsNullOrEmpty(department) || string.IsNullOrWhiteSpace(department))
            {
                throw new Exception("Please insert department");
            }
            else if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
            {
                throw new Exception("Please insert description");
            }
            else if (string.IsNullOrEmpty(productid) || string.IsNullOrWhiteSpace(productid))
            {
                throw new Exception("Please insert product id");
            }

            else
            {

                string query = "INSERT INTO products SET productID =@productID, name=@name, price =@price, shelfQuantity=0, description=@description, Department= @department, depoQuantity=@depoQuantity";
                MySqlConnection sqlConnection = new MySqlConnection(connectionString);
                MySqlCommand sendCommand = new MySqlCommand(query, sqlConnection);
                sendCommand.Parameters.AddWithValue("productID", productid);
                sendCommand.Parameters.AddWithValue("name", name);
                sendCommand.Parameters.AddWithValue("price", dbPrice);
                sendCommand.Parameters.AddWithValue("department", department);
                sendCommand.Parameters.AddWithValue("description", description);
                sendCommand.Parameters.AddWithValue("depoQuantity", depoQuantityDB);

                sendCommand.CommandTimeout = 60;
                MySqlDataReader reader;

                try
                {
                    sqlConnection.Open();
                    reader = sendCommand.ExecuteReader();
                    int shelfQuantity = 0;
                    product = new Products(productid, name, dbPrice, shelfQuantity, description, department, depoQuantityDB);
                    localProducts.Add(product);
                }
                catch
                {
                    return false;
                }
                finally
                {
                    sqlConnection.Close();
                }
                return true;
            }
        }

        public bool AdministrationEditProducts(string productid, string name, string price, string description, string department, string depoQuantity)
        {

            if (double.TryParse(price, out double dbPrice) == false)
            {
                throw new Exception("Please enter a valid price value");
            }

            else if (int.TryParse(depoQuantity, out int depoQuantityDB) == false)
            {
                throw new Exception("Please enter a valid quantity");
            }

            else if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Please insert name");
            }
            else if (string.IsNullOrEmpty(department) || string.IsNullOrWhiteSpace(department))
            {
                throw new Exception("Please insert department");
            }
            else if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
            {
                throw new Exception("Please insert description");
            }

            else
            {

                string query = "Update products SET name=@name, price=@price, description=@description, Department=@department, depoQuantity=@depoQuantity WHERE productID=@productID";
                MySqlConnection sqlConnection = new MySqlConnection(connectionString);
                MySqlCommand sendCommand = new MySqlCommand(query, sqlConnection);
                sendCommand.Parameters.AddWithValue("productID", productid);
                sendCommand.Parameters.AddWithValue("name", name);
                sendCommand.Parameters.AddWithValue("price", dbPrice);
                sendCommand.Parameters.AddWithValue("department", department);
                sendCommand.Parameters.AddWithValue("description", description);
                sendCommand.Parameters.AddWithValue("depoQuantity", depoQuantityDB);
                sendCommand.CommandTimeout = 60;
                MySqlDataReader reader;

                try
                {
                    sqlConnection.Open();
                    reader = sendCommand.ExecuteReader();
                    for (int i = 0; i < localProducts.Count(); i++)
                    {
                        if (localProducts[i].ProductID == productid)
                        {
                            localProducts[i].Name = name;
                            localProducts[i].DepoQuantity = depoQuantityDB;
                            localProducts[i].Price = dbPrice;
                            localProducts[i].Department = department;
                            localProducts[i].Description = description;
                        }
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    sqlConnection.Close();

                }
                return true;
            }
        }

        public void FloorSellProducts(string productid, string sellQuantity, int shelfQuantity)
        {
            if (string.IsNullOrEmpty(sellQuantity) || string.IsNullOrWhiteSpace(sellQuantity))
            {
                sellQuantity = "1";
            }
            if (int.TryParse(sellQuantity, out int sellQuantityDB) == false)
            {
                throw new Exception("Please enter a valid quantity");
            }
            else
            {
                if (sellQuantityDB > shelfQuantity)
                {
                    throw new Exception("Not enough stock");
                }
                else
                {
                    int finalQuantity = shelfQuantity - sellQuantityDB;
                    string query = "Update products SET shelfQuantity=@finalQuantity WHERE productID=@productID";
                    MySqlConnection sqlConnection = new MySqlConnection(connectionString);
                    MySqlCommand sendCommand = new MySqlCommand(query, sqlConnection);
                    sendCommand.Parameters.AddWithValue("productID", productid);
                    sendCommand.Parameters.AddWithValue("finalQuantity", finalQuantity);
                    sendCommand.CommandTimeout = 5;
                    MySqlDataReader reader;

                    try
                    {
                        sqlConnection.Open();
                        reader = sendCommand.ExecuteReader();
                        for (int i = 0; i < localProducts.Count(); i++)
                        {
                            if (localProducts[i].ProductID == productid)
                            {
                                localProducts[i].ShelfQuantity = finalQuantity;
                            }
                        }
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
            }
        }

        public void RestockProducts(string productid, int shelfQuantity, int depoQuantity, int requestQuantity)
        {
            int finalShelf = shelfQuantity + requestQuantity;
            int finalDepot = depoQuantity - requestQuantity;

            string query = "Update products SET shelfQuantity=@finalQuantity, depoQuantity=@depotQuantity WHERE productID=@productID";
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sendCommand = new MySqlCommand(query, sqlConnection);
            sendCommand.Parameters.AddWithValue("productID", productid);
            sendCommand.Parameters.AddWithValue("finalQuantity", finalShelf);
            sendCommand.Parameters.AddWithValue("depotQuantity", finalDepot);
            sendCommand.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                sqlConnection.Open();
                reader = sendCommand.ExecuteReader();
                for (int i = 0; i < localProducts.Count(); i++)
                {
                    if (localProducts[i].ProductID == productid)
                    {
                        localProducts[i].ShelfQuantity = finalShelf;
                        localProducts[i].DepoQuantity = finalDepot;
                    }
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
        }

        public List<Products> SearchProduct(string partial, string department)
        {
            searchedProduct = new List<Products>();

            foreach (Products p in localProducts)
            {
                if (p.Name.ToUpper().StartsWith(partial.ToUpper()))
                {
                    if (p.Name.ToUpper().Contains(partial.ToUpper()))
                    {
                        if (p.Department == department)
                        {
                            searchedProduct.Add(p);
                        }
                        if (department == "All")
                        {
                            searchedProduct.Add(p);
                        }
                    }
                }
            }
            return searchedProduct;
        }

        public List<Products> SearchCashierProduct(string partial)
        {
            searchedProduct = new List<Products>();

            foreach (Products p in localProducts)
            {
                if (p.Name.ToUpper().StartsWith(partial.ToUpper()))
                {
                    if (p.Name.ToUpper().Contains(partial.ToUpper()))
                    {
                       searchedProduct.Add(p);           
                    }
                }
            }
            return searchedProduct;
        }

        public Products GetProductInfo(string name)
        {
            Products fetchedProduct = null;

            foreach (Products product in localProducts)
            {
                if(product.Name == name)
                {
                   fetchedProduct = new Products(product.ProductID, product.Name, product.Price, product.ShelfQuantity, product.Description, product.Department, product.DepoQuantity);
                }
            }
            return fetchedProduct;
        }
    }
}

