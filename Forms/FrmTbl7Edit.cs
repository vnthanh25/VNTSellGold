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
using System.Globalization;

namespace VNTSellGold.Forms
{
    public partial class FrmTbl7Edit : Form
    {
        #region Members *****************************************
        // Controller.
        VNTSellGold.App_Code.Controller oCtrLer;
        int pageSize = 10;
        int pageCount = 0;
        bool isTbl6Load = false;
        bool isTbl7Load = false;
        #endregion Members -----------------------------------------

        #region Methods *****************************************
        void MtdCreateController()
        {
            if (oCtrLer == null)
            {
                oCtrLer = new VNTCode.Controller();
            }
        }

        #region Load
        void MtdLoadTbl3()
        {
            MtdCreateController();
            List<VNTCode.ClsTbl3> lstTbl3 = oCtrLer.Tbl3_Gets_Pair(lblUserName.Text);
            VNTSellGold.App_Code.ClsTbl3 oClsTbl3 = new VNTSellGold.App_Code.ClsTbl3();
            oClsTbl3.Id = 0;
            oClsTbl3.Name = "Chưa Giao";
            lstTbl3.Add(oClsTbl3);

            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = lstTbl3;
        }

        void MtdLoadTbl5()
        {
            MtdCreateController();
            List<VNTCode.Tbl5> lstTbl5 = oCtrLer.Tbl5_Gets_ByIdTbl3(Convert.ToInt32(comboBox1.SelectedValue.ToString()));
            listView2.Items.Clear();
            for (int i = 0; i < lstTbl5.Count; i++)
            {
                ListViewItem item = listView2.Items.Add("(" + lstTbl5[i].ICol3.ToString() + ") " + lstTbl5[i].Tbl1.SCol1 + " - " + lstTbl5[i].Tbl2.SCol1 + " - " + lstTbl5[i].ICol1.ToString());
                item.Name = lstTbl5[i].Id.ToString();
                item.ToolTipText = VNTCode.Controller.MtdDecimalToString(lstTbl5[i].MCol2.Value);
            }
        }

        void MtdLoadTbl61()
        {
            MtdCreateController();
            List<VNTCode.Tbl6> lstTbl6 = oCtrLer.Tbl6_Gets_ByIdTbl3(Convert.ToInt32(comboBox1.SelectedValue.ToString()));
            listView2.Items.Clear();
            for (int i = 0; i < lstTbl6.Count; i++)
            {
                ListViewItem item = listView2.Items.Add("(" + lstTbl6[i].Tbl5.ICol3.ToString() + ") " + lstTbl6[i].Tbl5.Tbl1.SCol1 + " - " + lstTbl6[i].Tbl5.Tbl2.SCol1 + " - " + lstTbl6[i].Tbl5.ICol1.ToString());
                item.Name = lstTbl6[i].Tbl5.Id.ToString();
                item.ToolTipText = lstTbl6[i].Tbl5.MCol2.ToString();
            }
        }

        void MtdLoadTbl7()
        {
            MtdCreateController();
            if (txtPageSize.Text != "")
                pageSize = int.Parse(txtPageSize.Text);
            int pageIndex = pageSize == -1 ? 0 : int.Parse(lblCurrentPage.Text) * pageSize;
            int idTbl3 = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            dataGridView1.DataSource = oCtrLer.Tbl7_Gets_OrderDesByCreateDate(pageIndex, pageSize, idTbl3);
            // Tính tổng số.
            lblTotal.Text = VNTCode.Controller.MtdIntToString(oCtrLer.Tbl7_Count_Sell(idTbl3));
            lblTotalICol1.Text = VNTCode.Controller.MtdIntToString(oCtrLer.Tbl5_SumICol1_Sell(idTbl3)) + " (ly)";
            lblTotalSell.Text = VNTCode.Controller.MtdDecimalToString(oCtrLer.Tbl7_SumMCol1(idTbl3)) + " (đ)";
            if (pageSize != -1)
                MtdGetPageCount();
        }

        void MtdGetPageCount()
        {
            MtdCreateController();
            if (txtPageSize.Text != "")
                pageSize = int.Parse(txtPageSize.Text);
            int count = 0;
            if(!string.IsNullOrEmpty(lblTotal.Text.Trim()))
                count = Convert.ToInt32(lblTotal.Text.Replace(".", "").Replace(",", ""));
            pageCount = count / pageSize;
            if (pageCount * pageSize < count)
                pageCount++;
        }
        #endregion Load End

