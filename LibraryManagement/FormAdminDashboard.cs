using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class FormAdminDashboard : Form
    {
        private DataAccess Da { get; set; }

        private FormLogin F1 { set; get; }

        private string Id { set; get; }

        public string LoggedInEmpID => this.Id;

        public FormAdminDashboard()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            panelMenu.Visible = false;
        }

        public FormAdminDashboard(string info, string id, FormLogin f1) : this()
        {
            this.lblName.Text = info;
            this.lblID.Text = id;
            this.F1 = f1;
            this.Id = id;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = !panelMenu.Visible;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnLogout_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FormAdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Da != null)
            {
                this.Da.Dispose();
            }
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have successfully logged out.");
            this.Hide();
            this.F1.Show();
            F1.ClearAll();
        }

        private void btnEmployeeManagement_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormEmployeeManagement(this).Show();
        }

        private void btnBookManagement_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormBookManagement(this).Show();
        }

        private void btnStudentManagement_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormStudentRecord(this).Show();
        }

        private void btnIssuedBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormIssueBook(Id, this).Show();
        }

        private void FormAdminDashboard_Load(object sender, EventArgs e)
        {
            this.RefreshDashboardData();
        }

        public void RefreshDashboardData()
        {
            try
            {
                var sql1 = "SELECT COUNT(BOOK_ID) FROM BOOK_TABLE;";
                var ds1 = this.Da.ExecuteQuery(sql1);
                var count1 = ds1.Tables[0].Rows[0][0].ToString();
                this.lblTotalBook.Text = count1;

                var sql2 = "SELECT COUNT(SERIAL) FROM ISSUE_BOOK;";
                var ds2 = this.Da.ExecuteQuery(sql2);
                var count2 = ds2.Tables[0].Rows[0][0].ToString();
                this.lblIssuedBook.Text = count2;

                var sql3 = "SELECT COUNT(BOOK_ID) FROM BOOK_TABLE WHERE QUANTITY>0;";
                var ds3 = this.Da.ExecuteQuery(sql3);
                var count3 = ds3.Tables[0].Rows[0][0].ToString();
                this.lblAvailableBook.Text = count3;

                var sql4 = "SELECT COUNT(SERIAL) FROM ISSUE_BOOK WHERE DELIVERY_DATE < CAST(GETDATE() AS DATE);";
                var ds4 = this.Da.ExecuteQuery(sql4);
                var count4 = ds4.Tables[0].Rows[0][0].ToString();
                this.lblOverdueBook.Text = count4;

                var sql5 = "SELECT SUM(FINE_AMOUNT) FROM INVOICE_TABLE;";
                var ds5 = this.Da.ExecuteQuery(sql5);
                var count5 = ds5.Tables[0].Rows[0][0].ToString();
                this.lblFine.Text = count5;

                var genreQuery = "SELECT genre, COUNT(*) AS Count FROM BOOK_TABLE GROUP BY genre";
                var genreData = this.Da.ExecuteQuery(genreQuery);

                chart1.Series.Clear();

                var series = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    Name = "Genres",
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                    IsValueShownAsLabel = true
                };
                chart1.Series.Add(series);

                int totalBooks = 0;
                foreach (DataRow row in genreData.Tables[0].Rows)
                {
                    totalBooks += Convert.ToInt32(row["Count"]);
                }

                foreach (DataRow row in genreData.Tables[0].Rows)
                {
                    string genre = row["genre"].ToString();
                    int count = Convert.ToInt32(row["Count"]);
                    double percentage = (count * 100.0) / totalBooks;
                    string label = $"{genre} ({percentage:F2}%)";

                    series.Points.AddXY(label, count);
                }

                if (chart1.Legends.Count > 0)
                {
                    chart1.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Right;
                    chart1.Legends[0].Alignment = System.Drawing.StringAlignment.Center;
                    chart1.Legends[0].Title = "Book Genres";
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormReturnBook(Id, this).Show();
        }

        private void btnReturnBook_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnReturnBook_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
