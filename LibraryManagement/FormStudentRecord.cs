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
    public partial class FormStudentRecord : Form
    {

        private DataAccess Da { get; set; }

        public FormEmployeeDashboard FormEmployeeDashboard { get; set; }

        private FormAdminDashboard Ad { get; set; }
        public FormStudentRecord()
        {
            InitializeComponent();
            this.Da = new DataAccess();

            txtSearch.Text = "Search...";
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Enter += txtSearch_Enter;
            txtSearch.Leave += txtSearch_Leave;

            this.PopulateGridView();
            
        }

        public FormStudentRecord(FormAdminDashboard ad) : this()
        {
            this.Ad = ad;
        }

        public FormStudentRecord(FormEmployeeDashboard formEmployeeDashboard) : this() 
        {
            this.FormEmployeeDashboard = formEmployeeDashboard;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black; 
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search...";
                txtSearch.ForeColor = Color.Gray;
            }
            this.dgvStudent.ClearSelection();
        }

        private void pictureBoxBack_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBoxBack_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FormStudentRecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Da != null)
            {
                this.Da.Dispose();
            }
            Application.Exit();
        }

        private void pictureBoxBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (this.Ad != null)
            {
                this.Ad.Show();
            }
            else if (this.FormEmployeeDashboard != null)
            {
                this.FormEmployeeDashboard.Show();
            }
        }

        private void PopulateGridView(string sql = "SELECT * FROM STUDENT_TABLE;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvStudent.AutoGenerateColumns = false;
            this.dgvStudent.DataSource = ds.Tables[0];
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = this.txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(search) || search == "Search...")
            {
                this.PopulateGridView();
            }
            else
            {
                var sql = "SELECT * FROM STUDENT_TABLE where STUDENT_ID like '" + this.txtSearch.Text + "%';";
                this.PopulateGridView(sql);
            }
        }

        private void FormStudentRecord_Load(object sender, EventArgs e)
        {
            this.dgvStudent.ClearSelection();
            this.AutoIdGenerate();
        }

        private void dgvStudent_DoubleClick(object sender, EventArgs e)
        {
            this.txtStudentName.Text = this.dgvStudent.CurrentRow.Cells[0].Value.ToString();
            this.txtStudentID.Text = this.dgvStudent.CurrentRow.Cells[1].Value.ToString();
            this.txtContact.Text = this.dgvStudent.CurrentRow.Cells[2].Value.ToString();
            this.cmbQualification.Text = this.dgvStudent.CurrentRow.Cells[3].Value.ToString();
            this.txtInstitution.Text = this.dgvStudent.CurrentRow.Cells[4].Value.ToString();
            this.dtpDateOfBirth.Text = this.dgvStudent.CurrentRow.Cells[5].Value.ToString();
            this.dgvStudent.ClearSelection();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAll();
        }

        public void ClearAll()
        {
            this.cmbQualification.SelectedIndex = -1;
            this.txtStudentID.Clear();
            this.txtStudentName.Clear();
            this.txtContact.Clear();
            this.txtInstitution.Clear();
            this.dtpDateOfBirth.Text = "";
            this.txtSearch.Clear();
            this.txtSearch.Text = "Search...";
            this.txtSearch.ForeColor = Color.Gray;
            this.txtSearch.Leave += txtSearch_Leave;

            this.PopulateGridView();
            this.dgvStudent.ClearSelection();
            this.AutoIdGenerate();

        }

        private void AutoIdGenerate()
        {
            var query = "select max(STUDENT_ID) from STUDENT_TABLE;";
            var dt = this.Da.ExecuteQueryTable(query);

            string newId;

            if (dt.Rows.Count == 0 || dt.Rows[0][0] == DBNull.Value)
            {
                newId = "s-001";
            }
            else
            {
                var oldId = dt.Rows[0][0].ToString();
                string[] temp = oldId.Split('-');
                var num = Convert.ToInt32(temp[1]);
                newId = "s-" + (++num).ToString("d3");
            }

            this.txtStudentID.Text = newId;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (!this.IsValidToSave())
                {
                    MessageBox.Show("Please fill all the informations.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!this.IsValidName(this.txtStudentName.Text))
                {
                    MessageBox.Show("Student name should only contain alphabetic characters (A-Z, a-z).", "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!this.IsValidContact(this.txtContact.Text))
                {
                    MessageBox.Show("Contact number should only contain numeric characters (0-9), must be 11 digit and frist 2 digit must be 01.", "Invalid contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var query = "select * from STUDENT_TABLE where STUDENT_ID = '" + this.txtStudentID.Text + "'";
                DataTable dt = this.Da.ExecuteQueryTable(query);

                if (dt.Rows.Count == 0) 
                {
                    var sql = "insert into STUDENT_TABLE values('" + this.txtStudentID.Text + "', '" + this.txtStudentName.Text + "', '" + this.txtContact.Text + "', '" + this.cmbQualification.Text + "', '" + this.txtInstitution.Text + "', '" + this.dtpDateOfBirth.Text + "'); ";
                    int count = this.Da.ExecuteDMLQuery(sql);

                    if (count == 1)
                        MessageBox.Show("The data has been successfully added.", "Success");
                    else
                        MessageBox.Show("There was an issue adding the data. Please try again.", "Error");
                }
                else if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("For update data enter update button . Please try again.", "Error");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured, please check: " + exc.Message);
            }
            this.PopulateGridView();
            this.ClearAll();
        }

        private bool IsValidToSave()
        {
            if (string.IsNullOrEmpty(this.cmbQualification.Text) || string.IsNullOrEmpty(this.txtStudentID.Text) ||
                string.IsNullOrEmpty(this.txtStudentName.Text) || string.IsNullOrEmpty(this.txtInstitution.Text) ||
                string.IsNullOrEmpty(this.txtContact.Text) || string.IsNullOrEmpty(this.dtpDateOfBirth.Text))
                return false;
            else
                return true;
        }

        private bool IsValidName(string name)
        {
            foreach (char c in name)
            {
                if (!((c >= 65 && c <= 90) || (c >= 97 && c <= 122) || c == ' '))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsValidContact(string contact)
        {
            if (contact.Length != 11)
            {
                return false;
            }

            if (!contact.StartsWith("01"))
            {
                return false;
            }

            foreach (char c in contact)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsValidToSave())
                {
                    MessageBox.Show("Please fill all the informations.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!this.IsValidName(this.txtStudentName.Text))
                {
                    MessageBox.Show("Student name should only contain alphabetic characters (A-Z, a-z).", "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!this.IsValidContact(this.txtContact.Text))
                {
                    MessageBox.Show("Contact number should only contain numeric characters (0-9), must be 11 digit and frist 2 digit must be 01.", "Invalid contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var query = "select * from STUDENT_TABLE where STUDENT_ID = '" + this.txtStudentID.Text + "'";
                DataTable dt = this.Da.ExecuteQueryTable(query);
                if (dt.Rows.Count == 1)
                {
                    var sql = @"update STUDENT_TABLE
                                set STUDENT_NAME = '" + this.txtStudentName.Text + @"',
                                CONTACT = '" + this.txtContact.Text + @"',
                                QUALIFICATION = '" + this.cmbQualification.Text + @"',
                                INSTUTITATION = '" + this.txtInstitution.Text + @"',
                                DOB = '" + this.dtpDateOfBirth.Text + @"'
                                
                                where STUDENT_ID = '" + this.txtStudentID.Text + "'; ";
                    int count = this.Da.ExecuteDMLQuery(sql);

                    if (count == 1)
                        MessageBox.Show("Data has been successfully updated.", "Success");
                    else
                        MessageBox.Show("There was an issue updating the data. Please try again.", "Error");
                }
                else if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("There is no student against this ID . Please try again.", "Error");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured, please check: " + exc.Message);
            }
            this.PopulateGridView();
            this.ClearAll();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvStudent.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a row first to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var id = this.dgvStudent.CurrentRow.Cells[1].Value.ToString();
                var title = this.dgvStudent.CurrentRow.Cells[0].Value.ToString();

                string checkSql = $"SELECT COUNT(*) FROM ISSUE_BOOK WHERE STUDENT_ID = '{id}';";
                DataTable dt = this.Da.ExecuteQueryTable(checkSql);

                if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
                {
                    MessageBox.Show($"Cannot delete student '{title}' because they have issued books. Please return books first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to delete " + title + "?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;

                var sql = "delete from STUDENT_TABLE where STUDENT_ID = '" + id + "';";
                var count = this.Da.ExecuteDMLQuery(sql);

                if (count == 1)
                    MessageBox.Show(title.ToUpper() + " has been removed from the list.");
                else
                    MessageBox.Show("Data hasn't been removed properly");

                this.PopulateGridView();
                this.ClearAll();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured, please check: " + exc.Message);
            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvStudent.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a student first.", "No student selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string studentName = this.dgvStudent.CurrentRow.Cells["STUDENT_NAME"].Value.ToString();
                string studentID = this.dgvStudent.CurrentRow.Cells["STUDENT_ID"].Value.ToString();

                new FormBorrowHistory(studentName, studentID, this).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }
        }
    }
}
