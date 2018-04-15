namespace VNTSellGold.Forms
{
    partial class FrmTbl3Edit
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbl3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vNTSellGoldDataSet = new VNTSellGold.VNTSellGoldDataSet();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbl3TableAdapter = new VNTSellGold.VNTSellGoldDataSetTableAdapters.Tbl3TableAdapter();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCol2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCol3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCol4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCol5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCol6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ICol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vNTSellGoldDataSet)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.SCol1,
            this.SCol2,
            this.SCol3,
            this.SCol4,
            this.SCol5,
            this.DTCol1,
            this.SCol6,
            this.ICol1});
            this.dataGridView1.DataSource = this.tbl3BindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(931, 327);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_RowValidating);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // tbl3BindingSource
            // 
            this.tbl3BindingSource.DataMember = "Tbl3";
            this.tbl3BindingSource.DataSource = this.vNTSellGoldDataSet;
            // 
            // vNTSellGoldDataSet
            // 
            this.vNTSellGoldDataSet.DataSetName = "VNTSellGoldDataSet";
            this.vNTSellGoldDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(931, 404);
            this.splitContainer1.SplitterDistance = 327;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            // 
            // tbl3TableAdapter
            // 
            this.tbl3TableAdapter.ClearBeforeFill = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // SCol1
            // 
            this.SCol1.DataPropertyName = "SCol1";
            this.SCol1.HeaderText = "Mật Khẩu";
            this.SCol1.Name = "SCol1";
            this.SCol1.Width = 111;
            // 
            // SCol2
            // 
            this.SCol2.DataPropertyName = "SCol2";
            this.SCol2.HeaderText = "Họ Lót";
            this.SCol2.Name = "SCol2";
            this.SCol2.Width = 111;
            // 
            // SCol3
            // 
            this.SCol3.DataPropertyName = "SCol3";
            this.SCol3.HeaderText = "Tên";
            this.SCol3.Name = "SCol3";
            this.SCol3.Width = 111;
            // 
            // SCol4
            // 
            this.SCol4.DataPropertyName = "SCol4";
            this.SCol4.HeaderText = "Điện Thoại";
            this.SCol4.Name = "SCol4";
            this.SCol4.Width = 111;
            // 
            // SCol5
            // 
            this.SCol5.DataPropertyName = "SCol5";
            this.SCol5.HeaderText = "Địa Chỉ";
            this.SCol5.Name = "SCol5";
            this.SCol5.Width = 111;
            // 
            // DTCol1
            // 
            this.DTCol1.DataPropertyName = "DTCol1";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.DTCol1.DefaultCellStyle = dataGridViewCellStyle1;
            this.DTCol1.HeaderText = "Ngày Sinh";
            this.DTCol1.Name = "DTCol1";
            this.DTCol1.Width = 111;
            // 
            // SCol6
            // 
            this.SCol6.DataPropertyName = "SCol6";
            this.SCol6.HeaderText = "Ghi Chú";
            this.SCol6.Name = "SCol6";
            this.SCol6.Width = 111;
            // 
            // ICol1
            // 
            this.ICol1.DataPropertyName = "ICol1";
            dataGridViewCellStyle2.NullValue = "1";
            this.ICol1.DefaultCellStyle = dataGridViewCellStyle2;
            this.ICol1.HeaderText = "Chủ=0";
            this.ICol1.Name = "ICol1";
            this.ICol1.Width = 111;
            // 
            // FrmTbl3Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 404);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmTbl3Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý người dùng";
            this.Load += new System.EventHandler(this.FrmTbl3Edit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vNTSellGoldDataSet)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private VNTSellGoldDataSet vNTSellGoldDataSet;
        private System.Windows.Forms.BindingSource tbl3BindingSource;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private VNTSellGold.VNTSellGoldDataSetTableAdapters.Tbl3TableAdapter tbl3TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCol3;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCol4;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCol5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCol6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ICol1;
    }
}