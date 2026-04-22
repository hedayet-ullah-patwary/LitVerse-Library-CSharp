namespace LibraryManagement
{
    partial class FormIssueBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStudentInfo = new System.Windows.Forms.DataGridView();
            this.STUDENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STUDENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUALIFICATION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvSelectedBook = new System.Windows.Forms.DataGridView();
            this.Book_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Issue_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delivary_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStudentSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBookSearch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBoxBack = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.label1.Location = new System.Drawing.Point(436, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Issue Book Form";
            // 
            // dgvStudentInfo
            // 
            this.dgvStudentInfo.AllowUserToAddRows = false;
            this.dgvStudentInfo.AllowUserToDeleteRows = false;
            this.dgvStudentInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudentInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STUDENT_ID,
            this.STUDENT_NAME,
            this.QUALIFICATION});
            this.dgvStudentInfo.Location = new System.Drawing.Point(12, 85);
            this.dgvStudentInfo.Name = "dgvStudentInfo";
            this.dgvStudentInfo.ReadOnly = true;
            this.dgvStudentInfo.RowHeadersWidth = 51;
            this.dgvStudentInfo.RowTemplate.Height = 24;
            this.dgvStudentInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudentInfo.Size = new System.Drawing.Size(534, 150);
            this.dgvStudentInfo.TabIndex = 1;
            this.dgvStudentInfo.DoubleClick += new System.EventHandler(this.dgvStudentInfo_DoubleClick);
            // 
            // STUDENT_ID
            // 
            this.STUDENT_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.STUDENT_ID.DataPropertyName = "STUDENT_ID";
            this.STUDENT_ID.HeaderText = "Student ID";
            this.STUDENT_ID.MinimumWidth = 6;
            this.STUDENT_ID.Name = "STUDENT_ID";
            this.STUDENT_ID.ReadOnly = true;
            // 
            // STUDENT_NAME
            // 
            this.STUDENT_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.STUDENT_NAME.DataPropertyName = "STUDENT_NAME";
            this.STUDENT_NAME.HeaderText = "Student Name";
            this.STUDENT_NAME.MinimumWidth = 6;
            this.STUDENT_NAME.Name = "STUDENT_NAME";
            this.STUDENT_NAME.ReadOnly = true;
            // 
            // QUALIFICATION
            // 
            this.QUALIFICATION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QUALIFICATION.DataPropertyName = "QUALIFICATION";
            this.QUALIFICATION.HeaderText = "Qualification";
            this.QUALIFICATION.MinimumWidth = 6;
            this.QUALIFICATION.Name = "QUALIFICATION";
            this.QUALIFICATION.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Student List: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.label3.Location = new System.Drawing.Point(79, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Student Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.label4.Location = new System.Drawing.Point(79, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Student ID";
            // 
            // txtStudentName
            // 
            this.txtStudentName.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentName.Location = new System.Drawing.Point(272, 244);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.ReadOnly = true;
            this.txtStudentName.Size = new System.Drawing.Size(203, 27);
            this.txtStudentName.TabIndex = 6;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentID.Location = new System.Drawing.Point(272, 279);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.ReadOnly = true;
            this.txtStudentID.Size = new System.Drawing.Size(203, 27);
            this.txtStudentID.TabIndex = 7;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.flowLayoutPanel.Location = new System.Drawing.Point(12, 355);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(1258, 286);
            this.flowLayoutPanel.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.label5.Location = new System.Drawing.Point(12, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Book List:";
            // 
            // dgvSelectedBook
            // 
            this.dgvSelectedBook.AllowUserToAddRows = false;
            this.dgvSelectedBook.AllowUserToDeleteRows = false;
            this.dgvSelectedBook.BackgroundColor = System.Drawing.Color.White;
            this.dgvSelectedBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedBook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Book_ID,
            this.Title,
            this.Author,
            this.Issue_Date,
            this.Delivary_Date});
            this.dgvSelectedBook.Location = new System.Drawing.Point(570, 85);
            this.dgvSelectedBook.Name = "dgvSelectedBook";
            this.dgvSelectedBook.ReadOnly = true;
            this.dgvSelectedBook.RowHeadersWidth = 51;
            this.dgvSelectedBook.RowTemplate.Height = 24;
            this.dgvSelectedBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedBook.Size = new System.Drawing.Size(700, 183);
            this.dgvSelectedBook.TabIndex = 10;
            // 
            // Book_ID
            // 
            this.Book_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Book_ID.HeaderText = "Book_ID";
            this.Book_ID.MinimumWidth = 6;
            this.Book_ID.Name = "Book_ID";
            this.Book_ID.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.HeaderText = "Title";
            this.Title.MinimumWidth = 6;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Author
            // 
            this.Author.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Author.HeaderText = "Author";
            this.Author.MinimumWidth = 6;
            this.Author.Name = "Author";
            this.Author.ReadOnly = true;
            // 
            // Issue_Date
            // 
            this.Issue_Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Issue_Date.HeaderText = "Issue_Date";
            this.Issue_Date.MinimumWidth = 6;
            this.Issue_Date.Name = "Issue_Date";
            this.Issue_Date.ReadOnly = true;
            // 
            // Delivary_Date
            // 
            this.Delivary_Date.HeaderText = "Delivary_Date";
            this.Delivary_Date.MinimumWidth = 6;
            this.Delivary_Date.Name = "Delivary_Date";
            this.Delivary_Date.ReadOnly = true;
            this.Delivary_Date.Width = 125;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.btnDelete.Location = new System.Drawing.Point(705, 273);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(121, 35);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClearAll.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.btnClearAll.Location = new System.Drawing.Point(858, 273);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(121, 35);
            this.btnClearAll.TabIndex = 12;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = false;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnConfirm.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.btnConfirm.Location = new System.Drawing.Point(1011, 273);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(121, 35);
            this.btnConfirm.TabIndex = 13;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(257, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 18);
            this.label9.TabIndex = 23;
            this.label9.Text = "(Search by ID)";
            // 
            // txtStudentSearch
            // 
            this.txtStudentSearch.Font = new System.Drawing.Font("Mongolian Baiti", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentSearch.Location = new System.Drawing.Point(381, 60);
            this.txtStudentSearch.Name = "txtStudentSearch";
            this.txtStudentSearch.Size = new System.Drawing.Size(165, 22);
            this.txtStudentSearch.TabIndex = 22;
            this.txtStudentSearch.TextChanged += new System.EventHandler(this.txtStudentSearch_TextChanged);
            this.txtStudentSearch.Enter += new System.EventHandler(this.txtStudentSearch_Enter);
            this.txtStudentSearch.Leave += new System.EventHandler(this.txtStudentSearch_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(824, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 18);
            this.label6.TabIndex = 25;
            this.label6.Text = "(Search by Book Title)";
            // 
            // txtBookSearch
            // 
            this.txtBookSearch.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookSearch.Location = new System.Drawing.Point(1008, 325);
            this.txtBookSearch.Name = "txtBookSearch";
            this.txtBookSearch.Size = new System.Drawing.Size(246, 27);
            this.txtBookSearch.TabIndex = 24;
            this.txtBookSearch.TextChanged += new System.EventHandler(this.txtBookSearch_TextChanged);
            this.txtBookSearch.Enter += new System.EventHandler(this.txtBookSearch_Enter);
            this.txtBookSearch.Leave += new System.EventHandler(this.txtBookSearch_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.label7.Location = new System.Drawing.Point(566, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 21);
            this.label7.TabIndex = 26;
            this.label7.Text = "Selected Books:";
            // 
            // pictureBoxBack
            // 
            this.pictureBoxBack.Image = global::LibraryManagement.Properties.Resources._return;
            this.pictureBoxBack.Location = new System.Drawing.Point(12, 8);
            this.pictureBoxBack.Name = "pictureBoxBack";
            this.pictureBoxBack.Size = new System.Drawing.Size(51, 42);
            this.pictureBoxBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBack.TabIndex = 27;
            this.pictureBoxBack.TabStop = false;
            this.pictureBoxBack.Click += new System.EventHandler(this.pictureBoxBack_Click);
            this.pictureBoxBack.MouseEnter += new System.EventHandler(this.pictureBoxBack_MouseEnter);
            this.pictureBoxBack.MouseLeave += new System.EventHandler(this.pictureBoxBack_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBoxBack);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1281, 55);
            this.panel1.TabIndex = 28;
            // 
            // FormIssueBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBookSearch);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtStudentSearch);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvSelectedBook);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvStudentInfo);
            this.MaximizeBox = false;
            this.Name = "FormIssueBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormIssueBook";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormIssueBook_FormClosed);
            this.Load += new System.EventHandler(this.FormIssueBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvStudentInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvSelectedBook;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn Issue_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delivary_Date;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStudentSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBookSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBoxBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn STUDENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn STUDENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUALIFICATION;
        private System.Windows.Forms.Panel panel1;
    }
}