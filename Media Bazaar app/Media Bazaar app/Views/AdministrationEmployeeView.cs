using Media_Bazaar_app.Classes;
using Media_Bazaar_app.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Bazaar_app
{
    public partial class AdministrationEmployeeView : Form
    {
        private User userControl;
        private Department departmentControl;

        public AdministrationEmployeeView()
        {
            InitializeComponent();
            LoadGUI();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            rtbHistory.Text = "Hired: " + dtStart.Value.ToString("dd/MM/yyyy");
            CreateNewUser(tbFirstName.Text, tbLastName.Text, dtBirthday.Value.ToString("dd/MM/yyyy"), tbBirthplace.Text, rtbReason.Text,tbBSN.Text,
                          tbAddress.Text, tbPhone.Text, tbEmergencyName.Text, tbEmergencyNr.Text, dtStart.Value.ToString("dd/MM/yyyy"), 
                          rtbHistory.Text, cbxPosition.Text, cbDepartment.Text, cbContract.Text, cbStatus.Text, tbEmail.Text, 
                          tbUsername.Text, tbPassword.Text, cbAccountType.Text, tbZipCode.Text);
        }
    
        private void cbSearchdepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchdepartment.SelectedIndex == 0)
            {
                PopulateUserListbox();
            }
            else
            {
                PopulateUserListboxByDepartment(cbSearchdepartment.Text);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id;
            int index = lbEmployees.SelectedIndex;
            if (string.IsNullOrEmpty(tbID.Text))
            {
                MessageBox.Show("Please select user");
            }
            else
            {
                id = Convert.ToInt32(tbID.Text);

                string department = "";
                string endDate = "";
                string position = "";

                if (cbAccountType.Text == "Floor")
                {
                    position = cbxPosition.Text;
                    department = cbDepartment.Text;
                }
                if (cbStatus.Text == "Inactive")
                {
                    endDate = dtEnd.Value.ToString("dd/MM/yyyy");
                }

                EditEmployees(id, tbFirstName.Text, tbLastName.Text, dtBirthday.Value.ToString("dd/MM/yyyy"), tbBirthplace.Text,
                              tbBSN.Text, tbAddress.Text, tbPhone.Text, tbEmergencyName.Text, tbEmergencyNr.Text,
                              dtStart.Value.ToString("dd/MM/yyyy"), endDate, rtbHistory.Text, position, department, cbContract.Text,
                              rtbReason.Text, cbStatus.Text, tbEmail.Text, tbUsername.Text, tbPassword.Text, cbAccountType.Text,
                              tbZipCode.Text);
                lbEmployees.SelectedIndex = index;
            }
        }

        private void lbEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbEmployees.SelectedIndex != -1)
            {
                GetEmployeeData();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbID.Text = "";
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbBirthplace.Text = "";
            tbBSN.Text = "";
            cbDepartment.SelectedIndex = -1;
            tbAddress.Text = "";
            tbZipCode.Text = "";
            tbPhone.Text = "";
            tbEmergencyName.Text = "";
            tbEmergencyNr.Text = "";
            rtbHistory.Text = "";
            cbContract.SelectedIndex = -1;
            cbStatus.SelectedIndex = -1;
            tbEmail.Text = "";
            tbUsername.Text = "";
            tbPassword.Text = "";
            cbAccountType.SelectedIndex = -1;
            rtbHistory.Text = "";
            cbxPosition.SelectedIndex = -1;
        }

        private void cbAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbAccountType.SelectedIndex == 1 || cbAccountType.SelectedIndex == 2)
            {
                cbDepartment.SelectedIndex = -1;
                cbxPosition.SelectedIndex = -1;
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text) || string.IsNullOrWhiteSpace(tbSearch.Text))
            {
                if (cbSearchdepartment.SelectedIndex == 0)
                {
                    PopulateUserListbox();
                }
                else
                {
                    PopulateUserListboxByDepartment(cbSearchdepartment.Text);
                }
            }
            else
            {
                SearchUser(tbSearch.Text, cbSearchdepartment.Text);
            }
        }

        private void CreateNewUser(string firstName, string lastName, string birthDate, string birthPlace, string terminationReason,string bsn, string address,
                                   string phoneNumber, string ecName, string ecNumber, string startDate, string careerHistory, string position,
                                   string department, string contractType, string active, string email, string username,
                                   string password, string AccountType, string zipCode)
        {
            try
            {
                if (userControl.CreateNewUser(firstName, lastName, birthDate,
                      birthPlace, terminationReason, bsn, address, phoneNumber, ecName,
                      ecNumber, startDate, careerHistory, position,
                      department, contractType, active, email, username,
                      password, AccountType, zipCode) == true)
                {
                    MessageBox.Show("User created");
                    if (cbSearchdepartment.SelectedIndex == 0)
                    {
                        PopulateUserListbox();
                    }
                    else
                    {
                        PopulateUserListboxByDepartment(cbSearchdepartment.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditEmployees(int id, string firstName, string lastName, string birthDate,
                                   string birthPlace, string bsn, string address, string phoneNumber, string ecName,
                                   string ecNumber, string startDate, string endDate, string careerHistory, string position,
                                   string department, string contractType, string terminationReason, string active, string email, string username,
                                   string password, string AccountType, string zipcode)
        {
            try
            {

                if (userControl.EditExistingUser(id, firstName, lastName, birthDate, birthPlace, bsn, address, phoneNumber, ecName,
                                    ecNumber, startDate, endDate, careerHistory, position, department, contractType,
                                    terminationReason, active, email, username, password, AccountType, zipcode) == true)
                {
                    MessageBox.Show("User information updated");
                    if (cbSearchdepartment.SelectedIndex == 0)
                    {
                        PopulateUserListbox();
                    }
                    else
                    {
                        PopulateUserListboxByDepartment(cbSearchdepartment.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Duplicate username or name");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateUserListbox()
        {
            lbEmployees.Items.Clear();
            foreach (User user in userControl.ReturnUsersLocalList())
            {
                lbEmployees.Items.Add(user.ToString());
            }
        }

        private void PopulateUserListboxByDepartment(string department)
        {

            lbEmployees.Items.Clear();
            foreach (User user in userControl.FilterLocalUsersListByDepartment(department))
            {
                if (user.Department == department)
                {
                    lbEmployees.Items.Add(user.ToString());
                }
            }
        }

        private void GetEmployeeData()
        {
            User user = userControl.GetUserInfo(lbEmployees.SelectedItem.ToString());

            tbID.Text = user.Id.ToString();
            tbFirstName.Text = user.FirstName;
            tbLastName.Text = user.LastName;
            dtBirthday.Text = user.BirthDate;
            tbBirthplace.Text = user.BirthPlace;
            tbBSN.Text = user.Bsn;
            cbDepartment.Text = user.Department;
            tbAddress.Text = user.Address;
            tbZipCode.Text = user.ZipCode;
            tbPhone.Text = user.PhoneNumber;
            tbEmergencyName.Text = user.EcName;
            tbEmergencyNr.Text = user.EcNumber;
            dtStart.Text = user.StartDate;
            rtbHistory.Text = user.CareerHistory;
            cbContract.Text = user.ContractType;
            cbStatus.Text = user.Active;
            cbxPosition.Text = user.Position;
            tbEmail.Text = user.Email;
            tbUsername.Text = user.Username;
            tbPassword.Text = user.Password;
            cbAccountType.Text = user.AccountType;
            rtbReason.Text = user.TerminationReason;
            if(user.Active == "Inactive")
            {
                dtEnd.Text = user.EndDate;
            }
            else
            {
                dtEnd.Value = DateTime.Today;
            }
        }

        private void SearchUser(string partial, string department)
        {
            lbEmployees.Items.Clear();
            foreach (User user in userControl.SearchUser(partial, department))
            {
                lbEmployees.Items.Add(user.FirstName + " " + user.LastName);
            }
        }

        private void LoadGUI()
        {
            userControl = new Classes.User();
            userControl.GetAllUsersFromDatabase();
            PopulateUserListbox();
            departmentControl = new Department();
            departmentControl.GetDeparmentsFromDatabase();
            foreach (Department department in departmentControl.ReturnDepartmentLocalList())
            {
                cbDepartment.Items.Add(department.ToString());
                cbSearchdepartment.Items.Add(department.ToString());
            }
            cbSearchdepartment.SelectedIndex = 0;
            dtBirthday.CustomFormat = "dd/MM/yyyy";
            dtEnd.CustomFormat = "dd/MM/yyyy";
            dtStart.CustomFormat = "dd/MM/yyyy";
        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
