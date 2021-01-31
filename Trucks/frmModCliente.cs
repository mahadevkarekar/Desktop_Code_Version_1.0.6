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
  public partial class frmModCliente : Form
  {
    public Form frmParent;
    public int IdSel;

    public frmModCliente()
    {
      InitializeComponent();
    }

    private void frmModCliente_Load(object sender, EventArgs e)
    {
      if (!this.Modal && this.MdiParent != null)
        this.WindowState = FormWindowState.Maximized;

      if (IdSel > 0)
        LoadCliente(IdSel);
      else
      {
        ClearFields();
        PopolaCombo();
        bttElimina.Enabled = false;
      }
    }

    private void bttEsci_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void frmModCliente_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (frmParent != null)
      {
        frmParent.Show();
      }
    }

    private bool VerificaCampi()
    {
      bool bRetValue = true;
      string strErrore = "";

      if (cmbDenominazione.SelectedIndex == 0)
      {
        if (txtRagSoc.Text == "") strErrore += "Richiesta Ragione Sociale\n";

      }
      else
      {
        if (txtNome.Text == "" || txtCognome.Text == "") strErrore += "Richiesto Nome/Cognome\n";
      }

      if (txtPIVA.Text == "") strErrore += "Richiesta Partita IVA\n";
      if (cmbPaese.SelectedIndex < 1) strErrore += "Richiesta Nazionalità Partita IVA\n";

      if (txtCodFiscale.Text == "") strErrore += "Richiesto Codice Fiscale\n";

      if (txtIndirizzo1.Text == "" || txtCap1.Text == "" || txtCitta1.Text == "" || txtPrv1.Text == "" || txtNCivico1.Text == "") strErrore += "Richiesto indirizzo completo Sede Legale\n";
      if (cmbNazione.SelectedIndex < 1) strErrore += "Richiesta Nazionalità indirizzo Sede\n";

      if ((cmbIdentificativo.SelectedIndex == 0) && (txtIdentificativo.Text == ""))
      {
        strErrore += "Richiesto Codice identificativo\n";
      }

      if ((cmbIdentificativo.SelectedIndex == 1) && (txtPEC.Text == ""))
      {
        strErrore += "Richiesto indirizzo mail PEC\n";
      }

      if (txtPEC.Text != "")
      {
        if (txtPEC.Text.IndexOf("@") < 1)
        {
          strErrore += "Richiesto indirizzo mail PEC valido (xxx@yyy.zz)\n";
        }
        else
        {
          if (txtPEC.Text.IndexOf("@") > txtPEC.Text.LastIndexOf("."))
            strErrore += "Richiesto indirizzo mail PEC valido (xxx@yyy.zz)\n";
        }
      }

      if (cmbDivisa.SelectedIndex < 1) strErrore += "Richiesta valuta\n";

      if (strErrore == "")
      {
        string strSql = "Select Count(*) from Clienti where id<> " + IdSel.ToString() + " and Cln_cancellato = 0 and  (Cln_iva='" + txtPIVA.Text.Replace("'", "''") + "' or Cln_cod_fis='" + txtCodFiscale.Text.Replace("'", "''") + "') ";
        if ((int)clsDataBase.ExecuteScalar(strSql) > 0)
          strErrore += "Codice Fiscale e/o Partita Iva già presente\n";
      }

      if (strErrore != "")
      {
        MessageBox.Show("Verificare i parametri inseriti:\n\n" + strErrore, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        bRetValue = false;
      }

      return bRetValue;
    }


    private void bttSave_Click(object sender, EventArgs e)
    {
      string strSql = "";

      if (MessageBox.Show("Salvare le nuove impostazioni.", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
        return;

      if (!VerificaCampi()) return;

      if (IdSel > 0)
      {
        // Devo Effettuare Update
        strSql = "Update Clienti set " +
                      " Cln_rag_soc = '" + txtRagSoc.Text.Replace("'", "''") + "'" +
                      ", Cln_nome = '" + txtNome.Text.Replace("'", "''") + "'" +
                      ", Cln_cognome = '" + txtCognome.Text.Replace("'", "''") + "'" +
                      ", Cln_sede_legale = '" + txtIndirizzo1.Text.Replace("'", "''") + "'" +
                      ", Cln_sede_legale_cap = '" + txtCap1.Text + "'" +
                      ", Cln_sede_legale_citta = '" + txtCitta1.Text.Replace("'", "''") + "'" +
                      ", Cln_sede_legale_prov = '" + txtPrv1.Text + "'" +
                      ", Cln_sede_legale_nciv = '" + txtNCivico1.Text + "'" +
                      ", Cln_ind_spedizione = '" + txtIndirizzo2.Text.Replace("'", "''") + "'" +
                      ", Cln_ind_spedizione_cap = '" + txtCap2.Text + "'" +
                      ", Cln_ind_spedizione_citta = '" + txtCitta2.Text.Replace("'", "''") + "'" +
                      ", Cln_ind_spedizione_prov = '" + txtPrv2.Text + "'" +
                      ", Cln_ind_spedizione_nciv = '" + txtNCivico2.Text + "'" +
                      ", Cln_iva = '" + txtPIVA.Text + "'" +
                      ", Cln_cod_fis = '" + txtCodFiscale.Text + "'" +
                      ", Cln_tel = '" + txtTel.Text + "'" +
                      ", Cln_fax = '" + txtFax.Text + "'" +
                      ", Cln_email = '" + txtEmail.Text + "'" +
                      ", Cln_web_site = '" + txtWeb.Text + "'" +
                      ", Cln_iban = '" + txtIBAN.Text + "'" +
                      ", Cln_banca_descr = '" + txtBanca.Text.Replace("'", "''") + "'" +
                      ", cln_banca_cab = '" + txtCAB.Text + "'" +
                      ", Cln_banca_abi = '" + txtABI.Text + "'" +
                      ", Cln_banca_cc = '" + txtCC.Text + "'" +
                      ", Cln_banca_cin = '" + txtCIN.Text + "'" +
                      ", Cln_banca_swift = '" + txtSwift.Text.Replace("'", "''") + "'" +
                      ", Cln_ID_Tipi_pagamento = " + ((_dataItemCombo)cmbTipPag.SelectedItem).Id.ToString() +
                      ", Cln_ID_Banca_azienda = " + ((_dataItemCombo)cmbBancaAz.SelectedItem).Id.ToString() +

                      ", Cln_paese ='" + ((cmbPaese.SelectedIndex >= 0) ? ((ComboboxItem)cmbPaese.SelectedItem).Value : "") + "'" +
                      ", Cln_nazione ='" + ((cmbNazione.SelectedIndex >= 0) ? ((ComboboxItem)cmbNazione.SelectedItem).Value : "") + "'" +
                      ", Cln_tipo_denominazione =" + cmbDenominazione.SelectedIndex.ToString() +
                      ", Cln_tipo_identificativo =" + cmbIdentificativo.SelectedIndex.ToString() +
                      ", Cln_pec ='" + txtPEC.Text + "'" +
                      ", Cln_cod_identificativo ='" + txtIdentificativo.Text + "'" +
                      ", Cln_divisa ='" + ((cmbDivisa.SelectedIndex >= 0) ? ((ComboboxItem)cmbDivisa.SelectedItem).Value : "") + "'" +
                      ", Cln_tipo_Cliente =" + (optPrivato.Checked ? "0" : "1") +

                      ", Cln_Note_Fatt = '" + txtNoteFatt.Text.Replace("'", "''") + "'" +

                      ", Cln_id_fattura_pdf = " + ((_dataItemCombo)cmbModPdf.SelectedItem).Id.ToString() +
                      ", Cln_id_fattura_xml = " + ((_dataItemCombo)cmbModXml.SelectedItem).Id.ToString() +
                      ", Cln_descr_fattura_pdf ='" + txtDescrPdf.Text + "'" +
                      ", Cln_descr_fattura_xml ='" + txtDescrXml.Text + "'" +

                      " where Id= " + IdSel.ToString();
      }
      else
      {
        // Devo effettuare inserimento
        strSql = "Insert into Clienti (Cln_rag_soc, Cln_sede_legale, Cln_sede_legale_cap, Cln_sede_legale_citta, Cln_sede_legale_prov, Cln_ind_spedizione, Cln_ind_spedizione_cap, Cln_ind_spedizione_citta, Cln_ind_spedizione_prov, Cln_iva, Cln_cod_fis, Cln_tel, Cln_fax, Cln_email, Cln_web_site, Cln_iban, Cln_banca_descr, cln_banca_cab, Cln_banca_abi, Cln_banca_cc, Cln_banca_cin, Cln_banca_swift, Cln_ID_Tipi_pagamento, Cln_ID_Banca_azienda, Cln_Note_Fatt" +
                      ", Cln_nome, Cln_cognome, Cln_sede_legale_nciv, Cln_ind_spedizione_nciv, Cln_paese, Cln_nazione, Cln_tipo_denominazione, Cln_tipo_identificativo, Cln_pec, Cln_cod_identificativo, Cln_divisa, Cln_tipo_Cliente, Cln_id_fattura_pdf, Cln_id_fattura_xml, Cln_descr_fattura_pdf, Cln_descr_fattura_xml) values (" +
                      "'" + txtRagSoc.Text.Replace("'", "''") + "'" +
                      ", '" + txtIndirizzo1.Text.Replace("'", "''") + "'" +
                      ", '" + txtCap1.Text + "'" +
                      ", '" + txtCitta1.Text.Replace("'", "''") + "'" +
                      ", '" + txtPrv1.Text + "'" +
                      ", '" + txtIndirizzo2.Text.Replace("'", "''") + "'" +
                      ", '" + txtCap2.Text + "'" +
                      ", '" + txtCitta2.Text.Replace("'", "''") + "'" +
                      ", '" + txtPrv2.Text + "'" +
                      ", '" + txtPIVA.Text + "'" +
                      ", '" + txtCodFiscale.Text + "'" +
                      ", '" + txtTel.Text + "'" +
                      ", '" + txtFax.Text + "'" +
                      ", '" + txtEmail.Text + "'" +
                      ", '" + txtWeb.Text + "'" +
                      ", '" + txtIBAN.Text + "'" +
                      ", '" + txtBanca.Text.Replace("'", "''") + "'" +
                      ", '" + txtCAB.Text + "'" +
                      ", '" + txtABI.Text + "'" +
                      ", '" + txtCC.Text + "'" +
                      ", '" + txtCIN.Text + "'" +
                      ", '" + txtSwift.Text.Replace("'", "''") + "'" +
                      ", " + ((_dataItemCombo)cmbTipPag.SelectedItem).Id.ToString() +
                      ", " + ((_dataItemCombo)cmbBancaAz.SelectedItem).Id.ToString() +
                      ", '" + txtNoteFatt.Text.Replace("'", "''") + "'" +


                      // Campi per fattura Xml
                      ", '" + txtNome.Text.Replace("'", "''") + "'" +
                      ", '" + txtCognome.Text.Replace("'", "''") + "'" +
                      ", '" + txtNCivico1.Text + "'" +
                      ", '" + txtNCivico2.Text + "'" +
                      ", '" + ((cmbPaese.SelectedIndex >= 0) ? ((ComboboxItem)cmbPaese.SelectedItem).Value : "") + "'" +
                      ", '" + ((cmbNazione.SelectedIndex >= 0) ? ((ComboboxItem)cmbNazione.SelectedItem).Value : "") + "'" +
                      ", " + cmbDenominazione.SelectedIndex.ToString() +
                      ", " + cmbIdentificativo.SelectedIndex.ToString() +
                      ", '" + txtPEC.Text + "'" +
                      ", '" + txtIdentificativo.Text + "'" +
                      ", '" + ((cmbDivisa.SelectedIndex >= 0) ? ((ComboboxItem)cmbDivisa.SelectedItem).Value : "") + "'" +
                      ", " + (optPrivato.Checked ? "0" : "1") +

                      ", " + ((_dataItemCombo)cmbModPdf.SelectedItem).Id.ToString() +
                      ", " + ((_dataItemCombo)cmbModXml.SelectedItem).Id.ToString() +
                      ", '" + txtDescrPdf.Text + "'" +
                      ", '" + txtDescrXml.Text + "'" +

                      ")";
      }

      if (clsDataBase.ExecuteNonQuery(strSql))
      {
        MessageBox.Show("Aggiornamento effettuato.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
        if (IdSel == 0)
          IdSel = clsDataBase.GetLastId(clsGlobal.ETypeTable.TT_CLIENTI);

        this.Close();
      }
    }

    private void LoadCliente(int IdSel)
    {
      string strSql = "Select * from Clienti where ID = " + IdSel.ToString();
      if (clsDataBase.ExecuteQuery(strSql))
      {
        if (clsDataBase.vetDbReader[0].Read())
        {
          txtCodCliente.Text = IdSel.ToString();
          txtRagSoc.Text = clsDataBase.GetStringValue("Cln_rag_soc");
          txtNome.Text = clsDataBase.GetStringValue("Cln_nome");
          txtCognome.Text = clsDataBase.GetStringValue("Cln_cognome");
          txtIdentificativo.Text = clsDataBase.GetStringValue("Cln_cod_identificativo");
          txtPEC.Text = clsDataBase.GetStringValue("Cln_pec");

          txtIndirizzo1.Text = clsDataBase.GetStringValue("Cln_sede_legale");
          txtCap1.Text = clsDataBase.GetStringValue("Cln_sede_legale_cap");
          txtCitta1.Text = clsDataBase.GetStringValue("Cln_sede_legale_citta");
          txtPrv1.Text = clsDataBase.GetStringValue("Cln_sede_legale_prov");
          txtNCivico1.Text = clsDataBase.GetStringValue("Cln_sede_legale_nciv");

          txtIndirizzo2.Text = clsDataBase.GetStringValue("Cln_ind_spedizione");
          txtCap2.Text = clsDataBase.GetStringValue("Cln_ind_spedizione_cap");
          txtCitta2.Text = clsDataBase.GetStringValue("Cln_ind_spedizione_citta");
          txtPrv2.Text = clsDataBase.GetStringValue("Cln_ind_spedizione_prov");
          txtNCivico2.Text = clsDataBase.GetStringValue("Cln_ind_spedizione_nciv");

          txtPIVA.Text = clsDataBase.GetStringValue("Cln_iva");
          txtCodFiscale.Text = clsDataBase.GetStringValue("Cln_cod_fis");
          txtTel.Text = clsDataBase.GetStringValue("Cln_tel");
          txtFax.Text = clsDataBase.GetStringValue("Cln_fax");
          txtEmail.Text = clsDataBase.GetStringValue("Cln_email");
          txtWeb.Text = clsDataBase.GetStringValue("Cln_web_site");
          txtIBAN.Text = clsDataBase.GetStringValue("Cln_iban");
          txtBanca.Text = clsDataBase.GetStringValue("Cln_banca_descr");
          txtCAB.Text = clsDataBase.GetStringValue("cln_banca_cab");
          txtABI.Text = clsDataBase.GetStringValue("Cln_banca_abi");
          txtCC.Text = clsDataBase.GetStringValue("Cln_banca_cc");
          txtCIN.Text = clsDataBase.GetStringValue("Cln_banca_cin");
          txtSwift.Text = clsDataBase.GetStringValue("Cln_banca_swift");
          cmbTipPag.Tag = clsDataBase.GetIntValue("Cln_ID_Tipi_pagamento");
          cmbBancaAz.Tag = clsDataBase.GetIntValue("Cln_ID_Banca_azienda");
          txtNoteFatt.Text = clsDataBase.GetStringValue("Cln_Note_Fatt");

          cmbIdentificativo.SelectedIndex = clsDataBase.GetIntValue("Cln_tipo_identificativo");
          cmbDenominazione.SelectedIndex = clsDataBase.GetIntValue("Cln_tipo_denominazione");

          cmbPaese.Tag = clsDataBase.GetStringValue("Cln_paese");
          cmbNazione.Tag = clsDataBase.GetStringValue("Cln_nazione");
          cmbDivisa.Tag = clsDataBase.GetStringValue("Cln_divisa");

          optPrivato.Checked = (clsDataBase.GetBoolValue("Cln_tipo_cliente") == false);
          optPA.Checked = (clsDataBase.GetBoolValue("Cln_tipo_cliente") == true);

          cmbModPdf.Tag = clsDataBase.GetIntValue("Cln_id_fattura_pdf");
          cmbModXml.Tag = clsDataBase.GetIntValue("Cln_id_fattura_xml");

        }
      }
      clsDataBase.CloseDataReader();
      PopolaCombo();
    }

    private void bttElimina_Click(object sender, EventArgs e)
    {
      if (IdSel > 0)
      {
        if (MessageBox.Show("Eliminare il cliente selezionato ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
        {
          string strSql = "Update clienti set " +
                              " Cln_cancellato = 1" +
                              " where Id= " + IdSel.ToString();
          if (clsDataBase.ExecuteNonQuery(strSql))
          {
            MessageBox.Show("Aggiornamento effettuato.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
          }
        }
      }
    }

    private void bttAnnulla_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Annullare le modifiche effettuate ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
      {
        if (IdSel > 0)
          LoadCliente(IdSel);
        else
          ClearFields();
      }
    }

    private void ClearFields()
    {
      txtCodCliente.Text = IdSel.ToString();
      txtRagSoc.Text = "";
      txtNome.Text = "";
      txtCognome.Text = "";
      txtIndirizzo1.Text = "";
      txtCap1.Text = "";
      txtCitta1.Text = "";
      txtPrv1.Text = "";
      txtNCivico1.Text = "";
      txtIndirizzo2.Text = "";
      txtCap2.Text = "";
      txtCitta2.Text = "";
      txtPrv2.Text = "";
      txtNCivico2.Text = "";
      txtPIVA.Text = "";
      txtCodFiscale.Text = "";
      txtTel.Text = "";
      txtFax.Text = "";
      txtEmail.Text = "";
      txtWeb.Text = "";
      txtIBAN.Text = "";
      txtBanca.Text = "";
      txtCAB.Text = "";
      txtABI.Text = "";
      txtCC.Text = "";
      txtCIN.Text = "";
      txtSwift.Text = "";
      txtIdentificativo.Text = "";
      txtPEC.Text = "";

      cmbTipPag.Tag = null;
      cmbBancaAz.Tag = null;

      cmbDenominazione.SelectedIndex = 0;
      cmbIdentificativo.SelectedIndex = 0;
      cmbPaese.Tag = "IT";
      cmbNazione.Tag = "IT";
      cmbDivisa.Tag = "EUR";
      optPrivato.Checked = true;
    }

    private void PopolaCombo()
    {
      clsDataBase.PopolaCombo(cmbTipPag, clsGlobal.ETypeTable.TT_TIP_PAGAMENTO);
      clsDataBase.PopolaCombo(cmbBancaAz, clsGlobal.ETypeTable.TT_BANCHE_AZ);
      clsDataBase.PopolaCombo_2(cmbPaese, clsGlobal.ETypeTable.XML_NAZIONE);
      clsDataBase.PopolaCombo_2(cmbNazione, clsGlobal.ETypeTable.XML_NAZIONE);
      clsDataBase.PopolaCombo_2(cmbDivisa, clsGlobal.ETypeTable.XML_DIVISA);

      clsDataBase.PopolaComboPdfFatture(cmbModPdf);
      clsDataBase.PopolaComboXmlFatture(cmbModXml);
    }

    private void txtABI_TextChanged(object sender, EventArgs e)
    {

    }

    private void txtABI_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = !clsGlobal.IsNumber(e.KeyChar);
    }

    private void txtCC_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = !clsGlobal.IsNumber(e.KeyChar);
    }

    private void txtCAB_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = !clsGlobal.IsNumber(e.KeyChar);
    }

    private void txtCap1_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = !clsGlobal.IsNumber(e.KeyChar);
    }

    private void txtCap2_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = !clsGlobal.IsNumber(e.KeyChar);
    }

    private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = !(clsGlobal.IsNumber(e.KeyChar) || e.KeyChar == '+' || e.KeyChar == ' ');
    }

    private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = !(clsGlobal.IsNumber(e.KeyChar) || e.KeyChar == '+' || e.KeyChar == ' ');
    }

    private void txtIdentificativo_KeyPress(object sender, KeyPressEventArgs e)
    {
      // Accetto solo numeri o lettere
      e.Handled = !(clsGlobal.IsNumber(e.KeyChar) || clsGlobal.IsLetter(e.KeyChar));

    }

    private void txtPEC_KeyPress(object sender, KeyPressEventArgs e)
    {
      // Accetto solo numeri, lettere ed i caratteri speciali .@-_
      e.Handled = !(clsGlobal.IsNumber(e.KeyChar) || clsGlobal.IsLetter(e.KeyChar) || (e.KeyChar == '@') || (e.KeyChar == '.') || (e.KeyChar == '-') || (e.KeyChar == '_'));
    }

    private void frmModCliente_Shown(object sender, EventArgs e)
    {

    }

    private void bttTipPag_Click(object sender, EventArgs e)
    {
      clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_TIP_PAGAMENTO, cmbTipPag);
    }

    private void txtTel_TextChanged(object sender, EventArgs e)
    {

    }

    private void bttBancaAz_Click(object sender, EventArgs e)
    {
      clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_BANCHE_AZ, cmbBancaAz);
    }



    /// <summary>
    /// Gestione dell'elemento selezionato: in base al valore, consente l'inserimento della Ragione sociale oppure dell'accopiata Nome/Cognome
    /// </summary>
    /// <param name="sender">Oggetto</param>
    /// <param name="e">Parametri evento</param>
    private void cmbDenominazione_SelectedIndexChanged(object sender, EventArgs e)
    {
      txtRagSoc.Enabled = (cmbDenominazione.SelectedIndex == 0);
      if (txtRagSoc.Enabled == false)
        txtRagSoc.Text = "";

      txtNome.Enabled = (cmbDenominazione.SelectedIndex == 1);
      txtCognome.Enabled = (cmbDenominazione.SelectedIndex == 1);
      if (txtNome.Enabled == false)
      {
        txtNome.Text = "";
        txtCognome.Text = "";
      }
    }

    /// <summary>
    /// Gestione dell'elemento selezionato: in base al valore, consente l'inserimento del codice identificativo oppure della PEC
    /// </summary>
    /// <param name="sender">Oggetto</param>
    /// <param name="e">Parametri evento</param>
    private void cmbIdentificativo_SelectedIndexChanged(object sender, EventArgs e)
    {
      txtIdentificativo.Enabled = (cmbIdentificativo.SelectedIndex == 0);
      if (txtIdentificativo.Enabled == false)
        txtIdentificativo.Text = "";

      txtPEC.Enabled = (cmbIdentificativo.SelectedIndex == 1);
      if (txtPEC.Enabled == false)
        txtPEC.Text = "";
    }

    private void cmbModPdf_SelectedIndexChanged(object sender, EventArgs e)
    {
      string val = "";
      if (cmbModPdf.SelectedIndex != -1)
        val = ((_dataItemCombo)cmbModPdf.SelectedItem).Tag.ToString();

      //txtDescrPdf.Visible = (val != "");
      txtDescrPdf.Text = val;
    }

    private void cmbModXml_SelectedIndexChanged(object sender, EventArgs e)
    {
      string val = "";
      if (cmbModXml.SelectedIndex != -1)
        val = ((_dataItemCombo)cmbModXml.SelectedItem).Tag.ToString();

      //txtDescrXml.Visible = (val != "");
      txtDescrXml.Text = val;
    }

  }
}
