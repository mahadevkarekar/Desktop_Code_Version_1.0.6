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
    public partial class frmAnagAzienda : Form
    {
        private bool IsChange = false;

        public frmAnagAzienda()
        {
            InitializeComponent();
        }

        private void bttFileLogo_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtLogo.Text = openFileDialog1.FileName;            
            picbLogo.ImageLocation = txtLogo.Text;

        }

        private void frmAnagAzienda_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LoadParam();
            PreparaCombo();
            IsChange = false;
        }

        private void frmAnagAzienda_FormClosed(object sender, FormClosedEventArgs e)
        {
            //((mdipMain)this.MdiParent).MainMenuStrip.Items["tsmiAnagrafica"].Enabled = true;
            //((mdipMain)this.MdiParent).MainMenuStrip.Items["tsmiAnagAzienda"].ToolTipText = "";
        }

        private void LoadParam()
        {

            string strSql = "select * from azienda";
            if (clsDataBase.ExecuteQuery(strSql))
            {
                if (clsDataBase.vetDbReader[0].Read())
                {
                    txtRagSoc.Text = clsDataBase.GetStringValue("Az_rag_soc");
          txtNome.Text = clsDataBase.GetStringValue("Az_nome");
          txtCognome.Text = clsDataBase.GetStringValue("Az_cognome");
          txtCodFisc.Text = clsDataBase.GetStringValue("Az_cod_fis");
                    txtPIVA.Text = clsDataBase.GetStringValue("Az_iva");
          txtIdentificativo.Text = clsDataBase.GetStringValue("Az_cod_identificativo");
          txtPEC.Text = clsDataBase.GetStringValue("Az_pec");

          txtIndirizzo1.Text = clsDataBase.GetStringValue("Az_ind_1");
                    txtCAP1.Text = clsDataBase.GetStringValue("Az_ind_1_cap");
                    txtCitta1.Text = clsDataBase.GetStringValue("Az_ind_1_citta");
                    txtProv1.Text = clsDataBase.GetStringValue("Az_ind_1_prov");
          txtNCivico1.Text = clsDataBase.GetStringValue("Az_ind_1_nciv");

          
                    txtIndirizzo2.Text = clsDataBase.GetStringValue("Az_ind_2");
                    txtCAP2.Text = clsDataBase.GetStringValue("Az_ind_2_cap");
                    txtCitta2.Text = clsDataBase.GetStringValue("Az_ind_2_citta");
                    txtProv2.Text = clsDataBase.GetStringValue("Az_ind_2_prov");
          txtNCivico2.Text = clsDataBase.GetStringValue("Az_ind_2_nciv");

          txtTel.Text = clsDataBase.GetStringValue("Az_tel");
                    txtFax.Text = clsDataBase.GetStringValue("Az_fax");
                    txtEmail.Text = clsDataBase.GetStringValue("Az_email");

                    txtWEB.Text = clsDataBase.GetStringValue("Az_web_site");
                    txtLogo.Text = clsDataBase.GetStringValue("Az_logo_path");

          cmbIdentificativo.SelectedIndex = clsDataBase.GetIntValue("Az_tipo_identificativo");
          cmbDenominazione.SelectedIndex = clsDataBase.GetIntValue("Az_tipo_denominazione");

          cmbPaese.Tag = clsDataBase.GetStringValue("Az_paese");
          cmbNazione.Tag = clsDataBase.GetStringValue("Az_nazione");
          cmbRegime.Tag = clsDataBase.GetStringValue("Az_regime");

          picbLogo.ImageLocation = txtLogo.Text;
                }
                else
                {
                    System.Reflection.Assembly exe = System.Reflection.Assembly.GetEntryAssembly(); 
                    txtLogo.Text = System.IO.Path.GetDirectoryName(exe.Location) + "\\logo_demo.jpg";
                }
            }
            
            clsDataBase.CloseDataReader();
        }

        private void bttSalva_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Salvare le modifiche apportate?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                SaveNewValue();
                IsChange = false; 
            }
        }

        private void SaveNewValue()
        {

            // Se i campi non sono compilato correttamente, segnalo l'errore ed esco
            if (!VerificaCampi()) return;

            bool bRet = false;

            if ((int)clsDataBase.ExecuteScalar("Select Count(*) from Azienda") == 0)
                bRet = InsertAnagAz();
            else
                bRet = UpdateAnagAz();

            if (bRet)
                MessageBox.Show("Salvataggio effettuato correttamente.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }

    private bool VerificaCampi()
    {
      bool bRetValue = true;
      string strErrore = "";

      // Controllo di validità sui nuovi campi
      if (cmbDenominazione.SelectedIndex == -1)
      {
        strErrore += "Impostare una tipologia di denominazione\n";
      }
      if (cmbIdentificativo.SelectedIndex == -1)
      {
        strErrore += "Impostare una tipologia di identificativo\n";
      }
      if (cmbRegime.SelectedIndex < 1)
      {
        strErrore += "Impostare un regime fiscale\n";
      }


      if (cmbDenominazione.SelectedIndex == 0)
      {
        if (txtRagSoc.Text == "") strErrore += "Richiesta Ragione Sociale\n";
      }
      else if(cmbDenominazione.SelectedIndex == 1)
      {
        if (txtNome.Text == "" || txtCognome.Text == "") strErrore += "Richiesto Nome/Cognome\n";
      }

      if (txtPIVA.Text == "")
        strErrore += "Richiesta Partita IVA\n";
      else
      {
        if (System.Text.RegularExpressions.Regex.Match(txtPIVA.Text, "[A-Za-z]").Success)
          strErrore += "Non sono ammessi caratteri alfanumerici nella Partita IVA\n";
      }

      if (txtIndirizzo1.Text == "" || txtCAP1.Text == "" || txtCitta1.Text == "" || txtProv1.Text == "" || txtNCivico1.Text == "") strErrore += "Richiesto indirizzo 1 completo\n";

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

      if (strErrore != "")
      {
        MessageBox.Show("Verificare i parametri inseriti:\n\n" + strErrore, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        bRetValue = false;
      }

      return bRetValue;
    }

    private bool InsertAnagAz()
        {
            string strSql = "Insert into Azienda (Az_rag_soc, Az_cod_fis, Az_iva, Az_nome, Az_cognome, Az_ind_1, Az_ind_1_cap, Az_ind_1_citta, Az_ind_1_prov, Az_ind_1_nciv, Az_ind_2, Az_ind_2_cap, Az_ind_2_citta, Az_ind_2_prov, Az_ind_2_nciv, Az_paese, Az_nazione, Az_regime, Az_tipo_identificativo, Az_tipo_denominazione, Az_cod_identificativo, Az_pec, Az_tel, Az_fax, Az_email, Az_web_site, Az_logo_path) values (" +
                            " '" + txtRagSoc.Text + "', " +
                            " '" + txtCodFisc.Text + "', " +
                            " '" + txtPIVA.Text + "', " +
                            " '" + txtNome.Text.Replace("'", "''") + "', " +
                            " '" + txtCognome.Text.Replace("'", "''") + "', " +

                            " '" + txtIndirizzo1.Text + "', " +
                            " '" + txtCAP1.Text + "', " +
                            " '" + txtCitta1.Text + "', " +
                            " '" + txtProv1.Text + "', " +
                            " '" + txtNCivico1.Text + "', " +

                            " '" + txtIndirizzo2.Text + "', " +
                            " '" + txtCAP2.Text + "', " +
                            " '" + txtCitta2.Text + "', " +
                            " '" + txtProv2.Text + "', " +
                            " '" + txtNCivico1.Text + "', " +

                            " '" + ((cmbPaese.SelectedIndex >= 0) ? ((_dataItemCombo)cmbPaese.SelectedItem).Value : "") + "', " +
                            " '" + ((cmbNazione.SelectedIndex >= 0) ? ((_dataItemCombo)cmbNazione.SelectedItem).Value : "") + "', " +

                            " '" + ((cmbRegime.SelectedIndex >= 0) ? ((_dataItemCombo)cmbRegime.SelectedItem).Value : "") + "', " +

                            " " + cmbIdentificativo.SelectedIndex.ToString() + ", " +
                            " " + cmbDenominazione.SelectedIndex.ToString() + ", " +

                            " '" + txtIdentificativo.Text + "', " +
                            " '" + txtPEC.Text + "', " +

                            " '" + txtTel.Text + "', " +
                            " '" + txtFax.Text + "', " +
                            " '" + txtEmail.Text + "', " +

                            " '" + txtWEB.Text + "', " +
                            " '" + txtLogo.Text + "')";

            return clsDataBase.ExecuteNonQuery(strSql);
        }

        private bool UpdateAnagAz()
        {
            string strSql = "Update Azienda set " +

                            "Az_tipo_denominazione =" + cmbDenominazione.SelectedIndex.ToString() + ", " +
                            "Az_rag_soc ='" + txtRagSoc.Text + "', " +
                            "Az_nome ='" + txtNome.Text.Replace("'", "''") + "', " +
                            "Az_cognome ='" + txtCognome.Text.Replace("'", "''") + "', " +
                            "Az_cod_fis ='" + txtCodFisc.Text + "', " +
                            "Az_iva ='" + txtPIVA.Text + "', " +

                            "Az_ind_1 ='" + txtIndirizzo1.Text + "', " +
                            "Az_ind_1_cap ='" + txtCAP1.Text + "', " +
                            "Az_ind_1_citta ='" + txtCitta1.Text + "', " +
                            "Az_ind_1_prov ='" + txtProv1.Text + "', " +
                            "Az_ind_1_nciv ='" + txtNCivico1.Text + "', " +

                            "Az_ind_2 ='" + txtIndirizzo2.Text + "', " +
                            "Az_ind_2_cap ='" + txtCAP2.Text + "', " +
                            "Az_ind_2_citta ='" + txtCitta2.Text + "', " +
                            "Az_ind_2_prov ='" + txtProv2.Text + "', " +
                            "Az_ind_2_nciv ='" + txtNCivico2.Text + "', " +

                            "Az_tipo_identificativo =" + cmbIdentificativo.SelectedIndex.ToString() + ", " +
                            "Az_pec ='" + txtPEC.Text + "', " +
                            "Az_cod_identificativo ='" + txtIdentificativo.Text + "', " +

                            "Az_paese ='" + ((cmbPaese.SelectedIndex >= 0) ? ((ComboboxItem) cmbPaese.SelectedItem).Value :  "")  + "', " +
                            "Az_nazione ='" + ((cmbNazione.SelectedIndex >= 0) ? ((ComboboxItem) cmbNazione.SelectedItem).Value : "")  + "', " +

                            "Az_regime ='" + ((cmbRegime.SelectedIndex >= 0) ? ((ComboboxItem) cmbRegime.SelectedItem).Value : "") + "', " +

                            "Az_tel ='" + txtTel.Text + "', " +
                            "Az_fax ='" + txtFax.Text + "', " +
                            "Az_email ='" + txtEmail.Text + "', " +

                            "Az_web_site ='" + txtWEB.Text + "', " +
                            "Az_logo_path ='" + txtLogo.Text + "'";

            return clsDataBase.ExecuteNonQuery(strSql);                
        }

        private void bttAnnulla_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Annullare le modifiche apportate?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                LoadParam();
        }

        private void bttEsci_Click(object sender, EventArgs e)
        {
                Close();
        }

        private void object_Changed(object sender, EventArgs e)
        {
            IsChange = true;
        }

    private void objectCombo_SelectedIndexChanged(object sender, EventArgs e)
    {
      IsChange = true;
    }

    private void txtCAP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled =! clsGlobal.IsNumber(e.KeyChar);
        }

        private void txtCAP2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmAnagAzienda_Shown(object sender, EventArgs e)
        {
            
        }

    private void txtPIVA_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = !clsGlobal.IsNumber(e.KeyChar);
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

    private void frmAnagAzienda_FormClosing(object sender, FormClosingEventArgs e)
        {            
            if (IsChange)
            {
                if (MessageBox.Show("Uscire senza salvare le modifiche apportate?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                    e.Cancel = true;
            }            
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

    private void PreparaCombo()
    {
      // Caricamento dei valori presenti su Db
      clsDataBase.PopolaCombo_2(cmbRegime, clsGlobal.ETypeTable.XML_REGIME);
      clsDataBase.PopolaCombo_2(cmbPaese, clsGlobal.ETypeTable.XML_NAZIONE);
      clsDataBase.PopolaCombo_2(cmbNazione, clsGlobal.ETypeTable.XML_NAZIONE);
    }
  }
}
