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
    public partial class frmModFattura : Form
    {      

        public enum ETypeDoc
        {
            TD_FAT = 0,
            TD_NDC = 1
        }

        public int IdSel = 0;
        public ETypeDoc TipoDoc = ETypeDoc.TD_FAT;
        public Form frmParent = null;

        public frmModFattura()
        {
            InitializeComponent();
        }

        private void frmModFattura_Load(object sender, EventArgs e)
        {
            if (!this.Modal && this.MdiParent != null)
                this.WindowState = FormWindowState.Maximized;

            this.WindowState = FormWindowState.Maximized;

            //imposto i limiti per la data
            clsDataBase.GetIntervalDateNumFattura(IdSel, dtpData);

            //Provo a impostare combobox nella tabella
            
            clsDataBase.PopolaCombo((DataGridViewComboBoxColumn)dgvResult.Columns["ColCod"], clsGlobal.ETypeTable.TT_ARTICOLI);


            if (IdSel > 0)
            {                
                LoadDocumento(IdSel);
            }
            else
            {                
                dtpData.Value = DateTime.Today;
                txtNote.Text = clsSetting.param_note_fattura;
                nudCoeff.Value = clsSetting.param_coefficente;
                EnableCommand(false);
                PopolaCombo();
            }
            

            if (TipoDoc == ETypeDoc.TD_FAT)
                txtTipoDoc.Text = "Fattura";
            else
                txtTipoDoc.Text = "Nota di Credito";
        }

        private void EnableCommand(bool Value)
        {
            bttStampa.Enabled = bttPDF.Enabled = Value;            
        }

        private bool LoadDocumento(int IdDoc)
        {
            bool bRet = false;
            string strSql = "Select Id, docu_numero, ID_cliente, docu_data, ID_tipi_pagamento, docu_coeficente, docu_bolli, docu_note, docu_tipo, docu_esenzione, Id_banca_az, docu_cl_abi, docu_cl_cab from Documenti where ID=" + IdDoc.ToString();

            if (clsDataBase.ExecuteQuery(strSql))
            {
                if (clsDataBase.vetDbReader[0].Read())
                {
                    txtNum.Text = GeneraCodiceFat(clsDataBase.GetDateValue("docu_data").ToString("yyyy"), clsDataBase.GetIntValue("docu_numero"));

                    cmbCliente.Tag = clsDataBase.GetIntValue("ID_cliente");
                    dtpData.Value =  clsDataBase.GetDateValue("docu_data");
                    cmbTipPag.Tag = clsDataBase.GetIntValue("ID_tipi_pagamento");
                    nudCoeff.Value = clsDataBase.GetDecimalValue("docu_coeficente");
                    nudBolli.Value = clsDataBase.GetValutaValue("docu_bolli");
                    txtNote.Text = clsDataBase.GetStringValue("docu_note");
                    TipoDoc = (ETypeDoc)clsDataBase.GetIntValue("docu_tipo");
                    txtEsenzione.Text = clsDataBase.GetStringValue("docu_esenzione");

                    PopolaCombo();
                    cmbBancaAz.Tag = clsDataBase.GetIntValue("Id_banca_az");
                    txtABI.Text = clsDataBase.GetStringValue("docu_cl_abi");
                    txtCAB.Text = clsDataBase.GetStringValue("docu_cl_cab");
                    clsDataBase.PopolaCombo(cmbBancaAz, clsGlobal.ETypeTable.TT_BANCHE_AZ);
                    bRet = true;
                }
            }

            clsDataBase.CloseDataReader();
            
            if(bRet)
            {       
                //Carico lista voci
                bRet = (LoadListaDettaglio(IdDoc));
                CalcolaRiepilogo();
            }
            return bRet;
        }

        private string GeneraCodiceFat(string Anno, int Numero)
        { 
            string RetValue = "";
            //RetValue = Anno + "_" + Numero.ToString("{0:00000}");
            RetValue = Anno + "_" + Numero.ToString("000000");

            return RetValue;
        }

        private bool LoadListaDettaglio(int IdDoc)
        {
            bool bRet = false;

            string strSql = "Select d.ID, d.ID_documento,d.ID_articoli,d.ID_distanze1,d.ID_distanze2,d.ID_truck,d.dtt_docu_ddt_n,d.dtt_docu_ddt_data,d.dtt_docu_descrizione,d.dtt_docu_qta,d.dtt_docu_um,d.dtt_docu_prezzo_u,d.dtt_docu_percent_iva,d.dtt_docu_costo_gasolio,d.dtt_docu_km, d.dtt_docu_pos, a.art_cod, d.dtt_descr_viaggio, d.dtt_descr_articolo, d.dtt_descr_truck from Dtt_documenti d left join Articoli a on d.ID_articoli=a.Id where dtt_docu_cancellato=0 and ID_documento =" + IdDoc.ToString() + " Order by dtt_docu_pos asc";
            if (clsDataBase.ExecuteQuery(strSql))
            {
                while (clsDataBase.vetDbReader[0].Read())
                {
                    int IdRow = dgvResult.Rows.Add();
                    dgvResult["ColID", IdRow].Value = clsDataBase.GetIntValue("ID");
                    dgvResult["ColCod", IdRow].Value = clsDataBase.GetStringValue("art_cod");
                    dgvResult["ColDescr", IdRow].Value = clsDataBase.GetStringValue("dtt_docu_descrizione");
                    dgvResult["ColQta", IdRow].Value = clsDataBase.GetValutaValue("dtt_docu_qta");
                    dgvResult["ColUM", IdRow].Value = clsDataBase.GetStringValue("dtt_docu_um");
                    dgvResult["colPrezzo", IdRow].Value = clsDataBase.GetValutaValue("dtt_docu_prezzo_u");
                    dgvResult["ColIva", IdRow].Value = clsDataBase.GetValutaValue("dtt_docu_percent_iva");
                    dgvResult["ColGasolio", IdRow].Value = clsDataBase.GetValutaValue("dtt_docu_costo_gasolio");
                    dgvResult["ColKM", IdRow].Value = clsDataBase.GetValutaValue("dtt_docu_km");
                    dgvResult["ColTot", IdRow].Value = Math.Round(clsDataBase.GetValutaValue("dtt_docu_prezzo_u") * clsDataBase.GetValutaValue("dtt_docu_qta"), 2);
                    if (dgvResult["ColKM", IdRow].Value != null)
                        dgvResult["ColGasolio", IdRow].Value = Math.Round((decimal)dgvResult["ColKM", IdRow].Value * nudCoeff.Value, 2);
                    else
                        dgvResult["ColGasolio", IdRow].Value = 0;
                    
                    dgvResult["ColViaggio", IdRow].Value = clsDataBase.GetStringValue("dtt_descr_viaggio");
                    dgvResult["ColArt", IdRow].Value = clsDataBase.GetStringValue("dtt_descr_articolo");
                    dgvResult["ColTruck", IdRow].Value= clsDataBase.GetStringValue("dtt_descr_truck");
                    
                    //Popolo la struttura Viaggi di riferimento

                    //clsGlobal._Viaggio NewInfoViaggio = new clsGlobal._Viaggio();
                    //NewInfoViaggio.Id_Articolo = clsDataBase.GetIntValue("ID_articoli");
                    //NewInfoViaggio.Id_LocalitaA = clsDataBase.GetIntValue("ID_distanze1");
                    //NewInfoViaggio.Id_LocalitaB = clsDataBase.GetIntValue("ID_distanze2");
                    //NewInfoViaggio.ID_Truck = clsDataBase.GetIntValue("ID_truck");
                    //NewInfoViaggio.Num_Viaggio = clsDataBase.GetStringValue("dtt_docu_um");
                    //NewInfoViaggio.Data = clsDataBase.GetDateValue("dtt_docu_ddt_data");
                    //NewInfoViaggio.Descr = clsDataBase.GetStringValue("dtt_docu_descrizione");
                    //NewInfoViaggio.Qta = clsDataBase.GetValutaValue("dtt_docu_qta");
                    //NewInfoViaggio.Um = clsDataBase.GetStringValue("dtt_docu_um");
                    //NewInfoViaggio.Prezzo = clsDataBase.GetValutaValue("dtt_docu_prezzo_u");
                    //NewInfoViaggio.IVA = clsDataBase.GetValutaValue("dtt_docu_percent_iva"); 
                    //NewInfoViaggio.KM = clsDataBase.GetValutaValue("dtt_docu_km");
                }
            }
            else
                bRet = false;

            clsDataBase.CloseDataReader();

            return bRet;
        }

        public bool InsertDettViaggio(int idViaggio, int IndexRow = -1)
        {
            bool bRet = false;
            int IdRow = IndexRow;

            string strSql = "Select v.ID,v.ID_cliente,v.ID_articoli,v.ID_ddt_distanze,v.ID_truck,v.viaggi_ddt_n,v.viaggi_ddt_data,v.viaggi_descrizione,v.viaggio_qta,v.viaggi_um,v.viaggi_prezzo_u,v.viaggi_percent_iva,v.viaggi_note, d.ID_localita_A, d.ID_localita_B, d.Dtt_distanze_km, a.art_cod, a.art_descrizione, (select locA.Loc_luogo + ' - ' + locB.Loc_luogo from Localita locA, Localita locB where locA.Id=d.ID_localita_A and locB.Id=d.ID_localita_B) as DescrViaggio, t.truck_targa" +
            " from Viaggi v left join Dtt_distanze d on v.ID_ddt_distanze=d.ID left join Articoli a on v.ID_articoli=a.ID left join truck t on t.ID=v.ID_truck" +
            " Where v.ID = " + idViaggio.ToString();
            
            if (IndexRow == -1)
                IdRow = dgvResult.Rows.Add();

            if (!clsDataBase.ExecuteQuery(strSql))
                return bRet;
            if (clsDataBase.vetDbReader[0].Read())
            {
                dgvResult["ColIdViaggio", IdRow].Value = idViaggio;
                dgvResult["ColCod", IdRow].Value = clsDataBase.GetStringValue("art_cod");
                dgvResult["ColArt", IdRow].Value = clsDataBase.GetStringValue("art_cod") + " - " + clsDataBase.GetStringValue("art_descrizione");
                
                dgvResult["ColDescr", IdRow].Value= clsDataBase.GetStringValue("viaggi_descrizione");

                dgvResult["ColViaggio", IdRow].Value = clsDataBase.GetStringValue("DescrViaggio");
                dgvResult["ColTruck", IdRow].Value = clsDataBase.GetStringValue("truck_targa");

                dgvResult["ColQta", IdRow].Value=clsDataBase.GetValutaValue("viaggio_qta");
                dgvResult["ColUM", IdRow].Value = clsDataBase.GetStringValue("viaggi_um");
                dgvResult["colPrezzo", IdRow].Value = clsDataBase.GetValutaValue("viaggi_prezzo_u");
                dgvResult["ColIva", IdRow].Value = clsDataBase.GetValutaValue("viaggi_percent_iva"); ;
                dgvResult["ColKM", IdRow].Value = clsDataBase.GetValutaValue("Dtt_distanze_km");
                dgvResult["ColTot", IdRow].Value = Math.Round(clsDataBase.GetValutaValue("viaggi_prezzo_u") * clsDataBase.GetValutaValue("viaggio_qta"), 2);
                //dgvResult["ColGasolio", IdRow].Value = clsSetting.param_prezzo_carburante;
                if (dgvResult["ColKM", IdRow].Value != null)
                    dgvResult["ColGasolio", IdRow].Value = Math.Round((decimal)dgvResult["ColKM", IdRow].Value * nudCoeff.Value, 2);
                else
                    dgvResult["ColGasolio", IdRow].Value = 0;

                if (IndexRow == -1 && IdRow == 0)
                { 
                    //Popolo anche altri parametri generici
                    cmbCliente.Tag = clsDataBase.GetIntValue("ID_cliente");
                }
            }
            clsDataBase.CloseDataReader();

            if (IndexRow == -1 && IdRow == 0 && cmbCliente.Tag!= null)
                clsDataBase.PopolaCombo(cmbCliente, clsGlobal.ETypeTable.TT_CLIENTI);
            
            bRet = true;
            return bRet;
        }

        private void PopolaCombo()
        {
            clsDataBase.PopolaCombo(cmbCliente, clsGlobal.ETypeTable.TT_CLIENTI);
            clsDataBase.PopolaCombo(cmbTipPag, clsGlobal.ETypeTable.TT_TIP_PAGAMENTO);
            clsDataBase.PopolaCombo(cmbBancaAz, clsGlobal.ETypeTable.TT_BANCHE_AZ);
        }

        private void bttEsci_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chiudere la finestra corrente", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                Close();
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Salvare le modifiche apportate ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!VerificaCampi()) return;

                if (!DeleteScadenze(IdSel))
                {
                    MessageBox.Show("Impossibile apportare le modifiche.\n Per il presente documento sono presenti scadenze con incassi già avvenuti", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (SaveFattura())
                {
                    bool IsOk = true;
                    if (cmbTipPag.SelectedIndex > 0)
                        IsOk = SaveScadenze(IdSel);
                    else
                        IsOk = SaveScadenzaDefault(IdSel);
                    
                    if (IsOk)
                    {
                        MessageBox.Show("Aggiornamento effettuato.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EnableCommand(true);
                    }
                    else
                    {
                        MessageBox.Show("La Fattura è stata salvata, ma si sono presentati degli errori nel salvataggio delle scadenze di pagamento.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private bool VerificaCampi()
        {
            bool bRetValue = true;
            string strErrore = "";

            if (cmbCliente.SelectedIndex < 1) strErrore += "Richiesto inserimento Cliente\n";
            //if (cmbTipPag.SelectedIndex < 1) strErrore += "Richiesto insserimento Modalità di Pagamento\n";
            if (dgvResult.Rows.Count == 0) strErrore += "Richiesto inserimento di almeno una Voce \n";
            
            if (strErrore != "")
            {
                MessageBox.Show("Verificare i parametri inseriti:\n\n" + strErrore, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bRetValue = false;
            }

            return bRetValue;
        }

        private bool SaveFattura()
        {
            bool RetValue = false;
            string strSql = "";
            string strBancaAppoggio = "";

            if (grpbBanca.Enabled)
            {
                if (pnlBancaAz.Visible)
                    strBancaAppoggio = "IBAN: " + txtIbanAz.Text;
                else
                    strBancaAppoggio = "ABI: " + txtABI.Text + "  CAB: " + txtCAB.Text;
            }

            if (IdSel > 0)
            {
                //Update
                strSql = "Update Documenti set " +
                            "ID_cliente = " + ((_dataItemCombo)cmbCliente.SelectedItem).Id.ToString() + "" +
                            ", docu_data = " + clsDataBase.SQL_ConvertDateTimeToData(dtpData.Value) + "" +
                            ", ID_tipi_pagamento = " + ((_dataItemCombo)cmbTipPag.SelectedItem).Id.ToString() + "" +
                            ", docu_coeficente = " + nudCoeff.Value.ToString().Replace(",", ".") + "" +
                            ", docu_bolli = " + nudBolli.Value.ToString().Replace(",", ".") + "" +
                            ", docu_note = '" + txtNote.Text.Replace("'", "''") + "'" +
                            ", docu_tipo = " + TipoDoc.GetHashCode().ToString() + 
                            ", docu_esenzione = '" + txtEsenzione.Text.Replace("'", "''") + "'" +

                            ", Id_banca_az = " + ((_dataItemCombo)cmbBancaAz.SelectedItem).Id.ToString() + "" +
                            ", docu_cl_abi = '" + txtABI.Text + "'" +
                            ", docu_cl_cab = '" + txtCAB.Text + "'" +
                            ", docu_banca_app = '" + strBancaAppoggio + "'" +

                            " Where id= " + IdSel.ToString();
            }
            else
            {
                //Insert

                strSql = "Insert into Documenti (ID_cliente, docu_data, ID_tipi_pagamento, docu_coeficente, docu_bolli, docu_note, docu_tipo, docu_esenzione, Id_banca_az, docu_cl_abi, docu_cl_cab, docu_banca_app) values (" +
                            //clsDataBase.GetNextNumFattura() +
                            " " + ((_dataItemCombo)cmbCliente.SelectedItem).Id.ToString() + "" +
                            ", " + clsDataBase.SQL_ConvertDateTimeToData(dtpData.Value) + "" +
                            ", " + ((_dataItemCombo)cmbTipPag.SelectedItem).Id.ToString() + "" +
                            ", " + nudCoeff.Value.ToString().Replace(",", ".") + "" +
                            ", " + nudBolli.Value.ToString().Replace(",", ".") + "" +
                            ", '" + txtNote.Text.Replace("'", "''") + "'" +
                            ", " + TipoDoc.GetHashCode().ToString() + 
                            ", '" + txtEsenzione.Text.Replace("'", "''") + "'" +
                            ", " + ((_dataItemCombo)cmbBancaAz.SelectedItem).Id.ToString() + "" +
                            ", '" + txtABI.Text + "'" +
                            ", '" + txtCAB.Text + "'" +
                            ", '" + strBancaAppoggio + "'" +
                            ")";                        
            }

            if (clsDataBase.ExecuteNonQuery(strSql))
            {
                //Acquisisco ID record salvato
                if (IdSel == 0)
                {
                    strSql = "Select max(id) from Documenti";
                    IdSel = (int)clsDataBase.ExecuteScalar(strSql);
                    //Imposto numero fattura
                    txtNum.Text = GeneraCodiceFat(dtpData.Value.ToString("yyyy"), clsDataBase.SetNumFattura(IdSel, dtpData.Value));
                    //strSql = "Select docu_numero from Documenti where id=" + IdSel.ToString();
                    //txtNum.Text = clsDataBase.ExecuteScalar(strSql).ToString();
                }

                //devo effettuare la sola insert del dettaglio documento
                //gli aggiornamenti sono salvati al momento della modifica stessa
                bool bRet = true;
                for (int i = 0; i < dgvResult.Rows.Count && bRet; i++)
                {
                    if (dgvResult["ColIdViaggio", i].Value != null)
                        bRet = InsertDttDocumento(i);
                    else
                        bRet = UpdateDttDocumento(i);
                    if (bRet && dgvResult["ColIdViaggio", i].Value != null && (int)dgvResult["ColIdViaggio", i].Value > 0)
                    {
                        //Impost viaggio come fatturato
                        strSql = "Update Viaggi set viaggi_fatturato=1 where id=" + dgvResult["ColIdViaggio", i].Value.ToString();
                        clsDataBase.ExecuteNonQuery(strSql);
                    }
                }
                RetValue = bRet;
            }

            return RetValue;
        }

        private bool DeleteScadenze(int IdFattura)
        {
            bool RetValue = false;

            string strSql = "select count(*) from Scadenze where ID_documento = " + IdFattura.ToString() + " and Scandenza_incassato > 0";
            if ((int)clsDataBase.ExecuteScalar(strSql)>0)
                return RetValue;

            strSql = "Delete Scadenze where ID_documento = " + IdFattura.ToString();
            RetValue = clsDataBase.ExecuteNonQuery(strSql);
            
            return RetValue;
        }

        private bool SaveScadenze(int idFattura)
        {
            bool RetValue = false;
            string strSql = "";

            if (idFattura < 1) return RetValue;
            
            strSql = "SELECT" +
                          " t.Tipi_pagam_descr" +
                          ", t.Tipi_pagam_fine_mese" +
                          ", t.Tipi_pagam_data_fattura" +
                          ", t.Tipi_pagamento_immediato" +
                          ", t.tipi_pagam_stampa_cliente" +
                          ", t.tipi_pagam_stampa_az" +
                          ", t.Tipi_pagam_cancellato" +
                          ", d.Dtt_tipi_pagamento_gg" +
                          ", d.Dtt_tipi_pagamento_percent" +
                          ", d.Dtt_tipi_pagamento_cancellato" +
                    " FROM Tipi_pagamento t" +
                         " left join Dtt_Tipi_pagamento d on d.ID_Tipi_pagamento=t.Id and d.Dtt_tipi_pagamento_cancellato = 0" +
                    " WHERE t.ID=" + ((_dataItemCombo)cmbTipPag.SelectedItem).Id +"";

            if (clsDataBase.ExecuteQuery(strSql))
            {
                RetValue = true;
                while (clsDataBase.vetDbReader[0].Read() && RetValue)
                { 
                    DateTime DataScadenza = dtpData.Value;
                    if (!clsDataBase.GetBoolValue("Tipi_pagam_data_fattura") && !clsDataBase.GetBoolValue("Tipi_pagam_fine_mese"))
                    {
                        strSql = "Insert into Scadenze (ID_documento, Scadenza_data, Scadenza_importo, Scandenza_incassato, Scandenza_incassato_data, Scadenza_saldata) values (" +
                               IdSel +
                               ", " + clsDataBase.SQL_ConvertDateTimeToData(DataScadenza) +
                               ", " + lblTotLordo.Text.Replace(",", ".") +
                               ", " + lblTotLordo.Text.Replace(",", ".") +
                               ", " + clsDataBase.SQL_ConvertDateTimeToData(DateTime.Today) +
                               ", 1" +
                               ")";

                    }
                    else
                    {
                        if (clsDataBase.GetBoolValue("Tipi_pagam_data_fattura"))
                            DataScadenza = DataScadenza.AddDays(clsDataBase.GetIntValue("Dtt_tipi_pagamento_gg"));

                        if (clsDataBase.GetBoolValue("Tipi_pagam_fine_mese"))
                        {
                            DataScadenza = DataScadenza.AddDays(1 - DataScadenza.Day);
                            DataScadenza = DataScadenza.AddMonths(1);
                            DataScadenza = DataScadenza.AddDays(clsDataBase.GetIntValue("Dtt_tipi_pagamento_gg"));
                        }

                        decimal ScadImporto = Math.Round(Convert.ToDecimal(lblTotLordo.Text) * clsDataBase.GetValutaValue("Dtt_tipi_pagamento_percent") / 100, 2);


                        strSql = "Insert into Scadenze (ID_documento, Scadenza_data, Scadenza_importo) values (" +
                               IdSel +
                               ", " + clsDataBase.SQL_ConvertDateTimeToData(DataScadenza) +
                               ", " + Math.Round(ScadImporto, 2).ToString().Replace(",", ".") +
                               ")";
                    }
                    
                    RetValue = clsDataBase.ExecuteNonQuery(strSql);
                }
            }
            clsDataBase.CloseDataReader();
        
            return RetValue;
        }

        private bool SaveScadenzaDefault(int idFattura)
        {
            bool RetValue = false;
            string strSql = "";

            if (idFattura < 1) return RetValue;

            DateTime DataScadenza = dtpData.Value;
            strSql = "Insert into Scadenze (ID_documento, Scadenza_data, Scadenza_importo) values (" +
                    IdSel +
                    ", " + clsDataBase.SQL_ConvertDateTimeToData(DataScadenza) +
                    ", " + lblTotLordo.Text.Replace(",", ".") +
                    ")";

            RetValue = clsDataBase.ExecuteNonQuery(strSql);

            return RetValue;
        }

        private void CalcolaRiepilogo()
        {
            decimal dImponibile = 0;
            decimal dIva = 0;

            dgvIVA.Rows.Clear();

            foreach (DataGridViewRow objRow in dgvResult.Rows)
            {
                if (objRow.Visible)
                {
                    if (objRow.Cells["ColTot"].Value != null)
                        dImponibile += Convert.ToDecimal(objRow.Cells["ColTot"].Value.ToString().Replace(".", ","));
                    if (objRow.Cells["ColTot"].Value != null && objRow.Cells["ColIva"].Value!= null)
                        dIva += Convert.ToDecimal(objRow.Cells["ColTot"].Value.ToString()) * Convert.ToDecimal(objRow.Cells["ColIva"].Value.ToString()) / 100;

                    //if (objRow.Cells["ColIva"].Value != null && objRow.Cells["ColTot"].Value != null)
                    //{
                        bool isGest = false;
                        for (int i = 0; i < dgvIVA.Rows.Count && !isGest; i++)
                        {
                            if (objRow.Cells["ColIva"].Value == null) objRow.Cells["ColIva"].Value = "0,00";
                            if (objRow.Cells["ColTot"].Value == null) objRow.Cells["ColTot"].Value = "0,00";

                            if (objRow.Cells["ColIva"].Value.ToString() == dgvIVA[0, i].Value.ToString())
                            {
                                dgvIVA[1, i].Value = Convert.ToDecimal(dgvIVA[1, i].Value.ToString()) + Convert.ToDecimal(objRow.Cells["ColTot"].Value.ToString());
                                isGest = true;
                            }
                        }
                        if (!isGest)
                            dgvIVA.Rows.Add(objRow.Cells["ColIva"].Value, objRow.Cells["ColTot"].Value);
                    //}
                }
            }

            lblImponibile.Text = Math.Round(dImponibile, 2).ToString();
            lblImportoIva.Text = Math.Round(dIva, 2).ToString();
            lblTotLordo.Text = Math.Round(dImponibile + dIva + nudBolli.Value, 2).ToString();
        }

        private bool InsertDttDocumento(int IdRow)
        {
            bool bRet = false;
            string strSql = "";
            int idViaggio = Convert.ToInt32(dgvResult["ColIdViaggio", IdRow].Value.ToString());

            //Carico Infro viaggio per preparare la insert
            strSql = "Select v.ID,v.ID_cliente,v.ID_articoli,v.ID_ddt_distanze,v.ID_truck,v.viaggi_ddt_n,v.viaggi_ddt_data,v.viaggi_descrizione,v.viaggio_qta,v.viaggi_um,v.viaggi_prezzo_u,v.viaggi_percent_iva,v.viaggi_note, d.ID_localita_A, d.ID_localita_B, d.Dtt_distanze_km" +
                        " from Viaggi v left join Dtt_distanze d on v.ID_ddt_distanze=d.ID" +
                        " Where v.ID = " + idViaggio.ToString();
            if (!clsDataBase.ExecuteQuery(strSql))
                return bRet;
            if (!clsDataBase.vetDbReader[0].Read())
                return bRet;

            strSql = "Insert into Dtt_documenti (ID_documento,ID_articoli,ID_distanze1,ID_distanze2,ID_truck,dtt_docu_ddt_n,dtt_docu_ddt_data,dtt_docu_descrizione,dtt_docu_qta,dtt_docu_um,dtt_docu_prezzo_u,dtt_docu_percent_iva,dtt_docu_costo_gasolio,dtt_docu_km, dtt_docu_pos, dtt_descr_viaggio, dtt_descr_articolo, dtt_descr_truck) values (" +
                                    "" + IdSel.ToString() + "" +
                                    ", " + clsDataBase.GetIntValue("ID_articoli") + "" +
                                    ", " + clsDataBase.GetIntValue("ID_localita_A") + "" +
                                    ", " + clsDataBase.GetIntValue("ID_localita_B") + "" +
                                    ", " + clsDataBase.GetIntValue("ID_truck") + "" +
                                    ", '" + clsDataBase.GetStringValue("viaggi_ddt_n") + "'";
            if (clsDataBase.GetDateValue("viaggi_ddt_data") == DateTime.MinValue)
                strSql +=           ", null";
            else
                strSql +=           ", " + clsDataBase.SQL_ConvertDateTimeToData(clsDataBase.GetDateValue("viaggi_ddt_data")) + "";

            strSql +=               ", '" + dgvResult["ColDescr", IdRow].Value.ToString().Replace("'", "''") + "'" +
                                    ", " + dgvResult["ColQta", IdRow].Value.ToString().Replace(",", ".") + "" +
                                    ", '" + dgvResult["ColUM", IdRow].Value.ToString().Replace("'", "''") + "'" +
                                    ", " + dgvResult["colPrezzo", IdRow].Value.ToString().Replace(",", ".") + "" +
                                    ", " + dgvResult["ColIva", IdRow].Value.ToString().Replace(",", ".") + "" +
                                    ", " + dgvResult["ColGasolio", IdRow].Value.ToString().Replace(",", ".") + "" +
                                    ", " + dgvResult["ColKM", IdRow].Value.ToString().Replace(",", ".") + "" +
                                    ", " + IdRow.ToString() + "" +
                                    ", '" + dgvResult["ColViaggio", IdRow].Value.ToString().Replace("'", "''") + "'" +
                                    ", '" + dgvResult["ColArt", IdRow].Value.ToString().Replace("'", "''") + "'" +
                                    ", '" + dgvResult["ColTruck", IdRow].Value.ToString().Replace("'", "''") + "'" +
                                    ")";

            
            clsDataBase.CloseDataReader();
            if (clsDataBase.ExecuteNonQuery(strSql))
            {
                bRet = true;
                //EnableCommand(true);
            }
            return bRet;
        }

        private bool UpdateDttDocumento(int IdRow)
        {
            string strSql = "Update Dtt_documenti set " +
                                    " dtt_docu_descrizione= '" + dgvResult["ColDescr", IdRow].Value.ToString().Replace("'", "''") + "'" +
                                    ", dtt_docu_qta= " + dgvResult["ColQta", IdRow].Value.ToString().Replace(",", ".") + "" +
                                    ", dtt_docu_um='" + dgvResult["ColUM", IdRow].Value.ToString().Replace("'", "''") + "'" +
                                    ", dtt_docu_prezzo_u=" + dgvResult["colPrezzo", IdRow].Value.ToString().Replace(",", ".") + "" +
                                    ", dtt_docu_percent_iva=" + dgvResult["ColIva", IdRow].Value.ToString().Replace(",", ".") + "" +
                                    ", dtt_docu_costo_gasolio=" + dgvResult["ColGasolio", IdRow].Value.ToString().Replace(",", ".") + "" +
                                    ", dtt_docu_km=" + dgvResult["ColKM", IdRow].Value.ToString().Replace(",", ".") + "" +
                                    ", dtt_docu_pos=" + IdRow.ToString() + "" +
                                    ", dtt_descr_viaggio='" + dgvResult["ColViaggio", IdRow].Value.ToString().Replace("'", "''") + "'" +
                                    ", dtt_descr_articolo='" + dgvResult["ColArt", IdRow].Value.ToString().Replace("'", "''") + "'" +
                                    ", dtt_descr_truck='" + dgvResult["ColTruck", IdRow].Value.ToString().Replace("'", "''") + "'" +
                                    " Where id=" + dgvResult[0,IdRow].Value.ToString();

            return clsDataBase.ExecuteNonQuery(strSql);
        }

        private void bttModificaVoce_Click(object sender, EventArgs e)
        {
            if (dgvResult.CurrentRow != null)
                SetChangeItemPag(dgvResult.CurrentRow.Index, true);
            
            return;

            //if (dgvResult["ColIdViaggio", dgvResult.CurrentRow.Index].Value == null)
            //{
            //    MessageBox.Show("Nessun record Viaggio associato. \nPer modificarlo, eliminarlo ed inserire un nuovo viaggio con le nuove impostazioni.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //if (IdSel>0)
            //    if (MessageBox.Show("Le modifiche saranno effettuate direttamente nella base dati.\nContinuare?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) return;
            
            ////Procedo con la modifca
            //frmModDocViaggi frmNew = new frmModDocViaggi();

            //frmNew.IdSel = (int)dgvResult["ColIdViaggio", dgvResult.CurrentRow.Index].Value;
            //frmNew.ShowDialog();
            //if (frmNew.IsChange)
            //{
            //    InsertDettViaggio(frmNew.IdSel, dgvResult.CurrentRow.Index);
            //    CalcolaRiepilogo();
            //}
        }

        private void bttEliminaVoce_Click(object sender, EventArgs e)
        {
            string strSql = "";

            if (MessageBox.Show("Eliminare la voce di dettaglio selezionata ?.", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;

            //Procedo con la modifca
            if (dgvResult[0, dgvResult.CurrentRow.Index].Value != null)
            { 
                //Devo Eliminare il record
                strSql = "Delete Dtt_documenti where Id=" + dgvResult[0, dgvResult.CurrentRow.Index].Value.ToString();
                clsDataBase.ExecuteNonQuery(strSql);                        
            }
            dgvResult.Rows.RemoveAt(dgvResult.CurrentRow.Index);
            
            CalcolaRiepilogo();
        }

        private void bttUp_Click(object sender, EventArgs e)
        {
            int SelRowDttToMove = dgvResult.CurrentRow.Index;
            int IdDett1 = -1;
            int IdDett2 = -1;
            int idNewPosDett1 = -1;
            int idNewPosDett2 = -1;

            if (clsGlobal.DataGridRowMoveUpDown(dgvResult, SelRowDttToMove, true))
            {
                if (IdSel > 0)
                {
                    if (dgvResult[0, SelRowDttToMove].Value != null)
                        IdDett1 = (int)dgvResult[0, SelRowDttToMove].Value;
                    if (dgvResult[0, SelRowDttToMove - 1].Value != null)
                        IdDett2 = (int)dgvResult[0, SelRowDttToMove - 1].Value;

                    idNewPosDett1 = dgvResult.CurrentRow.Index - 1;
                    idNewPosDett2 = dgvResult.CurrentRow.Index;


                    //Aggiorno la posizione del record nel DB                
                    UpdatePosRecordDtt(IdDett1, idNewPosDett1, IdDett2, idNewPosDett2);
                }
            }
        }

        private bool UpdatePosRecordDtt(int IdDett1, int NewPos1, int IdDett2, int NewPos2)
        {
            bool bRet = false;
            string strSql = "";

            if (IdDett1 > -1)
            {
                strSql = "Update into Dtt_documenti set dtt_docu_pos=" + NewPos1.ToString() + " where ID=" + IdDett1;
                if (!clsDataBase.ExecuteNonQuery(strSql)) return bRet;
                bRet = true;
            }
            if (IdDett2 > -1)
            {
                bRet = false;
                strSql = "Update into Dtt_documenti set dtt_docu_pos=" + NewPos2.ToString() + " where ID=" + IdDett2;
                if (clsDataBase.ExecuteNonQuery(strSql)) bRet = true;
            }
            return bRet;
        }

        private void bttDown_Click(object sender, EventArgs e)
        {
            int SelRowDttToMove = dgvResult.CurrentRow.Index;
            int IdDett1 = -1;
            int IdDett2 = -1;
            int idNewPosDett1 = -1;
            int idNewPosDett2 = -1;

            if (clsGlobal.DataGridRowMoveUpDown(dgvResult, SelRowDttToMove, false))
            {
                if (IdSel > 0)
                {
                    if (dgvResult[0, SelRowDttToMove].Value!=null)
                        IdDett1 = (int)dgvResult[0, SelRowDttToMove].Value;
                    if (dgvResult[0, SelRowDttToMove + 1].Value != null)
                        IdDett2 = (int)dgvResult[0, SelRowDttToMove + 1].Value;

                    idNewPosDett1 = dgvResult.CurrentRow.Index + 1;
                    idNewPosDett2 = dgvResult.CurrentRow.Index;


                    //Aggiorno la posizione del record nel DB                
                    UpdatePosRecordDtt(IdDett1, idNewPosDett1, IdDett2, idNewPosDett2);
                }               
            }
        }

        private void frmModFattura_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmParent != null)
                frmParent.Show();
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInfoCliente(((_dataItemCombo)cmbCliente.SelectedItem).Id);
        }

        private void LoadInfoCliente(int IdCliente)
        {
            string strSql = "Select Cln_iban,Cln_banca_descr,cln_banca_cab,Cln_banca_abi,Cln_banca_cc,Cln_banca_cin,Cln_banca_swift,Cln_ID_Tipi_pagamento, Cln_iva, Cln_Note_Fatt, Cln_ID_Banca_azienda from Clienti where ID=" + IdCliente.ToString();
            int ReaderIndex = clsDataBase.GetFreeDbReaderIndex();

            if (clsDataBase.ExecuteQuery(strSql, ReaderIndex))
            {
                if (clsDataBase.vetDbReader[ReaderIndex].Read())
                {
                    txtIVA.Text = clsDataBase.GetStringValue("Cln_iva", ReaderIndex);
                    txtABI.Text = clsDataBase.GetStringValue("Cln_banca_abi", ReaderIndex);
                    txtBanca.Text = clsDataBase.GetStringValue("Cln_banca_descr", ReaderIndex);
                    txtCAB.Text = clsDataBase.GetStringValue("cln_banca_cab", ReaderIndex);
                    txtCC.Text = clsDataBase.GetStringValue("Cln_banca_cc", ReaderIndex);
                    txtIBAN.Text = clsDataBase.GetStringValue("Cln_iban", ReaderIndex);
                    txtABI.Text = clsDataBase.GetStringValue("Cln_banca_abi", ReaderIndex);
                    cmbTipPag.Tag = clsDataBase.GetIntValue("Cln_ID_Tipi_pagamento", ReaderIndex);
                    txtNote.Text = clsDataBase.GetStringValue("Cln_Note_Fatt", ReaderIndex) + " " + clsSetting.param_note_fattura;
                    cmbBancaAz.Tag = clsDataBase.GetIntValue("Cln_ID_Banca_azienda", ReaderIndex);
                    clsDataBase.PopolaCombo(cmbTipPag, clsGlobal.ETypeTable.TT_TIP_PAGAMENTO);
                    clsDataBase.PopolaCombo(cmbBancaAz, clsGlobal.ETypeTable.TT_BANCHE_AZ);
                }
            }
            clsDataBase.CloseDataReader(ReaderIndex);
        }

        private void bttNuovaVoce_Click(object sender, EventArgs e)
        {            
            if (IdSel > 0)
                if (MessageBox.Show("Inserire una nuova voce di dettaglio ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) return;

            //Procedo con la modifca
            frmModDocViaggi frmNew = new frmModDocViaggi();
            
            frmNew.ShowDialog();
            if (frmNew.IsChange)
            {
                InsertDettViaggio(frmNew.IdSel);
                CalcolaRiepilogo();
            }
        }

        private void bttStampa_Click(object sender, EventArgs e)
        {
            crpDocFattura newReport = new crpDocFattura();

            clsReport.InizializzaReport(newReport);
            //crClienti.RecordSelectionFormula = "id=0";

            //newReport.SetDataSource((DataTable)(bindingSource1.DataSource));
            newReport.SetParameterValue("IdFatt2", IdSel);
            newReport.SetParameterValue("IdFat1", IdSel);
            newReport.SetParameterValue("IdFat", IdSel);
            newReport.SetParameterValue("TipoDocumento", txtTipoDoc.Text);

            clsReport.SetParamIntestazione(newReport);
            clsReport.ShowReport(newReport);
        }

        private void nudBolli_ValueChanged(object sender, EventArgs e)
        {
            lblTotLordo.Text = Math.Round(Convert.ToDecimal(lblImponibile.Text) + Convert.ToDecimal(lblImportoIva.Text) + nudBolli.Value, 2).ToString();
        }

        private void nudCoeff_ValueChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow objRow in dgvResult.Rows)
            {
                if (objRow.Cells["ColKM"].Value != null)
                    objRow.Cells["ColGasolio"].Value = Math.Round((decimal)objRow.Cells["ColKM"].Value * nudCoeff.Value, 2);
                else
                    objRow.Cells["ColGasolio"].Value = 0;
            }
        }

        private void frmModFattura_Shown(object sender, EventArgs e)
        {
            CalcolaRiepilogo();
        }

        private void bttNewVoce_Click(object sender, EventArgs e)
        {
            dgvResult.Rows.Add(1);
            //dgvResult["ColDataRif", dgvResult.Rows.Count - 1].Value = strRifDataInizio;
            //dgvResult["ColGiorni", dgvResult.Rows.Count - 1].Value = "0";
            //dgvResult["ColPercImp", dgvResult.Rows.Count - 1].Value = DefaultPercImp;

            SetChangeItemPag(dgvResult.Rows.Count - 1, true);
        }

        private void SetChangeItemPag(int RowIndex, bool IsToModify)
        {
            if (IsToModify)
            {
                dgvResult.CurrentCell = dgvResult["ColCod", RowIndex];
                //dgvPagamenti["ColPercImp", RowIndex].Value = dgvPagamenti["ColPercImp", RowIndex].Value.ToString().Replace(".", ","); 
                dgvResult.Rows[RowIndex].ReadOnly = false;
                dgvResult.CurrentRow.DefaultCellStyle.BackColor = Color.Salmon;
                dgvResult.Columns["ColTot"].DefaultCellStyle.BackColor = SystemColors.Window;
                dgvResult.Columns["ColGasolio"].DefaultCellStyle.BackColor = SystemColors.Window;
            }
            else
            {
                dgvResult.CurrentRow.ReadOnly = true;
                dgvResult.CurrentRow.DefaultCellStyle.BackColor = SystemColors.Window;
            }

        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (dgvResult.CurrentCell.ColumnIndex)
            {
                case 9: //Quantità
                    e.Handled = !clsGlobal.IsNumber(e.KeyChar);
                    break;
                case 7: //KM
                case 10: //Prezzo
                case 12: //IVA
                    e.Handled = !clsGlobal.IsDecimal(e.KeyChar);
                    if (!e.Handled)
                        e.Handled = (e.KeyChar == '.' && ((System.Windows.Forms.DataGridViewTextBoxEditingControl)sender).Text.IndexOf(".") > -1);
                    break;
                default:
                    break;
            }            
        }

        private void dgvResult_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvResult.Rows[e.RowIndex].ReadOnly == false)
            {
                SetChangeItemPag(e.RowIndex, false);
                CalcolaRiepilogo();
            }
        }

        private void dgvResult_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvResult.Rows[e.RowIndex].ReadOnly == false)
            {
                if (e.ColumnIndex == dgvResult.Columns["ColQta"].Index || e.ColumnIndex == dgvResult.Columns["ColPrezzo"].Index)
                {
                    if (dgvResult["ColPrezzo", e.RowIndex].EditedFormattedValue.ToString() == "" || dgvResult["ColQta", e.RowIndex].EditedFormattedValue.ToString() == "") 
                        dgvResult["ColTot", e.RowIndex].Value = "0,00";
                    else
                        dgvResult["ColTot", e.RowIndex].Value = Math.Round(Convert.ToDecimal(dgvResult["ColPrezzo", e.RowIndex].EditedFormattedValue.ToString().Replace(".", ",")) * Convert.ToDecimal(dgvResult["ColQta", e.RowIndex].EditedFormattedValue.ToString().Replace(".", ",")), 2).ToString("N2");
                }
                if (e.ColumnIndex == dgvResult.Columns["ColKm"].Index)
                {
                    if (dgvResult["ColPrezzo", e.RowIndex].EditedFormattedValue.ToString() == "")
                        dgvResult["ColGasolio", e.RowIndex].Value = "0,00";
                    else
                    {
                        if (dgvResult["ColKm", e.RowIndex].EditedFormattedValue.ToString() != "")
                            dgvResult["ColGasolio", e.RowIndex].Value = Math.Round(Convert.ToDecimal(dgvResult["ColKm", e.RowIndex].EditedFormattedValue.ToString().Replace(".", ",")) * nudCoeff.Value, 2).ToString("N2").Replace(",", ".");
                        else
                            dgvResult["ColGasolio", e.RowIndex].Value = 0;
                    }
                }
            }
        }

        private void cmbTipPag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipPag.SelectedIndex > 0)
            {
                grpbBanca.Enabled = true;
                switch (((_dataItemCombo)cmbTipPag.SelectedItem).Descrizione)
                {
                    case "Stampa c/c Azienda":
                        grpbBanca.Text = "Riferimenti Bancari Azienda:";
                        pnlBancaAz.Visible = true;
                        pnlBancaCl.Visible = false;
                        break;
                    case "Stampa c/c Cliente":
                        grpbBanca.Text = "Riferimenti Bancari Cliente:";
                        pnlBancaAz.Visible = false;
                        pnlBancaCl.Visible = true;
                        break;
                    default:
                        grpbBanca.Enabled = false;
                        break;
                }
            }
            else
                grpbBanca.Enabled = false;
        }

        private void cmbBancaAz_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBancaAz.SelectedIndex > 0)
                LoadDatiBancaAz(((_dataItemCombo)cmbBancaAz.SelectedItem).Id);
        }

        private void LoadDatiBancaAz(int idBanca)
        {
            string strSql = "Select banca_descrizione,banca_cin,banca_cab,banca_abi,banca_iban,banca_swift,banca_cancellato,banca_cc from Banca_azienda where ID=" + idBanca.ToString();
            int ReaderIndex = clsDataBase.GetFreeDbReaderIndex();

            if (clsDataBase.ExecuteQuery(strSql, ReaderIndex))
            {
                if (clsDataBase.vetDbReader[ReaderIndex].Read())
                {
                    txtAbiAz.Text = clsDataBase.GetStringValue("banca_abi", ReaderIndex);
                    txtBancaAz.Text = clsDataBase.GetStringValue("banca_descrizione", ReaderIndex);
                    txtCabAz.Text = clsDataBase.GetStringValue("banca_cab", ReaderIndex);
                    txtCCAz.Text = clsDataBase.GetStringValue("banca_cc", ReaderIndex);
                    txtIbanAz.Text = clsDataBase.GetStringValue("banca_iban", ReaderIndex);
                }
            }
            clsDataBase.CloseDataReader(ReaderIndex);
        }

        private void bttPDF_Click(object sender, EventArgs e)
        {
            crpDocFattura newReport = new crpDocFattura();

            clsReport.InizializzaReport(newReport);
            newReport.SetParameterValue("IdFatt2", IdSel);
            newReport.SetParameterValue("IdFat1", IdSel);
            newReport.SetParameterValue("IdFat", IdSel);
            newReport.SetParameterValue("TipoDocumento", txtTipoDoc.Text);

            clsReport.SetParamIntestazione(newReport);
            clsReport.ExportReportToFilePdf(newReport, txtTipoDoc.Text + "_" + txtNum.Text);
        }

        private void dgvResult_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);

            if (dgvResult.CurrentCell.ColumnIndex == dgvResult.Columns["ColCod"].Index)  
            {  
                // Check box column  
                ComboBox comboBox = e.Control as ComboBox;  
                comboBox.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);  
                
            }  
        }

        void comboBox_SelectedIndexChanged(object sender, EventArgs e)  
        {
            int selectedIndex = ((ComboBox)sender).SelectedIndex;
            //MessageBox.Show("Selected Index = " + selectedIndex);
            //dgvResult.CurrentCell.Value  = ((_dataItemCombo)((ComboBox)sender).SelectedItem).Value;            
            dgvResult.CurrentRow.Cells["ColDescr"].Value = ((_dataItemCombo)((ComboBox)sender).SelectedItem).Descrizione;            
            
        }

        private void dgvResult_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvResult.Columns["ColCod"].Index)
            {
                //dgvResult[e.ColumnIndex, e.RowIndex].Value = e.FormattedValue.ToString();
                //e.Cancel = true;
                //dgvResult[e.ColumnIndex, e.RowIndex].FormattedValueType = 

            }
        } 

    }
}
