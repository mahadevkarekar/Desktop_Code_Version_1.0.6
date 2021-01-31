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
    
    public partial class frmDocViaggi : Form
    {
        private string strFiltro = "";
        public int CLTSel = 0;
        public bool GoImport = false;

        public frmDocViaggi()
        {
            InitializeComponent();
        }
        
        private void frmDocViaggi_Load(object sender, EventArgs e)
        {
            if (!this.Modal && this.MdiParent != null)
                this.WindowState = FormWindowState.Maximized;

            ClearFields();

        }
        private void frmDocViaggi_Activated(object sender, System.EventArgs e)  
        {
            if (dgvResult.RowCount > 0)
            {
                LoadSearchRusult();
                NumberAllRow();
            }
        }
        private void frmdocViaggi_Shown()
                    {
                        if (dgvResult.RowCount > 0)
                        {
                            LoadSearchRusult();
                            NumberAllRow();
                        }
        }
        private void NumberAllRow()
        {
            for (int i = 1; i <= dgvResult.RowCount; i++)
                dgvResult.Rows[i-1].HeaderCell.Value = i.ToString();
        }

      
        private void PopolaCombo()
        {
            clsDataBase.PopolaCombo(cmbAutom, clsGlobal.ETypeTable.TT_AUTOMEZZI);
            clsDataBase.PopolaCombo(cmbCli, clsGlobal.ETypeTable.TT_CLIENTI);
            clsDataBase.PopolaCombo(cmbCodArt, clsGlobal.ETypeTable.TT_ARTICOLI);
            clsDataBase.PopolaCombo(cmbTrA, clsGlobal.ETypeTable.TT_LOCALITA);
            clsDataBase.PopolaCombo(cmbTrDa, clsGlobal.ETypeTable.TT_LOCALITA);
        }

        private void bttClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtDescr.Text = "";
            txtDTT.Text = "";
            dtpDataAl.Checked = dtpDataDal.Checked = false;
            if (CLTSel != 0)
            {
                bttGenFatt.Enabled = false;
                bttGenFatt.Visible = false;
                bttnImporta.Enabled = true;
                bttnImporta.Visible = true;
                rdbNoFatt.Checked = true;
                rdbFatt.Enabled = false;
                rdbNoFatt.Enabled = false;
                rdbTutti.Enabled = false;

                cmbCli.Tag = CLTSel;
                cmbCli.Enabled = false;
            }
            else
            {
                bttGenFatt.Enabled = true;
                bttGenFatt.Visible = true;
                bttnImporta.Enabled = false;
                bttnImporta.Visible = false;
            }
            PopolaCombo();

           
            LoadSearchRusult(true);
        }

        private void bttFind_Click(object sender, EventArgs e)
        {
            LoadSearchRusult();
        }

        private void LoadSearchRusult(bool OnlyIntestazione = false)
        {
            string strSql = " select v.ID as ID, Case When (IsNull(c.Cln_rag_soc, '') = '') Then c.Cln_nome + ' ' + c.Cln_Cognome Else c.Cln_rag_soc End as 'Cliente', a.art_cod as 'Codice Art.', v.viaggi_descrizione as Descrizione, locA.Loc_luogo as 'Da', locB.Loc_luogo as 'A', d.Dtt_distanze_km as 'Km', v.viaggi_ddt_n as 'N. ddt', v.viaggi_ddt_data as 'Data', t.truck_targa as 'Automezzo', v.viaggi_um as 'U.M.', v.viaggio_qta as 'Qta', v.viaggi_prezzo_u as 'Prezzo U.',  (v.viaggio_qta * v.viaggi_prezzo_u) as 'Imp. Tot.', case when viaggi_fatturato=0 then 'NO' else 'SI' end as 'Fatturato', viaggi_numfattura as 'N. Fatt.', viaggi_datafattura as 'Data Fatt.'" +
                                " from Viaggi v " +
                                " left join Clienti c on v.ID_cliente = c.ID" +
                                " left join Articoli a on v.ID_articoli = a.ID" +
                                " left join Dtt_distanze d on v.ID_ddt_distanze = d.ID" +
                                " left join Localita locA on d.ID_localita_A = locA.ID" +
                                " left join Localita locB on d.ID_localita_B = locB.ID" +
                                " left join Truck t on v.ID_truck = t.ID" +
                                " where viaggi_cancellato = 0 ";
            string strWhere = "";

            if (OnlyIntestazione)
                strWhere = "and c.ID = -1";

            strFiltro = "";

            if (cmbAutom.SelectedIndex > 0)
            {
                strWhere += " and t.Id = " + ((_dataItemCombo)cmbAutom.SelectedItem).Id + "";
                strFiltro += "   Automezzo: " + cmbAutom.Text;
            }

            if (cmbCli.SelectedIndex > 0)
            {
                strWhere += " and c.Id = " + ((_dataItemCombo)cmbCli.SelectedItem).Id + "";
                strFiltro += "   Cliente: " + cmbCli.Text;
            }

            if (cmbCodArt.SelectedIndex > 0)
            {
                strWhere += " and a.Id = " + ((_dataItemCombo)cmbCodArt.SelectedItem).Id + "";
                strFiltro += "   Cod. Art.: " + cmbCodArt.Text;
            }

            if (cmbTrA.SelectedIndex > 0)
            {
                //strWhere += " and (d.ID_localita_A = " + ((_dataItemCombo)cmbTrA.SelectedItem).Id + " or d.ID_localita_B = " + ((_dataItemCombo)cmbTrA.SelectedItem).Id + ")";
                strWhere += " and (d.ID_localita_B = " + ((_dataItemCombo)cmbTrA.SelectedItem).Id + ")";
                strFiltro += "   Tratta A: " + cmbTrA.Text;
            }

            if (cmbTrDa.SelectedIndex > 0)
            {
                //strWhere += " and (d.ID_localita_A = " + ((_dataItemCombo)cmbTrDa.SelectedItem).Id + " or d.ID_localita_B = " + ((_dataItemCombo)cmbTrDa.SelectedItem).Id + ")";
                strWhere += " and (d.ID_localita_A = " + ((_dataItemCombo)cmbTrDa.SelectedItem).Id + ")";
                strFiltro += "   Tratta Da: " + cmbTrDa.Text;
            }

            if (txtDescr.Text != "")
            {
                strWhere += " and v.viaggi_descrizione like '%" + txtDescr.Text.Replace("'","''") + "%'";
                strFiltro += "   Descr.: " + txtDescr.Text;
            }

            if (txtDTT.Text != "")
            {
                strWhere += " and v.viaggi_ddt_n like '%" + txtDTT.Text + "%'";
                strFiltro += "   DDT: " + txtDTT.Text;
            }

            if (rdbFatt.Checked)
            {
                strWhere += " and v.viaggi_fatturato=1";
                strFiltro += "   Fatturato: SI";
            }

            if (rdbNoFatt.Checked)
            {
                strWhere += " and v.viaggi_fatturato=0";
                strFiltro += "   Fatturato: NO";
            }

            if (dtpDataDal.Checked)
            {
                strWhere += " and v.viaggi_ddt_data >= " + clsDataBase.SQL_ConvertDateTimeToData(dtpDataDal.Value);
                strFiltro += "   Dal: " + dtpDataDal.Text;
            }

            if (dtpDataAl.Checked)
            {
                strWhere += " and v.viaggi_ddt_data <= " + clsDataBase.SQL_ConvertDateTimeToData(dtpDataAl.Value);
                strFiltro += "   Al: " + dtpDataAl.Text;
            }

            bindingSource1.DataSource = clsDataBase.GetDataTable(strSql + strWhere);
            
            dgvResult.DataSource = bindingSource1;
            dgvResult.Columns["ID"].Visible = false;
            dgvResult.Columns["Km"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.TopRight;
            dgvResult.Columns["Qta"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.TopRight;
            dgvResult.Columns["Prezzo U."].CellTemplate.Style.Alignment = DataGridViewContentAlignment.TopRight;
            dgvResult.Columns["Prezzo U."].CellTemplate.Style.Format = "C2";
            dgvResult.Columns["Imp. Tot."].CellTemplate.Style.Alignment = DataGridViewContentAlignment.TopRight;
            dgvResult.Columns["Imp. Tot."].CellTemplate.Style.Format = "C2";
            dgvResult.Columns["Fatturato"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvResult.Columns["N. Fatt."].CellTemplate.Style.Alignment = DataGridViewContentAlignment.TopRight;
            dgvResult.Columns["Data Fatt."].CellTemplate.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            for (int i=0; i<dgvResult.Columns.Count; i++)
                dgvResult.Columns[i].ReadOnly = true;

            dgvResult.Columns["ColChk"].ReadOnly = false;

            decimal totImporto = 0;
            decimal totKm = 0;
            int ii;  
            ii=1;
            foreach (DataGridViewRow objRow in dgvResult.Rows)
            {
                
                objRow.HeaderCell.Value = ii.ToString();
                objRow.HeaderCell.ToolTipText = ii.ToString();
        
                objRow.Cells["ColChk"].Value = false;
                totImporto += (decimal)objRow.Cells["Imp. Tot."].Value;
                totKm += (decimal)objRow.Cells["Km"].Value;
                ii++;
            }
            dgvResult.AutoResizeColumns();
            dgvResult.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dgvResult.RowHeadersVisible = true; 
            lblTotImporto.Text = totImporto.ToString("N2");
            lblTotKm.Text = totKm.ToString("N2");
        }

        private void bttEsci_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttNuovo_Click(object sender, EventArgs e)
        {
            frmModDocViaggi newForm = new frmModDocViaggi();
            newForm.MdiParent = this.MdiParent;
            this.Hide();
            newForm.frmParent = this;
            newForm.Show(); 
        }

        private void bttModifica_Click(object sender, EventArgs e)
        {
            if (dgvResult.CurrentRow != null)
            {

                if (dgvResult.CurrentRow.Cells["Fatturato"].Value.ToString() == "SI")
                    MessageBox.Show("Il viaggio è fatturato.\n\nImpossibile procedere ", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                frmModDocViaggi newForm = new frmModDocViaggi();
                newForm.MdiParent = this.MdiParent;
                this.Hide();
                newForm.frmParent = this;
                newForm.IdSel = Convert.ToInt32(dgvResult.CurrentRow.Cells["ID"].Value);
                newForm.Show();
                NumberAllRow();
                }
            }
            
        }

        private void bttElimina_Click(object sender, EventArgs e)
        {
            string strSql ="";
            Boolean contdel=true;
            if (dgvResult.CurrentRow != null)
            {
            if (VerificaSelCanc())
                if (MessageBox.Show("Eliminare i records selezionati ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {

                    for (int i = 0; i < dgvResult.Rows.Count && contdel; i++)
                    {
                        if (dgvResult["ColChk", i].Value != null && (bool)dgvResult["ColChk", i].Value)
                        {
                            strSql = "Update Viaggi set viaggi_cancellato=1 where id=" + Convert.ToInt32(dgvResult["ID", i].Value);
                            if (!clsDataBase.ExecuteNonQuery(strSql))
                                contdel = false;
                        }
                    }
    
                    if (contdel)
                       MessageBox.Show("records rimossi correttamente.\n\nEffettuare nuovamente la ricerca per aggiornare i dati visualizzati.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
        }

        private void dgvResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != dgvResult.Columns["ColChk"].Index)
            {
                bttModifica_Click(null, null);
                NumberAllRow();
            }
        }

        private void dgvResult_Sorted(object sender, EventArgs e)
        {
        }
 
        private void dgvResult_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvResult.RowCount > 0)
            {
                NumberAllRow();
            }


        }

        

        private void chkSelAll_CheckedChanged(object sender, EventArgs e)
        {
            nudSelRow.Enabled = !chkSelAll.Checked;
        }

        private void bttSelRow_Click(object sender, EventArgs e)
        {
            int NumRow = Convert.ToInt32(nudSelRow.Value);
            bool setValue = false;

            if (chkSelAll.Checked)
                NumRow = dgvResult.Rows.Count;
            if (dgvResult.Rows.Count > 0 && dgvResult["ColChk", 0].Value != null)
                setValue = (bool)dgvResult["ColChk", 0].Value;

            for (int i = 0; i < dgvResult.Rows.Count && i < NumRow; i++)
            {
                dgvResult["ColChk", i].Value = !setValue;
            }
        }

        private void bttGenFatt_Click(object sender, EventArgs e)
        {
            frmModFattura newForm = new frmModFattura();
            newForm.MdiParent = this.MdiParent;
            newForm.frmParent = this;

            newForm.TipoDoc = frmModFattura.ETypeDoc.TD_FAT;

            if (!VerificaSelezione())
            {
                newForm.Dispose();
                return;
            }
          
            for (int i = 0; i < dgvResult.Rows.Count; i++)
            {
                if (dgvResult["ColChk", i].Value != null && (bool)dgvResult["ColChk", i].Value)
                    newForm.InsertDettViaggio((int)dgvResult["ID", i].Value);
            }

            this.Hide();
            newForm.Show();
        }

        private bool VerificaSelezione()
        {
            bool RetValue = true;
            bool bFindCheck = false;
            bool bExit = false;
            bool IsPresentFatt = false;
            string strMessage = "";
            string strCliente = "";

            for (int i = 0; i < dgvResult.Rows.Count && !bExit; i++)
            {
                if (dgvResult["ColChk", i].Value != null && (bool)dgvResult["ColChk", i].Value)
                {
                    bFindCheck = true;
                    if (strCliente == "")
                        strCliente = dgvResult["Cliente", i].Value.ToString();
                    else
                    {
                        if (strCliente != dgvResult["Cliente", i].Value.ToString())
                            bExit = true;
                    }

                    if (dgvResult["Fatturato", i].Value.ToString() == "SI")
                        IsPresentFatt = true;
                }
            }

            if (!bFindCheck)
            {
                strMessage = "Nessun Viaggio Selezionato";
                RetValue = false;
            }

            if (bExit)
            {
                strMessage = "Sono stati selezionati viaggi attinenti a clienti diversi.\n\n Impossibile generare la fattura.";
                RetValue = false;
            }

            if (strMessage != "")
                MessageBox.Show(strMessage, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (IsPresentFatt)
                {
                    //*if (MessageBox.Show("Tra i selezionati sono presenti Viaggi già Fatturati.\n\nProcedere comunque ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                    MessageBox.Show("Tra i selezionati sono presenti Viaggi già Fatturati.\n\nImpossibile Procedere ", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    RetValue = false;
                }
            }

            return RetValue;
        }


        private bool VerificaSelCanc()
        {
            bool RetValue = true;
            bool bFindCheck = false;
            bool bExit = false;
            bool IsPresentFatt = false;
            
            for (int i = 0; i < dgvResult.Rows.Count && !bExit; i++)
            {
                if (dgvResult["ColChk", i].Value != null && (bool)dgvResult["ColChk", i].Value)
                {
                    bFindCheck = true;

                    if (dgvResult["Fatturato", i].Value.ToString() == "SI")
                    {
                        bExit = true;
                        IsPresentFatt = true;
                    }
                }
            }
            
            if (!bFindCheck)
            {
                MessageBox.Show("Nessun Viaggio Selezionato", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RetValue = false;
            }
            else
            {
                if (IsPresentFatt)
                {
                    //*if (MessageBox.Show("Tra i selezionati sono presenti Viaggi già Fatturati.\n\nProcedere comunque ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                    MessageBox.Show("Tra i selezionati sono presenti Viaggi già Fatturati.\n\nImpossibile Procedere ", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    RetValue = false;
                }
            }

            return RetValue;
        }

        private void bttStampa_Click(object sender, EventArgs e)
        {
            crpDocViaggi newReport = new crpDocViaggi();

            clsReport.InizializzaReport(newReport);
            //crClienti.RecordSelectionFormula = "id=0";

            //newReport.SetDataSource(((DataTable)(bindingSource1.DataSource)).Select("1=1", ""));
            
            DataTable dtSource = (DataTable)(bindingSource1.DataSource);
            
            if (dgvResult.SortedColumn == null)
              newReport.SetDataSource(dtSource);
            else
              newReport.SetDataSource(dtSource.Select("1=1", dgvResult.SortedColumn.Name + (dgvResult.SortOrder == SortOrder.Ascending ? " asc" : " desc").ToString()).CopyToDataTable());
              
            strFiltro = strFiltro.Trim();
            if (strFiltro == "")
                strFiltro = " ";

            clsReport.SetParamIntestazione(newReport, strFiltro);
            newReport.SetParameterValue("TipoDocumento", "Elenco Viaggi");
            clsReport.ShowReport(newReport);
        }

        private void dgvResult_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != dgvResult.Columns["ColChk"].Index)
            {
                bttModifica_Click(null, null);
                NumberAllRow();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDescr_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bttnImporta_Click(object sender, EventArgs e)
        {
            if (VerificaSelezione())
            {

                GoImport = true;
                Close();
            }
        }
        
 
    }
}
