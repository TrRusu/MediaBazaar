using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_app.Classes
{
    class Product
    {
        ValidationManager applicationManager;

        private string table = "products";
        private readonly List<string> toSelect;
        private List<string> whereValues;
        private List<string> whereNames;
        private List<string> setColumnName;
        private List<string> setColumnValue;

        private List<Product> localProducts;
        private List<Product> localProductsByDepartment;

        private DatabaseConnection database;

        public string ProductID
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }

        public int ShelfQuantity
        {
            get;
            set;
        }

        public int DepoQuantity
        {
            get;
            set;
        }

        public string Department
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public int SoldUnits
        {
            get;
            set;
        }

        public Product()
        {
            localProducts = new List<Product>();
            localProductsByDepartment = new List<Product>();
        }

        public Product(string productID, string name, double price, int shelfQuantity, string description, string department, int depoQuantity)
        {
            this.ProductID = productID;
            this.Name = name;
            this.Price = price;
            this.ShelfQuantity = shelfQuantity;
            this.Description = description;
            this.Department = department;
            this.DepoQuantity = depoQuantity;
        }

        public Product(string name, int soldUnits)
        {
            this.Name = name;
            this.SoldUnits = soldUnits;
        }

        public bool AddNewProduct(string name, string quantity, string price, string description, string department, string id)
        {
            applicationManager = new ValidationManager();
            if (applicationManager.ValidateProductValues(name, quantity, price, description, department, id) == false)
            {
                return false;
            }
            else
            {
                database = new DatabaseConnection();

                setColumnName = new List<string>
            {
                "productID",
                "name",
                "price",
                "shelfQuantity",
                "description",
                "Department",
                "depoQuantity"
            };

                setColumnValue = new List<string>
            {
                id,
                name,
                price,
                "0",
                description,
                department,
                quantity
            };

                database.InsertIntoDatabase(table, setColumnValue, setColumnName);
                AddProductToLocalList(name, quantity, price, description, department, id);

            }
            return true;
        }

        private void AddProductToLocalList(string name, string quantity, string price, string description, string department, string id)
        {
            int shelfQuantity = 0;
            localProducts.Add(new Product(id, name, Convert.ToDouble(price), shelfQuantity, description, department, Convert.ToInt32(quantity)));
        }

        public bool EditExistingProduct(string name, string quantity, string price, string description, string department, string id)
        {
            applicationManager = new ValidationManager();
            if (applicationManager.ValidateProductValues(name, quantity, price, description, department, id) == false)
            {
                return false;
            }
            else
            {
                database = new DatabaseConnection();

                setColumnName = new List<string>
            {
                "name",
                "price",
                "description",
                "Department",
                "depoQuantity"
            };

                setColumnValue = new List<string>
            {
                name,
                price,
                description,
                department,
                quantity
            };

                whereNames = new List<string>
            {
                "productID"
            };

                whereValues = new List<string>
            {
                id
            };


                database.UpdateInDatabase(table, setColumnName, setColumnValue, whereValues, whereNames);
                EditProductInLocalList(name, quantity, price, description, department, id);
            }
            return true;
        }

        private void EditProductInLocalList(string name, string quantity, string price, string description, string department, string id)
        {
            foreach(Product product in localProducts)
            {
                if(product.ProductID == id)
                {
                    product.Name = name;
                    product.DepoQuantity = Convert.ToInt32(quantity);
                    product.Price = Convert.ToDouble(price);
                    product.Department = department;
                    product.Description = description;
                }
            }
        }

        public void MoveProductInDatabase(string newDepartment, string name)
        {
            database = new DatabaseConnection();

            setColumnName = new List<string>
            {
                "Department"
            };

            setColumnValue = new List<string>
            {
                newDepartment
            };

            whereValues = new List<string>
            {
                name
            };

            whereNames = new List<string>
            {
                "name"
            };

            database.UpdateInDatabase(table, setColumnName, setColumnValue, whereValues, whereNames);
            MoveProductToDepartmentInLocalList(newDepartment, name);
        }

        private void MoveProductToDepartmentInLocalList(string newDepartment, string name)
        {
            foreach(Product product in localProducts)
            {
                if(product.Name == name)
                {
                    product.Department = newDepartment;
                }
            }
        }

        public void MoveAllProductsToDepartment(string oldDepartment, string newDepartment)
        {
            database = new DatabaseConnection();

            setColumnName = new List<string>
            {
                "Department"
            };

            setColumnValue = new List<string>
            {
                newDepartment
            };

            whereValues = new List<string>
            {
                oldDepartment
            };

            whereNames = new List<string>
            {
                "Department"
            };

            database.UpdateInDatabase(table, setColumnName, setColumnValue, whereValues, whereNames);
            MoveAllProductsToDepartmentInLocalList(oldDepartment, newDepartment);
        }

        private void MoveAllProductsToDepartmentInLocalList(string oldDepartment, string newDepartment)
        {
            foreach(Product product in localProducts)
            {
                if(product.Department == oldDepartment)
                {
                    product.Department = newDepartment;
                }
            }
        }

        public void DeleteAllProductsFromDatabase(string department)
        {
            database = new DatabaseConnection();

            whereValues = new List<string>
            {
                department
            };

            whereNames = new List<string>
            {
                "Department"
            };

            database.DeleteFromDatabase(table, whereValues, whereNames);
            RemoveAllProductsFromLocalList(department);
        }

        private void RemoveAllProductsFromLocalList(string department)
        {
            for(int i = 0; i < localProducts.Count; i++)
            {
                if (localProducts[i].Department == department)
                {
                    localProducts.Remove(localProducts[i]);
                }
            }        
        }

        public void DeleteProductFromDatabase(string name)
        {

            database = new DatabaseConnection();

            whereValues = new List<string>
            {
                name
            };

            whereNames = new List<string>
            {
                "name"
            };

            database.DeleteFromDatabase(table, whereValues, whereNames);
            DeleteProductFromLocalList(name);
        }

        private void DeleteProductFromLocalList(string name)
        {
            for(int i = 0; i < localProducts.Count; i++)
            {
                if(localProducts[i].Name == name)
                {
                    localProducts.Remove(localProducts[i]);
                }
            }
        }

        public void RegisterSaleInDatabase(string id, string sellQuantity, int shelfQuantity, int monthNumber, string name)
        {
            applicationManager = new ValidationManager();

            if (applicationManager.ValidateSaleProduct(sellQuantity, shelfQuantity))
            {

                database = new DatabaseConnection();
                int finalQuantity = shelfQuantity - Convert.ToInt32(sellQuantity);
                setColumnName = new List<string>
            {
                "shelfQuantity"
            };

                setColumnValue = new List<string>
            {
                 finalQuantity.ToString()
            };

                whereNames = new List<string>
            {
                "productID",
            };

                whereValues = new List<string>
            {
                id
            };
                database.UpdateInDatabase(table, setColumnName, setColumnValue, whereValues, whereNames);
                RegisterSaleForStatistics(monthNumber, name, Convert.ToInt32(sellQuantity), FindProductDepartment(name));
                RegisterSaleInLocalList(id, finalQuantity);
            }
        }

        private void RegisterSaleForStatistics(int monthNumber, string name, int sellQuantity, string department)
        {
            database = new DatabaseConnection();
            string tableName = "sales";
            setColumnName = new List<string>
            {
                "month",
                "amount",
                "productName",
                "department",
            };

            setColumnValue = new List<string>
            {
                monthNumber.ToString(),
                sellQuantity.ToString(),
                name,
                department,
            };
            database.InsertIntoDatabase(tableName, setColumnValue, setColumnName);         
        }

        private void RegisterSaleInLocalList(string id, int finalQuantity)
        {
            foreach (Product product in localProducts)
            {
                if (product.ProductID == id)
                {
                    product.ShelfQuantity = Convert.ToInt32(finalQuantity);   
                }
            }
        }

        public void UpdateProductQuantitiesInDatabase(string productid, int shelfQuantity, int depoQuantity, int requestQuantity)
        {
            int finalShelf = shelfQuantity + requestQuantity;
            int finalDepot = depoQuantity - requestQuantity;

            if(depoQuantity < requestQuantity)
            {
                throw new Exception("Unable to perform replenishment");
            }

            setColumnName = new List<string>()
            {
                "shelfQuantity",
                "depoQuantity"
            };

            setColumnValue = new List<string>()
            {
                finalShelf.ToString(),
                finalDepot.ToString()
            };

            whereNames = new List<string>()
            {
                "productID"
            };

            whereValues = new List<string>()
            {
                productid
            };

            database.UpdateInDatabase(table, setColumnName, setColumnValue, whereValues, whereNames);
            UpdateProductQuantitiesInLocalList(productid, finalShelf, finalDepot);
        }

        public void UpdateProductQuantitiesInLocalList(string productID, int shelfQuantity, int depotQuantity)
        {
            foreach(Product product in localProductsByDepartment)
            {
                if(product.ProductID == productID)
                {
                    product.ShelfQuantity = shelfQuantity;
                    product.DepoQuantity = depotQuantity;
                }
            }
        }

        public void GetProductsFromDatabase()
        {
            database = new DatabaseConnection();
            localProducts.Clear();

            foreach (DataRow reader in database.GetDataFromDatabase(table, toSelect, whereValues, whereNames).Rows)
            {
                localProducts.Add(new Product(reader[0].ToString(), reader[1].ToString(), Convert.ToDouble(reader[2].ToString()), Convert.ToInt32(reader[3].ToString()), reader[4].ToString(), reader[5].ToString(), Convert.ToInt32(reader[6].ToString())));
            }
        }

        public List<Product> GetProductsByDepartmentFromDatabase(string department)
        {
            database = new DatabaseConnection();
            localProductsByDepartment.Clear();

            whereValues = new List<string>()
            {
                department
            };

            whereNames = new List<string>()
            {
                "Department"
            };
            
            foreach (DataRow reader in database.GetDataFromDatabase(table, toSelect, whereValues, whereNames).Rows)
            {
                localProductsByDepartment.Add(new Product(reader[0].ToString(), reader[1].ToString(), Convert.ToDouble(reader[2].ToString()), Convert.ToInt32(reader[3].ToString()), reader[4].ToString(), reader[5].ToString(), Convert.ToInt32(reader[6].ToString())));
            }

            return localProductsByDepartment;
        }

        public List<Product> ReturnProductsLocalList()
        {
            return localProducts;
        }

        public List<Product> ReturnProductsByDepartmentLocalList()
        {
            return localProductsByDepartment;
        }

        public List<Product> FilterLocalProductsListByDepartment(string department)
        {
            List<Product> pByDepartment = new List<Product>();

            foreach (Product product in localProducts)
            {
                if (product.Department == department)
                {
                    pByDepartment.Add(product);
                }
            }
            return pByDepartment;
        }

        public Product GetProductInfo(string name)
        {
            Product fetchedProduct = null;

            foreach (Product product in localProducts)
            {
                if (product.Name == name)
                {
                    fetchedProduct = new Product(product.ProductID, product.Name, product.Price, product.ShelfQuantity, product.Description, product.Department, product.DepoQuantity);
                }
            }
            return fetchedProduct;
        }

        public Product GetProductInfoFilteredByDepartment(string name)
        {
            Product fetchedProduct = null;

            foreach (Product product in localProductsByDepartment)
            {
                if (product.Name == name)
                {
                    fetchedProduct = new Product(product.ProductID, product.Name, product.Price, product.ShelfQuantity, product.Description, product.Department, product.DepoQuantity);
                }
            }
            return fetchedProduct;
        }

        public List<Product> SearchProduct(string partial, string department)
        {
            List<Product> searchedProduct = new List<Product>();

            foreach (Product p in localProducts)
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

        public List<Product> SearchProductFilteredByDepartment(string partial, string department)
        {
            List<Product> searchedProduct = new List<Product>();

            foreach (Product p in localProductsByDepartment)
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

        public string FindProductDepartment(string name)
        {
            string department = null;

            foreach(Product p in localProducts)
            {
                if(p.Name == name)
                {
                    department = p.Department;
                }
            }
            return department;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
