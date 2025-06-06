namespace Media_Bazaar_app
{
    partial class AdministrationOverviewView
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblSection = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSearchDepartment = new System.Windows.Forms.Label();
            this.cbSearchdepartment = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbProducts = new System.Windows.Forms.ListBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbProductsCount = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblSection.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSection.Location = new System.Drawing.Point(28, 23);
            this.lblSection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(279, 37);
            this.lblSection.TabIndex = 158;
            this.lblSection.Text = "Stock Dashboard";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(-133, 77);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1950, 8);
            this.panel1.TabIndex = 157;
            // 
            // lblSearchDepartment
            // 
            this.lblSearchDepartment.AutoSize = true;
            this.lblSearchDepartment.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblSearchDepartment.ForeColor = System.Drawing.SystemColors.Window;
            this.lblSearchDepartment.Location = new System.Drawing.Point(784, 176);
            this.lblSearchDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearchDepartment.Name = "lblSearchDepartment";
            this.lblSearchDepartment.Size = new System.Drawing.Size(95, 18);
            this.lblSearchDepartment.TabIndex = 1;
            this.lblSearchDepartment.Text = "Department";
            // 
            // cbSearchdepartment
            // 
            this.cbSearchdepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchdepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSearchdepartment.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.cbSearchdepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbSearchdepartment.FormattingEnabled = true;
            this.cbSearchdepartment.Location = new System.Drawing.Point(884, 172);
            this.cbSearchdepartment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbSearchdepartment.Name = "cbSearchdepartment";
            this.cbSearchdepartment.Size = new System.Drawing.Size(142, 27);
            this.cbSearchdepartment.TabIndex = 5;
            this.cbSearchdepartment.SelectedIndexChanged += new System.EventHandler(this.cbSearchdepartment_SelectedIndexChanged);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(35, 221);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "DrawSideBySide=False";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(646, 426);
            this.chart1.TabIndex = 180;
            this.chart1.Text = "chart1";
            // 
            // lbProducts
            // 
            this.lbProducts.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbProducts.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProducts.ForeColor = System.Drawing.Color.Maroon;
            this.lbProducts.FormattingEnabled = true;
            this.lbProducts.ItemHeight = 19;
            this.lbProducts.Location = new System.Drawing.Point(754, 309);
            this.lbProducts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbProducts.Name = "lbProducts";
            this.lbProducts.Size = new System.Drawing.Size(303, 232);
            this.lbProducts.TabIndex = 181;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblMonth.ForeColor = System.Drawing.SystemColors.Window;
            this.lblMonth.Location = new System.Drawing.Point(812, 124);
            this.lblMonth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(54, 18);
            this.lblMonth.TabIndex = 182;
            this.lblMonth.Text = "Month";
            // 
            // cbMonth
            // 
            this.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMonth.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.cbMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cbMonth.Location = new System.Drawing.Point(884, 120);
            this.cbMonth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(142, 27);
            this.cbMonth.TabIndex = 183;
            this.cbMonth.SelectedIndexChanged += new System.EventHandler(this.cbMonth_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(751, 279);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 18);
            this.label1.TabIndex = 184;
            this.label1.Text = "Depot Stock Levels";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(214, 149);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 23);
            this.label2.TabIndex = 185;
            this.label2.Text = "Top 5 Best Selling Products";
            // 
            // lbProductsCount
            // 
            this.lbProductsCount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbProductsCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbProductsCount.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductsCount.ForeColor = System.Drawing.Color.Maroon;
            this.lbProductsCount.FormattingEnabled = true;
            this.lbProductsCount.ItemHeight = 19;
            this.lbProductsCount.Location = new System.Drawing.Point(998, 310);
            this.lbProductsCount.Margin = new System.Windows.Forms.Padding(2);
            this.lbProductsCount.Name = "lbProductsCount";
            this.lbProductsCount.Size = new System.Drawing.Size(59, 228);
            this.lbProductsCount.TabIndex = 187;
            // 
            // AdministrationOverviewView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1443, 782);
            this.Controls.Add(this.lbProductsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.cbMonth);
            this.Controls.Add(this.lbProducts);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lblSearchDepartment);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.cbSearchdepartment);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AdministrationOverviewView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdministrationOverviewView";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSearchDepartment;
        private System.Windows.Forms.ComboBox cbSearchdepartment;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ListBox lbProducts;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbProductsCount;
    }
}