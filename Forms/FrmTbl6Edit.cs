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
    public partial class FrmTbl6Edit : Form
    {
        #region Members *****************************************
        // Controller.
        VNTSellGold.App_Code.Controller oCtrLer;
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
                //(from tbl3s in oCtrLer.MemLinq.Tbl3s
                // where tbl3s.SCol1 != lblUserName.Text
                // select new
                // {
                //     Name = tbl3s.SCol2 + " " + tbl3s.SCol3,
                //     Id = tbl3s.Id
                // });
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = lstTbl3;
        }

        void MtdLoadTbl61()
        {
            MtdCreateController();
            List<VNTCode.Tbl6> lstTbl6 =
                (from tbl6s in oCtrLer.MemLinq.Tbl6s
                 where tbl6s.IdTbl3.ToString() == comboBox1.SelectedValue.ToString() && tbl6s.Tbl5.ICol2 == 1
                 select tbl6s).ToList();
            listView2.Items.Clear();
            for (int i = 0; i < lstTbl6.Count; i++)
            {
                ListViewItem item = listView2.Items.Add("(" + lstTbl6[i].Tbl5.Id.ToString() + ")" + lstTbl6[i].Tbl5.Tbl1.SCol1 + "-" + lstTbl6[i].Tbl5.Tbl2.SCol1 + "-" + lstTbl6[i].Tbl5.ICol1.ToString());
                item.Name = lstTbl6[i].Tbl5.Id.ToString();
                item.ToolTipText = lstTbl6[i].Tbl5.SCol2;
            }
        }

        //List<VNTCode.Tbl6> MtdLoadTbl6()
        //{
        //    MtdCreateController();
        //    return (from tbl6s in oCtrLer.MemLinq.Tbl6s
        //            where tbl6s.IdTbl3.ToString() == comboBox1.SelectedValue.ToString() && tbl6s.DTCol2 == null
        //            //&& oCtrLer.MemLinq.Tbl7s.Where(tbl7 => tbl7.IdTbl5 == tbl6s.IdTbl5).FirstOrDefault() == null
        //            select tbl6s).ToList();
        //}

        void MtdLoadTbl6()
        {
            MtdCreateController();
            List<VNTCode.Tbl6> lstTbl6 = oCtrLer.Tbl6_Gets_ByIdTbl3(Convert.ToInt32(comboBox1.SelectedValue.ToString()));
            listView2.Items.Clear();
            for (int i = 0; i < lstTbl6.Count; i++)
            {
                ListViewItem item = listView2.Items.Add("(" + lstTbl6[i].Tbl5.ICol3.ToString() + ") " + lstTbl6[i].Tbl5.Tbl1.SCol1 + " - " + lstTbl6[i].Tbl5.Tbl2.SCol1 + " - " + lstTbl6[i].Tbl5.ICol1.ToString());
                item.Name = lstTbl6[i].Tbl5.Id.ToString();
                item.ToolTipText = lstTbl6[i].Tbl5.SCol2;
            }
            lblTotalICol1.Text = VNTCode.Controller.MtdIntToString(MtdSumICol1()) + " (ly)";
        }

        int MtdSumICol1()
        {
            int iCol1 = 0;
            foreach (ListViewItem item in listView2.Items)
            {
                iCol1 += Convert.ToInt32(item.Text.Substring(item.Text.LastIndexOf("-") + 2));
            }
            return iCol1;
        }

        void MtdLoadTbl51()
        {
            MtdCreateController();
            List<VNTCode.Tbl5> lstTbl5 =
                (from tbl5s in oCtrLer.MemLinq.Tbl5s
                 where tbl5s.CreateBy == lblUserName.Text && tbl5s.ICol2 == 0
                 select tbl5s).ToList();
            listView1.Items.Clear();
            for (int i = 0; i < lstTbl5.Count; i++)
            {
                ListViewItem item = listView1.Items.Add("(" + lstTbl5[i].Id.ToString() + ")" + lstTbl5[i].Tbl1.SCol1 + "-" + lstTbl5[i].Tbl2.SCol1 + "-" + lstTbl5[i].ICol1.ToString());
                item.Name = lstTbl5[i].Id.ToString();
                item.ToolTipText = lstTbl5[i].SCol2;
            }
        }
        void MtdLoadTbl5()
        {
            MtdCreateController();
            List<VNTCode.Tbl5> lstTbl5 = oCtrLer.Tbl5_Gets_ByCreateBy(lblUserName.Text);
                //(from tbl5s in oCtrLer.MemLinq.Tbl5s
                // where tbl5s.CreateBy == lblUserName.Text 
                // && !oCtrLer.MemLinq.Tbl6s.Contains(oCtrLer.MemLinq.Tbl6s.Where(tbl6 => tbl6.IdTbl5 == tbl5s.Id && tbl6.DTCol2 == null).FirstOrDefault())
                // && !oCtrLer.MemLinq.Tbl7s.Contains(oCtrLer.MemLinq.Tbl7s.Where(tbl7 => tbl7.IdTbl5 == tbl5s.Id).FirstOrDefault())
                // select tbl5s).ToList();
            listView1.Items.Clear();
            for (int i = 0; i < lstTbl5.Count; i++)
            {
                ListViewItem item = listView1.Items.Add("(" + lstTbl5[i].ICol3.ToString() + ") " + lstTbl5[i].Tbl1.SCol1 + " - " + lstTbl5[i].Tbl2.SCol1 + " - " + lstTbl5[i].ICol1.ToString());
                item.Name = lstTbl5[i].Id.ToString();
                item.ToolTipText = lstTbl5[i].SCol2;
            }
        }


        #endregion Load End

        void MtdSave()
        {
            MtdCreateController();
            List<VNTCode.Tbl6> lstTbl6 = oCtrLer.Tbl6_Gets_ByIdTbl3(Convert.ToInt32(comboBox1.SelectedValue.ToString()));
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                VNTCode.Tbl6 oTbl6 = lstTbl6.Where(tbl6 => tbl6.IdTbl5.ToString() == listView2.Items[i].Name).FirstOrDefault();
                // Nếu không có trong danh sách ban đầu thì thêm vào.
                if (oTbl6 == null)
                {
                    oTbl6 = new VNTCode.Tbl6();
                    oTbl6.IdTbl3 = Convert.ToInt32(comboBox1.SelectedValue);
                    oTbl6.IdTbl5 = Convert.ToInt32(listView2.Items[i].Name);
                    oTbl6.DTCol1 = oCtrLer.MtdGetDate();
                    oCtrLer.MemLinq.Tbl6s.InsertOnSubmit(oTbl6);
                    oCtrLer.MemLinq.Tbl5s.Where(tb5 => tb5.Id == oTbl6.IdTbl5).Single().ICol2 = 3;
                }
                // Nếu có thì loại ra khoải danh sách ban đầu để không phải cập nhật lại DTCol2.
                else
                {
                    lstTbl6.Remove(oTbl6);// Remove trong List chứ không phải Delete trong Database.
                }
            }
            // Duyệt qua những thằng có trong danh sách ban đầu nhưng không có trong danh sách mới.
            foreach (VNTCode.Tbl6 oTbl6 in lstTbl6)
            {
                oTbl6.DTCol2 = oCtrLer.MtdGetDate();
                oTbl6.Tbl5.ICol2 = 1;
            }
            oCtrLer.MemLinq.SubmitChanges();
        }

        void MtdAddTbl61()
        {
            MtdCreateController();
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                VNTCode.Tbl5 oTbl5 = oCtrLer.MemLinq.Tbl5s.Where(tbl5 =>tbl5.Id.ToString() == listView1.SelectedItems[i].Name).FirstOrDefault();
                oTbl5.ICol2 = 1;
            }
            oCtrLer.MemLinq.SubmitChanges();
        }
        void MtdAddTbl6()
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
                listView2.Items.Add(item);
            }
            lblTotalICol1.Text = VNTCode.Controller.MtdIntToString(MtdSumICol1()) + " (ly)";
        }

        void MtdRemoveTbl61()
        {
            MtdCreateController();
            for (int i = 0; i < listView2.SelectedItems.Count; i++)
            {
                VNTCode.Tbl5 oTbl5 = oCtrLer.MemLinq.Tbl5s.Where(tbl5 => tbl5.Id.ToString() == listView2.SelectedItems[i].Name).FirstOrDefault();
                oTbl5.ICol2 = 0;
            }
            oCtrLer.MemLinq.SubmitChanges();
        }
        void MtdRemoveTbl6()
        {
            foreach (ListViewItem item in listView2.SelectedItems)
            {
                listView2.Items.Remove(item);
                listView1.Items.Add(item);
            }
            lblTotalICol1.Text = VNTCode.Controller.MtdIntToString(MtdSumICol1()) + " (ly)";
        }
        #endregion Methods -----------------------------------------

        #region Dotnet Methods *****************************************
        public FrmTbl6Edit()
        {
            InitializeComponent();
        }

        private void FrmTbl6Edit_Load(object sender, EventArgs e)
        {
            lblUserName.Text = "host";
            MtdLoadTbl3();
            MtdLoadTbl6();
            MtdLoadTbl5();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MtdAddTbl6();
            //MtdLoadTbl6();
            //MtdLoadTbl5();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MtdRemoveTbl6();
            //MtdLoadTbl6();
            //MtdLoadTbl5();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MtdSave();
            string cap = global::VNTSellGold.Properties.Resources.CapSave;
            string mes = global::VNTSellGold.Properties.Resources.MesSaveOk;
            MessageBox.Show(mes, cap, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MtdLoadTbl6();
            MtdLoadTbl5();
        }
        #endregion Dotnet Methods -----------------------------------------
    }
}
