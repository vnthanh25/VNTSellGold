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
    public partial class FrmTbl2Edit : Form
    {
        #region Members *****************************************
        // Store columns name which is checked empty.
        List<string> lstCheckColumn = new List<string>();
        #endregion Members -----------------------------------------

        #region Methods *****************************************
        #endregion Methods -----------------------------------------

        #region Dotnet Methods *****************************************
        public FrmTbl2Edit()
        {
            InitializeComponent();
        }

        private void FrmTbl2Edit_Load(object sender, EventArgs e)
        {
            // Check empty on SCol1 column.
            lstCheckColumn.Add("SCol1");
            // TODO: This line of code loads data into the 'vNTSellGoldDataSet.Tbl2' table. You can move, or remove it, as needed.
            this.tbl2TableAdapter.Fill(this.vNTSellGoldDataSet.Tbl2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Show message about saving completed.
            string mes;
            string cap;
            try
            {
                this.tbl2TableAdapter.Update(this.vNTSellGoldDataSet.Tbl2);
            }
            catch (Exception ex)
            {
                mes = global::VNTSellGold.Properties.Resources.MesErrorUpdate;
                cap = global::VNTSellGold.Properties.Resources.CapError;
                MessageBox.Show(mes, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            mes = global::VNTSellGold.Properties.Resources.MesSaveOk;
            cap = global::VNTSellGold.Properties.Resources.CapSave;
            MessageBox.Show(mes, cap, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //DataGridView dgv = sender as DataGridView;
            //if (lstCheckColumn.Contains(dgv.Columns[e.ColumnIndex].Name))
            //    if (e.Cancel = string.IsNullOrEmpty(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim()))
            //        dgv.CancelEdit();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            string cap = global::VNTSellGold.Properties.Resources.CapError;
            string mes = "";
            if (e.Exception.Message.ToLower().Contains("null"))
            {
                for (int i = 0; i < lstCheckColumn.Count; i++)
                    mes += dgv.Columns[lstCheckColumn[i]].HeaderText + ", ";
                mes = mes.Remove(mes.Length - 2);
                mes += " : " + global::VNTSellGold.Properties.Resources.MesEmpty;
            }
            if (dgv.Columns[e.ColumnIndex].Name == "DTCol1")
            {
                // Show message about invalid date.
                mes = global::VNTSellGold.Properties.Resources.MesInvalidDate;
            }
            MessageBox.Show(mes, cap, MessageBoxButtons.OK, MessageBoxIcon.Information);
            e.Cancel = true; // Not leave current cell.
            dgv.CancelEdit(); // Return previous value.
        }
        #endregion Dotnet Methods -----------------------------------------
    }
}
