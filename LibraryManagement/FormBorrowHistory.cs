using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class FormBorrowHistory : Form
    {
        private DataAccess Da { get; set; }

        private string Id { set; get; }

        private FormStudentRecord Sr { get; set; }

        public FormBorrowHistory()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }

        public FormBorrowHistory(string studentName, string studentID, FormStudentRecord sr) : this()
        {
            this.lblStudentName.Text += studentName;
            this.lblStudentID.Text += studentID;
            this.Id = studentID;
            this.Sr = sr;

            this.LoadImagesToFlowLayoutPanel();
            this.FineCount();

        }

        public void LoadImagesToFlowLayoutPanel()
        {
            flowLayoutPanel.Controls.Clear();
            DataTable dt = Da.ExecuteQueryTable($"SELECT * FROM ISSUE_BOOK WHERE STUDENT_ID = '{Id}'");
            ShowBook(dt);
        }

        private void ShowBook(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                string bookId = row["BOOK_ID"].ToString();

                string sql = $"SELECT PICTURE, TITLE, AUTHOR, QUANTITY FROM BOOK_TABLE WHERE BOOK_ID = '{bookId}'";
                DataTable bookDt = Da.ExecuteQueryTable(sql);

                byte[] imgData = (byte[])bookDt.Rows[0]["PICTURE"];

                string title = row["TITLE"].ToString();
                string author = row["AUTHOR"].ToString();
                string issue_date = Convert.ToDateTime(row["ISSUE_DATE"]).ToString("dd-MM-yyyy");
                string delivery_date = Convert.ToDateTime(row["DELIVERY_DATE"]).ToString("dd-MM-yyyy");

                using (MemoryStream ms = new MemoryStream(imgData))
                {
                    Image img = Image.FromStream(ms);

                    PictureBox pb = new PictureBox();
                    pb.Image = img;
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Size = new Size(120, 140);
                    pb.Location = new Point(12, 10);

                    Label lbl1 = new Label();
                    lbl1.Text = title;
                    lbl1.AutoSize = true;

                    Label lbl2 = new Label();
                    lbl2.Text = "Author: " + author;
                    lbl2.AutoSize = true;

                    Label lbl3 = new Label();
                    lbl3.Text = "Issue Date: " + issue_date;
                    lbl3.AutoSize = true;

                    Label lbl4 = new Label();
                    lbl4.Text = "Delivery Date: " + delivery_date;
                    lbl4.AutoSize = true;

                    FlowLayoutPanel itemPanel = new FlowLayoutPanel();
                    itemPanel.FlowDirection = FlowDirection.TopDown;
                    itemPanel.BackColor = Color.White;
                    itemPanel.Size = new Size(125, 220);
                    itemPanel.Margin = new Padding(10);

                    itemPanel.Controls.Add(pb);
                    itemPanel.Controls.Add(lbl1);
                    itemPanel.Controls.Add(lbl2);
                    itemPanel.Controls.Add(lbl3);
                    itemPanel.Controls.Add(lbl4);

                    flowLayoutPanel.Controls.Add(itemPanel);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Sr.ClearAll();
        }

        private void FineCount()
        {
            try
            {
                string fineSql = $"SELECT DELIVERY_DATE FROM ISSUE_BOOK WHERE STUDENT_ID = '{Id}';";
                DataTable fineDt = this.Da.ExecuteQueryTable(fineSql);

                double totalFine = 0;

                foreach (DataRow row in fineDt.Rows)
                {
                    DateTime deliveryDate;
                    if (DateTime.TryParse(row["DELIVERY_DATE"].ToString(), out deliveryDate))
                    {
                        int overdueDays = (DateTime.Today - deliveryDate).Days;

                        if (overdueDays > 0)
                        {
                            totalFine += overdueDays * 5; // per day 5 taka fine
                        }
                    }
                }

                this.lblFineAmount.Text = "Fine Amount: " + totalFine.ToString() + " Tk";
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }
    }
}
