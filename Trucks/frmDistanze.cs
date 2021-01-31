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
    public partial class frmDistanze : Form
    {
        public int IdSel = 0;

        private int CurretIdLocB = 0;

        public frmDistanze()
        {
            InitializeComponent();
        }

        private void frmDistanze_Load(object sender, EventArgs e)
        {
            if (!this.Modal && this.MdiParent != null)
                this.WindowState = FormWindowState.Maximized;

            clsDataBase.PopolaListItem(lstValori, clsGlobal.ETypeTable.TT_DISTANZE);
            PopolaCombo();
        }

        private void lstValori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstValori.SelectedIndex > -1)
                ShowID(lstValori.SelectedIndex);
        }

        private void ShowID(int Index)
        {
            IdSel = ((_dataItemCombo)lstValori.Items[Index]).Id;
            string strSql = "Select d.ID, d.ID_localita_A, d.ID_localita_B, d.Dtt_distanze_note, Dtt_distanze_km, Id_Dtt_Distanze_Reverse From Dtt_distanze d Where ID = " + IdSel.ToString();

            if (clsDataBase.ExecuteQuery(strSql))
            {
                if (clsDataBase.vetDbReader[0].Read())
                {
                    txtCodice.Text = clsDataBase.GetIntValue("ID").ToString(); 
                    txtCodice.Tag = clsDataBase.GetIntValue("Id_Dtt_Distanze_Reverse");
                    cmbLocA.Tag = clsDataBase.GetIntValue("ID_localita_A");
                    cmbLocB.Tag = clsDataBase.GetIntValue("ID_localita_B");
                    CurretIdLocB = clsDataBase.GetIntValue("ID_localita_B");
                    nudKm.Value = clsDataBase.GetValutaValue("Dtt_distanze_km");
                    txtNote.Text = clsDataBase.GetStringValue("Dtt_distanze_note");

                    PopolaCombo();
                }
            }

            clsDataBase.CloseDataReader();
        }

        private void PopolaCombo()
        {
            clsDataBase.PopolaCombo(cmbLocA, clsGlobal.ETypeTable.TT_LOCALITA);
            //clsDataBase.PopolaCombo(cmbLocB, clsGlobal.ETypeTable.TT_LOCALITA);            
            PopolaComboLocB();
        }

        private void SetModify(bool IsToModify)
        {
            // se IsToModify abilito le modifiche dei valori
            txtNote.ReadOnly = nudKm.ReadOnly = !IsToModify;
            cmbLocA.Enabled = cmbLocB.Enabled = bttLocA.Enabled = bttLocB.Enabled = IsToModify;
             
            bttDelete.Visible = bttModify.Visible = bttNew.Visible = bttEnd.Visible = !IsToModify;
            bttSave.Visible = bttAnnulla.Visible = IsToModify;
            lstValori.Enabled = !IsToModify;
        }

        private void bttLocA_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_LOCALITA, cmbLocA);
        }

        private void bttLocB_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_LOCALITA, cmbLocB);
            PopolaComboLocB();
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            if (txtCodice.Text != "")
            {
                if (MessageBox.Show("Eliminare il record selezionato ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (clsDataBase.DeleteItem(clsGlobal.ETypeTable.TT_DISTANZE, Convert.ToInt32(txtCodice.Text)))
                    {
                        if (clsDataBase.DeleteItem(clsGlobal.ETypeTable.TT_DISTANZE, Convert.ToInt32(txtCodice.Tag)))
                        {
                            MessageBox.Show("Record Eliminato.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clsDataBase.PopolaListItem(lstValori, clsGlobal.ETypeTable.TT_DISTANZE);
                        }
                    }
                }
            }
        }

        private void bttNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            SetModify(true);
        }

        private void ClearFields()
        {
            txtNote.Text = "";
            cmbLocA.Tag = null;
            cmbLocB.Tag = null;
            cmbLocA.SelectedIndex = 0;
            cmbLocB.SelectedIndex = 0;
            txtCodice.Text = "";
            txtCodice.Tag = "";
            nudKm.Value = 0;
            CurretIdLocB = 0;
        }

        private void bttModify_Click(object sender, EventArgs e)
        {
            if (txtCodice.Text != "")
                SetModify(true);
        }

        private void bttAnnulla_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Annullare le modifiche", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                //Devo riaggiornare i valori
                if (txtCodice.Text == "")
                {
                    if (lstValori.Items.Count > 0)
                    {
                        //lstValori.SelectedIndex = 0;
                        ClearFields();
                    }
                }
                else
                {
                    ShowID(lstValori.SelectedIndex);
                }
                SetModify(false);
            }
        }

        private void bttEnd_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttSave_Click(object sender, EventArgs e)
        {           
            bool bRetValue = false;
            string strSql = "";
            int NewId=0;

            if (!VerificaCampi()) return;

            if (MessageBox.Show("Salvare le nuove impostazioni ?", "Attenzione",
                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtCodice.Text == "")
                {
                    //Insert
                    strSql = "Insert into Dtt_distanze (ID_localita_A, ID_localita_B, Dtt_distanze_km, Dtt_distanze_note, Id_Dtt_Distanze_Reverse) Values (" +
                                ((_dataItemCombo)cmbLocA.SelectedItem).Id.ToString() +
                                ", " + ((_dataItemCombo)cmbLocB.SelectedItem).Id.ToString() +
                                ", " + nudKm.Value.ToString().Replace(",", ".") +
                                ", '" + txtNote.Text.Replace("'", "''") + "'" +
                                ", 0" +
                                ")";

                    if (clsDataBase.ExecuteNonQuery(strSql))
                    {
                        NewId = Convert.ToInt32(clsDataBase.ExecuteScalar("Select Max(ID) from Dtt_distanze"));

                        strSql = "Insert into Dtt_distanze (ID_localita_B, ID_localita_A, Dtt_distanze_km, Dtt_distanze_note, Id_Dtt_Distanze_Reverse) Values (" +
                                    ((_dataItemCombo)cmbLocA.SelectedItem).Id.ToString() +
                                    ", " + ((_dataItemCombo)cmbLocB.SelectedItem).Id.ToString() +
                                    ", " + nudKm.Value.ToString().Replace(",", ".") +
                                    ", '" + txtNote.Text.Replace("'", "''") + "'" +
                                    ", " + NewId.ToString() + "" +
                                    ")";
                        if (clsDataBase.ExecuteNonQuery(strSql))
                        {
                            strSql = "Update Dtt_distanze set Id_Dtt_Distanze_Reverse = " + (NewId + 1).ToString() + " where id = " + NewId;
                            bRetValue = clsDataBase.ExecuteNonQuery(strSql);
                        }
                        IdSel = NewId;
                    }

                }
                else
                {
                    //Update
                    strSql = "Update Dtt_distanze set" +
                                " ID_localita_A = " + ((_dataItemCombo)cmbLocA.SelectedItem).Id.ToString() +
                                ", ID_localita_B = " + ((_dataItemCombo)cmbLocB.SelectedItem).Id.ToString() +
                                ", Dtt_distanze_km = " + nudKm.Value.ToString().Replace(",", ".") +
                                ", Dtt_distanze_note = '" + txtNote.Text.Replace("'", "''") + "'" +
                                " Where ID = " + txtCodice.Text;

                    if (clsDataBase.ExecuteNonQuery(strSql))
                    {
                        strSql = "Update Dtt_distanze set" +
                                    " ID_localita_B = " + ((_dataItemCombo)cmbLocA.SelectedItem).Id.ToString() +
                                    ", ID_localita_A = " + ((_dataItemCombo)cmbLocB.SelectedItem).Id.ToString() +
                                    ", Dtt_distanze_km = " + nudKm.Value.ToString().Replace(",", ".") +
                                    ", Dtt_distanze_note = '" + txtNote.Text.Replace("'", "''") + "'" +
                                    " Where ID = " + txtCodice.Tag;
                        
                        CurretIdLocB = ((_dataItemCombo)cmbLocB.SelectedItem).Id;
                           
                        bRetValue = clsDataBase.ExecuteNonQuery(strSql);
                    }
                }


                if (bRetValue)
                {
                    MessageBox.Show("Impostazioni salvate.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetModify(false);
                    clsDataBase.PopolaListItem(lstValori, clsGlobal.ETypeTable.TT_DISTANZE);
                }
            }
            
        }

        private bool VerificaCampi()
        { 
            bool bRetValue = true;
            string strErrore = "";

            if (cmbLocA.SelectedIndex < 1) strErrore += "Richiesta selezione Località di Partenza\n";
            if (cmbLocB.SelectedIndex < 1) strErrore += "Richiesta selezione Località di Destinazione\n";
            if (nudKm.Value == 0) strErrore += "Richiesto valore per Distanza\n";

            if (strErrore != "")
            {
                MessageBox.Show("Verificare i parametri inseriti:\n\n" + strErrore, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bRetValue = false;
            }
            return bRetValue;
        }

        private void frmDistanze_Shown(object sender, EventArgs e)
        {
           
        }

        private void cmbLocA_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopolaComboLocB();
        }

        private void PopolaComboLocB(int IdSelected=0)
        {
            if (cmbLocB.SelectedIndex > 0)
                cmbLocB.Tag = ((_dataItemCombo)cmbLocB.SelectedItem).Id;
            //else
            //    cmbLocB.Tag = null;

            if (IdSelected > 0)
                cmbLocB.Tag = IdSelected;
            else
                cmbLocB.Tag = CurretIdLocB;

            string strSql = "Select ID, Loc_luogo as Valore, Loc_descrizione as Descr From Localita Where Loc_cancellato = 0 and id <> " + ((_dataItemCombo)cmbLocA.SelectedItem).Id.ToString() + " and (ID = " + CurretIdLocB + " or not ID in (select ID_localita_B from Dtt_distanze where Dtt_distanze_cancellato=0 and ID_localita_a=" + ((_dataItemCombo)cmbLocA.SelectedItem).Id.ToString() + ")) order by Loc_luogo";
            clsDataBase.PopolaCombo(cmbLocB, strSql);
        }

        private void frmDistanze_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bttSave.Visible)
                e.Cancel = true;
        }
    }
}
