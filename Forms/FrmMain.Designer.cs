namespace VNTSellGold.Forms
{
    partial class FrmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTbl3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTbl1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTbl2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTbl5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTbl6 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTbl7 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStatistic = new System.Windows.Forms.ToolStripMenuItem();
            this.saoLưuDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.tsm,
            this.tsmTbl5,
            this.tsmTbl6,
            this.tsmTbl7,
            this.tsmStatistic,
            this.saoLưuDữLiệuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(752, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // tsm
            // 
            this.tsm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmTbl3,
            this.tsmTbl1,
            this.tsmTbl2});
            this.tsm.Name = "tsm";
            this.tsm.Size = new System.Drawing.Size(106, 20);
            this.tsm.Text = "Nhập Danh Mục";
            // 
            // tsmTbl3
            // 
            this.tsmTbl3.Name = "tsmTbl3";
            this.tsmTbl3.Size = new System.Drawing.Size(184, 22);
            this.tsmTbl3.Text = "Nhập Nhân Viên";
            this.tsmTbl3.Click += new System.EventHandler(this.tsmTbl3_Click);
            // 
            // tsmTbl1
            // 
            this.tsmTbl1.Name = "tsmTbl1";
            this.tsmTbl1.Size = new System.Drawing.Size(184, 22);
            this.tsmTbl1.Text = "Nhập Loại Trang Sức";
            this.tsmTbl1.Click += new System.EventHandler(this.tsmTbl1_Click);
            // 
            // tsmTbl2
            // 
            this.tsmTbl2.Name = "tsmTbl2";
            this.tsmTbl2.Size = new System.Drawing.Size(184, 22);
            this.tsmTbl2.Text = "Nhập Loại Vàng";
            this.tsmTbl2.Click += new System.EventHandler(this.tsmTbl2_Click);
            // 
            // tsmTbl5
            // 
            this.tsmTbl5.Name = "tsmTbl5";
            this.tsmTbl5.Size = new System.Drawing.Size(107, 20);
            this.tsmTbl5.Text = "Nhập Trang Sức ";
            this.tsmTbl5.Click += new System.EventHandler(this.tsmTbl5_Click);
            // 
            // tsmTbl6
            // 
            this.tsmTbl6.Name = "tsmTbl6";
            this.tsmTbl6.Size = new System.Drawing.Size(99, 20);
            this.tsmTbl6.Text = "Giao Trang Sức";
            this.tsmTbl6.Click += new System.EventHandler(this.tsmTbl6_Click);
            // 
            // tsmTbl7
            // 
            this.tsmTbl7.Name = "tsmTbl7";
            this.tsmTbl7.Size = new System.Drawing.Size(95, 20);
            this.tsmTbl7.Text = "Bán Trang Sức";
            this.tsmTbl7.Click += new System.EventHandler(this.tsmTbl7_Click);
            // 
            // tsmStatistic
            // 
            this.tsmStatistic.Name = "tsmStatistic";
            this.tsmStatistic.Size = new System.Drawing.Size(70, 20);
            this.tsmStatistic.Text = "Thống Kê";
            this.tsmStatistic.Click += new System.EventHandler(this.tsmStatistic_Click);
            // 
            // saoLưuDữLiệuToolStripMenuItem
            // 
            this.saoLưuDữLiệuToolStripMenuItem.Name = "saoLưuDữLiệuToolStripMenuItem";
            this.saoLưuDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.saoLưuDữLiệuToolStripMenuItem.Text = "Sao Lưu Dữ Liệu";
            this.saoLưuDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.saoLưuDữLiệuToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 532);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsm;
        private System.Windows.Forms.ToolStripMenuItem tsmTbl3;
        private System.Windows.Forms.ToolStripMenuItem tsmTbl1;
        private System.Windows.Forms.ToolStripMenuItem tsmTbl2;
        private System.Windows.Forms.ToolStripMenuItem tsmTbl6;
        private System.Windows.Forms.ToolStripMenuItem tsmTbl7;
        private System.Windows.Forms.ToolStripMenuItem tsmTbl5;
        private System.Windows.Forms.ToolStripMenuItem tsmStatistic;
        private System.Windows.Forms.ToolStripMenuItem saoLưuDữLiệuToolStripMenuItem;
    }
}