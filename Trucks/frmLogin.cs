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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void bttAnnulla_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (clsDataBase.DbConnect())
            {
                clsReport.Set_Rerport_ConnInfo();

                Cursor.Current = Cursors.Default;
                clsSetting.LoadParam();

                if (txtbUser.Text == "" && txtbPwd.Text == "")
                {
                    // Credenziali corrette
                    mdipMain myFrm = new mdipMain();
                    Hide();
                    myFrm.ShowDialog();
                    Close();
                }
                else
                {
                    // Credenziali errate
                    MessageBox.Show("Cerdenziali errate.", "TRUK Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else 
            {
                MessageBox.Show("Impossibile connettersi al Database.\nVerificare le impostazioni di configurazione.", "TRUK Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default; 
        }

        private void bttImp_Click(object sender, EventArgs e)
        {
            Form newFrm = new frmImpostazioni();

            ((frmImpostazioni)newFrm).EnableOtherParam = false;
            newFrm.ShowDialog();
            //clsSetting.LoadParam();
            //clsDataBase.DbDisconnect();
            //clsDataBase.DbConnect(); 
        }

        private void bttAnnulla_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            clsSetting.Load_RegistryParam();
        }
    }
}
