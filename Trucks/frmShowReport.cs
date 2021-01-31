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
    public partial class frmShowReport : Form
    {
        public CrystalDecisions.CrystalReports.Engine.ReportClass objReportSource = null;

        private bool bIsToHide = false;

        public frmShowReport()
        {
            InitializeComponent();
        }

        private void frmShowReport_Load(object sender, EventArgs e)
        {
            if (objReportSource == null)
            {
                objReportSource = new crpVuoto();
                this.WindowState = FormWindowState.Minimized;
                bIsToHide = true;
                timer1.Enabled = true;
            } 
            else
            {
                crViewer.ReportSource = null;
                crViewer.Show();
                crViewer.ReportSource = objReportSource;
                crViewer.Refresh();
                crViewer.Show();
            }
        }

        private void frmShowReport_Shown(object sender, EventArgs e)
        {
            if (bIsToHide)
                this.Hide();
        }

        private void frmShowReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            crViewer.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Program._shouldStop)
                this.Close();
        }

    }
}
