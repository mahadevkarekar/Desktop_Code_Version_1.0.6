namespace Trucks
{
    partial class frmImpostazioni
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
      this.bttEsc = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.bttSaveDb = new System.Windows.Forms.Button();
      this.bttTestDb = new System.Windows.Forms.Button();
      this.txtDBServer = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.grpbOtherParam = new System.Windows.Forms.GroupBox();
      this.bttFatAntep = new System.Windows.Forms.Button();
      this.cmbModFatt = new System.Windows.Forms.ComboBox();
      this.label9 = new System.Windows.Forms.Label();
      this.nudCoeff = new System.Windows.Forms.NumericUpDown();
      this.label8 = new System.Windows.Forms.Label();
      this.nudPrezzoCarb = new System.Windows.Forms.NumericUpDown();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.bttSalvaOtherSet = new System.Windows.Forms.Button();
      this.txtNoteFatt = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.rdbPrintDatiNo = new System.Windows.Forms.RadioButton();
      this.rdbPrintDati = new System.Windows.Forms.RadioButton();
      this.label4 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.rdbPrintLogoNo = new System.Windows.Forms.RadioButton();
      this.rdbPrintLogo = new System.Windows.Forms.RadioButton();
      this.label3 = new System.Windows.Forms.Label();
      this.bttSetPathPdf = new System.Windows.Forms.Button();
      this.lblPathPdf = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.grpbOtherParam.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudCoeff)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudPrezzoCarb)).BeginInit();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // bttEsc
      // 
      this.bttEsc.Location = new System.Drawing.Point(390, 419);
      this.bttEsc.Name = "bttEsc";
      this.bttEsc.Size = new System.Drawing.Size(67, 25);
      this.bttEsc.TabIndex = 13;
      this.bttEsc.Text = "Esci";
      this.bttEsc.UseVisualStyleBackColor = true;
      this.bttEsc.Click += new System.EventHandler(this.bttEsc_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.bttSaveDb);
      this.groupBox1.Controls.Add(this.bttTestDb);
      this.groupBox1.Controls.Add(this.txtDBServer);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Location = new System.Drawing.Point(6, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(459, 85);
      this.groupBox1.TabIndex = 17;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Parametri Database";
      // 
      // bttSaveDb
      // 
      this.bttSaveDb.Location = new System.Drawing.Point(384, 50);
      this.bttSaveDb.Name = "bttSaveDb";
      this.bttSaveDb.Size = new System.Drawing.Size(67, 25);
      this.bttSaveDb.TabIndex = 2;
      this.bttSaveDb.Text = "Salva";
      this.bttSaveDb.UseVisualStyleBackColor = true;
      this.bttSaveDb.Click += new System.EventHandler(this.bttSaveDb_Click);
      // 
      // bttTestDb
      // 
      this.bttTestDb.Location = new System.Drawing.Point(239, 48);
      this.bttTestDb.Name = "bttTestDb";
      this.bttTestDb.Size = new System.Drawing.Size(120, 25);
      this.bttTestDb.TabIndex = 1;
      this.bttTestDb.Text = "Test di connessione";
      this.bttTestDb.UseVisualStyleBackColor = true;
      this.bttTestDb.Click += new System.EventHandler(this.bttTestDb_Click);
      // 
      // txtDBServer
      // 
      this.txtDBServer.Location = new System.Drawing.Point(55, 22);
      this.txtDBServer.MaxLength = 256;
      this.txtDBServer.Name = "txtDBServer";
      this.txtDBServer.Size = new System.Drawing.Size(396, 20);
      this.txtDBServer.TabIndex = 0;
      this.txtDBServer.TextChanged += new System.EventHandler(this.txtDBServer_TextChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 25);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(44, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Server :";
      // 
      // grpbOtherParam
      // 
      this.grpbOtherParam.Controls.Add(this.bttFatAntep);
      this.grpbOtherParam.Controls.Add(this.cmbModFatt);
      this.grpbOtherParam.Controls.Add(this.label9);
      this.grpbOtherParam.Controls.Add(this.nudCoeff);
      this.grpbOtherParam.Controls.Add(this.label8);
      this.grpbOtherParam.Controls.Add(this.nudPrezzoCarb);
      this.grpbOtherParam.Controls.Add(this.label7);
      this.grpbOtherParam.Controls.Add(this.label6);
      this.grpbOtherParam.Controls.Add(this.bttSalvaOtherSet);
      this.grpbOtherParam.Controls.Add(this.txtNoteFatt);
      this.grpbOtherParam.Controls.Add(this.label5);
      this.grpbOtherParam.Controls.Add(this.panel2);
      this.grpbOtherParam.Controls.Add(this.label4);
      this.grpbOtherParam.Controls.Add(this.panel1);
      this.grpbOtherParam.Controls.Add(this.label3);
      this.grpbOtherParam.Controls.Add(this.bttSetPathPdf);
      this.grpbOtherParam.Controls.Add(this.lblPathPdf);
      this.grpbOtherParam.Controls.Add(this.label1);
      this.grpbOtherParam.Location = new System.Drawing.Point(6, 103);
      this.grpbOtherParam.Name = "grpbOtherParam";
      this.grpbOtherParam.Size = new System.Drawing.Size(459, 310);
      this.grpbOtherParam.TabIndex = 18;
      this.grpbOtherParam.TabStop = false;
      this.grpbOtherParam.Text = "Altri Parametri";
      // 
      // bttFatAntep
      // 
      this.bttFatAntep.Location = new System.Drawing.Point(368, 165);
      this.bttFatAntep.Name = "bttFatAntep";
      this.bttFatAntep.Size = new System.Drawing.Size(83, 25);
      this.bttFatAntep.TabIndex = 33;
      this.bttFatAntep.Text = "Anteprima";
      this.bttFatAntep.UseVisualStyleBackColor = true;
      this.bttFatAntep.Click += new System.EventHandler(this.bttFatAntep_Click);
      // 
      // cmbModFatt
      // 
      this.cmbModFatt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbModFatt.FormattingEnabled = true;
      this.cmbModFatt.Items.AddRange(new object[] {
            "Modello 1 - Senza codice articolo",
            "Modello 2 - Con codice articolo"});
      this.cmbModFatt.Location = new System.Drawing.Point(99, 165);
      this.cmbModFatt.Name = "cmbModFatt";
      this.cmbModFatt.Size = new System.Drawing.Size(260, 21);
      this.cmbModFatt.TabIndex = 32;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(12, 168);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(83, 13);
      this.label9.TabIndex = 31;
      this.label9.Text = "Modello Fattura:";
      // 
      // nudCoeff
      // 
      this.nudCoeff.DecimalPlaces = 4;
      this.nudCoeff.Location = new System.Drawing.Point(82, 131);
      this.nudCoeff.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.nudCoeff.Name = "nudCoeff";
      this.nudCoeff.Size = new System.Drawing.Size(117, 20);
      this.nudCoeff.TabIndex = 9;
      this.nudCoeff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(438, 133);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(13, 13);
      this.label8.TabIndex = 30;
      this.label8.Text = "€";
      this.label8.Visible = false;
      // 
      // nudPrezzoCarb
      // 
      this.nudPrezzoCarb.DecimalPlaces = 2;
      this.nudPrezzoCarb.Location = new System.Drawing.Point(340, 131);
      this.nudPrezzoCarb.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.nudPrezzoCarb.Name = "nudPrezzoCarb";
      this.nudPrezzoCarb.Size = new System.Drawing.Size(92, 20);
      this.nudPrezzoCarb.TabIndex = 10;
      this.nudPrezzoCarb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.nudPrezzoCarb.Visible = false;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(237, 133);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(97, 13);
      this.label7.TabIndex = 28;
      this.label7.Text = "Prezzo Carburante:";
      this.label7.Visible = false;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(12, 133);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(66, 13);
      this.label6.TabIndex = 26;
      this.label6.Text = "Coefficiente:";
      // 
      // bttSalvaOtherSet
      // 
      this.bttSalvaOtherSet.Location = new System.Drawing.Point(384, 278);
      this.bttSalvaOtherSet.Name = "bttSalvaOtherSet";
      this.bttSalvaOtherSet.Size = new System.Drawing.Size(67, 25);
      this.bttSalvaOtherSet.TabIndex = 12;
      this.bttSalvaOtherSet.Text = "Salva";
      this.bttSalvaOtherSet.UseVisualStyleBackColor = true;
      this.bttSalvaOtherSet.Click += new System.EventHandler(this.bttSalvaOtherSet_Click);
      // 
      // txtNoteFatt
      // 
      this.txtNoteFatt.Location = new System.Drawing.Point(15, 218);
      this.txtNoteFatt.MaxLength = 200;
      this.txtNoteFatt.Multiline = true;
      this.txtNoteFatt.Name = "txtNoteFatt";
      this.txtNoteFatt.Size = new System.Drawing.Size(436, 54);
      this.txtNoteFatt.TabIndex = 11;
      this.txtNoteFatt.TextChanged += new System.EventHandler(this.txtNoteFatt_TextChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 193);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(69, 13);
      this.label5.TabIndex = 23;
      this.label5.Text = "Note Fattura:";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.rdbPrintDatiNo);
      this.panel2.Controls.Add(this.rdbPrintDati);
      this.panel2.Location = new System.Drawing.Point(123, 92);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(236, 27);
      this.panel2.TabIndex = 22;
      // 
      // rdbPrintDatiNo
      // 
      this.rdbPrintDatiNo.AutoSize = true;
      this.rdbPrintDatiNo.Location = new System.Drawing.Point(86, 3);
      this.rdbPrintDatiNo.Name = "rdbPrintDatiNo";
      this.rdbPrintDatiNo.Size = new System.Drawing.Size(39, 17);
      this.rdbPrintDatiNo.TabIndex = 8;
      this.rdbPrintDatiNo.Text = "No";
      this.rdbPrintDatiNo.UseVisualStyleBackColor = true;
      // 
      // rdbPrintDati
      // 
      this.rdbPrintDati.AutoSize = true;
      this.rdbPrintDati.Checked = true;
      this.rdbPrintDati.Location = new System.Drawing.Point(22, 3);
      this.rdbPrintDati.Name = "rdbPrintDati";
      this.rdbPrintDati.Size = new System.Drawing.Size(34, 17);
      this.rdbPrintDati.TabIndex = 7;
      this.rdbPrintDati.TabStop = true;
      this.rdbPrintDati.Text = "Si";
      this.rdbPrintDati.UseVisualStyleBackColor = true;
      this.rdbPrintDati.CheckedChanged += new System.EventHandler(this.rdbObject_CheckedChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 97);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(111, 13);
      this.label4.TabIndex = 21;
      this.label4.Text = "Stampa dati Aziendali:";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.rdbPrintLogoNo);
      this.panel1.Controls.Add(this.rdbPrintLogo);
      this.panel1.Location = new System.Drawing.Point(123, 59);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(236, 27);
      this.panel1.TabIndex = 20;
      // 
      // rdbPrintLogoNo
      // 
      this.rdbPrintLogoNo.AutoSize = true;
      this.rdbPrintLogoNo.Location = new System.Drawing.Point(86, 3);
      this.rdbPrintLogoNo.Name = "rdbPrintLogoNo";
      this.rdbPrintLogoNo.Size = new System.Drawing.Size(39, 17);
      this.rdbPrintLogoNo.TabIndex = 6;
      this.rdbPrintLogoNo.TabStop = true;
      this.rdbPrintLogoNo.Text = "No";
      this.rdbPrintLogoNo.UseVisualStyleBackColor = true;
      // 
      // rdbPrintLogo
      // 
      this.rdbPrintLogo.AutoSize = true;
      this.rdbPrintLogo.Checked = true;
      this.rdbPrintLogo.Location = new System.Drawing.Point(22, 3);
      this.rdbPrintLogo.Name = "rdbPrintLogo";
      this.rdbPrintLogo.Size = new System.Drawing.Size(34, 17);
      this.rdbPrintLogo.TabIndex = 5;
      this.rdbPrintLogo.TabStop = true;
      this.rdbPrintLogo.Text = "Si";
      this.rdbPrintLogo.UseVisualStyleBackColor = true;
      this.rdbPrintLogo.CheckedChanged += new System.EventHandler(this.rdbObject_CheckedChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 64);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(73, 13);
      this.label3.TabIndex = 19;
      this.label3.Text = "Stampa Logo:";
      // 
      // bttSetPathPdf
      // 
      this.bttSetPathPdf.Location = new System.Drawing.Point(419, 19);
      this.bttSetPathPdf.Name = "bttSetPathPdf";
      this.bttSetPathPdf.Size = new System.Drawing.Size(32, 21);
      this.bttSetPathPdf.TabIndex = 4;
      this.bttSetPathPdf.Text = "...";
      this.bttSetPathPdf.UseVisualStyleBackColor = true;
      this.bttSetPathPdf.Click += new System.EventHandler(this.bttSetPathPdf_Click);
      // 
      // lblPathPdf
      // 
      this.lblPathPdf.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblPathPdf.Location = new System.Drawing.Point(145, 21);
      this.lblPathPdf.Name = "lblPathPdf";
      this.lblPathPdf.Size = new System.Drawing.Size(268, 21);
      this.lblPathPdf.TabIndex = 3;
      this.lblPathPdf.TextChanged += new System.EventHandler(this.lblPathPdf_TextChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(106, 13);
      this.label1.TabIndex = 16;
      this.label1.Text = "Percoso salvataggio:";
      // 
      // frmImpostazioni
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(473, 456);
      this.Controls.Add(this.grpbOtherParam);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.bttEsc);
      this.Name = "frmImpostazioni";
      this.ShowIcon = false;
      this.Text = "Impostazioni";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmImpostazioni_FormClosing);
      this.Load += new System.EventHandler(this.frmImpostazioni_Load);
      this.Shown += new System.EventHandler(this.frmImpostazioni_Shown);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.grpbOtherParam.ResumeLayout(false);
      this.grpbOtherParam.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudCoeff)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudPrezzoCarb)).EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button bttEsc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bttSaveDb;
        private System.Windows.Forms.Button bttTestDb;
        private System.Windows.Forms.TextBox txtDBServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpbOtherParam;
        private System.Windows.Forms.Button bttSalvaOtherSet;
        private System.Windows.Forms.TextBox txtNoteFatt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdbPrintDatiNo;
        private System.Windows.Forms.RadioButton rdbPrintDati;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbPrintLogoNo;
        private System.Windows.Forms.RadioButton rdbPrintLogo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bttSetPathPdf;
        private System.Windows.Forms.Label lblPathPdf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudPrezzoCarb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudCoeff;
        private System.Windows.Forms.Button bttFatAntep;
        private System.Windows.Forms.ComboBox cmbModFatt;
        private System.Windows.Forms.Label label9;
    }
}