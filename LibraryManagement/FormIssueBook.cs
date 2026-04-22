using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class FormIssueBook : Form
    {
        private DataAccess Da { get; set; }

        private FormAdminDashboard Ad { get; set; }
        public FormEmployeeDashboard FormEmployeeDashboard { get; set; }

        public FormIssueBook()
        {
            InitializeComponent();
            this.Da = new DataAccess();

            txtStudentSearch.Text = "Search...";
            txtStudentSearch.ForeColor = Color.Gray;
            txtStudentSearch.Enter += txtStudentSearch_Enter;
            txtStudentSearch.Leave += txtStudentSearch_Leave;

            txtBookSearch.Text = "Search...";
            txtBookSearch.ForeColor = Color.Gray;
            txtBookSearch.Enter += txtBookSearch_Enter;
            txtBookSearch.Leave += txtBookSearch_Leave;

            this.PopulateGridView_Student();
            this.LoadImagesToFlowLayoutPanel();
        }

        public FormIssueBook(string id,FormAdminDashboard ad) : this()
        {
            this.Ad = ad;
        }

        public FormIssueBook(FormEmployeeDashboard formEmployeeDashboard) : this() 
        {
            this.FormEmployeeDashboard = formEmployeeDashboard;
        }

        private void txtStudentSearch_Enter(object sender, EventArgs e)
        {
            if (txtStudentSearch.Text == "Search...")
            {
                txtStudentSearch.Text = "";
                txtStudentSearch.ForeColor = Color.Black; 
            }
        }

        private void txtStudentSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentSearch.Text))
            {
                txtStudentSearch.Text = "Search...";
                txtStudentSearch.ForeColor = Color.Gray;
            }
            this.dgvStudentInfo.ClearSelection();
        }

        private void txtBookSearch_Enter(object sender, EventArgs e)
        {
            if (txtBookSearch.Text == "Search...")
            {
                txtBookSearch.Text = "";
                txtBookSearch.ForeColor = Color.Black; 
            }
        }

        private void txtBookSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBookSearch.Text))
            {
                txtBookSearch.Text = "Search...";
                txtBookSearch.ForeColor = Color.Gray;
            }
        }

        private void pictureBoxBack_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBoxBack_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FormIssueBook_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (this.dgvSelectedBook.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in this.dgvSelectedBook.Rows)
                    {
                        if (row.Cells["Book_ID"].Value != null)
                        {
                            string bookId = row.Cells["Book_ID"].Value.ToString();

                            string sql = $"UPDATE BOOK_TABLE SET QUANTITY = QUANTITY + 1 WHERE BOOK_ID = '{bookId}';";
                            Da.ExecuteDMLQuery(sql);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error restoring books on close: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (this.Da != null)
            {
                this.Da.Dispose();
            }
            Application.Exit();
        }

        private void pictureBoxBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvSelectedBook.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in this.dgvSelectedBook.Rows)
                    {
                        if (row.Cells["Book_ID"].Value != null)
                        {
                            string bookId = row.Cells["Book_ID"].Value.ToString();

                            string sql = $"UPDATE BOOK_TABLE SET QUANTITY = QUANTITY + 1 WHERE BOOK_ID = '{bookId}';";
                            Da.ExecuteDMLQuery(sql);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error restoring books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Hide();
            if (this.Ad != null)
            {
                this.Ad.Show();
                this.Ad.RefreshDashboardData();
            }
            else if (this.FormEmployeeDashboard != null)
            {
                this.FormEmployeeDashboard.Show();
                this.FormEmployeeDashboard.RefreshEmployeeDashboard();
            }
        }

        private void PopulateGridView_Student(string sql = "SELECT * FROM STUDENT_TABLE;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvStudentInfo.AutoGenerateColumns = false;
            this.dgvStudentInfo.DataSource = ds.Tables[0];
        }

        private void txtStudentSearch_TextChanged(object sender, EventArgs e)
        {
            string search = this.txtStudentSearch.Text.Trim();

            if (string.IsNullOrEmpty(search) || search == "Search...")
            {
                this.PopulateGridView_Student(); 
            }
            else
            {
                var sql = "SELECT * FROM STUDENT_TABLE where STUDENT_ID like '" + this.txtStudentSearch.Text + "%';";
                this.PopulateGridView_Student(sql);
            }
        }

        private void FormIssueBook_Load(object sender, EventArgs e)
        {
            this.dgvStudentInfo.ClearSelection();
        }

        private void dgvStudentInfo_DoubleClick(object sender, EventArgs e)
        {
            this.txtStudentID.Text = this.dgvStudentInfo.CurrentRow.Cells[0].Value.ToString();
            this.txtStudentName.Text = this.dgvStudentInfo.CurrentRow.Cells[1].Value.ToString();
            this.dgvStudentInfo.ClearSelection();
        }

        public void LoadImagesToFlowLayoutPanel()
        {
            flowLayoutPanel.Controls.Clear();
            DataTable dt = Da.ExecuteQueryTable("SELECT * FROM BOOK_TABLE");
            ShowBook(dt);
        }

        public void LoadImagesToFlowLayoutPanel(string searchText)
        {
            flowLayoutPanel.Controls.Clear();
            string sql = $"SELECT * FROM BOOK_TABLE WHERE TITLE LIKE '%{searchText}%'";
            DataTable dt = Da.ExecuteQueryTable(sql);
            ShowBook(dt);
        }

        private void ShowBook(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                byte[] imgData = (byte[])row["PICTURE"];
                string title = row["TITLE"].ToString();
                string author = row["AUTHOR"].ToString();
                string id = row["BOOK_ID"].ToString();
                string quantity = row["QUANTITY"].ToString();

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
                    lbl3.Text = "Q: " + quantity;
                    lbl3.AutoSize = true;

                    Button btnAdd = new Button();
                    btnAdd.Text = "Borrow";
                    btnAdd.Tag = id;
                    btnAdd.Click += btnAdd_Click;

                    FlowLayoutPanel itemPanel = new FlowLayoutPanel();
                    itemPanel.FlowDirection = FlowDirection.TopDown;
                    itemPanel.BackColor = Color.White;
                    itemPanel.Size = new Size(125, 240);
                    itemPanel.Margin = new Padding(10);

                    itemPanel.Controls.Add(pb);
                    itemPanel.Controls.Add(lbl1);
                    itemPanel.Controls.Add(lbl2);
                    itemPanel.Controls.Add(lbl3);
                    itemPanel.Controls.Add(btnAdd);

                    flowLayoutPanel.Controls.Add(itemPanel);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                string bookId = btn.Tag.ToString();

                if (string.IsNullOrWhiteSpace(this.txtStudentID.Text))
                {
                    MessageBox.Show("Please select a student first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string studentId = this.txtStudentID.Text;

                foreach (DataGridViewRow row in dgvSelectedBook.Rows)
                {
                    if (row.Cells["Book_ID"].Value != null && row.Cells["Book_ID"].Value.ToString() == bookId)
                    {
                        MessageBox.Show("This book is already selected for borrowing!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                //string sql = $"SELECT * FROM ISSUE_BOOK WHERE BOOK_ID = '{bookId}' AND STUDENT_ID = '{studentId}' AND DELIVERY_DATE >= GETDATE()";
                string sql = $"SELECT * FROM ISSUE_BOOK WHERE BOOK_ID = '{bookId}' AND STUDENT_ID = '{studentId}'";
                DataTable dt = Da.ExecuteQueryTable(sql);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("This student already borrowed this book and did not return yet!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sqlBook = $"SELECT * FROM BOOK_TABLE WHERE BOOK_ID = '{bookId}'";
                DataTable dtBook = Da.ExecuteQueryTable(sqlBook);

                if (dtBook.Rows.Count == 0)
                {
                    MessageBox.Show("Book not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string title = dtBook.Rows[0]["TITLE"].ToString();
                string author = dtBook.Rows[0]["AUTHOR"].ToString();
                int quantity = Convert.ToInt32(dtBook.Rows[0]["QUANTITY"]);

                if (quantity <= 0)
                {
                    MessageBox.Show("This book is currently not available!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string issueDate = DateTime.Now.ToString("yyyy-MM-dd");
                string deliveryDate = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");

                dgvSelectedBook.Rows.Add(bookId, title, author, issueDate, deliveryDate);

                string sqlUpdate = $"UPDATE BOOK_TABLE SET QUANTITY = QUANTITY - 1 WHERE BOOK_ID = '{bookId}'";
                Da.ExecuteDMLQuery(sqlUpdate);
                this.dgvSelectedBook.ClearSelection();

                if (string.IsNullOrWhiteSpace(txtBookSearch.Text) || txtBookSearch.Text == "Search...")
                {
                    LoadImagesToFlowLayoutPanel();
                }
                else
                {
                    LoadImagesToFlowLayoutPanel(txtBookSearch.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message);
            }
        }

        private void txtBookSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBookSearch.Text) || txtBookSearch.Text == "Search...")
            {
                LoadImagesToFlowLayoutPanel();
            }
            else
            {
                LoadImagesToFlowLayoutPanel(txtBookSearch.Text.Trim());
            }
        }

        private string AutoIdGenerate()
        {
            string newId = "I-001"; 

            string query = "SELECT MAX(SERIAL) FROM ISSUE_BOOK;";
            DataTable dt = this.Da.ExecuteQueryTable(query);

            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                string oldId = dt.Rows[0][0].ToString(); 
                if (oldId.StartsWith("I-"))
                {
                    int num = int.Parse(oldId.Split('-')[1]);
                    newId = $"I-{(num + 1).ToString("D3")}";
                }
            }

            return newId; 
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvSelectedBook.Rows.Count == 0)
                {
                    MessageBox.Show("No books selected for issue.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string studentId = this.txtStudentID.Text.Trim();
                if (string.IsNullOrEmpty(studentId))
                {
                    MessageBox.Show("Please select a student first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (this.dgvSelectedBook.Rows.Count > 5)
                {
                    MessageBox.Show("A student cannot borrow more than 5 books at a time.", "Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string empId = "";
                if (this.Ad != null)
                    empId = this.Ad.LoggedInEmpID;
                else if (this.FormEmployeeDashboard != null)
                    empId = this.FormEmployeeDashboard.LoggedInEmpID;

                if (string.IsNullOrEmpty(empId))
                {
                    MessageBox.Show("Employee ID not found. Please login again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (DataGridViewRow row in this.dgvSelectedBook.Rows)
                {
                    string bookId = row.Cells["Book_ID"].Value.ToString();

                    string checkSql = $"SELECT * FROM ISSUE_BOOK WHERE BOOK_ID = '{bookId}' AND STUDENT_ID = '{studentId}' AND DELIVERY_DATE >= GETDATE();";
                    DataTable checkDt = Da.ExecuteQueryTable(checkSql);

                    if (checkDt.Rows.Count > 0)
                    {
                        string title = row.Cells["Title"].Value.ToString();
                        MessageBox.Show($"The book '{title}' has already been issued to this student and is not yet returned.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return ;
                    }

                    string serial = AutoIdGenerate();
                    string titleInsert = row.Cells["Title"].Value.ToString();
                    string author = row.Cells["Author"].Value.ToString();
                    string issueDate = DateTime.Now.ToString("yyyy-MM-dd");
                    string deliveryDate = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");

                    string sql = @"INSERT INTO ISSUE_BOOK (SERIAL, BOOK_ID, STUDENT_ID, TITLE, AUTHOR, ISSUE_DATE, DELIVERY_DATE, EMP_ID)
                           VALUES (@SERIAL, @BOOK_ID, @STUDENT_ID, @TITLE, @AUTHOR, @ISSUE_DATE, @DELIVERY_DATE, @EMP_ID);";

                    SqlCommand cmd = new SqlCommand(sql, Da.Sqlcon);
                    cmd.Parameters.AddWithValue("@SERIAL", serial);
                    cmd.Parameters.AddWithValue("@BOOK_ID", bookId);
                    cmd.Parameters.AddWithValue("@TITLE", titleInsert);
                    cmd.Parameters.AddWithValue("@STUDENT_ID", studentId);
                    cmd.Parameters.AddWithValue("@AUTHOR", author);
                    cmd.Parameters.AddWithValue("@ISSUE_DATE", issueDate);
                    cmd.Parameters.AddWithValue("@DELIVERY_DATE", deliveryDate);
                    cmd.Parameters.AddWithValue("@EMP_ID", empId);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Book(s) issued successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.dgvSelectedBook.Rows.Clear();
                this.txtStudentID.Clear();
                this.txtStudentName.Clear();
                this.LoadImagesToFlowLayoutPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while confirming book issue.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnClearAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvSelectedBook.Rows.Count == 0)
                {
                    MessageBox.Show("No books in the list to cancel!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                for (int i = 0; i < dgvSelectedBook.Rows.Count; i++)
                {
                    DataGridViewRow row = dgvSelectedBook.Rows[i];

                    if (row.Cells["Book_ID"].Value != null)
                    {
                        string bookId = row.Cells["Book_ID"].Value.ToString();

                        string sql = $"UPDATE BOOK_TABLE SET QUANTITY = QUANTITY + 1 WHERE BOOK_ID = '{bookId}';";
                        Da.ExecuteDMLQuery(sql);
                    }
                }
                dgvSelectedBook.Rows.Clear();

                if (string.IsNullOrWhiteSpace(txtBookSearch.Text) || txtBookSearch.Text == "Search...")
                {
                    LoadImagesToFlowLayoutPanel();
                }
                else
                {
                    LoadImagesToFlowLayoutPanel(txtBookSearch.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvSelectedBook.Rows.Count == 0)
                {
                    MessageBox.Show("No books to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (this.dgvSelectedBook.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select at least one book to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (DataGridViewRow selectedRow in this.dgvSelectedBook.SelectedRows)
                {
                    if (selectedRow.Cells["Book_ID"].Value != null)
                    {
                        string bookId = selectedRow.Cells["Book_ID"].Value.ToString();

                        string sql = $"UPDATE BOOK_TABLE SET QUANTITY = QUANTITY + 1 WHERE BOOK_ID = '{bookId}';";
                        Da.ExecuteDMLQuery(sql);

                        this.dgvSelectedBook.Rows.Remove(selectedRow);
                    }
                }

                if (string.IsNullOrWhiteSpace(txtBookSearch.Text) || txtBookSearch.Text == "Search...")
                {
                    LoadImagesToFlowLayoutPanel();
                }
                else
                {
                    LoadImagesToFlowLayoutPanel(txtBookSearch.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.dgvSelectedBook.ClearSelection();
        }
    }
}
