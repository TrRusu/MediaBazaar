namespace Media_Bazaar_app
{
    partial class FloorDepartmentsView
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
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblSearchDepartment = new System.Windows.Forms.Label();
            this.lbProducts = new System.Windows.Forms.ListBox();
            this.rbDescription = new System.Windows.Forms.RichTextBox();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbProductID = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblProductID = new System.Windows.Forms.Label();
            this.pnlSide = new System.Windows.Forms.Panel();
            this.btnRestockReq = new System.Windows.Forms.Button();
            this.lblCU = new System.Windows.Forms.Label();
            this.lblReplenish = new System.Windows.Forms.Label();
            this.tbRestock = new System.Windows.Forms.TextBox();
            this.tbDeposit = new System.Windows.Forms.TextBox();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Century Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblAccount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAccount.Location = new System.Drawing.Point(-92, 994);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(85, 30);
            this.lblAccount.TabIndex = 187;
            this.lblAccount.Text = "label1";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMessage.Location = new System.Drawing.Point(235, 296);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(89, 21);
            this.lblMessage.TabIndex = 183;
            this.lblMessage.Text = "No results";
            this.lblMessage.Visible = false;
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.ForeColor = System.Drawing.Color.Maroon;
            this.tbSearch.Location = new System.Drawing.Point(287, 194);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(194, 28);
            this.tbSearch.TabIndex = 181;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSearch.Location = new System.Drawing.Point(95, 194);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(162, 23);
            this.lblSearch.TabIndex = 180;
            this.lblSearch.Text = "Search by name";
            // 
            // lblSearchDepartment
            // 
            this.lblSearchDepartment.AutoSize = true;
            this.lblSearchDepartment.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchDepartment.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSearchDepartment.Location = new System.Drawing.Point(-308, 199);
            this.lblSearchDepartment.Name = "lblSearchDepartment";
            this.lblSearchDepartment.Size = new System.Drawing.Size(120, 23);
            this.lblSearchDepartment.TabIndex = 178;
            this.lblSearchDepartment.Text = "Department";
            // 
            // lbProducts
            // 
            this.lbProducts.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbProducts.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProducts.ForeColor = System.Drawing.Color.Maroon;
            this.lbProducts.FormattingEnabled = true;
            this.lbProducts.ItemHeight = 21;
            this.lbProducts.Location = new System.Drawing.Point(99, 319);
            this.lbProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbProducts.Name = "lbProducts";
            this.lbProducts.Size = new System.Drawing.Size(382, 487);
            this.lbProducts.TabIndex = 167;
            this.lbProducts.SelectedIndexChanged += new System.EventHandler(this.lbProducts_SelectedIndexChanged_1);
            // 
            // rbDescription
            // 
            this.rbDescription.Enabled = false;
            this.rbDescription.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDescription.ForeColor = System.Drawing.Color.Maroon;
            this.rbDescription.Location = new System.Drawing.Point(660, 549);
            this.rbDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbDescription.Name = "rbDescription";
            this.rbDescription.Size = new System.Drawing.Size(337, 200);
            this.rbDescription.TabIndex = 166;
            this.rbDescription.Text = "";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Enabled = false;
            this.tbQuantity.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbQuantity.ForeColor = System.Drawing.Color.Maroon;
            this.tbQuantity.Location = new System.Drawing.Point(788, 429);
            this.tbQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(160, 28);
            this.tbQuantity.TabIndex = 165;
            // 
            // tbPrice
            // 
            this.tbPrice.Enabled = false;
            this.tbPrice.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrice.ForeColor = System.Drawing.Color.Maroon;
            this.tbPrice.Location = new System.Drawing.Point(788, 351);
            this.tbPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(207, 28);
            this.tbPrice.TabIndex = 164;
            // 
            // tbName
            // 
            this.tbName.Enabled = false;
            this.tbName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.ForeColor = System.Drawing.Color.Maroon;
            this.tbName.Location = new System.Drawing.Point(789, 271);
            this.tbName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(207, 28);
            this.tbName.TabIndex = 163;
            // 
            // tbProductID
            // 
            this.tbProductID.Enabled = false;
            this.tbProductID.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProductID.ForeColor = System.Drawing.Color.Maroon;
            this.tbProductID.Location = new System.Drawing.Point(789, 191);
            this.tbProductID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbProductID.Name = "tbProductID";
            this.tbProductID.Size = new System.Drawing.Size(207, 28);
            this.tbProductID.TabIndex = 162;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Century Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUser.Location = new System.Drawing.Point(-371, 932);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(85, 30);
            this.lblUser.TabIndex = 176;
            this.lblUser.Text = "Name";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDescription.Location = new System.Drawing.Point(656, 509);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(113, 23);
            this.lblDescription.TabIndex = 175;
            this.lblDescription.Text = "Description";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblQuantity.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblQuantity.Location = new System.Drawing.Point(654, 429);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(91, 23);
            this.lblQuantity.TabIndex = 174;
            this.lblQuantity.Text = "Shelf Qty";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPrice.Location = new System.Drawing.Point(654, 351);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(56, 23);
            this.lblPrice.TabIndex = 173;
            this.lblPrice.Text = "Price";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblName.Location = new System.Drawing.Point(656, 271);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(67, 23);
            this.lblName.TabIndex = 172;
            this.lblName.Text = "Name";
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblProductID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblProductID.Location = new System.Drawing.Point(656, 193);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(104, 23);
            this.lblProductID.TabIndex = 171;
            this.lblProductID.Text = "Product ID";
            // 
            // pnlSide
            // 
            this.pnlSide.AutoScroll = true;
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlSide.ForeColor = System.Drawing.Color.Crimson;
            this.pnlSide.Location = new System.Drawing.Point(1162, 191);
            this.pnlSide.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(591, 751);
            this.pnlSide.TabIndex = 170;
            // 
            // btnRestockReq
            // 
            this.btnRestockReq.BackColor = System.Drawing.Color.Maroon;
            this.btnRestockReq.FlatAppearance.BorderSize = 0;
            this.btnRestockReq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestockReq.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnRestockReq.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRestockReq.Location = new System.Drawing.Point(658, 883);
            this.btnRestockReq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRestockReq.Name = "btnRestockReq";
            this.btnRestockReq.Size = new System.Drawing.Size(337, 50);
            this.btnRestockReq.TabIndex = 191;
            this.btnRestockReq.Text = "Restock Request";
            this.btnRestockReq.UseVisualStyleBackColor = false;
            this.btnRestockReq.Click += new System.EventHandler(this.btnRestockReq_Click);
            // 
            // lblCU
            // 
            this.lblCU.AutoSize = true;
            this.lblCU.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblCU.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCU.Location = new System.Drawing.Point(956, 839);
            this.lblCU.Name = "lblCU";
            this.lblCU.Size = new System.Drawing.Size(39, 23);
            this.lblCU.TabIndex = 223;
            this.lblCU.Text = "CU";
            // 
            // lblReplenish
            // 
            this.lblReplenish.AutoSize = true;
            this.lblReplenish.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblReplenish.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblReplenish.Location = new System.Drawing.Point(658, 837);
            this.lblReplenish.Name = "lblReplenish";
            this.lblReplenish.Size = new System.Drawing.Size(98, 23);
            this.lblReplenish.TabIndex = 222;
            this.lblReplenish.Text = "Replenish";
            // 
            // tbRestock
            // 
            this.tbRestock.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.tbRestock.ForeColor = System.Drawing.Color.Maroon;
            this.tbRestock.Location = new System.Drawing.Point(856, 834);
            this.tbRestock.Margin = new System.Windows.Forms.Padding(4);
            this.tbRestock.Name = "tbRestock";
            this.tbRestock.Size = new System.Drawing.Size(95, 28);
            this.tbRestock.TabIndex = 221;
            // 
            // tbDeposit
            // 
            this.tbDeposit.Enabled = false;
            this.tbDeposit.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDeposit.ForeColor = System.Drawing.Color.Maroon;
            this.tbDeposit.Location = new System.Drawing.Point(856, 784);
            this.tbDeposit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDeposit.Name = "tbDeposit";
            this.tbDeposit.Size = new System.Drawing.Size(95, 28);
            this.tbDeposit.TabIndex = 232;
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblDeposit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDeposit.Location = new System.Drawing.Point(656, 784);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(150, 23);
            this.lblDeposit.TabIndex = 231;
            this.lblDeposit.Text = "Warehouse Qty";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(954, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 23);
            this.label2.TabIndex = 233;
            this.label2.Text = "CU";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(957, 789);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 23);
            this.label3.TabIndex = 234;
            this.label3.Text = "CU";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(-116, 124);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2599, 9);
            this.panel1.TabIndex = 168;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.lblDepartment.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDepartment.Location = new System.Drawing.Point(77, 46);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(212, 40);
            this.lblDepartment.TabIndex = 169;
            this.lblDepartment.Text = "Department";
            // 
            // FloorDepartmentsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDeposit);
            this.Controls.Add(this.lblDeposit);
            this.Controls.Add(this.lblCU);
            this.Controls.Add(this.lblReplenish);
            this.Controls.Add(this.tbRestock);
            this.Controls.Add(this.btnRestockReq);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblSearchDepartment);
            this.Controls.Add(this.lbProducts);
            this.Controls.Add(this.rbDescription);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbProductID);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblProductID);
            this.Controls.Add(this.pnlSide);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FloorDepartmentsView";
            this.Text = "s";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblSearchDepartment;
        private System.Windows.Forms.ListBox lbProducts;
        private System.Windows.Forms.RichTextBox rbDescription;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbProductID;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Button btnRestockReq;
        private System.Windows.Forms.Label lblCU;
        private System.Windows.Forms.Label lblReplenish;
        private System.Windows.Forms.TextBox tbRestock;
        private System.Windows.Forms.TextBox tbDeposit;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDepartment;
    }
}