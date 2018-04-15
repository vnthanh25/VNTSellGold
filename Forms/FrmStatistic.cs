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
    public partial class FrmStatistic : Form
    {
        #region Members *****************************************
        // Controller.
        VNTSellGold.App_Code.Controller oCtrLer;
        int pageSize = 10;
        int pageCount = 0;
        string sDateName;
        #endregion Members -----------------------------------------

        #region Methods *****************************************
        void MtdCreateController()
        {
            if (oCtrLer == null)
            {
                oCtrLer = new VNTCode.Controller();
            }
        }

        string MtdDelDotAndComma(string pNum)
        {
            if (pNum.Length > 0)
                pNum = pNum.Replace(".", "").Replace(",", "");
            else
                pNum = "0";
            return pNum;
        }
     
        void MtdKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if ((sender as Control).Name == "comboBox2" && !dateTimePicker1.Enabled)
                    comboBox3.Focus();
                else
                    this.GetNextControl(sender as Control, true).Focus();
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

        #region Load
        void MtdGetPageCount()
        {
            MtdCreateController();
            int count = 0;
            if (txtPageSize.Text != "")
                pageSize = int.Parse(txtPageSize.Text);
            int pageIndex = pageSize == -1 ? 0 : int.Parse(lblCurrentPage.Text) * pageSize;
            bool bAll = comboBox2.SelectedIndex == comboBox2.Items.Count - 1;
            count = Convert.ToInt32(MtdDelDotAndComma(lblTotal.Text));
            pageCount = count / pageSize;
            if (pageCount * pageSize < count)
                pageCount++;
        }

        void MtdLoadTbl1()
        {
            MtdCreateController();
            List<VNTCode.Tbl1> lstTbl1 = oCtrLer.Tbl1_Gets_OrderBySCol1();
            VNTSellGold.App_Code.Tbl1 oTbl1 = new VNTSellGold.App_Code.Tbl1();
            oTbl1.Id = 0;
            oTbl1.SCol1 = "Tất cả";
            lstTbl1.Insert(0, oTbl1);
            ddlTbl1.DataSource = lstTbl1;
        }

        void MtdLoadTbl2()
        {
            MtdCreateController();
            List<VNTCode.Tbl2> lstTbl2 = oCtrLer.Tbl2_Gets_OrderBySCol1();
            VNTSellGold.App_Code.Tbl2 oTbl2 = new VNTSellGold.App_Code.Tbl2();
            oTbl2.Id = 0;
            oTbl2.SCol1 = "Tất cả";
            lstTbl2.Insert(0, oTbl2);
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

            oClsTbl3 = new VNTSellGold.App_Code.ClsTbl3();
            oClsTbl3.Id = -1;
            oClsTbl3.Name = "Tất cả";
            lstTbl3.Add(oClsTbl3);
            
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = lstTbl3;
        }

        void MtdLoadDate()
        {
            List<string> lstDate = new List<string>();
            lstDate.Add("Ngày");
            lstDate.Add("Tháng");
            lstDate.Add("Năm");
            lstDate.Add("Tất cả");

            comboBox2.DataSource = lstDate;
        }

        void MtdLoadState()
        {
            List<string> lstState = new List<string>();
            lstState.Add("Đang Giữ");
            lstState.Add("Đã Bán");

            comboBox3.DataSource = lstState;
        }

        void MtdLoadTbl6Tbl7()
        {
            MtdCreateController();
            if (txtPageSize.Text != "")
                pageSize = int.Parse(txtPageSize.Text);
            int pageIndex = pageSize == -1 ? 0 : int.Parse(lblCurrentPage.Text) * pageSize;
            
            bool bAll = comboBox2.SelectedIndex == comboBox2.Items.Count - 1;
            int idTbl1 = Convert.ToInt32(ddlTbl1.SelectedValue);
            int idTbl2 = Convert.ToInt32(ddlTbl2.SelectedValue);
            int idTbl3 = Convert.ToInt32(comboBox1.SelectedValue);
            if (comboBox3.SelectedIndex == 0)
            {
                dataGridView1.DataSource = oCtrLer.Tbl6_Gets_DesCreateDate(pageIndex, pageSize, idTbl1, idTbl2, idTbl3, bAll, dateTimePicker1.Value, dateTimePicker2.Value);
                if (idTbl3 == -1)
                    sDateName = "Ngày Giao/Nhập";
                else if(idTbl3 == 0)
                    sDateName = "Ngày Nhập";
                else
                    sDateName = "Ngày Giao";

                dataGridView1.Columns["Col6"].HeaderText = "Tiền Mua Vào";
                dataGridView1.Columns["Col6"].Visible = false;
                dataGridView1.Columns["Col7"].HeaderText = sDateName;

                lblTotal.Text = VNTCode.Controller.MtdIntToString(oCtrLer.Tbl6_Gets_DesCreateDate_Count(idTbl1, idTbl2, idTbl3, bAll, dateTimePicker1.Value, dateTimePicker2.Value));
                lblTotalICol1.Text = VNTCode.Controller.MtdIntToString(oCtrLer.Tbl6_Gets_DesCreateDate_ICol1(idTbl1, idTbl2, idTbl3, bAll, dateTimePicker1.Value, dateTimePicker2.Value)) + " (ly)";
                lblTotalSell.Text = "0 (đ)";
                //lblTotalSell.Text = VNTCode.Controller.MtdDecimalToString(oCtrLer.Tbl6_Gets_DesCreateDate_ICol1_Sell(idTbl1, idTbl2, idTbl3, bAll, dateTimePicker1.Value, dateTimePicker2.Value)) + " (đ)";
            }
            else
            {
                dataGridView1.DataSource = oCtrLer.Tbl7_Gets_DesCreateDate(pageIndex, pageSize, idTbl1, idTbl2, idTbl3, bAll, dateTimePicker1.Value, dateTimePicker2.Value);
                dataGridView1.Columns["Col6"].HeaderText = "Tiền Bán Ra";
                dataGridView1.Columns["Col6"].Visible = true;
                sDateName = "Ngày Bán";
                dataGridView1.Columns["Col7"].HeaderText = sDateName;

                lblTotal.Text = VNTCode.Controller.MtdIntToString(oCtrLer.Tbl7_Gets_DesCreateDate_Count(idTbl1, idTbl2, idTbl3, bAll, dateTimePicker1.Value, dateTimePicker2.Value));
                lblTotalICol1.Text = VNTCode.Controller.MtdIntToString(oCtrLer.Tbl7_Gets_DesCreateDate_ICol1(idTbl1, idTbl2, idTbl3, bAll, dateTimePicker1.Value, dateTimePicker2.Value)) + " (ly)";
                lblTotalSell.Text = VNTCode.Controller.MtdDecimalToString(oCtrLer.Tbl7_Gets_DesCreateDate_Sell(idTbl1, idTbl2, idTbl3, bAll, dateTimePicker1.Value, dateTimePicker2.Value)) + " (đ)";
            }
            if (pageSize != -1)
                MtdGetPageCount();
        }
        #endregion Load

        #endregion Methods -----------------------------------------

        #region Dotnet Methods *****************************************
        public FrmStatistic()
        {
            InitializeComponent();
        }

        private void FrmStatistic_Load(object sender, EventArgs e)
        {
            lblUserName.Text = "host";
            MtdCreateController();
            // Load thống kê chung.
            lblTotalICol1_Buy.Text = VNTCode.Controller.MtdIntToString(oCtrLer.Tbl5_SumICol1_Buy()) + " (ly)";
            lblTotalICol1_Sell.Text = VNTCode.Controller.MtdIntToString(oCtrLer.Tbl5_SumICol1_Sell()) + " (ly)";
            lblTotalSell_Buy.Text = VNTCode.Controller.MtdDecimalToString(oCtrLer.Tbl5_SumMCol1_Buy()) + " (đ)";
            lblTotalSell_Sell.Text = VNTCode.Controller.MtdDecimalToString(oCtrLer.Tbl7_SumMCol1_Sell()) + " (đ)";

            MtdLoadTbl1();
            MtdLoadTbl2();
            MtdLoadTbl3();
            MtdLoadDate();
            MtdLoadState();
            comboBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                string cap = global::VNTSellGold.Properties.Resources.CapError;
                string mes = global::VNTSellGold.Properties.Resources.MesFromToDate;
                MessageBox.Show(mes, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MtdLoadTbl6Tbl7();
                comboBox1.Focus();
            }
        }
        #endregion Dotnet Methods -----------------------------------------

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bAll = comboBox2.SelectedIndex == comboBox2.Items.Count - 1;
            dateTimePicker1.Enabled = dateTimePicker2.Enabled = !bAll;
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    {
                        dateTimePicker1.Value = dateTimePicker2.Value = DateTime.Now;
                        break;
                    }
                case 1:
                    {
                        dateTimePicker1.Value = dateTimePicker1.Value.AddDays(-dateTimePicker1.Value.Day + 1);
                        dateTimePicker2.Value = dateTimePicker2.Value.AddMonths(1).AddDays(-dateTimePicker2.Value.Day);
                        break;
                    }
                case 2:
                    {
                        DateTime dt = dateTimePicker1.Value;
                        dateTimePicker1.Value = dt.AddMonths(-dt.Month + 1).AddDays(-dt.Day + 1);
                        dt = dateTimePicker2.Value;
                        dateTimePicker2.Value = dt.AddYears(1).AddMonths(-dt.Month + 1).AddDays(-dt.Day);
                        break;
                    }
            }

        }

        private void linkDau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblCurrentPage.Text = "0";
            MtdLoadTbl6Tbl7();
        }

        private void linkTruoc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int currentPage = int.Parse(lblCurrentPage.Text);
            if (currentPage > 0)
                currentPage--;
            lblCurrentPage.Text = currentPage.ToString();
            MtdLoadTbl6Tbl7();
        }

        private void linkSau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int currentPage = int.Parse(lblCurrentPage.Text);
            if (currentPage < pageCount - 1)
                currentPage++;
            lblCurrentPage.Text = currentPage.ToString();
            MtdLoadTbl6Tbl7();
        }

        private void linkCuoi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int currentPage = pageCount - 1;
            lblCurrentPage.Text = currentPage.ToString();
            MtdLoadTbl6Tbl7();
        }

        private void linkTatCa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sPageIndex = lblCurrentPage.Text;
            string sPageSize = txtPageSize.Text;
            // Select All.
            lblCurrentPage.Text = "0";
            txtPageSize.Text = "-1";
            MtdLoadTbl6Tbl7();
            lblCurrentPage.Text = sPageIndex;
            txtPageSize.Text = sPageSize;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                FrmReport oFrmReport = new FrmReport();
                oFrmReport.crystalReport1.SetDataSource(dataGridView1.DataSource as List<VNTCode.ClsTbl9Col>);
                oFrmReport.crystalReport1.SetParameterValue("NguoiGiu", comboBox1.Text);
                bool bAll = comboBox2.SelectedIndex == comboBox2.Items.Count - 1;
                string dateFrom = "", dateTo = "";

                if (!bAll)
                {
                    dateFrom = dateTimePicker1.Text;
                    dateTo = dateTimePicker2.Text;
                }
                oFrmReport.crystalReport1.SetParameterValue("DateFrom", dateFrom);
                oFrmReport.crystalReport1.SetParameterValue("DateTo", dateTo);
                oFrmReport.crystalReport1.SetParameterValue("Status", comboBox3.Text);
                oFrmReport.crystalReport1.SetParameterValue("lblTotalICol1", lblTotalICol1.Text);
                oFrmReport.crystalReport1.SetParameterValue("lblTotalSell", lblTotalSell.Text);
                oFrmReport.crystalReport1.SetParameterValue("lblTotalICol1_Buy", lblTotalICol1_Buy.Text);
                oFrmReport.crystalReport1.SetParameterValue("lblTotal", lblTotal.Text);
                oFrmReport.crystalReport1.SetParameterValue("lblTotalICol1_Sell", lblTotalICol1_Sell.Text);
                oFrmReport.crystalReport1.SetParameterValue("lblTotalSell_Sell", lblTotalSell_Sell.Text);
                oFrmReport.crystalReport1.SetParameterValue("sDateName", sDateName);

                oFrmReport.crystalReportViewer1.ReportSource = oFrmReport.crystalReport1;

                oFrmReport.ShowDialog();
            }
            catch (Exception ex) { }
            this.Cursor = Cursors.Default;
        }
    }
}
