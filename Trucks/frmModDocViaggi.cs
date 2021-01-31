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
    public partial class frmModDocViaggi : Form
    {
        public int IdSel = 0;
        public bool IsChange = false;
        public Form frmParent = null;
        public bool IsInsertDettFatt = false;
        public clsGlobal._DettFat DettFatt;
        private bool inload = true;
        private bool IsModify = false;

        public frmModDocViaggi()
        {
            InitializeComponent();
        }

        private void frmModDocViaggi_Load(object sender, EventArgs e)
        {
            if (!this.Modal && this.MdiParent != null)
                this.WindowState = FormWindowState.Maximized;

            if (IsInsertDettFatt)
            {
                //LoadInfoDettFatt();  
                txtNote.Enabled = false;
            }
            else
            {
                if (IdSel > 0)
                    LoadViaggio(IdSel);
                else
                {
                    bttElimina.Enabled = false;
                    PopolaCombo();
                }
            }
            inload = false;
        }


        public void LoadInfoDettFatt(clsGlobal._DettFat DettFattValue)
        {
            bttElimina.Visible = bttAnnulla.Visible = bttSave.Visible = false;
            bttInserDettFatt.Visible = true;
            cmbCliente.Enabled = false;

            this.Text = "Dettaglio Fattura";

            cmbCliente.Tag = DettFattValue.Id_Cliente;
            cmbAut.Tag = null;
            cmbPercorso.Tag = null;
            //cmbCodArt.Tag = DettFattValue.CodArticolo;
            cmbIva.Tag = DettFattValue.IdIva;
            clsDataBase.PopolaCombo(cmbUm, clsGlobal.ETypeTable.TT_UNIT_MISURA);
            PopolaCombo();
            cmbCliente.Enabled = false;

            if (DettFattValue.Data == DateTime.MinValue)
                dtpData.Checked = false;
            else
            {
                dtpData.Checked = true;
                dtpData.Value = DettFattValue.Data;
            }

            txtDDT.Text = DettFattValue.DDT;
            txtDescr.Text = DettFattValue.Descr;
            nudQuant.Value = DettFattValue.Qta;
            nudPrezzo.Value = DettFattValue.Prezzo;
            //lblTotale.Text = "";

            txtNote.Text = "";
            
            cmbAut.Text = DettFattValue.Truck;
            cmbCodArt.Text = DettFattValue.CodArticolo + " - " + DettFattValue.Descr;
            inload = false;
            cmbPercorso.Text = DettFattValue.Tratta.Trim();
            cmbUm.Text = DettFattValue.Um;
            nudIVA.Value = DettFattValue.IVA;
            lblKM.Text = DettFattValue.KM.ToString();

            if (DettFattValue.ID_Viaggio > 0)
            {
                IdSel = DettFattValue.ID_Viaggio;
            }
        }

        private void PopolaCombo()
        {
            clsDataBase.PopolaCombo(cmbPercorso, clsGlobal.ETypeTable.TT_DISTANZE);
            clsDataBase.PopolaCombo(cmbAut, clsGlobal.ETypeTable.TT_AUTOMEZZI);            
            clsDataBase.PopolaCombo(cmbIva, clsGlobal.ETypeTable.TT_IVA_DESCR);
            
            clsDataBase.PopolaCombo(cmbCliente, clsGlobal.ETypeTable.TT_CLIENTI);
            clsDataBase.PopolaCombo(cmbCodArt, clsGlobal.ETypeTable.TT_ARTICOLI_DESC_COD);
        }

        private void LoadViaggio(int Index)
        {
            
            clsDataBase.PopolaCombo(cmbUm, clsGlobal.ETypeTable.TT_UNIT_MISURA);
            string strSql = "Select ID,ID_cliente,ID_articoli,ID_ddt_distanze,ID_truck,viaggi_ddt_n,viaggi_ddt_data,viaggi_descrizione,viaggio_qta,viaggi_um,viaggi_prezzo_u,viaggi_percent_iva,viaggi_note from Viaggi Where viaggi_cancellato=0 and ID = " + Index.ToString();

            if (clsDataBase.ExecuteQuery(strSql))
            {
                if (clsDataBase.vetDbReader[0].Read())
                {
                    if (clsDataBase.GetDateValue("viaggi_ddt_data") == DateTime.MinValue)
                        dtpData.Checked = false;
                    else
                    {
                        dtpData.Value = clsDataBase.GetDateValue("viaggi_ddt_data");
                        dtpData.Checked = true;
                    }
                    txtDDT.Text = clsDataBase.GetStringValue("viaggi_ddt_n");

                    cmbAut.Tag = clsDataBase.GetIntValue("ID_truck");
                    cmbCliente.Tag = clsDataBase.GetIntValue("ID_cliente");

                    cmbCodArt.Tag = clsDataBase.GetIntValue("ID_articoli");
                   
                    txtDescr.Text = clsDataBase.GetStringValue("viaggi_descrizione");

                    cmbPercorso.Tag = clsDataBase.GetIntValue("ID_ddt_distanze");
                    cmbUm.Text = clsDataBase.GetStringValue("viaggi_um");

                    nudQuant.Value = clsDataBase.GetValutaValue("viaggio_qta");
                    nudPrezzo.Value = clsDataBase.GetValutaValue("viaggi_prezzo_u");

                    cmbIva.Tag = null;
                    nudIVA.Value = clsDataBase.GetValutaValue("viaggi_percent_iva");
                    nudIVA.Tag = nudIVA.Value; 
                    txtNote.Text = clsDataBase.GetStringValue("viaggi_note");

                    CalcolaImporti();
                }
                else
                {
                    MessageBox.Show("Nessuna corrispondenza trovata nel DB per il record selezionato.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                }

            }
            clsDataBase.CloseDataReader();
            PopolaCombo();
            nudIVA.Value = (decimal)nudIVA.Tag;


        }

        private bool VerificaCampi()
        {
            bool bRetValue = true;
            string strErrore = "";

            if (!dtpData.Checked) strErrore += "Richiesta la selezione della Data\n";
            if (cmbCliente.SelectedIndex < 1) strErrore += "Richiesta la selezione del Cliente\n";
            if (cmbPercorso.SelectedIndex < 1) strErrore += "Richiesta la selezione del Percorso\n";
            if (cmbCodArt.SelectedIndex < 1) strErrore += "Richiesta la selezione del Codice Articolo\n";
            if (nudQuant.Value == 0) strErrore += "Richiesta Quantità\n";

            // Verifica esenzione IVA
            if (nudIVA.Value == 0)
            {
              if (cmbIva.SelectedIndex < 1)
              {
                strErrore += "Richiesta tipologia IVA\n";
              }
              else
              {
                if (((_dataItemCombo)(cmbIva.SelectedItem)).Tag == "")
                {
                  strErrore += "Richiesta tipologia esenzione IVA: modificare voce IVA in menu Tabelle\n";
                }
              }
            }

            if (strErrore != "")
            {
                MessageBox.Show("Verificare i parametri inseriti:\n\n" + strErrore, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bRetValue = false;
            }
            else
            {
                //string strSql = "Select Count(*) from Viaggi where id<> " + IdSel.ToString() + " and viaggi_cancellato = 0 and ID_ddt_distanze = " + ((_dataItemCombo)cmbPercorso.SelectedItem).Id.ToString() + " and viaggi_ddt_data = " + clsDataBase.SQL_ConvertDateTimeToData(dtpData.Value) + " and viaggio_qta = " + nudQuant.Value.ToString().Replace(",", ".") + " and  ID_articoli = " + ((_dataItemCombo)cmbCodArt.SelectedItem).Id.ToString() + " and ID_cliente = " + ((_dataItemCombo)cmbCliente.SelectedItem).Id.ToString();
                string strSql = "Select Count(*) from Viaggi where id<> " + IdSel.ToString() + " and viaggi_cancellato = 0 and ID_ddt_distanze = " + ((_dataItemCombo)cmbPercorso.SelectedItem).Id.ToString() + " and viaggi_ddt_data = " + clsDataBase.SQL_ConvertDateTimeToData(dtpData.Value) + " and ID_cliente = " + ((_dataItemCombo)cmbCliente.SelectedItem).Id.ToString() + " and viaggi_ddt_n = '" + txtDDT.Text.Replace("'","''") + "'";
                if ((int)clsDataBase.ExecuteScalar(strSql) > 0)
                    if (MessageBox.Show ("Possibile viaggio duplicato. Procedere?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)!= System.Windows.Forms.DialogResult.Yes)
                        bRetValue = false;
            }

            return bRetValue;
        }

        private bool VerificaCampiDettFatt()
        {
            bool bRetValue = true;
            string strErrore = "";
            //string strSql = "";

            if (txtDescr.Text == "" ) strErrore += "Richiesta Descrizione\n";
            if (nudQuant.Value == 0) strErrore += "Richiesta Quantità\n";

            // Verifica esenzione IVA
            if (nudIVA.Value == 0)
            {
              if (cmbIva.SelectedIndex < 1)
              {
                strErrore += "Richiesta tipologia IVA\n";
              }
              else
              {
                if (((_dataItemCombo)(cmbIva.SelectedItem)).Tag == "")
                {
                  strErrore += "Richiesta tipologia esenzione IVA: modificare voce IVA in anagrafica\n";
                }
              }
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
                strSql = "Update Viaggi set " +
                              " ID_cliente = " + ((_dataItemCombo)cmbCliente.SelectedItem).Id + "" +
                              ", ID_articoli = " + ((_dataItemCombo)cmbCodArt.SelectedItem).Id + "" +
                              ", ID_ddt_distanze = " + ((_dataItemCombo)cmbPercorso.SelectedItem).Id + "" +
                              ", ID_truck = " + ((_dataItemCombo)cmbAut.SelectedItem).Id + "" +
                              ", viaggi_ddt_n = '" + txtDDT.Text.Replace("'", "''") + "'" +
                              ", viaggi_ddt_data = " + clsDataBase.SQL_ConvertDateTimeToData(dtpData) + "" +
                              ", viaggi_descrizione = '" + txtDescr.Text.Replace("'", "''")  + "'" +
                              ", viaggio_qta = " + nudQuant.Value.ToString().Replace(",",".") + "" +
                              ", viaggi_um = '" + cmbUm.Text.Replace("'", "''") + "'" +
                              ", viaggi_prezzo_u = " + nudPrezzo.Value.ToString().Replace(",",".") + "" +
                              ", viaggi_percent_iva = " + nudIVA.Value.ToString().Replace(",", ".")  + "" +
                              ", viaggi_note = '" + txtNote.Text.Replace("'", "''")  + "'" +
                              ", viaggi_id_iva = " + (cmbIva.SelectedIndex > 0 ? ((_dataItemCombo)cmbIva.SelectedItem).Id.ToString() : "-1") + "" +

                              " where Id= " + IdSel.ToString();
            }
            else
            {
                // Devo effettuare inserimento
                strSql = "Insert into Viaggi (ID_cliente,ID_articoli,ID_ddt_distanze,ID_truck,viaggi_ddt_n,viaggi_ddt_data,viaggi_descrizione,viaggio_qta,viaggi_um,viaggi_prezzo_u,viaggi_percent_iva,viaggi_note, viaggi_id_iva) values (" +
                              "" + ((_dataItemCombo)cmbCliente.SelectedItem).Id + "" +
                              ", " + ((_dataItemCombo)cmbCodArt.SelectedItem).Id + "" +
                              ", " + ((_dataItemCombo)cmbPercorso.SelectedItem).Id + "" +
                              ", " + ((_dataItemCombo)cmbAut.SelectedItem).Id + "" +
                              ", '" + txtDDT.Text.Replace("'", "''") + "'" +
                              ", " + clsDataBase.SQL_ConvertDateTimeToData(dtpData) + "" +
                              ", '" + txtDescr.Text.Replace("'", "''") + "'" +
                              ", " + nudQuant.Value.ToString().Replace(",", ".") + "" +
                              ", '" + cmbUm.Text.Replace("'", "''") + "'" +
                              ", " + nudPrezzo.Value.ToString().Replace(",", ".") + "" +
                              ", " + nudIVA.Value.ToString().Replace(",", ".") + "" +
                              ", '" + txtNote.Text.Replace("'", "''") + "'" +
                              ", " + (cmbIva.SelectedIndex > 0 ? ((_dataItemCombo)cmbIva.SelectedItem).Id.ToString() : "-1") + "" +
                              ")";
            }

            if (clsDataBase.ExecuteNonQuery(strSql))
            {
                IsChange = true;
                IsModify = false;

                if (IdSel < 1)
                    IdSel = (int)clsDataBase.ExecuteScalar("Select max(id) from Viaggi");

                MessageBox.Show("Aggiornamento effettuato.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        private void bttElimina_Click(object sender, EventArgs e)
        {
            if (IdSel > 0)
            {
                if (MessageBox.Show("Eliminare il viaggio selezionato ?.", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string strSql = "Update Viaggi set " +
                                        " viaggi_cancellato = 1" +
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
                    LoadViaggio(IdSel);
                else
                    ClearFields();
            }
        }

        private void ClearFields()
        {
            dtpData.Checked = false;
            txtDDT.Text = "";

            cmbAut.Tag = null;
            cmbCliente.Tag = null;

            cmbCodArt.Tag = null;
            txtDescr.Text = "";

            cmbPercorso.Tag = null;
            cmbUm.Text = "";

            nudQuant.Value = 0;
            nudPrezzo.Value = 0;
            lblTotale.Text = "";

            cmbIva.Text = "";
            cmbIva.Tag = null;
            nudIVA.Value = 0;
            lblImportoIva.Text = "";

            txtNote.Text = "";
            PopolaCombo();
        }

        private void bttEsci_Click(object sender, EventArgs e)
        {            
            Close();
        }

        private void frmModDocViaggi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsModify)
            {
                if (MessageBox.Show("I valori sono stati modificati senza salvare.\n\nUscire senza salvare?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = true;                   
                }
            } 
        }

        private void cmbCodArt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCodArt.SelectedIndex > 0)
            {
                if (!inload)
                {
                    IsModify = true;
                    LoadInfoArticolo(((_dataItemCombo)cmbCodArt.SelectedItem).Id);
                }
            }
        }

        private void LoadInfoArticolo(int Index)
        {
            string strSql = "Select a.art_cod, a.art_descrizione, a.art_prezzo, a.art_ID_categoria, a.art_ID_iva, a.art_ID_um, i.Iva, um.Um" +
                            " From Articoli a" +
                            " left join IVA i on a.art_ID_iva = i.ID" +
                            " left join UM um on a.art_ID_um = um.ID" +
                            " Where a.id = " + Index.ToString();

            if (clsDataBase.ExecuteQuery(strSql, 1))
            {
                if (clsDataBase.vetDbReader[1].Read())
                {
                    nudPrezzo.Value = clsDataBase.GetValutaValue("art_prezzo",1);
                    cmbIva.Tag = clsDataBase.GetIntValue("art_ID_iva",1);
                    clsDataBase.PopolaCombo(cmbIva, clsGlobal.ETypeTable.TT_IVA_DESCR);
                    cmbUm.Text = clsDataBase.GetStringValue("Um",1);
                    txtDescr.Text = clsDataBase.GetStringValue("art_descrizione", 1);
                }
            }
            clsDataBase.CloseDataReader(1);
      
        }

        private void nudQuant_ValueChanged(object sender, EventArgs e)
        {
            IsModify = true;
            CalcolaImporti();
        }

        private void CalcolaImporti()
        {
            lblTotale.Text = Math.Round(nudPrezzo.Value * nudQuant.Value, 2).ToString();
            if (nudIVA.Value > 0)
                //lblImportoIva.Text = Math.Round(((nudPrezzo.Value * nudQuant.Value) * nudIVA.Value) / (100 + nudIVA.Value), 2).ToString();
                lblImportoIva.Text = Math.Round(((nudPrezzo.Value * nudQuant.Value) * nudIVA.Value) /100, 2).ToString();
            else
                lblImportoIva.Text = "0" ;

            lblTotLordo.Text = Math.Round(Convert.ToDecimal(lblTotale.Text) + Convert.ToDecimal(lblImportoIva.Text), 2).ToString();
        }

        private void cmbIva_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsModify = true;

            if (cmbIva.SelectedIndex > 0)
            {
                nudIVA.Value = Convert.ToDecimal(((_dataItemCombo)cmbIva.SelectedItem).Descrizione.Replace(".",","));
                //nudIVA.ReadOnly = true;
            }
            //else
                //nudIVA.ReadOnly = false;            
        }

        private void nudPrezzo_ValueChanged(object sender, EventArgs e)
        {
            IsModify = true;
            CalcolaImporti();
        }

        private void cmbPercorso_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsModify = true;
            if (cmbPercorso.SelectedIndex > 0)
                lblKM.Text = ((_dataItemCombo)cmbPercorso.SelectedItem).Descrizione;
            else
                lblKM.Text = "";
        }

        private void bttNewDist_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_DISTANZE, cmbPercorso);
        }

        private void cmbIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !clsGlobal.IsNumber(e.KeyChar);
        }

        private void nudIVA_ValueChanged(object sender, EventArgs e)
        {
            IsModify = true;
            CalcolaImporti();
        }

        private void frmModDocViaggi_Shown(object sender, EventArgs e)
        {
            
        }

        private void obj_ValueChanged(object sender, EventArgs e)
        {
            IsModify = true;
        }

        private void bttInserDettFatt_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Inserire in fattura i nuovi parametri ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (VerificaCampiDettFatt())
                {
                    if (dtpData.Checked)
                        DettFatt.Data = dtpData.Value;
                    else
                        DettFatt.Data = DateTime.MinValue;

                    DettFatt.DDT = txtDDT.Text;
                    DettFatt.Descr = txtDescr.Text;

                    DettFatt.Qta = nudQuant.Value;
                    DettFatt.Prezzo = nudPrezzo.Value;
                    //lblTotale.Text = "";

                    DettFatt.Truck = cmbAut.Text;
                    if (cmbCodArt.Text != "")
                        DettFatt.CodArticolo = cmbCodArt.Text.Substring(0, cmbCodArt.Text.IndexOf(" - "));
                    else
                        DettFatt.CodArticolo = "";

                    DettFatt.Tratta = cmbPercorso.Text;
                    DettFatt.Um = cmbUm.Text;
                    DettFatt.IVA = nudIVA.Value ;
                    if (lblKM.Text != "")
                        DettFatt.KM = Convert.ToDecimal(lblKM.Text.Replace(".",","));
                    else
                        DettFatt.KM = 0;

          if (cmbIva.SelectedIndex < 0)
            DettFatt.IdIva = -1;
          else
            DettFatt.IdIva = ((_dataItemCombo)cmbIva.SelectedItem).Id;

                    if (IdSel > 0)
                    {
                        if (MessageBox.Show("Modificare anche i dati del viaggio ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {

                            string strSql = "";

                            
                            if (!VerificaCampi()) return;
                            // Devo Effettuare Update
                            strSql = "Update Viaggi set " +
                                     " ID_cliente = " + ((_dataItemCombo)cmbCliente.SelectedItem).Id + "" +
                                     ", ID_articoli = " + ((_dataItemCombo)cmbCodArt.SelectedItem).Id + "" +
                                     ", ID_ddt_distanze = " + ((_dataItemCombo)cmbPercorso.SelectedItem).Id + "" +
                                     ", ID_truck = " + ((_dataItemCombo)cmbAut.SelectedItem).Id + "" +
                                     ", viaggi_ddt_n = '" + txtDDT.Text.Replace("'", "''") + "'" +
                                    ", viaggi_ddt_data = " + clsDataBase.SQL_ConvertDateTimeToData(dtpData) + "" +
                                    ", viaggi_descrizione = '" + txtDescr.Text.Replace("'", "''") + "'" +
                                    ", viaggio_qta = " + nudQuant.Value.ToString().Replace(",", ".") + "" +
                                    ", viaggi_um = '" + cmbUm.Text.Replace("'", "''") + "'" +
                                    ", viaggi_prezzo_u = " + nudPrezzo.Value.ToString().Replace(",", ".") + "" +
                                    ", viaggi_percent_iva = " + nudIVA.Value.ToString().Replace(",", ".") + "" +
                                    ", viaggi_note = '" + txtNote.Text.Replace("'", "''") + "'" +
                                    ", viaggi_id_iva = " + DettFatt.IdIva + "" +
                                    " where Id= " + IdSel.ToString();
                            if (clsDataBase.ExecuteNonQuery(strSql))
                            {
                                IsChange = true;
                                IsModify = false;

                                MessageBox.Show("Aggiornamento viaggio effettuato.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }    
                            
                    }      
                             
                    IsChange = true;
                    IsModify = false;
                    this.Close();
                }
            }
        }

        private void frmModDocViaggi_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmParent != null)
            {
                frmParent.Show();
            }
        }

        private void bttTabAutomezzo_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_AUTOMEZZI, cmbAut);
        }

        private void bttTabArt_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_ARTICOLI_DESC_COD, cmbCodArt);
        }

        private void bttTabUM_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_UNIT_MISURA, cmbUm);
        }

        private void bttTabIva_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_IVA_DESCR, cmbIva);
        }

        private void bttTabClienti_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_CLIENTI, cmbCliente);
        }

        private void nudQuant_Enter(object sender, EventArgs e)
        {
            nudQuant.Select(0, nudQuant.Value.ToString("N2").Length);
        }

        private void nudPrezzo_Enter(object sender, EventArgs e)
        {
                nudPrezzo.Select(0, nudPrezzo.Value.ToString("N2").Length);
        }

    }
}
