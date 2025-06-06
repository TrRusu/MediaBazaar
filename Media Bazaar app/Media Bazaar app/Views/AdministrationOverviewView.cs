using Media_Bazaar_app.Classes;
using Media_Bazaar_app.Views;
using System;
using System.Drawing;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Media_Bazaar_app
{
    public partial class AdministrationOverviewView : Form
    {
        private Statistic statistics;
        private Department departmentControl;

        public AdministrationOverviewView()
        {
            InitializeComponent();
            LoadGUI();
        }

        private void UpdateGUI(string department, string month)
        {
            int nMonth = 0;
            if(month == "January")
            {
                nMonth = 1;
            }
            else if (month == "February")
            {
                nMonth = 2;
            }
            else if (month == "March")
            {
                nMonth = 3;
            }
            else if (month == "April")
            {
                nMonth = 4;
            }
            else if (month == "May")
            {
                nMonth = 5;
            }
            else if (month == "June")
            {
                nMonth = 6;
            }
            else if (month == "July")
            {
                nMonth = 7;
            }
            else if (month == "August")
            {
                nMonth = 8;
            }
            else if (month == "September")
            {
                nMonth = 9;
            }
            else if (month == "October")
            {
                nMonth = 10;
            }
            else if (month == "November")
            {
                nMonth = 11;
            }
            else if (month == "December")
            {
                nMonth = 12;
            }


            chart1.Series.Clear();
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            lbProducts.Items.Clear();
            lbProductsCount.Items.Clear();

            foreach (Statistic statistics in statistics.GetTopSalesCurrentMonth(nMonth, department))
            {
                foreach (Statistic c in statistics.GetTotalStock(statistics.Name))
                {
                    lbProducts.Items.Add(c.Name);
                    lbProductsCount.Items.Add(c.Value);
                }
                chart1.Series.Add(statistics.Name);
                chart1.Series[statistics.Name].ChartType = SeriesChartType.Column;
                chart1.Series[statistics.Name].Points.AddXY(1, Convert.ToDouble(statistics.Value));
                chart1.Series[statistics.Name]["PointWidth"] = "2";
            }

            Axis axis = chart1.ChartAreas[0].Axes[0];
            LabelStyle als = new LabelStyle();
            als.ForeColor = chart1.ChartAreas[0].BackColor;
            axis.LabelStyle = als;
            axis.MajorTickMark.TickMarkStyle = TickMarkStyle.None;
        }

        private void cbSearchdepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            string department = cbSearchdepartment.Text;
            string month = cbMonth.Text;
            UpdateGUI(department, month);
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string department = cbSearchdepartment.Text;
            string month = cbMonth.Text;
            UpdateGUI(department, month);
        }

        private void LoadGUI()
        {
            statistics = new Statistic();
            departmentControl = new Department();
            departmentControl.GetDeparmentsFromDatabase();
            int nMonth = Convert.ToInt32(DateTime.Now.ToString("MM"));
            LoadDepartments();
            cbMonth.SelectedIndex = nMonth - 1;
            cbSearchdepartment.SelectedIndex = 0;
        }

        private void LoadDepartments()
        {
            foreach (Department dep in departmentControl.ReturnDepartmentLocalList())
            {
                cbSearchdepartment.Items.Add(dep.Name);
            }
        }
    }
}
