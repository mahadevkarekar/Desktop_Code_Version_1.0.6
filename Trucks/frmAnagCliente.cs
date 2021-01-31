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
    public partial class frmAnagCliente : Form
    {
        private string strFiltro = "";

        public frmAnagCliente()
        {
            InitializeComponent();
        }

        private void bttNuovo_Click(object sender, EventArgs e)
        {
            frmModCliente newForm = new frmModCliente(); 
            newForm.MdiParent = this.MdiParent;
            this.Hide();
            newForm.frmParent = this;
            newForm.Show(); 
        }

        private void bttClear_Click(object sender, EventArgs e)
        {
            LoadSearchRusult(true);
            txtCitta.Text = "";
            txtPIVA.Text = "";
            txtRagSoc.Text = "";
            txtTel.Text = "";
            txtCodFiscale.Text = "";
        }

        private void bttEsci_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttFind_Click(object sender, EventArgs e)
        {
            LoadSearchRusult();
        }

        private void LoadSearchRusult(bool OnlyIntestazione = false)
        {
            string strSql = " select " +
                                "c.id as ID, Case When (c.Cln_rag_soc != '') Then c.Cln_rag_soc Else c.Cln_nome + ' ' + c.Cln_cognome End as 'Ragione Sociale', c.Cln_cod_fis as 'Codice Fiscale', c.Cln_iva as 'Partita IVA', c.Cln_cod_identificativo As Identificativo, c.Cln_pec As Pec, c.Cln_sede_legale As Indirizzo, c.Cln_sede_legale_nciv As [N°], c.Cln_sede_legale_cap as CAP, c.Cln_sede_legale_citta as 'Città', c.Cln_sede_legale_prov as 'Prov.', c.Cln_tel as Telefono, c.Cln_fax as Fax" +
                                " from Clienti c" +
                                " where Cln_cancellato = 0 ";
            string strWhere = "";

            if (OnlyIntestazione)
                strWhere = "and c.ID = -1";

            strFiltro = "";

            if (txtRagSoc.Text != "")
            {
                strWhere += " and (c.Cln_rag_soc like '%" + txtRagSoc.Text.Replace("'", "''") + "%'";
                strWhere += " or c.Cln_nome like '%" + txtRagSoc.Text.Replace("'", "''") + "%'";
                strWhere += " or c.Cln_cognome like '%" + txtRagSoc.Text.Replace("'", "''") + "%')";
                strFiltro += "   Rag. Soc.: " + txtRagSoc.Text;
            }
            
            if (txtPIVA.Text != "")
            {
                strWhere += " and c.Cln_iva like '%" + txtPIVA.Text.Replace("'", "''") + "%'";
                strFiltro += "   P. IVA: " + txtPIVA.Text;
            }
            
            if (txtCodFiscale.Text != "")
            {
                strWhere += " and c.Cln_cod_fis like '%" + txtCodFiscale.Text.Replace("'", "''") + "%'";
                strFiltro += "   Cod. Fis.: " + txtCodFiscale.Text;
            }
            
            if (txtTel.Text != "")
            {
                strWhere += " and c.Cln_tel like '%" + txtTel.Text + "%'";
                strFiltro += "   Tel.: " + txtTel.Text;
            }

            if (txtCitta.Text != "")
            {
                strWhere += " and c.Cln_sede_legale_citta like '%" + txtCitta.Text.Replace("'", "''") + "%'";
                strFiltro += "   Città: " + txtCitta.Text;
            }

            bindingSource1.DataSource = clsDataBase.GetDataTable(strSql + strWhere);
            dgvResult.DataSource = bindingSource1.DataSource;
            dgvResult.Columns["ID"].Visible = false;
            dgvResult.AutoResizeColumns();
        }

        private void frmAnagCliente_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LoadSearchRusult(true);
        }

        private void bttModifica_Click(object sender, EventArgs e)
        {
            if (dgvResult.CurrentRow != null)
            {
                frmModCliente newForm = new frmModCliente();
                newForm.MdiParent = this.MdiParent;
                this.Hide();
                newForm.frmParent = this;
                newForm.IdSel = Convert.ToInt32(dgvResult.CurrentRow.Cells["ID"].Value);
                newForm.Show();
            }
        }

        private void dgvResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void bttElimina_Click(object sender, EventArgs e)
        {
            if (dgvResult.CurrentRow != null)
            {
                if (MessageBox.Show("Eliminare il record selezionato ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string strSql = "Update Clienti set Cln_cancellato=1 where id=" + Convert.ToInt32(dgvResult.CurrentRow.Cells["ID"].Value);
                    if (clsDataBase.ExecuteNonQuery(strSql))
                        MessageBox.Show("Record rimosso correttamente.\n\nEffettuare nuovamente la ricerca per aggiornare i dati visualizzati.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !clsGlobal.IsNumber(e.KeyChar);
        }

        private void frmAnagCliente_Shown(object sender, EventArgs e)
        {
            
        }

        private void bttStampa_Click(object sender, EventArgs e)
        {
            crpAnagCliente1 crClienti = new crpAnagCliente1();

            
            clsReport.InizializzaReport(crClienti);
            
            //crClienti.RecordSelectionFormula = "id=0";
            //DataTable objDataTable = (DataTable)(bindingSource1.DataSource);
            //crClienti.SetDataSource(objDataTable);

            crClienti.SetDataSource((DataTable)(bindingSource1.DataSource));

            strFiltro = strFiltro.Trim();
            if (strFiltro == "")
                strFiltro = " ";

            clsReport.SetParamIntestazione(crClienti, strFiltro);
            crClienti.SetParameterValue("TipoDocumento", "Anagrafe Clienti");
            clsReport.ShowReport(crClienti);
            
            
        }

        private void dgvResult_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bttModifica_Click(null, null);
        }

        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtPIVA_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
