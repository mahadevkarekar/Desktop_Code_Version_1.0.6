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
    public partial class frmTipoPag : Form
    {
        public int IdSel = 0;
        public bool IsInsertOnly = false;

        private string strRifDataInizio = "Immediata";
        
        public frmTipoPag()
        {
            InitializeComponent();
        }

        private void bttNew_Click(object sender, EventArgs e)
        {
            ClearField();
            SetModify(true);
        }

        private void ClearField()
        {
            txtNote.Text = "";
            rdbStampAz.Checked = rdbImm.Checked = true;
            lblCodice.Text = "";

            dgvPagamenti.Rows.Clear();
        }

        private void SetModify(bool IsToModify)
        {
            // se IsToModify abilito le modifiche dei valori
            grpbDettaglio.Enabled = IsToModify;
            bttDelete.Visible = bttModify.Visible = bttNew.Visible = bttEnd.Visible = !IsToModify;
            bttSave.Visible = IsToModify;
            bttAnnulla.Visible = IsToModify;
            lstValori.Enabled = !IsToModify;        
        }

        private void bttModify_Click(object sender, EventArgs e)
        {
            if (lblCodice.Text != "")
                SetModify(true);
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

        private void ShowID(int Index)
        {
            string strSql = "";
            bool bRet = false;

            IdSel = ((_dataItemCombo)lstValori.Items[Index]).Id;
            lblCodice.Text = IdSel.ToString();

            strSql = "Select ID,Tipi_pagam_descr,Tipi_pagam_fine_mese,Tipi_pagam_data_fattura,Tipi_pagamento_immediato,tipi_pagam_stampa_cliente,tipi_pagam_stampa_az, Tipi_pagam_condizioni, Tipi_pagam_modalita from Tipi_pagamento Where Id = " + IdSel.ToString();
            int idReader = clsDataBase.GetFreeDbReaderIndex();
            if (clsDataBase.ExecuteQuery(strSql, idReader))
            {
                if (clsDataBase.vetDbReader[idReader].Read())
                {
                    txtNote.Text = clsDataBase.GetStringValue("Tipi_pagam_descr", idReader);
                    if (clsDataBase.GetBoolValue("Tipi_pagamento_immediato", idReader))
                        rdbImm.Checked = true;
                    if (clsDataBase.GetBoolValue("Tipi_pagam_data_fattura", idReader))
                        rdbDaFatt.Checked = true;
                    if (clsDataBase.GetBoolValue("Tipi_pagam_fine_mese", idReader))
                        rdbFineMese.Checked = true;

                    if (clsDataBase.GetBoolValue("tipi_pagam_stampa_cliente", idReader))
                        rdbStampaCl.Checked = true;
                    if (clsDataBase.GetBoolValue("tipi_pagam_stampa_az", idReader))
                        rdbStampAz.Checked = true;

                    clsDataBase.SelezionaComboItem_2(cmbCondPag, clsDataBase.GetStringValue("Tipi_pagam_condizioni", idReader));
                    clsDataBase.SelezionaComboItem_2(cmbModPag, clsDataBase.GetStringValue("Tipi_pagam_modalita", idReader));

                    bRet = true;
                }
            }

            clsDataBase.CloseDataReader(idReader);
            dgvPagamenti.Rows.Clear();

            if (!bRet) return;


            strSql = "Select ID,'" + strRifDataInizio + "',Dtt_tipi_pagamento_gg, Dtt_tipi_pagamento_percent from Dtt_Tipi_pagamento Where Dtt_tipi_pagamento_cancellato=0 and ID_Tipi_pagamento = " + IdSel.ToString();
            if (clsDataBase.ExecuteQuery(strSql, idReader))
            {
                while (clsDataBase.vetDbReader[idReader].Read())
                {
                    object[] newItem = new object[4];
                    clsDataBase.vetDbReader[idReader].GetSqlValues(newItem);
                    dgvPagamenti.Rows.Add(newItem);
                }
            }

            clsDataBase.CloseDataReader(idReader);

            foreach (DataGridViewRow objRow in dgvPagamenti.Rows)
            {
                objRow.ReadOnly = true;
            }

        }


        private void bttEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool VerificaCampi()
        {
            bool bRetValue = true;
            string strErrore = "";

            decimal Tot = 0;
            if (txtNote.Text == "") strErrore += "Richiesta Descrizione Modalità di Pagamento\n";

            if (cmbCondPag.SelectedIndex < 1) strErrore += "Richieste Condizioni di Pagamento\n";
            if (cmbModPag.SelectedIndex < 1) strErrore += "Richieste Modalità di Pagamento\n";

            if (!rdbImm.Checked)
            {
                foreach (DataGridViewRow objRow in dgvPagamenti.Rows)
                {
                    if (objRow.Visible)
                        Tot += Convert.ToDecimal(objRow.Cells["ColPercImp"].Value.ToString().Replace(".", ","));
                }

                if (Tot != 100) strErrore += "La somma dei valori per % Importo deve essere pari a 100\n";
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
            bool bRetValue = false;
            
            if (MessageBox.Show("Salvare le nuove impostazioni?", "Attenzione",
                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!VerificaCampi()) return;

                if (lblCodice.Text == "")
                    bRetValue = SaveNewItem();
                else
                    bRetValue = UpdateItem();
                
                if (bRetValue)
                {
                    if (lblCodice.Text == "")
                        IdSel = clsDataBase.GetLastId(clsGlobal.ETypeTable.TT_TIP_PAGAMENTO);
                    
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
                        clsDataBase.PopolaListItem(lstValori, clsGlobal.ETypeTable.TT_TIP_PAGAMENTO);
                    }
                }
            }
        }

        private bool UpdateItem()
        {
            bool bRet=true;
            
            string strSql = "Update Tipi_pagamento set " +
                                " Tipi_pagam_descr = '"+ txtNote.Text.Replace("'", "''") + "'" +
                                ", Tipi_pagam_fine_mese = " + Convert.ToInt32(rdbFineMese.Checked).ToString() +"" +
                                ", Tipi_pagam_data_fattura = " + Convert.ToInt32(rdbDaFatt.Checked).ToString() +
                                ", Tipi_pagamento_immediato = " + Convert.ToInt32(rdbImm.Checked).ToString() +
                                ", tipi_pagam_stampa_cliente = " + Convert.ToInt32(rdbStampaCl.Checked).ToString() +
                                ", tipi_pagam_stampa_az = " + Convert.ToInt32(rdbStampAz.Checked).ToString() +
                                ", Tipi_pagam_condizioni ='" + ((cmbCondPag.SelectedIndex >= 0) ? ((ComboboxItem)cmbCondPag.SelectedItem).Value : "") + "'" +
                                ", Tipi_pagam_modalita ='" + ((cmbModPag.SelectedIndex >= 0) ? ((ComboboxItem)cmbModPag.SelectedItem).Value : "") + "'" +
                                " Where Id = " + IdSel.ToString();

            bRet = clsDataBase.ExecuteNonQuery(strSql);

            int numRow = dgvPagamenti.Rows.Count;
            if (dgvPagamenti.AllowUserToAddRows) numRow -= 1;

            if (rdbImm.Checked)
            {
                //Un solo pagamento
                bool bSetFirstValue = false;
                for (int i = 0; i < numRow && bRet; i++)
                {
                    if (dgvPagamenti.Rows[i].Visible)
                    {
                        if (dgvPagamenti["ColId", i].Value != null)
                        {
                            if (!bSetFirstValue)
                            {
                                strSql = "Update Dtt_Tipi_pagamento set " +
                                    " Dtt_tipi_pagamento_gg = 0" +
                                    ", Dtt_tipi_pagamento_percent = 100.00" +
                                    " Where id=" + dgvPagamenti["ColId", i].Value.ToString();
                                bSetFirstValue = true;
                            }
                            else
                                strSql = "Update Dtt_Tipi_pagamento set " +
                                    " Dtt_tipi_pagamento_cancellato = 1" +
                                    " Where id=" + dgvPagamenti["ColId", i].Value.ToString();

                        }
                    }
                    else
                        strSql = "Update Dtt_Tipi_pagamento set " +
                            " Dtt_tipi_pagamento_cancellato = 1" +
                            " Where id=" + dgvPagamenti["ColId", i].Value.ToString();

                    bRet = clsDataBase.ExecuteNonQuery(strSql);
                }

                if (!bSetFirstValue)
                {
                    strSql = "Insert into Dtt_Tipi_pagamento (ID_Tipi_pagamento, Dtt_tipi_pagamento_gg, Dtt_tipi_pagamento_percent) Values (" +
                                IdSel.ToString() +
                                ", 0" +
                                ", 100.00" +
                                ")";
                    bRet = clsDataBase.ExecuteNonQuery(strSql);
                }
            }
            else
            {
                for (int i = 0; i < numRow && bRet; i++)
                {
                    if (dgvPagamenti.Rows[i].Visible)
                    {
                        if (dgvPagamenti["ColId", i].Value == null)
                            strSql = "Insert into Dtt_Tipi_pagamento (ID_Tipi_pagamento, Dtt_tipi_pagamento_gg, Dtt_tipi_pagamento_percent) Values (" +
                                IdSel.ToString() +
                                ", " + dgvPagamenti["ColGiorni", i].Value.ToString() +
                                ", " + dgvPagamenti["ColPercImp", i].Value.ToString().Replace(",", ".") +
                                ")";
                        else
                            strSql = "Update Dtt_Tipi_pagamento set " +
                                    " Dtt_tipi_pagamento_gg = " + dgvPagamenti["ColGiorni", i].Value.ToString() +
                                    ", Dtt_tipi_pagamento_percent =" + dgvPagamenti["ColPercImp", i].Value.ToString().Replace(",", ".") +
                                    " Where id=" + dgvPagamenti["ColId", i].Value.ToString();
                    }
                    else
                        strSql = "Update Dtt_Tipi_pagamento set " +
                            " Dtt_tipi_pagamento_cancellato = 1" +
                            " Where id=" + dgvPagamenti["ColId", i].Value.ToString();

                    bRet = clsDataBase.ExecuteNonQuery(strSql);
                }
            }
            return bRet;          
        }

        private bool SaveNewItem()
        {
            bool bRet = true;
            string strSql = "Insert into Tipi_pagamento (Tipi_pagam_descr, Tipi_pagam_fine_mese, Tipi_pagam_data_fattura, Tipi_pagamento_immediato, tipi_pagam_stampa_cliente, tipi_pagam_stampa_az, Tipi_pagam_condizioni, Tipi_pagam_modalita) Values (" +
                                " '" + txtNote.Text.Replace("'", "''") + "'" +
                                ", " + Convert.ToInt32(rdbFineMese.Checked).ToString() + "" +
                                ", " + Convert.ToInt32(rdbDaFatt.Checked).ToString() +
                                ", " + Convert.ToInt32(rdbImm.Checked).ToString() +
                                ", " + Convert.ToInt32(rdbStampaCl.Checked).ToString() +
                                ", " + Convert.ToInt32(rdbStampAz.Checked).ToString() +
                                ", '" + ((cmbCondPag.SelectedIndex >= 0) ? ((ComboboxItem)cmbCondPag.SelectedItem).Value : "") + "'" +
                                ", '" + ((cmbModPag.SelectedIndex >= 0) ? ((ComboboxItem)cmbModPag.SelectedItem).Value : "") + "'" +
                                ")";

            bRet = clsDataBase.ExecuteNonQuery(strSql);
            if (bRet)
                IdSel = (int)clsDataBase.ExecuteScalar("Select max(id) from Tipi_pagamento");

            if (rdbImm.Checked)
            {
                strSql = "Insert into Dtt_Tipi_pagamento (ID_Tipi_pagamento, Dtt_tipi_pagamento_gg, Dtt_tipi_pagamento_percent) Values (" +
                            IdSel.ToString() +
                            ", 0" +
                            ", 100.00" +
                            ")";
                bRet = clsDataBase.ExecuteNonQuery(strSql);
            }
            else
            {
                int numRow = dgvPagamenti.Rows.Count;
                if (dgvPagamenti.AllowUserToAddRows) numRow -= 1;

                for (int i = 0; i < numRow && bRet; i++)
                {
                    strSql = "Insert into Dtt_Tipi_pagamento (ID_Tipi_pagamento, Dtt_tipi_pagamento_gg, Dtt_tipi_pagamento_percent) Values (" +
                            IdSel.ToString() +
                            ", " + dgvPagamenti["ColGiorni", i].Value.ToString() +
                            ", " + dgvPagamenti["ColPercImp", i].Value.ToString().Replace(",", ".") +
                            ")";
                    bRet = clsDataBase.ExecuteNonQuery(strSql);
                }
            }
            return bRet;
        }

        private void rdbImm_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbImm.Checked)
            {
                strRifDataInizio = "Immediata";
                //ChangeDataRifToItemPag();
                grpbRipPag.Enabled = dgvPagamenti.Enabled = false;
            }
            else
                grpbRipPag.Enabled = dgvPagamenti.Enabled = true;
        }

        private void rdbDaFatt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDaFatt.Checked)
            {
                strRifDataInizio = "Data Fattura";
                ChangeDataRifToItemPag();
            }
        }

        private void rdbFineMese_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFineMese.Checked)
            {
                strRifDataInizio = "Fine Mese";
                ChangeDataRifToItemPag();
            }
        }

        private void ChangeDataRifToItemPag()
        {
            foreach (DataGridViewRow objRow in dgvPagamenti.Rows)
            {
                objRow.Cells["ColDataRif"].Value = strRifDataInizio;
            }
        }

        private void frmTipoPag_Load(object sender, EventArgs e)
        {
            if (!this.Modal)
                this.WindowState = FormWindowState.Maximized;

            clsDataBase.PopolaCombo_2(cmbCondPag, clsGlobal.ETypeTable.XML_COND_PAGAMENTO);
            clsDataBase.PopolaCombo_2(cmbModPag, clsGlobal.ETypeTable.XML_MOD_PAGAMENTO);

            clsDataBase.PopolaListItem(lstValori, clsGlobal.ETypeTable.TT_TIP_PAGAMENTO);
            if (IsInsertOnly)
                bttNew_Click(null, null);
        }

        private void lstValori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstValori.SelectedIndex >-1)
                ShowID(lstValori.SelectedIndex);
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            string strSql = "";

            if (lblCodice.Text != "")
            {
                if (MessageBox.Show("Eliminare il record selezionato ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    strSql = "Update Tipi_pagamento set " +
                                " Tipi_pagam_cancellato = 1" +
                                " where ID = " + lblCodice.Text;
                    if (clsDataBase.ExecuteNonQuery(strSql))
                    {
                        strSql = "Update Dtt_Tipi_pagamento set " +
                                " Dtt_tipi_pagamento_cancellato = 1" +
                                " where ID_Tipi_pagamento = " + lblCodice.Text;
                        if (clsDataBase.ExecuteNonQuery(strSql))
                        {
                            MessageBox.Show("Record Eliminato.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clsDataBase.PopolaListItem(lstValori, clsGlobal.ETypeTable.TT_TIP_PAGAMENTO);
                        }
                    }
                }
            }
        }

        private void bttPagNew_Click(object sender, EventArgs e)
        {
            decimal DefaultPercImp = 100;

            foreach (DataGridViewRow objRow in dgvPagamenti.Rows)
            {
                if (objRow.Cells["ColPercImp"].Value != null && objRow.Visible)
                    DefaultPercImp -= Convert.ToDecimal(objRow.Cells["ColPercImp"].Value.ToString().Replace(".",","));
            }

            //dgvPagamenti.AllowUserToAddRows = true;
            dgvPagamenti.Rows.Add(1);
            dgvPagamenti["ColDataRif", dgvPagamenti.Rows.Count - 1].Value = strRifDataInizio;
            dgvPagamenti["ColGiorni", dgvPagamenti.Rows.Count - 1].Value = "0";
            dgvPagamenti["ColPercImp", dgvPagamenti.Rows.Count - 1].Value = DefaultPercImp;

            SetChangeItemPag(dgvPagamenti.Rows.Count - 1, true);
        }

        private void SetChangeItemPag(int RowIndex, bool IsToModify)
        { 
            if (IsToModify)
            {
                dgvPagamenti.CurrentCell = dgvPagamenti["ColGiorni", RowIndex];
                //dgvPagamenti["ColPercImp", RowIndex].Value = dgvPagamenti["ColPercImp", RowIndex].Value.ToString().Replace(".", ","); 
                dgvPagamenti.Rows[RowIndex].ReadOnly = false;
                dgvPagamenti.CurrentRow.DefaultCellStyle.BackColor= Color.Salmon; 
            }
            else
            {
                dgvPagamenti.CurrentRow.ReadOnly = true;
                dgvPagamenti.CurrentRow.DefaultCellStyle.BackColor = SystemColors.Window;
            }
        
        }

        private void bttPagMod_Click(object sender, EventArgs e)
        {
            if (dgvPagamenti.CurrentRow != null)
                SetChangeItemPag(dgvPagamenti.CurrentRow.Index, true);
        }

        private void bttPagDelete_Click(object sender, EventArgs e)
        {
            if (dgvPagamenti.CurrentRow != null)
            {
                if (MessageBox.Show("Eliminare il pagamento selezionato ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    if (lblCodice.Text != "")
                        dgvPagamenti.CurrentRow.Visible = false;
                    else
                        dgvPagamenti.Rows.RemoveAt(dgvPagamenti.CurrentRow.Index);
            }
        }

        private void dgvPagamenti_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPagamenti.Rows[e.RowIndex].ReadOnly == false)
            {
                SetChangeItemPag(e.RowIndex, false);
                //Verifico parametri riga
                //dgvPagamenti["ColGiorni", e.RowIndex].Value = Convert.ToInt32(dgvPagamenti["ColGiorni", e.RowIndex].Value.ToString());
                //dgvPagamenti["ColPercImp", e.RowIndex].Value = Convert.ToDecimal(dgvPagamenti["ColPercImp", e.RowIndex].Value.ToString().Replace(",", "."));                    
            }
        }

        private void dgvPagamenti_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (dgvPagamenti.CurrentCell.ColumnIndex)
            {
                case 2: //Num Giorni
                    e.Handled = !clsGlobal.IsNumber(e.KeyChar);
                    break;
                case 3: //Percentuale importo
                    e.Handled = !clsGlobal.IsDecimal(e.KeyChar);
                    if (!e.Handled)
                        e.Handled = (e.KeyChar == '.' && ((System.Windows.Forms.DataGridViewTextBoxEditingControl)sender).Text.IndexOf(".") > -1);
                    break;
                default:
                    break;
            }            

        }

        private void frmTipoPag_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bttSave.Visible)
                e.Cancel = true;
            else
                e.Cancel = false;
        }
    }
}
