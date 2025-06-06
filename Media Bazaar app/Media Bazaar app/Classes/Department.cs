using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_app.Classes
{
    class Department
    {
        private string tableName = "department";
        private readonly List<string> toSelect;
        private List<string> whereValues;
        private List<string> whereNames;
        private List<string> setColumnName;
        private List<string> setColumnValue;
        private List<Department> localDepartments;
        private DatabaseConnection database;

        public string Name
        {
            get;
            private set;
        }

        public Department()
        {
            localDepartments = new List<Department>();
        }

        public Department(string name)
        {
            this.Name = name;
        }

        public void GetDeparmentsFromDatabase()
        {
            database = new DatabaseConnection();

            foreach(DataRow reader in database.GetDataFromDatabase(tableName, toSelect, whereValues, whereNames).Rows)
            {
                localDepartments.Add(new Department(reader[0].ToString()));
            }
        }

        public void CreateNewDepartment(string name)
        {
            ValidationManager applicationManager = new ValidationManager();

            if (applicationManager.ValidateNewDepartment(name))
            {
                database = new DatabaseConnection();

                setColumnValue = new List<string>()
                {
                    name
                };

                setColumnName = new List<string>()
                {
                    "Department"
                };

                database.InsertIntoDatabase(tableName, setColumnValue, setColumnName);
                AddNewDepartmentInLocalList(name);
            }
        }

        private void AddNewDepartmentInLocalList(string name)
        {
            localDepartments.Add(new Department(name));
        }

        public void EditExistingDepartmentName(string newName, string oldName)
        {
            ValidationManager applicationManager = new ValidationManager();

            if(applicationManager.ValidateNewDepartment(newName))
            {
                setColumnName = new List<string>()
                {
                    "Department"
                };

                setColumnValue = new List<string>()
                {
                    newName
                };

                whereNames = new List<string>()
                {
                    "Department"
                };

                whereValues = new List<string>()
                {
                    oldName
                };


                database.UpdateInDatabase(tableName, setColumnName, setColumnValue, whereValues, whereNames);
                EditDepartmentInLocalList(oldName, newName);

            }      
        }

        private void EditDepartmentInLocalList(string oldName, string newName)
        {
            foreach(Department department in localDepartments)
            {
                if(department.Name == oldName)
                {
                    department.Name = newName;
                }
            }
        }

        public void RemoveDepartmentFromDatabase(string name)
        {
            database = new DatabaseConnection();

            setColumnValue = new List<string>()
                {
                    name
                };

            setColumnName = new List<string>()
                {
                    "Department"
                };

            database.DeleteFromDatabase(tableName, setColumnValue, setColumnName);
            RemoveDepartmentFromLocalList(name);
        }

        private void RemoveDepartmentFromLocalList(string name)
        {
            for(int i = 0; i < localDepartments.Count; i++)
            {
                if(localDepartments[i].Name == name)
                {
                    localDepartments.Remove(localDepartments[i]);
                }
            }
        }

        public List<Department> ReturnDepartmentLocalList()
        {
            return localDepartments;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
