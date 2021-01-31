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
    public partial class mdipMain : Form
    {
        private int childFormNumber = 0;

        public mdipMain()
        {
            InitializeComponent();            
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Finestra " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "File di testo (*.txt)|*.txt|Tutti i file (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutBox newForm = new frmAboutBox();
            newForm.ShowDialog();
            newForm.Dispose();
        }

        private void tsmiAnagAzienda_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.GetType().ToString() == "Trucks.frmAnagAzienda")
                {
                    if (childForm.Visible == false)
                        MessageBox.Show("Per Visualizzare la finestra è necessario chiudere le finestre di dettaglio inerenti Anagrafica Azienda.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        childForm.Focus();
                    count++;
                }
            }
            if (count == 0)
            {
                Form childForm = new frmAnagAzienda();
                childForm.MdiParent = this;
                childFormNumber++;
                childForm.Show();
            }
        }

        private void tsmiAnagClienti_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.GetType().ToString() == "Trucks.frmAnagCliente")
                {
                    if (childForm.Visible == false)
                        MessageBox.Show("Per visualizzare la finestra è necessario chiudere le finestre di dettaglio Clienti.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        childForm.Focus();
                    count++;
                }
            }
            if (count == 0)
            {
                Form childForm = new frmAnagCliente();
                childForm.MdiParent = this;
                childFormNumber++;
                childForm.Show();
            }            
        }

        private void tsmiAnagArticoli_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.GetType().ToString() == "Trucks.frmAnagArticoli")
                {
                    if (childForm.Visible == false)
                        MessageBox.Show("Per visualizzare la finestra è necessario chiudere le finestre di dettaglio Articoli.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        childForm.Focus();
                    count++;
                }
            }
            if (count == 0)
            {
                Form childForm = new frmAnagArticoli();
                childForm.MdiParent = this;
                childFormNumber++;
                childForm.Show();
            }            
        }

        private void tsmiAnagAutomezzi_Click(object sender, EventArgs e)
        {            
            int count = 0;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.GetType().ToString() == "Trucks.frmAnagAutomezzi")
                {
                    if (childForm.Visible == false)
                        MessageBox.Show("Per visualizzare la finestra è necessario chiudere le finestre di dettaglio Automezzi.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        childForm.Focus();
                    count++;
                }
            }
            if (count == 0)
            {
                Form childForm = new frmAnagAutomezzi();
                childForm.MdiParent = this;
                childFormNumber++;
                childForm.Show();
            }
        }

        private void tsmiTabelleIVA_Click(object sender, EventArgs e)
        {
            LoadFormGestTab(clsGlobal.ETypeTable.TT_IVA);
        }


        private void tsmiTabelleUnitMis_Click(object sender, EventArgs e)
        {
            LoadFormGestTab(clsGlobal.ETypeTable.TT_UNIT_MISURA);
        }

        private void tsmiTabelleCateg_Click(object sender, EventArgs e)
        {
            LoadFormGestTab(clsGlobal.ETypeTable.TT_CATEGORIA);
        }

        private void tsmiTabelleAssic_Click(object sender, EventArgs e)
        {
            LoadFormGestTab(clsGlobal.ETypeTable.TT_ASSICURAZIONI);
        }

        private void tsmiTabellePagType_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.GetType().ToString() == "Trucks.frmTipoPag")
                {
                    if (childForm.Visible == false)
                        MessageBox.Show("Per visualizzare la finestra è necessario chiudere le finestre di dettaglio Automezzi.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        childForm.Focus();
                    count++;
                }
            }
            if (count == 0)
            {
                Form childForm = new frmTipoPag();
                childForm.MdiParent = this;
                childFormNumber++;
                childForm.Show();
            }
        }

        private void tsmiTabellePagMod_Click(object sender, EventArgs e)
        {
            LoadFormGestTab(clsGlobal.ETypeTable.TT_MOD_PAGAMENTO);
        }

        private void mdipMain_Load(object sender, EventArgs e)
        {
            clsReport.FORM_PARENTE_MDI = this;
        }

        private void tsmiDocViaggi_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.GetType().ToString() == "Trucks.frmDocViaggi")
                {
                    if (childForm.Visible == false)
                        MessageBox.Show("Per visualizzare la finestra è necessario chiudere le finestre di dettaglio Viaggi.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        childForm.Focus();
                    count++;
                }
            }
            if (count == 0)
            {
                Form childForm = new frmDocViaggi();
                childForm.MdiParent = this;
                childFormNumber++;
                childForm.Show();
            }
        }

        private void tsmiToolsImp_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.GetType().ToString() == "Trucks.frmImpostazioni")
                {
                    childForm.Focus();
                    count++;
                }
            }
            if (count == 0)
            {
                Form childForm = new frmImpostazioni();
                childForm.MdiParent = this;
                childFormNumber++;
                childForm.Show();
            }
        }

        public void LoadFormGestTab(clsGlobal.ETypeTable TypeTable)
        {
            string sTextCaption = clsGlobal.GetCaptionTabForm(TypeTable);

            int count = 0;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.GetType().ToString() == "Trucks.frmGestTab")
                {
                    if (childForm.Text == sTextCaption)
                    {
                        childForm.Focus();
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                Form childForm = new frmGestTab();
                childForm.MdiParent = this;
                ((frmGestTab)childForm).TypeTable = TypeTable;
                //childFormNumber++;

                childForm.Show();
            }
        }

        private void tsmiTabelleDistViaggi_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.GetType().ToString() == "Trucks.frmDistanze")
                {
                    childForm.Focus();
                    count++;
                }
            }
            if (count == 0)
            {
                Form childForm = new frmDistanze();
                childForm.MdiParent = this;
                childFormNumber++;
                childForm.Show();
            }
        }

        private void tsmiTabelleLocalita_Click(object sender, EventArgs e)
        {
            LoadFormGestTab(clsGlobal.ETypeTable.TT_LOCALITA);
        }

        private void tsmiDocRicerca_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.GetType().ToString() == "Trucks.frmDocumenti")
                {
                    childForm.Focus();
                    count++;
                }
            }
            if (count == 0)
            {
                Form childForm = new frmDocumenti();
                childForm.MdiParent = this;
                childFormNumber++;
                childForm.Show();
            }
        }

        private void tsmiDocFatture_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.GetType().ToString() == "Trucks.frmModFattura")
                {
                    MessageBox.Show("Finestra Fatture/Note di Credito già aperta.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    childForm.Focus();
                    count++;
                }
            }
            if (count == 0)
            {
                Form childForm = new frmModFattura();
                childForm.MdiParent = this;
                childFormNumber++;
                childForm.Show();
            }
        }

        private void tsmiGestAutScadenziario_Click(object sender, EventArgs e)
        {
            

        }

        private void tsmiAnagBancheAz_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.GetType().ToString() == "Trucks.frmBanche")
                {
                    childForm.Focus();
                    count++;
                }
            }
            if (count == 0)
            {
                Form childForm = new frmBanche();
                childForm.MdiParent = this;
                childFormNumber++;
                childForm.Show();
            }

        }

        private void tsmiContabScadenziario_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.GetType().ToString() == "Trucks.frmScadenziario")
                {
                    childForm.Focus();
                    count++;
                }
            }
            if (count == 0)
            {
                Form childForm = new frmScadenziario();
                childForm.MdiParent = this;
                childFormNumber++;
                childForm.Show();
            }
        }

        private void tsmiDocNoteCredito_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.GetType().ToString() == "Trucks.frmModFattura")
                {
                    MessageBox.Show("Finestra Fatture/Note di Credito già aperta.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    childForm.Focus();
                    count++;
                }
            }
            if (count == 0)
            {
                Form childForm = new frmModFattura();
                childForm.MdiParent = this;
                ((frmModFattura)childForm).TipoDoc = frmModFattura.ETypeDoc.TD_NDC;
                childFormNumber++;
                childForm.Show();
            }            

        }

        private void tsmiTabelleEsenzioni_Click(object sender, EventArgs e)
        {
            LoadFormGestTab(clsGlobal.ETypeTable.TT_ESENZIONI);
        }

        private void mdipMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Qualora siano presenti finestre aperte le modifiche apportate saranno perse.\n\nConfermi la chiusura dell'applicazione ?", "Trucks - Chiusura", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                e.Cancel = true;
        }

        private void tsmiTabelleDescrBreve_Click(object sender, EventArgs e)
        {
          LoadFormGestTab(clsGlobal.ETypeTable.TT_DESCR_BREVI);
        }
    }
}
