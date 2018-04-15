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
    public partial class FrmStatistic2 : Form
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
            var lstTbl3 =
                (from tbl3s in oCtrLer.MemLinq.Tbl3s
                 where tbl3s.SCol1 != lblUserName.Text
                 select new
                 {
                     Name = tbl3s.SCol2 + " " + tbl3s.SCol3,
                     Id = tbl3s.Id
                 });
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = lstTbl3;
        }

        void MtdLoadDate()
        {
            List<string> lstDate = new List<string>();
            lstDate.Add("All");
            lstDate.Add("Ngày");
            lstDate.Add("Tháng");
            lstDate.Add("Năm");

            comboBox2.DataSource = lstDate;
        }

        List<VNTCode.Tbl6> MtdLoadTbl6()
        {
            MtdCreateController();
            return (from tbl6s in oCtrLer.MemLinq.Tbl6s
                    where tbl6s.IdTbl3.ToString() == comboBox1.SelectedValue.ToString() && tbl6s.DTCol2 == null
                    && oCtrLer.MemLinq.Tbl7s.Where(tbl7 => tbl7.IdTbl5 == tbl6s.IdTbl5).FirstOrDefault() == null
                    select tbl6s).ToList();
        }

        void MtdKeeping()
        {
        }
        #endregion Load

        #endregion Methods -----------------------------------------

        #region Dotnet Methods *****************************************
        public FrmStatistic2()
        {
            InitializeComponent();
        }

        private void FrmStatistic2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        #endregion Dotnet Methods -----------------------------------------
    }
}
