namespace VNTSellGold.Forms
{
    partial class FrmTbl1Edit
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbl1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vNTSellGoldDataSet = new VNTSellGold.VNTSellGoldDataSet();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbl1TableAdapter = new VNTSellGold.VNTSellGoldDataSetTableAdapters.Tbl1TableAdapter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vNTSellGoldDataSet)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SCol1});
            this.dataGridView1.DataSource = this.tbl1BindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(404, 266);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_RowValidating);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // tbl1BindingSource
            // 
            this.tbl1BindingSource.DataMember = "Tbl1";
            this.tbl1BindingSource.DataSource = this.vNTSellGoldDataSet;
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
            // tbl1TableAdapter
            // 
            this.tbl1TableAdapter.ClearBeforeFill = true;
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
            this.splitContainer1.Size = new System.Drawing.Size(404, 328);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            // 
            // SCol1
            // 
            this.SCol1.DataPropertyName = "SCol1";
            this.SCol1.HeaderText = "Loại Trang Sức";
            this.SCol1.Name = "SCol1";
            this.SCol1.Width = 361;
            // 
            // FrmTbl1Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 328);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmTbl1Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTbl1Edit";
            this.Load += new System.EventHandler(this.FrmTbl1Edit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vNTSellGoldDataSet)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private VNTSellGoldDataSet vNTSellGoldDataSet;
        private System.Windows.Forms.BindingSource tbl1BindingSource;
        private VNTSellGold.VNTSellGoldDataSetTableAdapters.Tbl1TableAdapter tbl1TableAdapter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCol1;
    }
}