        private void MtdEnter(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox txt = sender as TextBox;
                txt.SelectAll();
            }
            else if (sender is ComboBox)
            {
                ComboBox cbb = sender as ComboBox;
                cbb.DroppedDown = true;
            }
        }

        void MtdSave()
        {
            MtdCreateController();
            VNTCode.Tbl7 oTbl7 = new VNTCode.Tbl7();
            oTbl7.IdTbl4 = 1;
            oTbl7.IdTbl5 = Convert.ToInt32(listView2.SelectedItems[0].Name);
            oTbl7.MCol1 = Convert.ToDecimal(MtdDelDotAndComma(txtMCol1.Text.Trim()));
            oTbl7.SCol1 = txtSCol1.Text;
            oTbl7.DTCol1 = oCtrLer.MtdGetDate();
            oCtrLer.MemLinq.Tbl7s.InsertOnSubmit(oTbl7);
            // Cap nhat ngay ket thuc cho Tbl6.
            int idTbl3 = Convert.ToInt32(comboBox1.SelectedValue);
            oCtrLer.Tbl5_Update_Sell(oTbl7.IdTbl5.Value, idTbl3);
            //oCtrLer.MemLinq.Tbl5s.Where(tb5 => tb5.Id == oTbl7.IdTbl5).Single().ICol2 = idTbl3 == 0 ? 10 : 12;// 10 : chưa giao mới nhập; 12 : đã giao mới nhập.
            
            oCtrLer.MemLinq.SubmitChanges();
        }

        void MtdResetControlValues()
        {
            txtMCol1.Text = "0";
            txtIdTbl5.Text = txtSCol1.Text = "";
        }

        string MtdDelDotAndComma(string pNum)
        {
            if (pNum.Length > 0)
                pNum = pNum.Replace(".", "").Replace(",", "");
            else
                pNum = "0";
            return pNum;
        }

        string MtdNumToName(string pNum)
        {
            // Lưu tên gọi chính.
            string sTenChinh = "Không xác định";
            if (pNum.Length < 18)
            {
                // Lưu tên gọi gốc như Nghìn, triệu, tỉ.
                List<string> lstRootName = new List<string>();
                lstRootName.Add("");
                lstRootName.Add(" Nghìn");
                lstRootName.Add(" Triệu");
                lstRootName.Add(" Tỉ");
                lstRootName.Add(" Nghìn Tỉ");
                lstRootName.Add(" Triệu Tỉ");
                // Lấy tên gọi gốc từ chuỗi truyền vào.
                string sTenGoc = lstRootName[(pNum.Length - 1) / 3];
                switch (pNum.Length % 3)
                {
                    case 1:
                        {
                            sTenChinh = sTenGoc;
                            break;
                        }
                    case 2:
                        {
                            sTenChinh = "Chục" + sTenGoc;
                            break;
                        }
                    case 0:
                        {
                            sTenChinh = "Trăm" + sTenGoc;
                            break;
                        }
                }
            }
            return sTenChinh;
        }

        void MtdShowNumName(object sender)
        {
            string sTenGoi = "";
            TextBox txt = sender as TextBox;
            if (txt.Text.Trim() == "")
            {
                string cap = global::VNTSellGold.Properties.Resources.CapWar;
                string mes = global::VNTSellGold.Properties.Resources.MesNumEmpty;
                if (MessageBox.Show(mes, cap, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    txt.Text = "0";
                    sTenGoi = "Không";
                    this.GetNextControl(sender as Control, true).Focus();
                }
                else
                    txt.Focus();
            }
            else
            {
                sTenGoi = MtdNumToName(MtdDelDotAndComma(txt.Text));
                this.GetNextControl(sender as Control, true).Focus();
            }
            lblDVMCol1.Text = sTenGoi;
        }

        bool MtdAcceptNumber(KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b' && e.KeyChar != '\r')
            {
                // K chap nhan.
                e.Handled = true;
                return false;
            }
            return true;
        }
        #endregion Methods -----------------------------------------

        #region Dotnet Methods *****************************************
        public FrmTbl7Edit()
        {
            InitializeComponent();
        }

        private void FrmTbl7_Load(object sender, EventArgs e)
        {
            lblUserName.Text = "host";
            MtdCreateController();
            oCtrLer.Tbl5_Update_ICol2_Tbl7Edit();
            MtdLoadTbl3();
            //MtdLoadTbl6();
            //MtdLoadTbl7();
            comboBox1.Focus();
            comboBox1.DroppedDown = true;
            //txtIdTbl5.SelectAll();
            //txtIdTbl5.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MtdLoadTbl5();
            MtdLoadTbl7();
        }

        private void txtMCol1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (MtdAcceptNumber(e))
            {
                if (e.KeyChar == '\r')
                {
                    TextBox txt = sender as TextBox;
                    string s = MtdDelDotAndComma(txt.Text);
                    lblDVMCol1.Text = MtdNumToName(s);
                    txt.Text = VNTCode.Controller.MtdDecimalToString(Convert.ToDecimal(s));
                    this.GetNextControl(sender as Control, true).Focus();
                }
            }
        }

