namespace LibraryManagement
{
    partial class FormEmployeeDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnIssuedBook = new System.Windows.Forms.Button();
            this.btnStudentManagement = new System.Windows.Forms.Button();
            this.btnBookManagement = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPendingFine = new System.Windows.Forms.Label();
            this.lblOverdueBook = new System.Windows.Forms.Label();
            this.lblIssueBookToday = new System.Windows.Forms.Label();
            this.LineChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LineChart)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SkyBlue;
            this.panel3.Controls.Add(this.lblID);
            this.panel3.Controls.Add(this.lblName);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.lblWelcome);
            this.panel3.Location = new System.Drawing.Point(0, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1282, 135);
            this.panel3.TabIndex = 6;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.lblID.Location = new System.Drawing.Point(1141, 82);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(64, 24);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "a-001";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.lblName.Location = new System.Drawing.Point(1141, 58);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 24);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibraryManagement.Properties.Resources.png_transparent_computer_icons_user_profile_circle_abstract_miscellaneous_rim_account;
            this.pictureBox1.Location = new System.Drawing.Point(1146, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Mongolian Baiti", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.lblWelcome.Location = new System.Drawing.Point(12, 39);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(236, 50);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(0)))), ((int)(((byte)(42)))));
            this.panel1.Controls.Add(this.panelMenu);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(0, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 520);
            this.panel1.TabIndex = 7;
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnReturnBook);
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.btnIssuedBook);
            this.panelMenu.Controls.Add(this.btnStudentManagement);
            this.panelMenu.Controls.Add(this.btnBookManagement);
            this.panelMenu.Location = new System.Drawing.Point(3, 85);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(371, 340);
            this.panelMenu.TabIndex = 2;
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.BackColor = System.Drawing.Color.Transparent;
            this.btnReturnBook.FlatAppearance.BorderSize = 0;
            this.btnReturnBook.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReturnBook.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReturnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnBook.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(91)))), ((int)(((byte)(74)))));
            this.btnReturnBook.Location = new System.Drawing.Point(35, 139);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(276, 37);
            this.btnReturnBook.TabIndex = 6;
            this.btnReturnBook.Text = "Return Book";
            this.btnReturnBook.UseVisualStyleBackColor = false;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            this.btnReturnBook.MouseEnter += new System.EventHandler(this.btnReturnBook_MouseEnter);
            this.btnReturnBook.MouseLeave += new System.EventHandler(this.btnReturnBook_MouseLeave);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(91)))), ((int)(((byte)(74)))));
            this.btnLogout.Location = new System.Drawing.Point(35, 182);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(276, 37);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            this.btnLogout.MouseEnter += new System.EventHandler(this.btnReturnBook_MouseEnter);
            this.btnLogout.MouseLeave += new System.EventHandler(this.btnReturnBook_MouseLeave);
            // 
            // btnIssuedBook
            // 
            this.btnIssuedBook.BackColor = System.Drawing.Color.Transparent;
            this.btnIssuedBook.FlatAppearance.BorderSize = 0;
            this.btnIssuedBook.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnIssuedBook.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnIssuedBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssuedBook.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssuedBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(91)))), ((int)(((byte)(74)))));
            this.btnIssuedBook.Location = new System.Drawing.Point(9, 95);
            this.btnIssuedBook.Name = "btnIssuedBook";
            this.btnIssuedBook.Size = new System.Drawing.Size(329, 37);
            this.btnIssuedBook.TabIndex = 4;
            this.btnIssuedBook.Text = "Issued Books Management";
            this.btnIssuedBook.UseVisualStyleBackColor = false;
            this.btnIssuedBook.Click += new System.EventHandler(this.btnIssuedBook_Click);
            this.btnIssuedBook.MouseEnter += new System.EventHandler(this.btnReturnBook_MouseEnter);
            this.btnIssuedBook.MouseLeave += new System.EventHandler(this.btnReturnBook_MouseLeave);
            // 
            // btnStudentManagement
            // 
            this.btnStudentManagement.BackColor = System.Drawing.Color.Transparent;
            this.btnStudentManagement.FlatAppearance.BorderSize = 0;
            this.btnStudentManagement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStudentManagement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStudentManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentManagement.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentManagement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(91)))), ((int)(((byte)(74)))));
            this.btnStudentManagement.Location = new System.Drawing.Point(13, 52);
            this.btnStudentManagement.Name = "btnStudentManagement";
            this.btnStudentManagement.Size = new System.Drawing.Size(321, 37);
            this.btnStudentManagement.TabIndex = 3;
            this.btnStudentManagement.Text = "Student Records";
            this.btnStudentManagement.UseVisualStyleBackColor = false;
            this.btnStudentManagement.Click += new System.EventHandler(this.btnStudentManagement_Click);
            this.btnStudentManagement.MouseEnter += new System.EventHandler(this.btnReturnBook_MouseEnter);
            this.btnStudentManagement.MouseLeave += new System.EventHandler(this.btnReturnBook_MouseLeave);
            // 
            // btnBookManagement
            // 
            this.btnBookManagement.BackColor = System.Drawing.Color.Transparent;
            this.btnBookManagement.FlatAppearance.BorderSize = 0;
            this.btnBookManagement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBookManagement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBookManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookManagement.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookManagement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(91)))), ((int)(((byte)(74)))));
            this.btnBookManagement.Location = new System.Drawing.Point(4, 9);
            this.btnBookManagement.Name = "btnBookManagement";
            this.btnBookManagement.Size = new System.Drawing.Size(338, 37);
            this.btnBookManagement.TabIndex = 2;
            this.btnBookManagement.Text = "Book Management";
            this.btnBookManagement.UseVisualStyleBackColor = false;
            this.btnBookManagement.Click += new System.EventHandler(this.btnBookManagement_Click);
            this.btnBookManagement.MouseEnter += new System.EventHandler(this.btnReturnBook_MouseEnter);
            this.btnBookManagement.MouseLeave += new System.EventHandler(this.btnReturnBook_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LibraryManagement.Properties.Resources._358_3587928_burgers_clip_art;
            this.pictureBox2.Location = new System.Drawing.Point(17, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(54, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblPendingFine);
            this.panel2.Controls.Add(this.lblOverdueBook);
            this.panel2.Controls.Add(this.lblIssueBookToday);
            this.panel2.Controls.Add(this.LineChart);
            this.panel2.Controls.Add(this.lbl3);
            this.panel2.Controls.Add(this.lbl2);
            this.panel2.Controls.Add(this.lbl1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(380, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(902, 520);
            this.panel2.TabIndex = 8;
            // 
            // lblPendingFine
            // 
            this.lblPendingFine.AutoSize = true;
            this.lblPendingFine.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingFine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.lblPendingFine.Location = new System.Drawing.Point(356, 150);
            this.lblPendingFine.Name = "lblPendingFine";
            this.lblPendingFine.Size = new System.Drawing.Size(64, 24);
            this.lblPendingFine.TabIndex = 10;
            this.lblPendingFine.Text = "a-001";
            // 
            // lblOverdueBook
            // 
            this.lblOverdueBook.AutoSize = true;
            this.lblOverdueBook.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverdueBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.lblOverdueBook.Location = new System.Drawing.Point(269, 115);
            this.lblOverdueBook.Name = "lblOverdueBook";
            this.lblOverdueBook.Size = new System.Drawing.Size(64, 24);
            this.lblOverdueBook.TabIndex = 9;
            this.lblOverdueBook.Text = "a-001";
            // 
            // lblIssueBookToday
            // 
            this.lblIssueBookToday.AutoSize = true;
            this.lblIssueBookToday.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueBookToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.lblIssueBookToday.Location = new System.Drawing.Point(330, 81);
            this.lblIssueBookToday.Name = "lblIssueBookToday";
            this.lblIssueBookToday.Size = new System.Drawing.Size(64, 24);
            this.lblIssueBookToday.TabIndex = 8;
            this.lblIssueBookToday.Text = "a-001";
            // 
            // LineChart
            // 
            chartArea1.Name = "ChartArea1";
            this.LineChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.LineChart.Legends.Add(legend1);
            this.LineChart.Location = new System.Drawing.Point(13, 295);
            this.LineChart.Name = "LineChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.LineChart.Series.Add(series1);
            this.LineChart.Size = new System.Drawing.Size(877, 213);
            this.LineChart.TabIndex = 5;
            this.LineChart.Text = "chart1";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.lbl3.Location = new System.Drawing.Point(71, 149);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(259, 24);
            this.lbl3.TabIndex = 4;
            this.lbl3.Text = "Pending fine payments: ";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.lbl2.Location = new System.Drawing.Point(71, 115);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(181, 24);
            this.lbl2.TabIndex = 3;
            this.lbl2.Text = "Overdue books: ";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.lbl1.Location = new System.Drawing.Point(71, 81);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(243, 24);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Issued books number: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.label2.Location = new System.Drawing.Point(29, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Short Views";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(43)))), ((int)(((byte)(78)))));
            this.label1.Location = new System.Drawing.Point(8, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(424, 30);
            this.label1.TabIndex = 11;
            this.label1.Text = "Issued book vs Date (Line Chart):";
            // 
            // FormEmployeeDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.Name = "FormEmployeeDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEmployeeDashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormEmployeeDashboard_FormClosed);
            this.Load += new System.EventHandler(this.FormEmployeeDashboard_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LineChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnIssuedBook;
        private System.Windows.Forms.Button btnStudentManagement;
        private System.Windows.Forms.Button btnBookManagement;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.DataVisualization.Charting.Chart LineChart;
        private System.Windows.Forms.Label lblPendingFine;
        private System.Windows.Forms.Label lblOverdueBook;
        private System.Windows.Forms.Label lblIssueBookToday;
        private System.Windows.Forms.Label label1;
    }
}