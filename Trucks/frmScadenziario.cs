using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trucks
{
    public partial class frmScadenziario : Form
    {
        private string strFiltro = "";

        public frmScadenziario()
        {
            InitializeComponent();
        }

        private void bttFind_Click(object sender, EventArgs e)
        {
            LoadSearchRusult();
        }

        private void LoadSearchRusult(bool OnlyIntestazione = false)
        {
            string strSql = "";
            string strGroupBy = "";

            bttNuovoPag.Enabled = !chkRagCl.Checked;
            bttElimina.Enabled = !chkRagCl.Checked;

            if (!chkRagCl.Checked)
            {
                strSql = "select " +
                                " s.ID as ID, " +
                                " c.Cln_rag_soc as Cliente," +
                                " f.docu_numero as 'Num. Fattura'," +
                                " f.docu_data as 'Data Fattura'," +
                                " f.importo as 'Importo Fattura'," +
                                " s.Scadenza_importo as 'Importo Scadenza'," +
                                " s.Scadenza_data as 'Data Scadenza'," +
                                " s.Scandenza_incassato as Incassato," +
                                " s.Scandenza_incassato_data as 'Data Incasso'," +
                                " (s.Scadenza_importo - Scandenza_incassato) as Saldo " +
                            " from " +
                                " Scadenze s" +
                                " left join View_Fatture f on s.ID_documento = f.ID" +
                                " left join Clienti c on c.Id = f.ID_cliente" +
                            " where docu_cancellato = 0 and Scadenza_cancellato = 0 ";
            }
            else
            {
                strSql = "select " +
                                " '0' as ID, " +
                                " c.Cln_rag_soc as Cliente," +
                                " '' as 'Num. Fattura'," +
                                " '' as 'Data Fattura'," +
                                " sum(f.importo) as 'Importo Fattura'," +
                                " sum(s.Scadenza_importo) as 'Importo Scadenza'," +
                                " '' as 'Data Scadenza'," +
                                " sum(s.Scandenza_incassato) as Incassato," +
                                " sum((s.Scadenza_importo - Scandenza_incassato)) as Saldo " +
                            " from " +
                                " Scadenze s" +
                                " left join View_Fatture f on s.ID_documento = f.ID" +
                                " left join Clienti c on c.Id = f.ID_cliente" +
                            " where docu_cancellato = 0 and Scadenza_cancellato = 0 ";

                strGroupBy = " Group by c.Cln_rag_soc ";
            }
            string strWhere = "";

            if (OnlyIntestazione)
                strWhere = " and s.ID = -1";


            strFiltro = "";

            if (cmbCli.SelectedIndex > 0)
            {
                strWhere += " and f.Id_Cliente = " + ((_dataItemCombo)cmbCli.SelectedItem).Id + "";
                strFiltro += "   Cliente: " +  cmbCli.Text;
            }

            if (nudImpMin.Value > 0)
            {
                strWhere += " and s.Scadenza_importo >= " + nudImpMin.Value.ToString().Replace(",",".") + "";
                strFiltro += "   Importo MIN: " + nudImpMin.Value.ToString();
            }

            if (nudImpMax.Value > 0)
            {
                strWhere += " and s.Scadenza_importo <= " + nudImpMax.Value.ToString().Replace(",", ".") + "";
                strFiltro += "   Importo MAX: " + nudImpMax.Value.ToString();
            }

            if (dtpDataFatt.Checked)
            {
                strWhere += " and f.docu_data = " + clsDataBase.SQL_ConvertDateTimeToData(dtpDataFatt.Value) + "";
                strFiltro += "   Data Fatt.: " + dtpDataFatt.Text;
            }

            if (dtpDataDal.Checked)
            {
                strWhere += " and f.docu_data >= " + clsDataBase.SQL_ConvertDateTimeToData(dtpDataDal.Value) + "";
                strFiltro += "   Dal: " + dtpDataDal.Text;
            }

            if (dtpDataAl.Checked)
            {
                strWhere += " and f.docu_data <= " + clsDataBase.SQL_ConvertDateTimeToData(dtpDataAl.Value) + "";
                strFiltro += "   Al: " + dtpDataAl.Text;
            }

            if (txtNumFatt.Text != "")
            {
                strWhere += " and f.docu_numero = " + txtNumFatt.Text + "";
                strFiltro += "   Num. Fatt.: " + txtNumFatt.Text;
            }

            if (chkScaduti.Checked)
            {
                strWhere += " and s.Scadenza_data <= " + clsDataBase.SQL_ConvertDateTimeToData(DateTime.Today) + " and Scadenza_saldata = 0";
                strFiltro += "   Scaduti: SI";
            }

            if (nudScadGG.Value > 0)
            {
                strWhere += " and s.Scadenza_data <= " + clsDataBase.SQL_ConvertDateTimeToData(DateTime.Today.AddDays((int)nudScadGG.Value)) + " and Scadenza_saldata = 0";
                strFiltro += "   Scad. Entro gg: " + nudScadGG.Text;
            }

            if (dtpScadDal.Checked)
            {
                strWhere += " and s.Scadenza_data >= " + clsDataBase.SQL_ConvertDateTimeToData(dtpScadDal.Value) + "";
                strFiltro += "   Scad. Dal: " + dtpScadDal.Text;
            }

            if (dtpScadAl.Checked)
            {
                strWhere += " and s.Scadenza_data <= " + clsDataBase.SQL_ConvertDateTimeToData(dtpScadAl.Value) + "";
                strFiltro += "   Scad. Al: " + dtpScadAl.Text;
            }

            bindingSource1.DataSource = clsDataBase.GetDataTable(strSql + strWhere + strGroupBy);
            dgvResult.DataSource = bindingSource1;
            dgvResult.Columns["ID"].Visible = false;
            dgvResult.Columns["Num. Fattura"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvResult.Columns["Importo Fattura"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvResult.Columns["Importo Fattura"].CellTemplate.Style.Format = "C2";
            dgvResult.Columns["Incassato"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvResult.Columns["Incassato"].CellTemplate.Style.Format = "C2";
            dgvResult.Columns["Importo Scadenza"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvResult.Columns["Importo Scadenza"].CellTemplate.Style.Format = "C2";
            dgvResult.Columns["Saldo"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvResult.Columns["Saldo"].CellTemplate.Style.Format = "C2";

            for (int i = 0; i < dgvResult.Columns.Count; i++)
                dgvResult.Columns[i].ReadOnly = true;

            //dgvResult.Columns["ColChk"].ReadOnly = false;
            dgvResult.AutoResizeColumns();

            SetTotali();
        }

        private void SetTotali()
        {
            decimal dTotImpScad = 0;
            decimal dTotImpFatt = 0;
            decimal dTotInc = 0;
            decimal dTotSaldo = 0;

            foreach (DataGridViewRow objRow in dgvResult.Rows)
            {
                if (objRow.Cells["Importo Scadenza"].Value.ToString() != "") dTotImpScad += Convert.ToDecimal(objRow.Cells["Importo Scadenza"].Value.ToString());
                if (objRow.Cells["Importo Fattura"].Value.ToString() != "") dTotImpFatt += Convert.ToDecimal(objRow.Cells["Importo Fattura"].Value.ToString());
                if (objRow.Cells["Incassato"].Value.ToString() != "") dTotInc += Convert.ToDecimal(objRow.Cells["Incassato"].Value.ToString());
                if (objRow.Cells["Saldo"].Value.ToString() != "") dTotSaldo += Convert.ToDecimal(objRow.Cells["Saldo"].Value.ToString());
                
            }

            lblTotImp.Text = dTotImpScad.ToString("C2");
            lblTotFat.Text = dTotImpFatt.ToString("C2");
            lblTotInc.Text = dTotInc.ToString("C2");
            lblSaldo.Text = dTotSaldo.ToString("C2");
        }

        private void frmScadenziario_Load(object sender, EventArgs e)
        {
            if (!this.Modal && this.MdiParent != null)
                this.WindowState = FormWindowState.Maximized;

            LoadSearchRusult(true);
            PopolaCombo();
        }

        private void PopolaCombo()
        {
            clsDataBase.PopolaCombo(cmbCli, clsGlobal.ETypeTable.TT_CLIENTI);
        }

        private void bttClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            //dgvResult.Rows.Clear();
            LoadSearchRusult(true);

            cmbCli.SelectedIndex = 0;
            nudImpMin.Value = 0;
            nudImpMax.Value = 0;
            dtpDataFatt.Checked = false;
            dtpDataDal.Checked = false;
            dtpDataAl.Checked = false;
            txtNumFatt.Text = "";
            chkScaduti.Checked = false;
            nudScadGG.Value = 0;
            dtpScadDal.Checked = false;
            dtpScadAl.Checked = false;
        }

        private void txtNumFatt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !clsGlobal.IsNumber(e.KeyChar);
        }

        private void bttEsci_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttNuovoPag_Click(object sender, EventArgs e)
        {
            if (dgvResult.CurrentRow!=null)
            {
                frmNewPagamento frmNew = new frmNewPagamento();

                frmNew.IdSel = (int)dgvResult.CurrentRow.Cells["Id"].Value;
                frmNew.frmParent = this;
                frmNew.MdiParent = this.MdiParent;
                this.Hide();
                frmNew.Show();
            }
        }

        private void bttStampa_Click(object sender, EventArgs e)
        {
            crpScadenziario newReport = new crpScadenziario();

            clsReport.InizializzaReport(newReport);
            //crClienti.RecordSelectionFormula = "id=0";

            newReport.SetDataSource((DataTable)(bindingSource1.DataSource));

            strFiltro = strFiltro.Trim();
            if (strFiltro == "")
                strFiltro = " ";

            clsReport.SetParamIntestazione(newReport, strFiltro);
            newReport.SetParameterValue("TipoDocumento", "Scadenziario");
            clsReport.ShowReport(newReport);
        }

        private void bttElimina_Click(object sender, EventArgs e)
        {
            if (dgvResult.CurrentRow != null)
            {
                if (MessageBox.Show("Eliminare la Scadenza di pagamento selezionata ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string strSql = "Update Scadenze set " +
                                        " Scadenza_cancellato = 1" +
                                        " where Id= " + dgvResult.CurrentRow.Cells["Id"].Value.ToString();
                    if (clsDataBase.ExecuteNonQuery(strSql))
                    {
                        MessageBox.Show("Aggiornamento effettuato.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void bttModifica_Click(object sender, EventArgs e)
        {
            if (dgvResult.CurrentRow != null)
            {
                frmNewPagamento frmNew = new frmNewPagamento();

                frmNew.IdSel = (int)dgvResult.CurrentRow.Cells["Id"].Value;
                frmNew.frmParent = this;
                this.Hide();
                frmNew.Show();
            }
        }

        private void dgvResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvResult_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bttNuovoPag.Enabled)
                bttNuovoPag_Click(null, null);
        }

        private void chkRagCl_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
