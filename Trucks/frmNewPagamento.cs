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
    public partial class frmNewPagamento : Form
    {
        public Form frmParent = null;
        public int IdSel = 0;

        private bool isChanged = false;

        public frmNewPagamento()
        {
            InitializeComponent();
        }

        private void frmNewPagamento_Load(object sender, EventArgs e)
        {
            if (!this.Modal)
                this.WindowState = FormWindowState.Maximized;

            PopolaCombo();

            if (IdSel > 0)
                LoadItem(IdSel);
        }

        private void bttEsci_Click(object sender, EventArgs e)
        {
            if (isChanged)
            {
                if (MessageBox.Show("Uscire senza salvare le modifiche ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    Close();
            }
            else
                Close();
        }

        private void LoadItem(int Id)
        {
            string strSql = "select " +
                               " s.ID as ID, " +
                               " c.Cln_rag_soc as Cliente," +
                               " f.docu_numero as 'Num. Fattura'," +
                               " f.docu_data as 'Data Fattura'," +
                               " f.importo as 'Importo Fattura'," +
                               " s.Scadenza_importo as 'Importo Scadenza'," +
                               " s.Scadenza_data as 'Data Scadenza'," +
                               " s.Scandenza_incassato as Incassato," +
                               " s.Scandenza_incassato_data, " +
                               " s.ID_mod_pagamenti, " +
                               " s.Scadenza_ID_banca, " +
                               " s.Scadenza_note, " +
                               " (s.Scadenza_importo - Scandenza_incassato) as Saldo " +
                           " from " +
                               " Scadenze s" +
                               " left join View_Fatture f on s.ID_documento = f.ID" +
                               " left join Clienti c on c.Id = f.ID_cliente" +
                           " where docu_cancellato = 0 and s.Id = " + Id.ToString();

            if (clsDataBase.ExecuteQuery(strSql))
            {
                if (clsDataBase.vetDbReader[0].Read())
                {
                    lblNumFatt.Text = clsDataBase.GetIntValue("Num. Fattura").ToString();
                    lblDataFatt.Text = clsDataBase.GetDateValue("Data Fattura").ToString("dd/MM/yyyy");
                    lblCliente.Text = clsDataBase.GetStringValue("Cliente");
                    lblScadImp.Text = clsDataBase.GetValutaValue("Importo Scadenza").ToString();
                    lblScadData.Text = clsDataBase.GetDateValue("Data Scadenza").ToString("dd/MM/yyyy");
                    
                    nudImporto.Maximum = clsDataBase.GetValutaValue("Importo Scadenza");
                    nudImporto.Value = clsDataBase.GetValutaValue("Incassato");
                    
                    if (clsDataBase.GetDateValue("Scandenza_incassato_data") == DateTime.MinValue)
                        dtpData.Value = DateTime.Today;
                    else
                        dtpData.Value = clsDataBase.GetDateValue("Scandenza_incassato_data");
                    cmbModPag.Tag = clsDataBase.GetIntValue("ID_mod_pagamenti");
                    cmbBanca.Tag = clsDataBase.GetIntValue("Scadenza_ID_banca");
                    txtNote.Text = clsDataBase.GetStringValue("Scadenza_note");
                }
            }

            clsDataBase.CloseDataReader();
            PopolaCombo();
        }

        private void PopolaCombo()
        {
            clsDataBase.PopolaCombo(cmbModPag, clsGlobal.ETypeTable.TT_MOD_PAGAMENTO);
            clsDataBase.PopolaCombo(cmbBanca, clsGlobal.ETypeTable.TT_BANCHE_AZ);
        }

        private void nudImporto_ValueChanged(object sender, EventArgs e)
        {
            isChanged = true;
        }

        private void dtpData_ValueChanged(object sender, EventArgs e)
        {
            isChanged = true;
        }

        private void cmbModPag_SelectedIndexChanged(object sender, EventArgs e)
        {
            isChanged = true;
            if (cmbModPag.Text !="" && cmbModPag.Text.Substring(0, 5) == "BANCA")
                cmbBanca.Enabled = true;
            else
            {
                cmbBanca.SelectedIndex = -1;
                cmbBanca.Enabled = false;
            }
        }

        private void cmbBanca_SelectedIndexChanged(object sender, EventArgs e)
        {
            isChanged = true;
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            isChanged = true;
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            if (!VerificaCampi()) return;

            if (MessageBox.Show("Salvare le nuove impostazioni ?", "Attenzione", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;

            //Salvo le impostazioni
            string strSql = "Update Scadenze Set" +
                                " Scandenza_incassato = " + nudImporto.Value.ToString().Replace(",", ".") +
                                ", Scandenza_incassato_data = " + clsDataBase.SQL_ConvertDateTimeToData(dtpData.Value) +
                                ", ID_mod_pagamenti = " + ((_dataItemCombo)cmbModPag.SelectedItem).Id.ToString() +
                                ", Scadenza_ID_banca = " + ((_dataItemCombo)cmbBanca.SelectedItem).Id.ToString() +
                                ", Scadenza_note = '" + txtNote.Text.Replace("'", "''") + "'" +
                                " Where Id =" + IdSel.ToString();

            if (clsDataBase.ExecuteNonQuery(strSql))
            {
                isChanged = false;
                this.Close();
            }

        }

        private bool VerificaCampi()
        {
            bool bRetValue = true;
            string strErrore = "";

            if (cmbModPag.SelectedIndex < 1 && nudImporto.Value > 0) strErrore += "Richiesta selezione Modalità di Incasso\n";
            if (cmbBanca.Enabled && cmbBanca.SelectedIndex < 1) strErrore += "Richiesta selezione Banca\n";

            if (strErrore != "")
            {
                MessageBox.Show("Verificare i parametri inseriti:\n\n" + strErrore, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bRetValue = false;
            }
            return bRetValue;
        }

        private void frmNewPagamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmParent != null)
            {
                frmParent.Show();
            }
        }

        private void bttTabModInc_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_MOD_PAGAMENTO, cmbModPag);
        }

        private void bttTabBancaAz_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable.TT_BANCHE_AZ, cmbBanca);
        }
    }
}
