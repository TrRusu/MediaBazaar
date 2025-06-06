namespace Media_Bazaar_app.Views
{
    partial class AdministrationMessages
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSection = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.rbxContent = new System.Windows.Forms.RichTextBox();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.rbxBody = new System.Windows.Forms.RichTextBox();
            this.lbMessages = new System.Windows.Forms.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(-116, 124);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2599, 9);
            this.panel1.TabIndex = 184;
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.lblSection.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSection.Location = new System.Drawing.Point(35, 41);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(214, 47);
            this.lblSection.TabIndex = 105;
            this.lblSection.Text = "Messages";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblSubject.ForeColor = System.Drawing.SystemColors.Window;
            this.lblSubject.Location = new System.Drawing.Point(222, 361);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(79, 23);
            this.lblSubject.TabIndex = 185;
            this.lblSubject.Text = "Subject";
            // 
            // rbxContent
            // 
            this.rbxContent.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rbxContent.ForeColor = System.Drawing.Color.Maroon;
            this.rbxContent.Location = new System.Drawing.Point(91, 449);
            this.rbxContent.MaxLength = 500;
            this.rbxContent.Name = "rbxContent";
            this.rbxContent.Size = new System.Drawing.Size(635, 262);
            this.rbxContent.TabIndex = 186;
            this.rbxContent.Text = "";
            this.rbxContent.TextChanged += new System.EventHandler(this.rbxContent_TextChanged);
            // 
            // tbSubject
            // 
            this.tbSubject.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSubject.ForeColor = System.Drawing.Color.Maroon;
            this.tbSubject.Location = new System.Drawing.Point(92, 401);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(399, 28);
            this.tbSubject.TabIndex = 187;
            // 
            // rbxBody
            // 
            this.rbxBody.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbxBody.ForeColor = System.Drawing.Color.Maroon;
            this.rbxBody.Location = new System.Drawing.Point(811, 449);
            this.rbxBody.Margin = new System.Windows.Forms.Padding(4);
            this.rbxBody.Name = "rbxBody";
            this.rbxBody.Size = new System.Drawing.Size(730, 262);
            this.rbxBody.TabIndex = 189;
            this.rbxBody.Text = "";
            // 
            // lbMessages
            // 
            this.lbMessages.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessages.ForeColor = System.Drawing.Color.Maroon;
            this.lbMessages.FormattingEnabled = true;
            this.lbMessages.ItemHeight = 22;
            this.lbMessages.Location = new System.Drawing.Point(917, 226);
            this.lbMessages.Margin = new System.Windows.Forms.Padding(4);
            this.lbMessages.Name = "lbMessages";
            this.lbMessages.Size = new System.Drawing.Size(532, 158);
            this.lbMessages.TabIndex = 188;
            this.lbMessages.SelectedIndexChanged += new System.EventHandler(this.lbMessages_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Maroon;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDelete.Location = new System.Drawing.Point(1121, 390);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 50);
            this.btnDelete.TabIndex = 190;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Maroon;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSend.Location = new System.Drawing.Point(353, 716);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(120, 50);
            this.btnSend.TabIndex = 191;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.SystemColors.Window;
            this.lblCount.Location = new System.Drawing.Point(663, 716);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(63, 23);
            this.lblCount.TabIndex = 192;
            this.lblCount.Text = "0/500";
            // 
            // dtDate
            // 
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(1101, 161);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(163, 30);
            this.dtDate.TabIndex = 196;
            this.dtDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Media_Bazaar_app.Properties.Resources.msg;
            this.pictureBox1.Location = new System.Drawing.Point(177, 161);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 151);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 197;
            this.pictureBox1.TabStop = false;
            // 
            // AdministrationMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1924, 962);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.rbxBody);
            this.Controls.Add(this.lbMessages);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.rbxContent);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.panel1);
            this.Name = "AdministrationMessages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdministrationMessages";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.RichTextBox rbxContent;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.RichTextBox rbxBody;
        private System.Windows.Forms.ListBox lbMessages;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}