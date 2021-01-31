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
    public partial class frmModAutomezzi : Form
    {
        public Form frmParent;
        public int IdSel;

        public frmModAutomezzi()
        {
            InitializeComponent();
        }

        private void frmModAutomezzi_Load(object sender, EventArgs e)
        {
            if (!this.Modal && this.MdiParent != null)
                this.WindowState = FormWindowState.Maximized;

            if (IdSel > 0)
                LoadAUtomezzo(IdSel);
            else
            {
                bttElimina.Enabled = false;
                cmbFreqBollo.SelectedIndex = 0;
                cmbFreqAss.SelectedIndex = 0;
            }            
        }

        private void LoadAUtomezzo(int IdSel)
        {
            string strSql = "Select * from Truck where ID = " + IdSel.ToString();
            if (clsDataBase.ExecuteQuery(strSql))
            {
                if (clsDataBase.vetDbReader[0].Read())
                {
                    lblCodice.Text = IdSel.ToString();
                    txtTarga.Text = clsDataBase.GetStringValue("truck_targa");
                    txtTelaio.Text = clsDataBase.GetStringValue("truck_telaio");
                    txtMarca.Text = clsDataBase.GetStringValue("truck_Marca");
                    txtModello.Text = clsDataBase.GetStringValue("truck_Modello");
                    txtDescr.Text = clsDataBase.GetStringValue("truck_descrizione");
                    if (clsDataBase.GetDateValue("truck_data_acquisto") == DateTime.MinValue)
                        dtpDataAcq.Checked = false;
                    else
                    {
                        dtpDataAcq.Checked = true;
                        dtpDataAcq.Value = clsDataBase.GetDateValue("truck_data_acquisto");
                    }

                    if (clsDataBase.GetDateValue("truck_immatricolazione") == DateTime.MinValue)
                        dtpDataImm.Checked = false;
                    else
                    {
                        dtpDataImm.Checked = true;
                        dtpDataImm.Value = clsDataBase.GetDateValue("truck_immatricolazione");
                    }
                    nudPortata.Value = clsDataBase.GetIntValue("truck_portata");
                    nudKM.Value = clsDataBase.GetIntValue("truck_Km");
                    nudKw.Value = clsDataBase.GetIntValue("truck_Kw");
                    if (clsDataBase.GetDateValue("truck_scadenza_bollo") == DateTime.MinValue)
                        dtpScadBollo.Checked = false;
                    else
                    {
                        dtpScadBollo.Checked = true;
                        dtpScadBollo.Value = clsDataBase.GetDateValue("truck_scadenza_bollo");
                    }
                    
                    cmbFreqBollo.SelectedIndex = clsDataBase.GetIntValue("truck_tipo_scadenza_bollo");  
                    nudBollo.Value = clsDataBase.GetValutaValue("truck_importo_bollo");
                    txtAss.Text = clsDataBase.GetStringValue("truck_assicurazione");

                    if (clsDataBase.GetDateValue("truck_scadenza_assic") == DateTime.MinValue)
                        dtpScadAss.Checked = false;
                    else
                    {
                        dtpScadAss.Checked = true;
                        dtpScadAss.Value = clsDataBase.GetDateValue("truck_scadenza_assic");
                    }
                    
                    cmbFreqAss.SelectedIndex= clsDataBase.GetIntValue("truck_tipo_scadenza_ass"); 
                    nudAss.Value = clsDataBase.GetValutaValue("truck_importo_assic");
                    txtNote.Text = clsDataBase.GetStringValue("truck_note");
                    if (!clsDataBase.GetBoolValue("truck_proprio")) rdbPropTerzi.Checked = true;
                }
            }

            clsDataBase.CloseDataReader();            
        }

        private void frmModAutomezzi_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void bttEsci_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            string strSql = "";

            if (MessageBox.Show("Salvare le nuove impostazioni.", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;

            if (!VerificaCampi()) return;

            int TypeScadBollo = 1;
            int TypeScadAss = 1;
            int TypeProprieta = 1;

            TypeScadBollo = cmbFreqBollo.SelectedIndex;
            TypeScadAss = cmbFreqAss.SelectedIndex;
            
            if (rdbPropTerzi.Checked) TypeProprieta = 0;

            if (lblCodice.Text != "")
            {
                // Devo Effettuare Update
                strSql = "Update Truck set " +
                          " truck_targa = '" + txtTarga.Text + "'" +
                          ", truck_telaio = '" + txtTelaio.Text + "'" +
                          ", truck_Marca = '" + txtMarca.Text.Replace("'", "''") + "'" +
                          ", truck_Modello = '" + txtModello.Text.Replace("'", "''") + "'" +
                          ", truck_descrizione = '" + txtDescr.Text.Replace("'", "''") + "'";
                if (dtpDataAcq.Checked && rdbProprio.Checked)
                    strSql += ", truck_data_acquisto = " + clsDataBase.SQL_ConvertDateTimeToData(dtpDataAcq.Value);
                else
                    strSql += ", truck_data_acquisto = null";
                
                          //", truck_data_acquisto = " + clsDataBase.SQL_ConvertDateTimeToData(dtpDataAcq.Value) +
                if (dtpDataImm.Checked && rdbProprio.Checked)
                    strSql += ", truck_immatricolazione = " + clsDataBase.SQL_ConvertDateTimeToData(dtpDataImm.Value);
                else
                    strSql += ", truck_immatricolazione = null";

                strSql += ", truck_portata = " + nudPortata.Value.ToString() +
                          ", truck_Km = " + nudKM.Value.ToString() +
                          ", truck_Kw = " + nudKw.Value.ToString();

                if (rdbProprio.Checked)
                {
                    if (dtpDataImm.Checked)
                        strSql += ", truck_scadenza_bollo = " + clsDataBase.SQL_ConvertDateTimeToData(dtpScadBollo.Value);
                    else
                        strSql += ", truck_scadenza_bollo = null";
                    
                    strSql += ", truck_importo_bollo = " + nudBollo.Value.ToString().Replace(",", ".") +
                          ", truck_assicurazione = '" + txtAss.Text.Replace("'", "''") + "'";
                    
                    if (rdbProprio.Checked)
                        strSql += ", truck_scadenza_assic = " + clsDataBase.SQL_ConvertDateTimeToData(dtpScadAss.Value);
                    else
                        strSql += ", truck_scadenza_assic = null";

                    strSql += ", truck_tipo_scadenza_ass = " + TypeScadAss.ToString() +
                              ", truck_importo_assic = " + nudAss.Value.ToString().Replace(",", ".");
                }
                else
                {
                    strSql += ", truck_scadenza_bollo = null" +
                              ", truck_importo_bollo = 0.00" +
                              ", truck_assicurazione = ''" +
                              ", truck_scadenza_assic = null" +
                              ", truck_tipo_scadenza_ass = 0" +
                              ", truck_importo_assic = 0.00";
                }


                strSql += ", truck_note = '" + txtNote.Text.Replace("'", "''") + "'" +
                          ", truck_proprio = " + TypeProprieta +
                          " where Id= " + lblCodice.Text;
            }
            else
            { 
                // Devo effettuare inserimento
                strSql = "Insert into Truck (truck_targa, truck_telaio, truck_Marca, truck_modello, truck_descrizione, truck_data_acquisto, truck_immatricolazione, truck_portata, truck_Km, truck_Kw, truck_scadenza_bollo, truck_tipo_scadenza_bollo, truck_importo_bollo, truck_assicurazione, truck_scadenza_assic, truck_tipo_scadenza_ass, truck_importo_assic, truck_note, truck_proprio) values (" +
                          "'" + txtTarga.Text + "'" +
                          ", '" + txtTelaio.Text + "'" +
                          ", '" + txtMarca.Text.Replace("'","''") + "'" +
                          ", '" + txtModello.Text.Replace("'", "''") + "'" +
                          ", '" + txtDescr.Text.Replace("'", "''") + "'" +
                          ", " + clsDataBase.SQL_ConvertDateTimeToData(dtpDataAcq) +
                          ", " + clsDataBase.SQL_ConvertDateTimeToData(dtpDataImm) +
                          ", " + nudPortata.Value.ToString() +
                          ", " + nudKM.Value.ToString() +
                          ", " + nudKw.Value.ToString() +
                          ", " + clsDataBase.SQL_ConvertDateTimeToData(dtpScadBollo) +
                          ", " + TypeScadBollo.ToString() +
                          ", " + nudBollo.Value.ToString().Replace(",", ".") +
                          ", '" + txtAss.Text.Replace("'", "''") + "'" +
                          ", " + clsDataBase.SQL_ConvertDateTimeToData(dtpScadAss) +
                          ", " + TypeScadAss.ToString() +
                          ", " + nudAss.Value.ToString().Replace(",", ".") +
                          ", '" + txtNote.Text.Replace("'", "''") + "'" +
                          ", " + TypeProprieta +
                          ")";
            }

            if (clsDataBase.ExecuteNonQuery(strSql))
            {
                MessageBox.Show("Aggiornamento effettuato.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (lblCodice.Text == "")
                    IdSel = clsDataBase.GetLastId(clsGlobal.ETypeTable.TT_AUTOMEZZI);
                this.Close();
            }
        }

        private bool VerificaCampi()
        {
            bool bRetValue = true;
            string strErrore = "";

            if (txtTarga.Text == "") strErrore += "Richiesto inserimento Targa\n";
            
            if (strErrore == "")
            {
                if ((int)clsDataBase.ExecuteScalar("Select count(*) from  Truck where id<>" + IdSel.ToString() + " and truck_cancellato=0 and upper(truck_targa) ='" + txtTarga.Text.Trim().ToUpper().Replace("'", "''") + "'") > 0)
                    strErrore = "Targa automezzo già presente\n";
            }

            if (strErrore == "" && txtTelaio.Text != "")
            {
                if ((int)clsDataBase.ExecuteScalar("Select count(*) from Truck where id<>" + IdSel.ToString() + " and truck_cancellato=0 and upper(truck_telaio) ='" + txtTelaio.Text.Trim().ToUpper().Replace("'", "''") + "'") > 0)
                    strErrore = "Telaio automezzo già presente\n";
            }

            if (strErrore != "")
            {
                MessageBox.Show("Verificare i parametri inseriti:\n\n" + strErrore, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bRetValue = false;
            }

            return bRetValue;
        }

        private void bttElimina_Click(object sender, EventArgs e)
        {
            if (lblCodice.Text != "")
            {
                if (MessageBox.Show("Eliminare l'automezzo selezionato ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string strSql = "Update Truck set " +
                                        " truck_cancellato = 1" +
                                        " where Id= " + lblCodice.Text;
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
                    LoadAUtomezzo(IdSel);
                else
                    ClearFields();
            }
        }

        private void ClearFields()
        {
            lblCodice.Text = IdSel.ToString();
            txtTarga.Text = "";
            txtTelaio.Text = "";
            txtMarca.Text = "";
            txtModello.Text = "";
            txtDescr.Text = "";
            dtpDataAcq.Checked = false;
            dtpDataImm.Checked = false;
            nudPortata.Value = 0;
            nudKM.Value = 0;
            nudKw.Value = 0;
            dtpScadBollo.Checked = false;
            cmbFreqBollo.SelectedIndex=0;
            nudBollo.Value = 0;
            txtAss.Text = "";
            dtpScadAss.Checked = false;
            cmbFreqAss.SelectedIndex = 0;
            nudAss.Value = 0;
            txtNote.Text = "";
            rdbProprio.Checked = true;            
        }

        private void frmModAutomezzi_Shown(object sender, EventArgs e)
        {
            
        }

        private void rdbProprio_CheckedChanged(object sender, EventArgs e)
        {
            //grpbProprio.Enabled = rdbProprio.Checked;
            grpTerzi.Enabled = !rdbProprio.Checked;
            grpbScad.Enabled = rdbProprio.Checked;
            dtpDataAcq.Enabled = dtpDataImm.Enabled = rdbProprio.Checked;
        }

        private void frmModAutomezzi_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmParent != null)
            {
                frmParent.Show();
            }
        }
    }
}
