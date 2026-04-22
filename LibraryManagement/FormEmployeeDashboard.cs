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
    public partial class FormEmployeeDashboard : Form
    {
        private DataAccess Da { set; get; }

        private FormLogin F1 { set; get; }

        private string Id { set; get; }

        public string LoggedInEmpID => this.Id;

        public FormEmployeeDashboard()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.RefreshEmployeeDashboard();

            panelMenu.Visible = false;
        }

        public FormEmployeeDashboard(string info, string id, FormLogin f1) : this()
        {
            this.F1 = f1;
            this.lblName.Text = info;
            this.lblID.Text = id;
            this.Id = id;
            this.lblWelcome.Text += info;
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

        private void btnReturnBook_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnReturnBook_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FormEmployeeDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Da != null)
            {
                this.Da.Dispose();
            }
            Application.Exit();
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
            new FormIssueBook(this).Show();
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormReturnBook(this).Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have successfully logged out.");
            this.Hide();
            this.F1.Show();
            F1.ClearAll();
        }

        private void FormEmployeeDashboard_Load(object sender, EventArgs e)
        {
            this.RefreshEmployeeDashboard();
        }

        public void RefreshEmployeeDashboard()
        {
            try
            {
                var sql1 = $"SELECT COUNT(SERIAL) FROM ISSUE_BOOK WHERE EMP_ID = '{Id}'";
                var ds1 = this.Da.ExecuteQuery(sql1);
                var count1 = ds1.Tables[0].Rows[0][0].ToString();
                this.lblIssueBookToday.Text = count1;

                var sql2 = "SELECT COUNT(SERIAL) FROM ISSUE_BOOK WHERE DELIVERY_DATE < CAST(GETDATE() AS DATE);";
                var ds2 = this.Da.ExecuteQuery(sql2);
                var count2 = ds2.Tables[0].Rows[0][0].ToString();
                this.lblOverdueBook.Text = count2;

                var sql3 = "SELECT SUM(CASE WHEN DATEDIFF(DAY, DELIVERY_DATE, GETDATE()) > 0 THEN DATEDIFF(DAY, DELIVERY_DATE, GETDATE()) * 5 ELSE 0 END) FROM ISSUE_BOOK;";
                var ds3 = this.Da.ExecuteQuery(sql3);
                var count3 = ds3.Tables[0].Rows[0][0].ToString();
                this.lblPendingFine.Text = count3;

                //Daily Issued Books Line Chart
                var sql4 = @"
                SELECT FORMAT(ISSUE_DATE, 'yyyy-MM-dd') AS [Day], COUNT(*) AS [IssuedCount]
                FROM ISSUE_BOOK
                GROUP BY FORMAT(ISSUE_DATE, 'yyyy-MM-dd')
                ORDER BY [Day];";

                var ds4 = this.Da.ExecuteQuery(sql4);

                this.LineChart.Series["Series1"].Points.Clear();

                foreach (DataRow dr in ds4.Tables[0].Rows)
                {
                    string day = dr["Day"].ToString();
                    int issuedCount = Convert.ToInt32(dr["IssuedCount"]);
                    this.LineChart.Series["Series1"].Points.AddXY(day, issuedCount);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error occured!" + exc);
                return;
            }
        }
    }
}
