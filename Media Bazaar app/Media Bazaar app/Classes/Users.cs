using Media_Bazaar_app.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_app.Views
{
    public class Users
    {
        readonly private string connectionString = "Server=studmysql01.fhict.local;Uid=dbi438993;Database=dbi438993;Pwd=blabla;";
        private readonly List<Users> usersPerDepartment = new List<Users>();
        private readonly List<Users> administrationUsers = new List<Users>();
        private List<Users> searchUsers;
        private Users user;
        private int lastID;

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

        public int Active
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

        public Users() { }

        public Users(string firstName,string lastName, int active, string AccountType, string position)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Active = active;
            this.AccountType = AccountType;
            this.Position = position;
        }

        public Users(int id, string department, string firstName, string lastName, string contractType, string position)
        {
            this.Department = department;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ContractType = contractType;
            this.Position = position;
            this.Id = id;
        }

        public Users(int id, string firstName, string lastName,string birthDate,
                     string birthPlace, string bsn, string address, string phoneNumber, string ecName,
                     string ecNumber, string startDate, string endDate,string careerHistory, string position,
                     string department, string contractType, string terminationReason,int active, string email,
                     string username, string password, string AccountType, string zipcode)
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
            this.AccountType = AccountType;
            this.ZipCode = zipcode;
            this.Position = position;
            this.TerminationReason = terminationReason;
            this.EndDate = endDate;
        }

        public bool CreateUser(string firstName, string lastName, string birthDate,
                               string birthPlace, string bsn, string address, string phoneNumber, string ecName,
                               string ecNumber, string startDate, string careerHistory, string position,
                               string department, string contractType, string active, string email, string username,
                               string password, string AccountType, string zipcode)
        {

            int status;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName))
            {
                throw new Exception("Please enter a first name");
            }
            else if (string.IsNullOrEmpty(lastName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new Exception("Please enter a last name");
            }
            else if (string.IsNullOrWhiteSpace(birthPlace) || string.IsNullOrEmpty(birthPlace))
            {
                throw new Exception("Please enter birthplace");
            }
            else if (string.IsNullOrEmpty(bsn) || string.IsNullOrWhiteSpace(bsn))
            {
                throw new Exception("Please enter BSN");
            }
            else if (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address))
            {
                throw new Exception("Please enter a address");
            }
            else if (string.IsNullOrEmpty(zipcode) || string.IsNullOrWhiteSpace(zipcode))
            {
                throw new Exception("Please enter a zipcode");
            }
            else if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new Exception("Please enter a phone number");
            }
            else if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Please enter email address");
            }
            else if (string.IsNullOrEmpty(ecName) || string.IsNullOrWhiteSpace(ecName))
            {
                throw new Exception("Please enter an emergency contact name");
            }
            else if (string.IsNullOrEmpty(ecNumber) || string.IsNullOrWhiteSpace(ecNumber))
            {
                throw new Exception("Please enter an emergency contact phone number");
            }
            else if (string.IsNullOrEmpty(contractType))
            {
                throw new Exception("Please select contract type");
            }
            else if (string.IsNullOrEmpty(active) || string.IsNullOrWhiteSpace(active))
            {
                throw new Exception("Please select status");
            }
            else if (string.IsNullOrEmpty(AccountType) || string.IsNullOrWhiteSpace(AccountType))
            {
                throw new Exception("Please select account type");
            }
            else if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Please enter username");
            }
            else if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Please enter password");
            }
            
            else 
            {

                if(active == "Active")
                {
                    status = 1;
                }

                else
                {
                    status = 0;
                }

                if(AccountType == "Floor")
                {
                    if(string.IsNullOrEmpty(department) == true)
                    {
                        throw new Exception("Please select department for this type of account");
                    }

                    if(string.IsNullOrEmpty(position) == true)
                    {
                        throw new Exception("Please select position for this type of account");
                    }
                }
                else
                {
                    position = null;
                    department = null;
                }

                string query = "INSERT INTO user SET id = NULL, firstName= @firstName, lastName=@lastName, birthDate=@birthDate, birthPlace= @birthPlace, bsn =@bsn , address=@address, phoneNumber = @phoneNumber, ecName= @ecName, ecNumber = @ecNumber, startDate=@startDate, endDate=NULL,careerHistory= @careerHistory, position=@position ,department= @department, contractType =@contractType, terminationReason=NULL, active =@active, email=@email, username= @username, password = @password, AccountType = @accountType, zipcode=@zipcode";
                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, conn);
                commandDatabase.Parameters.AddWithValue("firstName", firstName);
                commandDatabase.Parameters.AddWithValue("lastName", lastName);
                commandDatabase.Parameters.AddWithValue("birthDate", birthDate);
                commandDatabase.Parameters.AddWithValue("birthPlace", birthPlace);
                commandDatabase.Parameters.AddWithValue("bsn", bsn);
                commandDatabase.Parameters.AddWithValue("address", address);
                commandDatabase.Parameters.AddWithValue("phoneNumber", phoneNumber);
                commandDatabase.Parameters.AddWithValue("ecName", ecName);
                commandDatabase.Parameters.AddWithValue("ecNumber", ecNumber);
                commandDatabase.Parameters.AddWithValue("contractType", contractType);
                commandDatabase.Parameters.AddWithValue("startDate", startDate);
                commandDatabase.Parameters.AddWithValue("department", department);
                commandDatabase.Parameters.AddWithValue("username", username);
                commandDatabase.Parameters.AddWithValue("password", password);
                commandDatabase.Parameters.AddWithValue("email", email);
                commandDatabase.Parameters.AddWithValue("careerHistory", careerHistory);
                commandDatabase.Parameters.AddWithValue("position", position);
                commandDatabase.Parameters.AddWithValue("accountType", AccountType);
                commandDatabase.Parameters.AddWithValue("zipcode", zipcode);
                commandDatabase.Parameters.AddWithValue("active", status);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;
                string terminationReason = null;
                string endDate = null;

                try
                {
                    conn.Open();
                    reader = commandDatabase.ExecuteReader();
                    administrationUsers.Add(new Users(lastID+1, firstName, lastName, birthDate,
                    birthPlace, bsn, address, phoneNumber, ecName,
                    ecNumber, startDate, endDate, careerHistory, position, department, contractType,
                    terminationReason, status, email, password,
                    password, AccountType, zipcode));                  
                }

                catch(Exception ex)
                {
                    
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
                return true;
            }
        }


        public bool EditUser(int id, string firstName, string lastName, string birthDate,
                             string birthPlace, string bsn, string address, string phoneNumber, string ecName,
                             string ecNumber, string startDate, string endDate, string careerHistory, string position, string
                             department, string contractType, string terminationReason, string active, string email, string username,
                             string password, string AccountType, string zipcode)
        {
            int status;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName))
            {
                throw new Exception("Please enter a first name");
            }
            else if (string.IsNullOrEmpty(lastName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new Exception("Please enter a last name");
            }
            else if (string.IsNullOrWhiteSpace(birthPlace) || string.IsNullOrEmpty(birthPlace))
            {
                throw new Exception("Please enter birthplace");
            }
            else if (string.IsNullOrEmpty(bsn) || string.IsNullOrWhiteSpace(bsn))
            {
                throw new Exception("Please enter BSN");
            }
            else if (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address))
            {
                throw new Exception("Please enter a address");
            }
            else if (string.IsNullOrEmpty(zipcode) || string.IsNullOrWhiteSpace(zipcode))
            {
                throw new Exception("Please enter a zipcode");
            }
            else if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new Exception("Please enter a phone number");
            }
            else if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Please enter email address");
            }
            else if (string.IsNullOrEmpty(ecName) || string.IsNullOrWhiteSpace(ecName))
            {
                throw new Exception("Please enter an emergency contact name");
            }
            else if (string.IsNullOrEmpty(ecNumber) || string.IsNullOrWhiteSpace(ecNumber))
            {
                throw new Exception("Please enter an emergency contact phone number");
            }
            else if (string.IsNullOrEmpty(contractType))
            {
                throw new Exception("Please select contract type");
            }
            else if (string.IsNullOrEmpty(active) || string.IsNullOrWhiteSpace(active))
            {
                throw new Exception("Please select status");
            }
            else if (string.IsNullOrEmpty(AccountType) || string.IsNullOrWhiteSpace(AccountType))
            {
                throw new Exception("Please select account type");
            }
            else if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Please enter username");
            }
            else if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Please enter password");
            }

            else
            {

                if (active == "Active")
                {
                    status = 1;
                }

                else
                {
                    status = 0;
                }

                if (AccountType == "Floor")
                {
                    if (string.IsNullOrEmpty(department) == true)
                    {
                        throw new Exception("Please select department for this type of account");
                    }

                    if (string.IsNullOrEmpty(position) == true)
                    {
                        throw new Exception("Please select position for this type of account");
                    }
                }
                else
                {
                    position = null;
                    department = null;
                }

                if (status == 0)
                {
                    if (string.IsNullOrWhiteSpace(terminationReason) || string.IsNullOrEmpty(terminationReason))
                    {
                        throw new Exception("Please enter termination reason");
                    }
                }

                else
                {
                    endDate = null;
                }

                string query = "UPDATE user SET firstName=@firstName, lastName=@lastName, birthDate=@birthDate, birthPlace=@birthPlace, bsn=@bsn, " +
                               "address=@address, phoneNumber=@phoneNumber, ecName=@ecName, ecNumber=@ecNumber, startDate=@startDate," +
                               "endDate=@endDate, careerHistory=@careerHistory, position=@position ,department=@department, contractType=@contractType, " +
                               "terminationReason=@terminationReason, active=@active, email=@email, username=@username, password=@password, AccountType=@accountType," +
                               "zipcode=@zipcode WHERE id=@id";
                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, conn);

                commandDatabase.Parameters.AddWithValue("id", id);
                commandDatabase.Parameters.AddWithValue("firstName", firstName);
                commandDatabase.Parameters.AddWithValue("lastName", lastName);
                commandDatabase.Parameters.AddWithValue("birthDate", birthDate);
                commandDatabase.Parameters.AddWithValue("birthPlace", birthPlace);
                commandDatabase.Parameters.AddWithValue("bsn", bsn);
                commandDatabase.Parameters.AddWithValue("address", address);
                commandDatabase.Parameters.AddWithValue("phoneNumber", phoneNumber);
                commandDatabase.Parameters.AddWithValue("ecName", ecName);
                commandDatabase.Parameters.AddWithValue("ecNumber", ecNumber);
                commandDatabase.Parameters.AddWithValue("startDate", startDate);
                commandDatabase.Parameters.AddWithValue("endDate", endDate);
                commandDatabase.Parameters.AddWithValue("careerHistory", careerHistory);
                commandDatabase.Parameters.AddWithValue("position", position);
                commandDatabase.Parameters.AddWithValue("department", department);
                commandDatabase.Parameters.AddWithValue("contractType", contractType);
                commandDatabase.Parameters.AddWithValue("terminationReason", terminationReason);
                commandDatabase.Parameters.AddWithValue("active", status);
                commandDatabase.Parameters.AddWithValue("email", email);
                commandDatabase.Parameters.AddWithValue("username", username);
                commandDatabase.Parameters.AddWithValue("password", password);
                commandDatabase.Parameters.AddWithValue("accountType", AccountType);
                commandDatabase.Parameters.AddWithValue("zipcode", zipcode);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                try
                {
                    conn.Open();
                    reader = commandDatabase.ExecuteReader();
                    foreach (Users user in administrationUsers)
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
                            user.AccountType = AccountType;
                            user.ZipCode = zipcode;
                            user.TerminationReason = terminationReason;                           
                            user.EndDate = endDate;
                            user.Active = status;
                            user.Position = position;                            
                        }
                    }
                }

                catch
                { 
                    return false;                   
                }
                finally
                {
                    conn.Close();
                }
                return true;
            }
        }

        public List<Users> AllUsers()
        {
            administrationUsers.Clear();
            string query = "SELECT * FROM user";
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sendCommand = new MySqlCommand(query, sqlConnection);

            try
            {
                sqlConnection.Open();
                MySqlDataReader reader = sendCommand.ExecuteReader();

                while (reader.Read())
                {
                    Users user = new Users(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(),
                                           reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(),
                                           reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString(), 
                                           reader[16].ToString(), Convert.ToInt32(reader[17].ToString()), reader[18].ToString(), reader[19].ToString(), reader[20].ToString(),
                                           reader[21].ToString(), reader[22].ToString());
                    administrationUsers.Add(user);
                    lastID = Convert.ToInt32(reader[0].ToString());
                }
            }

            catch
            {
              
            }
            finally
            {
                sqlConnection.Close();
            }
            return administrationUsers;
        }

        public List<Users> AllLocalUsers()
        {
            return administrationUsers;
        }

        public List<Users> AllFloorUsers()
        {
            administrationUsers.Clear();
            string query = "SELECT * FROM user WHERE accountType='Floor'";
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sendCommand = new MySqlCommand(query, sqlConnection);

            try
            {
                sqlConnection.Open();
                MySqlDataReader reader = sendCommand.ExecuteReader();

                while (reader.Read())
                {
                    Users user = new Users(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(),
                                           reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(),
                                           reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), reader[13].ToString(), reader[14].ToString(), reader[15].ToString(),
                                           reader[16].ToString(), Convert.ToInt32(reader[17].ToString()), reader[18].ToString(), reader[19].ToString(), reader[20].ToString(),
                                           reader[21].ToString(), reader[22].ToString());
                    administrationUsers.Add(user);
                    lastID = Convert.ToInt32(reader[0].ToString());
                }
            }

            catch
            {

            }
            finally
            {
                sqlConnection.Close();
            }
            return administrationUsers;
        }

        public List<Users> BrowseUsersPerDepartment(string department)
        {
            usersPerDepartment.Clear();
            foreach (Users user in administrationUsers)
            {
                if (department == "All")
                {
                    return administrationUsers;
                }
                else
                {
                    if (user.Department == department)
                    {
                        usersPerDepartment.Add(user);
                    }
                }
            }
            return usersPerDepartment;
        }

        public Users AuthenticateUser(string username, string password)
        {
            string query = "SELECT firstName, lastName, active, accountType, position FROM user WHERE username=@username AND password=@password";
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sendCommand = new MySqlCommand(query, sqlConnection);
            sendCommand.Parameters.AddWithValue("username", username);
            sendCommand.Parameters.AddWithValue("password", password);
            user = null;

            try
            {
                sqlConnection.Open();
                MySqlDataReader reader = sendCommand.ExecuteReader();

                while (reader.Read())
                {
                    user = new Users(reader[0].ToString(), reader[1].ToString(),Convert.ToInt32(reader[2]), reader[3].ToString(), reader[4].ToString());
                }
            }
            catch
            {
                throw new Exception("Please connect to VPN and try again");
            }
            finally
            {
                sqlConnection.Close();
            }
           
            if (user == null)
            {
                throw new Exception("Invalid username or password");
            }
            else
            {
                if (user.Active == 0)
                {
                    throw new Exception("Account is disabled");
                }
                else if (user.Active == 1)
                {
                    if (user.AccountType == "Admin")
                    {
                        AdministrationView f1 = new AdministrationView(user);
                        f1.Show();
                    }
                    else if (user.AccountType == "Floor")
                    {
                        if (user.Position == "Security Guard")
                        {
                            FloorScheduleView f3 = new FloorScheduleView(user);
                            f3.Show();
                        }
                        else
                        {
                            FloorView f2 = new FloorView(user);
                            f2.Show();
                        }
                    }
                    else if (user.AccountType == "Manager")
                    {
                        throw new Exception("This type of account is not permitted");
                    }
                }
            }
            return user;
        }


        public void MoveEmployee(string name, string department)
        {
            string[] stringArray;
            char[] split = { ' ' };
            stringArray = name.Split(split);
            string firstName = stringArray[0];
            string lastName = stringArray[1];


            string query = "UPDATE user SET department=@department WHERE firstName=@firstName AND lastName=@lastName";

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, conn);
            commandDatabase.Parameters.AddWithValue("firstName", firstName);
            commandDatabase.Parameters.AddWithValue("lastName", lastName);
            commandDatabase.Parameters.AddWithValue("department", department);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                conn.Open();
                reader = commandDatabase.ExecuteReader();
                foreach (Users user in usersPerDepartment)
                {
                    if (user.FirstName + " " + user.LastName == name)
                    {
                        user.Department = department;
                    }
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

        public void MoveAllEmployees(string newDepartment, string oldDepartment)
        {
            
            string query = "UPDATE user SET department=@newDepartment WHERE department=@oldDepartment";

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

        public List<Users> SearchUsers(string partial, string department)
        {
            searchUsers = new List<Users>();

            foreach (Users user in administrationUsers)
            {
                string fullName = user.FirstName + " " + user.LastName;
                if (fullName.ToUpper().StartsWith(partial.ToUpper()))
                {
                    if (fullName.ToUpper().Contains(partial.ToUpper()))
                    {
                        if (user.Department == department)
                        {
                            searchUsers.Add(user);
                        }
                        else if (department == "All")
                        {
                            searchUsers.Add(user);
                        }
                    }
                }
            }
            return searchUsers;
        }       
    }
}
