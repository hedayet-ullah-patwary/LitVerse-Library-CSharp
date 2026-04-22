namespace LibraryManagement
{
    partial class FormReturnBook
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
            this.label9 = new System.Windows.Forms.Label();
            this.txtStudentSearch = new System.Windows.Forms.TextBox();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvStudentInfo = new System.Windows.Forms.DataGridView();
            this.Student_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Student_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qualification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvSelectedBook = new System.Windows.Forms.DataGridView();
            this.Book_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delivary_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCalculatedFine = new System.Windows.Forms.Label();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelPayment = new System.Windows.Forms.Panel();
            this.rbNagad = new System.Windows.Forms.RadioButton();
            this.rbBikash = new System.Windows.Forms.RadioButton();
            this.rbCard = new System.Windows.Forms.RadioButton();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.pictureBoxBack = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedBook)).BeginInit();
            this.panelPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.label1.Location = new System.Drawing.Point(404, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Return Book Form";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(255, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 18);
            this.label9.TabIndex = 31;
            this.label9.Text = "(Search by ID)";
            // 
            // txtStudentSearch
            // 
            this.txtStudentSearch.Font = new System.Drawing.Font("Mongolian Baiti", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentSearch.Location = new System.Drawing.Point(379, 58);
            this.txtStudentSearch.Name = "txtStudentSearch";
            this.txtStudentSearch.Size = new System.Drawing.Size(165, 22);
            this.txtStudentSearch.TabIndex = 30;
            this.txtStudentSearch.TextChanged += new System.EventHandler(this.txtStudentSearch_TextChanged);
            this.txtStudentSearch.Enter += new System.EventHandler(this.txtStudentSearch_Enter);
            this.txtStudentSearch.Leave += new System.EventHandler(this.txtStudentSearch_Leave);
            // 
            // txtStudentID
            // 
            this.txtStudentID.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentID.Location = new System.Drawing.Point(270, 277);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.ReadOnly = true;
            this.txtStudentID.Size = new System.Drawing.Size(149, 27);
            this.txtStudentID.TabIndex = 29;
            // 
            // txtStudentName
            // 
            this.txtStudentName.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentName.Location = new System.Drawing.Point(270, 242);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.ReadOnly = true;
            this.txtStudentName.Size = new System.Drawing.Size(149, 27);
            this.txtStudentName.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.label4.Location = new System.Drawing.Point(77, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 24);
            this.label4.TabIndex = 27;
            this.label4.Text = "Student ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.label3.Location = new System.Drawing.Point(77, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 24);
            this.label3.TabIndex = 26;
            this.label3.Text = "Student Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.label2.Location = new System.Drawing.Point(10, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 21);
            this.label2.TabIndex = 25;
            this.label2.Text = "Student List: ";
            // 
            // dgvStudentInfo
            // 
            this.dgvStudentInfo.AllowUserToAddRows = false;
            this.dgvStudentInfo.AllowUserToDeleteRows = false;
            this.dgvStudentInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudentInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Student_ID,
            this.Student_Name,
            this.Qualification});
            this.dgvStudentInfo.Location = new System.Drawing.Point(10, 83);
            this.dgvStudentInfo.Name = "dgvStudentInfo";
            this.dgvStudentInfo.ReadOnly = true;
            this.dgvStudentInfo.RowHeadersWidth = 51;
            this.dgvStudentInfo.RowTemplate.Height = 24;
            this.dgvStudentInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudentInfo.Size = new System.Drawing.Size(534, 150);
            this.dgvStudentInfo.TabIndex = 24;
            this.dgvStudentInfo.DoubleClick += new System.EventHandler(this.dgvStudentInfo_DoubleClick);
            // 
            // Student_ID
            // 
            this.Student_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Student_ID.DataPropertyName = "Student_ID";
            this.Student_ID.HeaderText = "Student_ID";
            this.Student_ID.MinimumWidth = 6;
            this.Student_ID.Name = "Student_ID";
            this.Student_ID.ReadOnly = true;
            // 
            // Student_Name
            // 
            this.Student_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Student_Name.DataPropertyName = "Student_Name";
            this.Student_Name.HeaderText = "Student_Name";
            this.Student_Name.MinimumWidth = 6;
            this.Student_Name.Name = "Student_Name";
            this.Student_Name.ReadOnly = true;
            // 
            // Qualification
            // 
            this.Qualification.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Qualification.DataPropertyName = "Qualification";
            this.Qualification.HeaderText = "Qualification";
            this.Qualification.MinimumWidth = 6;
            this.Qualification.Name = "Qualification";
            this.Qualification.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.label7.Location = new System.Drawing.Point(565, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 21);
            this.label7.TabIndex = 36;
            this.label7.Text = "Selected Books:";
            // 
            // btnClearAll
            // 
            this.btnClearAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClearAll.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.btnClearAll.Location = new System.Drawing.Point(944, 297);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(131, 36);
            this.btnClearAll.TabIndex = 34;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = false;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.btnDelete.Location = new System.Drawing.Point(767, 298);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(131, 35);
            this.btnDelete.TabIndex = 33;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.Delivary_Date,
            this.Fine});
            this.dgvSelectedBook.Location = new System.Drawing.Point(569, 83);
            this.dgvSelectedBook.Name = "dgvSelectedBook";
            this.dgvSelectedBook.ReadOnly = true;
            this.dgvSelectedBook.RowHeadersWidth = 51;
            this.dgvSelectedBook.RowTemplate.Height = 24;
            this.dgvSelectedBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedBook.Size = new System.Drawing.Size(700, 183);
            this.dgvSelectedBook.TabIndex = 32;
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
            // Delivary_Date
            // 
            this.Delivary_Date.HeaderText = "Delivary_Date";
            this.Delivary_Date.MinimumWidth = 6;
            this.Delivary_Date.Name = "Delivary_Date";
            this.Delivary_Date.ReadOnly = true;
            this.Delivary_Date.Width = 125;
            // 
            // Fine
            // 
            this.Fine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fine.HeaderText = "Fine";
            this.Fine.MinimumWidth = 6;
            this.Fine.Name = "Fine";
            this.Fine.ReadOnly = true;
            // 
            // lblCalculatedFine
            // 
            this.lblCalculatedFine.AutoSize = true;
            this.lblCalculatedFine.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalculatedFine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.lblCalculatedFine.Location = new System.Drawing.Point(565, 269);
            this.lblCalculatedFine.Name = "lblCalculatedFine";
            this.lblCalculatedFine.Size = new System.Drawing.Size(183, 24);
            this.lblCalculatedFine.TabIndex = 37;
            this.lblCalculatedFine.Text = "Calculated Fine: ";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.flowLayoutPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.flowLayoutPanel.Location = new System.Drawing.Point(12, 369);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(806, 272);
            this.flowLayoutPanel.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.label5.Location = new System.Drawing.Point(11, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 24);
            this.label5.TabIndex = 39;
            this.label5.Text = "Borrowed Books:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(258, 24);
            this.label6.TabIndex = 40;
            this.label6.Text = "Select Payment Method:";
            // 
            // panelPayment
            // 
            this.panelPayment.Controls.Add(this.rbNagad);
            this.panelPayment.Controls.Add(this.rbBikash);
            this.panelPayment.Controls.Add(this.rbCard);
            this.panelPayment.Controls.Add(this.label6);
            this.panelPayment.Controls.Add(this.rbCash);
            this.panelPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.panelPayment.Location = new System.Drawing.Point(840, 369);
            this.panelPayment.Name = "panelPayment";
            this.panelPayment.Size = new System.Drawing.Size(429, 233);
            this.panelPayment.TabIndex = 41;
            // 
            // rbNagad
            // 
            this.rbNagad.AutoSize = true;
            this.rbNagad.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNagad.Location = new System.Drawing.Point(104, 159);
            this.rbNagad.Name = "rbNagad";
            this.rbNagad.Size = new System.Drawing.Size(88, 25);
            this.rbNagad.TabIndex = 3;
            this.rbNagad.TabStop = true;
            this.rbNagad.Text = "Nagad";
            this.rbNagad.UseVisualStyleBackColor = true;
            // 
            // rbBikash
            // 
            this.rbBikash.AutoSize = true;
            this.rbBikash.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBikash.Location = new System.Drawing.Point(104, 122);
            this.rbBikash.Name = "rbBikash";
            this.rbBikash.Size = new System.Drawing.Size(93, 25);
            this.rbBikash.TabIndex = 2;
            this.rbBikash.TabStop = true;
            this.rbBikash.Text = "Bikash";
            this.rbBikash.UseVisualStyleBackColor = true;
            // 
            // rbCard
            // 
            this.rbCard.AutoSize = true;
            this.rbCard.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCard.Location = new System.Drawing.Point(104, 85);
            this.rbCard.Name = "rbCard";
            this.rbCard.Size = new System.Drawing.Size(74, 25);
            this.rbCard.TabIndex = 1;
            this.rbCard.TabStop = true;
            this.rbCard.Text = "Card";
            this.rbCard.UseVisualStyleBackColor = true;
            // 
            // rbCash
            // 
            this.rbCash.AutoSize = true;
            this.rbCash.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCash.Location = new System.Drawing.Point(104, 48);
            this.rbCash.Name = "rbCash";
            this.rbCash.Size = new System.Drawing.Size(75, 25);
            this.rbCash.TabIndex = 0;
            this.rbCash.TabStop = true;
            this.rbCash.Text = "Cash";
            this.rbCash.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnConfirm.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.btnConfirm.Location = new System.Drawing.Point(1123, 608);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(104, 33);
            this.btnConfirm.TabIndex = 42;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // pictureBoxBack
            // 
            this.pictureBoxBack.Image = global::LibraryManagement.Properties.Resources._return;
            this.pictureBoxBack.Location = new System.Drawing.Point(12, 8);
            this.pictureBoxBack.Name = "pictureBoxBack";
            this.pictureBoxBack.Size = new System.Drawing.Size(51, 42);
            this.pictureBoxBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBack.TabIndex = 43;
            this.pictureBoxBack.TabStop = false;
            this.pictureBoxBack.Click += new System.EventHandler(this.pictureBoxBack_Click);
            this.pictureBoxBack.MouseEnter += new System.EventHandler(this.pictureBoxBack_MouseEnter);
            this.pictureBoxBack.MouseLeave += new System.EventHandler(this.pictureBoxBack_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBoxBack);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1281, 55);
            this.panel2.TabIndex = 44;
            // 
            // FormReturnBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.panelPayment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.lblCalculatedFine);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvSelectedBook);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtStudentSearch);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvStudentInfo);
            this.MaximizeBox = false;
            this.Name = "FormReturnBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReturnBook";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormReturnBook_FormClosed);
            this.Load += new System.EventHandler(this.FormReturnBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedBook)).EndInit();
            this.panelPayment.ResumeLayout(false);
            this.panelPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStudentSearch;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvStudentInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvSelectedBook;
        private System.Windows.Forms.Label lblCalculatedFine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delivary_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fine;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelPayment;
        private System.Windows.Forms.RadioButton rbNagad;
        private System.Windows.Forms.RadioButton rbBikash;
        private System.Windows.Forms.RadioButton rbCard;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.PictureBox pictureBoxBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn Student_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Student_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qualification;
        private System.Windows.Forms.Panel panel2;
    }
}