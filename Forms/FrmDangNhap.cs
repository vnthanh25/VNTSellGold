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
    public partial class FrmDangNhap : Form
    {
        #region Members *****************************************
        // Controller.
        VNTSellGold.App_Code.Controller oCtrLer;
        bool bValid = false;

        #endregion Members -----------------------------------------

        void MtdLoadTbl3()
        {
            MtdCreateController();
            List<VNTCode.ClsTbl3> lstTbl3 = oCtrLer.Tbl3_Gets_Pair("");
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = lstTbl3;
        }


        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            MtdLoadTbl3();
            comboBox1.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            MtdCreateController();
            bValid = oCtrLer.Tbl3_Check_SCol1(Convert.ToInt32(comboBox1.SelectedValue), txtMatKhau.Text);
            if (bValid)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("- Tên đăng nhập hoặc mật khẩu không đúng.\r\n- Vui lòng nhập lại", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
            }
        }

        void MtdCreateController()
        {
            if (oCtrLer == null)
            {
                oCtrLer = new VNTCode.Controller();
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                btnDangNhap_Click(sender, new EventArgs());
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtMatKhau.Focus();
                txtMatKhau.SelectAll();
            }
        }

        private void FrmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!bValid)
                Application.Exit();
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }
    }
}
