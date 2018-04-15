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
    public partial class FrmTbl5Edit : Form
    {
        #region Members *****************************************
        // Controller.
        VNTSellGold.App_Code.Controller oCtrLer;
        // Store columns name which is checked empty.
        List<string> lstCheckColumn = new List<string>();
        // Lưu tên gọi gốc như Nghìn, triệu, tỉ.
        List<string> lstRootName;

        int pageSize = 10;
        int pageCount = 0;
        #endregion Members -----------------------------------------

        #region Methods *****************************************
        #region Xu ly so nhap vao.
        string MtdNumToName(string pNum)
        {
            // Lưu tên gọi chính.
            string sTenChinh = "Không xác định";
            if (pNum.Length > 0 && pNum.Length < 18)
            {
                MtdCreateRootName();
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

        string MtdGoldToName(string pNum)
        {
            // Lưu tên gọi chính.
            string sTenChinh = "Không xác định";
            if (pNum.Length > 0 && pNum.Length < 18)
            {
                //MtdCreateGoldName();
                switch (pNum.Length)
                {
                    case 1:
                        {
                            sTenChinh = "Ly";
                            break;
                        }
                    case 2:
                        {
                            sTenChinh = "Phân";
                            break;
                        }
                    case 3:
                        {
                            sTenChinh = "Chỉ";
                            break;
                        }
                    default:
                        {
                            sTenChinh = "Lượng";
                            sTenChinh = MtdNumToName(pNum.Substring(0, pNum.Length - 3)) + " " + sTenChinh;
                            break;
                        }
                }
            }
            return sTenChinh;
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
                string s = MtdDelDotAndComma(txt.Text);
                if (txt.Name == "txtICol1")
                {
                    sTenGoi = MtdGoldToName(s);
                    txt.Text = VNTCode.Controller.MtdIntToString(Convert.ToInt32(s));
                }
                else
                {
                    sTenGoi = MtdNumToName(s);
                    txt.Text = VNTCode.Controller.MtdDecimalToString(Convert.ToDecimal(s));
                }
                this.GetNextControl(sender as Control, true).Focus();
            }
            //if (sTenGoi != "")
            {
                // Tuy theo textbox nao ma dat label ten goi ten ung.
                switch (txt.Name)
                {
                    case "txtICol1":
                        {
                            lblDVICol1.Text = sTenGoi;
                            break;
                        }
                    case "txtMCol1":
                        {
                            lblDVMCol1.Text = sTenGoi;
                            break;
                        }
                    case "txtMCol2":
                        {
                            lblDVMCol2.Text = sTenGoi;
                            break;
                        }
                }
            }// if sTenGoi   
        }

        string MtdDelDotAndComma(string pNum)
        {
            if (pNum.Length > 0)
                pNum = pNum.Replace(".", "").Replace(",", "");
            return pNum;
        }

        void MtdCreateRootName()
        {
            if (lstRootName == null)
            {
                lstRootName = new List<string>();
                lstRootName.Add("");
                lstRootName.Add(" Nghìn");
                lstRootName.Add(" Triệu");
                lstRootName.Add(" Tỉ");
                lstRootName.Add(" Nghìn Tỉ");
                lstRootName.Add(" Triệu Tỉ");
            }
        }

        void MtdKeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox)
            {
                if (MtdAcceptNumber(e))
                {
                    if (e.KeyChar == '\r')
                    {
                        MtdShowNumName(sender);
                    }// if e.Keychar
                }// if MtdAccept
            }// if sender
            else if (sender is ComboBox)
            {
                if (e.KeyChar == '\r')
                {
                    this.GetNextControl(sender as Control, true).Focus();
                }
            }
        }

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
        #endregion Xu ly so nhap vao. End

        #region Xu ly phan trang.
        void MtdCreateController()
        {
            if (oCtrLer == null)
            {
                oCtrLer = new VNTCode.Controller();
            }
        }

        void MtdGetPageCount()
        {
            MtdCreateController();
            if (txtPageSize.Text != "")
                pageSize = int.Parse(txtPageSize.Text);
            //int count = oCtrLer.Tbl5_Gets_OrderDesByCreateDate_Count(Convert.ToInt32(cbbTbl3.SelectedValue));
            int count = 0;
            if(!string.IsNullOrEmpty(lblTotal.Text.Trim()))
                count = Convert.ToInt32(lblTotal.Text.Replace(".", "").Replace(",", ""));
            //(from t5s in oCtrLer.MemLinq.Tbl5s
            // select t5s).Count();
            pageCount = count / pageSize;
            if (pageCount * pageSize < count)
                pageCount++;
        }
        #endregion Xu ly phan trang. End

        #region Load Data
        void MtdLoadTbl1()
        {
            MtdCreateController();
            List<VNTCode.Tbl1> lstTbl1 = oCtrLer.Tbl1_Gets_OrderBySCol1();
                //(from tbl1s in oCtrLer.MemLinq.Tbl1s
                // select tbl1s).OrderBy(t1 => t1.SCol1).ToList();
            ddlTbl1.DataSource = lstTbl1;
        }

        void MtdLoadTbl2()
        {
            MtdCreateController();
            List<VNTCode.Tbl2> lstTbl2 = oCtrLer.Tbl2_Gets_OrderBySCol1();
                //(from tbl2s in oCtrLer.MemLinq.Tbl2s
                // select tbl2s).OrderBy(t2 => t2.SCol1).ToList();
            ddlTbl2.DataSource = lstTbl2;
            //ddlTbl2.SelectedIndex = 0;
        }

        void MtdLoadTbl3()
        {
            MtdCreateController();
            List<VNTCode.ClsTbl3> lstTbl3 = oCtrLer.Tbl3_Gets_Pair(lblUserName.Text);
            VNTSellGold.App_Code.ClsTbl3 oClsTbl3 = new VNTSellGold.App_Code.ClsTbl3();
            oClsTbl3.Id = 0;
            oClsTbl3.Name = "Chưa Giao";
            lstTbl3.Add(oClsTbl3);

            cbbTbl3.DisplayMember = "Name";
            cbbTbl3.ValueMember = "Id";
            cbbTbl3.DataSource = lstTbl3;
        }
        /// <summary>
        /// * Tham số truyền vào lấy từ txtPageSize.Text, lblCurrentPage.Text, cbbTbl3.SelectedValue.
        /// </summary>
        /// <returns></returns>
        List<VNTCode.ClsTbl14Col> MtdTbl5Gets()
        {
            MtdCreateController();
            if (txtPageSize.Text != "")
                pageSize = int.Parse(txtPageSize.Text);
            int pageIndex = pageSize == -1 ? 0 : int.Parse(lblCurrentPage.Text) * pageSize;
            return oCtrLer.Tbl5_Gets_OrderDesByCreateDate(pageIndex, pageSize, Convert.ToInt32(cbbTbl3.SelectedValue));
        }

        void MtdLoadTbl5()
        {
            dataGridView1.DataSource = MtdTbl5Gets();
            MtdUnSelect();

            lblTotal.Text = VNTCode.Controller.MtdIntToString(oCtrLer.Tbl5_Gets_OrderDesByCreateDate_Count(Convert.ToInt32(cbbTbl3.SelectedValue)));
            lblNewCount.Text = VNTCode.Controller.MtdIntToString(oCtrLer.Tbl5_Gets_OrderDesByCreateDate_NewCount(Convert.ToInt32(cbbTbl3.SelectedValue)));
            lblTotalICol1.Text = VNTCode.Controller.MtdIntToString(oCtrLer.Tbl5_SumICol1(Convert.ToInt32(cbbTbl3.SelectedValue))) + " (ly)";
            lblNewICol1.Text = VNTCode.Controller.MtdIntToString(oCtrLer.Tbl5_SumICol1_New(Convert.ToInt32(cbbTbl3.SelectedValue))) + " (ly)";

            if (pageSize != -1)
                MtdGetPageCount();
        }

        bool MtdSelectRow(string pICol3)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Col2"].Value.ToString() == pICol3)
                {
                    row.Selected = true;
                    MtdSetControlValues(row);
                    cbbTbl3.Focus();
                    return true;
                }
            }
            return false;
        }

        void MtdUnSelect()
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                dataGridView1.SelectedRows[i].Selected = false;
        }
        #endregion Load Data

        #region Xu ly Cap nhat.
        bool MtdCheckValid()
        {
            string cap = global::VNTSellGold.Properties.Resources.CapWar;
            // Khong co thong bao thi ket qua la true.
            bool kq = true;
            string mes = "";
            if (txtICol1.Text.Trim() == "")
            {
                mes += lblICol1.Text + " ,";
            }
            if (txtMCol1.Text.Trim() == "")
            {
                mes += lblMCol1.Text + " ,";
            }
            if (txtMCol2.Text.Trim() == "")
            {
                mes += lblMCol2.Text + " ,";
            }
            if (mes != "")
            {
                // Co thong bao thi ket qua la false.
                kq = false;
                mes = mes.Remove(mes.Length - 2) + " : ";
                mes += global::VNTSellGold.Properties.Resources.MesNumEmpty;
                if (MessageBox.Show(mes, cap, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (mes.Contains(lblMCol2.Text))
                        txtMCol2.Text = "0";
                    if (mes.Contains(lblMCol1.Text))
                        txtMCol1.Text = "0";
                    if (mes.Contains(lblICol1.Text))
                        txtICol1.Text = "0";
                    // Chap nhan thay the thi ket qua la true.
                    kq = true;
                }
            }
            return kq;
        }

        void MtdGetControlValues(ref VNTCode.Tbl5 pTbl5)
        {
            pTbl5.IdTbl1 = Convert.ToInt32(ddlTbl1.SelectedValue);
            pTbl5.IdTbl2 = Convert.ToInt32(ddlTbl2.SelectedValue);
            pTbl5.ICol1 = Convert.ToInt32(MtdDelDotAndComma(txtICol1.Text.Trim()));
            pTbl5.MCol1 = Convert.ToDecimal(MtdDelDotAndComma(txtMCol1.Text.Trim()));
            pTbl5.MCol2 = Convert.ToDecimal(MtdDelDotAndComma(txtMCol2.Text.Trim()));
            pTbl5.SCol1 = txtSCol1.Text.Trim();
            pTbl5.SCol2 = txtSCol2.Text.Trim();
        }

        void MtdSetControlValues(VNTCode.Tbl5 pTbl5)
        {
            lblId.Text = pTbl5.Id.ToString();
            lblICol3.Text = txtICol3.Text = pTbl5.ICol3.ToString();
            cbbTbl3.SelectedValue = 0;
            VNTCode.Tbl6 oTbl6 = pTbl5.Tbl6s.Where(tbl6 => tbl6.DTCol2.Value == null).FirstOrDefault();
            if (oTbl6 != null)
                cbbTbl3.SelectedValue = oTbl6.IdTbl3;
            ddlTbl1.SelectedValue = pTbl5.IdTbl1;
            ddlTbl2.SelectedValue = pTbl5.IdTbl2;
            txtICol1.Text = VNTCode.Controller.MtdIntToString(pTbl5.ICol1.Value);
            txtMCol1.Text = VNTCode.Controller.MtdDecimalToString(pTbl5.MCol1.Value);
            txtMCol2.Text = VNTCode.Controller.MtdDecimalToString(pTbl5.MCol2.Value);
            txtSCol1.Text = pTbl5.SCol1;
            txtSCol2.Text = pTbl5.SCol2;
            // Chuyen doi ten.
            MtdShowNumName(txtICol1);
            MtdShowNumName(txtMCol1);
            MtdShowNumName(txtMCol2);
        }

        void MtdSetControlValues(DataGridViewRow pRow)
        {
            lblId.Text = pRow.Cells["Col1"].Value.ToString();
            lblICol3.Text = txtICol3.Text = pRow.Cells["Col2"].Value.ToString();
            //cbbTbl3.SelectedValue = Convert.ToInt32(pRow.Cells["Col14"].Value.ToString());
            ddlTbl1.SelectedValue = Convert.ToInt32(pRow.Cells["Col3"].Value.ToString());
            ddlTbl2.SelectedValue = Convert.ToInt32(pRow.Cells["Col4"].Value.ToString());
            txtICol1.Text = pRow.Cells["Col7"].Value.ToString();
            // Xoa dau "." hoac "," trong gia tri MCol1.
            //txtMCol1.Text = MtdDelDotAndComma(pRow.Cells["Col8"].Value.ToString());
            txtMCol1.Text = pRow.Cells["Col8"].Value.ToString();
            // Xoa dau "." hoac "," trong gia tri MCol2.
            //txtMCol2.Text = MtdDelDotAndComma(pRow.Cells["Col9"].Value.ToString());
            txtMCol2.Text = pRow.Cells["Col9"].Value.ToString();

            txtSCol1.Text = pRow.Cells["Col10"].Value.ToString();
            txtSCol2.Text = pRow.Cells["Col13"].Value.ToString();
            // Chuyen doi ten.
            MtdShowNumName(txtICol1);
            MtdShowNumName(txtMCol1);
            MtdShowNumName(txtMCol2);
        }

        void MtdResetControlValues()
        {
            lblId.Text = lblICol3.Text = txtICol3.Text = txtICol1.Text = txtMCol1.Text = txtMCol2.Text = "0";
            //lblNewICol1.Text = lblTotalICol1.Text = lblNewCount.Text = lblTotal.Text = "0";
            lblDVICol1.Text = "Ly";
            lblDVMCol1.Text = lblDVMCol2.Text = "(đ)";
            txtSCol1.Text = "";
            txtSCol2.Text = "";
        }

        bool MtdSave()
        {
            if (MtdCheckValid())
            {
                //int idxDdl2 = ddlTbl2.SelectedIndex;
                MtdCreateController();
                VNTCode.Tbl5 oTbl5;
                VNTCode.Tbl6 oTbl6;
                DateTime dt = oCtrLer.MtdGetDate();
                int idTbl3 = Convert.ToInt32(cbbTbl3.SelectedValue);
                // Tao moi.
                if (lblId.Text == "0")
                {
                    int iCol3 = oCtrLer.Tbl5_Get_ICol3();
                    // Nếu tất cả mã số đã sử dụng thì thoát.
                    if (iCol3 == -1)
                    {
                        string cap = global::VNTSellGold.Properties.Resources.CapError;
                        string mes = global::VNTSellGold.Properties.Resources.MesICol3Full;
                        MessageBox.Show(mes, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    oTbl5 = new VNTCode.Tbl5();
                    oTbl5.ICol2 = idTbl3 == 0 ? 0 : 2;// 0 : mới nhập chưa giao; 2 : mới nhập đã giao.
                    oTbl5.ICol3 = iCol3;
                    MtdGetControlValues(ref oTbl5);
                    oTbl5.CreateDate = dt;
                    oTbl5.ModifyDate = oTbl5.CreateDate;
                    oTbl5.CreateBy = lblUserName.Text;
                    oTbl5.ModifyBy = lblUserName.Text;
                    // Insert Tbl6 Khi co chọn nhan viên.
                    if (idTbl3 > 0)
                    {
                        oTbl6 = new VNTCode.Tbl6();
                        oTbl6.IdTbl3 = idTbl3;
                        oTbl6.DTCol1 = dt;
                        oTbl5.Tbl6s.Add(oTbl6);
                    }
                    //oCtrLer.MemLinq.Tbl6s.InsertOnSubmit(oTbl6);
                    oCtrLer.MemLinq.Tbl5s.InsertOnSubmit(oTbl5);
                }
                // Cap nhat. Không cập nhật tình trạng đã giao hay chưa.
                else
                {
                    oTbl5 = oCtrLer.Tbl5_Get_ById(Convert.ToInt32(lblId.Text));
                    MtdGetControlValues(ref oTbl5);

                    //// Chưa giao -> Giao : chưa giao mới nhập -> đã giao mới nhập || chưa giao -> đã giữ.
                    //// Đã giao -> Giao cho người khác : Trạng thái giữ nguyên.
                    //// Đã giao -> Không giao : đã giao mới nhập -> chưa giao mới nhập || đã giữ -> chưa giao.
                    //// Get Tbl6.
                    //oTbl6 = oTbl5.Tbl6s.Where(tbl6 => tbl6.DTCol2 == null).FirstOrDefault();
                    //// Nếu chưa có trong Tbl6 (Chưa giao) Mà có giao thì insert moi.
                    //if (oTbl6 == null && idTbl3 > 0)
                    //{
                    //    oTbl5.ICol2 += 2;// Đã giao (mới nhập).
                    //    // Inset vao Tbl6.
                    //    oTbl6 = new VNTCode.Tbl6();
                    //    oTbl6.IdTbl3 = idTbl3;
                    //    oTbl6.DTCol1 = dt;
                    //    oTbl5.Tbl6s.Add(oTbl6);
                    //}
                    //// Nếu co trong Tbl6 (Đã giao).
                    //else
                    //{
                    //    if (idTbl3 > 0) // Có giao cho ai đó.
                    //    {
                    //        oTbl6.IdTbl3 = idTbl3;
                    //    }
                    //    else // Đã giao bây giờ không giao.
                    //    {
                    //        oTbl5.ICol2 -= 2;// Chưa giao (mới nhập).
                    //        oTbl6.DTCol2 = dt;
                    //    }
                    //}
                    oTbl5.ModifyDate = dt;
                    oTbl5.ModifyBy = lblUserName.Text;
                }

                oCtrLer.MemLinq.SubmitChanges();
                return true;
            }
            return false;
        }
        #endregion Xu ly Cap nhat. End

        bool MtdFindICol3()
        {
            string sICol3 = txtICol3.Text;
            bool bFound = MtdSelectRow(txtICol3.Text);
            //Nếu không có ở trang hiện tại và Nếu không phải hiển thị tất cả và số trang lớn hơn 1. Thì tìm tiếp ở tất cả các trang khác.
            if (!bFound && dataGridView1.Rows.Count <= pageSize && pageCount > 1)
            {
                string sCurrentPage = lblCurrentPage.Text;
                lblCurrentPage.Text = "0";
                for (int i = 0; i < pageCount; i++)
                {
                    if (i.ToString() != sCurrentPage)
                    {
                        lblCurrentPage.Text = i.ToString();
                        if (txtPageSize.Text != "")
                            pageSize = int.Parse(txtPageSize.Text);
                        int pageIndex = pageSize == -1 ? 0 : int.Parse(lblCurrentPage.Text) * pageSize;
                        MtdCreateController();
                        List<int> lstTbl5ICol3 = oCtrLer.Tbl5_Gets_ICol3_OrderDesByCreateDate(pageIndex, pageSize, Convert.ToInt32(cbbTbl3.SelectedValue));
                        // Nếu tìm thấy trong trang kế tiếp thì load lên DataGridView.
                        if (lstTbl5ICol3.Contains(Convert.ToInt32(txtICol3.Text)))
                        {
                            MtdLoadTbl5();
                            MtdSelectRow(txtICol3.Text);
                            bFound = true;
                            break;
                        }
                    }
                }
            }
            if (!bFound)
            {
                string cap = global::VNTSellGold.Properties.Resources.CapWar;
                string mes = global::VNTSellGold.Properties.Resources.MesFoundAgaint;
                if (MessageBox.Show(mes, cap, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    //txtICol3.Text = sICol3;
                    txtICol3.Focus();
                }
                else
                    txtICol3.Text = lblICol3.Text;
                txtICol3.SelectAll();
            }
            return bFound;
        }

        #endregion Methods -----------------------------------------

        #region Dotnet Methods *****************************************
        public FrmTbl5Edit()
        {
            InitializeComponent();

        }

        private void FrmTbl5Edit_Load(object sender, EventArgs e)
        {
            lblUserName.Text = "host";
            string sPageSize = global::VNTSellGold.Properties.Resources.PageSize;
            if (!string.IsNullOrEmpty(sPageSize))
            {
                txtPageSize.Text = global::VNTSellGold.Properties.Resources.PageSize;
                pageSize = Convert.ToInt32(sPageSize);
            }
            MtdCreateController();
            oCtrLer.Tbl5_Update_ICol2_Tbl5Edit();
            MtdLoadTbl1();
            MtdLoadTbl2();
            MtdLoadTbl3();
            //MtdLoadTbl5();
            //MtdResetControlValues();
        }

        private void ICol1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void MCol1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MtdKeyPress(sender, e);
        }

        private void MCol2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPageSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            MtdAcceptNumber(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MtdSave())
            {
                lblCurrentPage.Text = "0";
                MtdLoadTbl5();
                MtdResetControlValues();

                string cap = global::VNTSellGold.Properties.Resources.CapSave;
                string mes = global::VNTSellGold.Properties.Resources.MesSaveOk;
                MessageBox.Show(mes, cap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Nhảy tới control chọn người.
                cbbTbl3.Focus();
                cbbTbl3.DroppedDown = true;
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (lblId.Text != "0")
            {
                MtdCreateController();
                VNTCode.Tbl5 oTbl5 = oCtrLer.MemLinq.Tbl5s.Where(t5 => t5.Id.ToString() == lblId.Text).FirstOrDefault();
                if (oTbl5 != null)
                    oCtrLer.MemLinq.Tbl5s.DeleteOnSubmit(oTbl5);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MtdResetControlValues();
            MtdUnSelect();
        }

        private void linkDau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblCurrentPage.Text = "0";
            MtdLoadTbl5();
        }

        private void linkTruoc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int currentPage = int.Parse(lblCurrentPage.Text);
            if (currentPage > 0)
                currentPage--;
            lblCurrentPage.Text = currentPage.ToString();
            MtdLoadTbl5();
        }

        private void linkSau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int currentPage = int.Parse(lblCurrentPage.Text);
            if (currentPage < pageCount - 1)
                currentPage++;
            lblCurrentPage.Text = currentPage.ToString();
            MtdLoadTbl5();
        }

        private void linkCuoi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int currentPage = pageCount - 1;
            lblCurrentPage.Text = currentPage.ToString();
            MtdLoadTbl5();
        }

        private void linkTatCa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sPageIndex = lblCurrentPage.Text;
            string sPageSize = txtPageSize.Text;
            // Select All.
            lblCurrentPage.Text = "0";
            txtPageSize.Text = "-1";
            MtdLoadTbl5();
            lblCurrentPage.Text = sPageIndex;
            txtPageSize.Text = sPageSize;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lblId.Text != "0")
            {
                string cap = global::VNTSellGold.Properties.Resources.CapWar;
                string mes = global::VNTSellGold.Properties.Resources.MesDelete;
                mes = "Mã số : " + txtICol3.Text + ". " + mes;
                if (MessageBox.Show(mes, cap, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    MtdCreateController();
                    VNTCode.Tbl5 oTbl5 = oCtrLer.MemLinq.Tbl5s.Where(t5 => t5.Id.ToString() == lblId.Text).FirstOrDefault();
                    if (oTbl5 != null)
                    {
                        oCtrLer.MemLinq.Tbl6s.DeleteAllOnSubmit(oTbl5.Tbl6s);
                        oCtrLer.MemLinq.Tbl5s.DeleteOnSubmit(oTbl5);
                        oCtrLer.MemLinq.SubmitChanges();
                        MtdLoadTbl5();
                    }
                    MtdResetControlValues();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.SelectedRows.Count > 0)
            {
                MtdSetControlValues(dgv.SelectedRows[0]);
                // Nhảy tới control chọn người.
                cbbTbl3.Focus();
                cbbTbl3.DroppedDown = true;

                //VNTCode.Tbl5 oTbl5 = oCtrLer.MemLinq.Tbl5s.Where(t5 => t5.Id.ToString() == lblId.Text).FirstOrDefault();
                //if (oTbl5 != null)
                //{
                //    MtdSetControlValues(oTbl5);
                //}
            }
        }

        private void txtICol3_KeyPress(object sender, KeyPressEventArgs e)
        {
            MtdAcceptNumber(e);
            if (e.KeyChar == '\r')
            {
                MtdFindICol3();
            }
        }

        private void cbbTbl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            MtdLoadTbl5();
            MtdResetControlValues();
        }

        private void FrmTbl5Edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            MtdCreateController();
            oCtrLer.Tbl5_Update_ICol2_Tbl5Edit();
        }
        #endregion Dotnet Methods -----------------------------------------

        private void txtICol3_Leave(object sender, EventArgs e)
        {
            txtICol3.Text = lblICol3.Text;
        }
    }
}
