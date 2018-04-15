using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// -----------------------
using VNTCode = VNTSellGold.App_Code;

namespace VNTSellGold.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void tsmTbl5_Click(object sender, EventArgs e)
        {
            (new FrmTbl5Edit()).ShowDialog();
        }

        private void tsmTbl3_Click(object sender, EventArgs e)
        {
            (new FrmTbl3Edit()).ShowDialog();
        }

        private void tsmTbl1_Click(object sender, EventArgs e)
        {
            (new FrmTbl1Edit()).ShowDialog();
        }

        private void tsmTbl2_Click(object sender, EventArgs e)
        {
            (new FrmTbl2Edit()).ShowDialog();
        }

        private void tsmTbl6_Click(object sender, EventArgs e)
        {
            (new FrmTbl6Edit()).ShowDialog();
        }

        private void tsmTbl7_Click(object sender, EventArgs e)
        {
            (new FrmTbl7Edit()).ShowDialog();
        }

        private void tsmStatistic_Click(object sender, EventArgs e)
        {
            (new FrmStatistic()).ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            (new FrmDangNhap()).ShowDialog();
        }

        private void saoLưuDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string cap, mes;
            try
            {
                // Tạo đường dẫn.
                VNTCode.Controller oCtl = new VNTSellGold.App_Code.Controller();
                string sFullName = Application.StartupPath + "\\VNTSellGold.bak";
                // Kiểm tra tồn tại đường dẫn.
                if (System.IO.File.Exists(sFullName))
                    System.IO.File.Delete(sFullName);
                // Bắt đầu backup.
                oCtl.MtdBackupDatabase(sFullName);

                cap = global::VNTSellGold.Properties.Resources.CapSave;
                mes = global::VNTSellGold.Properties.Resources.MesBackup;
            }
            catch (Exception ex) {
                cap = global::VNTSellGold.Properties.Resources.CapError;
                mes = global::VNTSellGold.Properties.Resources.MesBackupError;
            }
            Cursor = Cursors.Default;
            MessageBox.Show(mes, cap, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
