namespace Trucks
{
    partial class frmScadenziario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbCli = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpDataAl = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpDataDal = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDataFatt = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudImpMax = new System.Windows.Forms.NumericUpDown();
            this.nudImpMin = new System.Windows.Forms.NumericUpDown();
            this.txtNumFatt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkScaduti = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudScadGG = new System.Windows.Forms.NumericUpDown();
            this.dtpScadAl = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpScadDal = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.bttClear = new System.Windows.Forms.Button();
            this.bttFind = new System.Windows.Forms.Button();
            this.bttNuovoPag = new System.Windows.Forms.Button();
            this.bttEsci = new System.Windows.Forms.Button();
            this.bttElimina = new System.Windows.Forms.Button();
            this.bttModifica = new System.Windows.Forms.Button();
            this.bttStampa = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTotImp = new System.Windows.Forms.Label();
            this.lblTotFat = new System.Windows.Forms.Label();
            this.lblTotInc = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.chkRagCl = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudImpMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImpMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScadGG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCli
            // 
            this.cmbCli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCli.FormattingEnabled = true;
            this.cmbCli.Location = new System.Drawing.Point(56, 12);
            this.cmbCli.Name = "cmbCli";
            this.cmbCli.Size = new System.Drawing.Size(124, 21);
            this.cmbCli.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 63;
            this.label10.Text = "Cliente:";
            // 
            // dtpDataAl
            // 
            this.dtpDataAl.Checked = false;
            this.dtpDataAl.CustomFormat = "dd/MM/yyyy";
            this.dtpDataAl.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataAl.Location = new System.Drawing.Point(398, 46);
            this.dtpDataAl.Name = "dtpDataAl";
            this.dtpDataAl.ShowCheckBox = true;
            this.dtpDataAl.Size = new System.Drawing.Size(106, 20);
            this.dtpDataAl.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(376, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 67;
            this.label9.Text = "al:";
            // 
            // dtpDataDal
            // 
            this.dtpDataDal.Checked = false;
            this.dtpDataDal.CustomFormat = "dd/MM/yyyy";
            this.dtpDataDal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataDal.Location = new System.Drawing.Point(261, 47);
            this.dtpDataDal.Name = "dtpDataDal";
            this.dtpDataDal.ShowCheckBox = true;
            this.dtpDataDal.Size = new System.Drawing.Size(101, 20);
            this.dtpDataDal.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(186, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 65;
            this.label8.Text = "Data dal:";
            // 
            // dtpDataFatt
            // 
            this.dtpDataFatt.Checked = false;
            this.dtpDataFatt.CustomFormat = "dd/MM/yyyy";
            this.dtpDataFatt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataFatt.Location = new System.Drawing.Point(79, 46);
            this.dtpDataFatt.Name = "dtpDataFatt";
            this.dtpDataFatt.ShowCheckBox = true;
            this.dtpDataFatt.Size = new System.Drawing.Size(101, 20);
            this.dtpDataFatt.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Data Fattura:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Importo > di";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "< di";
            // 
            // nudImpMax
            // 
            this.nudImpMax.DecimalPlaces = 2;
            this.nudImpMax.Location = new System.Drawing.Point(398, 14);
            this.nudImpMax.Maximum = new decimal(new int[] {
            9000000,
            0,
            0,
            0});
            this.nudImpMax.Name = "nudImpMax";
            this.nudImpMax.Size = new System.Drawing.Size(106, 20);
            this.nudImpMax.TabIndex = 2;
            this.nudImpMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudImpMin
            // 
            this.nudImpMin.DecimalPlaces = 2;
            this.nudImpMin.Location = new System.Drawing.Point(261, 14);
            this.nudImpMin.Maximum = new decimal(new int[] {
            9000000,
            0,
            0,
            0});
            this.nudImpMin.Name = "nudImpMin";
            this.nudImpMin.Size = new System.Drawing.Size(101, 20);
            this.nudImpMin.TabIndex = 1;
            this.nudImpMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNumFatt
            // 
            this.txtNumFatt.Location = new System.Drawing.Point(79, 79);
            this.txtNumFatt.Name = "txtNumFatt";
            this.txtNumFatt.Size = new System.Drawing.Size(101, 20);
            this.txtNumFatt.TabIndex = 6;
            this.txtNumFatt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumFatt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumFatt_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 75;
            this.label6.Text = "N. Fattura:";
            // 
            // chkScaduti
            // 
            this.chkScaduti.AutoSize = true;
            this.chkScaduti.Location = new System.Drawing.Point(261, 81);
            this.chkScaduti.Name = "chkScaduti";
            this.chkScaduti.Size = new System.Drawing.Size(62, 17);
            this.chkScaduti.TabIndex = 7;
            this.chkScaduti.Text = "Scaduti";
            this.chkScaduti.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 78;
            this.label4.Text = "Scadenza entro :";
            // 
            // nudScadGG
            // 
            this.nudScadGG.Location = new System.Drawing.Point(104, 112);
            this.nudScadGG.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudScadGG.Name = "nudScadGG";
            this.nudScadGG.Size = new System.Drawing.Size(76, 20);
            this.nudScadGG.TabIndex = 8;
            this.nudScadGG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpScadAl
            // 
            this.dtpScadAl.Checked = false;
            this.dtpScadAl.CustomFormat = "dd/MM/yyyy";
            this.dtpScadAl.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpScadAl.Location = new System.Drawing.Point(398, 110);
            this.dtpScadAl.Name = "dtpScadAl";
            this.dtpScadAl.ShowCheckBox = true;
            this.dtpScadAl.Size = new System.Drawing.Size(106, 20);
            this.dtpScadAl.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(376, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "al:";
            // 
            // dtpScadDal
            // 
            this.dtpScadDal.Checked = false;
            this.dtpScadDal.CustomFormat = "dd/MM/yyyy";
            this.dtpScadDal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpScadDal.Location = new System.Drawing.Point(261, 111);
            this.dtpScadDal.Name = "dtpScadDal";
            this.dtpScadDal.ShowCheckBox = true;
            this.dtpScadDal.Size = new System.Drawing.Size(101, 20);
            this.dtpScadDal.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 80;
            this.label7.Text = "Scadenza dal:";
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(13, 171);
            this.dgvResult.MultiSelect = false;
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.ShowEditingIcon = false;
            this.dgvResult.Size = new System.Drawing.Size(656, 110);
            this.dgvResult.TabIndex = 14;
            this.dgvResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellContentClick);
            this.dgvResult.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellContentDoubleClick);
            this.dgvResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellDoubleClick);
            // 
            // bttClear
            // 
            this.bttClear.Location = new System.Drawing.Point(555, 50);
            this.bttClear.Name = "bttClear";
            this.bttClear.Size = new System.Drawing.Size(70, 27);
            this.bttClear.TabIndex = 13;
            this.bttClear.Text = "Pulisci";
            this.bttClear.UseVisualStyleBackColor = true;
            this.bttClear.Click += new System.EventHandler(this.bttClear_Click);
            // 
            // bttFind
            // 
            this.bttFind.Location = new System.Drawing.Point(555, 16);
            this.bttFind.Name = "bttFind";
            this.bttFind.Size = new System.Drawing.Size(70, 27);
            this.bttFind.TabIndex = 12;
            this.bttFind.Text = "Cerca";
            this.bttFind.UseVisualStyleBackColor = true;
            this.bttFind.Click += new System.EventHandler(this.bttFind_Click);
            // 
            // bttNuovoPag
            // 
            this.bttNuovoPag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttNuovoPag.Location = new System.Drawing.Point(316, 362);
            this.bttNuovoPag.Name = "bttNuovoPag";
            this.bttNuovoPag.Size = new System.Drawing.Size(121, 27);
            this.bttNuovoPag.TabIndex = 20;
            this.bttNuovoPag.Text = "Imposta Pagamento";
            this.bttNuovoPag.UseVisualStyleBackColor = true;
            this.bttNuovoPag.Click += new System.EventHandler(this.bttNuovoPag_Click);
            // 
            // bttEsci
            // 
            this.bttEsci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttEsci.Location = new System.Drawing.Point(599, 362);
            this.bttEsci.Name = "bttEsci";
            this.bttEsci.Size = new System.Drawing.Size(70, 27);
            this.bttEsci.TabIndex = 22;
            this.bttEsci.Text = "Esci";
            this.bttEsci.UseVisualStyleBackColor = true;
            this.bttEsci.Click += new System.EventHandler(this.bttEsci_Click);
            // 
            // bttElimina
            // 
            this.bttElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttElimina.Location = new System.Drawing.Point(462, 362);
            this.bttElimina.Name = "bttElimina";
            this.bttElimina.Size = new System.Drawing.Size(70, 27);
            this.bttElimina.TabIndex = 21;
            this.bttElimina.Text = "Elimina";
            this.bttElimina.UseVisualStyleBackColor = true;
            this.bttElimina.Click += new System.EventHandler(this.bttElimina_Click);
            // 
            // bttModifica
            // 
            this.bttModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttModifica.Enabled = false;
            this.bttModifica.Location = new System.Drawing.Point(367, 362);
            this.bttModifica.Name = "bttModifica";
            this.bttModifica.Size = new System.Drawing.Size(70, 27);
            this.bttModifica.TabIndex = 88;
            this.bttModifica.Text = "Modifica";
            this.bttModifica.UseVisualStyleBackColor = true;
            this.bttModifica.Visible = false;
            this.bttModifica.Click += new System.EventHandler(this.bttModifica_Click);
            // 
            // bttStampa
            // 
            this.bttStampa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttStampa.Location = new System.Drawing.Point(13, 362);
            this.bttStampa.Name = "bttStampa";
            this.bttStampa.Size = new System.Drawing.Size(70, 27);
            this.bttStampa.TabIndex = 19;
            this.bttStampa.Text = "Stampa";
            this.bttStampa.UseVisualStyleBackColor = true;
            this.bttStampa.Click += new System.EventHandler(this.bttStampa_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(461, 301);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 92;
            this.label11.Text = "Saldo";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(351, 301);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 93;
            this.label12.Text = "Incassato";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(101, 301);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 13);
            this.label13.TabIndex = 94;
            this.label13.Text = "Importo Fatture";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(210, 301);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 13);
            this.label14.TabIndex = 95;
            this.label14.Text = "Importo Scadenze";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(13, 317);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 96;
            this.label15.Text = "Totali";
            // 
            // lblTotImp
            // 
            this.lblTotImp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotImp.Location = new System.Drawing.Point(213, 318);
            this.lblTotImp.Name = "lblTotImp";
            this.lblTotImp.Size = new System.Drawing.Size(100, 12);
            this.lblTotImp.TabIndex = 16;
            this.lblTotImp.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotFat
            // 
            this.lblTotFat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotFat.Location = new System.Drawing.Point(90, 318);
            this.lblTotFat.Name = "lblTotFat";
            this.lblTotFat.Size = new System.Drawing.Size(101, 12);
            this.lblTotFat.TabIndex = 15;
            this.lblTotFat.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotInc
            // 
            this.lblTotInc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotInc.Location = new System.Drawing.Point(332, 318);
            this.lblTotInc.Name = "lblTotInc";
            this.lblTotInc.Size = new System.Drawing.Size(81, 12);
            this.lblTotInc.TabIndex = 17;
            this.lblTotInc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSaldo
            // 
            this.lblSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSaldo.Location = new System.Drawing.Point(419, 318);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(81, 12);
            this.lblSaldo.TabIndex = 18;
            this.lblSaldo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkRagCl
            // 
            this.chkRagCl.AutoSize = true;
            this.chkRagCl.Location = new System.Drawing.Point(13, 142);
            this.chkRagCl.Name = "chkRagCl";
            this.chkRagCl.Size = new System.Drawing.Size(131, 17);
            this.chkRagCl.TabIndex = 11;
            this.chkRagCl.Text = "Raggruppa per cliente";
            this.chkRagCl.UseVisualStyleBackColor = true;
            this.chkRagCl.CheckedChanged += new System.EventHandler(this.chkRagCl_CheckedChanged);
            // 
            // frmScadenziario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 401);
            this.Controls.Add(this.chkRagCl);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.lblTotInc);
            this.Controls.Add(this.lblTotFat);
            this.Controls.Add(this.lblTotImp);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.bttNuovoPag);
            this.Controls.Add(this.bttEsci);
            this.Controls.Add(this.bttElimina);
            this.Controls.Add(this.bttModifica);
            this.Controls.Add(this.bttStampa);
            this.Controls.Add(this.bttClear);
            this.Controls.Add(this.bttFind);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.dtpScadAl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpScadDal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudScadGG);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkScaduti);
            this.Controls.Add(this.txtNumFatt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudImpMin);
            this.Controls.Add(this.nudImpMax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDataFatt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDataAl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpDataDal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbCli);
            this.Controls.Add(this.label10);
            this.Name = "frmScadenziario";
            this.ShowIcon = false;
            this.Text = "Scadenziario";
            this.Load += new System.EventHandler(this.frmScadenziario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudImpMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImpMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScadGG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCli;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpDataAl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDataDal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDataFatt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudImpMax;
        private System.Windows.Forms.NumericUpDown nudImpMin;
        private System.Windows.Forms.TextBox txtNumFatt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkScaduti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudScadGG;
        private System.Windows.Forms.DateTimePicker dtpScadAl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpScadDal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button bttClear;
        private System.Windows.Forms.Button bttFind;
        private System.Windows.Forms.Button bttNuovoPag;
        private System.Windows.Forms.Button bttEsci;
        private System.Windows.Forms.Button bttElimina;
        private System.Windows.Forms.Button bttModifica;
        private System.Windows.Forms.Button bttStampa;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTotImp;
        private System.Windows.Forms.Label lblTotFat;
        private System.Windows.Forms.Label lblTotInc;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.CheckBox chkRagCl;
    }
}