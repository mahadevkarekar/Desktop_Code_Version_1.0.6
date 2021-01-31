using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;

namespace Trucks
{
    static class clsReport
    {
        public static Form FORM_PARENTE_MDI = null;
        public static CrystalDecisions.Shared.ConnectionInfo crpConnInfo = new CrystalDecisions.Shared.ConnectionInfo();

        public static void Set_Rerport_ConnInfo()
        {
            crpConnInfo.DatabaseName = clsSetting.DB_NAME;
            crpConnInfo.UserID = clsSetting.DB_USERNAME;
            crpConnInfo.Password = clsSetting.DB_PASSWORD;
            crpConnInfo.ServerName = clsSetting.DB_Server;
        }

        public static void InizializzaReport(CrystalDecisions.CrystalReports.Engine.ReportClass objReport)        
        {   
            //CrystalDecisions.CrystalReports.Engine.Tables rptTables = ((CrystalReport4)objReport).Database.Tables; //Insieme delle tabelle all'interno del report
            CrystalDecisions.CrystalReports.Engine.Tables rptTables = objReport.Database.Tables; //Insieme delle tabelle all'interno del report
            foreach( CrystalDecisions.CrystalReports.Engine.Table myTable in rptTables)
            {
                //Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
                myTable.LogOnInfo.ConnectionInfo = crpConnInfo;
                myTable.ApplyLogOnInfo(myTable.LogOnInfo);
            }
        }

        public static void ShowReport(CrystalDecisions.CrystalReports.Engine.ReportClass objReportSource)
        {
            frmShowReport frmNewReport = new frmShowReport();

            frmNewReport.objReportSource = objReportSource;
            if (FORM_PARENTE_MDI != null)
                frmNewReport.MdiParent = FORM_PARENTE_MDI;

            frmNewReport.Show();
        }

