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
    public partial class frmBanche : Form
    {
        public int IdSel = 0;
        public bool IsInsertOnly = false;

        public frmBanche()
        {
            InitializeComponent();
        }

        private void frmBanche_Load(object sender, EventArgs e)
        {
            if (!this.Modal)
                this.WindowState = FormWindowState.Maximized;

            clsDataBase.PopolaListItem(lstValori, clsGlobal.ETypeTable.TT_BANCHE_AZ);
            
            if (IsInsertOnly)
                bttNew_Click(null, null);
        }

        private void bttNew_Click(object sender, EventArgs e)
        {
            ClearField();
            SetModify(true);
        }

        private void ClearField()
        {
            txtABI.Text = "";
            txtBanca.Text = "";
            lblCodice.Text = "";
            txtCAB.Text = "";
            txtCC.Text = "";
            txtCIN.Text = "";
            txtIBAN.Text = "";
            txtSwift.Text = "";
        }

        private void SetModify(bool IsToModify)
        {
            // se IsToModify abilito le modifiche dei valori
            txtABI.ReadOnly = txtBanca.ReadOnly = txtCAB.ReadOnly = txtCC.ReadOnly = txtCIN.ReadOnly = txtIBAN.ReadOnly = txtSwift.ReadOnly = !IsToModify;
            bttDelete.Visible = bttModify.Visible = bttNew.Visible = bttEnd.Visible = !IsToModify;
            bttSave.Visible = bttAnnulla.Visible = IsToModify;
            lstValori.Enabled = !IsToModify;
        }

        private void lstValori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstValori.SelectedIndex > -1)
                ShowID(lstValori.SelectedIndex);
        }

        private void ShowID(int Index)
        {
            string strSql = "";

            IdSel = ((_dataItemCombo)lstValori.Items[Index]).Id;
            lblCodice.Text = IdSel.ToString();

            strSql = "Select " +
                          " banca_descrizione" +
                          ", banca_cin" +
                          ", banca_cab" +
                          ", banca_abi" +
                          ", banca_iban" +
                          ", banca_cc" +
                          ", banca_swift" +
                     " FROM Banca_azienda" +
                     " Where Id= " + IdSel.ToString();

            int idDbReader = clsDataBase.GetFreeDbReaderIndex();
            if (clsDataBase.ExecuteQuery(strSql, idDbReader))
            {
                if (clsDataBase.vetDbReader[idDbReader].Read())
                {
                    txtABI.Text = clsDataBase.GetStringValue("banca_abi", idDbReader);
                    txtBanca.Text = clsDataBase.GetStringValue("banca_descrizione", idDbReader);
                    txtCAB.Text = clsDataBase.GetStringValue("banca_cab", idDbReader);
                    txtCC.Text = clsDataBase.GetStringValue("banca_cc", idDbReader);
                    txtCIN.Text = clsDataBase.GetStringValue("banca_cin", idDbReader);
                    txtIBAN.Text = clsDataBase.GetStringValue("banca_iban", idDbReader);
                    txtSwift.Text = clsDataBase.GetStringValue("banca_swift", idDbReader);
                }
            }

            clsDataBase.CloseDataReader(idDbReader);
        }

        private void bttModify_Click(object sender, EventArgs e)
        {
            if (lblCodice.Text != "")
                SetModify(true);
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            if (lblCodice.Text != "")
            {
                if (MessageBox.Show("Eliminare il record selezionato ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (clsDataBase.DeleteItem(clsGlobal.ETypeTable.TT_BANCHE_AZ, Convert.ToInt32(lblCodice.Text)))
                    {
                        MessageBox.Show("Record Eliminato.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clsDataBase.PopolaListItem(lstValori, clsGlobal.ETypeTable.TT_BANCHE_AZ);
                    }
                }
            }
        }

        private void bttEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            string strSql = "";

            if (MessageBox.Show("Salvare le nuove impostazioni?", "Attenzione",
                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!VerificaCampi()) return;

                if (lblCodice.Text == "")
                {
                    strSql = "Insert into Banca_azienda (banca_abi, banca_descrizione, banca_cab, banca_cc, banca_cin, banca_iban, banca_swift) values (" +
                             " '" + txtABI.Text + "'" +
                             ", '" + txtBanca.Text + "'" +
                             ", '" + txtCAB.Text + "'" +
                             ", '" + txtCC.Text + "'" +
                             ", '" + txtCIN.Text + "'" +
                             ", '" + txtIBAN.Text + "'" +
                             ", '" + txtSwift.Text + "'" +
                             ")";
                }
                else
                {
                    strSql = "Update Banca_azienda Set" +
                                " banca_abi ='" + txtABI.Text + "'" +
                                ", banca_descrizione ='" + txtBanca.Text + "'" +
                                ", banca_cab ='" + txtCAB.Text + "'" +
                                ", banca_cc ='" + txtCC.Text + "'" +
                                ", banca_cin ='" + txtCIN.Text + "'" +
                                ", banca_iban ='" + txtIBAN.Text + "'" +
                                ", banca_swift ='" + txtSwift.Text + "'" +
                            " WHERE ID = " + lblCodice.Text;
                }

                if (clsDataBase.ExecuteNonQuery(strSql))
                {
                    if (lblCodice.Text == "")
                        IdSel = clsDataBase.GetLastId(clsGlobal.ETypeTable.TT_BANCHE_AZ);
                    
                    lstValori.Tag = IdSel;

                    if (IsInsertOnly)
                    {
                        SetModify(false);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Impostazioni salvate.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetModify(false);
                        clsDataBase.PopolaListItem(lstValori, clsGlobal.ETypeTable.TT_BANCHE_AZ);
                    }
                }
            }
        }

        private bool VerificaCampi()
        {
            bool bRetValue = true;
            string strErrore = "";
            string strSql = "";

            if (txtBanca.Text == "") strErrore += "Richiesto inserimento Denominazione Banca\n";

            if (strErrore == "")
            {
                if (txtIBAN.Text != "")
                {
                    strSql = "Select Count(*) from Banca_azienda where id<> " + IdSel.ToString() + " and banca_cancellato = 0 and banca_iban='" + txtIBAN.Text.Replace("'", "''") + "' ";
                    if ((int)clsDataBase.ExecuteScalar(strSql) > 0)
                        strErrore += "Codice IBAN già presente\n";
                }

                if (txtCC.Text != "")
                {
                    strSql = "Select Count(*) from Banca_azienda where id<> " + IdSel.ToString() + " and banca_cancellato = 0 and banca_abi='" + txtABI.Text.Replace("'", "''") + "' and banca_cab ='" + txtCAB.Text.Replace("'", "''") + "' and banca_cc ='" + txtCC.Text.Replace("'", "''") + "' ";
                    if ((int)clsDataBase.ExecuteScalar(strSql) > 0)
                        strErrore += "Codice ABI + CAB + C/C già presente\n";                    
                }
            }

            if (strErrore != "")
            {
                MessageBox.Show("Verificare i parametri inseriti:\n\n" + strErrore, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bRetValue = false;
            }

            return bRetValue;
        }

        private void bttAnnulla_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Annullare le modifiche", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (IsInsertOnly)
                {
                    SetModify(false);
                    IdSel = 0;
                    Close();
                    return;
                }

                //Devo riaggiornare i valori
                if (lblCodice.Text == "")
                {
                    if (lstValori.Items.Count > 0)
                    {
                        //lstValori.SelectedIndex = 1;
                        ClearField();
                    }
                }
                else
                {
                    ShowID(lstValori.SelectedIndex);
                }
                SetModify(false);
            }
        }

        private void txtCAB_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmBanche_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bttSave.Visible)
                e.Cancel = true;
        }


    }
}
