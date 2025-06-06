using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Media_Bazaar_app.Classes;
using Media_Bazaar_app.Views;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Media_Bazaar_app
{
    public partial class LoginView : Form
    {
        private readonly Classes.User userControl;
        private User user;

        public LoginView()
        {
            InitializeComponent();
            userControl = new Classes.User();
            tbUsername.BringToFront();
         
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                user = userControl.AuthenticateUser(tbUsername.Text, tbPassword.Text);

                if (user == null)
                {
                    throw new Exception("Invalid username or password");
                }
                else
                {
                    if (user.Active == "Inactive")
                    {
                        throw new Exception("Account is disabled");
                    }
                    else if (user.Active == "Active")
                    {
                        if (user.AccountType == "Admin")
                        {
                            AdministrationView f1 = new AdministrationView();
                            this.Hide();
                            f1.Show();
                        }
                        else if (user.AccountType == "Floor")
                        {
                            if (user.Position == "Security Guard")
                            {
                                FloorScheduleView f3 = new FloorScheduleView(user);
                                f3.Show();
                                this.Hide();
                            }
                            else
                            {
                                FloorView f2 = new FloorView(user);
                                f2.Show();
                                this.Hide();
                            }
                        }
                        else if (user.AccountType == "Manager")
                        {
                            throw new Exception("This type of account is not permitted");
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            
        private void LoginView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

