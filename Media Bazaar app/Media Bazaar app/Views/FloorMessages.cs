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
    public partial class FloorMessages : Form
    {
        private GeneralMessage generalMessage;

        public FloorMessages()
        {
            InitializeComponent();
            LoadGUI();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMessages.SelectedIndex != -1)
            {
                int index = lbMessages.SelectedIndex;
                rbxBody.Text = generalMessage.GetMessageBody(index);
            }
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshMessages();
        }

        private void RefreshMessages()
        {
            lbMessages.Items.Clear();
            rbxBody.Clear();
            foreach (Classes.Message message in generalMessage.ReturnMessagesByDate(dtDate.Value.ToString("dd/MM/yyyy")))
            {
                lbMessages.Items.Add(message.ToString());
            }
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