        private void txtMCol1_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            MtdShowNumName(txt);
            txt.Text = VNTCode.Controller.MtdDecimalToString(Convert.ToDecimal(MtdDelDotAndComma(txt.Text)));
        }

        private void txtSCol1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                this.GetNextControl(sender as Control, true).Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0)
            {
                string cap = global::VNTSellGold.Properties.Resources.CapWar;
                string mes = global::VNTSellGold.Properties.Resources.MesNotFound;
                MessageBox.Show(mes, cap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MtdSave();
                MtdResetControlValues();
                MtdLoadTbl5();
                MtdLoadTbl7();
                comboBox1.Focus();
                comboBox1.DroppedDown = true;
                //txtIdTbl5.Focus();
            }
        }

        private void txtIdTbl5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (MtdAcceptNumber(e))
            {
                if (e.KeyChar == '\r')
                {
                    int i;
                    // UnSelect ListView.
                    for (i = 0; i < listView2.SelectedItems.Count; i++)
                        listView2.SelectedItems[i].Selected = false;
                    // Loai bo khoang trang trong txtIdTbl5.
                    txtIdTbl5.Text = txtIdTbl5.Text.Trim();
                    // Tim IdTbl5 trong ListView.
                    for (i = 0; i < listView2.Items.Count; i++)
                        if (txtIdTbl5.Text.Trim() == listView2.Items[i].Text.Substring(1, listView2.Items[i].Text.IndexOf(")") - 1))
                        {
                            listView2.Select();
                            listView2.Items[i].Selected = true;
                            listView2.Refresh();
                            break;
                        }
                    // Neu khong tim thay thi y/c nhap lai.
                    if (i == listView2.Items.Count)
                    {
                        string cap = global::VNTSellGold.Properties.Resources.CapWar;
                        string mes = global::VNTSellGold.Properties.Resources.MesNotFound;
                        MessageBox.Show(mes, cap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtIdTbl5.SelectAll();
                        txtIdTbl5.Focus();
                    }
                    else
                    {
                        txtMCol1.SelectAll();
                        txtMCol1.Focus();
                    }
                }
            }
        }
        #endregion Dotnet Methods -----------------------------------------

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lstView = sender as ListView;
            if (lstView.SelectedItems.Count > 0)
            {
                //txtMCol1.Focus();
                MtdShowNumName(txtMCol1);
                txtMCol1.Text = VNTCode.Controller.MtdDecimalToString(Convert.ToDecimal(MtdDelDotAndComma(lstView.SelectedItems[0].ToolTipText)));
                txtMCol1.SelectAll();
            }
        }

        private void linkDau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblCurrentPage.Text = "0";
            MtdLoadTbl7();
        }

        private void linkTruoc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int currentPage = int.Parse(lblCurrentPage.Text);
            if (currentPage > 0)
                currentPage--;
            lblCurrentPage.Text = currentPage.ToString();
            MtdLoadTbl7();
        }

        private void linkSau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int currentPage = int.Parse(lblCurrentPage.Text);
            if (currentPage < pageCount - 1)
                currentPage++;
            lblCurrentPage.Text = currentPage.ToString();
            MtdLoadTbl7();
        }

        private void linkCuoi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int currentPage = pageCount - 1;
            lblCurrentPage.Text = currentPage.ToString();
            MtdLoadTbl7();
        }

        private void linkTatCa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sPageIndex = lblCurrentPage.Text;
            string sPageSize = txtPageSize.Text;
            // Select All.
            lblCurrentPage.Text = "0";
            txtPageSize.Text = "-1";
            MtdLoadTbl7();
            lblCurrentPage.Text = sPageIndex;
            txtPageSize.Text = sPageSize;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.GetNextControl(sender as Control, true).Focus();
            }
        }

        private void FrmTbl7Edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            oCtrLer.Tbl5_Update_ICol2_Tbl7Edit();
        }
    }
}
