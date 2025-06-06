namespace Media_Bazaar_app.Views
{
    partial class AdministrationCreateDepartmentView
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
            this.lblSection = new System.Windows.Forms.Label();
            this.lbDepartments = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblDepname = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lbProducts = new System.Windows.Forms.ListBox();
            this.lbEmployees = new System.Windows.Forms.ListBox();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.btnMoveProduct = new System.Windows.Forms.Button();
            this.btnMoveAllEmployees = new System.Windows.Forms.Button();
            this.btnRemoveAllProducts = new System.Windows.Forms.Button();
            this.btnMoveAllProducts = new System.Windows.Forms.Button();
            this.btnMoveEmployee = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDepartments = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.lblSection.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSection.Location = new System.Drawing.Point(44, 51);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(370, 47);
            this.lblSection.TabIndex = 105;
            this.lblSection.Text = "Department Editor";
            // 
            // lbDepartments
            // 
            this.lbDepartments.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbDepartments.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDepartments.ForeColor = System.Drawing.Color.Maroon;
            this.lbDepartments.FormattingEnabled = true;
            this.lbDepartments.ItemHeight = 21;
            this.lbDepartments.Location = new System.Drawing.Point(76, 390);
            this.lbDepartments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbDepartments.Name = "lbDepartments";
            this.lbDepartments.Size = new System.Drawing.Size(367, 256);
            this.lbDepartments.TabIndex = 106;
            this.lbDepartments.SelectedIndexChanged += new System.EventHandler(this.lbDepartments_SelectedIndexChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Maroon;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRemove.Location = new System.Drawing.Point(202, 671);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(120, 36);
            this.btnRemove.TabIndex = 127;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Maroon;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAdd.Location = new System.Drawing.Point(76, 314);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 36);
            this.btnAdd.TabIndex = 128;
            this.btnAdd.Text = "Create";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.ForeColor = System.Drawing.Color.Maroon;
            this.tbName.Location = new System.Drawing.Point(76, 268);
            this.tbName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(367, 28);
            this.tbName.TabIndex = 129;
            // 
            // lblDepname
            // 
            this.lblDepname.AutoSize = true;
            this.lblDepname.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblDepname.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDepname.Location = new System.Drawing.Point(138, 220);
            this.lblDepname.Name = "lblDepname";
            this.lblDepname.Size = new System.Drawing.Size(228, 23);
            this.lblDepname.TabIndex = 130;
            this.lblDepname.Text = "New Department Name";
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Maroon;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEdit.Location = new System.Drawing.Point(323, 314);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 36);
            this.btnEdit.TabIndex = 131;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lbProducts
            // 
            this.lbProducts.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbProducts.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProducts.ForeColor = System.Drawing.Color.Maroon;
            this.lbProducts.FormattingEnabled = true;
            this.lbProducts.ItemHeight = 21;
            this.lbProducts.Location = new System.Drawing.Point(581, 264);
            this.lbProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbProducts.Name = "lbProducts";
            this.lbProducts.Size = new System.Drawing.Size(371, 382);
            this.lbProducts.TabIndex = 132;
            // 
            // lbEmployees
            // 
            this.lbEmployees.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbEmployees.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmployees.ForeColor = System.Drawing.Color.Maroon;
            this.lbEmployees.FormattingEnabled = true;
            this.lbEmployees.ItemHeight = 21;
            this.lbEmployees.Location = new System.Drawing.Point(1019, 264);
            this.lbEmployees.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbEmployees.Name = "lbEmployees";
            this.lbEmployees.Size = new System.Drawing.Size(371, 382);
            this.lbEmployees.TabIndex = 133;
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.BackColor = System.Drawing.Color.Maroon;
            this.btnRemoveProduct.FlatAppearance.BorderSize = 0;
            this.btnRemoveProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveProduct.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveProduct.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRemoveProduct.Location = new System.Drawing.Point(581, 740);
            this.btnRemoveProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(157, 36);
            this.btnRemoveProduct.TabIndex = 134;
            this.btnRemoveProduct.Text = "Remove Product";
            this.btnRemoveProduct.UseVisualStyleBackColor = false;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // btnMoveProduct
            // 
            this.btnMoveProduct.BackColor = System.Drawing.Color.Maroon;
            this.btnMoveProduct.FlatAppearance.BorderSize = 0;
            this.btnMoveProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveProduct.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveProduct.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMoveProduct.Location = new System.Drawing.Point(581, 681);
            this.btnMoveProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMoveProduct.Name = "btnMoveProduct";
            this.btnMoveProduct.Size = new System.Drawing.Size(157, 36);
            this.btnMoveProduct.TabIndex = 135;
            this.btnMoveProduct.Text = "Move Product";
            this.btnMoveProduct.UseVisualStyleBackColor = false;
            this.btnMoveProduct.Click += new System.EventHandler(this.btnMoveProduct_Click);
            // 
            // btnMoveAllEmployees
            // 
            this.btnMoveAllEmployees.BackColor = System.Drawing.Color.Maroon;
            this.btnMoveAllEmployees.FlatAppearance.BorderSize = 0;
            this.btnMoveAllEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveAllEmployees.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveAllEmployees.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMoveAllEmployees.Location = new System.Drawing.Point(1199, 740);
            this.btnMoveAllEmployees.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMoveAllEmployees.Name = "btnMoveAllEmployees";
            this.btnMoveAllEmployees.Size = new System.Drawing.Size(191, 36);
            this.btnMoveAllEmployees.TabIndex = 137;
            this.btnMoveAllEmployees.Text = "Move All Employees";
            this.btnMoveAllEmployees.UseVisualStyleBackColor = false;
            this.btnMoveAllEmployees.Click += new System.EventHandler(this.btnMoveAllEmployees_Click);
            // 
            // btnRemoveAllProducts
            // 
            this.btnRemoveAllProducts.BackColor = System.Drawing.Color.Maroon;
            this.btnRemoveAllProducts.FlatAppearance.BorderSize = 0;
            this.btnRemoveAllProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAllProducts.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveAllProducts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRemoveAllProducts.Location = new System.Drawing.Point(761, 740);
            this.btnRemoveAllProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveAllProducts.Name = "btnRemoveAllProducts";
            this.btnRemoveAllProducts.Size = new System.Drawing.Size(191, 36);
            this.btnRemoveAllProducts.TabIndex = 138;
            this.btnRemoveAllProducts.Text = "Remove All Products";
            this.btnRemoveAllProducts.UseVisualStyleBackColor = false;
            this.btnRemoveAllProducts.Click += new System.EventHandler(this.btnRemoveAllProducts_Click);
            // 
            // btnMoveAllProducts
            // 
            this.btnMoveAllProducts.BackColor = System.Drawing.Color.Maroon;
            this.btnMoveAllProducts.FlatAppearance.BorderSize = 0;
            this.btnMoveAllProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveAllProducts.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveAllProducts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMoveAllProducts.Location = new System.Drawing.Point(761, 681);
            this.btnMoveAllProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMoveAllProducts.Name = "btnMoveAllProducts";
            this.btnMoveAllProducts.Size = new System.Drawing.Size(191, 36);
            this.btnMoveAllProducts.TabIndex = 184;
            this.btnMoveAllProducts.Text = "Move All Products";
            this.btnMoveAllProducts.UseVisualStyleBackColor = false;
            this.btnMoveAllProducts.Click += new System.EventHandler(this.btnMoveAllProducts_Click);
            // 
            // btnMoveEmployee
            // 
            this.btnMoveEmployee.BackColor = System.Drawing.Color.Maroon;
            this.btnMoveEmployee.FlatAppearance.BorderSize = 0;
            this.btnMoveEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveEmployee.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveEmployee.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMoveEmployee.Location = new System.Drawing.Point(1019, 740);
            this.btnMoveEmployee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMoveEmployee.Name = "btnMoveEmployee";
            this.btnMoveEmployee.Size = new System.Drawing.Size(174, 36);
            this.btnMoveEmployee.TabIndex = 185;
            this.btnMoveEmployee.Text = "Move Employee";
            this.btnMoveEmployee.UseVisualStyleBackColor = false;
            this.btnMoveEmployee.Click += new System.EventHandler(this.btnMoveEmployee_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(1015, 687);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 23);
            this.label1.TabIndex = 186;
            this.label1.Text = "Move To";
            // 
            // cbDepartments
            // 
            this.cbDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDepartments.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.cbDepartments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbDepartments.FormattingEnabled = true;
            this.cbDepartments.Location = new System.Drawing.Point(1123, 681);
            this.cbDepartments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDepartments.Name = "cbDepartments";
            this.cbDepartments.Size = new System.Drawing.Size(267, 29);
            this.cbDepartments.TabIndex = 187;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(-217, 130);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2599, 9);
            this.panel1.TabIndex = 188;
            // 
            // AdministrationCreateDepartmentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1493, 841);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbDepartments);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMoveEmployee);
            this.Controls.Add(this.btnMoveAllProducts);
            this.Controls.Add(this.btnRemoveAllProducts);
            this.Controls.Add(this.btnMoveAllEmployees);
            this.Controls.Add(this.btnMoveProduct);
            this.Controls.Add(this.btnRemoveProduct);
            this.Controls.Add(this.lbEmployees);
            this.Controls.Add(this.lbProducts);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblDepname);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lbDepartments);
            this.Controls.Add(this.lblSection);
            this.Name = "AdministrationCreateDepartmentView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdministrationCreateDepartmentView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.ListBox lbDepartments;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblDepname;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListBox lbProducts;
        private System.Windows.Forms.ListBox lbEmployees;
        private System.Windows.Forms.Button btnRemoveProduct;
        private System.Windows.Forms.Button btnMoveProduct;
        private System.Windows.Forms.Button btnMoveAllEmployees;
        private System.Windows.Forms.Button btnRemoveAllProducts;
        private System.Windows.Forms.Button btnMoveAllProducts;
        private System.Windows.Forms.Button btnMoveEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDepartments;
        private System.Windows.Forms.Panel panel1;
    }
}