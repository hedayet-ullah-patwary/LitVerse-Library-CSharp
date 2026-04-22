using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class FormReturnBook : Form
    {
        private DataAccess Da { set; get; }

        private FormAdminDashboard Ad { get; set; }

        public FormEmployeeDashboard FormEmployeeDashboard { get; set; }

        public FormReturnBook()
        {
            InitializeComponent();
            this.Da = new DataAccess();

            txtStudentSearch.Text = "Search...";
            txtStudentSearch.ForeColor = Color.Gray;
            txtStudentSearch.Enter += txtStudentSearch_Enter;
            txtStudentSearch.Leave += txtStudentSearch_Leave;

            this.PopulateGridView_Student();
            this.panelPayment.Visible = false;
        }

        public FormReturnBook(string id, FormAdminDashboard ad) : this()
        {
            this.Ad = ad;
        }

        public FormReturnBook(FormEmployeeDashboard formEmployeeDashboard) : this() 
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

        private void pictureBoxBack_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBoxBack_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBoxBack_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void FormReturnBook_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Da != null)
            {
                this.Da.Dispose();
            }
            Application.Exit();
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

        private void FormReturnBook_Load(object sender, EventArgs e)
        {
            this.dgvStudentInfo.ClearSelection();
        }

        private void dgvStudentInfo_DoubleClick(object sender, EventArgs e)
        {
            this.txtStudentID.Text = this.dgvStudentInfo.CurrentRow.Cells[0].Value.ToString();
            this.txtStudentName.Text = this.dgvStudentInfo.CurrentRow.Cells[1].Value.ToString();
            this.dgvStudentInfo.ClearSelection();

            this.LoadImagesToFlowLayoutPanel();
        }

        public void LoadImagesToFlowLayoutPanel()
        {
            try
            {
                flowLayoutPanel.Controls.Clear();
                DataTable dt = Da.ExecuteQueryTable("SELECT * FROM ISSUE_BOOK WHERE STUDENT_ID = '" + this.txtStudentID.Text + "';");
                ShowBook(dt);
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured, please check: " + exc.Message);
            }
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
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

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

                    Button btnReturn = new Button();
                    btnReturn.Text = "Return";
                    btnReturn.Tag = bookId;
                    btnReturn.Click += btnReturn_Click;

                    FlowLayoutPanel itemPanel = new FlowLayoutPanel();
                    itemPanel.FlowDirection = FlowDirection.TopDown;
                    itemPanel.BackColor = Color.White;
                    itemPanel.Size = new Size(125, 260);
                    itemPanel.Margin = new Padding(10);

                    itemPanel.Controls.Add(pb);
                    itemPanel.Controls.Add(lbl1);
                    itemPanel.Controls.Add(lbl2);
                    itemPanel.Controls.Add(lbl3);
                    itemPanel.Controls.Add(lbl4);
                    itemPanel.Controls.Add(btnReturn);

                    flowLayoutPanel.Controls.Add(itemPanel);
                }
            }
        }

        private void UpdateTotalFineLabel()
        {
            int totalFine = 0;

            foreach (DataGridViewRow row in dgvSelectedBook.Rows)
            {
                if (row.Cells["Fine"].Value != null)
                {
                    int fineValue = 0;
                    int.TryParse(row.Cells["Fine"].Value.ToString(), out fineValue);
                    totalFine += fineValue;
                }
            }

            this.lblCalculatedFine.Text = $"Calculated Fine: {totalFine} Tk";

            if (totalFine > 0)
            {
                panelPayment.Visible = true;   
            }
            else
            {
                panelPayment.Visible = false;  
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            string bookId = btn.Tag.ToString();

            foreach (DataGridViewRow row in dgvSelectedBook.Rows)
            {
                if (row.Cells["Book_ID"].Value != null && row.Cells["Book_ID"].Value.ToString() == bookId)
                {
                    MessageBox.Show("This book is already selected for return.", "Duplicate Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; 
                }
            }

            FlowLayoutPanel itemPanel = btn.Parent as FlowLayoutPanel;
            if (itemPanel == null) return;

            string title = "";
            string author = "";
            string deliveryDate = "";

            foreach (Control ctrl in itemPanel.Controls)
            {
                if (ctrl is Label lbl)
                {
                    if (lbl.Text.StartsWith("Author: "))
                        author = lbl.Text.Substring(8);
                    else if (lbl.Text.StartsWith("Delivery Date: "))
                        deliveryDate = lbl.Text.Substring(15);
                    else if (lbl != null && lbl.Text != "" && !lbl.Text.Contains(":"))
                        title = lbl.Text;
                }
            }

            DateTime deliveryDt = DateTime.ParseExact(deliveryDate, "dd-MM-yyyy", null);
            int fine = 0;
            if (DateTime.Now.Date > deliveryDt)
            {
                fine = (DateTime.Now.Date - deliveryDt).Days * 5;
            }

            this.dgvSelectedBook.Rows.Add(bookId, title, author, deliveryDate, fine.ToString());

            UpdateTotalFineLabel();
            this.dgvSelectedBook.ClearSelection();
        }


        private void btnClearAll_Click(object sender, EventArgs e)
        {
            this.dgvSelectedBook.Rows.Clear();
            this.UpdateTotalFineLabel();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvSelectedBook.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in this.dgvSelectedBook.SelectedRows)
                {
                    this.dgvSelectedBook.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Please select a book to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            UpdateTotalFineLabel();
            this.dgvSelectedBook.ClearSelection();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSelectedBook.Rows.Count == 0)
                {
                    MessageBox.Show("No books selected for return.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string invoiceId = AutoIdGenerate();

                string studentId = txtStudentID.Text.Trim();
                if (string.IsNullOrEmpty(studentId))
                {
                    MessageBox.Show("Student ID is required.");
                    return;
                }

                string returnedBooks = "";
                int totalFine = 0;

                foreach (DataGridViewRow row in dgvSelectedBook.Rows)
                {
                    if (row.Cells["Title"].Value != null)
                    {
                        string title = row.Cells["Title"].Value.ToString().Trim().Replace("'", "''");
                        returnedBooks += (returnedBooks == "") ? title : "," + title;

                        int fine = int.Parse(row.Cells["Fine"].Value.ToString());
                        totalFine += fine;

                        string bookId = row.Cells["Book_ID"].Value.ToString();
                        string deleteSql = $"DELETE FROM ISSUE_BOOK WHERE BOOK_ID = '{bookId}' AND STUDENT_ID = '{studentId}';";
                        Da.ExecuteDMLQuery(deleteSql);
                    }
                }

                string paymentMethod = "NULL";
                if (totalFine > 0)
                {
                    if (rbCash.Checked) paymentMethod = "'Cash'";
                    else if (rbCard.Checked) paymentMethod = "'Card'";
                    else if (rbBikash.Checked) paymentMethod = "'Bikash'";
                    else if (rbNagad.Checked) paymentMethod = "'Nagad'";
                    else
                    {
                        MessageBox.Show("Please select a payment method!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string empId = "NULL";
                if (this.Ad != null && !string.IsNullOrEmpty(this.Ad.LoggedInEmpID))
                    empId = $"'{this.Ad.LoggedInEmpID}'";
                else if (this.FormEmployeeDashboard != null && !string.IsNullOrEmpty(this.FormEmployeeDashboard.LoggedInEmpID))
                    empId = $"'{this.FormEmployeeDashboard.LoggedInEmpID}'";

                string returnDate = DateTime.Now.ToString("yyyy-MM-dd");

                string insertSql = $@"
            INSERT INTO INVOICE_TABLE 
            (INVOICE_ID, STUDENT_ID, RETURN_BOOKS, FINE_AMOUNT, RETURN_DATE, PAYMENT_METHOD, EMP_ID)
            VALUES 
            ('{invoiceId}', '{studentId}', '{returnedBooks}', {totalFine}, '{returnDate}', {paymentMethod}, {empId});
        ";
                Da.ExecuteDMLQuery(insertSql);

                foreach (DataGridViewRow row in dgvSelectedBook.Rows)
                {
                    if (row.Cells["Book_ID"].Value != null)
                    {
                        string bookId = row.Cells["Book_ID"].Value.ToString();
                        string checkSql = $"SELECT COUNT(*) FROM BOOK_TABLE WHERE BOOK_ID = '{bookId}';";
                        DataTable dt = Da.ExecuteQueryTable(checkSql);

                        if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
                        {
                            string sql = $"UPDATE BOOK_TABLE SET QUANTITY = QUANTITY + 1 WHERE BOOK_ID = '{bookId}';";
                            Da.ExecuteDMLQuery(sql);
                        }
                    }
                }

                dgvSelectedBook.Rows.Clear();
                UpdateTotalFineLabel();
                LoadImagesToFlowLayoutPanel();
                CreatePDF(invoiceId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private string AutoIdGenerate()
        {
            string newId = "v-001";

            string query = "SELECT MAX(INVOICE_ID) FROM INVOICE_TABLE;";
            DataTable dt = this.Da.ExecuteQueryTable(query);

            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                string oldId = dt.Rows[0][0].ToString();
                if (oldId.StartsWith("v-"))
                {
                    int num = int.Parse(oldId.Split('-')[1]);
                    newId = $"v-{(num + 1).ToString("D3")}";
                }
            }

            return newId;
        }

        public void CreatePDF(string invoiceId)
        {
            try
            {
                if (string.IsNullOrEmpty(invoiceId))
                {
                    MessageBox.Show("Invalid Invoice ID!");
                    return;
                }

                string sql = $"SELECT * FROM INVOICE_TABLE WHERE INVOICE_ID = '{invoiceId}';";
                DataTable dt = Da.ExecuteQueryTable(sql);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Invoice found for this ID!");
                    return;
                }

                DataRow row = dt.Rows[0];
                string studentId = row["STUDENT_ID"].ToString();
                string returnedBooks = row["RETURN_BOOKS"].ToString();
                string fineAmount = row["FINE_AMOUNT"].ToString();
                string returnDate = Convert.ToDateTime(row["RETURN_DATE"]).ToString("dd-MM-yyyy");
                string paymentMethod = row["PAYMENT_METHOD"] != DBNull.Value ? row["PAYMENT_METHOD"].ToString() : "N/A";
                string empId = row["EMP_ID"] != DBNull.Value ? row["EMP_ID"].ToString() : "N/A";

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF files (*.pdf)|*.pdf";
                sfd.FileName = $"ReturnBookInvoice_{invoiceId}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Document doc = new Document(PageSize.A4, 50, 50, 50, 50);
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                    doc.Open();

                    Paragraph header = new Paragraph("📚 LitVerse Library", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD));
                    header.Alignment = Element.ALIGN_CENTER;
                    doc.Add(header);

                    doc.Add(new Paragraph($"Invoice ID: {invoiceId}"));
                    doc.Add(new Paragraph($"Student ID: {studentId}"));
                    doc.Add(new Paragraph(" ")); 

                    PdfPTable table = new PdfPTable(1);
                    table.WidthPercentage = 100;
                    table.AddCell("Returned Books:");
                    table.AddCell(returnedBooks);

                    doc.Add(table);

                    doc.Add(new Paragraph(" ")); 

                    Paragraph finePara = new Paragraph($"Total Fine: {fineAmount} TK", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD));
                    doc.Add(finePara);

                    Paragraph payMethod = new Paragraph($"Payment Method: {paymentMethod}", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12));
                    doc.Add(payMethod);

                    doc.Add(new Paragraph(" ")); 

                    Paragraph genBy = new Paragraph($"Generated By (EMP_ID): {empId}", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12));
                    doc.Add(genBy);

                    Paragraph retDate = new Paragraph($"Return Date: {returnDate}", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10));
                    doc.Add(retDate);

                    doc.Close();

                    MessageBox.Show("Books returned and invoice created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
