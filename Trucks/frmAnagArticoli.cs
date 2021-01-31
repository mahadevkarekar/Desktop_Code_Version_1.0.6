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
    public partial class frmAnagArticoli : Form
    {
        private string strFiltro = "";
       
        public frmAnagArticoli()
        {
            InitializeComponent();
        }

        private void bttNuovo_Click(object sender, EventArgs e)
        {
            frmModArticoli newForm = new frmModArticoli();
            newForm.MdiParent = this.MdiParent;
            this.Hide();
            newForm.frmParent = this;
            newForm.Show();
        }

        private void bttClear_Click(object sender, EventArgs e)
        {
            ClearFileds();
        }

        private void ClearFileds()
        {
            dgvResult.DataSource = null;
            dgvResult.Rows.Clear();
            txtDescr.Text = "";
            txtCodice.Text = "";
            cmbCategoria.SelectedIndex = -1;
            cmbIva.SelectedIndex = -1;
            cmbUM.SelectedIndex = -1;
        }

        private void bttFind_Click(object sender, EventArgs e)
        {
            LoadSearchRusult();
        }

        private void PopolaCombo()
        {
            clsDataBase.PopolaCombo(cmbCategoria, clsGlobal.ETypeTable.TT_CATEGORIA);
            clsDataBase.PopolaCombo(cmbIva, clsGlobal.ETypeTable.TT_IVA);
            clsDataBase.PopolaCombo(cmbUM, clsGlobal.ETypeTable.TT_UNIT_MISURA);
        }

        private void LoadSearchRusult(bool OnlyIntestazione =false)
        {
            string strSql = " select " +
                                "a.id as ID, a.art_cod as Codice, a.art_descrizione as Descrizione, c.Categoria as Categoria, U.UM as 'U.M.', i.Iva as 'IVA %', round(a.art_prezzo, 2) as 'Prezzo €' " +
                                " from Articoli a" +
                                " left join categorie c on c.ID = a.art_ID_categoria" +
                                " left join Iva I on I.ID = a.art_ID_iva" +
                                " left join Um  U on U.ID = a.art_ID_um" +
                                " where art_cancellato = 0 ";
            string strWhere = "";
            
            if (OnlyIntestazione) 
                   strWhere = "and a.ID=-1";

            strFiltro = "";
            if (txtCodice.Text != "")
            {
                strWhere += " and art_cod = '" + txtCodice.Text.Replace("'","''") + "'";
                strFiltro += "   Codice: " + txtCodice.Text;
            }

            if (txtDescr.Text != "")
            {
                strWhere += " and art_descrizione like '%" + txtDescr.Text.Replace("'", "''") + "%'";
                strFiltro += "   Descrizione: " + txtDescr.Text;
            }

            if (cmbCategoria.Text != "")
            {
                strWhere += " and art_ID_categoria = " + ((_dataItemCombo)cmbCategoria.SelectedItem).Id.ToString();
                strFiltro += "   Categoria: " + cmbCategoria.Text;
            }
            if (cmbIva.Text != "")
            {
                strWhere += " and art_ID_iva = " + ((_dataItemCombo)cmbIva.SelectedItem).Id.ToString();
                strFiltro += "   IVA: " + cmbIva.Text;
            }
            if (cmbUM.Text != "")
            {
                strWhere += " and art_ID_um = " + ((_dataItemCombo)cmbUM.SelectedItem).Id.ToString();
                strFiltro += "   UM: " + cmbUM.Text;
            }

            bindingSource1.DataSource = clsDataBase.GetDataTable(strSql + strWhere);
            dgvResult.DataSource = bindingSource1;
            dgvResult.Columns["ID"].Visible = false;
            dgvResult.Columns["IVA %"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dgvResult.Columns["Prezzo €"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dgvResult.AutoResizeColumns();

            //if (clsDataBase.ExecuteQuery(strSql + strWhere))
            //{
            //    dgvResult.DataSource = clsDataBase.vetDbReader[0];
            //    dgvResult.Refresh();
            //    //while (clsDataBase.vetDbReader[0].Read())
            //    //{ 
                    
            //    //}
            //}
            //clsDataBase.CloseDataReader();

        }

        private void frmAnagArticoli_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PopolaCombo();
            LoadSearchRusult(true);
        }

        private void bttEsci_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttModifica_Click(object sender, EventArgs e)
        {
            if (dgvResult.CurrentRow != null)
            {
                frmModArticoli newForm = new frmModArticoli();
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
                    string strSql = "Update Articoli set art_cancellato=1 where id=" + Convert.ToInt32(dgvResult.CurrentRow.Cells["ID"].Value);
                    if (clsDataBase.ExecuteNonQuery(strSql))
                        MessageBox.Show("Record rimosso correttamente.\n\nEffettuare nuovamente la ricerca per aggiornare i dati visualizzati.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void frmAnagArticoli_Shown(object sender, EventArgs e)
        {
            
        }

        private void bttStampa_Click(object sender, EventArgs e)
        {
            //crpAnagArtNew newReport1 = new crpAnagArtNew();
            //clsReport.InizializzaReport(newReport1);
            //clsReport.ShowReport(newReport1);
            //return;

            crpAnagArticoli newReport = new crpAnagArticoli();

            clsReport.InizializzaReport(newReport);
            //crClienti.RecordSelectionFormula = "id=0";

            newReport.SetDataSource((DataTable)(bindingSource1.DataSource));
            strFiltro = strFiltro.Trim();
            if (strFiltro == "") 
                strFiltro = " ";
            clsReport.SetParamIntestazione(newReport, strFiltro);
            newReport.SetParameterValue("TipoDocumento", "Elenco Articoli");
            clsReport.ShowReport(newReport);
        }

        private void dgvResult_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bttModifica_Click(null, null);
        }
    }
}
