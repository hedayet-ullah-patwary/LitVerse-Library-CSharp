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
using System.Xml.Linq;

namespace LibraryManagement
{
    public partial class FormBookManagement : Form
    {
        private DataAccess Da { get; set; }

        private FormAdminDashboard Ad { get; set; }

        private string selectedID = "-1";

        public FormEmployeeDashboard FormEmployeeDashboard { get; set; }

        public FormBookManagement()
        {
            InitializeComponent();
            this.Da = new DataAccess();

            txtSearch.Text = "Search...";
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Enter += txtSearch_Enter;
            txtSearch.Leave += txtSearch_Leave;

            this.SetDefaultImage();
            this.LoadImagesToFlowLayoutPanel();

        }

        public FormBookManagement(FormAdminDashboard ad) : this()
        {
            this.Ad = ad;
        }

        public FormBookManagement(FormEmployeeDashboard formEmployeeDashboard) : this()
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
        }

        private void pictureBoxPreview_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBoxPreview_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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

        private void FormBookManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Da != null)
            {
                this.Da.Dispose();
            }
            Application.Exit();
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

                if (!this.IsValidName(this.txtAuthor.Text))
                {
                    MessageBox.Show("Author name should only contain alphabetic characters (A-Z, a-z).", "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!this.IsValidQuantity(this.txtQuantity.Text))
                {
                    MessageBox.Show("Quantity must be a valid non-negative number.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                string id = this.txtBookID.Text;
                string title = this.txtTitle.Text;
                string author = this.txtAuthor.Text;
                int quantity = int.Parse(txtQuantity.Text);
                string date = this.dtpPublishingYear.Text;
                string genre = this.cmbGenre.Text;

                byte[] imgData;

                if (pictureBoxPreview.Tag != null)
                {
                    string filePath = pictureBoxPreview.Tag.ToString();
                    imgData = File.ReadAllBytes(filePath);
                }
                else
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBoxPreview.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imgData = ms.ToArray();
                    }
                }

                var query = "select * from BOOK_TABLE where BOOK_ID = '" + id + "'";
                DataTable dt = this.Da.ExecuteQueryTable(query);

                if (dt.Rows.Count == 0)
                {
                    string sql = "INSERT INTO BOOK_TABLE (BOOK_ID, TITLE, AUTHOR, QUANTITY, PUBLISHED_DATE, PICTURE, GENRE) VALUES (@BOOK_ID, @TITLE, @AUTHOR, @QUANTITY, @PUBLISHED_DATE, @PICTURE, @GENRE)";

                    SqlCommand cmd = new SqlCommand(sql, Da.Sqlcon);
                    cmd.Parameters.AddWithValue("@BOOK_ID", id);
                    cmd.Parameters.AddWithValue("@TITLE", title);
                    cmd.Parameters.AddWithValue("@AUTHOR", author);
                    cmd.Parameters.AddWithValue("@QUANTITY", quantity);
                    cmd.Parameters.AddWithValue("@PUBLISHED_DATE", date);
                    cmd.Parameters.AddWithValue("@PICTURE", imgData);
                    cmd.Parameters.AddWithValue("@GENRE", genre);
                    cmd.ExecuteNonQuery();
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

            this.ClearAll();
            this.AutoIdGenerate();
            LoadImagesToFlowLayoutPanel();
        }

        private void pictureBoxPreview_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        pictureBoxPreview.Image = Image.FromStream(fs);
                        pictureBoxPreview.Tag = ofd.FileName;
                    }
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("The selected file is not a valid image or is too large.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        public void LoadImagesToFlowLayoutPanel()
        {
            flowLayoutPanel.Controls.Clear();
            DataTable dt = Da.ExecuteQueryTable("SELECT * FROM BOOK_TABLE");
            ShowImages(dt);
        }

        public void LoadImagesToFlowLayoutPanel(string searchText)
        {
            flowLayoutPanel.Controls.Clear();
            string sql = $"SELECT * FROM BOOK_TABLE WHERE TITLE LIKE '%{searchText}%'";
            DataTable dt = Da.ExecuteQueryTable(sql);
            ShowImages(dt);
        }

        private void ShowImages(DataTable dt)
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

                    Button btnDelete = new Button();
                    btnDelete.Text = "Delete";
                    btnDelete.Tag = id;
                    btnDelete.Click += btnDelete_Click;

                    Button btnEdit = new Button();
                    btnEdit.Text = "Edit";
                    btnEdit.Tag = id;
                    btnEdit.Click += btnEdit_Click;

                    FlowLayoutPanel itemPanel = new FlowLayoutPanel();
                    itemPanel.FlowDirection = FlowDirection.TopDown;
                    itemPanel.BackColor = Color.White;
                    itemPanel.Size = new Size(125, 260);
                    itemPanel.Margin = new Padding(10);

                    itemPanel.Controls.Add(pb);
                    itemPanel.Controls.Add(lbl1);
                    itemPanel.Controls.Add(lbl2);
                    itemPanel.Controls.Add(lbl3);
                    itemPanel.Controls.Add(btnDelete);
                    itemPanel.Controls.Add(btnEdit);

                    flowLayoutPanel.Controls.Add(itemPanel);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                string id = btn.Tag.ToString();

                DataAccess da = new DataAccess();

                string checkSql = $"SELECT COUNT(*) FROM ISSUE_BOOK WHERE BOOK_ID = '{id}';";
                DataTable dt = da.ExecuteQueryTable(checkSql);

                if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
                {
                    MessageBox.Show("This book cannot be deleted because it is currently issued to students.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = $"DELETE FROM BOOK_TABLE WHERE BOOK_ID = '{id}'";
                da.ExecuteDMLQuery(sql);

                MessageBox.Show("Deleted!");

                if (string.IsNullOrWhiteSpace(txtSearch.Text) || txtSearch.Text == "Search...")
                {
                    LoadImagesToFlowLayoutPanel();
                }
                else
                {
                    LoadImagesToFlowLayoutPanel(txtSearch.Text.Trim());
                }

                this.AutoIdGenerate();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured, please check: " + exc.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.Tag.ToString();

            string sql = $"SELECT * FROM BOOK_TABLE WHERE BOOK_ID = '{id}'";
            DataTable dt = this.Da.ExecuteQueryTable(sql);

            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                this.txtBookID.Text = row["BOOK_ID"].ToString();
                this.txtTitle.Text = row["TITLE"].ToString();
                this.txtAuthor.Text = row["AUTHOR"].ToString();
                this.txtQuantity.Text = row["QUANTITY"].ToString();
                this.cmbGenre.Text = row["GENRE"].ToString();
                this.dtpPublishingYear.Text = row["PUBLISHED_DATE"].ToString();

                byte[] imgData = (byte[])row["PICTURE"];
                using (MemoryStream ms = new MemoryStream(imgData))
                {
                    Image img = Image.FromStream(ms);
                    pictureBoxPreview.Image = img;
                    pictureBoxPreview.Tag = null;
                }

                this.selectedID = id; 
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text) || txtSearch.Text == "Search...")
            {
                LoadImagesToFlowLayoutPanel();
            }
            else
            {
                LoadImagesToFlowLayoutPanel(txtSearch.Text.Trim());
            }
        }

        private void AutoIdGenerate()
        {
            var query = "select max(BOOK_ID) from BOOK_TABLE;";
            var dt = this.Da.ExecuteQueryTable(query);

            string newId;

            if (dt.Rows.Count == 0 || dt.Rows[0][0] == DBNull.Value)
            {
                newId = "b-001";
            }
            else
            {
                var oldId = dt.Rows[0][0].ToString();
                string[] temp = oldId.Split('-');
                var num = Convert.ToInt32(temp[1]);
                newId = "b-" + (++num).ToString("d3");
            }

            this.txtBookID.Text = newId;
        }

        private void FormBookManagement_Load(object sender, EventArgs e)
        {
            this.AutoIdGenerate();
        }

        private void ClearAll()
        {
            this.txtBookID.Clear();
            this.cmbGenre.SelectedIndex = -1;
            this.txtTitle.Clear();
            this.txtAuthor.Clear();
            this.txtQuantity.Clear();
            this.dtpPublishingYear.Text = "";
            this.txtSearch.Text = "Search...";
            this.txtSearch.ForeColor = Color.Gray;

            this.SetDefaultImage();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAll();
            this.AutoIdGenerate();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedID == "-1")
                {
                    MessageBox.Show("Please select an item to update (click Edit first).");
                    return;
                }

                if (!this.IsValidToSave())
                {
                    MessageBox.Show("Please fill all the informations.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!this.IsValidName(this.txtAuthor.Text))
                {
                    MessageBox.Show("Author name should only contain alphabetic characters (A-Z, a-z).", "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!this.IsValidQuantity(this.txtQuantity.Text))
                {
                    MessageBox.Show("Quantity must be a valid non-negative number.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                string title = this.txtTitle.Text;
                string author = this.txtAuthor.Text;
                int quantity = int.Parse(txtQuantity.Text);
                string date = this.dtpPublishingYear.Text;
                string genre = this.cmbGenre.Text;

                byte[] imgData;

                if (pictureBoxPreview.Tag != null)
                {
                    string filePath = pictureBoxPreview.Tag.ToString();
                    imgData = File.ReadAllBytes(filePath);
                }
                else
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (Bitmap bmp = new Bitmap(pictureBoxPreview.Image))
                        {
                            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            imgData = ms.ToArray();
                        }
                    }

                }

                string imgHex = "0x" + BitConverter.ToString(imgData).Replace("-", "");

                string sql = $"UPDATE BOOK_TABLE SET TITLE = '{title}', AUTHOR = '{author}', QUANTITY = {quantity}, PUBLISHED_DATE = '{date}', GENRE = '{genre}', PICTURE = {imgHex} WHERE BOOK_ID = '{selectedID}'";

                int count = this.Da.ExecuteDMLQuery(sql);

                if (count > 0)
                {
                    MessageBox.Show("Update successful!");
                    this.ClearAll();

                    if (string.IsNullOrWhiteSpace(txtSearch.Text) || txtSearch.Text == "Search...")
                    {
                        LoadImagesToFlowLayoutPanel();
                    }
                    else
                    {
                        LoadImagesToFlowLayoutPanel(txtSearch.Text.Trim());
                    }
                }
                else
                {
                    MessageBox.Show("Update failed!");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured, please check: " + exc.Message);
            }

            this.AutoIdGenerate();
            this.ClearAll();
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

        private bool IsValidToSave()
        {
            if (string.IsNullOrEmpty(this.txtBookID.Text) || string.IsNullOrEmpty(this.txtTitle.Text) ||
                string.IsNullOrEmpty(this.txtAuthor.Text) || string.IsNullOrEmpty(this.txtQuantity.Text) ||
                string.IsNullOrEmpty(this.dtpPublishingYear.Text) || string.IsNullOrEmpty(this.cmbGenre.Text))
                return false;
            else
                return true;
        }

        private bool IsValidQuantity(string quantityStr)
        {
            int quantity;
            if (int.TryParse(quantityStr, out quantity))
            {
                if (quantity >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void SetDefaultImage()
        {
            pictureBoxPreview.Image = Properties.Resources.DefaultImage;
            pictureBoxPreview.Tag = null;
        }
    }
}
