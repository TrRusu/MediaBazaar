namespace Media_Bazaar_app.Views
{
    partial class FloorMessages
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
            this.lbMessages = new System.Windows.Forms.ListBox();
            this.rbxBody = new System.Windows.Forms.RichTextBox();
            this.lblSection = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lbMessages
            // 
            this.lbMessages.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessages.ForeColor = System.Drawing.Color.Maroon;
            this.lbMessages.FormattingEnabled = true;
            this.lbMessages.ItemHeight = 22;
            this.lbMessages.Location = new System.Drawing.Point(600, 348);
            this.lbMessages.Margin = new System.Windows.Forms.Padding(4);
            this.lbMessages.Name = "lbMessages";
            this.lbMessages.Size = new System.Drawing.Size(532, 202);
            this.lbMessages.TabIndex = 1;
            this.lbMessages.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // rbxBody
            // 
            this.rbxBody.Enabled = false;
            this.rbxBody.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbxBody.ForeColor = System.Drawing.Color.Maroon;
            this.rbxBody.Location = new System.Drawing.Point(422, 588);
            this.rbxBody.Margin = new System.Windows.Forms.Padding(4);
            this.rbxBody.Name = "rbxBody";
            this.rbxBody.Size = new System.Drawing.Size(889, 262);
            this.rbxBody.TabIndex = 2;
            this.rbxBody.Text = "";
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.lblSection.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSection.Location = new System.Drawing.Point(802, 172);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(129, 47);
            this.lblSection.TabIndex = 105;
            this.lblSection.Text = "Inbox";
            // 
            // dtDate
            // 
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(785, 260);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(163, 30);
            this.dtDate.TabIndex = 197;
            this.dtDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            // 
            // FloorMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1576, 796);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.rbxBody);
            this.Controls.Add(this.lbMessages);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FloorMessages";
            this.Text = "FloorMessages";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbMessages;
        private System.Windows.Forms.RichTextBox rbxBody;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.DateTimePicker dtDate;
    }
}