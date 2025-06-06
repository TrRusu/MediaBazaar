using Media_Bazaar_app.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Bazaar_app.Views
{
    public partial class AdministrationMessages : Form
    {
        private GeneralMessage generalMessage;

        public AdministrationMessages()
        {
            InitializeComponent();

            LoadGUI();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                generalMessage.CreateGeneralMessage(rbxContent.Text, tbSubject.Text, dtDate.Value.ToString("dd/MM/yyyy"));
                RefreshMessages();
                tbSubject.Clear();
                rbxContent.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }             
        }

        private void lbMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMessages.SelectedIndex != -1)
            {
                int index = lbMessages.SelectedIndex;
                rbxBody.Text = generalMessage.GetMessageBody(index);
            }
        }

        private void rbxContent_TextChanged(object sender, EventArgs e)
        {
            int counter = 0;
            foreach(char c in rbxContent.Text)
            {
                counter++;
            }
            lblCount.Text = counter.ToString() + "/500"; 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbMessages.SelectedIndex != -1)
            {
                int index = lbMessages.SelectedIndex;
                generalMessage.DeleteMessage(generalMessage.GetMessageId(index));
                RefreshMessages();
            }
            else
            {
                MessageBox.Show("Please select message");
            }
        }

        private void RefreshMessages()
        {
            lbMessages.Items.Clear();
            rbxBody.Text = "";
            foreach (Classes.Message message in generalMessage.ReturnMessagesByDate(dtDate.Value.ToString("dd/MM/yyyy")))
            {
                lbMessages.Items.Add(message.ToString());
            }
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshMessages();
        }

        private void LoadGUI()
        {
            generalMessage = new GeneralMessage();
            generalMessage.GetGeneralMessagesFromDatabase();

            RefreshMessages();
            dtDate.CustomFormat = "dd/MM/yyyy";
        }
    }
}
