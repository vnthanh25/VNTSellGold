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
    public partial class FrmTbl4Edit : Form
    {
        #region Members *****************************************
        // Store columns name which is checked empty.
        List<string> lstCheckColumn = new List<string>();
        #endregion Members -----------------------------------------

        #region Methods *****************************************
        #endregion Methods -----------------------------------------
        
        #region Dotnet Methods *****************************************
        public FrmTbl4Edit()
        {
            InitializeComponent();
        }

        private void FrmTbl4Edit_Load(object sender, EventArgs e)
        {
            // Check empty on SCol1 column.
            lstCheckColumn.Add("SCol1");
            // TODO: This line of code loads data into the 'vNTSellGoldDataSet.Tbl4' table. You can move, or remove it, as needed.
            this.tbl4TableAdapter.Fill(this.vNTSellGoldDataSet.Tbl4);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.tbl4TableAdapter.Update(this.vNTSellGoldDataSet.Tbl4);
            // Show message about saving completed.
            string cap = global::VNTSellGold.Properties.Resources.CapSave;
            string mes = global::VNTSellGold.Properties.Resources.MesSaveOk;
            MessageBox.Show(mes, cap, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //DataGridView dgv = sender as DataGridView;
            //string cap = VNTSellGold.Data.Controller.MtdGetResourceValue(typeof(FrmTbl4Edit), "CapError");
            //string mes = VNTSellGold.Data.Controller.MtdGetResourceValue(typeof(FrmTbl4Edit), "MesEmpty");
            //for (int i = 0; i < lstCheckColumn.Count; i++)
            //{
            //    int iColIndex = dgv.Columns[lstCheckColumn[i]].Index;
            //    if (Convert.ToString(dgv.Rows[e.RowIndex].Cells[iColIndex].Value).Trim() == "")
            //    {
            //        mes = dgv.Columns[iColIndex].HeaderText + " : " + mes;
            //        //if (e.Cancel = MessageBox.Show(mes, cap, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            //        //    dgv.CancelEdit();
            //    }
            //}
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (!dgv.CurrentRow.IsNewRow)
            {
                string cap = global::VNTSellGold.Properties.Resources.CapError;
                string mes = cap;
                if (e.Exception.Message.ToLower().Contains("null"))
                {
                    mes = "";
                    for (int i = 0; i < lstCheckColumn.Count; i++)
                        mes += dgv.Columns[lstCheckColumn[i]].HeaderText + ", ";
                    mes = mes.Remove(mes.Length - 3);
                    mes += " : " + global::VNTSellGold.Properties.Resources.MesEmpty;
                }
                if (dgv.Columns[e.ColumnIndex].Name.ToLower().Contains("dt"))
                {
                    // Show message about invalid date.
                    mes = global::VNTSellGold.Properties.Resources.MesInvalidDate;
                    dgv.CancelEdit(); // Return previous value.
                }
                MessageBox.Show(mes, cap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true; // Not leave current cell.
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.Columns[e.ColumnIndex].Name.ToLower().Contains("dt"))
            {
                if (e.FormattedValue.ToString().Trim() == "")
                {
                    dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = System.DBNull.Value;
                    dgv.RefreshEdit();
                    e.Cancel = false;
                }
                else
                {
                    // User input by dd/MM/yyyy format.
                    string[] aDate = e.FormattedValue.ToString().Trim().Split('/');
                    if (aDate.Length == 3)
                    {
                        // Get date format in the region (it may is MM/dd/yyyy).
                        List<int> lstIndDate = VNTCode.Controller.MtdGetIndexDateFormat();
                        List<string> lstDate = new List<string>(3);
                        lstDate.Add("");
                        lstDate.Add("");
                        lstDate.Add("");
                        lstDate[lstIndDate[0]] = aDate[0];
                        lstDate[lstIndDate[1]] = aDate[1];
                        lstDate[lstIndDate[2]] = aDate[2];
                        dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = lstDate[0] + "/" + lstDate[1] + "/" + lstDate[2];
                        dgv.RefreshEdit();
                        e.Cancel = false;
                    }
                }
            }
        }
        #endregion Dotnet Methods -----------------------------------------
    }
}
