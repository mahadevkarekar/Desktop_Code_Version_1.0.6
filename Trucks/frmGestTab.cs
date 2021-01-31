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
    public partial class frmGestTab : Form
    {       

        public clsGlobal.ETypeTable TypeTable;
        public int IdSel = 0;
        public bool IsInsertOnly = false;

        public frmGestTab()
        {
            InitializeComponent();
        }

        private void bttEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttNew_Click(object sender, EventArgs e)
        {
            ClearField();
            SetModify(true);
        }

        private void ClearField()
        {
            txtNote.Text = "";
            txtValore.Text = "";
            lblCodice.Text = "";
            nudValore.Value = 0;
      cmbEsenzione.SelectedIndex = -1;
        }

        private void SetModify(bool IsToModify)
        {
            // se IsToModify abilito le modifiche dei valori
            txtNote.ReadOnly = txtValore.ReadOnly = nudValore.ReadOnly = !IsToModify;
            nudValore.Enabled = IsToModify;
            bttDelete.Visible = bttModify.Visible = bttNew.Visible = bttEnd.Visible = !IsToModify;
            bttSave.Visible = bttAnnulla.Visible = IsToModify;
            rdbModPagBanca.Enabled = rdbModPagCassa.Enabled = IsToModify;
            lstValori.Enabled = !IsToModify;
      cmbEsenzione.Enabled = IsToModify;
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

        private void frmGestTab_Load(object sender, EventArgs e)
        {
            this.Text = clsGlobal.GetCaptionTabForm(TypeTable);
            if (!this.Modal)
                this.WindowState = FormWindowState.Maximized;

            cmbEsenzione.Visible = TypeTable == clsGlobal.ETypeTable.TT_IVA;

            switch (TypeTable)
            {
                case clsGlobal.ETypeTable.TT_IVA:
                    txtValore.Visible = false;
                    nudValore.Visible = true;
                    lvlPerc.Visible = true;
                    cmbEsenzione.Width = 400;

                    clsDataBase.PopolaCombo_2(cmbEsenzione, clsGlobal.ETypeTable.XML_NATURA);
                    break;
                case clsGlobal.ETypeTable.TT_MOD_PAGAMENTO:
                    txtValore.Visible = false;
                    rdbModPagBanca.Visible = rdbModPagCassa.Visible = true;
                    break;
                case clsGlobal.ETypeTable.TT_DESCR_BREVI:
                    txtValore.MaxLength = 30;
                    txtNote.MaxLength = 200;

                    label3.Text = "Nome Descrizione Breve:";
                    label5.Text = "Testo da Inserire in Fattura";

                    break;
                default:
                    break;
            }

            clsDataBase.PopolaListItem(lstValori, TypeTable);
            if (IsInsertOnly)
                bttNew_Click(null, null);


    }

    private void lstValori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstValori.SelectedIndex > -1)
                ShowID(lstValori.SelectedIndex);
        }

        private void ShowID(int Index)
        {
            IdSel = ((_dataItemCombo)lstValori.Items[Index]).Id;
            lblCodice.Text = IdSel.ToString();
            txtNote.Text = ((_dataItemCombo)lstValori.Items[Index]).Descrizione;
            switch (TypeTable)
            { 
                case clsGlobal.ETypeTable.TT_IVA:
                    nudValore.Value = Convert.ToDecimal(((_dataItemCombo)lstValori.Items[Index]).Value.Replace(".",","));
                    clsDataBase.SelezionaComboItem_2(cmbEsenzione, ((_dataItemCombo)lstValori.Items[Index]).Tag);
                    break;
                case clsGlobal.ETypeTable.TT_MOD_PAGAMENTO:
                    if (((_dataItemCombo)lstValori.Items[Index]).Value.ToString().Substring(0, 5) == "CASSA")
                        rdbModPagCassa.Checked = true;
                    else
                        rdbModPagBanca.Checked = true;
                    break;
                default:
                    txtValore.Text = ((_dataItemCombo)lstValori.Items[Index]).Value;
                    break;
            }

           
        }

        private bool VerificaCampi()
        {
            bool bRet = true;
            string strSql = "";

            switch (TypeTable)
            {
                case clsGlobal.ETypeTable.TT_IVA:
                    if ((nudValore.Value == 0) && (cmbEsenzione.SelectedIndex < 1))
                    {
                      MessageBox.Show("Richiesta tipologia esenzione.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                      bRet = false;
                    }

                    break;
                case clsGlobal.ETypeTable.TT_UNIT_MISURA:
                    break;
                case clsGlobal.ETypeTable.TT_CATEGORIA:
                    break;
                case clsGlobal.ETypeTable.TT_ASSICURAZIONI:
                    break;
                case clsGlobal.ETypeTable.TT_TIP_PAGAMENTO:
                    break;
                case clsGlobal.ETypeTable.TT_MOD_PAGAMENTO:
                    break;
                case clsGlobal.ETypeTable.TT_BANCHE_AZ:
                    break;
                case clsGlobal.ETypeTable.TT_DISTANZE:
                    break;
                case clsGlobal.ETypeTable.TT_LOCALITA:
                    if (lblCodice.Text == "")
                        strSql = "select count(*) from Localita where Loc_cancellato=0 and Loc_luogo='" + txtValore.Text.Replace("'", "''") + "'";
                    else
                        strSql = "select count(*) from Localita where id<>" + lblCodice.Text + " and Loc_cancellato=0 and Loc_luogo='" + txtValore.Text.Replace("'", "''") + "'";
                    if ((int)clsDataBase.ExecuteScalar(strSql) > 0)
                    {
                        MessageBox.Show("Località già presente.\nVerificare i parametri inseriti.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        bRet = false;
                    }
                    break;
                case clsGlobal.ETypeTable.TT_AUTOMEZZI:
                    break;
                case clsGlobal.ETypeTable.TT_ARTICOLI:
                    break;
                case clsGlobal.ETypeTable.TT_CLIENTI:
                    break;
                case clsGlobal.ETypeTable.TT_IVA_DESCR:
                    break;
                case clsGlobal.ETypeTable.TT_ARTICOLI_DESC_COD:
                    break;
                case clsGlobal.ETypeTable.TT_ESENZIONI:
                    break;
                case clsGlobal.ETypeTable.TT_DESCR_BREVI:
                    if ((txtValore.Text == "") || (txtNote.Text == ""))
                    {
                      MessageBox.Show("Richieste descrizione breve e descrizione.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                      bRet = false;
                    }

                    break;
                default:
                    break;
            }
            return bRet;
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            bool bRetValue = false;

            if (MessageBox.Show("Salvare le nuove impostazioni?", "Attenzione",
                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (VerificaCampi())
                {
                    if (lblCodice.Text == "")
                    {
                        switch (TypeTable)
                        {
                            case clsGlobal.ETypeTable.TT_IVA:
                                bRetValue = clsDataBase.SaveItemIva(nudValore.Value, txtNote.Text, ((cmbEsenzione.SelectedIndex >= 0) ? ((ComboboxItem)cmbEsenzione.SelectedItem).Value.ToString() : ""));
                                break;
                            case clsGlobal.ETypeTable.TT_MOD_PAGAMENTO:
                                if (rdbModPagCassa.Checked)
                                    bRetValue = clsDataBase.SaveItem(TypeTable, "1", txtNote.Text);
                                else
                                    bRetValue = clsDataBase.SaveItem(TypeTable, "0", txtNote.Text);
                                break;
                            default:
                                bRetValue = clsDataBase.SaveItem(TypeTable, txtValore.Text, txtNote.Text);
                                break;
                        }
                        if (bRetValue)
                        {
                            IdSel = clsDataBase.GetLastId(TypeTable);
                        }
                    }
                    else
                    {
                        switch (TypeTable)
                        {
                            case clsGlobal.ETypeTable.TT_IVA:
                                //bRetValue = clsDataBase.SaveItem(TypeTable, nudValore.Value.ToString(), txtNote.Text, Convert.ToInt32(lblCodice.Text));
                                bRetValue = clsDataBase.SaveItemIva(nudValore.Value, txtNote.Text, ((cmbEsenzione.SelectedIndex >= 0) ? ((ComboboxItem)cmbEsenzione.SelectedItem).Value.ToString() : ""), Convert.ToInt32(lblCodice.Text));
                                break;
                            case clsGlobal.ETypeTable.TT_MOD_PAGAMENTO:
                                if (rdbModPagCassa.Checked)
                                    bRetValue = clsDataBase.SaveItem(TypeTable, "1", txtNote.Text, Convert.ToInt32(lblCodice.Text));
                                else
                                    bRetValue = clsDataBase.SaveItem(TypeTable, "0", txtNote.Text, Convert.ToInt32(lblCodice.Text));
                                break;
                            default:
                                bRetValue = clsDataBase.SaveItem(TypeTable, txtValore.Text, txtNote.Text, Convert.ToInt32(lblCodice.Text));
                                break;
                        }
                        if (bRetValue)
                        {
                            IdSel = Convert.ToInt32(lblCodice.Text);
                        }
                    }
                }

                if (bRetValue)
                {   
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
                        clsDataBase.PopolaListItem(lstValori, TypeTable);
                    }
                }
            }
            
        }

        private void frmGestTab_Shown(object sender, EventArgs e)
        {
            
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            if (lblCodice.Text != "")
            {
                if (MessageBox.Show("Eliminare il record selezionato ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (clsDataBase.DeleteItem(TypeTable, Convert.ToInt32(lblCodice.Text)))
                    {
                        MessageBox.Show("Record Eliminato.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clsDataBase.PopolaListItem(lstValori, TypeTable);
                    }
                }
            }
        }

        private void bttModify_Click(object sender, EventArgs e)
        {
            if (lblCodice.Text != "")
                SetModify(true);
        }

        private void frmGestTab_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bttSave.Visible)
                e.Cancel = true;
        }

    private void nudValore_ValueChanged(object sender, EventArgs e)
    {
      cmbEsenzione.Visible = TypeTable == clsGlobal.ETypeTable.TT_IVA && nudValore.Value == 0;
    }

    private void cmbEsenzione_VisibleChanged(object sender, EventArgs e)
    {
      label4.Visible = cmbEsenzione.Visible;
    }
  }
}
