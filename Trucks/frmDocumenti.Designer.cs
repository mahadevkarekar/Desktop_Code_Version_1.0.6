namespace Trucks
{
    partial class frmDocumenti
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      this.chkFat = new System.Windows.Forms.CheckBox();
      this.chkNDC = new System.Windows.Forms.CheckBox();
      this.chkDDT = new System.Windows.Forms.CheckBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cmbCli = new System.Windows.Forms.ComboBox();
      this.dtpDataAl = new System.Windows.Forms.DateTimePicker();
      this.label9 = new System.Windows.Forms.Label();
      this.dtpDataDal = new System.Windows.Forms.DateTimePicker();
      this.label8 = new System.Windows.Forms.Label();
      this.txtDTT = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.cmbTrA = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.cmbTrDa = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtDescr = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.cmbCodArt = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.dgvResult = new System.Windows.Forms.DataGridView();
      this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.ColCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColCodArt = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColTrDa = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColTrA = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColDDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColData = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColFurg = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColQta = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colPrezzo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColTot = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.bttClear = new System.Windows.Forms.Button();
      this.bttFind = new System.Windows.Forms.Button();
      this.bttNuovaFat = new System.Windows.Forms.Button();
      this.bttEsci = new System.Windows.Forms.Button();
      this.bttElimina = new System.Windows.Forms.Button();
      this.bttModifica = new System.Windows.Forms.Button();
      this.bttStampa = new System.Windows.Forms.Button();
      this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
      this.chkNDB = new System.Windows.Forms.CheckBox();
      this.bttNuovaNDC = new System.Windows.Forms.Button();
      this.label11 = new System.Windows.Forms.Label();
      this.lblNumDoc = new System.Windows.Forms.Label();
      this.lblTotKm = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.lblTotImporto = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.txtCoeff = new System.Windows.Forms.TextBox();
      this.cmbTruck = new System.Windows.Forms.ComboBox();
      this.label12 = new System.Windows.Forms.Label();
      this.cmbXml = new System.Windows.Forms.ComboBox();
      this.label14 = new System.Windows.Forms.Label();
      this.cmbAnno = new System.Windows.Forms.ComboBox();
      this.label17 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
      this.SuspendLayout();
      // 
      // chkFat
      // 
      this.chkFat.AutoSize = true;
      this.chkFat.Location = new System.Drawing.Point(127, 8);
      this.chkFat.Name = "chkFat";
      this.chkFat.Size = new System.Drawing.Size(88, 17);
      this.chkFat.TabIndex = 0;
      this.chkFat.Text = "[FAT] Fatture";
      this.chkFat.UseVisualStyleBackColor = true;
      // 
      // chkNDC
      // 
      this.chkNDC.AutoSize = true;
      this.chkNDC.Location = new System.Drawing.Point(219, 8);
      this.chkNDC.Name = "chkNDC";
      this.chkNDC.Size = new System.Drawing.Size(128, 17);
      this.chkNDC.TabIndex = 1;
      this.chkNDC.Text = "[NDC] Note di Credito";
      this.chkNDC.UseVisualStyleBackColor = true;
      // 
      // chkDDT
      // 
      this.chkDDT.AutoSize = true;
      this.chkDDT.Enabled = false;
      this.chkDDT.Location = new System.Drawing.Point(353, 8);
      this.chkDDT.Name = "chkDDT";
      this.chkDDT.Size = new System.Drawing.Size(81, 17);
      this.chkDDT.TabIndex = 2;
      this.chkDDT.Text = "[DDT] DDT";
      this.chkDDT.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(116, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Tipoologia Documenti: ";
      // 
      // cmbCli
      // 
      this.cmbCli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbCli.FormattingEnabled = true;
      this.cmbCli.Location = new System.Drawing.Point(79, 36);
      this.cmbCli.Name = "cmbCli";
      this.cmbCli.Size = new System.Drawing.Size(296, 21);
      this.cmbCli.TabIndex = 4;
      // 
      // dtpDataAl
      // 
      this.dtpDataAl.Checked = false;
      this.dtpDataAl.CustomFormat = "dd/MM/yyyy";
      this.dtpDataAl.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpDataAl.Location = new System.Drawing.Point(401, 122);
      this.dtpDataAl.Name = "dtpDataAl";
      this.dtpDataAl.ShowCheckBox = true;
      this.dtpDataAl.Size = new System.Drawing.Size(106, 20);
      this.dtpDataAl.TabIndex = 12;
      this.dtpDataAl.ValueChanged += new System.EventHandler(this.dtpDataAl_ValueChanged);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(383, 126);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(18, 13);
      this.label9.TabIndex = 60;
      this.label9.Text = "al:";
      // 
      // dtpDataDal
      // 
      this.dtpDataDal.Checked = false;
      this.dtpDataDal.CustomFormat = "dd/MM/yyyy";
      this.dtpDataDal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpDataDal.Location = new System.Drawing.Point(268, 122);
      this.dtpDataDal.Name = "dtpDataDal";
      this.dtpDataDal.ShowCheckBox = true;
      this.dtpDataDal.Size = new System.Drawing.Size(101, 20);
      this.dtpDataDal.TabIndex = 11;
      this.dtpDataDal.ValueChanged += new System.EventHandler(this.dtpDataDal_ValueChanged);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(212, 126);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(50, 13);
      this.label8.TabIndex = 58;
      this.label8.Text = "Data dal:";
      // 
      // txtDTT
      // 
      this.txtDTT.Location = new System.Drawing.Point(481, 93);
      this.txtDTT.Name = "txtDTT";
      this.txtDTT.Size = new System.Drawing.Size(237, 20);
      this.txtDTT.TabIndex = 9;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(398, 97);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(82, 13);
      this.label6.TabIndex = 56;
      this.label6.Text = "N. DDT Cliente:";
      // 
      // cmbTrA
      // 
      this.cmbTrA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbTrA.FormattingEnabled = true;
      this.cmbTrA.Location = new System.Drawing.Point(268, 94);
      this.cmbTrA.Name = "cmbTrA";
      this.cmbTrA.Size = new System.Drawing.Size(124, 21);
      this.cmbTrA.TabIndex = 8;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(246, 97);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(16, 13);
      this.label5.TabIndex = 54;
      this.label5.Text = "a:";
      // 
      // cmbTrDa
      // 
      this.cmbTrDa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbTrDa.FormattingEnabled = true;
      this.cmbTrDa.Location = new System.Drawing.Point(79, 94);
      this.cmbTrDa.Name = "cmbTrDa";
      this.cmbTrDa.Size = new System.Drawing.Size(124, 21);
      this.cmbTrDa.TabIndex = 7;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(9, 97);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(53, 13);
      this.label4.TabIndex = 52;
      this.label4.Text = "Tratta da:";
      // 
      // txtDescr
      // 
      this.txtDescr.Location = new System.Drawing.Point(268, 66);
      this.txtDescr.Name = "txtDescr";
      this.txtDescr.Size = new System.Drawing.Size(450, 20);
      this.txtDescr.TabIndex = 6;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(209, 69);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(65, 13);
      this.label3.TabIndex = 50;
      this.label3.Text = "Descrizione:";
      // 
      // cmbCodArt
      // 
      this.cmbCodArt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbCodArt.FormattingEnabled = true;
      this.cmbCodArt.Location = new System.Drawing.Point(79, 66);
      this.cmbCodArt.Name = "cmbCodArt";
      this.cmbCodArt.Size = new System.Drawing.Size(124, 21);
      this.cmbCodArt.TabIndex = 5;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(9, 69);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(70, 13);
      this.label7.TabIndex = 48;
      this.label7.Text = "Cod. Articolo:";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(9, 39);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(42, 13);
      this.label10.TabIndex = 47;
      this.label10.Text = "Cliente:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(9, 124);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(66, 13);
      this.label2.TabIndex = 63;
      this.label2.Text = "Coefficiente:";
      // 
      // dgvResult
      // 
      this.dgvResult.AllowUserToAddRows = false;
      this.dgvResult.AllowUserToDeleteRows = false;
      this.dgvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
      this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColChk,
            this.ColCliente,
            this.ColCodArt,
            this.ColDescr,
            this.ColTrDa,
            this.ColTrA,
            this.ColKM,
            this.ColDDT,
            this.ColData,
            this.ColFurg,
            this.ColUM,
            this.ColQta,
            this.colPrezzo,
            this.ColTot});
      this.dgvResult.Location = new System.Drawing.Point(12, 155);
      this.dgvResult.MultiSelect = false;
      this.dgvResult.Name = "dgvResult";
      this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvResult.ShowEditingIcon = false;
      this.dgvResult.Size = new System.Drawing.Size(831, 142);
      this.dgvResult.TabIndex = 16;
      this.dgvResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellContentClick);
      this.dgvResult.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellContentDoubleClick);
      this.dgvResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellDoubleClick);
      // 
      // ColID
      // 
      this.ColID.HeaderText = "ID";
      this.ColID.Name = "ColID";
      this.ColID.Visible = false;
      // 
      // ColChk
      // 
      this.ColChk.HeaderText = "";
      this.ColChk.Name = "ColChk";
      this.ColChk.Visible = false;
      this.ColChk.Width = 20;
      // 
      // ColCliente
      // 
      this.ColCliente.HeaderText = "Cliente";
      this.ColCliente.Name = "ColCliente";
      this.ColCliente.Visible = false;
      this.ColCliente.Width = 120;
      // 
      // ColCodArt
      // 
      this.ColCodArt.HeaderText = "Cod. Art.";
      this.ColCodArt.Name = "ColCodArt";
      this.ColCodArt.Visible = false;
      this.ColCodArt.Width = 75;
      // 
      // ColDescr
      // 
      this.ColDescr.HeaderText = "Descrizione";
      this.ColDescr.Name = "ColDescr";
      this.ColDescr.Visible = false;
      this.ColDescr.Width = 150;
      // 
      // ColTrDa
      // 
      this.ColTrDa.HeaderText = "Da";
      this.ColTrDa.Name = "ColTrDa";
      this.ColTrDa.Visible = false;
      // 
      // ColTrA
      // 
      this.ColTrA.HeaderText = "A";
      this.ColTrA.Name = "ColTrA";
      this.ColTrA.Visible = false;
      // 
      // ColKM
      // 
      this.ColKM.HeaderText = "KM";
      this.ColKM.Name = "ColKM";
      this.ColKM.Visible = false;
      this.ColKM.Width = 40;
      // 
      // ColDDT
      // 
      this.ColDDT.HeaderText = "N. DDT";
      this.ColDDT.Name = "ColDDT";
      this.ColDDT.Visible = false;
      // 
      // ColData
      // 
      this.ColData.HeaderText = "Data";
      this.ColData.Name = "ColData";
      this.ColData.Visible = false;
      this.ColData.Width = 70;
      // 
      // ColFurg
      // 
      this.ColFurg.HeaderText = "Furgone";
      this.ColFurg.Name = "ColFurg";
      this.ColFurg.Visible = false;
      // 
      // ColUM
      // 
      this.ColUM.HeaderText = "U.M.";
      this.ColUM.Name = "ColUM";
      this.ColUM.Visible = false;
      this.ColUM.Width = 30;
      // 
      // ColQta
      // 
      this.ColQta.HeaderText = "Qta";
      this.ColQta.Name = "ColQta";
      this.ColQta.Visible = false;
      this.ColQta.Width = 30;
      // 
      // colPrezzo
      // 
      this.colPrezzo.HeaderText = "Prezzo";
      this.colPrezzo.Name = "colPrezzo";
      this.colPrezzo.Visible = false;
      this.colPrezzo.Width = 70;
      // 
      // ColTot
      // 
      this.ColTot.HeaderText = "Totale";
      this.ColTot.Name = "ColTot";
      this.ColTot.Visible = false;
      // 
      // bttClear
      // 
      this.bttClear.Location = new System.Drawing.Point(773, 46);
      this.bttClear.Name = "bttClear";
      this.bttClear.Size = new System.Drawing.Size(70, 27);
      this.bttClear.TabIndex = 15;
      this.bttClear.Text = "Pulisci";
      this.bttClear.UseVisualStyleBackColor = true;
      this.bttClear.Click += new System.EventHandler(this.bttClear_Click);
      // 
      // bttFind
      // 
      this.bttFind.Location = new System.Drawing.Point(773, 12);
      this.bttFind.Name = "bttFind";
      this.bttFind.Size = new System.Drawing.Size(70, 27);
      this.bttFind.TabIndex = 14;
      this.bttFind.Text = "Cerca";
      this.bttFind.UseVisualStyleBackColor = true;
      this.bttFind.Click += new System.EventHandler(this.bttFind_Click);
      // 
      // bttNuovaFat
      // 
      this.bttNuovaFat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.bttNuovaFat.Location = new System.Drawing.Point(291, 340);
      this.bttNuovaFat.Name = "bttNuovaFat";
      this.bttNuovaFat.Size = new System.Drawing.Size(84, 27);
      this.bttNuovaFat.TabIndex = 21;
      this.bttNuovaFat.Text = "Nuova Fattura";
      this.bttNuovaFat.UseVisualStyleBackColor = true;
      this.bttNuovaFat.Click += new System.EventHandler(this.bttNuovaFat_Click);
      // 
      // bttEsci
      // 
      this.bttEsci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.bttEsci.Location = new System.Drawing.Point(773, 340);
      this.bttEsci.Name = "bttEsci";
      this.bttEsci.Size = new System.Drawing.Size(70, 27);
      this.bttEsci.TabIndex = 25;
      this.bttEsci.Text = "Esci";
      this.bttEsci.UseVisualStyleBackColor = true;
      this.bttEsci.Click += new System.EventHandler(this.bttEsci_Click);
      // 
      // bttElimina
      // 
      this.bttElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.bttElimina.Location = new System.Drawing.Point(636, 340);
      this.bttElimina.Name = "bttElimina";
      this.bttElimina.Size = new System.Drawing.Size(70, 27);
      this.bttElimina.TabIndex = 24;
      this.bttElimina.Text = "Elimina";
      this.bttElimina.UseVisualStyleBackColor = true;
      this.bttElimina.Click += new System.EventHandler(this.bttElimina_Click);
      // 
      // bttModifica
      // 
      this.bttModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.bttModifica.Location = new System.Drawing.Point(541, 340);
      this.bttModifica.Name = "bttModifica";
      this.bttModifica.Size = new System.Drawing.Size(70, 27);
      this.bttModifica.TabIndex = 23;
      this.bttModifica.Text = "Modifica";
      this.bttModifica.UseVisualStyleBackColor = true;
      this.bttModifica.Click += new System.EventHandler(this.bttModifica_Click);
      // 
      // bttStampa
      // 
      this.bttStampa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.bttStampa.Location = new System.Drawing.Point(12, 340);
      this.bttStampa.Name = "bttStampa";
      this.bttStampa.Size = new System.Drawing.Size(70, 27);
      this.bttStampa.TabIndex = 20;
      this.bttStampa.Text = "Stampa";
      this.bttStampa.UseVisualStyleBackColor = true;
      this.bttStampa.Click += new System.EventHandler(this.bttStampa_Click);
      // 
      // chkNDB
      // 
      this.chkNDB.AutoSize = true;
      this.chkNDB.Enabled = false;
      this.chkNDB.Location = new System.Drawing.Point(440, 8);
      this.chkNDB.Name = "chkNDB";
      this.chkNDB.Size = new System.Drawing.Size(126, 17);
      this.chkNDB.TabIndex = 3;
      this.chkNDB.Text = "[NDB] Note di Debito";
      this.chkNDB.UseVisualStyleBackColor = true;
      this.chkNDB.Visible = false;
      // 
      // bttNuovaNDC
      // 
      this.bttNuovaNDC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.bttNuovaNDC.Location = new System.Drawing.Point(393, 340);
      this.bttNuovaNDC.Name = "bttNuovaNDC";
      this.bttNuovaNDC.Size = new System.Drawing.Size(128, 27);
      this.bttNuovaNDC.TabIndex = 22;
      this.bttNuovaNDC.Text = "Nuova Nota di Credito";
      this.bttNuovaNDC.UseVisualStyleBackColor = true;
      this.bttNuovaNDC.Click += new System.EventHandler(this.bttNuovaNDC_Click);
      // 
      // label11
      // 
      this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(12, 305);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(101, 13);
      this.label11.TabIndex = 75;
      this.label11.Text = "Numero Documenti:";
      // 
      // lblNumDoc
      // 
      this.lblNumDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblNumDoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblNumDoc.Location = new System.Drawing.Point(119, 304);
      this.lblNumDoc.Name = "lblNumDoc";
      this.lblNumDoc.Size = new System.Drawing.Size(58, 21);
      this.lblNumDoc.TabIndex = 17;
      this.lblNumDoc.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // lblTotKm
      // 
      this.lblTotKm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lblTotKm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblTotKm.Location = new System.Drawing.Point(742, 303);
      this.lblTotKm.Name = "lblTotKm";
      this.lblTotKm.Size = new System.Drawing.Size(101, 21);
      this.lblTotKm.TabIndex = 19;
      this.lblTotKm.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label13
      // 
      this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(678, 304);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(58, 13);
      this.label13.TabIndex = 77;
      this.label13.Text = "Totale Km:";
      // 
      // lblTotImporto
      // 
      this.lblTotImporto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lblTotImporto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblTotImporto.Location = new System.Drawing.Point(523, 303);
      this.lblTotImporto.Name = "lblTotImporto";
      this.lblTotImporto.Size = new System.Drawing.Size(107, 21);
      this.lblTotImporto.TabIndex = 18;
      this.lblTotImporto.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label15
      // 
      this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(439, 304);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(78, 13);
      this.label15.TabIndex = 79;
      this.label15.Text = "Totale Importo:";
      // 
      // label16
      // 
      this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label16.AutoSize = true;
      this.label16.Location = new System.Drawing.Point(635, 304);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(13, 13);
      this.label16.TabIndex = 81;
      this.label16.Text = "€";
      // 
      // txtCoeff
      // 
      this.txtCoeff.Location = new System.Drawing.Point(79, 121);
      this.txtCoeff.Name = "txtCoeff";
      this.txtCoeff.Size = new System.Drawing.Size(124, 20);
      this.txtCoeff.TabIndex = 10;
      this.txtCoeff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtCoeff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCoeff_KeyPress);
      // 
      // cmbTruck
      // 
      this.cmbTruck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbTruck.FormattingEnabled = true;
      this.cmbTruck.Location = new System.Drawing.Point(585, 122);
      this.cmbTruck.Name = "cmbTruck";
      this.cmbTruck.Size = new System.Drawing.Size(133, 21);
      this.cmbTruck.TabIndex = 13;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(520, 124);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(62, 13);
      this.label12.TabIndex = 82;
      this.label12.Text = "Automezzo:";
      // 
      // cmbXml
      // 
      this.cmbXml.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbXml.FormattingEnabled = true;
      this.cmbXml.Items.AddRange(new object[] {
            " ",
            "Si",
            "No"});
      this.cmbXml.Location = new System.Drawing.Point(773, 92);
      this.cmbXml.Name = "cmbXml";
      this.cmbXml.Size = new System.Drawing.Size(70, 21);
      this.cmbXml.TabIndex = 83;
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(735, 97);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(32, 13);
      this.label14.TabIndex = 84;
      this.label14.Text = "XML:";
      // 
      // cmbAnno
      // 
      this.cmbAnno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbAnno.FormattingEnabled = true;
      this.cmbAnno.Items.AddRange(new object[] {
            " ",
            "Si",
            "No"});
      this.cmbAnno.Location = new System.Drawing.Point(773, 122);
      this.cmbAnno.Name = "cmbAnno";
      this.cmbAnno.Size = new System.Drawing.Size(70, 21);
      this.cmbAnno.TabIndex = 85;
      this.cmbAnno.SelectedValueChanged += new System.EventHandler(this.cmbAnno_SelectedValueChanged);
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Location = new System.Drawing.Point(735, 124);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(35, 13);
      this.label17.TabIndex = 86;
      this.label17.Text = "Anno:";
      // 
      // frmDocumenti
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(855, 374);
      this.Controls.Add(this.cmbAnno);
      this.Controls.Add(this.label17);
      this.Controls.Add(this.cmbXml);
      this.Controls.Add(this.label14);
      this.Controls.Add(this.cmbTruck);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.label16);
      this.Controls.Add(this.lblTotImporto);
      this.Controls.Add(this.label15);
      this.Controls.Add(this.lblTotKm);
      this.Controls.Add(this.label13);
      this.Controls.Add(this.lblNumDoc);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.bttNuovaNDC);
      this.Controls.Add(this.chkNDB);
      this.Controls.Add(this.bttNuovaFat);
      this.Controls.Add(this.bttEsci);
      this.Controls.Add(this.bttElimina);
      this.Controls.Add(this.bttModifica);
      this.Controls.Add(this.bttStampa);
      this.Controls.Add(this.bttClear);
      this.Controls.Add(this.bttFind);
      this.Controls.Add(this.dgvResult);
      this.Controls.Add(this.txtCoeff);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cmbCli);
      this.Controls.Add(this.dtpDataAl);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.dtpDataDal);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.txtDTT);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.cmbTrA);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.cmbTrDa);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtDescr);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.cmbCodArt);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.chkDDT);
      this.Controls.Add(this.chkNDC);
      this.Controls.Add(this.chkFat);
      this.Name = "frmDocumenti";
      this.ShowIcon = false;
      this.Text = "Documenti";
      this.Load += new System.EventHandler(this.frmDocumenti_Load);
      ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkFat;
        private System.Windows.Forms.CheckBox chkNDC;
        private System.Windows.Forms.CheckBox chkDDT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCli;
        private System.Windows.Forms.DateTimePicker dtpDataAl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDataDal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDTT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTrA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTrDa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCodArt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button bttClear;
        private System.Windows.Forms.Button bttFind;
        private System.Windows.Forms.Button bttNuovaFat;
        private System.Windows.Forms.Button bttEsci;
        private System.Windows.Forms.Button bttElimina;
        private System.Windows.Forms.Button bttModifica;
        private System.Windows.Forms.Button bttStampa;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.CheckBox chkNDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodArt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTrDa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTrA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFurg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrezzo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTot;
        private System.Windows.Forms.Button bttNuovaNDC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblNumDoc;
        private System.Windows.Forms.Label lblTotKm;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTotImporto;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCoeff;
        private System.Windows.Forms.ComboBox cmbTruck;
        private System.Windows.Forms.Label label12;
    private System.Windows.Forms.ComboBox cmbXml;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.ComboBox cmbAnno;
    private System.Windows.Forms.Label label17;
  }
}