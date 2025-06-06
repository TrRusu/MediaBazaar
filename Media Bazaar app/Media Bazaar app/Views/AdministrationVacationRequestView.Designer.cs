namespace Media_Bazaar_app.Views
{
    partial class AdministrationVacationRequestView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbWeekNumber = new System.Windows.Forms.ComboBox();
            this.lblWeekNr = new System.Windows.Forms.Label();
            this.lbRequests = new System.Windows.Forms.ListBox();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnDismiss = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbWeekNumber
            // 
            this.cbWeekNumber.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.cbWeekNumber.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbWeekNumber.FormattingEnabled = true;
            this.cbWeekNumber.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52"});
            this.cbWeekNumber.Location = new System.Drawing.Point(457, 159);
            this.cbWeekNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbWeekNumber.Name = "cbWeekNumber";
            this.cbWeekNumber.Size = new System.Drawing.Size(67, 27);
            this.cbWeekNumber.TabIndex = 190;
            this.cbWeekNumber.SelectedIndexChanged += new System.EventHandler(this.cbWeekNumber_SelectedIndexChanged);
            // 
            // lblWeekNr
            // 
            this.lblWeekNr.AutoSize = true;
            this.lblWeekNr.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblWeekNr.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblWeekNr.Location = new System.Drawing.Point(253, 159);
            this.lblWeekNr.Name = "lblWeekNr";
            this.lblWeekNr.Size = new System.Drawing.Size(179, 28);
            this.lblWeekNr.TabIndex = 189;
            this.lblWeekNr.Text = "Week Number";
            // 
            // lbRequests
            // 
            this.lbRequests.BackColor = System.Drawing.Color.Maroon;
            this.lbRequests.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.lbRequests.ForeColor = System.Drawing.Color.White;
            this.lbRequests.FormattingEnabled = true;
            this.lbRequests.ItemHeight = 21;
            this.lbRequests.Location = new System.Drawing.Point(258, 271);
            this.lbRequests.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbRequests.Name = "lbRequests";
            this.lbRequests.Size = new System.Drawing.Size(1064, 361);
            this.lbRequests.TabIndex = 191;
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.Green;
            this.btnApprove.FlatAppearance.BorderSize = 0;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnApprove.Location = new System.Drawing.Point(258, 700);
            this.btnApprove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(205, 48);
            this.btnApprove.TabIndex = 223;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnDismiss
            // 
            this.btnDismiss.BackColor = System.Drawing.Color.Maroon;
            this.btnDismiss.FlatAppearance.BorderSize = 0;
            this.btnDismiss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDismiss.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnDismiss.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDismiss.Location = new System.Drawing.Point(1117, 700);
            this.btnDismiss.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDismiss.Name = "btnDismiss";
            this.btnDismiss.Size = new System.Drawing.Size(205, 48);
            this.btnDismiss.TabIndex = 224;
            this.btnDismiss.Text = "Dismiss";
            this.btnDismiss.UseVisualStyleBackColor = false;
            this.btnDismiss.Click += new System.EventHandler(this.btnDismiss_Click);
            // 
            // AdministrationVacationRequestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1924, 962);
            this.Controls.Add(this.btnDismiss);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.lbRequests);
            this.Controls.Add(this.cbWeekNumber);
            this.Controls.Add(this.lblWeekNr);
            this.Name = "AdministrationVacationRequestView";
            this.Text = "AdministrationVacationRequestView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbWeekNumber;
        private System.Windows.Forms.Label lblWeekNr;
        private System.Windows.Forms.ListBox lbRequests;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnDismiss;
    }
}