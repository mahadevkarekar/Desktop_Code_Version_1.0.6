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
    public partial class frmDocumenti : Form
    {
        private string strFiltro = "";

        public frmDocumenti()
        {
            InitializeComponent();
        }

        private void bttEsci_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttFind_Click(object sender, EventArgs e)
        {
            LoadSearchRusult();
            RefreshTotali();
        }

        private void LoadSearchRusult(bool OnlyIntestazione = false)
        {
            string strSql = " select d.ID as ID, Case When (d.docu_xml_generato = 1) Then ' X ' Else '' End as Xml, case d.docu_Tipo when 0 then 'FAT' when 1 then 'NDC' when 2 then 'DDT' else '' end  as Tipo, d.docu_data as Data, d.docu_numero as 'Numero', Case When (IsNull(c.Cln_rag_soc, '') = '') Then c.Cln_nome + ' ' + c.Cln_Cognome Else c.Cln_rag_soc End as 'Cliente', d.docu_coeficente as 'Coefficiente'" +
                                ", (select sum(z.dtt_docu_prezzo_u * z.dtt_docu_qta) + sum(z.dtt_docu_prezzo_u * z.dtt_docu_qta * case z.dtt_docu_percent_iva when 0 then 0 else z.dtt_docu_percent_iva/100 end) as TotImp from Dtt_documenti z where z.dtt_docu_cancellato=0 and z.ID_documento = d.Id group by z.ID_documento) + d.docu_bolli as 'Tot. Importo'" +
                                ", (select sum(z1.dtt_docu_km) as TotKm from Dtt_documenti z1 where z1.dtt_docu_cancellato=0 and z1.ID_documento = d.Id group by z1.ID_documento) as 'Tot. Km'" +
            " from Documenti d " +
                                " left join Clienti c on d.ID_cliente = c.ID" +
                                " where docu_cancellato = 0 ";
            string strWhere = "";

            if (OnlyIntestazione)
                strWhere = "and d.ID = -1";

            strFiltro = "";

            //if (cmbAutom.SelectedIndex > 0)
            //    strWhere += " and t.Id = " + ((_dataItemCombo)cmbAutom.SelectedItem).Id + "";
            if (chkFat.Checked || chkNDC.Checked)
            {
                string appo = "";
                if (chkFat.Checked)
                {
                    appo = "d.docu_tipo = 0";
                    strFiltro += "   Doc.: FAT";
                }

                if (chkNDC.Checked)
                {
                    if (appo != "")
                    {
                        appo += " or d.docu_tipo = 1";
                        strFiltro += ", NDC";
                    }
                    else
                    {
                        appo = "d.docu_tipo = 1";
                        strFiltro += "   Doc.: NDC";
                    }
                }

                strWhere += " and (" + appo + ")";
            }
                
            if (cmbCli.SelectedIndex > 0)
            {
                strWhere += " and d.Id_Cliente = " + ((_dataItemCombo)cmbCli.SelectedItem).Id + "";
                strFiltro += "   Cliente: " + cmbCli.Text;
            }
            
            if (cmbCodArt.SelectedIndex > 0)
            {
                string [] strApp = ((_dataItemCombo)cmbCodArt.SelectedItem).Value.Split('-');
                strWhere += " and '" + strApp[0].Trim() + "' in (select distinct dtt_docu_cod_art from Dtt_documenti where dtt_docu_cancellato=0 and ID_documento =d.ID) ";
                strFiltro += "   Cod. Art.: " + cmbCodArt.Text;
            }

            if (cmbTrA.SelectedIndex > 0)
            {
                //strWhere += " and (" + ((_dataItemCombo)cmbTrA.SelectedItem).Id + " in (select distinct ID_distanze1 from Dtt_documenti where dtt_docu_cancellato=0 and ID_documento =d.ID) or " + ((_dataItemCombo)cmbTrA.SelectedItem).Id + " in (select distinct ID_distanze2 from Dtt_documenti where dtt_docu_cancellato=0 and ID_documento =d.ID))";
                strWhere += " and (select count(*) from Dtt_documenti where dtt_docu_cancellato=0 and ID_documento =d.ID and dtt_docu_tratta like '% - " + ((_dataItemCombo)cmbTrA.SelectedItem).Value.Replace("'", "''") + "%') > 0";
                strFiltro += "   Tratta A: " + cmbTrA.Text;
            }

            if (cmbTrDa.SelectedIndex > 0)
            {
                //strWhere += " and (" + ((_dataItemCombo)cmbTrDa.SelectedItem).Id + " in (select distinct ID_distanze1 from Dtt_documenti where dtt_docu_cancellato=0 and ID_documento =d.ID) or " + ((_dataItemCombo)cmbTrDa.SelectedItem).Id + " in (select distinct ID_distanze2 from Dtt_documenti where dtt_docu_cancellato=0 and ID_documento =d.ID))";
                strWhere += " and (select count(*) from Dtt_documenti where dtt_docu_cancellato=0 and ID_documento =d.ID and dtt_docu_tratta like '" + ((_dataItemCombo)cmbTrDa.SelectedItem).Value.Replace("'", "''") + " - %') > 0";
                strFiltro += "   Tratta Da: " + cmbTrDa.Text;
            }

            if (txtDescr.Text != "")
            {
                strWhere += " and (Select count(*) from Dtt_documenti where dtt_docu_cancellato=0 and ID_documento =d.ID and dtt_docu_descrizione like '%" + txtDescr.Text.Replace("'", "''") + "%')>0";
                strFiltro += "   Descr.: " + txtDescr.Text;
            }

            if (txtDTT.Text != "")
            {
                strWhere += " and (Select count(*) from Dtt_documenti where dtt_docu_cancellato=0 and ID_documento =d.ID and dtt_docu_ddt_n like '%" + txtDTT.Text.Replace("'", "''") + "%')>0";
                strFiltro += "   DDT: " + txtDTT.Text;
            }

            if (txtCoeff.Text != "")
            {
                strWhere += " and d.docu_coeficente = " + txtCoeff.Text.ToString().Replace(",", ".");
                strFiltro += "   Coeff.: " + txtCoeff.Text;
            }
            
            if (dtpDataDal.Checked)
            {
                strWhere += " and d.docu_data >= " + clsDataBase.SQL_ConvertDateTimeToData(dtpDataDal.Value);
                strFiltro += "   Dal: " + dtpDataDal.Text;
            }

            if (dtpDataAl.Checked)
            {
                strWhere += " and d.docu_data <= " + clsDataBase.SQL_ConvertDateTimeToData(dtpDataAl.Value);
                strFiltro += "   Al: " + dtpDataAl.Text;
            }

            if (!(dtpDataDal.Checked || dtpDataDal.Checked) && (cmbAnno.SelectedIndex > 0))
            {
              strWhere += " and Year(d.docu_data) = " + cmbAnno.SelectedItem.ToString();
              strFiltro += "   Anno: " + cmbAnno.SelectedItem.ToString();
            }

            if (cmbTruck.SelectedIndex > 0)
            {
                strWhere += " and (Select count(*) from Dtt_documenti where dtt_docu_cancellato=0 and ID_documento =d.ID and dtt_docu_truck like '%" + cmbTruck.Text.Replace("'", "''") + "%') > 0";
                strFiltro += "   Automezzo: " + cmbTruck.Text;
            }

            if (cmbXml.SelectedIndex == 1)
            {
              strWhere += " and d.docu_xml_generato = 1";
              strFiltro += "   Xml: Sì";
            }

            if (cmbXml.SelectedIndex == 2)
            {
              strWhere += " and d.docu_xml_generato = 0";
              strFiltro += "   Xml: No";
            }

            bindingSource1.DataSource = clsDataBase.GetDataTable(strSql + strWhere + " order by d.ID desc");
            dgvResult.DataSource = bindingSource1;
            dgvResult.Columns["ID"].Visible = false;
            dgvResult.Columns["Xml"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvResult.Columns["Tot. Km"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.TopRight;
            dgvResult.Columns["Tot. Importo"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.TopRight;
            dgvResult.Columns["Tot. Importo"].CellTemplate.Style.Format = "C2";
            dgvResult.Columns["Coefficiente"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.TopRight;
            for (int i = 0; i < dgvResult.Columns.Count; i++)
                dgvResult.Columns[i].ReadOnly = true;

            //dgvResult.Columns["ColChk"].ReadOnly = false;
            dgvResult.AutoResizeColumns();

        }

        private void RefreshTotali()
        {
            decimal TotKm = 0;
            decimal TotImporto = 0;
            foreach (DataGridViewRow objRow in dgvResult.Rows)
            {
                if (objRow.Cells["Tot. Km"].Value.ToString()!="")
                    TotKm += Convert.ToDecimal(objRow.Cells["Tot. Km"].Value.ToString());
                if (objRow.Cells["Tot. Importo"].Value.ToString() != "")
                    TotImporto += (decimal)objRow.Cells["Tot. Importo"].Value;
            }

            lblNumDoc.Text = dgvResult.Rows.Count.ToString();
            lblTotKm.Text = TotKm.ToString("N2");
            lblTotImporto.Text = TotImporto.ToString("N2");
        }

        private void frmDocumenti_Load(object sender, EventArgs e)
        {
            if (!this.Modal && this.MdiParent != null)
                this.WindowState = FormWindowState.Maximized;

            LoadSearchRusult(true);
            PopolaCombo();
        }

        private void PopolaCombo()
        {
            //clsDataBase.PopolaCombo(cmbAutom, clsGlobal.ETypeTable.TT_AUTOMEZZI);
            clsDataBase.PopolaCombo(cmbCli, clsGlobal.ETypeTable.TT_CLIENTI);
            clsDataBase.PopolaCombo(cmbCodArt, clsGlobal.ETypeTable.TT_ARTICOLI);
            clsDataBase.PopolaCombo(cmbTrA, clsGlobal.ETypeTable.TT_LOCALITA);
            clsDataBase.PopolaCombo(cmbTrDa, clsGlobal.ETypeTable.TT_LOCALITA);
            clsDataBase.PopolaCombo(cmbTruck, clsGlobal.ETypeTable.TT_AUTOMEZZI);

            cmbAnno.Items.Clear();

            cmbAnno.Items.Add("");
            for (int i = DateTime.Now.Year + 3; i >= 2011 ; i--)
            {
              if (i == DateTime.Now.Year)
                cmbAnno.SelectedIndex = cmbAnno.Items.Add(i);
              else
                cmbAnno.Items.Add(i);
            }

        }
        private Boolean Del_Dettaglio()
        {
            int idviaggio= 0;
            string strSql = "select * from dtt_documenti where id_documento = " + dgvResult.CurrentRow.Cells["ID"].Value.ToString();
            int dbReaderIndex = clsDataBase.GetFreeDbReaderIndex();
            if (clsDataBase.ExecuteQuery(strSql, dbReaderIndex))
            {
                while (clsDataBase.vetDbReader[dbReaderIndex].Read())
                {
                    //Aggiorno i campo nella tabella viaggi
                    idviaggio = clsDataBase.GetIntValue("dtt_id_viaggio", dbReaderIndex);
                    if (idviaggio > 0)
                    {
                        strSql = "update Viaggi set viaggi_fatturato = 0, viaggi_numfattura = null, viaggi_datafattura = null where Id=" + idviaggio.ToString();
                        clsDataBase.ExecuteNonQuery(strSql );
                    }
                }
                
                //Devo Eliminare il record
                strSql = "Delete Dtt_documenti where Id_Documento =" + dgvResult.CurrentRow.Cells["ID"].Value.ToString();
                clsDataBase.ExecuteNonQuery(strSql);                        

            }
            clsDataBase.CloseDataReader(dbReaderIndex);

            return true;
        }
        private void bttModifica_Click(object sender, EventArgs e)
        {
            frmModFattura frmNew = new frmModFattura();
            frmNew.MdiParent = this.MdiParent;
            frmNew.frmParent = this;
            frmNew.IdSel = (int)dgvResult["ID", dgvResult.CurrentRow.Index].Value;

            this.Hide();
            frmNew.Show();
        }

        private void dgvResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bttModifica_Click(null, null);
        }

        private void bttNuovaFat_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Form childForm in this.MdiParent.MdiChildren)
            {
                if (childForm.GetType().ToString() == "Trucks.frmModFattura")
                {
                    MessageBox.Show("Finestra Fatture/Note di Credito già aperta.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    childForm.Focus();
                    count++;
                }
            }
            if (count == 0)
            {
                Form childForm = new frmModFattura();
                childForm.MdiParent = this.MdiParent;
                ((frmModFattura)childForm).frmParent = this;
                this.Hide();
                childForm.Show();
            }
        }

        private void bttStampa_Click(object sender, EventArgs e)
        {
            crpDocumenti newReport = new crpDocumenti();

            clsReport.InizializzaReport(newReport);
            //crClienti.RecordSelectionFormula = "id=0";

            newReport.SetDataSource((DataTable)(bindingSource1.DataSource));

            strFiltro = strFiltro.Trim();
            if (strFiltro == "")
                strFiltro = " ";

            clsReport.SetParamIntestazione(newReport, strFiltro);
            newReport.SetParameterValue("TipoDocumento", "Elenco Documenti");
            clsReport.ShowReport(newReport);
        }

        private void bttElimina_Click(object sender, EventArgs e)
        {
            string strSql = "";
            bool bError = false;

            if (dgvResult.CurrentRow != null)
            {
                strSql = "Select max(id) from Documenti where docu_cancellato=0";
                if ((int)dgvResult.CurrentRow.Cells["ID"].Value == (int)clsDataBase.ExecuteScalar(strSql))
                {
                    if (MessageBox.Show("Richiesta eliminazione del documento\n\n    Num.:" + dgvResult.CurrentRow.Cells["Numero"].Value.ToString() + "   del " + dgvResult.CurrentRow.Cells["Data"].Value.ToString().Substring(0,10) +"\n\n Procedere con l'eliminazione ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        
                        if (dgvResult.CurrentRow.Cells["Tipo"].Value.ToString() == "FAT")
                        {
                            //eliminazione delle righe di dettaglio ed aggiornamento dei campi nella tabella viaggi
                            bError = Del_Dettaglio();

                        }
                        strSql = "Update Documenti set docu_cancellato=1 where id=" + dgvResult.CurrentRow.Cells["ID"].Value.ToString();
                        bError = !clsDataBase.ExecuteNonQuery(strSql);
                        if (!bError)
                        {
                            strSql = "Update Parametri set last_num_fattura = (select docu_numero from documenti where id = (select MAX(id) from Documenti where docu_cancellato=0)), last_date_fattura = (select docu_data from documenti where id = (select MAX(id) from Documenti where docu_cancellato=0))";
                            bError = !clsDataBase.ExecuteNonQuery(strSql);
                        }
                        if (bError)
                            MessageBox.Show("Rilevato errore nell'aggiornamento del DB. \nVerificare la congruenza dei dati nel database.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            MessageBox.Show("Documento eliminato correttamente.\nEffettuare nuovamente la ricerca per aggiornare l'elenco dei risultati.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bttFind_Click(null, null);
                        }
                    }
                }
                else
                    MessageBox.Show("Impossibile eliminare il documento selezionato.\nE' possibile eliminare solo l'ultimo documento emesso.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Nessun documento è stato selezionato.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void bttClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            //dgvResult.Rows.Clear();
            

            chkFat.Checked = chkNDC.Checked = chkNDB.Checked = chkDDT.Checked = false;

            cmbCli.SelectedIndex = 0;
            cmbCodArt.SelectedIndex = 0;
            cmbTrA.SelectedIndex = 0;
            cmbTrDa.SelectedIndex = 0;
            txtDescr.Text = "";
            txtDTT.Text = "";
            txtCoeff.Text = "";
            dtpDataDal.Checked = dtpDataAl.Checked = false;
            
            LoadSearchRusult(true);
        }

        private void txtCoeff_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !clsGlobal.IsDecimal(e.KeyChar);
            if (!e.Handled)
                e.Handled = (e.KeyChar == '.' && txtCoeff.Text.IndexOf(".") > -1);
        }

        private void bttNuovaNDC_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Form childForm in this.MdiParent.MdiChildren)
            {
                if (childForm.GetType().ToString() == "Trucks.frmModFattura")
                {
                    MessageBox.Show("Finestra Fatture/Note di Credito già aperta.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    childForm.Focus();
                    count++;
                }
            }
            if (count == 0)
            {
                Form childForm = new frmModFattura();
                childForm.MdiParent = this.MdiParent;
                ((frmModFattura)childForm).frmParent = this;
                ((frmModFattura)childForm).TipoDoc = frmModFattura.ETypeDoc.TD_NDC;
                this.Hide();
                childForm.Show();
            }
        }

        private void dgvResult_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bttModifica_Click(null, null);
        }

        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpDataDal_ValueChanged(object sender, EventArgs e)
        {
          cmbAnno.SelectedIndex = 0;
        }

        private void dtpDataAl_ValueChanged(object sender, EventArgs e)
        {
          cmbAnno.SelectedIndex = 0;
        }

        private void cmbAnno_SelectedValueChanged(object sender, EventArgs e)
        {
          if (cmbAnno.SelectedIndex > 0)
          {
            dtpDataDal.Checked = false;
            dtpDataAl.Checked = false;
          }
        }
    }
}
