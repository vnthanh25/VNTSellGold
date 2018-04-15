namespace VNTSellGold.Forms
{
    partial class FrmStatistic2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblUserName = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtPageSize = new System.Windows.Forms.TextBox();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.linkTatCa = new System.Windows.Forms.LinkLabel();
            this.linkCuoi = new System.Windows.Forms.LinkLabel();
            this.linkSau = new System.Windows.Forms.LinkLabel();
            this.linkTruoc = new System.Windows.Forms.LinkLabel();
            this.linkDau = new System.Windows.Forms.LinkLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCol1Tbl1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTbl1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTbl2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCol1Tbl2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ICol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MCol2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker2);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Panel1.Controls.Add(this.lblUserName);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox2);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtPageSize);
            this.splitContainer1.Panel2.Controls.Add(this.lblCurrentPage);
            this.splitContainer1.Panel2.Controls.Add(this.lblPageSize);
            this.splitContainer1.Panel2.Controls.Add(this.linkTatCa);
            this.splitContainer1.Panel2.Controls.Add(this.linkCuoi);
            this.splitContainer1.Panel2.Controls.Add(this.linkSau);
            this.splitContainer1.Panel2.Controls.Add(this.linkTruoc);
            this.splitContainer1.Panel2.Controls.Add(this.linkDau);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(786, 484);
            this.splitContainer1.SplitterDistance = 68;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(482, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Đến";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 66;
            this.label3.Text = "Từ";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(514, 23);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker2.TabIndex = 65;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(381, 24);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker1.TabIndex = 64;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(12, 8);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(57, 13);
            this.lblUserName.TabIndex = 63;
            this.lblUserName.Text = "UserName";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(716, 21);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 24);
            this.button2.TabIndex = 10;
            this.button2.Text = "Đã Bán";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(629, 21);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 24);
            this.button1.TabIndex = 9;
            this.button1.Text = "Đang Giữ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Theo";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(260, 22);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(78, 21);
            this.comboBox2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Người giữ";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(88, 21);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(118, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // txtPageSize
            // 
            this.txtPageSize.Location = new System.Drawing.Point(175, 388);
            this.txtPageSize.Name = "txtPageSize";
            this.txtPageSize.Size = new System.Drawing.Size(31, 20);
            this.txtPageSize.TabIndex = 25;
            this.txtPageSize.Text = "10";
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Location = new System.Drawing.Point(29, 391);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(13, 13);
            this.lblCurrentPage.TabIndex = 31;
            this.lblCurrentPage.Text = "0";
            this.lblCurrentPage.Visible = false;
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblPageSize.Location = new System.Drawing.Point(79, 391);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(93, 13);
            this.lblPageSize.TabIndex = 32;
            this.lblPageSize.Text = "Kích thước trang :";
            // 
            // linkTatCa
            // 
            this.linkTatCa.AutoSize = true;
            this.linkTatCa.Location = new System.Drawing.Point(365, 391);
            this.linkTatCa.Name = "linkTatCa";
            this.linkTatCa.Size = new System.Drawing.Size(38, 13);
            this.linkTatCa.TabIndex = 30;
            this.linkTatCa.TabStop = true;
            this.linkTatCa.Text = "Tất cả";
            // 
            // linkCuoi
            // 
            this.linkCuoi.AutoSize = true;
            this.linkCuoi.Location = new System.Drawing.Point(331, 391);
            this.linkCuoi.Name = "linkCuoi";
            this.linkCuoi.Size = new System.Drawing.Size(28, 13);
            this.linkCuoi.TabIndex = 29;
            this.linkCuoi.TabStop = true;
            this.linkCuoi.Text = "Cuối";
            // 
            // linkSau
            // 
            this.linkSau.AutoSize = true;
            this.linkSau.Location = new System.Drawing.Point(299, 391);
            this.linkSau.Name = "linkSau";
            this.linkSau.Size = new System.Drawing.Size(26, 13);
            this.linkSau.TabIndex = 28;
            this.linkSau.TabStop = true;
            this.linkSau.Text = "Sau";
            // 
            // linkTruoc
            // 
            this.linkTruoc.AutoSize = true;
            this.linkTruoc.Location = new System.Drawing.Point(257, 391);
            this.linkTruoc.Name = "linkTruoc";
            this.linkTruoc.Size = new System.Drawing.Size(35, 13);
            this.linkTruoc.TabIndex = 27;
            this.linkTruoc.TabStop = true;
            this.linkTruoc.Text = "Trước";
            // 
            // linkDau
            // 
            this.linkDau.AutoSize = true;
            this.linkDau.Location = new System.Drawing.Point(225, 391);
            this.linkDau.Name = "linkDau";
            this.linkDau.Size = new System.Drawing.Size(27, 13);
            this.linkDau.TabIndex = 26;
            this.linkDau.TabStop = true;
            this.linkDau.Text = "Đầu";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.SCol1Tbl1,
            this.IdTbl1,
            this.IdTbl2,
            this.SCol1Tbl2,
            this.ICol1,
            this.MCol1,
            this.MCol2,
            this.CreateDate});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(786, 364);
            this.dataGridView1.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Mã Số";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // SCol1Tbl1
            // 
            this.SCol1Tbl1.DataPropertyName = "SCol1Tbl1";
            this.SCol1Tbl1.HeaderText = "Loại Trang Sức";
            this.SCol1Tbl1.Name = "SCol1Tbl1";
            this.SCol1Tbl1.ReadOnly = true;
            // 
            // IdTbl1
            // 
            this.IdTbl1.DataPropertyName = "IdTbl1";
            this.IdTbl1.HeaderText = "IdTbl1";
            this.IdTbl1.Name = "IdTbl1";
            this.IdTbl1.ReadOnly = true;
            this.IdTbl1.Visible = false;
            // 
            // IdTbl2
            // 
            this.IdTbl2.DataPropertyName = "IdTbl2";
            this.IdTbl2.HeaderText = "IdTbl2";
            this.IdTbl2.Name = "IdTbl2";
            this.IdTbl2.ReadOnly = true;
            this.IdTbl2.Visible = false;
            // 
            // SCol1Tbl2
            // 
            this.SCol1Tbl2.DataPropertyName = "SCol1Tbl2";
            this.SCol1Tbl2.HeaderText = "Loại Vàng";
            this.SCol1Tbl2.Name = "SCol1Tbl2";
            this.SCol1Tbl2.ReadOnly = true;
            // 
            // ICol1
            // 
            this.ICol1.DataPropertyName = "ICol1";
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.ICol1.DefaultCellStyle = dataGridViewCellStyle9;
            this.ICol1.HeaderText = "Trọng Lượng";
            this.ICol1.Name = "ICol1";
            this.ICol1.ReadOnly = true;
            // 
            // MCol1
            // 
            this.MCol1.DataPropertyName = "MCol1";
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = null;
            this.MCol1.DefaultCellStyle = dataGridViewCellStyle10;
            this.MCol1.HeaderText = "Tiền Công";
            this.MCol1.Name = "MCol1";
            this.MCol1.ReadOnly = true;
            // 
            // MCol2
            // 
            this.MCol2.DataPropertyName = "MCol2";
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = null;
            this.MCol2.DefaultCellStyle = dataGridViewCellStyle11;
            this.MCol2.HeaderText = "Tiền Mua Vào";
            this.MCol2.Name = "MCol2";
            this.MCol2.ReadOnly = true;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            dataGridViewCellStyle12.Format = "dd/MM/yyyy";
            this.CreateDate.DefaultCellStyle = dataGridViewCellStyle12;
            this.CreateDate.HeaderText = "Ngày Nhập";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            // 
            // FrmStatistic2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 484);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmStatistic2";
            this.Text = "FrmStatistic";
            this.Load += new System.EventHandler(this.FrmStatistic2_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtPageSize;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.LinkLabel linkTatCa;
        private System.Windows.Forms.LinkLabel linkCuoi;
        private System.Windows.Forms.LinkLabel linkSau;
        private System.Windows.Forms.LinkLabel linkTruoc;
        private System.Windows.Forms.LinkLabel linkDau;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCol1Tbl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTbl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTbl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCol1Tbl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ICol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
    }
}