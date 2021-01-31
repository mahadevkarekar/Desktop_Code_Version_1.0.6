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
    public partial class frmImpostazioni : Form
    {
        private bool isChangeDbSetting = false;
        private bool isChangeOtherSetting = false;

        public bool EnableOtherParam = true;

        public frmImpostazioni()
        {
            InitializeComponent();
        }

        private void bttTestDb_Click(object sender, EventArgs e)
        {
            if (clsDataBase.TestConnection(txtDBServer.Text))
                MessageBox.Show("Connessione effettuata correttamente.", "Test di connettività",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Errore nella connessione al DB.\n\n" + "Error\n  " + clsDataBase.LastError, "Test di connettività",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void bttEsc_Click(object sender, EventArgs e)
        {   
                this.Close();
        }

        private void txtDBServer_TextChanged(object sender, EventArgs e)
        {
            isChangeDbSetting = true;
        }

        private void bttSaveDb_Click(object sender, EventArgs e)
        {
            clsSetting.DB_Server = txtDBServer.Text.Trim();
            if (EnableOtherParam)
                MessageBox.Show("Impostazioni Database salvate correttamente.\n\nPer Rendere effettive le modifiche è necessario riavviare l'applicazione.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Impostazioni Database salvate correttamente.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsDataBase.DbConnect(clsSetting.DB_Server); 
            }
            isChangeDbSetting = false;
        }

        private void lblPathPdf_TextChanged(object sender, EventArgs e)
        {
            isChangeOtherSetting = true;
        }

        private void rdbObject_CheckedChanged(object sender, EventArgs e)
        {
            isChangeOtherSetting = true;
        }

        private void txtNoteFatt_TextChanged(object sender, EventArgs e)
        {
            isChangeOtherSetting = true;
        }

        private void bttSalvaOtherSet_Click(object sender, EventArgs e)
        {
            clsSetting.param_path_save_folder = lblPathPdf.Text;
      clsSetting.param_stampa_logo_docu = rdbPrintLogo.Checked;
            clsSetting.param_stampa_dati_az_docu = rdbPrintDati.Checked;
            clsSetting.param_note_fattura = txtNoteFatt.Text;
            clsSetting.param_coefficente = nudCoeff.Value;
            clsSetting.param_prezzo_carburante = nudPrezzoCarb.Value;
            if (cmbModFatt.SelectedIndex >-1)
                clsSetting.param_model_fattura = cmbModFatt.SelectedIndex;
            else
                clsSetting.param_model_fattura = 0;

            if (clsSetting.Save_OtherParam())
                MessageBox.Show("Parametri salvati correttamente.","Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Errore nel salvataggio dei parametri.","Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            isChangeOtherSetting = false;
        }

        private void frmImpostazioni_Load(object sender, EventArgs e)
        {
            if (!this.Modal && this.MdiParent != null)
                this.WindowState = FormWindowState.Maximized;

            txtDBServer.Text = clsSetting.DB_Server;
            grpbOtherParam.Enabled = EnableOtherParam;
            grpbOtherParam.Visible = EnableOtherParam;
            if (!EnableOtherParam)
            {
                this.Height -= grpbOtherParam.Height;
                bttEsc.Top -= grpbOtherParam.Height;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
            }
            else
                LoadOtherParam();

            isChangeDbSetting = false;
            isChangeOtherSetting = false;
        }

        private void LoadOtherParam()
        {
            lblPathPdf.Text = clsSetting.param_path_save_pdf;
            if (clsSetting.param_stampa_dati_az_docu)
                rdbPrintDati.Checked = true;
            else
                rdbPrintDatiNo.Checked = true;

            if (clsSetting.param_stampa_logo_docu)
                 rdbPrintLogo.Checked = true;
            else
                rdbPrintLogoNo.Checked = true;

            cmbModFatt.SelectedIndex = clsSetting.param_model_fattura;

            txtNoteFatt.Text = clsSetting.param_note_fattura;
            nudCoeff.Value = clsSetting.param_coefficente;
            nudPrezzoCarb.Value = clsSetting.param_prezzo_carburante;
        }

        private void frmImpostazioni_Shown(object sender, EventArgs e)
        {
           
        }

        private void bttSetPathPdf_Click(object sender, EventArgs e)
        {

            if (lblPathPdf.Text != "")
                folderBrowserDialog1.SelectedPath = lblPathPdf.Text;

            folderBrowserDialog1.ShowDialog();
            lblPathPdf.Text = folderBrowserDialog1.SelectedPath;
        }

        private void frmImpostazioni_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChangeOtherSetting || isChangeDbSetting)
            {
                if (MessageBox.Show("Chiudi senza salvare?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                    e.Cancel = true;
            }            
        }

        private void bttFatAntep_Click(object sender, EventArgs e)
        {
            if (cmbModFatt.SelectedIndex == 1)
            {
                crpDocFat1 newReport = new crpDocFat1();

                clsReport.InizializzaReport(newReport);
                //crClienti.RecordSelectionFormula = "id=0";

                //newReport.SetDataSource((DataTable)(bindingSource1.DataSource));
                newReport.SetParameterValue("IdFatt2", 0);
                newReport.SetParameterValue("IdFat1", 0);
                newReport.SetParameterValue("IdFat", 0);
                newReport.SetParameterValue("TipoDocumento", "FATTURA");

                clsReport.SetParamIntestazione(newReport);
                clsReport.ShowReport(newReport);
            }
            else
            {
                crpDocFattura newReport = new crpDocFattura();

                clsReport.InizializzaReport(newReport);
                //crClienti.RecordSelectionFormula = "id=0";

                //newReport.SetDataSource((DataTable)(bindingSource1.DataSource));
                newReport.SetParameterValue("IdFatt2", 0);
                newReport.SetParameterValue("IdFat1", 0);
                newReport.SetParameterValue("IdFat", 0);
                newReport.SetParameterValue("TipoDocumento", "FATTURA");

                clsReport.SetParamIntestazione(newReport);
                clsReport.ShowReport(newReport);
            }
        }
    }
}
