namespace Trucks
{
    partial class frmModAutomezzi
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblCodice = new System.Windows.Forms.Label();
            this.rdbPropTerzi = new System.Windows.Forms.RadioButton();
            this.rdbProprio = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.bttEsci = new System.Windows.Forms.Button();
            this.bttElimina = new System.Windows.Forms.Button();
            this.bttAnnulla = new System.Windows.Forms.Button();
            this.bttSave = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.grpbProprio = new System.Windows.Forms.GroupBox();
            this.nudKw = new System.Windows.Forms.NumericUpDown();
            this.nudKM = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudPortata = new System.Windows.Forms.NumericUpDown();
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.grpbScad = new System.Windows.Forms.GroupBox();
            this.cmbFreqAss = new System.Windows.Forms.ComboBox();
            this.cmbFreqBollo = new System.Windows.Forms.ComboBox();
            this.txtAss = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.nudAss = new System.Windows.Forms.NumericUpDown();
            this.dtpScadAss = new System.Windows.Forms.DateTimePicker();
            this.nudBollo = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpScadBollo = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpDataImm = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpDataAcq = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTarga = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModello = new System.Windows.Forms.TextBox();
            this.txtTelaio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpTerzi = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.grpbProprio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortata)).BeginInit();
            this.grpbScad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBollo)).BeginInit();
            this.grpTerzi.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codice:";
            // 
            // lblCodice
            // 
            this.lblCodice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCodice.Location = new System.Drawing.Point(58, 8);
            this.lblCodice.Name = "lblCodice";
            this.lblCodice.Size = new System.Drawing.Size(114, 20);
            this.lblCodice.TabIndex = 1;
            this.lblCodice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rdbPropTerzi
            // 
            this.rdbPropTerzi.AutoSize = true;
            this.rdbPropTerzi.Location = new System.Drawing.Point(147, 58);
            this.rdbPropTerzi.Name = "rdbPropTerzi";
            this.rdbPropTerzi.Size = new System.Drawing.Size(57, 17);
            this.rdbPropTerzi.TabIndex = 3;
            this.rdbPropTerzi.Text = "Di terzi";
            this.rdbPropTerzi.UseVisualStyleBackColor = true;
            // 
            // rdbProprio
            // 
            this.rdbProprio.AutoSize = true;
            this.rdbProprio.Checked = true;
            this.rdbProprio.Location = new System.Drawing.Point(65, 58);
            this.rdbProprio.Name = "rdbProprio";
            this.rdbProprio.Size = new System.Drawing.Size(79, 17);
            this.rdbProprio.TabIndex = 2;
            this.rdbProprio.TabStop = true;
            this.rdbProprio.Text = "Di proprietà";
            this.rdbProprio.UseVisualStyleBackColor = true;
            this.rdbProprio.CheckedChanged += new System.EventHandler(this.rdbProprio_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Tipologia:";
            // 
            // bttEsci
            // 
            this.bttEsci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttEsci.Location = new System.Drawing.Point(671, 483);
            this.bttEsci.Name = "bttEsci";
            this.bttEsci.Size = new System.Drawing.Size(60, 25);
            this.bttEsci.TabIndex = 26;
            this.bttEsci.Text = "Esci";
            this.bttEsci.UseVisualStyleBackColor = true;
            this.bttEsci.Click += new System.EventHandler(this.bttEsci_Click);
            // 
            // bttElimina
            // 
            this.bttElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttElimina.Location = new System.Drawing.Point(209, 483);
            this.bttElimina.Name = "bttElimina";
            this.bttElimina.Size = new System.Drawing.Size(60, 25);
            this.bttElimina.TabIndex = 25;
            this.bttElimina.Text = "Elimina";
            this.bttElimina.UseVisualStyleBackColor = true;
            this.bttElimina.Click += new System.EventHandler(this.bttElimina_Click);
            // 
            // bttAnnulla
            // 
            this.bttAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttAnnulla.Location = new System.Drawing.Point(105, 483);
            this.bttAnnulla.Name = "bttAnnulla";
            this.bttAnnulla.Size = new System.Drawing.Size(60, 25);
            this.bttAnnulla.TabIndex = 24;
            this.bttAnnulla.Text = "Annulla";
            this.bttAnnulla.UseVisualStyleBackColor = true;
            this.bttAnnulla.Click += new System.EventHandler(this.bttAnnulla_Click);
            // 
            // bttSave
            // 
            this.bttSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttSave.Location = new System.Drawing.Point(8, 483);
            this.bttSave.Name = "bttSave";
            this.bttSave.Size = new System.Drawing.Size(60, 25);
            this.bttSave.TabIndex = 23;
            this.bttSave.Text = "Salva";
            this.bttSave.UseVisualStyleBackColor = true;
            this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 346);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(33, 13);
            this.label19.TabIndex = 84;
            this.label19.Text = "Note:";
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.Location = new System.Drawing.Point(8, 362);
            this.txtNote.MaxLength = 3000;
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNote.Size = new System.Drawing.Size(723, 107);
            this.txtNote.TabIndex = 22;
            // 
            // grpbProprio
            // 
            this.grpbProprio.Controls.Add(this.nudKw);
            this.grpbProprio.Controls.Add(this.nudKM);
            this.grpbProprio.Controls.Add(this.label7);
            this.grpbProprio.Controls.Add(this.nudPortata);
            this.grpbProprio.Controls.Add(this.txtDescr);
            this.grpbProprio.Controls.Add(this.label20);
            this.grpbProprio.Controls.Add(this.label18);
            this.grpbProprio.Controls.Add(this.label17);
            this.grpbProprio.Controls.Add(this.grpbScad);
            this.grpbProprio.Controls.Add(this.dtpDataImm);
            this.grpbProprio.Controls.Add(this.label9);
            this.grpbProprio.Controls.Add(this.dtpDataAcq);
            this.grpbProprio.Controls.Add(this.label8);
            this.grpbProprio.Controls.Add(this.txtTarga);
            this.grpbProprio.Controls.Add(this.label2);
            this.grpbProprio.Controls.Add(this.label6);
            this.grpbProprio.Controls.Add(this.label3);
            this.grpbProprio.Controls.Add(this.txtModello);
            this.grpbProprio.Controls.Add(this.txtTelaio);
            this.grpbProprio.Controls.Add(this.label5);
            this.grpbProprio.Controls.Add(this.txtMarca);
            this.grpbProprio.Controls.Add(this.label4);
            this.grpbProprio.Location = new System.Drawing.Point(9, 92);
            this.grpbProprio.Name = "grpbProprio";
            this.grpbProprio.Size = new System.Drawing.Size(723, 251);
            this.grpbProprio.TabIndex = 88;
            this.grpbProprio.TabStop = false;
            this.grpbProprio.Text = "Dettaglio automezzo:";
            // 
            // nudKw
            // 
            this.nudKw.Location = new System.Drawing.Point(601, 57);
            this.nudKw.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudKw.Name = "nudKw";
            this.nudKw.Size = new System.Drawing.Size(65, 20);
            this.nudKw.TabIndex = 9;
            this.nudKw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudKM
            // 
            this.nudKM.Location = new System.Drawing.Point(468, 86);
            this.nudKM.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudKM.Name = "nudKM";
            this.nudKM.Size = new System.Drawing.Size(65, 20);
            this.nudKM.TabIndex = 12;
            this.nudKM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(672, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 107;
            this.label7.Text = "quintali";
            // 
            // nudPortata
            // 
            this.nudPortata.Location = new System.Drawing.Point(601, 87);
            this.nudPortata.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudPortata.Name = "nudPortata";
            this.nudPortata.Size = new System.Drawing.Size(65, 20);
            this.nudPortata.TabIndex = 13;
            this.nudPortata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDescr
            // 
            this.txtDescr.Location = new System.Drawing.Point(93, 118);
            this.txtDescr.MaxLength = 25;
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(619, 20);
            this.txtDescr.TabIndex = 14;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 121);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 13);
            this.label20.TabIndex = 104;
            this.label20.Text = "Descrizione:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(551, 60);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(25, 13);
            this.label18.TabIndex = 103;
            this.label18.Text = "Kw:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(444, 90);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 13);
            this.label17.TabIndex = 102;
            this.label17.Text = "Km:";
            // 
            // grpbScad
            // 
            this.grpbScad.Controls.Add(this.cmbFreqAss);
            this.grpbScad.Controls.Add(this.cmbFreqBollo);
            this.grpbScad.Controls.Add(this.txtAss);
            this.grpbScad.Controls.Add(this.label14);
            this.grpbScad.Controls.Add(this.nudAss);
            this.grpbScad.Controls.Add(this.dtpScadAss);
            this.grpbScad.Controls.Add(this.nudBollo);
            this.grpbScad.Controls.Add(this.label13);
            this.grpbScad.Controls.Add(this.dtpScadBollo);
            this.grpbScad.Controls.Add(this.label12);
            this.grpbScad.Controls.Add(this.label11);
            this.grpbScad.Controls.Add(this.label10);
            this.grpbScad.Location = new System.Drawing.Point(14, 153);
            this.grpbScad.Name = "grpbScad";
            this.grpbScad.Size = new System.Drawing.Size(700, 92);
            this.grpbScad.TabIndex = 101;
            this.grpbScad.TabStop = false;
            this.grpbScad.Text = "Scadenze";
            // 
            // cmbFreqAss
            // 
            this.cmbFreqAss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFreqAss.FormattingEnabled = true;
            this.cmbFreqAss.Items.AddRange(new object[] {
            "",
            "Annuale",
            "Semestrale",
            "Trimestrale",
            "Quadrimestrale"});
            this.cmbFreqAss.Location = new System.Drawing.Point(427, 62);
            this.cmbFreqAss.Name = "cmbFreqAss";
            this.cmbFreqAss.Size = new System.Drawing.Size(137, 21);
            this.cmbFreqAss.TabIndex = 20;
            // 
            // cmbFreqBollo
            // 
            this.cmbFreqBollo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFreqBollo.FormattingEnabled = true;
            this.cmbFreqBollo.Items.AddRange(new object[] {
            "",
            "Annuale",
            "Semestrale",
            "Trimestrale",
            "Quadrimestrale"});
            this.cmbFreqBollo.Location = new System.Drawing.Point(427, 33);
            this.cmbFreqBollo.Name = "cmbFreqBollo";
            this.cmbFreqBollo.Size = new System.Drawing.Size(137, 21);
            this.cmbFreqBollo.TabIndex = 16;
            // 
            // txtAss
            // 
            this.txtAss.Location = new System.Drawing.Point(81, 64);
            this.txtAss.MaxLength = 50;
            this.txtAss.Name = "txtAss";
            this.txtAss.Size = new System.Drawing.Size(201, 20);
            this.txtAss.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(468, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Frequenza";
            // 
            // nudAss
            // 
            this.nudAss.DecimalPlaces = 2;
            this.nudAss.Location = new System.Drawing.Point(601, 62);
            this.nudAss.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudAss.Name = "nudAss";
            this.nudAss.Size = new System.Drawing.Size(84, 20);
            this.nudAss.TabIndex = 21;
            this.nudAss.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpScadAss
            // 
            this.dtpScadAss.Checked = false;
            this.dtpScadAss.CustomFormat = "dd/MM/yyyy";
            this.dtpScadAss.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpScadAss.Location = new System.Drawing.Point(294, 63);
            this.dtpScadAss.Name = "dtpScadAss";
            this.dtpScadAss.ShowCheckBox = true;
            this.dtpScadAss.Size = new System.Drawing.Size(97, 20);
            this.dtpScadAss.TabIndex = 19;
            // 
            // nudBollo
            // 
            this.nudBollo.DecimalPlaces = 2;
            this.nudBollo.Location = new System.Drawing.Point(601, 34);
            this.nudBollo.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudBollo.Name = "nudBollo";
            this.nudBollo.Size = new System.Drawing.Size(84, 20);
            this.nudBollo.TabIndex = 17;
            this.nudBollo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(618, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Importo";
            // 
            // dtpScadBollo
            // 
            this.dtpScadBollo.Checked = false;
            this.dtpScadBollo.CustomFormat = "dd/MM/yyyy";
            this.dtpScadBollo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpScadBollo.Location = new System.Drawing.Point(294, 34);
            this.dtpScadBollo.Name = "dtpScadBollo";
            this.dtpScadBollo.ShowCheckBox = true;
            this.dtpScadBollo.Size = new System.Drawing.Size(97, 20);
            this.dtpScadBollo.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Assicurazione";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Bollo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(300, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Data Scadenza";
            // 
            // dtpDataImm
            // 
            this.dtpDataImm.Checked = false;
            this.dtpDataImm.CustomFormat = "dd/MM/yyyy";
            this.dtpDataImm.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataImm.Location = new System.Drawing.Point(321, 86);
            this.dtpDataImm.Name = "dtpDataImm";
            this.dtpDataImm.ShowCheckBox = true;
            this.dtpDataImm.Size = new System.Drawing.Size(106, 20);
            this.dtpDataImm.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 13);
            this.label9.TabIndex = 99;
            this.label9.Text = "Data Immatricolazione:";
            // 
            // dtpDataAcq
            // 
            this.dtpDataAcq.Checked = false;
            this.dtpDataAcq.CustomFormat = "dd/MM/yyyy";
            this.dtpDataAcq.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataAcq.Location = new System.Drawing.Point(92, 86);
            this.dtpDataAcq.Name = "dtpDataAcq";
            this.dtpDataAcq.ShowCheckBox = true;
            this.dtpDataAcq.Size = new System.Drawing.Size(101, 20);
            this.dtpDataAcq.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 97;
            this.label8.Text = "Data Acquisto:";
            // 
            // txtTarga
            // 
            this.txtTarga.Location = new System.Drawing.Point(59, 28);
            this.txtTarga.MaxLength = 10;
            this.txtTarga.Name = "txtTarga";
            this.txtTarga.Size = new System.Drawing.Size(114, 20);
            this.txtTarga.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "Targa:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(551, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 96;
            this.label6.Text = "Portata:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 90;
            this.label3.Text = "Telaio:";
            // 
            // txtModello
            // 
            this.txtModello.Location = new System.Drawing.Point(332, 57);
            this.txtModello.MaxLength = 20;
            this.txtModello.Name = "txtModello";
            this.txtModello.Size = new System.Drawing.Size(201, 20);
            this.txtModello.TabIndex = 8;
            // 
            // txtTelaio
            // 
            this.txtTelaio.Location = new System.Drawing.Point(332, 28);
            this.txtTelaio.MaxLength = 30;
            this.txtTelaio.Name = "txtTelaio";
            this.txtTelaio.Size = new System.Drawing.Size(145, 20);
            this.txtTelaio.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(279, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 94;
            this.label5.Text = "Modello:";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(59, 57);
            this.txtMarca.MaxLength = 20;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(201, 20);
            this.txtMarca.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 92;
            this.label4.Text = "Marca:";
            // 
            // grpTerzi
            // 
            this.grpTerzi.Controls.Add(this.comboBox1);
            this.grpTerzi.Controls.Add(this.label21);
            this.grpTerzi.Enabled = false;
            this.grpTerzi.Location = new System.Drawing.Point(211, 40);
            this.grpTerzi.Name = "grpTerzi";
            this.grpTerzi.Size = new System.Drawing.Size(521, 48);
            this.grpTerzi.TabIndex = 89;
            this.grpTerzi.TabStop = false;
            this.grpTerzi.Text = "Dettaglio automezzo di terzi:";
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(98, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(175, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Enabled = false;
            this.label21.Location = new System.Drawing.Point(41, 21);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(51, 13);
            this.label21.TabIndex = 1;
            this.label21.Text = "Fornitore:";
            // 
            // frmModAutomezzi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 511);
            this.Controls.Add(this.grpTerzi);
            this.Controls.Add(this.grpbProprio);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.bttEsci);
            this.Controls.Add(this.bttElimina);
            this.Controls.Add(this.bttAnnulla);
            this.Controls.Add(this.bttSave);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.rdbPropTerzi);
            this.Controls.Add(this.rdbProprio);
            this.Controls.Add(this.lblCodice);
            this.Controls.Add(this.label1);
            this.Name = "frmModAutomezzi";
            this.ShowIcon = false;
            this.Text = "Anagrafica Automezzi - Nuovo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmModAutomezzi_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmModAutomezzi_FormClosed);
            this.Load += new System.EventHandler(this.frmModAutomezzi_Load);
            this.Shown += new System.EventHandler(this.frmModAutomezzi_Shown);
            this.grpbProprio.ResumeLayout(false);
            this.grpbProprio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortata)).EndInit();
            this.grpbScad.ResumeLayout(false);
            this.grpbScad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBollo)).EndInit();
            this.grpTerzi.ResumeLayout(false);
            this.grpTerzi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCodice;
        private System.Windows.Forms.RadioButton rdbPropTerzi;
        private System.Windows.Forms.RadioButton rdbProprio;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button bttEsci;
        private System.Windows.Forms.Button bttElimina;
        private System.Windows.Forms.Button bttAnnulla;
        private System.Windows.Forms.Button bttSave;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.GroupBox grpbProprio;
        private System.Windows.Forms.NumericUpDown nudKw;
        private System.Windows.Forms.NumericUpDown nudKM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudPortata;
        private System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox grpbScad;
        private System.Windows.Forms.TextBox txtAss;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nudAss;
        private System.Windows.Forms.DateTimePicker dtpScadAss;
        private System.Windows.Forms.NumericUpDown nudBollo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpScadBollo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpDataImm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDataAcq;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtModello;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTelaio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTarga;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpTerzi;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbFreqAss;
        private System.Windows.Forms.ComboBox cmbFreqBollo;
    }
}