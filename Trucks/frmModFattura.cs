using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

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

    private bool bIsChange = false;
    private int NumFattura = 0;

    private string m_DescrClientePdf = "";
    private string m_DescrClienteXml = "";

    private int m_IdClientePdf = 0;
    private int m_IdClienteXml = 0;

    public frmModFattura()
    {
      InitializeComponent();
    }

    private void frmModFattura_Load(object sender, EventArgs e)
    {
      toolTipEsenzione.SetToolTip(cmbEsenzione, "Il parametro è utilizzato per le sole fatture antecedenti allo 01-01-2019");

      dgvResult.Columns["ColData"].DefaultCellStyle.Format = "dd/MM/yyyy";    //columns.["ColData"].DefaultCellStyle.Format = "dd/MM/yyyy";
      if (!this.Modal && this.MdiParent != null)
        this.WindowState = FormWindowState.Maximized;

      this.WindowState = FormWindowState.Maximized;

      //imposto i limiti per la data
      clsDataBase.GetIntervalDateNumFattura(IdSel, dtpData);
      cmbModFatt.Tag = clsSetting.param_model_fattura;

      if (IdSel > 0)
      {
        LoadDocumento(IdSel);
        //Devo impostare la modifica della data fattura solo per l'anno corrente
        if (dtpData.MinDate.Year < dtpData.Value.Year)
          dtpData.MinDate = Convert.ToDateTime(dtpData.Value.Year.ToString() + "/01/01");

        dtpData.MaxDate = Convert.ToDateTime(dtpData.Value.Year.ToString() + "/12/31");
        SetIsChange(false);
      }
      else
      {
        //groupBox2.Enabled = false;
        if (dgvResult.Rows.Count > 0)
          groupBox2.Enabled = false;

        if (DateTime.Today < dtpData.MinDate)
          dtpData.Value = dtpData.MinDate;
        else
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


      bttXML.Visible = clsSetting.ATTIVA_XML;
      btnPdfXml.Visible = clsSetting.ATTIVA_XML;

      if (cmbModFattXml.SelectedIndex < 1)
        cmbModFattXml.SelectedIndex = 1;

      if (cmbModFatt.SelectedIndex < 1)
      {
        // Inizializzo la combo fattura per la stampa per codici
        int iModFat = ((int)clsSetting.param_model_fattura);
        if (iModFat < 1)
          iModFat = 2;

        cmbModFatt.Tag = iModFat.ToString();
        SelectCombo(cmbModFatt, iModFat.ToString());
      }
    }

    private void EnableCommand(bool Value)
    {
      SetIsChange(false);

      bttStampa.Enabled = bttPDF.Enabled = Value;
      bttXML.Enabled = Value && clsSetting.ATTIVA_XML;
      btnPdfXml.Enabled = Value && clsSetting.ATTIVA_XML;
      btnXmlWithAtt.Enabled = Value && clsSetting.ATTIVA_XML;
      btnXmlWithPdfAtt.Enabled = Value && clsSetting.ATTIVA_XML;
    }

    private bool LoadDocumento(int IdDoc)
    {
      bool bRet = false;
      string strSql = "Select Documenti.Id, docu_numero, ID_cliente, docu_data, ID_tipi_pagamento, docu_coeficente, docu_bolli, docu_note, docu_tipo, docu_esenzione, Id_banca_az, docu_cl_abi, docu_cl_cab, " +
                      " IsNull(Tipi_pagam_condizioni, '') As Tipi_pagam_condizioni, IsNull(Tipi_pagam_modalita, '') As Tipi_pagam_modalita, " +
                      " IsNull(Xml_Documenti.DataCreazione, 0) As DataCreazione, IsNull(Xml_Documenti.OraCreazione, 0) As OraCreazione, IsNull(Xml_Documenti.FileAllegato, '') As FileAllegato, " +
                      " IsNull(docu_id_fattura_pdf, 0) As docu_id_fattura_pdf, IsNull(docu_id_fattura_xml, 0) As docu_id_fattura_xml " +
                      " From Documenti" +
                      " Left Join Tipi_pagamento On Documenti.ID_tipi_pagamento = Tipi_pagamento.ID" +
                      " Left Join Xml_Documenti On Documenti.ID = Xml_Documenti.IdDocumento" +
                      " Where Documenti.ID = " + IdDoc.ToString();
      //" IsNull(Cln_id_fattura_pdf, 0) As Cln_id_fattura_pdf, IsNull(Cln_id_fattura_xml, 0) As Cln_id_fattura_xml " +
      //" Left Join Clienti On Documenti.ID_cliente = Clienti.ID" +

      if (clsDataBase.ExecuteQuery(strSql))
      {
        if (clsDataBase.vetDbReader[0].Read())
        {
          txtNum.Text = GeneraCodiceFat(clsDataBase.GetDateValue("docu_data").ToString("yyyy"), clsDataBase.GetIntValue("docu_numero"));
          NumFattura = clsDataBase.GetIntValue("docu_numero");
          cmbCliente.Tag = clsDataBase.GetIntValue("ID_cliente");
          dtpData.Value = clsDataBase.GetDateValue("docu_data");

          nudCoeff.Value = clsDataBase.GetDecimalValue("docu_coeficente");
          nudBolli.Value = clsDataBase.GetValutaValue("docu_bolli");

          TipoDoc = (ETypeDoc)clsDataBase.GetIntValue("docu_tipo");

          PopolaCombo();

          if (clsDataBase.GetIntValue("docu_id_fattura_pdf") > 0)
            cmbModFatt.Tag = clsDataBase.GetIntValue("docu_id_fattura_pdf");

          SelectCombo(cmbModFatt, cmbModFatt.Tag.ToString());

          if (clsDataBase.GetIntValue("docu_id_fattura_xml") > 0)
            cmbModFattXml.Tag = clsDataBase.GetIntValue("docu_id_fattura_xml");

          SelectCombo(cmbModFattXml, cmbModFattXml.Tag.ToString());

          txtNote.Text = clsDataBase.GetStringValue("docu_note");
          SelectCombo2ByDescr(cmbEsenzione, clsDataBase.GetStringValue("docu_esenzione"));
          cmbTipPag.Tag = clsDataBase.GetIntValue("ID_tipi_pagamento");
          clsDataBase.PopolaCombo(cmbTipPag, clsGlobal.ETypeTable.TT_TIP_PAGAMENTO);
          cmbBancaAz.Tag = clsDataBase.GetIntValue("Id_banca_az");
          txtABI.Text = clsDataBase.GetStringValue("docu_cl_abi");
          txtCAB.Text = clsDataBase.GetStringValue("docu_cl_cab");
          clsDataBase.PopolaCombo(cmbBancaAz, clsGlobal.ETypeTable.TT_BANCHE_AZ);

          int DtLastXmlExport = clsDataBase.GetIntValue("DataCreazione");
          if (DtLastXmlExport > 0)
            lblXml.Text = FromNumToDateString(DtLastXmlExport, clsDataBase.GetIntValue("OraCreazione"));
          else
            lblXml.Text = "";

          lblXmlAtt.Text = clsDataBase.GetStringValue("FileAllegato");
          bRet = true;
        }
      }
      clsDataBase.CloseDataReader();

      if (bRet)
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
      dgvResult.Rows.Clear();

      string strSql = "Select d.ID, d.ID_documento,d.dtt_docu_cod_art,d.dtt_docu_tratta,d.dtt_docu_truck,d.dtt_docu_ddt_n,d.dtt_docu_ddt_data,d.dtt_docu_descrizione,d.dtt_docu_qta,d.dtt_docu_um,d.dtt_docu_prezzo_u,d.dtt_docu_percent_iva,d.dtt_docu_km, d.dtt_docu_pos, d.dtt_id_viaggio,round(dtt_docu_prezzo_u*dtt_docu_qta,2) as Imponibile, IsNull(d.dtt_id_iva, -1) As IdIva from Dtt_documenti d where dtt_docu_cancellato=0 and ID_documento =" + IdDoc.ToString() + " Order by dtt_docu_pos asc";
      if (clsDataBase.ExecuteQuery(strSql))
      {
        while (clsDataBase.vetDbReader[0].Read())
        {
          int IdRow = dgvResult.Rows.Add();
          dgvResult["ColID", IdRow].Value = clsDataBase.GetIntValue("ID");
          dgvResult["ColCod", IdRow].Value = clsDataBase.GetStringValue("dtt_docu_cod_art");
          dgvResult["ColDescr", IdRow].Value = clsDataBase.GetStringValue("dtt_docu_descrizione");
          dgvResult["ColQta", IdRow].Value = clsDataBase.GetDecimalValue("dtt_docu_qta");
          dgvResult["ColUM", IdRow].Value = clsDataBase.GetStringValue("dtt_docu_um");
          dgvResult["colPrezzo", IdRow].Value = clsDataBase.GetValutaValue("dtt_docu_prezzo_u");
          dgvResult["ColIva", IdRow].Value = clsDataBase.GetValutaValue("dtt_docu_percent_iva");
          dgvResult["ColKM", IdRow].Value = clsDataBase.GetValutaValue("dtt_docu_km");
          dgvResult["ColTot", IdRow].Value = clsDataBase.GetValutaValue("imponibile");
          //dgvResult["ColTot", IdRow].Value = Math.Round(clsDataBase.GetValutaValue("dtt_docu_prezzo_u") * clsDataBase.GetValutaValue("dtt_docu_qta"), 2);
          if (dgvResult["ColKM", IdRow].Value != null)
            dgvResult["ColGasolio", IdRow].Value = Math.Round((decimal)dgvResult["ColKM", IdRow].Value * nudCoeff.Value, 2);
          else
            dgvResult["ColGasolio", IdRow].Value = 0;

          dgvResult["ColViaggio", IdRow].Value = clsDataBase.GetStringValue("dtt_docu_tratta");
          dgvResult["ColTruck", IdRow].Value = clsDataBase.GetStringValue("dtt_docu_truck");

          if (clsDataBase.GetDateValue("dtt_docu_ddt_data") == DateTime.MinValue)
            dgvResult["ColData", IdRow].Value = "";
          else
            dgvResult["ColData", IdRow].Value = clsDataBase.GetDateValue("dtt_docu_ddt_data"); //.ToString("dd/MM/yyyy");


          dgvResult["ColDDT", IdRow].Value = clsDataBase.GetStringValue("dtt_docu_ddt_n");
          dgvResult["ColIdViaggio", IdRow].Value = clsDataBase.GetIntValue("dtt_id_viaggio");
          dgvResult["ColIdIva", IdRow].Value = clsDataBase.GetIntValue("IdIva");

          if (clsDataBase.GetIntValue("dtt_id_viaggio") > 0)
            cmbCliente.Enabled = false;
          //Popolo la struttura Viaggi di riferimento

          //clsGlobal._DettFat NewDettFat = new clsGlobal._DettFat();
          //NewDettFat.CodArticolo = clsDataBase.GetStringValue("dtt_docu_cod_art");
          //NewDettFat.Descr = clsDataBase.GetStringValue("dtt_docu_cod_art");
          //NewDettFat.Tratta = clsDataBase.GetStringValue("dtt_docu_tratta");
          //NewDettFat.Truck = clsDataBase.GetStringValue("dtt_docu_truck");
          //NewDettFat.Num_Viaggio = clsDataBase.GetStringValue("dtt_docu_um");
          //NewDettFat.Data = clsDataBase.GetDateValue("dtt_docu_ddt_data");
          //NewDettFat.Descr = clsDataBase.GetStringValue("dtt_docu_descrizione");
          //NewDettFat.Qta = clsDataBase.GetValutaValue("dtt_docu_qta");
          //NewDettFat.Um = clsDataBase.GetStringValue("dtt_docu_um");
          //NewDettFat.Prezzo = clsDataBase.GetValutaValue("dtt_docu_prezzo_u");
          //NewDettFat.IVA = clsDataBase.GetValutaValue("dtt_docu_percent_iva");
          //NewDettFat.KM = clsDataBase.GetValutaValue("dtt_docu_km");
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

      string strSql = "Select v.ID, v.ID_cliente, v.ID_articoli, v.ID_ddt_distanze, v.ID_truck, v.viaggi_ddt_n, " +
      "v.viaggi_ddt_data, v.viaggi_descrizione, v.viaggio_qta, v.viaggi_um, v.viaggi_prezzo_u, v.viaggi_percent_iva, " +
      "v.viaggi_note, d.ID_localita_A, d.ID_localita_B, d.Dtt_distanze_km, a.art_cod, a.art_descrizione, " +
      "(select locA.Loc_luogo + ' - ' + locB.Loc_luogo from Localita locA, Localita locB where locA.Id=d.ID_localita_A and locB.Id=d.ID_localita_B) as DescrViaggio, " +
      "t.truck_targa, round(v.viaggi_prezzo_u * v.viaggio_qta,2) as imponibile " +
      " from Viaggi v left join Dtt_distanze d on v.ID_ddt_distanze=d.ID left join Articoli a on v.ID_articoli=a.ID left join truck t on t.ID=v.ID_truck" +
      " Where v.ID = " + idViaggio.ToString();

      if (IndexRow == -1)
        IdRow = dgvResult.Rows.Add();

      if (!clsDataBase.ExecuteQuery(strSql))
        return bRet;
      if (clsDataBase.vetDbReader[0].Read())
      {
        dgvResult["ColCod", IdRow].Value = clsDataBase.GetStringValue("art_cod");
        dgvResult["ColDescr", IdRow].Value = clsDataBase.GetStringValue("viaggi_descrizione");

        dgvResult["ColViaggio", IdRow].Value = clsDataBase.GetStringValue("DescrViaggio");
        dgvResult["ColTruck", IdRow].Value = clsDataBase.GetStringValue("truck_targa");

        //dgvResult["ColData", IdRow].Value = clsDataBase.GetDateValue("viaggi_ddt_data").ToString("dd/MM/yyyy");
        dgvResult["ColData", IdRow].Value = clsDataBase.GetDateValue("viaggi_ddt_data");

        dgvResult["ColQta", IdRow].Value = clsDataBase.GetDecimalValue("viaggio_qta");
        dgvResult["ColUM", IdRow].Value = clsDataBase.GetStringValue("viaggi_um");
        dgvResult["colPrezzo", IdRow].Value = clsDataBase.GetValutaValue("viaggi_prezzo_u");
        dgvResult["ColIva", IdRow].Value = clsDataBase.GetValutaValue("viaggi_percent_iva"); ;
        dgvResult["ColKM", IdRow].Value = clsDataBase.GetValutaValue("Dtt_distanze_km");
        dgvResult["ColTot", IdRow].Value = clsDataBase.GetValutaValue("imponibile");
        //dgvResult["ColTot", IdRow].Value = Math.Round(clsDataBase.GetValutaValue("viaggi_prezzo_u") * clsDataBase.GetValutaValue("viaggio_qta"), 2);
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
        dgvResult["ColDDT", IdRow].Value = clsDataBase.GetStringValue("viaggi_ddt_n");
        dgvResult["ColIdViaggio", IdRow].Value = idViaggio;
      }
      clsDataBase.CloseDataReader();

      if (IndexRow == -1 && IdRow == 0 && cmbCliente.Tag != null)
      {
        clsDataBase.PopolaCombo_2(cmbCondPag, clsGlobal.ETypeTable.XML_COND_PAGAMENTO);
        clsDataBase.PopolaCombo_2(cmbModPag, clsGlobal.ETypeTable.XML_MOD_PAGAMENTO);

        clsDataBase.PopolaCombo(cmbCliente, clsGlobal.ETypeTable.TT_CLIENTI);
      }

      bRet = true;
      return bRet;
    }

    public bool InsertDettFatt(clsGlobal._DettFat DettFatt, int IndexRow = -1)
    {
      bool bRet = false;
      int IdRow = IndexRow;

      if (IndexRow == -1)
        IdRow = dgvResult.Rows.Add();

      dgvResult["ColCod", IdRow].Value = DettFatt.CodArticolo;
      dgvResult["ColDescr", IdRow].Value = DettFatt.Descr;

      dgvResult["ColViaggio", IdRow].Value = DettFatt.Tratta;
      dgvResult["ColTruck", IdRow].Value = DettFatt.Truck;
      if (DettFatt.Data == null || DettFatt.Data == DateTime.MinValue)
        dgvResult["ColData", IdRow].Value = "";
      else
        dgvResult["ColData", IdRow].Value = DettFatt.Data; //.ToString("dd/MM/yyyy");

      dgvResult["ColQta", IdRow].Value = DettFatt.Qta;
      dgvResult["ColUM", IdRow].Value = DettFatt.Um;
      dgvResult["colPrezzo", IdRow].Value = DettFatt.Prezzo;
      dgvResult["ColIva", IdRow].Value = DettFatt.IVA;
      dgvResult["ColKM", IdRow].Value = DettFatt.KM;
      dgvResult["ColTot", IdRow].Value = Math.Round(DettFatt.Prezzo * DettFatt.Qta, 2);
      //dgvResult["ColGasolio", IdRow].Value = clsSetting.param_prezzo_carburante;
      dgvResult["ColGasolio", IdRow].Value = Math.Round(DettFatt.KM * nudCoeff.Value, 2);

      dgvResult["ColDDT", IdRow].Value = DettFatt.DDT;
      dgvResult["ColIdViaggio", IdRow].Value = 0;
      dgvResult["ColIdIva", IdRow].Value = DettFatt.IdIva;

      bRet = true;
      return bRet;
    }

    public bool SettDettFatt(ref clsGlobal._DettFat DettFatt, int IdRow)
    {
      bool bRet = false;

      if (IdRow == -1) return bRet;
      DettFatt.Id_Cliente = ((_dataItemCombo)cmbCliente.SelectedItem).Id;
      DettFatt.CodArticolo = dgvResult["ColCod", IdRow].Value.ToString();
      DettFatt.Descr = dgvResult["ColDescr", IdRow].Value.ToString();

      DettFatt.Tratta = dgvResult["ColViaggio", IdRow].Value.ToString();
      DettFatt.Truck = dgvResult["ColTruck", IdRow].Value.ToString().Trim();

      if (dgvResult["ColData", IdRow].Value.ToString() == "")
        DettFatt.Data = DateTime.MinValue;
      else
      {
        DettFatt.Data = Convert.ToDateTime(dgvResult["ColData", IdRow].Value);
        //DettFatt.Data = new DateTime(Convert.ToInt32(dgvResult["ColData", IdRow].Value.ToString().Substring(6, 4)),
        //                                        Convert.ToInt32(dgvResult["ColData", IdRow].Value.ToString().Substring(3, 2)),
        //                                        Convert.ToInt32(dgvResult["ColData", IdRow].Value.ToString().Substring(0, 2)));
      }
      DettFatt.Qta = Convert.ToDecimal(dgvResult["ColQta", IdRow].Value);
      DettFatt.Um = dgvResult["ColUM", IdRow].Value.ToString();
      DettFatt.Prezzo = Convert.ToDecimal(dgvResult["colPrezzo", IdRow].Value.ToString());
      DettFatt.IVA = Convert.ToDecimal(dgvResult["ColIva", IdRow].Value.ToString());
      DettFatt.KM = Convert.ToDecimal(dgvResult["ColKM", IdRow].Value.ToString());
      DettFatt.DDT = dgvResult["ColDDT", IdRow].Value.ToString();
      DettFatt.ID_Viaggio = (int)dgvResult["ColIdViaggio", IdRow].Value;
      DettFatt.IdIva = (int)dgvResult["ColIdIva", IdRow].Value;

      bRet = true;
      return bRet;
    }

    private void PopolaCombo()
    {
      clsDataBase.PopolaCombo(cmbCliente, clsGlobal.ETypeTable.TT_CLIENTI);
      clsDataBase.PopolaCombo(cmbTipPag, clsGlobal.ETypeTable.TT_TIP_PAGAMENTO);
      clsDataBase.PopolaCombo(cmbBancaAz, clsGlobal.ETypeTable.TT_BANCHE_AZ);
      //clsDataBase.PopolaCombo(cmbEsenzione, clsGlobal.ETypeTable.TT_ESENZIONI);

      clsDataBase.PopolaCombo_2(cmbEsenzione, clsGlobal.ETypeTable.XML_NATURA);
      clsDataBase.PopolaCombo_2(cmbCondPag, clsGlobal.ETypeTable.XML_COND_PAGAMENTO);
      clsDataBase.PopolaCombo_2(cmbModPag, clsGlobal.ETypeTable.XML_MOD_PAGAMENTO);

      if (cmbTipPag.SelectedIndex > 0)
      {
        string[] sVal = ((_dataItemCombo)cmbTipPag.SelectedItem).Tag.Split(';');

        clsDataBase.SelezionaComboItem_2(cmbCondPag, sVal[0].ToString());
        clsDataBase.SelezionaComboItem_2(cmbModPag, sVal[1].ToString());
      }

      clsDataBase.PopolaComboPdfFatture(cmbModFatt);
      clsDataBase.PopolaComboXmlFatture(cmbModFattXml);

    }

    private void SelectCombo(ComboBox objCombo, string Id)
    {
      for (int i = 0; i < objCombo.Items.Count; i++)
      {
        if ((string)((_dataItemCombo)objCombo.Items[i]).Id.ToString() == Id)
        {
          objCombo.SelectedIndex = i;
          return;
        }
      }

    }

    private void SelectCombo2ByDescr(ComboBox objCombo, string Descr)
    {
      for (int i = 0; i < objCombo.Items.Count; i++)
      {
        if ((string)((ComboboxItem)objCombo.Items[i]).Text == Descr)
        {
          objCombo.SelectedIndex = i;
          return;
        }
      }

    }

    private void bttEsci_Click(object sender, EventArgs e)
    {

      Close();

    }

    private void bttSave_Click(object sender, EventArgs e)
    {
      string strMsg = "Salvare le modifiche apportate ?";
      if (IdSel > 0 && TipoDoc == ETypeDoc.TD_FAT)
        strMsg = "Salvando le modifiche verranno aggiornate anche le scadenze.\n\n" + strMsg;

      if (MessageBox.Show(strMsg, "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
      {
        if (!VerificaCampi()) return;
        if (TipoDoc == ETypeDoc.TD_FAT)
        {
          if (!DeleteScadenze(IdSel))
            return;
        }

        if (SaveFattura())
        {
          bool IsOk = true;
          if (TipoDoc == ETypeDoc.TD_FAT)
          {
            if (cmbTipPag.SelectedIndex > 0)
              IsOk = SaveScadenze(IdSel);
            else
              IsOk = SaveScadenzaDefault(IdSel);
          }

          if (IsOk)
          {
            MessageBox.Show("Aggiornamento effettuato.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            groupBox2.Enabled = true;
            EnableCommand(true);
          }
          else
          {
            MessageBox.Show("La Fattura è stata salvata, ma si sono presentati degli errori nel salvataggio delle scadenze di pagamento.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }

          //Devo impostare la modifica della data fattura solo per l'anno della fattura
          if (dtpData.MinDate.Year < dtpData.Value.Year)
            dtpData.MinDate = Convert.ToDateTime(dtpData.Value.Year.ToString() + "/01/01");

          dtpData.MaxDate = Convert.ToDateTime(dtpData.Value.Year.ToString() + "/12/31");
        }
      }
    }

    private bool VerificaCampi()
    {
      bool bRetValue = true;
      string strErrore = "";

      if (cmbCliente.SelectedIndex < 1) strErrore += "Richiesto inserimento Cliente\n";
      if (dgvResult.Rows.Count == 0) strErrore += "Richiesto inserimento di almeno una Voce \n";

      if (cmbModFatt.SelectedIndex < 1) strErrore += "Richiesta una modalità di generazione PFD\n";

      if (strErrore != "")
      {
        MessageBox.Show("Verificare i parametri inseriti:\n\n" + strErrore, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        bRetValue = false;
      }

      return bRetValue;
    }

    private bool VerificaCampiXml()
    {
      bool bRetValue = true;
      string strErrore = "";

      if (dtpData.Value < (new DateTime(2019, 1, 1)))
      {
        MessageBox.Show("Non è possibile generare Xml per fatture antecedenti allo 01-01-2019\n", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return false;
      }

      if (cmbCliente.SelectedIndex < 1) strErrore += "Richiesto inserimento Cliente\n";
      if (dgvResult.Rows.Count == 0) strErrore += "Richiesto inserimento di almeno una Voce \n";

      if (cmbCondPag.SelectedIndex < 1) strErrore += "Richieste condizioni di pagamento\n";
      if (cmbModPag.SelectedIndex < 1) strErrore += "Richieste modalità di pagamento\n";

      if (cmbModFattXml.SelectedIndex < 1) strErrore += "Richiesta una modalità di generazione XML\n";

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
      int bSaveLastFat = 0;
      string strSql = "";
      string strBancaAppoggio = "";

      if (grpbBanca.Enabled)
      {
        if (pnlBancaAz.Visible)
          strBancaAppoggio = "IBAN: " + txtIbanAz.Text;
        else
          strBancaAppoggio = "ABI: " + txtABI.Text + "  CAB: " + txtCAB.Text;
      }

      int IdClientePdf = 0;
      int IdClienteXml = 0;
      string DescrClientePdf = "";
      string DescrClienteXml = "";

      if (m_IdClientePdf == ((_dataItemCombo)cmbModFatt.SelectedItem).Id)
      {
        IdClientePdf = m_IdClientePdf;
        DescrClientePdf = m_DescrClientePdf;
      }
      else
      {
        IdClientePdf = ((_dataItemCombo)cmbModFatt.SelectedItem).Id;
        DescrClientePdf = ((_dataItemCombo)cmbModFatt.SelectedItem).Tag.ToString();
      }

      if (m_IdClienteXml == ((_dataItemCombo)cmbModFattXml.SelectedItem).Id)
      {
        IdClienteXml = m_IdClienteXml;
        DescrClienteXml = m_DescrClienteXml;
      }
      else
      {
        IdClienteXml = ((_dataItemCombo)cmbModFattXml.SelectedItem).Id;
        DescrClienteXml = ((_dataItemCombo)cmbModFattXml.SelectedItem).Tag.ToString();
      }


      if (IdSel > 0)
      {

        //Determino se sto modificando l'ultima fattura
        //strSql = "Select count(*) from Documenti d, parametri p where d.ID= " + IdSel.ToString() +" and d.docu_data = p.last_date_fattura and d.docu_numero = p.last_num_fattura";
        strSql = "Select max(id) from documenti";
        int LastIdFat = (int)clsDataBase.ExecuteScalar(strSql);
        if (LastIdFat == IdSel) bSaveLastFat = 1;

        //Update
        strSql = "Update Documenti set " +
                    "ID_cliente = " + ((_dataItemCombo)cmbCliente.SelectedItem).Id.ToString() + "" +
                    ", docu_data = " + clsDataBase.SQL_ConvertDateTimeToData(dtpData.Value) + "" +
                    ", ID_tipi_pagamento = " + ((_dataItemCombo)cmbTipPag.SelectedItem).Id.ToString() + "" +
                    ", docu_coeficente = " + nudCoeff.Value.ToString().Replace(",", ".") + "" +
                    ", docu_bolli = " + nudBolli.Value.ToString().Replace(",", ".") + "" +
                    ", docu_note = '" + txtNote.Text.Replace("'", "''") + "'" +
                    ", docu_tipo = " + TipoDoc.GetHashCode().ToString() +
                    ", docu_esenzione = '" + ((cmbEsenzione.SelectedIndex >= 0) ? ((ComboboxItem)cmbEsenzione.SelectedItem).Text : "").ToString().Replace("'", "''") + "'" +

                    ", Id_banca_az = " + ((_dataItemCombo)cmbBancaAz.SelectedItem).Id.ToString() + "" +
                    ", docu_cl_abi = '" + txtABI.Text + "'" +
                    ", docu_cl_cab = '" + txtCAB.Text + "'" +
                    ", docu_banca_app = '" + strBancaAppoggio + "'" +

                    ", docu_id_fattura_pdf = " + IdClientePdf.ToString() +
                    ", docu_id_fattura_xml = " + IdClienteXml.ToString() +
                    ", docu_descr_fattura_pdf ='" + DescrClientePdf.Replace("'", "''") + "'" +
                    ", docu_descr_fattura_xml ='" + DescrClienteXml.Replace("'", "''") + "'" +

                    " Where id= " + IdSel.ToString();
      }
      else
      {
        //Insert

        strSql = "Insert into Documenti (ID_cliente, docu_data, ID_tipi_pagamento, docu_coeficente, docu_bolli, docu_note, docu_tipo, docu_esenzione " +
                    ", Id_banca_az, docu_cl_abi, docu_cl_cab, docu_banca_app, docu_id_fattura_pdf, docu_id_fattura_xml, docu_descr_fattura_pdf, docu_descr_fattura_xml) values (" +

                    " " + ((_dataItemCombo)cmbCliente.SelectedItem).Id.ToString() + "" +
                    ", " + clsDataBase.SQL_ConvertDateTimeToData(dtpData.Value) + "" +
                    ", " + ((_dataItemCombo)cmbTipPag.SelectedItem).Id.ToString() + "" +
                    ", " + nudCoeff.Value.ToString().Replace(",", ".") + "" +
                    ", " + nudBolli.Value.ToString().Replace(",", ".") + "" +
                    ", '" + txtNote.Text.Replace("'", "''") + "'" +
                    ", " + TipoDoc.GetHashCode().ToString() +
                    ", '" + ((cmbEsenzione.SelectedIndex >= 0) ? ((ComboboxItem)cmbEsenzione.SelectedItem).Text : "").ToString().Replace("'", "''") + "'" +
                    ", " + ((_dataItemCombo)cmbBancaAz.SelectedItem).Id.ToString() + "" +
                    ", '" + txtABI.Text + "'" +
                    ", '" + txtCAB.Text + "'" +
                    ", '" + strBancaAppoggio + "'" +

                    ", " + IdClientePdf.ToString() +
                    ", " + IdClienteXml.ToString() +
                    ", '" + DescrClientePdf.Replace("'", "''") + "'" +
                    ", '" + DescrClienteXml.Replace("'", "''") + "'" +

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
          NumFattura = clsDataBase.SetNumFattura(IdSel, dtpData.Value);

          txtNum.Text = GeneraCodiceFat(dtpData.Value.ToString("yyyy"), NumFattura);
          //strSql = "Select docu_numero from Documenti where id=" + IdSel.ToString();
          //txtNum.Text = clsDataBase.ExecuteScalar(strSql).ToString();
        }
        else
        {
          if (bSaveLastFat == 1)
          {
            if (!clsDataBase.SetLastDateFattura(dtpData.Value))
              return false;
          }
        }

        //devo effettuare la sola insert del dettaglio documento
        //gli aggiornamenti sono salvati al momento della modifica stessa
        bool bRet = true;
        for (int i = 0; i < dgvResult.Rows.Count && bRet; i++)
        {
          if (dgvResult["ColId", i].Value == null)
            bRet = InsertDttDocumento(i);
          else
            bRet = UpdateDttDocumento(i);
          if (bRet && dgvResult["ColIdViaggio", i].Value != null && (int)dgvResult["ColIdViaggio", i].Value > 0)
          {
            //Impost viaggio come fatturato
            strSql = "Update Viaggi set viaggi_fatturato = 1, viaggi_numfattura = " + NumFattura + ", viaggi_datafattura = " + clsDataBase.SQL_ConvertDateTimeToData(dtpData.Value) + " where id=" + dgvResult["ColIdViaggio", i].Value.ToString();
            clsDataBase.ExecuteNonQuery(strSql);
          }
        }

        //Ricarico la lista
        LoadListaDettaglio(IdSel);
        RetValue = bRet;
      }

      return RetValue;
    }

    private bool DeleteScadenze(int IdFattura)
    {
      bool RetValue = true;

      string strSql = "select count(*) from Scadenze where ID_documento = " + IdFattura.ToString() + " and Scandenza_incassato > 0";
      if ((int)clsDataBase.ExecuteScalar(strSql) > 0)
      {
        if (MessageBox.Show("Per il presente documento sono presenti scadenze con incassi già avvenuti.\nPer poter salvare il documento con le nuove impostazioni è necessario eliminare i pagamenti già avvenuti, pagamenti che non saranno più disponibili.\n\nProcedere con l'eliminazione dei pagamenti e con il salvataggio del documento ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
          RetValue = false;
      }

      if (RetValue)
      {
        strSql = "Delete Scadenze where ID_documento = " + IdFattura.ToString();
        RetValue = clsDataBase.ExecuteNonQuery(strSql);
      }

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
              " WHERE t.ID=" + ((_dataItemCombo)cmbTipPag.SelectedItem).Id + "";

      if (clsDataBase.ExecuteQuery(strSql))
      {
        RetValue = true;
        while (clsDataBase.vetDbReader[0].Read() && RetValue)
        {
          DateTime DataScadenza = dtpData.Value;
          if (!clsDataBase.GetBoolValue("Tipi_pagam_data_fattura") && !clsDataBase.GetBoolValue("Tipi_pagam_fine_mese"))
          {
            //Immediato
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
            {
              if (clsDataBase.GetIntValue("Dtt_tipi_pagamento_gg") % 30 == 0)
                DataScadenza = DataScadenza.AddMonths(clsDataBase.GetIntValue("Dtt_tipi_pagamento_gg") / 30);
              else
                DataScadenza = DataScadenza.AddDays(clsDataBase.GetIntValue("Dtt_tipi_pagamento_gg"));

            }
            if (clsDataBase.GetBoolValue("Tipi_pagam_fine_mese"))
            {
              if (clsDataBase.GetIntValue("Dtt_tipi_pagamento_gg") % 30 == 0)
                DataScadenza = DataScadenza.AddMonths(clsDataBase.GetIntValue("Dtt_tipi_pagamento_gg") / 30);
              else
                DataScadenza = DataScadenza.AddDays(clsDataBase.GetIntValue("Dtt_tipi_pagamento_gg"));

              //DataScadenza = DataScadenza.AddDays(clsDataBase.GetIntValue("Dtt_tipi_pagamento_gg"));
              DataScadenza = DataScadenza.AddDays(-DataScadenza.Day);
              DataScadenza = DataScadenza.AddMonths(1);
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
          if (objRow.Cells["ColTot"].Value != null && objRow.Cells["ColIva"].Value != null)
            dIva += Convert.ToDecimal(objRow.Cells["ColTot"].Value.ToString()) * Convert.ToDecimal(objRow.Cells["ColIva"].Value.ToString()) / 100;

          //if (objRow.Cells["ColIva"].Value != null && objRow.Cells["ColTot"].Value != null)
          //{
          bool isGest = false;
          for (int i = 0; i < dgvIVA.Rows.Count && !isGest; i++)
          {
            if (objRow.Cells["ColIva"].Value == null) objRow.Cells["ColIva"].Value = "0,00";
            if (objRow.Cells["ColTot"].Value == null) objRow.Cells["ColTot"].Value = "0,00";

            if (Convert.ToDecimal(objRow.Cells["ColIva"].Value.ToString()) == Convert.ToDecimal(dgvIVA[0, i].Value.ToString()))
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


      if (dgvIVA.RowCount > 1)
      {
        if ((cmbModFatt.SelectedIndex > 2) || (cmbModFattXml.SelectedIndex > 1))
        {
          MessageBox.Show("Non è possibile selezionare un formato breve fattura se sono presenti articoli con differenti aliquote IVA", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          if (cmbModFatt.SelectedIndex > 2)
            cmbModFatt.SelectedIndex = 0;

          if (cmbModFattXml.SelectedIndex > 1)
            cmbModFattXml.SelectedIndex = 0;
        }
      }

    }

    private bool InsertDttDocumento(int IdRow)
    {
      bool bRet = false;
      string strSql = "";

      strSql = "Insert into Dtt_documenti (ID_documento,dtt_docu_cod_art,dtt_docu_tratta,dtt_docu_truck,dtt_docu_ddt_n,dtt_docu_ddt_data,dtt_docu_descrizione,dtt_docu_qta,dtt_docu_um,dtt_docu_prezzo_u,dtt_docu_percent_iva,dtt_docu_km, dtt_id_viaggio, dtt_id_iva, dtt_docu_pos) values (" +
                              "" + IdSel.ToString() + "" +
                              ", '" + dgvResult["ColCod", IdRow].Value.ToString().Replace("'", "''") + "'" +
                              ", '" + dgvResult["ColViaggio", IdRow].Value.ToString().Replace("'", "''") + "'" +
                              ", '" + dgvResult["ColTruck", IdRow].Value.ToString().Replace("'", "''") + "'" +
                              ", '" + dgvResult["ColDDT", IdRow].Value.ToString().Replace("'", "''") + "'";
      if (dgvResult["ColData", IdRow].Value.ToString() == "")
        strSql += ", null";
      else
        strSql += ", " + clsDataBase.SQL_ConvertStrToData(((DateTime)dgvResult["ColData", IdRow].Value).ToString("dd/MM/yyyy")) + "";

      strSql += ", '" + dgvResult["ColDescr", IdRow].Value.ToString().Replace("'", "''") + "'" +
                       ", " + dgvResult["ColQta", IdRow].Value.ToString().Replace(",", ".") + "" +
                       ", '" + dgvResult["ColUM", IdRow].Value.ToString().Replace("'", "''") + "'" +
                       ", " + dgvResult["colPrezzo", IdRow].Value.ToString().Replace(",", ".") + "" +
                       ", " + dgvResult["ColIva", IdRow].Value.ToString().Replace(",", ".") + "" +
                       ", " + dgvResult["ColKM", IdRow].Value.ToString().Replace(",", ".") + "";
      if (dgvResult["ColIdViaggio", IdRow].Value != null && (int)dgvResult["ColIdViaggio", IdRow].Value > 0)
        strSql += ", " + dgvResult["ColIdViaggio", IdRow].Value.ToString() + "";
      else
        strSql += ", 0" + "";

      if (dgvResult["ColIdIva", IdRow].Value != null && (int)dgvResult["ColIdIva", IdRow].Value > 0)
        strSql += ", " + dgvResult["ColIdIva", IdRow].Value.ToString() + "";
      else
        strSql += ", -1" + "";


      strSql += ", " + IdRow.ToString() + "" + ")";


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
                              ", dtt_docu_km=" + dgvResult["ColKM", IdRow].Value.ToString().Replace(",", ".") + "" +
                              ", dtt_docu_pos=" + IdRow.ToString() + "" +
                              ", dtt_docu_tratta='" + dgvResult["ColViaggio", IdRow].Value.ToString().Replace("'", "''") + "'" +
                              ", dtt_docu_cod_art='" + dgvResult["ColCod", IdRow].Value.ToString().Replace("'", "''") + "'" +
                              ", dtt_docu_truck='" + dgvResult["ColTruck", IdRow].Value.ToString().Replace("'", "''") + "'" +
                              ", dtt_docu_ddt_n='" + dgvResult["ColDDT", IdRow].Value.ToString().Replace("'", "''") + "'";
      if (dgvResult["ColData", IdRow].Value.ToString() == "")
        strSql += ", dtt_docu_ddt_data = null";
      else
        strSql += ", dtt_docu_ddt_data = " + clsDataBase.SQL_ConvertStrToData(((DateTime)dgvResult["ColData", IdRow].Value).ToString("dd/MM/yyyy")) + "";


      if (dgvResult["ColIdIva", IdRow].Value != null && (int)dgvResult["ColIdIva", IdRow].Value > 0)
        strSql += ", dtt_id_iva = " + dgvResult["ColIdIva", IdRow].Value.ToString() + "";
      else
        strSql += ", dtt_id_iva = -1" + "";

      strSql += " Where id=" + dgvResult[0, IdRow].Value.ToString();

      return clsDataBase.ExecuteNonQuery(strSql);
    }

    private void bttModificaVoce_Click(object sender, EventArgs e)
    {
      if (dgvResult.CurrentRow == null) return;
      if (MessageBox.Show("Modificare la voce di dettaglio selezionata ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) return;


      //Procedo con la modifca
      frmModDocViaggi frmNew = new frmModDocViaggi();

      clsGlobal._DettFat DettFatt = new clsGlobal._DettFat();

      frmNew.IsInsertDettFatt = true;
      if (cmbCliente.SelectedIndex > 0)
        DettFatt.Id_Cliente = ((_dataItemCombo)cmbCliente.SelectedItem).Id;
      else
        DettFatt.Id_Cliente = 0;

      SettDettFatt(ref DettFatt, dgvResult.CurrentRow.Index);

      //frmNew.SetDettFatt(DettFatt);
      frmNew.LoadInfoDettFatt(DettFatt);

      frmNew.ShowDialog();
      if (frmNew.IsChange)
      {
        SetIsChange();

        InsertDettFatt(frmNew.DettFatt, dgvResult.CurrentRow.Index);
        //InsertDettViaggio(frmNew.IdSel);
        CalcolaRiepilogo();
      }
      frmNew.Dispose();

      //if (dgvResult.CurrentRow != null)
      //    SetChangeItemPag(dgvResult.CurrentRow.Index, true);

      //return;

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
      if (dgvResult.Rows.Count == 0) return;

      string strSql = "";

      if (MessageBox.Show("Eliminare la voce di dettaglio selezionata ?.", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
        return;

      //Procedo con la modifca
      if (dgvResult[0, dgvResult.CurrentRow.Index].Value != null)
      {
        SetIsChange();
        //devo prendere il valore di dtt_id_viaggio
        //dgvResult.CurrentRow.Cells["ColIdViaggio"].Value.ToString()

        if (dgvResult.CurrentRow.Cells["ColIdViaggio"].Value != null && (int)dgvResult.CurrentRow.Cells["ColIdViaggio"].Value > 0)
        {
          strSql = "update Viaggi set viaggi_fatturato = 0, viaggi_numfattura = null, viaggi_datafattura = null where Id=" + dgvResult.CurrentRow.Cells["ColIdViaggio"].Value.ToString();
          clsDataBase.ExecuteNonQuery(strSql);
        }

        //Devo Eliminare il record
        strSql = "Delete Dtt_documenti where Id=" + dgvResult[0, dgvResult.CurrentRow.Index].Value.ToString();
        clsDataBase.ExecuteNonQuery(strSql);
      }
      dgvResult.Rows.RemoveAt(dgvResult.CurrentRow.Index);

      CalcolaRiepilogo();
    }

    private void bttUp_Click(object sender, EventArgs e)
    {
      if (dgvResult.Rows.Count == 0) return;

      SetIsChange();

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
      if (dgvResult.Rows.Count == 0) return;

      SetIsChange();

      int SelRowDttToMove = dgvResult.CurrentRow.Index;
      int IdDett1 = -1;
      int IdDett2 = -1;
      int idNewPosDett1 = -1;
      int idNewPosDett2 = -1;

      if (clsGlobal.DataGridRowMoveUpDown(dgvResult, SelRowDttToMove, false))
      {
        if (IdSel > 0)
        {
          if (dgvResult[0, SelRowDttToMove].Value != null)
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
      string strMsg = "";

      if (bIsChange)
        strMsg = "La fattura è stata modificata senza essere salvata.\n\n";

      if (MessageBox.Show(strMsg + "Chiudere la finestra corrente", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
        e.Cancel = true;

    }

    private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetIsChange();
      LoadInfoCliente(((_dataItemCombo)cmbCliente.SelectedItem).Id);
    }

    private void LoadInfoCliente(int IdCliente)
    {
      string strSql = "Select Cln_iban,Cln_banca_descr,cln_banca_cab,Cln_banca_abi,Cln_banca_cc,Cln_banca_cin,Cln_banca_swift,Cln_ID_Tipi_pagamento, Cln_iva, Cln_Note_Fatt, Cln_ID_Banca_azienda, IsNull(Cln_id_fattura_pdf, 0) As Cln_id_fattura_pdf, IsNull(Cln_id_fattura_xml, 0) As Cln_id_fattura_xml, IsNull(Cln_descr_fattura_pdf, '') As Cln_descr_fattura_pdf, IsNull(Cln_descr_fattura_xml, '') As Cln_descr_fattura_xml from Clienti where ID=" + IdCliente.ToString();
      int ReaderIndex = clsDataBase.GetFreeDbReaderIndex();
      txtABI.Text = " ";
      txtIVA.Text = " ";
      txtBanca.Text = " ";
      txtCAB.Text = " ";
      txtCC.Text = " ";
      txtIBAN.Text = " ";
      cmbTipPag.Tag = 0;
      txtNote.Text = " ";
      cmbBancaAz.Tag = 0;
      bttImpViaggi.Enabled = false;

      m_DescrClientePdf = "";
      m_DescrClienteXml = "";

      m_IdClientePdf = 0;
      m_IdClienteXml = 0;

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

          cmbTipPag.Tag = clsDataBase.GetIntValue("Cln_ID_Tipi_pagamento", ReaderIndex);
          txtNote.Text = clsDataBase.GetStringValue("Cln_Note_Fatt", ReaderIndex) + " " + clsSetting.param_note_fattura;
          cmbBancaAz.Tag = clsDataBase.GetIntValue("Cln_ID_Banca_azienda", ReaderIndex);
          bttImpViaggi.Enabled = true;

          cmbModFatt.Tag = clsDataBase.GetIntValue("Cln_id_fattura_pdf", ReaderIndex);
          cmbModFattXml.Tag = clsDataBase.GetIntValue("Cln_id_fattura_xml", ReaderIndex);

          m_DescrClientePdf = clsDataBase.GetStringValue("Cln_descr_fattura_pdf", ReaderIndex);
          m_DescrClienteXml = clsDataBase.GetStringValue("Cln_descr_fattura_xml", ReaderIndex);
          m_IdClientePdf = clsDataBase.GetIntValue("Cln_id_fattura_pdf", ReaderIndex);
          m_IdClienteXml = clsDataBase.GetIntValue("Cln_id_fattura_xml", ReaderIndex);
          
        }


      }
      clsDataBase.PopolaCombo(cmbTipPag, clsGlobal.ETypeTable.TT_TIP_PAGAMENTO);
      clsDataBase.PopolaCombo(cmbBancaAz, clsGlobal.ETypeTable.TT_BANCHE_AZ);
      clsDataBase.CloseDataReader(ReaderIndex);
    }

    private void bttNuovaVoce_Click(object sender, EventArgs e)
    {
      if (IdSel > 0)
        if (MessageBox.Show("Inserire una nuova voce di dettaglio ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) return;

      //Procedo con la modifca
      frmModDocViaggi frmNew = new frmModDocViaggi();

      clsGlobal._DettFat DettFatt = new clsGlobal._DettFat();

      frmNew.IsInsertDettFatt = true;

      if (cmbCliente.SelectedIndex > 0)
        DettFatt.Id_Cliente = ((_dataItemCombo)cmbCliente.SelectedItem).Id;
      else
        DettFatt.Id_Cliente = 0;

      DettFatt.CodArticolo = "";
      DettFatt.Tratta = "";
      DettFatt.Truck = "";
      DettFatt.DDT = "";
      DettFatt.Data = DateTime.MinValue;
      DettFatt.Descr = "";
      DettFatt.Qta = 0;
      DettFatt.Um = "";
      DettFatt.Prezzo = 0;
      DettFatt.IVA = 0;
      DettFatt.KM = 0;
      DettFatt.Note = "";

      //frmNew.SetDettFatt(DettFatt);
      frmNew.LoadInfoDettFatt(DettFatt);

      frmNew.ShowDialog();
      if (frmNew.IsChange)
      {
        SetIsChange();

        InsertDettFatt(frmNew.DettFatt);
        //InsertDettViaggio(frmNew.IdSel);
        CalcolaRiepilogo();
      }
      frmNew.Dispose();
    }

    private void bttStampa_Click(object sender, EventArgs e)
    {
      string TipoDocumento = txtTipoDoc.Text;
      if (TipoDoc == ETypeDoc.TD_FAT)
      {
        if (!DeleteScadenze(IdSel))
          return;

        TipoDocumento = "Resoconto " + TipoDocumento;
      }
      else
        TipoDocumento = "Resoconto NdC";

      if (SaveFattura())
      {
        bool IsOk = true;
        if (TipoDoc == ETypeDoc.TD_FAT)
        {
          if (cmbTipPag.SelectedIndex > 0)
            IsOk = SaveScadenze(IdSel);
          else
            IsOk = SaveScadenzaDefault(IdSel);
        }

        //Devo impostare la modifica della data fattura solo per l'anno della fattura
        if (dtpData.MinDate.Year < dtpData.Value.Year)
          dtpData.MinDate = Convert.ToDateTime(dtpData.Value.Year.ToString() + "/01/01");

        dtpData.MaxDate = Convert.ToDateTime(dtpData.Value.Year.ToString() + "/12/31");
      }


      GeneraReport(TipoDocumento, true);

    }

    private void nudBolli_ValueChanged(object sender, EventArgs e)
    {
      lblTotLordo.Text = Math.Round(Convert.ToDecimal(lblImponibile.Text) + Convert.ToDecimal(lblImportoIva.Text) + nudBolli.Value, 2).ToString();
    }

    private void nudCoeff_ValueChanged(object sender, EventArgs e)
    {
      SetIsChange();

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

    private void dgvResult_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
      e.Control.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
      e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
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
    private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
    {
      if (e.Column.Name == "ColData")
      {
        DateTime d1 = DateTime.Parse(e.CellValue1.ToString());
        DateTime d2 = DateTime.Parse(e.CellValue2.ToString());
        if (e.SortResult > 0)
          e.SortResult = d1.CompareTo(d2);
        else
          e.SortResult = d2.CompareTo(d1);
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
      SetIsChange();

      cmbCondPag.SelectedIndex = -1;
      cmbModPag.SelectedIndex = -1;

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
            grpbBanca.Text = "Riferimenti Bancari Cliente:";

            pnlBancaAz.Visible = false;
            pnlBancaCl.Visible = true;
            grpbBanca.Enabled = false;
            break;
        }

        string[] sVal = ((_dataItemCombo)cmbTipPag.SelectedItem).Tag.Split(';');

        clsDataBase.SelezionaComboItem_2(cmbCondPag, sVal[0].ToString());
        clsDataBase.SelezionaComboItem_2(cmbModPag, sVal[1].ToString());
      }
      else
      {
        grpbBanca.Text = "Riferimenti Bancari Cliente:";
        pnlBancaAz.Visible = false;
        pnlBancaCl.Visible = true;
        grpbBanca.Enabled = false;
      }

    }

    private void cmbBancaAz_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetIsChange();

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
      string TipoDocumento = txtTipoDoc.Text;
      if (TipoDoc == ETypeDoc.TD_FAT)
      {
        if (!DeleteScadenze(IdSel))
          return;

        TipoDocumento = "Resoconto " + TipoDocumento;
      }
      else
        TipoDocumento = "Resoconto NdC";

      if (SaveFattura())
      {
        bool IsOk = true;
        if (TipoDoc == ETypeDoc.TD_FAT)
        {
          if (cmbTipPag.SelectedIndex > 0)
            IsOk = SaveScadenze(IdSel);
          else
            IsOk = SaveScadenzaDefault(IdSel);
        }

        //Devo impostare la modifica della data fattura solo per l'anno della fattura
        if (dtpData.MinDate.Year < dtpData.Value.Year)
          dtpData.MinDate = Convert.ToDateTime(dtpData.Value.Year.ToString() + "/01/01");

        dtpData.MaxDate = Convert.ToDateTime(dtpData.Value.Year.ToString() + "/12/31");
      }

      GeneraReport(TipoDocumento);
    }

    private void bttXML_Click(object sender, EventArgs e)
    {
      string Suffisso = "";

      if (TipoDoc == ETypeDoc.TD_FAT)
      {
        if (!DeleteScadenze(IdSel))
          return;
      }

      if (SaveFattura())
      {
        bool IsOk = true;
        if (TipoDoc == ETypeDoc.TD_FAT)
        {
          if (cmbTipPag.SelectedIndex > 0)
            IsOk = SaveScadenze(IdSel);
          else
            IsOk = SaveScadenzaDefault(IdSel);

          Suffisso = "_FT";
        }
        else
          if (TipoDoc == ETypeDoc.TD_NDC)
          {
            Suffisso = "_NC";
          }

        //Devo impostare la modifica della data fattura solo per l'anno della fattura
        if (dtpData.MinDate.Year < dtpData.Value.Year)
          dtpData.MinDate = Convert.ToDateTime(dtpData.Value.Year.ToString() + "/01/01");

        dtpData.MaxDate = Convert.ToDateTime(dtpData.Value.Year.ToString() + "/12/31");
      }

      if (VerificaCampiXml())
      {
        bool bReturn = clsReport.ExportFatturaToFileXml(clsDataBase.GetNextNumFatturaXml(IdSel), Suffisso, txtNum.Text, IdSel, nudBolli.Value, Convert.ToDouble(lblTotLordo.Text), ((_dataItemCombo)cmbModFattXml.SelectedItem).Tag.ToString(), "");
        if (bReturn)
        {
          lblXmlAtt.Text = "";
          lblXml.Text = FromNumToDateString(DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("HHmmss"));
        }
      }
    }

    private void btnPdfXml_Click(object sender, EventArgs e)
    {
      string Suffisso = "";

      string TipoDocumento = txtTipoDoc.Text;
      if (TipoDoc == ETypeDoc.TD_FAT)
      {
        if (!DeleteScadenze(IdSel))
          return;

        TipoDocumento = "Resoconto " + TipoDocumento;
      }
      else
        TipoDocumento = "Resoconto NdC";

      if (SaveFattura())
      {
        bool IsOk = true;
        if (TipoDoc == ETypeDoc.TD_FAT)
        {
          if (cmbTipPag.SelectedIndex > 0)
            IsOk = SaveScadenze(IdSel);
          else
            IsOk = SaveScadenzaDefault(IdSel);

          Suffisso = "_FT";
        }
        else
          if (TipoDoc == ETypeDoc.TD_NDC)
          {
            Suffisso = "_NC";
          }

        //Devo impostare la modifica della data fattura solo per l'anno della fattura
        if (dtpData.MinDate.Year < dtpData.Value.Year)
          dtpData.MinDate = Convert.ToDateTime(dtpData.Value.Year.ToString() + "/01/01");

        dtpData.MaxDate = Convert.ToDateTime(dtpData.Value.Year.ToString() + "/12/31");
      }

      GeneraReport(TipoDocumento);

      if (VerificaCampiXml())
      {
        bool bReturn = clsReport.ExportFatturaToFileXml(clsDataBase.GetNextNumFatturaXml(IdSel), Suffisso, txtNum.Text, IdSel, nudBolli.Value, Convert.ToDouble(lblTotLordo.Text), ((_dataItemCombo)cmbModFattXml.SelectedItem).Tag.ToString(), "");
        if (bReturn)
        {
          lblXmlAtt.Text = "";
          lblXml.Text = FromNumToDateString(DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("HHmmss"));
        }

      }
    }

    private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void dgvResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {

      bttModificaVoce_Click(null, null);

    }
    private void dtpData_ValueChanged(object sender, EventArgs e)
    {
      SetIsChange();
    }

    private void txtIBAN_TextChanged(object sender, EventArgs e)
    {
      SetIsChange();
    }

    private void SetIsChange(bool Value = true)
    {
      bIsChange = Value;
      bttStampa.Enabled = bttPDF.Enabled = !Value;
      cmbMostraInGriglia.Enabled = !Value;

      bttXML.Enabled = !Value && clsSetting.ATTIVA_XML;
      btnPdfXml.Enabled = !Value && clsSetting.ATTIVA_XML;
      btnXmlWithAtt.Enabled = !Value && clsSetting.ATTIVA_XML;
      btnXmlWithPdfAtt.Enabled = !Value && clsSetting.ATTIVA_XML;
    }

    private void txtBanca_TextChanged(object sender, EventArgs e)
    {
      SetIsChange();
    }

    private void txtCAB_TextChanged(object sender, EventArgs e)
    {
      SetIsChange();
    }

    private void txtABI_TextChanged(object sender, EventArgs e)
    {
      SetIsChange();
    }

    private void txtCC_TextChanged(object sender, EventArgs e)
    {
      SetIsChange();
    }

    private void txtEsenzione_TextChanged(object sender, EventArgs e)
    {
      SetIsChange();
    }

    private void txtNote_TextChanged(object sender, EventArgs e)
    {
      SetIsChange();
    }

    private void frmModFattura_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (frmParent != null)
        frmParent.Show();
    }

    private void bttTabClienti_Click(object sender, EventArgs e)
    {
      clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_CLIENTI, cmbCliente);
    }

    private void bttTabTipoPag_Click(object sender, EventArgs e)
    {
      clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_TIP_PAGAMENTO, cmbTipPag);
    }

    private void bttTabBancAz_Click(object sender, EventArgs e)
    {
      clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_BANCHE_AZ, cmbBancaAz);
    }

    private void bttTabEsenz_Click(object sender, EventArgs e)
    {
      clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_ESENZIONI, cmbEsenzione);
    }

    private void groupBox2_Enter(object sender, EventArgs e)
    {

    }



    private void bttImpViaggi_Click_1(object sender, EventArgs e)
    {
      if (cmbCliente.SelectedIndex <= 0)
      {
        MessageBox.Show("Selezionare un cliente", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }
      //Procedo con la modifca

      string strSql = " select * from Viaggi  where viaggi_cancellato = 0 and viaggi_fatturato = 0 and Id_cliente = " + ((_dataItemCombo)cmbCliente.SelectedItem).Id + "";

      if (clsDataBase.ExecuteQuery(strSql))
      {
        if (!(clsDataBase.vetDbReader[0].Read()))
        {
          MessageBox.Show("Nessun viaggio da fatturare per il cliente selezionato", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          clsDataBase.CloseDataReader();
          return;
        }
        else
        {
          clsDataBase.CloseDataReader();
          frmDocViaggi frmNew = new frmDocViaggi();
          frmNew.CLTSel = ((_dataItemCombo)cmbCliente.SelectedItem).Id;
          frmNew.ShowDialog();
          if (frmNew.GoImport)
          {
            groupBox2.Enabled = false;
            for (int i = 0; i < frmNew.dgvResult.Rows.Count; i++)
            {
              if (frmNew.dgvResult["ColChk", i].Value != null && (bool)frmNew.dgvResult["ColChk", i].Value)
                InsertDettViaggio((int)frmNew.dgvResult["ID", i].Value);
            }
            cmbCliente.Enabled = false;
            SetIsChange();
            //InsertDettViaggio(frmNew.IdSel);
            CalcolaRiepilogo();
          }
          frmNew.Dispose();
        }
      }

    }

    private static string FromNumToDateString(int DataNumerica, int OraNumerica = 0)
    {
      string DataStringa = DataNumerica.ToString();
      string OraStringa = OraNumerica.ToString();
      if (DataStringa.Length == 8)
      {
        string strRet = DataStringa.Substring(6, 2) + "-" + DataStringa.Substring(4, 2) + "-" + DataStringa.Substring(0, 4);
        if (OraNumerica > 0)
        {
          if (OraStringa.Length == 6)
            strRet += " " + OraStringa.Substring(0, 2) + ":" + OraStringa.Substring(2, 2) + ":" + OraStringa.Substring(4, 2);
          else
            strRet += " " + OraStringa.Substring(0, 1) + ":" + OraStringa.Substring(1, 2) + ":" + OraStringa.Substring(3, 2);

        }
        return strRet;
      }
      else
        return "";
    }

    private static string FromNumToDateString(string DataStringa, string OraStringa = "")
    {
      if (DataStringa.Length == 8)
      {
        string strRet = DataStringa.Substring(6, 2) + "-" + DataStringa.Substring(4, 2) + "-" + DataStringa.Substring(0, 4);
        if (OraStringa.Length > 0)
        {
          if (OraStringa.Length == 6)
            strRet += " " + OraStringa.Substring(0, 2) + ":" + OraStringa.Substring(2, 2) + ":" + OraStringa.Substring(4, 2);
          else
            strRet += " " + OraStringa.Substring(0, 1) + ":" + OraStringa.Substring(1, 2) + ":" + OraStringa.Substring(3, 2);

        }
        return strRet;
      }
      else
        return "";
    }

    private void cmbEsenzione_MouseHover(object sender, EventArgs e)
    {
    }

    private void btnXmlWithPdfAtt_Click(object sender, EventArgs e)
    {
      string Suffisso = "";

      string TipoDocumento = txtTipoDoc.Text;
      if (TipoDoc == ETypeDoc.TD_FAT)
      {
        if (!DeleteScadenze(IdSel))
          return;

        TipoDocumento = "Resoconto " + TipoDocumento;
      }
      else
        TipoDocumento = "Resoconto NdC";

      if (SaveFattura())
      {
        bool IsOk = true;
        if (TipoDoc == ETypeDoc.TD_FAT)
        {
          if (cmbTipPag.SelectedIndex > 0)
            IsOk = SaveScadenze(IdSel);
          else
            IsOk = SaveScadenzaDefault(IdSel);

          Suffisso = "_FT";
        }
        else
          if (TipoDoc == ETypeDoc.TD_NDC)
          {
            Suffisso = "_NC";
          }

        //Devo impostare la modifica della data fattura solo per l'anno della fattura
        if (dtpData.MinDate.Year < dtpData.Value.Year)
          dtpData.MinDate = Convert.ToDateTime(dtpData.Value.Year.ToString() + "/01/01");

        dtpData.MaxDate = Convert.ToDateTime(dtpData.Value.Year.ToString() + "/12/31");
      }

      string strPathOrig = GeneraReport(TipoDocumento, false, true);

      if (VerificaCampiXml())
      {
        string strPath = clsSetting.param_path_save_att;
        if (!System.IO.Directory.Exists(strPath))
          System.IO.Directory.CreateDirectory(strPath);

        strPath += "\\" + txtNum.Text;
        if (!System.IO.Directory.Exists(strPath))
          System.IO.Directory.CreateDirectory(strPath);

        strPath += "\\" + clsReport.GetFileName(strPathOrig);

        System.IO.File.Copy(strPathOrig, strPath, true);

        bool bReturn = clsReport.ExportFatturaToFileXml(clsDataBase.GetNextNumFatturaXml(IdSel), Suffisso, txtNum.Text, IdSel, nudBolli.Value, Convert.ToDouble(lblTotLordo.Text), ((_dataItemCombo)cmbModFattXml.SelectedItem).Tag.ToString(), strPath);
        if (bReturn)
        {
          lblXmlAtt.Text = clsReport.GetFileName(strPathOrig);
          lblXml.Text = FromNumToDateString(DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("HHmmss"));
        }
      }
    }

    private void btnXmlWithAtt_Click(object sender, EventArgs e)
    {
      string Suffisso = "";

      if (TipoDoc == ETypeDoc.TD_FAT)
      {
        if (!DeleteScadenze(IdSel))
          return;
      }

      if (SaveFattura())
      {
        bool IsOk = true;
        if (TipoDoc == ETypeDoc.TD_FAT)
        {
          if (cmbTipPag.SelectedIndex > 0)
            IsOk = SaveScadenze(IdSel);
          else
            IsOk = SaveScadenzaDefault(IdSel);

          Suffisso = "_FT";
        }
        else
          if (TipoDoc == ETypeDoc.TD_NDC)
          {
            Suffisso = "_NC";
          }

        //Devo impostare la modifica della data fattura solo per l'anno della fattura
        if (dtpData.MinDate.Year < dtpData.Value.Year)
          dtpData.MinDate = Convert.ToDateTime(dtpData.Value.Year.ToString() + "/01/01");

        dtpData.MaxDate = Convert.ToDateTime(dtpData.Value.Year.ToString() + "/12/31");
      }

      if (VerificaCampiXml())
      {
        string strPath = "";
        OpenFileDialog dlgFile = new OpenFileDialog();
        dlgFile.Multiselect = false;
        dlgFile.Filter = "Pdf|*.pdf";

        if (dlgFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
          strPath = clsSetting.param_path_save_att;
          if (!System.IO.Directory.Exists(strPath))
            System.IO.Directory.CreateDirectory(strPath);

          strPath += "\\" + txtNum.Text;
          if (!System.IO.Directory.Exists(strPath))
            System.IO.Directory.CreateDirectory(strPath);

          strPath += "\\" + clsReport.GetFileName(dlgFile.FileName);
          
          System.IO.File.Copy(dlgFile.FileName, strPath, true);

          bool bReturn = clsReport.ExportFatturaToFileXml(clsDataBase.GetNextNumFatturaXml(IdSel), Suffisso, txtNum.Text, IdSel, nudBolli.Value, Convert.ToDouble(lblTotLordo.Text), ((_dataItemCombo)cmbModFattXml.SelectedItem).Tag.ToString(), strPath);
          if (bReturn)
          {
            lblXmlAtt.Text = clsReport.GetFileName(strPath);
            lblXml.Text = FromNumToDateString(DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("HHmmss"));
          }
        }
      }
    }

    private string GeneraReport(string TipoDocumento, bool bStampa = false, bool bNoApertura = false)
    {
      string strPathFile = "";

      switch (cmbModFatt.SelectedIndex)
      {
        case 1:
          crpDocFattura newReport_2 = new crpDocFattura();

          clsReport.InizializzaReport(newReport_2);
          newReport_2.SetParameterValue("IdFatt2", IdSel);
          newReport_2.SetParameterValue("IdFat1", IdSel);
          newReport_2.SetParameterValue("IdFat", IdSel);
          newReport_2.SetParameterValue("TipoDocumento", TipoDocumento);

          clsReport.SetParamIntestazione(newReport_2);
          if (!bStampa)
            strPathFile = clsReport.ExportReportToFilePdf(newReport_2, "Resoconto_" + txtTipoDoc.Text + "_" + txtNum.Text, bNoApertura);
          else
            clsReport.ShowReport(newReport_2);

          break;

        case 2:
          crpDocFat1 newReport_1 = new crpDocFat1();

          clsReport.InizializzaReport(newReport_1);
          newReport_1.SetParameterValue("IdFatt2", IdSel);
          newReport_1.SetParameterValue("IdFat1", IdSel);
          newReport_1.SetParameterValue("IdFat", IdSel);
          newReport_1.SetParameterValue("TipoDocumento", TipoDocumento);

          clsReport.SetParamIntestazione(newReport_1);
          if (!bStampa)
            strPathFile = clsReport.ExportReportToFilePdf(newReport_1, "Resoconto_" + txtTipoDoc.Text + "_" + txtNum.Text, bNoApertura);
          else
            clsReport.ShowReport(newReport_1);

          break;

        default:
          crpDocFatturaBreve newReport_3 = new crpDocFatturaBreve();

          clsReport.InizializzaReport(newReport_3);
          newReport_3.SetParameterValue("IdFatt2", IdSel);
          newReport_3.SetParameterValue("IdFat1", IdSel);
          newReport_3.SetParameterValue("IdFat", IdSel);
          newReport_3.SetParameterValue("TipoDocumento", TipoDocumento);

          clsReport.SetParamIntestazione(newReport_3);

          if (!bStampa)
            strPathFile = clsReport.ExportReportToFilePdf(newReport_3, "Resoconto_" + txtTipoDoc.Text + "_" + txtNum.Text, bNoApertura);
          else
            clsReport.ShowReport(newReport_3);

          break;
      }

      return strPathFile;
    }

    private void cmbMostraInGriglia_SelectedIndexChanged(object sender, EventArgs e)
    {
      dgvResult.Visible = cmbMostraInGriglia.SelectedIndex == 0;
      dgvAnteprima.Visible = cmbMostraInGriglia.SelectedIndex != 0;

      LoadAnteprima();      
    }

    private void LoadAnteprima()
    {

      string strDescr = "";
      bool bModBreve = false;
      bool bMostraCodici = false;

      switch (cmbMostraInGriglia.SelectedIndex)
      {
        case 1:
          groupBox2.Text = "Anteprima PDF";
          bModBreve = cmbModFatt.SelectedIndex > 2;
          bMostraCodici = cmbModFatt.SelectedIndex == 2;
          strDescr = ((_dataItemCombo)cmbModFatt.SelectedItem).Descrizione;
          break;

        case 2:
          groupBox2.Text = "Anteprima XML";
          bModBreve = cmbModFattXml.SelectedIndex > 1;
          strDescr = ((_dataItemCombo)cmbModFattXml.SelectedItem).Descrizione;
          break;

        default:
          groupBox2.Text = "Elenco Voci";
          break;
      }

      if (dgvAnteprima.Visible)
      {
        if (bModBreve)
          LoadAnteprimaBreve(IdSel, strDescr);
        else
          LoadAnteprimaDett(IdSel, bMostraCodici);
      }

    }

    private bool LoadAnteprimaBreve(int IdDoc, string strDescrizione)
    {

      bool bRet = false;
      dgvAnteprima.Rows.Clear();

      //string strSql = "Select d.ID, d.ID_documento,d.dtt_docu_cod_art,d.dtt_docu_tratta,d.dtt_docu_truck,d.dtt_docu_ddt_n,d.dtt_docu_ddt_data,d.dtt_docu_descrizione,d.dtt_docu_qta,d.dtt_docu_um,d.dtt_docu_prezzo_u,d.dtt_docu_percent_iva,d.dtt_docu_km, d.dtt_docu_pos, d.dtt_id_viaggio,round(dtt_docu_prezzo_u*dtt_docu_qta,2) as Imponibile, IsNull(d.dtt_id_iva, -1) As IdIva from Dtt_documenti d where dtt_docu_cancellato=0 and ID_documento =" + IdDoc.ToString() + " Order by dtt_docu_pos asc";
      string strSql = "";  //"Select * from v_EsportaFattureBrevi where ID =" + IdDoc.ToString();

      strSql = "SELECT Documenti.ID, 1.0 As dtt_docu_qta, Dtt_documenti.dtt_docu_um, Sum(Dtt_documenti.dtt_docu_qta * Dtt_documenti.dtt_docu_prezzo_u) As dtt_docu_prezzo_u, Dtt_documenti.dtt_docu_percent_iva, Sum(Dtt_documenti.dtt_docu_km) As dtt_docu_km, Documenti.docu_coeficente, Documenti.docu_descr_fattura_xml \n" +
               "FROM   Dtt_documenti \n" +
               "INNER JOIN Documenti ON Dtt_documenti.ID_documento=Documenti.ID \n" +
               "WHERE  Dtt_documenti.dtt_docu_cancellato = 0 AND Documenti.ID = " + IdDoc.ToString() + "\n" +
               "GROUP BY Documenti.ID, Dtt_documenti.dtt_docu_um, Dtt_documenti.dtt_docu_percent_iva, Documenti.docu_coeficente, Documenti.docu_descr_fattura_xml \n";


      int ReaderIndex = clsDataBase.GetFreeDbReaderIndex();
      if (clsDataBase.ExecuteQuery(strSql, ReaderIndex))
      {
        while (clsDataBase.vetDbReader[ReaderIndex].Read())
        {
          int IdRow = dgvAnteprima.Rows.Add();
          //dgvAnteprima["ColID", IdRow].Value = clsDataBase.GetIntValue("ID");
          //dgvAnteprima["ColCod", IdRow].Value = clsDataBase.GetStringValue("dtt_docu_cod_art");
          dgvAnteprima["ColDescrAnt", IdRow].Value = strDescrizione;
          dgvAnteprima["ColQtaAnt", IdRow].Value = clsDataBase.GetDecimalValue("dtt_docu_qta", ReaderIndex);
          dgvAnteprima["ColUMAnt", IdRow].Value = clsDataBase.GetStringValue("dtt_docu_um", ReaderIndex);
          dgvAnteprima["ColPrezzoAnt", IdRow].Value = clsDataBase.GetValutaValue("dtt_docu_prezzo_u", ReaderIndex);
          dgvAnteprima["ColIvaAnt", IdRow].Value = clsDataBase.GetValutaValue("dtt_docu_percent_iva", ReaderIndex);
          dgvAnteprima["ColKMAnt", IdRow].Value = clsDataBase.GetValutaValue("dtt_docu_km", ReaderIndex);
          dgvAnteprima["ColTotAnt", IdRow].Value = clsDataBase.GetValutaValue("dtt_docu_prezzo_u", ReaderIndex) * clsDataBase.GetDecimalValue("dtt_docu_qta", ReaderIndex);

          if (dgvAnteprima["ColKMAnt", IdRow].Value != null)
            dgvAnteprima["ColGasolioAnt", IdRow].Value = Math.Round((decimal)dgvAnteprima["ColKMAnt", IdRow].Value * nudCoeff.Value, 2);
          else
            dgvAnteprima["ColGasolioAnt", IdRow].Value = 0;

        }

        dgvAnteprima.Columns["ColCodAnt"].Visible = false;
      }
      else
        bRet = false;

      clsDataBase.CloseDataReader();

      return bRet;
    }

    private bool LoadAnteprimaDett(int IdDoc, bool bMostraCodici)
    {

      bool bRet = false;
      dgvAnteprima.Rows.Clear();

      //string strSql = "Select d.ID, d.ID_documento,d.dtt_docu_cod_art,d.dtt_docu_tratta,d.dtt_docu_truck,d.dtt_docu_ddt_n,d.dtt_docu_ddt_data,d.dtt_docu_descrizione,d.dtt_docu_qta,d.dtt_docu_um,d.dtt_docu_prezzo_u,d.dtt_docu_percent_iva,d.dtt_docu_km, d.dtt_docu_pos, d.dtt_id_viaggio,round(dtt_docu_prezzo_u*dtt_docu_qta,2) as Imponibile, IsNull(d.dtt_id_iva, -1) As IdIva from Dtt_documenti d where dtt_docu_cancellato=0 and ID_documento =" + IdDoc.ToString() + " Order by dtt_docu_pos asc";
      string strSql = "";  //"Select * from v_EsportaFattureBrevi where ID =" + IdDoc.ToString();

      strSql = "SELECT Documenti.ID, Dtt_documenti.dtt_docu_qta As dtt_docu_qta, Dtt_documenti.dtt_docu_um, Dtt_documenti.dtt_docu_prezzo_u, \n" +
               "	   Dtt_documenti.dtt_docu_percent_iva, Dtt_documenti.dtt_docu_km, Documenti.docu_coeficente, Documenti.docu_descr_fattura_xml, \n" +
               "	   dtt_docu_descrizione, dtt_docu_tratta, dtt_docu_ddt_n, dtt_docu_ddt_data, dtt_docu_cod_art \n" +
               "FROM   Dtt_documenti \n" +
               "INNER JOIN Documenti ON Dtt_documenti.ID_documento=Documenti.ID \n" +
               "WHERE  Dtt_documenti.dtt_docu_cancellato = 0 AND Documenti.ID = " + IdDoc.ToString();


      int ReaderIndex = clsDataBase.GetFreeDbReaderIndex();
      if (clsDataBase.ExecuteQuery(strSql, ReaderIndex))
      {
        while (clsDataBase.vetDbReader[ReaderIndex].Read())
        {
          int IdRow = dgvAnteprima.Rows.Add();
          //dgvAnteprima["ColID", IdRow].Value = clsDataBase.GetIntValue("ID");
          dgvAnteprima["ColCodAnt", IdRow].Value = clsDataBase.GetStringValue("dtt_docu_cod_art", ReaderIndex);

          string DescrBene = clsDataBase.GetStringValue("dtt_docu_descrizione", ReaderIndex);
          if (clsDataBase.GetStringValue("dtt_docu_tratta", ReaderIndex) != "")
            DescrBene += " da " + clsDataBase.GetStringValue("dtt_docu_tratta", ReaderIndex);

          if (clsDataBase.GetStringValue("dtt_docu_ddt_n", ReaderIndex) != "")
            DescrBene += " ddt n. " + clsDataBase.GetStringValue("dtt_docu_ddt_n", ReaderIndex);

          if (clsDataBase.GetDateValue("dtt_docu_ddt_data", ReaderIndex) != DateTime.MinValue)
            DescrBene += " del " + clsDataBase.GetDateValue("dtt_docu_ddt_data", ReaderIndex).ToString("dd-MM-yyyy");

          dgvAnteprima["ColDescrAnt", IdRow].Value = DescrBene;
          dgvAnteprima["ColQtaAnt", IdRow].Value = clsDataBase.GetDecimalValue("dtt_docu_qta", ReaderIndex);
          dgvAnteprima["ColUMAnt", IdRow].Value = clsDataBase.GetStringValue("dtt_docu_um", ReaderIndex);
          dgvAnteprima["ColPrezzoAnt", IdRow].Value = clsDataBase.GetValutaValue("dtt_docu_prezzo_u", ReaderIndex);
          dgvAnteprima["ColIvaAnt", IdRow].Value = clsDataBase.GetValutaValue("dtt_docu_percent_iva", ReaderIndex);
          dgvAnteprima["ColKMAnt", IdRow].Value = clsDataBase.GetValutaValue("dtt_docu_km", ReaderIndex);
          dgvAnteprima["ColTotAnt", IdRow].Value = clsDataBase.GetValutaValue("dtt_docu_prezzo_u", ReaderIndex) * clsDataBase.GetDecimalValue("dtt_docu_qta", ReaderIndex);

          if (dgvAnteprima["ColKMAnt", IdRow].Value != null)
            dgvAnteprima["ColGasolioAnt", IdRow].Value = Math.Round((decimal)dgvAnteprima["ColKMAnt", IdRow].Value * nudCoeff.Value, 2);
          else
            dgvAnteprima["ColGasolioAnt", IdRow].Value = 0;

        }

        dgvAnteprima.Columns["ColCodAnt"].Visible = bMostraCodici;
      }
      else
        bRet = false;

      clsDataBase.CloseDataReader();

      return bRet;
    }

    private void cmbModFatt_SelectedIndexChanged(object sender, EventArgs e)
    {

      if (cmbModFatt.SelectedIndex > 2)
      {
        if (dgvIVA.RowCount > 1)
        {
          MessageBox.Show("Non è possibile selezionare un formato breve fattura se sono presenti articoli con differenti aliquote IVA", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          cmbModFatt.SelectedIndex = 0;
          return;
        }
      }

      if (dgvAnteprima.Visible)
        LoadAnteprima();
    }

    private void cmbModFattXml_SelectedIndexChanged(object sender, EventArgs e)
    {

      if (cmbModFattXml.SelectedIndex > 1)
      {
        if (dgvIVA.RowCount > 1)
        {
          MessageBox.Show("Non è possibile selezionare un formato breve fattura se sono presenti articoli con differenti aliquote IVA", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          cmbModFattXml.SelectedIndex = 0;
          return;
        }
      }

      if (dgvAnteprima.Visible)
        LoadAnteprima();
    }

    private void btnShowAtt_Click(object sender, EventArgs e)
    {

      if (lblXmlAtt.Text != "")
      {
        string strPath = clsSetting.param_path_save_att + "\\" + txtNum.Text + "\\" + lblXmlAtt.Text;

        ProcessStartInfo sPdf = new ProcessStartInfo(strPath);
        Process.Start(strPath);
      }
    }

  }
}
