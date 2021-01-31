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
    public partial class frmAnagAutomezzi : Form
    {
        private string strFiltro = "";

        public frmAnagAutomezzi()
        {
            InitializeComponent();
        }

        private void bttNuovo_Click(object sender, EventArgs e)
        {
            frmModAutomezzi newForm = new frmModAutomezzi();
            newForm.MdiParent = this.MdiParent;
            this.Hide();
            newForm.frmParent = this;
            newForm.Show();
        }

        private void bttClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            dgvResult.DataSource = null;
            dgvResult.Rows.Clear();
            LoadSearchRusult(true);
            txtAssicurazione.Text = "";
            txtMarca.Text = "";
            txtModello.Text = ""; 
            txtTarga.Text = "";
            txtTelaio.Text = "";
            dtpAssScadAl.Checked = false;
            dtpAssScadDal.Checked = false; 
        }

        private void bttCerca_Click(object sender, EventArgs e)
        {
            LoadSearchRusult();
        }

        private void LoadSearchRusult(bool OnlyIntestazione = false)
        {
            string strSql = " select " +
                                "t.id as ID, t.truck_targa as Targa, t.truck_marca as Marca, t.truck_modello as Modello, t.truck_telaio as Telaio, t.truck_portata as Portata, t.truck_assicurazione as Assicurazione, t.truck_scadenza_assic as 'Scad. Assic.', t.truck_scadenza_bollo as 'Scad. Bollo'" +
                                " from Truck t" +
                                " where truck_cancellato = 0 ";
            string strWhere = "";

            if (OnlyIntestazione)
                strWhere = "and t.ID=-1";

            strFiltro = "";

            if (txtTarga.Text != "")
            {
                strWhere += " and t.truck_targa = '" + txtTarga.Text.Replace("'", "''") + "'";
                strFiltro += "   Targa: " + txtTarga.Text;
            }
            
            if (txtTelaio.Text != "")
            {
                strWhere += " and t.truck_telaio like '%" + txtTelaio.Text.Replace("'", "''") + "%'";
                strFiltro += "   Telaio: " + txtTelaio.Text;
            }
            
            if (txtMarca.Text != "")
            {
                strWhere += " and t.truck_marca = '" + txtMarca.Text.Replace("'", "''") + "'";
                strFiltro += "   Marca: " + txtMarca.Text;
            }
            
            if (txtModello.Text != "")
            {
                strWhere += " and t.truck_modello = '" + txtModello.Text.Replace("'", "''") + "'";
                strFiltro += "   Modello: " + txtModello.Text;
            }
            
            if (txtAssicurazione.Text != "")
            {
                strWhere += " and t.truck_assicurazione = '" + txtAssicurazione.Text.Replace("'", "''") + "'";
                strFiltro += "   Assicurazione: " + txtAssicurazione.Text;
            }
            
            if (dtpAssScadDal.Checked)
            {
                strWhere += " and t.truck_scadenza_assic >= " + clsDataBase.SQL_ConvertDateTimeToData(dtpAssScadDal.Value);
                strFiltro += "   Ass. Scad. Dal: " + dtpAssScadDal.Value.ToString("dd/MM/yyyy");
            }
            
            if (dtpAssScadAl.Checked)
            {
                strWhere += " and t.truck_scadenza_assic <= " + clsDataBase.SQL_ConvertDateTimeToData(dtpAssScadAl.Value);
                strFiltro += "   Ass. Scad. Al: " + dtpAssScadAl.Value.ToString("dd/MM/yyyy");
            }

            bindingSource1.DataSource = clsDataBase.GetDataTable(strSql + strWhere);
            dgvResult.DataSource = bindingSource1;
            dgvResult.Columns["ID"].Visible = false;
            dgvResult.AutoResizeColumns();            
        }

        private void frmAnagAutomezzi_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LoadSearchRusult(true);
        }

        private void bttModifica_Click(object sender, EventArgs e)
        {
            if (dgvResult.CurrentRow != null)
            {
                frmModAutomezzi newForm = new frmModAutomezzi();
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

        private void bttEsci_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttElimina_Click(object sender, EventArgs e)
        {
            if (dgvResult.CurrentRow != null)
            {
                if (MessageBox.Show("Eliminare il record selezionato ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string strSql = "Update Truck set truck_cancellato=1 where id=" + Convert.ToInt32(dgvResult.CurrentRow.Cells["ID"].Value);
                    if (clsDataBase.ExecuteNonQuery(strSql))
                        MessageBox.Show("Record rimosso correttamente.\n\nEffettuare nuovamente la ricerca per aggiornare i dati visualizzati.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void frmAnagAutomezzi_Shown(object sender, EventArgs e)
        {
            
        }

        private void bttStampa_Click(object sender, EventArgs e)
        {
            crpAnagAutomezzi newReport = new crpAnagAutomezzi();

            clsReport.InizializzaReport(newReport);
            //crClienti.RecordSelectionFormula = "id=0";

            newReport.SetDataSource((DataTable)(bindingSource1.DataSource));
            
            strFiltro = strFiltro.Trim();
            if (strFiltro == "")
                strFiltro = " ";

            clsReport.SetParamIntestazione(newReport, strFiltro);
            newReport.SetParameterValue("TipoDocumento", "Elenco Automezzi");
            clsReport.ShowReport(newReport);
        }

        private void dgvResult_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bttModifica_Click(null, null);
        }
    }
}
