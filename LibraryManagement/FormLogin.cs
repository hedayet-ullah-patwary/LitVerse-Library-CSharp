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
    public partial class FormLogin : Form
    {
        private DataAccess Da { set; get; }
        public FormLogin()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid())
                {
                    MessageBox.Show("Please fill all the information.");
                    return;
                }
                var sql = "select * from EMP_TABLE where EMP_ID='" + this.txtUserId.Text + "' and PASSWORD='" + this.txtPassword.Text + "';";
                DataSet ds = this.Da.ExecuteQuery(sql);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    var name = ds.Tables[0].Rows[0][1].ToString();
                    var id = ds.Tables[0].Rows[0][0].ToString();

                    this.Visible = false;
                    if (ds.Tables[0].Rows[0][7].ToString().Equals("admin"))
                    {
                        new FormAdminDashboard(name, id, this).Show();
                    }
                    else if (ds.Tables[0].Rows[0][7].ToString().Equals("employee"))
                    {
                        new FormEmployeeDashboard(name, id, this).Show();
                    }

                }
                else if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Wrong id or password.", "Warning!");

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error Occured.Please Check:" + exc.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAll();
        }

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(this.txtUserId.Text) || string.IsNullOrEmpty(this.txtPassword.Text))
                return false;
            else
                return true;
        }

        public void ClearAll()
        {
            this.txtUserId.Clear();
            this.txtPassword.Clear();

        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Da != null)
            {
                this.Da.Dispose();
            }
            Application.Exit();
        }
    }
}
