namespace Trucks
{
    partial class frmDocViaggi
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.cmbCodArt = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtDescr = new System.Windows.Forms.TextBox();
      this.cmbTrDa = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtDTT = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.cmbAutom = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.dtpDataAl = new System.Windows.Forms.DateTimePicker();
      this.label9 = new System.Windows.Forms.Label();
      this.dtpDataDal = new System.Windows.Forms.DateTimePicker();
      this.label8 = new System.Windows.Forms.Label();
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
      this.bttNuovo = new System.Windows.Forms.Button();
      this.bttEsci = new System.Windows.Forms.Button();
      this.bttElimina = new System.Windows.Forms.Button();
      this.bttModifica = new System.Windows.Forms.Button();
      this.bttStampa = new System.Windows.Forms.Button();
      this.bttClear = new System.Windows.Forms.Button();
      this.bttFind = new System.Windows.Forms.Button();
      this.bttGenFatt = new System.Windows.Forms.Button();
      this.cmbCli = new System.Windows.Forms.ComboBox();
      this.cmbTrA = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
      this.label10 = new System.Windows.Forms.Label();
      this.nudSelRow = new System.Windows.Forms.NumericUpDown();
      this.chkSelAll = new System.Windows.Forms.CheckBox();
      this.bttSelRow = new System.Windows.Forms.Button();
      this.label11 = new System.Windows.Forms.Label();
      this.rdbTutti = new System.Windows.Forms.RadioButton();
      this.rdbNoFatt = new System.Windows.Forms.RadioButton();
      this.rdbFatt = new System.Windows.Forms.RadioButton();
      this.label16 = new System.Windows.Forms.Label();
      this.lblTotImporto = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.lblTotKm = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.bttnImporta = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudSelRow)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(-1, 11);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(42, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Cliente:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(-1, 37);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(70, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Cod. Articolo:";
      // 
      // cmbCodArt
      // 
      this.cmbCodArt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbCodArt.FormattingEnabled = true;
      this.cmbCodArt.Location = new System.Drawing.Point(69, 34);
      this.cmbCodArt.Name = "cmbCodArt";
      this.cmbCodArt.Size = new System.Drawing.Size(137, 21);
      this.cmbCodArt.TabIndex = 1;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(223, 38);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(65, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Descrizione:";
      // 
      // txtDescr
      // 
      this.txtDescr.Location = new System.Drawing.Point(294, 35);
      this.txtDescr.Name = "txtDescr";
      this.txtDescr.Size = new System.Drawing.Size(393, 20);
      this.txtDescr.TabIndex = 2;
      this.txtDescr.TextChanged += new System.EventHandler(this.txtDescr_TextChanged);
      // 
      // cmbTrDa
      // 
      this.cmbTrDa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbTrDa.FormattingEnabled = true;
      this.cmbTrDa.Location = new System.Drawing.Point(69, 61);
      this.cmbTrDa.Name = "cmbTrDa";
      this.cmbTrDa.Size = new System.Drawing.Size(137, 21);
      this.cmbTrDa.TabIndex = 3;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(-1, 65);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(53, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Tratta da:";
      // 
      // txtDTT
      // 
      this.txtDTT.Location = new System.Drawing.Point(479, 62);
      this.txtDTT.Name = "txtDTT";
      this.txtDTT.Size = new System.Drawing.Size(208, 20);
      this.txtDTT.TabIndex = 5;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(434, 65);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(39, 13);
      this.label6.TabIndex = 10;
      this.label6.Text = "N. ddt:";
      this.label6.Click += new System.EventHandler(this.label6_Click);
      // 
      // cmbAutom
      // 
      this.cmbAutom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbAutom.FormattingEnabled = true;
      this.cmbAutom.Location = new System.Drawing.Point(69, 88);
      this.cmbAutom.Name = "cmbAutom";
      this.cmbAutom.Size = new System.Drawing.Size(137, 21);
      this.cmbAutom.TabIndex = 6;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(-1, 92);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(62, 13);
      this.label7.TabIndex = 12;
      this.label7.Text = "Automezzo:";
      // 
      // dtpDataAl
      // 
      this.dtpDataAl.Checked = false;
      this.dtpDataAl.CustomFormat = "dd/MM/yyyy";
      this.dtpDataAl.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpDataAl.Location = new System.Drawing.Point(479, 90);
      this.dtpDataAl.Name = "dtpDataAl";
      this.dtpDataAl.ShowCheckBox = true;
      this.dtpDataAl.Size = new System.Drawing.Size(106, 20);
      this.dtpDataAl.TabIndex = 8;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(455, 92);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(18, 13);
      this.label9.TabIndex = 20;
      this.label9.Text = "al:";
      // 
      // dtpDataDal
      // 
      this.dtpDataDal.Checked = false;
      this.dtpDataDal.CustomFormat = "dd/MM/yyyy";
      this.dtpDataDal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpDataDal.Location = new System.Drawing.Point(294, 89);
      this.dtpDataDal.Name = "dtpDataDal";
      this.dtpDataDal.ShowCheckBox = true;
      this.dtpDataDal.Size = new System.Drawing.Size(101, 20);
      this.dtpDataDal.TabIndex = 7;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(238, 92);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(50, 13);
      this.label8.TabIndex = 18;
      this.label8.Text = "Data dal:";
      // 
      // dgvResult
      // 
      this.dgvResult.AllowUserToAddRows = false;
      this.dgvResult.AllowUserToDeleteRows = false;
      this.dgvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
      this.dgvResult.Location = new System.Drawing.Point(1, 172);
      this.dgvResult.MultiSelect = false;
      this.dgvResult.Name = "dgvResult";
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle6.Format = "N0";
      dataGridViewCellStyle6.NullValue = null;
      dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgvResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
      this.dgvResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvResult.ShowEditingIcon = false;
      this.dgvResult.Size = new System.Drawing.Size(826, 130);
      this.dgvResult.TabIndex = 17;
      this.dgvResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellContentClick);
      this.dgvResult.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellContentDoubleClick);
      this.dgvResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellDoubleClick);
      this.dgvResult.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvResult_DataBindingComplete);
      this.dgvResult.Sorted += new System.EventHandler(this.dgvResult_Sorted);
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
      dataGridViewCellStyle5.Format = "N3";
      dataGridViewCellStyle5.NullValue = null;
      this.ColQta.DefaultCellStyle = dataGridViewCellStyle5;
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
      // bttNuovo
      // 
      this.bttNuovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.bttNuovo.Location = new System.Drawing.Point(430, 335);
      this.bttNuovo.Name = "bttNuovo";
      this.bttNuovo.Size = new System.Drawing.Size(70, 27);
      this.bttNuovo.TabIndex = 20;
      this.bttNuovo.Text = "Nuovo";
      this.bttNuovo.UseVisualStyleBackColor = true;
      this.bttNuovo.Click += new System.EventHandler(this.bttNuovo_Click);
      // 
      // bttEsci
      // 
      this.bttEsci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.bttEsci.Location = new System.Drawing.Point(757, 335);
      this.bttEsci.Name = "bttEsci";
      this.bttEsci.Size = new System.Drawing.Size(70, 27);
      this.bttEsci.TabIndex = 23;
      this.bttEsci.Text = "Esci";
      this.bttEsci.UseVisualStyleBackColor = true;
      this.bttEsci.Click += new System.EventHandler(this.bttEsci_Click);
      // 
      // bttElimina
      // 
      this.bttElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.bttElimina.Location = new System.Drawing.Point(620, 335);
      this.bttElimina.Name = "bttElimina";
      this.bttElimina.Size = new System.Drawing.Size(70, 27);
      this.bttElimina.TabIndex = 22;
      this.bttElimina.Text = "Elimina";
      this.bttElimina.UseVisualStyleBackColor = true;
      this.bttElimina.Click += new System.EventHandler(this.bttElimina_Click);
      // 
      // bttModifica
      // 
      this.bttModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.bttModifica.Location = new System.Drawing.Point(525, 335);
      this.bttModifica.Name = "bttModifica";
      this.bttModifica.Size = new System.Drawing.Size(70, 27);
      this.bttModifica.TabIndex = 21;
      this.bttModifica.Text = "Modifica";
      this.bttModifica.UseVisualStyleBackColor = true;
      this.bttModifica.Click += new System.EventHandler(this.bttModifica_Click);
      // 
      // bttStampa
      // 
      this.bttStampa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.bttStampa.Location = new System.Drawing.Point(2, 335);
      this.bttStampa.Name = "bttStampa";
      this.bttStampa.Size = new System.Drawing.Size(70, 27);
      this.bttStampa.TabIndex = 18;
      this.bttStampa.Text = "Stampa";
      this.bttStampa.UseVisualStyleBackColor = true;
      this.bttStampa.Click += new System.EventHandler(this.bttStampa_Click);
      // 
      // bttClear
      // 
      this.bttClear.Location = new System.Drawing.Point(717, 46);
      this.bttClear.Name = "bttClear";
      this.bttClear.Size = new System.Drawing.Size(70, 27);
      this.bttClear.TabIndex = 13;
      this.bttClear.Text = "Pulisci";
      this.bttClear.UseVisualStyleBackColor = true;
      this.bttClear.Click += new System.EventHandler(this.bttClear_Click);
      // 
      // bttFind
      // 
      this.bttFind.Location = new System.Drawing.Point(717, 12);
      this.bttFind.Name = "bttFind";
      this.bttFind.Size = new System.Drawing.Size(70, 27);
      this.bttFind.TabIndex = 12;
      this.bttFind.Text = "Cerca";
      this.bttFind.UseVisualStyleBackColor = true;
      this.bttFind.Click += new System.EventHandler(this.bttFind_Click);
      // 
      // bttGenFatt
      // 
      this.bttGenFatt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.bttGenFatt.Location = new System.Drawing.Point(97, 335);
      this.bttGenFatt.Name = "bttGenFatt";
      this.bttGenFatt.Size = new System.Drawing.Size(92, 27);
      this.bttGenFatt.TabIndex = 19;
      this.bttGenFatt.Text = "Genera Fattura";
      this.bttGenFatt.UseVisualStyleBackColor = true;
      this.bttGenFatt.Click += new System.EventHandler(this.bttGenFatt_Click);
      // 
      // cmbCli
      // 
      this.cmbCli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbCli.FormattingEnabled = true;
      this.cmbCli.Location = new System.Drawing.Point(69, 7);
      this.cmbCli.Name = "cmbCli";
      this.cmbCli.Size = new System.Drawing.Size(618, 21);
      this.cmbCli.TabIndex = 0;
      // 
      // cmbTrA
      // 
      this.cmbTrA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbTrA.FormattingEnabled = true;
      this.cmbTrA.Location = new System.Drawing.Point(294, 61);
      this.cmbTrA.Name = "cmbTrA";
      this.cmbTrA.Size = new System.Drawing.Size(124, 21);
      this.cmbTrA.TabIndex = 4;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(272, 65);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(16, 13);
      this.label5.TabIndex = 8;
      this.label5.Text = "a:";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.Location = new System.Drawing.Point(-2, 156);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(66, 13);
      this.label10.TabIndex = 47;
      this.label10.Text = "Num. Righe:";
      // 
      // nudSelRow
      // 
      this.nudSelRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.nudSelRow.Location = new System.Drawing.Point(69, 154);
      this.nudSelRow.Name = "nudSelRow";
      this.nudSelRow.Size = new System.Drawing.Size(48, 20);
      this.nudSelRow.TabIndex = 14;
      this.nudSelRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // chkSelAll
      // 
      this.chkSelAll.AutoSize = true;
      this.chkSelAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkSelAll.Location = new System.Drawing.Point(124, 155);
      this.chkSelAll.Name = "chkSelAll";
      this.chkSelAll.Size = new System.Drawing.Size(51, 17);
      this.chkSelAll.TabIndex = 15;
      this.chkSelAll.Text = "Tutte";
      this.chkSelAll.UseVisualStyleBackColor = true;
      this.chkSelAll.CheckedChanged += new System.EventHandler(this.chkSelAll_CheckedChanged);
      // 
      // bttSelRow
      // 
      this.bttSelRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.bttSelRow.Location = new System.Drawing.Point(176, 154);
      this.bttSelRow.Name = "bttSelRow";
      this.bttSelRow.Size = new System.Drawing.Size(125, 19);
      this.bttSelRow.TabIndex = 16;
      this.bttSelRow.Text = "Seleziona/Deseleziona";
      this.bttSelRow.UseVisualStyleBackColor = true;
      this.bttSelRow.Click += new System.EventHandler(this.bttSelRow_Click);
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(-1, 121);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(96, 13);
      this.label11.TabIndex = 53;
      this.label11.Text = "Stato Fatturazione:";
      // 
      // rdbTutti
      // 
      this.rdbTutti.AutoSize = true;
      this.rdbTutti.Location = new System.Drawing.Point(97, 119);
      this.rdbTutti.Name = "rdbTutti";
      this.rdbTutti.Size = new System.Drawing.Size(46, 17);
      this.rdbTutti.TabIndex = 9;
      this.rdbTutti.Text = "Tutti";
      this.rdbTutti.UseVisualStyleBackColor = true;
      // 
      // rdbNoFatt
      // 
      this.rdbNoFatt.AutoSize = true;
      this.rdbNoFatt.Location = new System.Drawing.Point(155, 119);
      this.rdbNoFatt.Name = "rdbNoFatt";
      this.rdbNoFatt.Size = new System.Drawing.Size(83, 17);
      this.rdbNoFatt.TabIndex = 10;
      this.rdbNoFatt.Text = "Non fatturati";
      this.rdbNoFatt.UseVisualStyleBackColor = true;
      // 
      // rdbFatt
      // 
      this.rdbFatt.AutoSize = true;
      this.rdbFatt.Checked = true;
      this.rdbFatt.Location = new System.Drawing.Point(245, 119);
      this.rdbFatt.Name = "rdbFatt";
      this.rdbFatt.Size = new System.Drawing.Size(63, 17);
      this.rdbFatt.TabIndex = 11;
      this.rdbFatt.TabStop = true;
      this.rdbFatt.Text = "Fatturati";
      this.rdbFatt.UseVisualStyleBackColor = true;
      // 
      // label16
      // 
      this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label16.AutoSize = true;
      this.label16.Location = new System.Drawing.Point(761, 307);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(13, 13);
      this.label16.TabIndex = 84;
      this.label16.Text = "€";
      // 
      // lblTotImporto
      // 
      this.lblTotImporto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lblTotImporto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblTotImporto.Location = new System.Drawing.Point(649, 306);
      this.lblTotImporto.Name = "lblTotImporto";
      this.lblTotImporto.Size = new System.Drawing.Size(107, 21);
      this.lblTotImporto.TabIndex = 82;
      this.lblTotImporto.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label15
      // 
      this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(565, 307);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(78, 13);
      this.label15.TabIndex = 83;
      this.label15.Text = "Totale Importo:";
      // 
      // lblTotKm
      // 
      this.lblTotKm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lblTotKm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblTotKm.Location = new System.Drawing.Point(412, 305);
      this.lblTotKm.Name = "lblTotKm";
      this.lblTotKm.Size = new System.Drawing.Size(107, 21);
      this.lblTotKm.TabIndex = 85;
      this.lblTotKm.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label14
      // 
      this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(352, 307);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(58, 13);
      this.label14.TabIndex = 86;
      this.label14.Text = "Totale Km:";
      // 
      // bttnImporta
      // 
      this.bttnImporta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.bttnImporta.Enabled = false;
      this.bttnImporta.Location = new System.Drawing.Point(220, 335);
      this.bttnImporta.Name = "bttnImporta";
      this.bttnImporta.Size = new System.Drawing.Size(75, 27);
      this.bttnImporta.TabIndex = 87;
      this.bttnImporta.Text = "Importa";
      this.bttnImporta.UseVisualStyleBackColor = true;
      this.bttnImporta.Visible = false;
      this.bttnImporta.Click += new System.EventHandler(this.bttnImporta_Click);
      // 
      // frmDocViaggi
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(831, 370);
      this.Controls.Add(this.bttnImporta);
      this.Controls.Add(this.lblTotKm);
      this.Controls.Add(this.label14);
      this.Controls.Add(this.label16);
      this.Controls.Add(this.lblTotImporto);
      this.Controls.Add(this.label15);
      this.Controls.Add(this.rdbFatt);
      this.Controls.Add(this.rdbNoFatt);
      this.Controls.Add(this.rdbTutti);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.bttSelRow);
      this.Controls.Add(this.chkSelAll);
      this.Controls.Add(this.nudSelRow);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.cmbCli);
      this.Controls.Add(this.bttGenFatt);
      this.Controls.Add(this.bttClear);
      this.Controls.Add(this.bttFind);
      this.Controls.Add(this.bttNuovo);
      this.Controls.Add(this.bttEsci);
      this.Controls.Add(this.bttElimina);
      this.Controls.Add(this.bttModifica);
      this.Controls.Add(this.bttStampa);
      this.Controls.Add(this.dgvResult);
      this.Controls.Add(this.dtpDataAl);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.dtpDataDal);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.cmbAutom);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.txtDTT);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.cmbTrA);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.cmbTrDa);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtDescr);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.cmbCodArt);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "frmDocViaggi";
      this.ShowIcon = false;
      this.Text = "Doc. Viaggi - Ricerca";
      this.Load += new System.EventHandler(this.frmDocViaggi_Load);
      ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudSelRow)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCodArt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.ComboBox cmbTrDa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDTT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbAutom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDataAl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDataDal;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button bttNuovo;
        private System.Windows.Forms.Button bttEsci;
        private System.Windows.Forms.Button bttElimina;
        private System.Windows.Forms.Button bttModifica;
        private System.Windows.Forms.Button bttStampa;
        private System.Windows.Forms.Button bttClear;
        private System.Windows.Forms.Button bttFind;
        private System.Windows.Forms.Button bttGenFatt;
        private System.Windows.Forms.ComboBox cmbCli;
        private System.Windows.Forms.ComboBox cmbTrA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudSelRow;
        private System.Windows.Forms.CheckBox chkSelAll;
        private System.Windows.Forms.Button bttSelRow;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rdbTutti;
        private System.Windows.Forms.RadioButton rdbNoFatt;
        private System.Windows.Forms.RadioButton rdbFatt;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblTotImporto;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTotKm;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button bttnImporta;
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
    }
}