        public static void SetParamIntestazione(CrystalDecisions.CrystalReports.Engine.ReportClass objReportSource, string strFiltraggio = "")
        { 
            //objReportSource.PrintOptions.PrinterName = cStampante;
            //objReportSource.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait

            string strSql = "Select Az_rag_soc, Az_cod_fis, Az_iva, Az_ind_1 + '  ' + Az_ind_1_cap + '  ' + Az_ind_1_citta + ' (' + Az_ind_1_prov + ')' as Indirizzo, Az_tel, Az_fax, Az_email, Az_logo_path, Az_web_site from azienda ";

            string strIndirizzo = "";
            //string strPartIva = "";
            string strAzienda = "";
            string strPathLogo = "";

            if (clsDataBase.ExecuteQuery(strSql))
            {
                if(clsDataBase.vetDbReader[0].Read())
                {
                    if (clsSetting.param_stampa_dati_az_docu)
                    {
                        strAzienda = clsDataBase.GetStringValue("Az_rag_soc");
                        strIndirizzo = clsDataBase.GetStringValue("Indirizzo");
                        strIndirizzo += "\nCod. Fiscale: " + clsDataBase.GetStringValue("Az_cod_fis");
                        strIndirizzo += "\nP. Iva: " + clsDataBase.GetStringValue("Az_iva") + '\n';
                        
                        if (clsDataBase.GetStringValue("Az_tel") != "")
                            strIndirizzo += "Tel. " + clsDataBase.GetStringValue("Az_tel") + "   ";
                        if (clsDataBase.GetStringValue("Az_fax") != "")
                            strIndirizzo += "Fax " + clsDataBase.GetStringValue("Az_fax");
                        strIndirizzo += "\n";
                        if (clsDataBase.GetStringValue("Az_web_site") != "")
                            strIndirizzo += clsDataBase.GetStringValue("Az_web_site") + "  \t";
                        if (clsDataBase.GetStringValue("Az_email") != "")
                            strIndirizzo += "email: " + clsDataBase.GetStringValue("Az_email");
                    }
                    if (clsSetting.param_stampa_logo_docu)
                        strPathLogo = clsDataBase.GetStringValue("Az_logo_path");
                    if (strPathLogo == "")
                        strPathLogo = " ";
                }
            }

            clsDataBase.CloseDataReader();

            
            objReportSource.SetParameterValue("MittIva", " ");
            objReportSource.SetParameterValue("MittIndirizzo", strIndirizzo);
            objReportSource.SetParameterValue("MittIntestazione", strAzienda);


            objReportSource.SetParameterValue("ImgLogo", strPathLogo);

            objReportSource.SetParameterValue("DataStampa", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            if (strFiltraggio != "")
                objReportSource.SetParameterValue("ParamRicerca", strFiltraggio);


            //objReportSource.PrintToPrinter(1, False, 0, 0)
        }

        public static string ExportReportToFilePdf(CrystalDecisions.CrystalReports.Engine.ReportClass objReportSource, string strFileName, bool bNoApertura = false)
        {
            string  strPath ="";

            FORM_PARENTE_MDI.Cursor = Cursors.WaitCursor;
            try
            {
                if (clsSetting.param_path_save_pdf == "")
                {
                    MessageBox.Show("Non è impostato alcun percorso per il salvataggio del file.\n\nAndare su Strumenti->Impostazioni per aggiornare la configurazione.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FORM_PARENTE_MDI.Cursor = Cursors.Default;
                    return "";
                }

                strPath = clsSetting.param_path_save_pdf;                
                if (!System.IO.Directory.Exists(strPath))
                    System.IO.Directory.CreateDirectory(strPath);

                //strPath += "\\" + strFileName + "_" + DateTime.Today.ToString("yyyy-MM-dd") + ".pdf";
                strPath += "\\" + strFileName + ".pdf";
                if (System.IO.File.Exists(strPath))
                    if (MessageBox.Show("File già presente.\n\n" + strPath + "\n\nSovrascriverlo ?", "Attenzione",  MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        FORM_PARENTE_MDI.Cursor = Cursors.Default;
                        return strPath;
                    }
                    else
                        System.IO.File.Delete(strPath);

                objReportSource.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, strPath);
                if (bNoApertura)
                {
                  MessageBox.Show("File PDF creato correttamente.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                { 
                if (MessageBox.Show("File PDF creato correttamente.\n\n" + strPath + "\n\nAprire il file ?", "Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    ProcessStartInfo sPdf = new ProcessStartInfo(strPath);
                    Process.Start(strPath);
                }
                }
            }
            catch (SystemException e)
            {
                MessageBox.Show("Errore nella generazione del file PDF.\n\n" + e.Message, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            FORM_PARENTE_MDI.Cursor = Cursors.Default;
            return strPath;
        }

    public static bool ExportFatturaToFileXml(string ProgFattura, string Suffisso, string NumeroFattura, int IdFattura, decimal TotBollo, double TotFattura, string strDesrBreve, string FileAllegato)
    {
      bool bReturn = false;

      string strPath = "";
      string NomeFileAllegato = "";

      //string strFileName = clsDataBase.GetIvaAzienda() + "_" + ProgFattura;
      //string strFileName = clsDataBase.GetDataFattura(IdFattura) + "_" + ProgFattura;
      string strFileName = clsDataBase.GetDataFattura(IdFattura) + "_" + NumeroFattura + Suffisso;

      FORM_PARENTE_MDI.Cursor = Cursors.WaitCursor;

      try
      {
        if (clsSetting.param_path_save_xml == "")
        {
          MessageBox.Show("Non è impostato alcun percorso per il salvataggio del file.\n\nAndare su Strumenti->Impostazioni per aggiornare la configurazione.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          FORM_PARENTE_MDI.Cursor = Cursors.Default;
          return false;
        }

        strPath = clsSetting.param_path_save_xml;
        if (!System.IO.Directory.Exists(strPath))
          System.IO.Directory.CreateDirectory(strPath);

        strPath += "\\" + strFileName + ".xml";
        if (System.IO.File.Exists(strPath))
          if (MessageBox.Show("File già presente.\n\n" + strPath + "\n\nSovrascriverlo ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
          {
            FORM_PARENTE_MDI.Cursor = Cursors.Default;
            return false;
          }
          else
            System.IO.File.Delete(strPath);

        string strErrore = "";

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", System.Text.ASCIIEncoding.UTF8.HeaderName, String.Empty));

        XmlNode XmlNdFE = xmlDoc.CreateNode(XmlNodeType.Element, "p" ,"FatturaElettronica", "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2");
        xmlDoc.AppendChild(XmlNdFE);

        xmlDoc.DocumentElement.SetAttribute("versione", "FPR12");
        xmlDoc.DocumentElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
        xmlDoc.DocumentElement.SetAttribute("schemaLocation", "http://www.w3.org/2001/XMLSchema-instance", "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2 http://www.fatturapa.gov.it/export/fatturazione/sdi/fatturapa/v1.2/Schema_del_file_xml_FatturaPA_versione_1.2.xsd");
        xmlDoc.DocumentElement.SetAttribute("xmlns:ds", "http://www.w3.org/2000/09/xmldsig#");
        
        XmlNode XmlNdHead = xmlDoc.CreateElement("FatturaElettronicaHeader");
        XmlNdFE.AppendChild(XmlNdHead);

        XmlNdHead.AppendChild(GetDatiTrasmissione(xmlDoc, ProgFattura.Substring(0,5), IdFattura, ref strErrore));
        XmlNdHead.AppendChild(GetCedentePrestatore(xmlDoc, ref strErrore));
        XmlNdHead.AppendChild(GetCessionarioCommittente(xmlDoc, IdFattura, ref strErrore));

        XmlNode XmlNdBody = xmlDoc.CreateElement("FatturaElettronicaBody");
        XmlNdBody.AppendChild(GetDatiGenerali(xmlDoc, IdFattura, NumeroFattura, TotFattura, TotBollo, ref strErrore));
        XmlNdBody.AppendChild(GetDatiBeniServizi(xmlDoc, IdFattura, strDesrBreve, ref strErrore));
        XmlNdBody.AppendChild(GetDatiPagamento(xmlDoc, IdFattura, TotFattura, ref strErrore));
        
        if (FileAllegato != "")
        {
          XmlNdBody.AppendChild(GetAllegato(xmlDoc, FileAllegato, ref strErrore));
          if (strErrore == "")
          {
            NomeFileAllegato = GetFileName(FileAllegato);
          }
          
        }

        XmlNdFE.AppendChild(XmlNdBody);

        if (strErrore == "")
        {
          xmlDoc.Save(strPath);

          // Controllo sulle dimensioni del file: un file non può essere più grande di 5MB
          System.IO.FileInfo fi = new System.IO.FileInfo(strPath);
          if ((fi != null) && (fi.Length > 5 * 1024 * 1024))
          {
            strErrore = "La dimensione del file Xml è troppo grande per essere inviata. \n\nRidurre gli elementi di fatturazione od eliminare eventuali allegati.";
            MessageBox.Show("Errore nella generazione del file XML.\n\n" + strErrore, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            bReturn = false;
          }
          else 
          {
            clsDataBase.ExecuteNonQuery("UpDate XML_Documenti Set DataCreazione = " + DateTime.Now.ToString("yyyyMMdd") + ", OraCreazione = " + DateTime.Now.ToString("HHmmss") + ", FileAllegato = '" + NomeFileAllegato.Replace("'", "''") + "' Where IdDocumento = " + IdFattura.ToString());
            if (clsDataBase.LastNumRowModify == 0)
            {
              clsDataBase.ExecuteNonQuery("Insert Into XML_Documenti (IdDocumento, NomeFile, DataCreazione, OraCreazione, FileAllegato) VALUES (" + IdFattura.ToString() + ", '" + strFileName + "', " + DateTime.Now.ToString("yyyyMMdd") + ", " + DateTime.Now.ToString("HHmmss") + ",'" + NomeFileAllegato.Replace("'", "''") + "')");
            }

            clsDataBase.ExecuteNonQuery("UpDate Documenti Set docu_xml_generato = 1 Where Id = " + IdFattura.ToString());

            MessageBox.Show("File XML creato correttamente.\n\n" + strPath, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
            bReturn = true;
          }

        }
        else
        {
          MessageBox.Show("Errore nella generazione del file XML.\n\n" + strErrore, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


      }
      catch (SystemException e)
      {
        MessageBox.Show("Errore nella generazione del file XML.\n\n" + e.Message, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

      FORM_PARENTE_MDI.Cursor = Cursors.Default;

      return bReturn;
    }

    /// <summary>
    /// Genera il nodo DatiTrasmissione
    /// </summary>
    /// <remarks>Blocco sempre obbligatorio contenente informazioni che identificano univocamente il soggetto che trasmette, il documento trasmesso, il formato in cui è stato trasmesso il documento, il soggetto destinatario</remarks>
    private static XmlNode GetDatiTrasmissione(XmlDocument xmlDoc, string NumeroFattura, int IdFattura, ref string strErrore)
    {
      XmlNode xmlNode = xmlDoc.CreateElement("DatiTrasmissione");

      string sSql = "Select Top 1 Cln_tipo_identificativo, \n" +
                    "             Az_paese, \n" +
                    "             Case When(Az_iva = '') Then Az_cod_fis Else Az_iva End As IdFiscale, \n" +

                    "             Cln_cod_identificativo, \n" +
                    "             Cln_pec, \n" +
                    "             Az_tel, \n" +
                    "             Az_email \n" +
                    "             From Azienda, Clienti \n" +
                    "Left Join Documenti On Clienti.Id = Documenti.ID_cliente \n" +
                    "Where Documenti.Id = " + IdFattura.ToString();

      int dbReaderIndex = clsDataBase.GetFreeDbReaderIndex();
      if (clsDataBase.ExecuteQuery(sSql, dbReaderIndex))
      {
        if (clsDataBase.vetDbReader[dbReaderIndex].Read())
        {
          XmlNode xmlIdTra = xmlDoc.CreateElement("IdTrasmittente");
          if (clsDataBase.GetStringValue("Az_paese", dbReaderIndex) == "")
            strErrore += "Richiesta Nazionalità azienda. \n";
          else
            xmlIdTra.AppendChild(CreateNode(xmlDoc, "IdPaese", clsDataBase.GetStringValue("Az_paese", dbReaderIndex)));

          if (clsDataBase.GetStringValue("IdFiscale", dbReaderIndex) == "")
            strErrore += "Richiesto Codice Fiscale/Partita IVA azienda. \n";
          else
            xmlIdTra.AppendChild(CreateNode(xmlDoc, "IdCodice", clsDataBase.GetStringValue("IdFiscale", dbReaderIndex)));

          xmlNode.AppendChild(xmlIdTra);

          xmlNode.AppendChild(CreateNode(xmlDoc, "ProgressivoInvio", NumeroFattura));
          xmlNode.AppendChild(CreateNode(xmlDoc, "FormatoTrasmissione", "FPR12"));

          
          int idTipoIdentificativo = clsDataBase.GetIntValue("Cln_tipo_identificativo", dbReaderIndex);

          if (idTipoIdentificativo == 0)
          {
            if (clsDataBase.GetStringValue("Cln_cod_identificativo", dbReaderIndex) == "")
              strErrore += "Richiesto Codice Identificativo cliente. \n";

            string CodID = clsDataBase.GetStringValue("Cln_cod_identificativo", dbReaderIndex).PadLeft(7, '0');
            xmlNode.AppendChild(CreateNode(xmlDoc, "CodiceDestinatario", CodID));
          }
          else
            xmlNode.AppendChild(CreateNode(xmlDoc, "CodiceDestinatario", "0000000"));

          XmlNode xmlCntTra = xmlDoc.CreateElement("ContattiTrasmittente");
          if (clsDataBase.GetStringValue("Az_tel", dbReaderIndex) == "")
            strErrore += "Richiesto numero di telefono azienda. \n";
          else
            xmlCntTra.AppendChild(CreateNode(xmlDoc, "Telefono", clsDataBase.GetStringValue("Az_tel", dbReaderIndex)));

          if (clsDataBase.GetStringValue("Az_email", dbReaderIndex) == "")
            strErrore += "Richiesta Email azienda. \n";
          else
            xmlCntTra.AppendChild(CreateNode(xmlDoc, "Email", clsDataBase.GetStringValue("Az_email", dbReaderIndex)));

          xmlNode.AppendChild(xmlCntTra);

          if (idTipoIdentificativo == 1)
          {
            if (clsDataBase.GetStringValue("Cln_pec", dbReaderIndex) == "")
              strErrore += "Richiesta PEC cliente. \n";
            else
              xmlNode.AppendChild(CreateNode(xmlDoc, "PECDestinatario", clsDataBase.GetStringValue("Cln_pec", dbReaderIndex)));
          }

        }

      }
      clsDataBase.CloseDataReader(dbReaderIndex);

      return xmlNode;
    }

    /// <summary>
    /// Genera il nodo Xml CedentePrestatore
    /// </summary>
    /// <remarks>Blocco sempre obbligatorio contenente dati relativi al cedente / prestatore (fornitore)</remarks>
    private static XmlNode GetCedentePrestatore(XmlDocument xmlDoc, ref string strErrore)
    {
      XmlNode xmlNode = xmlDoc.CreateElement("CedentePrestatore");

      string sSql = "Select Top 1 Az_tipo_identificativo, \n" +
                    "             Az_paese, \n" +
                    "             Az_iva, \n" +
                    "             Az_rag_soc, \n" +
                    "             Az_nome, \n" +
                    "             Az_cognome, \n" +
                    "             Az_tipo_denominazione, \n" +
                    "             Az_regime, \n" +
                    "             Az_ind_1, \n" +
                    "             Az_ind_1_cap, \n" +
                    "             Az_ind_1_citta, \n" +
                    "             Az_ind_1_prov, \n" +
                    "             Az_ind_1_nciv, \n" +
                    "             Az_nazione, \n" +
                    "             Az_tel, \n" +
                    "             Az_fax, \n" +
                    "             Az_email \n" +

                    "             From Azienda";

      int dbReaderIndex = clsDataBase.GetFreeDbReaderIndex();
      if (clsDataBase.ExecuteQuery(sSql, dbReaderIndex))
      {
        if (clsDataBase.vetDbReader[dbReaderIndex].Read())
        {
          XmlNode xmlDatiAnag = xmlDoc.CreateElement("DatiAnagrafici");

          XmlNode xmlIdTra = xmlDoc.CreateElement("IdFiscaleIVA");
          xmlIdTra.AppendChild(CreateNode(xmlDoc, "IdPaese", clsDataBase.GetStringValue("Az_paese", dbReaderIndex)));
          xmlIdTra.AppendChild(CreateNode(xmlDoc, "IdCodice", clsDataBase.GetStringValue("Az_iva", dbReaderIndex)));
          xmlDatiAnag.AppendChild(xmlIdTra);

          XmlNode xmlAnagrafica = xmlDoc.CreateElement("Anagrafica");

          int idTipoIdentificativo = clsDataBase.GetIntValue("Az_tipo_denominazione", dbReaderIndex);
          if (idTipoIdentificativo == 0)
          {
            if (clsDataBase.GetStringValue("Az_rag_soc", dbReaderIndex) == "")
              strErrore += "Richiesta Ragione Sociale azienda. \n";
            else
              xmlAnagrafica.AppendChild(CreateNode(xmlDoc, "Denominazione", clsDataBase.GetStringValue("Az_rag_soc", dbReaderIndex)));
          }
          else
          {
            if (clsDataBase.GetStringValue("Az_nome", dbReaderIndex) == "")
              strErrore += "Richiesto Nome azienda. \n";
            else
              xmlAnagrafica.AppendChild(CreateNode(xmlDoc, "Nome", clsDataBase.GetStringValue("Az_nome", dbReaderIndex)));

            if (clsDataBase.GetStringValue("Az_cognome", dbReaderIndex) == "")
              strErrore += "Richiesto Cognome azienda. \n";
            else
              xmlAnagrafica.AppendChild(CreateNode(xmlDoc, "Cognome", clsDataBase.GetStringValue("Az_cognome", dbReaderIndex)));
          }

          xmlDatiAnag.AppendChild(xmlAnagrafica);

          if (clsDataBase.GetStringValue("Az_regime", dbReaderIndex) == "")
            strErrore += "Richiesto Regime fiscale azienda. \n";
          else
            xmlDatiAnag.AppendChild(CreateNode(xmlDoc, "RegimeFiscale", clsDataBase.GetStringValue("Az_regime", dbReaderIndex)));

          xmlNode.AppendChild(xmlDatiAnag);

          XmlNode xmlSede = xmlDoc.CreateElement("Sede");

          if (clsDataBase.GetStringValue("Az_ind_1", dbReaderIndex) == "")
            strErrore += "Richiesto Indirizzo 1 azienda. \n";
          else
            xmlSede.AppendChild(CreateNode(xmlDoc, "Indirizzo", clsDataBase.GetStringValue("Az_ind_1", dbReaderIndex)));

          if (clsDataBase.GetStringValue("Az_ind_1_nciv", dbReaderIndex) == "")
            strErrore += "Richiesto Numero civico indirizzo 1 azienda. \n";
          else
            xmlSede.AppendChild(CreateNode(xmlDoc, "NumeroCivico", clsDataBase.GetStringValue("Az_ind_1_nciv", dbReaderIndex)));

          if (clsDataBase.GetStringValue("Az_ind_1_cap", dbReaderIndex) == "")
            strErrore += "Richiesto Cap indirizzo 1 azienda. \n";
          else
            xmlSede.AppendChild(CreateNode(xmlDoc, "CAP", clsDataBase.GetStringValue("Az_ind_1_cap", dbReaderIndex)));

          if (clsDataBase.GetStringValue("Az_ind_1_citta", dbReaderIndex) == "")
            strErrore += "Richiesta Città indirizzo 1 azienda. \n";
          else
            xmlSede.AppendChild(CreateNode(xmlDoc, "Comune", clsDataBase.GetStringValue("Az_ind_1_citta", dbReaderIndex)));

          if (clsDataBase.GetStringValue("Az_ind_1_prov", dbReaderIndex) == "")
            strErrore += "Richiesta Provincia indirizzo 1 azienda. \n";
          else
            xmlSede.AppendChild(CreateNode(xmlDoc, "Provincia", clsDataBase.GetStringValue("Az_ind_1_prov", dbReaderIndex)));

          if (clsDataBase.GetStringValue("Az_nazione", dbReaderIndex) == "")
            strErrore += "Richiesta Nazione indirizzo 1 azienda. \n";
          else
            xmlSede.AppendChild(CreateNode(xmlDoc, "Nazione", clsDataBase.GetStringValue("Az_nazione", dbReaderIndex)));

          xmlNode.AppendChild(xmlSede);


          XmlNode xmlContatti = xmlDoc.CreateElement("Contatti");
          xmlContatti.AppendChild(CreateNode(xmlDoc, "Telefono", clsDataBase.GetStringValue("Az_tel", dbReaderIndex)));
          xmlContatti.AppendChild(CreateNode(xmlDoc, "Fax", clsDataBase.GetStringValue("Az_fax", dbReaderIndex)));
          xmlContatti.AppendChild(CreateNode(xmlDoc, "Email", clsDataBase.GetStringValue("Az_email", dbReaderIndex)));
          xmlNode.AppendChild(xmlContatti);

        }

      }
      clsDataBase.CloseDataReader(dbReaderIndex);

      return xmlNode;
    }

    /// <summary>
    /// Genera il nodo CessionarioCommittente
    /// </summary>
    /// <remarks>Blocco sempre obbligatorio contenente dati relativi al cessionario / committente (cliente)</remarks>
    private static XmlNode GetCessionarioCommittente(XmlDocument xmlDoc, int IdFattura, ref string strErrore)
    {
      XmlNode xmlNode = xmlDoc.CreateElement("CessionarioCommittente");

      string sSql = "Select Top 1 Cln_paese, \n" +
                    "             Cln_iva, \n" +
                    "             Cln_cod_fis, \n" +
                    "             Cln_rag_soc, \n" +
                    "             Cln_nome, \n" +
                    "             Cln_cognome, \n" +
                    "             Cln_tipo_denominazione, \n" +
                    "             Cln_sede_legale, \n" +
                    "             Cln_sede_legale_cap, \n" +
                    "             Cln_sede_legale_citta, \n" +
                    "             Cln_sede_legale_prov, \n" +
                    "             Cln_sede_legale_nciv, \n" +
                    "             Cln_nazione, \n" +
                    "             Cln_tel, \n" +
                    "             Cln_fax, \n" +
                    "             Cln_email, \n" +
                    "             Cln_tipo_cliente \n" +
                    

                    "From Clienti \n" +
                    "Left Join Documenti On Clienti.Id = Documenti.ID_cliente \n" +
                    "Where Documenti.Id = " + IdFattura.ToString();

      int dbReaderIndex = clsDataBase.GetFreeDbReaderIndex();
      if (clsDataBase.ExecuteQuery(sSql, dbReaderIndex))
      {
        if (clsDataBase.vetDbReader[dbReaderIndex].Read())
        {
          int idTipoIdentificativo = clsDataBase.GetIntValue("Cln_tipo_denominazione", dbReaderIndex);
          
          if (clsDataBase.GetBoolValue("Cln_tipo_cliente", dbReaderIndex))
            strErrore += "Al momento non è possibile generare Xml per la pubblica amministrazione. \n";

          XmlNode xmlDatiAnag = xmlDoc.CreateElement("DatiAnagrafici");

          if (idTipoIdentificativo == 0)
          {
            XmlNode xmlIdTra = xmlDoc.CreateElement("IdFiscaleIVA");
            if (clsDataBase.GetStringValue("Cln_paese", dbReaderIndex) == "")
              strErrore += "Richiesta Nazione Sede cliente. \n";
            else
              xmlIdTra.AppendChild(CreateNode(xmlDoc, "IdPaese", clsDataBase.GetStringValue("Cln_paese", dbReaderIndex)));

            if (clsDataBase.GetStringValue("Cln_iva", dbReaderIndex) == "")
              strErrore += "Richiesta Paritita Iva cliente. \n";
            else
              xmlIdTra.AppendChild(CreateNode(xmlDoc, "IdCodice", clsDataBase.GetStringValue("Cln_iva", dbReaderIndex)));

            xmlDatiAnag.AppendChild(xmlIdTra);
          }
          else
          {
            if (clsDataBase.GetStringValue("Cln_cod_fis", dbReaderIndex) == "")
              strErrore += "Richiesto Codice Fiscale cliente. \n";
            else
              xmlDatiAnag.AppendChild(CreateNode(xmlDoc, "CodiceFiscale", clsDataBase.GetStringValue("Cln_cod_fis", dbReaderIndex)));
          }

          XmlNode xmlAnagrafica = xmlDoc.CreateElement("Anagrafica");

          if (idTipoIdentificativo == 0)
          {
            if (clsDataBase.GetStringValue("Cln_rag_soc", dbReaderIndex) == "")
              strErrore += "Richiesta Ragione Sociale cliente. \n";
            else
              xmlAnagrafica.AppendChild(CreateNode(xmlDoc, "Denominazione", clsDataBase.GetStringValue("Cln_rag_soc", dbReaderIndex)));
          }
          else
          {
            if (clsDataBase.GetStringValue("Cln_nome", dbReaderIndex) == "")
              strErrore += "Richiesto Nome cliente. \n";
            else
              xmlAnagrafica.AppendChild(CreateNode(xmlDoc, "Nome", clsDataBase.GetStringValue("Cln_nome", dbReaderIndex)));

            if (clsDataBase.GetStringValue("Cln_cognome", dbReaderIndex) == "")
              strErrore += "Richiesto Cognome cliente. \n";
            else
              xmlAnagrafica.AppendChild(CreateNode(xmlDoc, "Cognome", clsDataBase.GetStringValue("Cln_cognome", dbReaderIndex)));
          }

          xmlDatiAnag.AppendChild(xmlAnagrafica);

          xmlNode.AppendChild(xmlDatiAnag);

          XmlNode xmlSede = xmlDoc.CreateElement("Sede");
          if (clsDataBase.GetStringValue("Cln_sede_legale", dbReaderIndex) == "")
            strErrore += "Richiesto Indirizzo sede legale cliente. \n";
          else
            xmlSede.AppendChild(CreateNode(xmlDoc, "Indirizzo", clsDataBase.GetStringValue("Cln_sede_legale", dbReaderIndex)));

          if (clsDataBase.GetStringValue("Cln_sede_legale_nciv", dbReaderIndex) == "")
            strErrore += "Richiesto Numero Civico sede legale cliente. \n";
          else
            xmlSede.AppendChild(CreateNode(xmlDoc, "NumeroCivico", clsDataBase.GetStringValue("Cln_sede_legale_nciv", dbReaderIndex)));

          if (clsDataBase.GetStringValue("Cln_sede_legale_cap", dbReaderIndex) == "")
            strErrore += "Richiesto Cap sede legale cliente. \n";
          else
            xmlSede.AppendChild(CreateNode(xmlDoc, "CAP", clsDataBase.GetStringValue("Cln_sede_legale_cap", dbReaderIndex)));

          if (clsDataBase.GetStringValue("Cln_sede_legale_citta", dbReaderIndex) == "")
            strErrore += "Richiesta Città sede legale cliente. \n";
          else
            xmlSede.AppendChild(CreateNode(xmlDoc, "Comune", clsDataBase.GetStringValue("Cln_sede_legale_citta", dbReaderIndex)));

          if (clsDataBase.GetStringValue("Cln_sede_legale_prov", dbReaderIndex) == "")
            strErrore += "Richiesto Provincia sede legale cliente. \n";
          else
            xmlSede.AppendChild(CreateNode(xmlDoc, "Provincia", clsDataBase.GetStringValue("Cln_sede_legale_prov", dbReaderIndex)));

          if (clsDataBase.GetStringValue("Cln_nazione", dbReaderIndex) == "")
            strErrore += "Richiesta Nazione sede legale cliente. \n";
          else
            xmlSede.AppendChild(CreateNode(xmlDoc, "Nazione", clsDataBase.GetStringValue("Cln_nazione", dbReaderIndex)));

          xmlNode.AppendChild(xmlSede);

        }

      }
      clsDataBase.CloseDataReader(dbReaderIndex);

      return xmlNode;
    }

    /// <summary>
    /// Genera il nodo DatiGenerali
    /// </summary>
    /// <remarks>Blocco sempre obbligatorio contenente i dati generali della fattura e quelli degli eventuali documenti correlati</remarks>
    private static XmlNode GetDatiGenerali(XmlDocument xmlDoc, int IdFattura, string NumeroFattura, double TotaleFattura, decimal Bollo, ref string strErrore)
    {
      XmlNode xmlNode = xmlDoc.CreateElement("DatiGenerali");

      string sSql = "Select docu_tipo, \n" +
                    "       docu_data, \n" +
                    "       docu_numero, \n" +
                    "       docu_note, \n" +
                    "       Cln_divisa \n" +

                    "From Documenti \n" +
                    "Left Join Clienti On Clienti.Id = Documenti.ID_cliente \n" +
                    "Where Documenti.Id = " + IdFattura.ToString();

      int dbReaderIndex = clsDataBase.GetFreeDbReaderIndex();
      if (clsDataBase.ExecuteQuery(sSql, dbReaderIndex))
      {
        if (clsDataBase.vetDbReader[dbReaderIndex].Read())
        {
          int idTipoDocumento = clsDataBase.GetIntValue("docu_tipo", dbReaderIndex);
          string CodTipoDocumento = "";

          switch (idTipoDocumento)
          {
            case 0:
              CodTipoDocumento = "TD01";
              break;
            case 1:
              CodTipoDocumento = "TD04";
              break;
          }

          if (CodTipoDocumento == "")
          {
            strErrore += "Tipo documento non gestito \n";
            return xmlNode;
          }

          XmlNode xmlDatiGen = xmlDoc.CreateElement("DatiGeneraliDocumento");
          xmlDatiGen.AppendChild(CreateNode(xmlDoc, "TipoDocumento", CodTipoDocumento));

          if (clsDataBase.GetStringValue("Cln_divisa", dbReaderIndex) == "")
            strErrore += "Richiesta Valuta cliente. \n";
          else
            xmlDatiGen.AppendChild(CreateNode(xmlDoc, "Divisa", clsDataBase.GetStringValue("Cln_divisa", dbReaderIndex)));

          xmlDatiGen.AppendChild(CreateNode(xmlDoc, "Data", clsDataBase.GetDateValue("docu_data", dbReaderIndex).ToString("yyyy-MM-dd")));

          if (NumeroFattura == "")
            xmlDatiGen.AppendChild(CreateNode(xmlDoc, "Numero", clsDataBase.GetIntValue("docu_numero", dbReaderIndex).ToString()));
          else
            xmlDatiGen.AppendChild(CreateNode(xmlDoc, "Numero", NumeroFattura));
          
          if (Bollo > 0)
          {
            XmlNode xmlDatiBollo = xmlDoc.CreateElement("DatiBollo");
            xmlDatiBollo.AppendChild(CreateNode(xmlDoc, "BolloVirtuale", "SI"));
            xmlDatiBollo.AppendChild(CreateNode(xmlDoc, "ImportoBollo", Bollo.ToString().Replace(",", ".")));
            xmlDatiGen.AppendChild(xmlDatiBollo);
          }

          if (TotaleFattura > 0)
          {
            xmlDatiGen.AppendChild(CreateNode(xmlDoc, "ImportoTotaleDocumento", FromNumTOXmlNumFormat2(TotaleFattura)));
          }

          string causale = clsDataBase.GetStringValue("docu_note", dbReaderIndex);
          if (causale.Length > 0)
          {
            if (causale.Length > 200)
            {
              xmlDatiGen.AppendChild(CreateNode(xmlDoc, "Causale", causale.Substring(0,200)));
              xmlDatiGen.AppendChild(CreateNode(xmlDoc, "Causale", causale.Substring(200)));
            }
            else
              xmlDatiGen.AppendChild(CreateNode(xmlDoc, "Causale", causale));

          }

          xmlNode.AppendChild(xmlDatiGen);

        }

      }
      clsDataBase.CloseDataReader(dbReaderIndex);

      return xmlNode;
    }

    /// <summary>
    /// Genera il nodo DatiBeniServizi
    /// </summary>
    /// <remarks>Blocco sempre obbligatorio. Contiene natura, qualità, quantità e gli elementi necessari a determinare il valore dei beni e/o dei servizi formanti oggetto dell'operazione</remarks>
    private static XmlNode GetDatiBeniServizi(XmlDocument xmlDoc, int IdFattura, string strDesrBreve, ref string strErrore)
    {
      XmlNode xmlNode = xmlDoc.CreateElement("DatiBeniServizi");

      string sSql = "";

      if (strDesrBreve == "")
      {
        sSql = "Select dtt_docu_descrizione, \n" +
               "       dtt_docu_tratta, \n" +
               "       dtt_docu_ddt_n, \n" +
               "       dtt_docu_ddt_data, \n" +
               "       Cast(dtt_docu_qta As Decimal (20,3)) As dtt_docu_qta,  \n" +
               "       Cast(dtt_docu_prezzo_u As Decimal (20,3)) As dtt_docu_prezzo_u, \n" +
               "       Cast((dtt_docu_qta * dtt_docu_prezzo_u) As Decimal (20,3)) As PrezzoTotale, \n" +
               "       dtt_docu_percent_iva, \n" +
               "       Iva.iva_cod_esenzione As Codice \n" +

               "From Documenti \n" +
               "Left Join Dtt_documenti On Dtt_documenti.ID_documento = Documenti.ID \n" +
               "Left Join Iva On Iva.Id = Dtt_documenti.Dtt_id_iva \n" +

               "Where Documenti.Id = " + IdFattura.ToString();
      }
      else
      {
        sSql = "Select '" + strDesrBreve.Replace("'", "''") + "' As dtt_docu_descrizione, \n" +
               "       '' As dtt_docu_tratta, \n" +
               "       '' As dtt_docu_ddt_n, \n" +
               "       NULL As dtt_docu_ddt_data, \n" +
               "       Cast(1 As Decimal (20,3)) As dtt_docu_qta,  \n" +
               "       Cast(Sum(dtt_docu_qta * dtt_docu_prezzo_u) As Decimal (20,3)) As dtt_docu_prezzo_u, \n" +
               "       Cast(Sum(dtt_docu_qta * dtt_docu_prezzo_u) As Decimal (20,3)) As PrezzoTotale, \n" +
               "       dtt_docu_percent_iva, \n" +
               "       Iva.iva_cod_esenzione As Codice \n" +

               "From Documenti \n" +
               "Left Join Dtt_documenti On Dtt_documenti.ID_documento = Documenti.ID \n" +
               "Left Join Iva On Iva.Id = Dtt_documenti.Dtt_id_iva \n" +

               "Where Documenti.Id = " + IdFattura.ToString() + "\n" +
               "Group By dtt_docu_percent_iva, Iva.iva_cod_esenzione \n";
      }

      double Arrotondamento = 0;

      int dbReaderIndex = clsDataBase.GetFreeDbReaderIndex();
      if (clsDataBase.ExecuteQuery(sSql, dbReaderIndex))
      {

        int iRowCount = 0;
        while (clsDataBase.vetDbReader[dbReaderIndex].Read())
        {

          iRowCount++;

          XmlNode xmlDatiGen = xmlDoc.CreateElement("DettaglioLinee");
          xmlDatiGen.AppendChild(CreateNode(xmlDoc, "NumeroLinea", iRowCount.ToString()));

          string DescrBene = "";
          DescrBene = clsDataBase.GetStringValue("dtt_docu_descrizione", dbReaderIndex);

          if (clsDataBase.GetStringValue("dtt_docu_tratta", dbReaderIndex) != "")
            DescrBene += " da " + clsDataBase.GetStringValue("dtt_docu_tratta", dbReaderIndex);

          if (clsDataBase.GetStringValue("dtt_docu_ddt_n", dbReaderIndex) != "")
            DescrBene += " ddt n. " + clsDataBase.GetStringValue("dtt_docu_ddt_n", dbReaderIndex);

          if (clsDataBase.GetDateValue("dtt_docu_ddt_data", dbReaderIndex) != DateTime.MinValue)
            DescrBene += " del " + clsDataBase.GetDateValue("dtt_docu_ddt_data", dbReaderIndex).ToString("dd-MM-yyyy");

          xmlDatiGen.AppendChild(CreateNode(xmlDoc, "Descrizione", DescrBene));
          xmlDatiGen.AppendChild(CreateNode(xmlDoc, "Quantita", FromNumTOXmlNumFormat(clsDataBase.GetDecimalValue("dtt_docu_qta", dbReaderIndex))));
          xmlDatiGen.AppendChild(CreateNode(xmlDoc, "PrezzoUnitario", FromNumTOXmlNumFormat(clsDataBase.GetDecimalValue("dtt_docu_prezzo_u", dbReaderIndex))));

          Decimal PrezzoTotale = clsDataBase.GetDecimalValue("dtt_docu_qta", dbReaderIndex) * clsDataBase.GetDecimalValue("dtt_docu_prezzo_u", dbReaderIndex);
          if (clsDataBase.GetDecimalValue("PrezzoTotale", dbReaderIndex) != PrezzoTotale)
            Arrotondamento += (double) (PrezzoTotale - clsDataBase.GetDecimalValue("PrezzoTotale", dbReaderIndex));

          xmlDatiGen.AppendChild(CreateNode(xmlDoc, "PrezzoTotale", FromNumTOXmlNumFormat(PrezzoTotale)));
          xmlDatiGen.AppendChild(CreateNode(xmlDoc, "AliquotaIVA", FromNumTOXmlNumFormat2(clsDataBase.GetDecimalValue("dtt_docu_percent_iva", dbReaderIndex))));

          if (clsDataBase.GetDecimalValue("dtt_docu_percent_iva", dbReaderIndex) == 0)
          {
            if (clsDataBase.GetStringValue("Codice", dbReaderIndex) == "")
              strErrore += "Richiesta codice esenzione IVA valido. \n";
            else
              xmlDatiGen.AppendChild(CreateNode(xmlDoc, "Natura", clsDataBase.GetStringValue("Codice", dbReaderIndex)));
          }

          xmlNode.AppendChild(xmlDatiGen);

        }

      }
      clsDataBase.CloseDataReader(dbReaderIndex);

      GetDatiRiepilogo(xmlDoc, xmlNode, IdFattura, Arrotondamento, ref strErrore);

      return xmlNode;
    }

    private static void GetDatiRiepilogo(XmlDocument xmlDoc, XmlNode xmlNode, int IdFattura, double Arrotondamento, ref string strErrore)
    {

      string sSql = "Select dtt_docu_percent_iva As AliquotaIva, \n" +
                    "       Iva.iva_cod_esenzione As Codice, \n" +
                    "       Sum(dtt_docu_qta * dtt_docu_prezzo_u) As Imponibile, \n" +
                    "       (Sum(dtt_docu_qta * dtt_docu_prezzo_u) * dtt_docu_percent_iva ) / 100 As Importo \n" +

                    "From Documenti \n" +
                    "Left Join Dtt_documenti On Dtt_documenti.Id_Documento = Documenti.Id \n" +
                    "Left Join Iva On Iva.Id = Dtt_documenti.Dtt_id_iva \n" +

                    "Where Documenti.Id = " + IdFattura.ToString() + "\n" +

                    "Group By dtt_docu_percent_iva, Iva.iva_cod_esenzione";

      int dbReaderIndex = clsDataBase.GetFreeDbReaderIndex();
      if (clsDataBase.ExecuteQuery(sSql, dbReaderIndex))
      {

        while (clsDataBase.vetDbReader[dbReaderIndex].Read())
        {

          XmlNode xmlDatiGen = xmlDoc.CreateElement("DatiRiepilogo");

          xmlDatiGen.AppendChild(CreateNode(xmlDoc, "AliquotaIVA", FromNumTOXmlNumFormat2(clsDataBase.GetDecimalValue("AliquotaIva", dbReaderIndex))));

          if (clsDataBase.GetDecimalValue("AliquotaIva", dbReaderIndex) == 0)
          {
            if (clsDataBase.GetStringValue("Codice", dbReaderIndex) == "")
              strErrore += "Richiesta codice esenzione IVA valido. \n";
            else
              xmlDatiGen.AppendChild(CreateNode(xmlDoc, "Natura", clsDataBase.GetStringValue("Codice", dbReaderIndex)));
          }

          if (Arrotondamento != 0)
            xmlDatiGen.AppendChild(CreateNode(xmlDoc, "Arrotondamento", FromNumTOXmlNumFormat2(Arrotondamento)));

          xmlDatiGen.AppendChild(CreateNode(xmlDoc, "ImponibileImporto", FromNumTOXmlNumFormat2(clsDataBase.GetDecimalValue("Imponibile", dbReaderIndex))));
          xmlDatiGen.AppendChild(CreateNode(xmlDoc, "Imposta", FromNumTOXmlNumFormat2(clsDataBase.GetDecimalValue("Importo", dbReaderIndex))));

          xmlNode.AppendChild(xmlDatiGen);

        }

      }
      clsDataBase.CloseDataReader(dbReaderIndex);
    }

    private static XmlNode GetDatiPagamento(XmlDocument xmlDoc, int IdFattura, double TotalePagamento, ref string strErrore)
    {
          XmlNode xmlNode = xmlDoc.CreateElement("DatiPagamento");

          string sSql = "Select Tipi_Pagamento.Tipi_pagam_condizioni, \n" +
                    "       Tipi_Pagamento.Tipi_pagam_modalita, \n" +
                    "       IsNull(Banca_Azienda.banca_descrizione, '') As Banca, \n" +
                    "       IsNull(Banca_Azienda.banca_iban, '') As Iban, \n" +
                    "       IsNull(Banca_Azienda.banca_abi, '') As Abi, \n" +
                    "       IsNull(Banca_Azienda.banca_cab, '') As Cab, \n" +
                    "       IsNull(Banca_Azienda.banca_swift, '') As Bic, \n" +
                    "       Scadenze.Scadenza_data, \n" +
                    "       Scadenze.Scadenza_importo \n" +

                    "From Documenti \n" +
                    "Left Join Tipi_Pagamento On Tipi_Pagamento.ID = Documenti.ID_tipi_pagamento \n" +
                    "Left Join Banca_Azienda On Banca_Azienda.ID = Documenti.id_banca_az \n" +
                    "Left Join Scadenze On Scadenze.ID_documento = Documenti.Id \n" +
                    "Where Documenti.Id = " + IdFattura.ToString();

      int dbReaderIndex = clsDataBase.GetFreeDbReaderIndex();
      if (clsDataBase.ExecuteQuery(sSql, dbReaderIndex))
      {

        bool bFirtRead = true;

          while (clsDataBase.vetDbReader[dbReaderIndex].Read())
          {

          if (bFirtRead)
          {
            xmlNode.AppendChild(CreateNode(xmlDoc, "CondizioniPagamento", clsDataBase.GetStringValue("Tipi_pagam_condizioni", dbReaderIndex)));
            bFirtRead = false;
          }

          XmlNode xmlDatiGen = xmlDoc.CreateElement("DettaglioPagamento");

          xmlDatiGen.AppendChild(CreateNode(xmlDoc, "ModalitaPagamento", clsDataBase.GetStringValue("Tipi_pagam_modalita", dbReaderIndex)));

          if (clsDataBase.GetDateValue("Scadenza_data", dbReaderIndex) != DateTime.MinValue)
            xmlDatiGen.AppendChild(CreateNode(xmlDoc, "DataScadenzaPagamento", clsDataBase.GetDateValue("Scadenza_data", dbReaderIndex).ToString("yyyy-MM-dd")));

          if (clsDataBase.GetDecimalValue("Scadenza_importo", dbReaderIndex) != 0)
            xmlDatiGen.AppendChild(CreateNode(xmlDoc, "ImportoPagamento", FromNumTOXmlNumFormat2(clsDataBase.GetDecimalValue("Scadenza_importo", dbReaderIndex))));
          else
            xmlDatiGen.AppendChild(CreateNode(xmlDoc, "ImportoPagamento", FromNumTOXmlNumFormat2(TotalePagamento)));

          if (clsDataBase.GetStringValue("Banca", dbReaderIndex) != "")
              xmlDatiGen.AppendChild(CreateNode(xmlDoc, "IstitutoFinanziario", clsDataBase.GetStringValue("Banca", dbReaderIndex)));

            if (clsDataBase.GetStringValue("Iban", dbReaderIndex) != "")
              xmlDatiGen.AppendChild(CreateNode(xmlDoc, "IBAN", clsDataBase.GetStringValue("Iban", dbReaderIndex)));

            if (clsDataBase.GetStringValue("Abi", dbReaderIndex) != "")
              xmlDatiGen.AppendChild(CreateNode(xmlDoc, "ABI", clsDataBase.GetStringValue("Abi", dbReaderIndex).PadLeft(5,'0')));

            if (clsDataBase.GetStringValue("Cab", dbReaderIndex) != "")
              xmlDatiGen.AppendChild(CreateNode(xmlDoc, "CAB", clsDataBase.GetStringValue("Cab", dbReaderIndex).PadLeft(5, '0')));

            if (clsDataBase.GetStringValue("Bic", dbReaderIndex) != "")
            {
              string Bic = clsDataBase.GetStringValue("Bic", dbReaderIndex);
              if (Bic.Length > 7 && Bic.Length < 12)
                xmlDatiGen.AppendChild(CreateNode(xmlDoc, "BIC", Bic));
            }

            xmlNode.AppendChild(xmlDatiGen);

          }

      }
      clsDataBase.CloseDataReader(dbReaderIndex);

      return xmlNode;
    }

    private static XmlNode GetAllegato(XmlDocument xmlDoc, string FileAllegato, ref string strErrore)
    {

      if (System.IO.File.Exists(FileAllegato) == false)
      {
        strErrore += "File allegato non trovato. \n";
        return null;
      }
      else
      {

        XmlNode xmlNode = xmlDoc.CreateElement("Allegati");
        xmlNode.AppendChild(CreateNode(xmlDoc, "NomeAttachment", GetFileName(FileAllegato)));

        Byte[] bytes = System.IO.File.ReadAllBytes(FileAllegato);
        string file = Convert.ToBase64String(bytes);

        xmlNode.AppendChild(CreateNode(xmlDoc, "Attachment", file));

        return xmlNode;

      }

    }

    private static XmlNode CreateNode(XmlDocument xmlDocument, string nodeName, string nodeValue)
    {
      XmlNode xmlNode = xmlDocument.CreateElement(nodeName);
      xmlNode.InnerText = nodeValue;

      return xmlNode;

    }

    private static string FromNumTOXmlNumFormat(int intNum)
    {
      return FromNumTOXmlNumFormat(Convert.ToDouble(intNum));
    }

    private static string FromNumTOXmlNumFormat(decimal decNum)
    {
      return FromNumTOXmlNumFormat(Convert.ToDouble(decNum));
    }

    private static string FromNumTOXmlNumFormat( double dblNum)
    {
      return dblNum.ToString("0.000").Replace(",", ".");
    }

    private static string FromNumTOXmlNumFormat2(decimal decNum)
    {
        return FromNumTOXmlNumFormat2(Convert.ToDouble(decNum));
    }

    private static string FromNumTOXmlNumFormat2(double dblNum)
    {
        return dblNum.ToString("0.00").Replace(",", ".");
    }

    public static string GetFileName(string strPathFile)
    {
      int iStart = strPathFile.LastIndexOf("\\") + 1;
      int iEnd = strPathFile.LastIndexOf(".") ;

      //return strPathFile.Substring(iStart, iEnd - iStart);
      return strPathFile.Substring(iStart);
    }
  }
}
