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
    public partial class frmModArticoli : Form
    {
        public Form frmParent;
        public int IdSel = 0;

        private bool bIsChange = false;

        public frmModArticoli()
        {
            InitializeComponent();
        }

        private void frmModArticoli_Load(object sender, EventArgs e)
        {
            if (!this.Modal && this.MdiParent != null)
                this.WindowState = FormWindowState.Maximized;

            if (IdSel > 0)
                LoadArticolo(IdSel);
            else
            {
                PopolaCombo();
                bttElimina.Enabled = false;
            }            
        }

        private void PopolaCombo()
        {
            clsDataBase.PopolaCombo(cmbCateg, clsGlobal.ETypeTable.TT_CATEGORIA);
            clsDataBase.PopolaCombo(cmbIVA, clsGlobal.ETypeTable.TT_IVA);
            clsDataBase.PopolaCombo(cmbUM, clsGlobal.ETypeTable.TT_UNIT_MISURA);
            
        }

        private void LoadArticolo(int IdSel)
        {
            string strSql = "Select * from articoli where ID = " + IdSel.ToString();
            if (clsDataBase.ExecuteQuery(strSql))
            {
                if (clsDataBase.vetDbReader[0].Read())
                {
                    txtCodice.Text = clsDataBase.GetStringValue("art_cod");
                    txtDescr.Text = clsDataBase.GetStringValue("art_descrizione");
                    cmbCateg.Tag = clsDataBase.GetIntValue("art_ID_categoria");
                    cmbUM.Tag = clsDataBase.GetIntValue("art_ID_um");
                    nudPrezzo.Value = clsDataBase.GetValutaValue("art_prezzo");
                    cmbIVA.Tag = clsDataBase.GetIntValue("art_ID_iva");
                }
            }
            
            clsDataBase.CloseDataReader();
            PopolaCombo();
        }

        private void ClearFields()
        {
            txtCodice.Text = "";
            txtDescr.Text = "";
            cmbCateg.Text = "";
            cmbUM.Text = "";
            nudPrezzo.Text = "";
            cmbIVA.Text = "";
        }

        private void bttEsci_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmModArticoli_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bIsChange)
            {
                if (MessageBox.Show("Chiudi senza salvare?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                    e.Cancel = true;
            }
        }

        private void frmModArticoli_Activated(object sender, EventArgs e)
        {
            PopolaCombo();
        }

        private void bttElimina_Click(object sender, EventArgs e)
        {
            string strSql = "";

            if (MessageBox.Show("Eliminare l'articolo selezionato ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                strSql = "Update Articoli set art_cancellato=1 where ID = " + IdSel.ToString();
                clsDataBase.ExecuteNonQuery(strSql);
                Close();
            }
        }

        private void bttAnnulla_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Annullare le modifiche effettuate ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (IdSel > 0)
                    LoadArticolo(IdSel);
                else
                    ClearFields();
            }
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            string strSql = "";
            
            if (MessageBox.Show("Salvare le modifiche apportate ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!VerificaCampi()) return;

                if (IdSel > 0)
                {
                    //Update
                    strSql = "Update articoli set " +
                    "art_cod = '" + txtCodice.Text + "', " +
                    "art_descrizione = '" + txtDescr.Text.Replace("'", "''") + "', " +
                    "art_ID_categoria = " + ((_dataItemCombo)cmbCateg.SelectedItem).Id.ToString() + ", " +
                    "art_ID_um = " + ((_dataItemCombo)cmbUM.SelectedItem).Id.ToString() + ", " +
                    "art_prezzo = " + nudPrezzo.Value.ToString().Replace(",", ".") + ", " +
                    "art_ID_iva = " + ((_dataItemCombo)cmbIVA.SelectedItem).Id.ToString() +
                    " Where id= " + IdSel.ToString();
                }
                else
                { 
                    //Insert
                    strSql = "Insert into articoli (art_cod, art_descrizione, art_ID_categoria, art_ID_um, art_prezzo, art_ID_iva) values (" +
                              "'" + txtCodice.Text + "', " +
                              "'" + txtDescr.Text + "', " +
                              ((_dataItemCombo)cmbCateg.SelectedItem).Id.ToString() + ", " +
                              ((_dataItemCombo)cmbUM.SelectedItem).Id.ToString() + ", " + 
                              nudPrezzo.Value.ToString().Replace(",",".") + "," +
                              ((_dataItemCombo)cmbIVA.SelectedItem).Id.ToString() + ")";
                }

                if (clsDataBase.ExecuteNonQuery(strSql))
                {
                    MessageBox.Show("Aggiornamento effettuato.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (IdSel == 0)
                        IdSel = clsDataBase.GetLastId(clsGlobal.ETypeTable.TT_ARTICOLI);
                    bIsChange = false;
                    bttEsci_Click(null, null);
                }
            }
        }

        private bool VerificaCampi()
        {
            bool bRetValue = true;
            string strErrore = "";

            if (txtCodice.Text == "") strErrore += "Richiesto inserimento Codice\n";
            if (txtDescr.Text == "")  strErrore += "Richiesto insserimento Descrizione\n";

            if (strErrore == "")
            {
                if ((int)clsDataBase.ExecuteScalar("Select count(*) from  Articoli where id <> " + IdSel.ToString() + " and art_cancellato=0 and upper(art_cod) ='" + txtCodice.Text.Trim().ToUpper() + "'") > 0)
                {
                    MessageBox.Show("Codice Articolo già presente.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    bRetValue = false;
                }
            }

            if (strErrore != "")
            {
                MessageBox.Show("Verificare i parametri inseriti:\n\n" + strErrore, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bRetValue = false;
            }

            return bRetValue;
        }

        private void cmbCateg_SelectedIndexChanged(object sender, EventArgs e)
        {
            bIsChange = true;
            cmbCateg.Tag = ((_dataItemCombo)cmbCateg.SelectedItem).Id;
        }

        private void bttTabCateg_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_CATEGORIA, cmbCateg);
        }

        private void bttTabUM_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_UNIT_MISURA, cmbUM);
        }

        private void bttTabIva_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_IVA, cmbIVA);
        }

        private void frmModArticoli_Shown(object sender, EventArgs e)
        {
            
        }

        private void frmModArticoli_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmParent != null)
            {
                frmParent.Show();
            }

        }

        private void txtCodice_TextChanged(object sender, EventArgs e)
        {
            bIsChange = true;
        }

        private void txtDescr_TextChanged(object sender, EventArgs e)
        {
            bIsChange = true;
        }

        private void cmbUM_SelectedIndexChanged(object sender, EventArgs e)
        {
            bIsChange = true;
        }

        private void nudPrezzo_ValueChanged(object sender, EventArgs e)
        {
            bIsChange = true;
        }

        private void cmbIVA_SelectedIndexChanged(object sender, EventArgs e)
        {
            bIsChange = true;
        }
    }
}
