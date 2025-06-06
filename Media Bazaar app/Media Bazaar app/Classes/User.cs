using Media_Bazaar_app.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_app.Classes
{
    public class User
    {
        private string tableName = "user";

        private List<string> toSelect;
        private List<string> whereValues;
        private List<string> whereNames;
        private List<string> setColumnName;
        private List<string> setColumnValue;
        private List<User> localUsers;

        private DatabaseConnection database;
        private ValidationManager applicationManager;

        public int Id
        {
            get;
            private set;
        }

        public string FirstName
        {
            get;
            private set;
        }

        public string LastName
        {
            get;
            private set;
        }

        public string BirthDate
        {
            get;
            private set;
        }

        public string BirthPlace
        {
            get;
            private set;
        }

        public string Bsn
        {
            get;
            private set;
        }

        public string Address
        {
            get;
            private set;
        }

        public string PhoneNumber
        {
            get;
            private set;
        }

        public string EcName
        {
            get;
            private set;
        }

        public string EcNumber
        {
            get;
            private set;
        }

        public string StartDate
        {
            get;
            private set;
        }

        public string CareerHistory
        {
            get;
            private set;
        }

        public string Position
        {
            get;
            private set;
        }

        public string Email
        {
            get;
            private set;
        }

        public string Username
        {
            get;
            private set;
        }

        public string Password
        {
            get;
            private set;
        }

        public string ZipCode
        {
            get;
            private set;
        }

        public string Department
        {
            get;
            private set;
        }

        public string Active
        {
            get;
            private set;
        }

        public string AccountType
        {
            get;
            private set;
        }

        public string ContractType
        {
            get;
            private set;
        }

        public string TerminationReason
        {
            get;
            private set;
        }

        public string EndDate
        {
            get;
            private set;
        }

        public User() 
        {
            localUsers = new List<User>();
        }

        public User(string firstName, string lastName, string active, string AccountType, string position, string department)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Active = active;
            this.AccountType = AccountType;
            this.Position = position;
            this.Department = department;
        }

        public User(string department, string firstName, string lastName, string contractType, string position)
        {
            this.Department = department;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ContractType = contractType;
            this.Position = position;
        }

        public User(int id, string firstName, string lastName, string birthDate,
                     string birthPlace, string bsn, string address, string phoneNumber, string ecName,
                     string ecNumber, string startDate, string endDate, string careerHistory, string position,
                     string department, string contractType, string terminationReason, string active, string email,
                     string username, string password, string accountType, string zipcode)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.BirthPlace = birthPlace;
            this.Bsn = bsn;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.EcName = ecName;
            this.EcNumber = ecNumber;
            this.StartDate = startDate;
            this.CareerHistory = careerHistory;
            this.Department = department;
            this.ContractType = contractType;
            this.Active = active;
            this.Email = email;
            this.Username = username;
            this.Password = password;
            this.AccountType = accountType;
            this.ZipCode = zipcode;
            this.Position = position;
            this.TerminationReason = terminationReason;
            this.EndDate = endDate;
        }


        public User AuthenticateUser(string username, string password)
        {
            User user = null;
            applicationManager = new ValidationManager();

            if (applicationManager.ValidateUserLogin(username, password) == true)
            {
                database = new DatabaseConnection();

                //Values to select from Database
                toSelect = new List<string>();
                toSelect.Add("firstName");
                toSelect.Add("lastName");
                toSelect.Add("active");
                toSelect.Add("accountType");
                toSelect.Add("position");
                toSelect.Add("department");

                //Column names from Database
                whereNames = new List<string>();
                whereNames.Add("username");
                whereNames.Add("password");

                //WHERE Column values
                whereValues = new List<string>();
                whereValues.Add(username);
                whereValues.Add(password);

                try
                {

                    foreach (DataRow result in database.GetDataFromDatabase(tableName, toSelect, whereValues, whereNames).Rows)
                    {
                        user = new User(result[0].ToString(), result[1].ToString(), result[2].ToString(), result[3].ToString(), result[4].ToString(), result[5].ToString());
                    }
                }
                catch
                {
                    throw new Exception("Please connect to VPN and try again");
                }
            }

            return user;
        }

        public bool CreateNewUser(string firstName, string lastName, string birthDate,
                                  string birthPlace, string terminationReason, string bsn, string address, string phoneNumber,
                                  string ecName, string ecNumber, string startDate, string careerHistory, string position,
                                  string department, string contractType, string active, string email, string username,
                                  string password, string accountType, string zipcode)
        {
            applicationManager = new ValidationManager();

            if (applicationManager.ValidateUserDetails(firstName, lastName, birthPlace, terminationReason, bsn, address, phoneNumber,
                                                      ecName, ecNumber, position, department, contractType, active, email,
                                                      username, password, accountType, zipcode) == false)
            {
                return false;
            }
            else
            {
                database = new DatabaseConnection();

                setColumnName = new List<string>
            {
                    "firstName",
                    "lastName",
                    "birthDate",
                    "birthPlace",
                    "bsn",
                    "address",
                    "phoneNumber",
                    "ecName",
                    "ecNumber",
                    "startDate",
                    "careerHistory",
                    "position",
                    "department",
                    "contractType",
                    "active",
                    "email",
                    "username",
                    "password",
                    "accountType",
                    "zipcode"
                };

                setColumnValue = new List<string>
            {
                    firstName,
                    lastName,
                    birthDate,
                    birthPlace,
                    bsn,
                    address,
                    phoneNumber,
                    ecName,
                    ecNumber,
                    startDate,
                    careerHistory,
                    position,
                    department,
                    contractType,
                    active,
                    email,
                    username,
                    password,
                    accountType,
                    zipcode
                };

                try
                {


                    database.InsertIntoDatabase(tableName, setColumnValue, setColumnName);
                    AddUserToLocalList(firstName, lastName, birthDate,
                                      birthPlace, terminationReason, bsn, address, phoneNumber,
                                      ecName, ecNumber, startDate, careerHistory, position,
                                      department, contractType, active, email, username,
                                      password, accountType, zipcode);
                }
                catch
                {
                    throw new Exception("A user with the same username already exists");
                }
            }
            return true;
        }

        private void AddUserToLocalList(string firstName, string lastName, string birthDate,
                                  string birthPlace, string terminationReason, string bsn, string address, string phoneNumber,
                                  string ecName, string ecNumber, string startDate, string careerHistory, string position,
                                  string department, string contractType, string active, string email, string username,
                                  string password, string accountType, string zipcode)
        {
            localUsers.Add(new User(NextUserId(), firstName, lastName, birthDate,
                                 birthPlace, bsn, address, phoneNumber, ecName,
                                 ecNumber, startDate, " ", careerHistory, position,
                                 department, contractType, terminationReason, active, email,
                                 username, password, accountType, zipcode));
        }

        public bool EditExistingUser(int id, string firstName, string lastName, string birthDate,
                                     string birthPlace, string bsn, string address, string phoneNumber, string ecName,
                                     string ecNumber, string startDate, string endDate, string careerHistory, string position,
                                     string department, string contractType, string terminationReason, string active, string email, string username,
                                     string password, string accountType, string zipcode)
        {
            applicationManager = new ValidationManager();

            if (applicationManager.ValidateUserDetails(firstName, lastName, birthPlace, terminationReason, bsn, address, phoneNumber,
                                                      ecName, ecNumber, position, department, contractType, active, email,
                                                      username, password, accountType, zipcode) == false)
            {
                return false;
            }
            else
            {
                database = new DatabaseConnection();

                setColumnName = new List<string>
            {
                    "firstName",
                    "lastName",
                    "birthDate",
                    "birthPlace",
                    "address",
                    "phoneNumber",
                    "ecName",
                    "ecNumber",
                    "startDate",
                    "careerHistory",
                    "position",
                    "department",
                    "contractType",
                    "active",
                    "email",
                    "username",
                    "password",
                    "accountType",
                    "zipcode"
                };

                setColumnValue = new List<string>
            {
                    firstName,
                    lastName,
                    birthDate,
                    birthPlace,
                    address,
                    phoneNumber,
                    ecName,
                    ecNumber,
                    startDate,
                    careerHistory,
                    position,
                    department,
                    contractType,
                    active,
                    email,
                    username,
                    password,
                    accountType,
                    zipcode
                };

                whereNames = new List<string>();
                whereNames.Add("id");

                whereValues = new List<string>();
                whereValues.Add(id.ToString());

                if (active == "Inactive")
                {
                    setColumnName.Add("endDate");
                    setColumnName.Add("terminationReason");
                    setColumnValue.Add(endDate);
                    setColumnValue.Add(terminationReason);
                }
                database.UpdateInDatabase(tableName, setColumnName, setColumnValue, whereValues, whereNames);
                EditInLocalList(id, firstName, lastName, birthDate,
                                birthPlace, address, phoneNumber, ecName,
                                ecNumber, startDate, endDate, careerHistory, position,
                                department, contractType, terminationReason, active, email, username,
                                password, accountType, zipcode, bsn);
            }
            return true;
        }

        private void EditInLocalList(int id, string firstName, string lastName, string birthDate,
                                     string birthPlace, string address, string phoneNumber, string ecName,
                                     string ecNumber, string startDate, string endDate, string careerHistory, string position,
                                     string department, string contractType, string terminationReason, string active, string email, string username,
                                     string password, string accountType, string zipcode, string bsn)
        {
            foreach (User user in localUsers)
            {
                if (user.Id == id)
                {
                    user.FirstName = firstName;
                    user.LastName = lastName;
                    user.BirthDate = birthDate;
                    user.BirthPlace = birthPlace;
                    user.Bsn = bsn;
                    user.Address = address;
                    user.PhoneNumber = phoneNumber;
                    user.EcName = ecName;
                    user.EcNumber = ecNumber;
                    user.ContractType = contractType;
                    user.StartDate = startDate;
                    user.Department = department;
                    user.Username = username;
                    user.Password = password;
                    user.Email = email;
                    user.CareerHistory = careerHistory;
                    user.AccountType = accountType;
                    user.ZipCode = zipcode;
                    user.TerminationReason = terminationReason;
                    user.EndDate = endDate;
                    user.Active = active;
                    user.Position = position;
                }
            }
        }

        public void GetAllUsersFromDatabase()
        {
            database = new DatabaseConnection();
            localUsers.Clear();

            foreach (DataRow reader in database.GetDataFromDatabase(tableName, toSelect, whereValues, whereNames).Rows)
            {
                localUsers.Add(new User(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(),
                                          reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(),
                                          reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString(),
                                          reader[16].ToString(), reader[17].ToString(), reader[18].ToString(), reader[19].ToString(), reader[20].ToString(),
                                          reader[21].ToString(), reader[22].ToString()));
            }
        }

        public void GetUsersForAutomatedSchedule(string department)
        {
            database = new DatabaseConnection();
            localUsers.Clear();

            toSelect = new List<string>()
            {
                "firstName",
                "lastName",
                "department",
                "position",
                "contractType"
            };

            whereNames = new List<string>()
            {
                "department",
                "active"
            };

            whereValues = new List<string>()
            {
                department,
                "Active"
            };

            foreach (DataRow reader in database.GetDataFromDatabase(tableName, toSelect, whereValues, whereNames).Rows)
            {
                localUsers.Add(new User(reader[2].ToString(), reader[0].ToString(), reader[1].ToString(), reader[4].ToString(), reader[3].ToString()));
            }
        }

        public List<User> ReturnUsersLocalList()
        {
            return localUsers;
        }

        public List<User> FilterLocalUsersListByDepartment(string department)
        {
            List<User> usersByDepartment = new List<User>();

            foreach (User user in localUsers)
            {
                if (user.Department == department)
                {
                    usersByDepartment.Add(user);
                }
            }
            return usersByDepartment;
        }

        public List<User> SearchUser(string partial, string department)
        {
            List<User> searchedUser = new List<User>();

            foreach (User user in localUsers)
            {
                string fullName = user.FirstName + " " + user.LastName;
                if (fullName.ToUpper().StartsWith(partial.ToUpper()))
                {
                    if (fullName.ToUpper().Contains(partial.ToUpper()))
                    {
                        if (user.Department == department)
                        {
                            searchedUser.Add(user);
                        }
                        else if (department == "All")
                        {
                            searchedUser.Add(user);
                        }
                    }
                }
            }
            return searchedUser;
        }

        private int NextUserId()
        {
            // I subtract 1 because message is already added to database

            return database.GetFromSchema("user") - 1;
        }

        public User GetUserInfo(string name)
        {
            User fetchedUser = null;

            foreach (User user in localUsers)
            {
                if (user.FirstName + " " + user.LastName == name)
                {
                    fetchedUser = new User(user.Id, user.FirstName, user.LastName, user.BirthDate,
                                           user.BirthPlace, user.Bsn, user.Address, user.PhoneNumber, user.EcName,
                                           user.EcNumber, user.StartDate, user.EndDate, user.CareerHistory, user.Position,
                                           user.Department, user.ContractType, user.TerminationReason, user.Active, user.Email,
                                           user.Username, user.Password, user.AccountType, user.ZipCode);
                }
            }
            return fetchedUser;
        }

        public int GetUserId(string name)
        {
            int userID = 0;
            foreach(User user in localUsers)
            {
                if(user.FirstName + " " + user.LastName == name)
                {
                    userID = user.Id;
                }
            }
            return userID;
        }

        public string GetUserDepartment(string selected)
        {
            string department = null;

            foreach (User user in localUsers)
            {
                string fullName = user.FirstName + " " + user.LastName;

                if (selected == fullName)
                {
                    department = user.Department;
                }
            }

            return department;
        }

        public string GetUserPosition(string selected)
        {
            string position = null;

            foreach (User user in localUsers)
            {
                string fullName = user.FirstName + " " + user.LastName;

                if (selected == fullName)
                {
                    position = user.Position;
                }
            }
            return position;
        }

        public string GetUserContract(string selected)
        {
            string contractType = null;

            foreach (User user in localUsers)
            {
                string fullName = user.FirstName + " " + user.LastName;

                if (selected == fullName)
                {
                    contractType = user.ContractType;
                }
            }
            return contractType;
        }

        public void MoveAllFloorToDepartment(string oldDepartment, string newDepartment)
        {

            database = new DatabaseConnection();

            setColumnName = new List<string>()
            {
                "department"
            };

            setColumnValue = new List<string>()
            {
                newDepartment
            };

            whereNames = new List<string>()
            {
                "department"
            };

            whereValues = new List<string>()
            {
                oldDepartment
            };

            database.UpdateInDatabase(tableName, setColumnName, setColumnValue, whereValues, whereNames);
            MoveAllFloorToDepartmentInLocalList(oldDepartment, newDepartment);
        }

        public void MoveFloorEmployeeToDepartemnt(string newDepartment, string name)
        {
            int id = GetUserId(name);

            database = new DatabaseConnection();

            setColumnName = new List<string>()
            {
                "department"
            };

            setColumnValue = new List<string>()
            {
                newDepartment
            };

            whereNames = new List<string>()
            {
                "id"
            };

            whereValues = new List<string>()
            {
                id.ToString()
            };

            database.UpdateInDatabase(tableName, setColumnName, setColumnValue, whereValues, whereNames);
            MoveFloorEmployeeToDepartmnetInLocalList(newDepartment, id);
        }

        private void MoveAllFloorToDepartmentInLocalList(string oldDepartment, string newDepartment)
        {
            foreach (User user in localUsers)
            {
                if (user.Department == oldDepartment)
                {
                    user.Department = newDepartment;
                }
            }
        }

        private void MoveFloorEmployeeToDepartmnetInLocalList(string newDepartment, int id)
        {
            foreach (User user in localUsers)
            {
                if (user.Id == id)
                {
                    user.Department = newDepartment;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
