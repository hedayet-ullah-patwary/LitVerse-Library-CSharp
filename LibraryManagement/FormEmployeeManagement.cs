using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LibraryManagement
{
    public partial class FormEmployeeManagement : Form
    {
        private DataAccess Da { get; set; }

        private FormAdminDashboard Ad { get; set; }
        public FormEmployeeManagement()
        {
            InitializeComponent();
            this.Da = new DataAccess();

            txtSearch.Text = "Search...";
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Enter += txtSearch_Enter;
            txtSearch.Leave += txtSearch_Leave;

            this.PopulateGridView();
        }

        public FormEmployeeManagement(FormAdminDashboard ad):this()
        {
            this.Ad = ad;
        }

        private void PopulateGridView(string sql = "SELECT * FROM EMP_TABLE;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvAddemp.AutoGenerateColumns = false;
            this.dgvAddemp.DataSource = ds.Tables[0];
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
            this.dgvAddemp.ClearSelection();
        }

        private void pictureBoxBack_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBoxBack_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FormEmployeeManagement_FormClosed(object sender, FormClosedEventArgs e)
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
            this.Ad.Show();
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
                var sql = "SELECT * FROM EMP_TABLE where EMP_ID like '" + this.txtSearch.Text + "%';";
                this.PopulateGridView(sql);
            }
        }

        private void dgvAddemp_DoubleClick(object sender, EventArgs e)
        {
            this.txtEmployeeId.Text = this.dgvAddemp.CurrentRow.Cells[0].Value.ToString();
            this.txtEmployeeName.Text = this.dgvAddemp.CurrentRow.Cells[1].Value.ToString();
            this.txtPassword.Text = this.dgvAddemp.CurrentRow.Cells[2].Value.ToString();
            this.txtContact.Text = this.dgvAddemp.CurrentRow.Cells[3].Value.ToString();
            this.txtAddress.Text = this.dgvAddemp.CurrentRow.Cells[4].Value.ToString();
            this.dtpDateOfBirth.Text = this.dgvAddemp.CurrentRow.Cells[5].Value.ToString();
            this.txtEmail.Text = this.dgvAddemp.CurrentRow.Cells[6].Value.ToString();
            this.cmbRole.Text = " ";
            this.dgvAddemp.ClearSelection();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAll();
        }

        private void ClearAll()
        {
            this.cmbRole.SelectedIndex = -1;
            this.txtEmployeeId.Clear();
            this.txtEmployeeName.Clear();
            this.txtPassword.Clear();
            this.txtContact.Clear();
            this.txtAddress.Clear();
            this.dtpDateOfBirth.Text = "";
            this.txtEmail.Clear();

            this.dgvAddemp.ClearSelection();
        }

        private void AutoIdGenerate()
        {

            if (this.cmbRole.Text == "admin")
            {
                var query = "select max(EMP_ID) from EMP_TABLE where ROLE like 'a%';";
                var dt = this.Da.ExecuteQueryTable(query);
                var oldId = dt.Rows[0][0].ToString();
                string[] temp = oldId.Split('-');
                var num = Convert.ToInt32(temp[1]);
                var newId = "a-" + (++num).ToString("d3");
                this.txtEmployeeId.Text = newId;
            }
            else if (this.cmbRole.Text == "employee")
            {
                var query = "select max(EMP_ID) from EMP_TABLE where ROLE like 'e%';";
                var dt = this.Da.ExecuteQueryTable(query);
                var oldId = dt.Rows[0][0].ToString();
                string[] temp = oldId.Split('-');
                var num = Convert.ToInt32(temp[1]);
                var newId = "e-" + (++num).ToString("d3");
                this.txtEmployeeId.Text = newId;
            }
            else
            {
                return;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsValidToSave())
                {
                    MessageBox.Show("Please fill all the informations.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!this.IsValidName(this.txtEmployeeName.Text))
                {
                    MessageBox.Show("Employee name should only contain alphabetic characters (A-Z, a-z).", "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!this.IsValidContact(this.txtContact.Text))
                {
                    MessageBox.Show("Contact number should only contain numeric characters (0-9), must be 11 digit and frist 2 digit must be 01.", "Invalid contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!this.IsValidEmail(this.txtEmail.Text))
                {
                    MessageBox.Show("Invalid email format. Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var query = "select * from EMP_TABLE where EMP_ID = '" + this.txtEmployeeId.Text + "'";
                DataTable dt = this.Da.ExecuteQueryTable(query);

                if (dt.Rows.Count == 0)
                {
                    var sql = "insert into EMP_TABLE values('" + this.txtEmployeeId.Text + "', '" + this.txtEmployeeName.Text + "', '" + this.txtPassword.Text + "', '" + this.txtContact.Text + "', '" + this.txtAddress.Text + "', '" + this.txtEmail.Text + "', '" + this.dtpDateOfBirth.Text + "','" + this.cmbRole.Text + "'); ";
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

        private void FormEmployeeManagement_Load(object sender, EventArgs e)
        {
            this.dgvAddemp.ClearSelection();
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoIdGenerate();
        }

        private bool IsValidToSave()
        {
            if (string.IsNullOrEmpty(this.cmbRole.Text) || string.IsNullOrEmpty(this.txtEmployeeId.Text) ||
                string.IsNullOrEmpty(this.txtEmployeeName.Text) || string.IsNullOrEmpty(this.txtPassword.Text) ||
                string.IsNullOrEmpty(this.txtContact.Text) || string.IsNullOrEmpty(this.txtAddress.Text) || string.IsNullOrEmpty(this.txtEmail.Text))
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

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
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
                if (!this.IsValidName(this.txtEmployeeName.Text))
                {
                    MessageBox.Show("Employee name should only contain alphabetic characters (A-Z, a-z).", "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!this.IsValidContact(this.txtContact.Text))
                {
                    MessageBox.Show("Contact number should only contain numeric characters (0-9), must be 11 digit and frist 2 digit must be 01.", "Invalid contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!this.IsValidEmail(this.txtEmail.Text))
                {
                    MessageBox.Show("Invalid email format. Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var query1 = "select * from EMP_TABLE where EMP_ID = '" + this.txtEmployeeId.Text + "'";
                DataTable dt1 = this.Da.ExecuteQueryTable(query1);

                if (dt1.Rows.Count == 1)
                {
                    var query = "select * from EMP_TABLE where EMP_ID = '" + this.txtEmployeeId.Text + "'";
                    DataTable dt = this.Da.ExecuteQueryTable(query);
                    if (dt.Rows.Count == 1)
                    {
                        var sql = @"update EMP_TABLE
                                set EMP_NAME = '" + this.txtEmployeeName.Text + @"',
                                PASSWORD = '" + this.txtPassword.Text + @"',
                                CONTACT = '" + this.txtContact.Text + @"',
                                ADDRESS = '" + this.txtAddress.Text + @"',
                                DOB = '" + this.dtpDateOfBirth.Text + @"',
                                EMAIL = '" + this.txtEmail.Text + @"'
                                
                                where EMP_ID = '" + this.txtEmployeeId.Text + "'; ";
                        int count = this.Da.ExecuteDMLQuery(sql);

                        if (count == 1)
                            MessageBox.Show("Data has been successfully updated.", "Success");
                        else
                            MessageBox.Show("There was an issue updating the data. Please try again.", "Error");
                    }
                }
                else if (dt1.Rows.Count == 0)
                {
                    MessageBox.Show("For add new member enter submit button . Please try again.", "Error");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured, please check: " + exc.Message);
            }
            this.PopulateGridView();
            this.ClearAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvAddemp.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a row first to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var id = this.dgvAddemp.CurrentRow.Cells[0].Value.ToString();
                var title = this.dgvAddemp.CurrentRow.Cells[1].Value.ToString();

                if (id == "a-001")
                {
                    MessageBox.Show("You cannot delete the employee with ID 'a-001'.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (id == "e-001")
                {
                    MessageBox.Show("You cannot delete the employee with ID 'e-001'.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult result = MessageBox.Show("Are you sure you want to delete " + title + "?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;

                var sql = "delete from EMP_TABLE where EMP_ID = '" + id + "';";
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
    }
}
