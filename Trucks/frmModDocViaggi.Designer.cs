namespace Trucks
{
    partial class frmModDocViaggi
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
      this.txtDescr = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.cmbCodArt = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.cmbPercorso = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.bttNewDist = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.lblKM = new System.Windows.Forms.Label();
      this.txtDDT = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.dtpData = new System.Windows.Forms.DateTimePicker();
      this.label9 = new System.Windows.Forms.Label();
      this.cmbAut = new System.Windows.Forms.ComboBox();
      this.label8 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.cmbUm = new System.Windows.Forms.ComboBox();
      this.label11 = new System.Windows.Forms.Label();
      this.nudQuant = new System.Windows.Forms.NumericUpDown();
      this.nudPrezzo = new System.Windows.Forms.NumericUpDown();
      this.label12 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.lblTotale = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.label17 = new System.Windows.Forms.Label();
      this.cmbIva = new System.Windows.Forms.ComboBox();
      this.label19 = new System.Windows.Forms.Label();
      this.label20 = new System.Windows.Forms.Label();
      this.label21 = new System.Windows.Forms.Label();
      this.lblImportoIva = new System.Windows.Forms.Label();
      this.label23 = new System.Windows.Forms.Label();
      this.bttAnnulla = new System.Windows.Forms.Button();
      this.bttSave = new System.Windows.Forms.Button();
      this.bttEsci = new System.Windows.Forms.Button();
      this.txtNote = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.bttElimina = new System.Windows.Forms.Button();
      this.cmbCliente = new System.Windows.Forms.ComboBox();
      this.nudIVA = new System.Windows.Forms.NumericUpDown();
      this.label15 = new System.Windows.Forms.Label();
      this.lblTotLordo = new System.Windows.Forms.Label();
      this.label22 = new System.Windows.Forms.Label();
      this.bttInserDettFatt = new System.Windows.Forms.Button();
      this.bttTabAutomezzo = new System.Windows.Forms.Button();
      this.bttTabArt = new System.Windows.Forms.Button();
      this.bttTabUM = new System.Windows.Forms.Button();
      this.bttTabIva = new System.Windows.Forms.Button();
      this.bttTabClienti = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.nudQuant)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudPrezzo)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudIVA)).BeginInit();
      this.SuspendLayout();
      // 
      // txtDescr
      // 
      this.txtDescr.Location = new System.Drawing.Point(68, 112);
      this.txtDescr.MaxLength = 80;
      this.txtDescr.Name = "txtDescr";
      this.txtDescr.Size = new System.Drawing.Size(554, 20);
      this.txtDescr.TabIndex = 5;
      this.txtDescr.TextChanged += new System.EventHandler(this.obj_ValueChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(0, 115);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(65, 13);
      this.label3.TabIndex = 10;
      this.label3.Text = "Descrizione:";
      // 
      // cmbCodArt
      // 
      this.cmbCodArt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cmbCodArt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cmbCodArt.FormattingEnabled = true;
      this.cmbCodArt.Location = new System.Drawing.Point(68, 85);
      this.cmbCodArt.Name = "cmbCodArt";
      this.cmbCodArt.Size = new System.Drawing.Size(327, 21);
      this.cmbCodArt.TabIndex = 4;
      this.cmbCodArt.SelectedIndexChanged += new System.EventHandler(this.cmbCodArt_SelectedIndexChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(2, 88);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(45, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "Articolo:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(0, 53);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(42, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Cliente:";
      // 
      // cmbPercorso
      // 
      this.cmbPercorso.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cmbPercorso.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cmbPercorso.FormattingEnabled = true;
      this.cmbPercorso.Location = new System.Drawing.Point(68, 157);
      this.cmbPercorso.Name = "cmbPercorso";
      this.cmbPercorso.Size = new System.Drawing.Size(313, 21);
      this.cmbPercorso.TabIndex = 6;
      this.cmbPercorso.SelectedIndexChanged += new System.EventHandler(this.cmbPercorso_SelectedIndexChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(0, 160);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(52, 13);
      this.label4.TabIndex = 12;
      this.label4.Text = "Percorso:";
      // 
      // bttNewDist
      // 
      this.bttNewDist.Location = new System.Drawing.Point(534, 154);
      this.bttNewDist.Name = "bttNewDist";
      this.bttNewDist.Size = new System.Drawing.Size(88, 26);
      this.bttNewDist.TabIndex = 8;
      this.bttNewDist.Text = "Nuova Tratta";
      this.bttNewDist.UseVisualStyleBackColor = true;
      this.bttNewDist.Click += new System.EventHandler(this.bttNewDist_Click);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(392, 161);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(23, 13);
      this.label6.TabIndex = 17;
      this.label6.Text = "KM";
      // 
      // lblKM
      // 
      this.lblKM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblKM.Location = new System.Drawing.Point(422, 157);
      this.lblKM.Name = "lblKM";
      this.lblKM.Size = new System.Drawing.Size(81, 21);
      this.lblKM.TabIndex = 7;
      this.lblKM.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // txtDDT
      // 
      this.txtDDT.Location = new System.Drawing.Point(219, 22);
      this.txtDDT.MaxLength = 20;
      this.txtDDT.Name = "txtDDT";
      this.txtDDT.Size = new System.Drawing.Size(181, 20);
      this.txtDDT.TabIndex = 1;
      this.txtDDT.TextChanged += new System.EventHandler(this.obj_ValueChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(178, 25);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(39, 13);
      this.label7.TabIndex = 19;
      this.label7.Text = "N. ddt:";
      // 
      // dtpData
      // 
      this.dtpData.Checked = false;
      this.dtpData.CustomFormat = "dd/MM/yyyy";
      this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpData.Location = new System.Drawing.Point(48, 21);
      this.dtpData.Name = "dtpData";
      this.dtpData.ShowCheckBox = true;
      this.dtpData.Size = new System.Drawing.Size(104, 20);
      this.dtpData.TabIndex = 0;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(0, 25);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(33, 13);
      this.label9.TabIndex = 22;
      this.label9.Text = "Data:";
      // 
      // cmbAut
      // 
      this.cmbAut.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cmbAut.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cmbAut.FormattingEnabled = true;
      this.cmbAut.Location = new System.Drawing.Point(477, 21);
      this.cmbAut.Name = "cmbAut";
      this.cmbAut.Size = new System.Drawing.Size(112, 21);
      this.cmbAut.TabIndex = 2;
      this.cmbAut.SelectedIndexChanged += new System.EventHandler(this.obj_ValueChanged);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(418, 25);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(62, 13);
      this.label8.TabIndex = 24;
      this.label8.Text = "Automezzo:";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(0, 196);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(80, 13);
      this.label10.TabIndex = 26;
      this.label10.Text = "Unità di Misura:";
      // 
      // cmbUm
      // 
      this.cmbUm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cmbUm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cmbUm.FormattingEnabled = true;
      this.cmbUm.Location = new System.Drawing.Point(86, 193);
      this.cmbUm.Name = "cmbUm";
      this.cmbUm.Size = new System.Drawing.Size(86, 21);
      this.cmbUm.TabIndex = 9;
      this.cmbUm.SelectedIndexChanged += new System.EventHandler(this.obj_ValueChanged);
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(223, 196);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(50, 13);
      this.label11.TabIndex = 29;
      this.label11.Text = "Quantità:";
      // 
      // nudQuant
      // 
      this.nudQuant.DecimalPlaces = 3;
      this.nudQuant.Location = new System.Drawing.Point(280, 194);
      this.nudQuant.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.nudQuant.Name = "nudQuant";
      this.nudQuant.Size = new System.Drawing.Size(82, 20);
      this.nudQuant.TabIndex = 10;
      this.nudQuant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.nudQuant.ValueChanged += new System.EventHandler(this.nudQuant_ValueChanged);
      this.nudQuant.Enter += new System.EventHandler(this.nudQuant_Enter);
      // 
      // nudPrezzo
      // 
      this.nudPrezzo.DecimalPlaces = 2;
      this.nudPrezzo.Location = new System.Drawing.Point(521, 194);
      this.nudPrezzo.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
      this.nudPrezzo.Name = "nudPrezzo";
      this.nudPrezzo.Size = new System.Drawing.Size(83, 20);
      this.nudPrezzo.TabIndex = 11;
      this.nudPrezzo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.nudPrezzo.ValueChanged += new System.EventHandler(this.nudPrezzo_ValueChanged);
      this.nudPrezzo.Enter += new System.EventHandler(this.nudPrezzo_Enter);
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(473, 198);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(42, 13);
      this.label12.TabIndex = 32;
      this.label12.Text = "Prezzo:";
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(610, 196);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(13, 13);
      this.label13.TabIndex = 33;
      this.label13.Text = "€";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(448, 230);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(67, 13);
      this.label14.TabIndex = 34;
      this.label14.Text = "Totale netto:";
      // 
      // lblTotale
      // 
      this.lblTotale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblTotale.Location = new System.Drawing.Point(521, 229);
      this.lblTotale.Name = "lblTotale";
      this.lblTotale.Size = new System.Drawing.Size(82, 21);
      this.lblTotale.TabIndex = 12;
      this.lblTotale.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Location = new System.Drawing.Point(610, 230);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(13, 13);
      this.label16.TabIndex = 36;
      this.label16.Text = "€";
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Location = new System.Drawing.Point(281, 262);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(68, 13);
      this.label17.TabIndex = 37;
      this.label17.Text = "Aliquota IVA:";
      // 
      // cmbIva
      // 
      this.cmbIva.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cmbIva.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cmbIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbIva.FormattingEnabled = true;
      this.cmbIva.Location = new System.Drawing.Point(68, 259);
      this.cmbIva.Name = "cmbIva";
      this.cmbIva.Size = new System.Drawing.Size(169, 21);
      this.cmbIva.TabIndex = 13;
      this.cmbIva.SelectedIndexChanged += new System.EventHandler(this.cmbIva_SelectedIndexChanged);
      this.cmbIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbIva_KeyPress);
      // 
      // label19
      // 
      this.label19.AutoSize = true;
      this.label19.Location = new System.Drawing.Point(1, 262);
      this.label19.Name = "label19";
      this.label19.Size = new System.Drawing.Size(61, 13);
      this.label19.TabIndex = 39;
      this.label19.Text = "Descr. IVA:";
      // 
      // label20
      // 
      this.label20.AutoSize = true;
      this.label20.Location = new System.Drawing.Point(427, 262);
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size(15, 13);
      this.label20.TabIndex = 41;
      this.label20.Text = "%";
      // 
      // label21
      // 
      this.label21.AutoSize = true;
      this.label21.Location = new System.Drawing.Point(610, 262);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(13, 13);
      this.label21.TabIndex = 44;
      this.label21.Text = "€";
      // 
      // lblImportoIva
      // 
      this.lblImportoIva.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblImportoIva.Location = new System.Drawing.Point(521, 261);
      this.lblImportoIva.Name = "lblImportoIva";
      this.lblImportoIva.Size = new System.Drawing.Size(82, 21);
      this.lblImportoIva.TabIndex = 15;
      this.lblImportoIva.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label23
      // 
      this.label23.AutoSize = true;
      this.label23.Location = new System.Drawing.Point(450, 261);
      this.label23.Name = "label23";
      this.label23.Size = new System.Drawing.Size(65, 13);
      this.label23.TabIndex = 42;
      this.label23.Text = "Importo IVA:";
      // 
      // bttAnnulla
      // 
      this.bttAnnulla.Location = new System.Drawing.Point(103, 397);
      this.bttAnnulla.Name = "bttAnnulla";
      this.bttAnnulla.Size = new System.Drawing.Size(69, 26);
      this.bttAnnulla.TabIndex = 19;
      this.bttAnnulla.Text = "Annulla";
      this.bttAnnulla.UseVisualStyleBackColor = true;
      this.bttAnnulla.Click += new System.EventHandler(this.bttAnnulla_Click);
      // 
      // bttSave
      // 
      this.bttSave.Location = new System.Drawing.Point(3, 397);
      this.bttSave.Name = "bttSave";
      this.bttSave.Size = new System.Drawing.Size(69, 26);
      this.bttSave.TabIndex = 46;
      this.bttSave.Text = "Salva";
      this.bttSave.UseVisualStyleBackColor = true;
      this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
      // 
      // bttEsci
      // 
      this.bttEsci.Location = new System.Drawing.Point(553, 397);
      this.bttEsci.Name = "bttEsci";
      this.bttEsci.Size = new System.Drawing.Size(69, 26);
      this.bttEsci.TabIndex = 21;
      this.bttEsci.Text = "Esci";
      this.bttEsci.UseVisualStyleBackColor = true;
      this.bttEsci.Click += new System.EventHandler(this.bttEsci_Click);
      // 
      // txtNote
      // 
      this.txtNote.Location = new System.Drawing.Point(3, 339);
      this.txtNote.MaxLength = 50;
      this.txtNote.Multiline = true;
      this.txtNote.Name = "txtNote";
      this.txtNote.Size = new System.Drawing.Size(619, 46);
      this.txtNote.TabIndex = 17;
      this.txtNote.TextChanged += new System.EventHandler(this.obj_ValueChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(0, 323);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(33, 13);
      this.label5.TabIndex = 48;
      this.label5.Text = "Note:";
      // 
      // bttElimina
      // 
      this.bttElimina.Location = new System.Drawing.Point(202, 397);
      this.bttElimina.Name = "bttElimina";
      this.bttElimina.Size = new System.Drawing.Size(69, 26);
      this.bttElimina.TabIndex = 20;
      this.bttElimina.Text = "Elimina";
      this.bttElimina.UseVisualStyleBackColor = true;
      this.bttElimina.Click += new System.EventHandler(this.bttElimina_Click);
      // 
      // cmbCliente
      // 
      this.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbCliente.FormattingEnabled = true;
      this.cmbCliente.Location = new System.Drawing.Point(68, 50);
      this.cmbCliente.Name = "cmbCliente";
      this.cmbCliente.Size = new System.Drawing.Size(327, 21);
      this.cmbCliente.TabIndex = 3;
      this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.obj_ValueChanged);
      // 
      // nudIVA
      // 
      this.nudIVA.DecimalPlaces = 2;
      this.nudIVA.Enabled = false;
      this.nudIVA.Location = new System.Drawing.Point(350, 260);
      this.nudIVA.Name = "nudIVA";
      this.nudIVA.ReadOnly = true;
      this.nudIVA.Size = new System.Drawing.Size(71, 20);
      this.nudIVA.TabIndex = 14;
      this.nudIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.nudIVA.ValueChanged += new System.EventHandler(this.nudIVA_ValueChanged);
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(610, 293);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(13, 13);
      this.label15.TabIndex = 55;
      this.label15.Text = "€";
      // 
      // lblTotLordo
      // 
      this.lblTotLordo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblTotLordo.Location = new System.Drawing.Point(521, 292);
      this.lblTotLordo.Name = "lblTotLordo";
      this.lblTotLordo.Size = new System.Drawing.Size(82, 21);
      this.lblTotLordo.TabIndex = 16;
      this.lblTotLordo.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // label22
      // 
      this.label22.AutoSize = true;
      this.label22.Location = new System.Drawing.Point(445, 292);
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size(70, 13);
      this.label22.TabIndex = 53;
      this.label22.Text = "Totale Lordo:";
      // 
      // bttInserDettFatt
      // 
      this.bttInserDettFatt.Location = new System.Drawing.Point(3, 397);
      this.bttInserDettFatt.Name = "bttInserDettFatt";
      this.bttInserDettFatt.Size = new System.Drawing.Size(69, 26);
      this.bttInserDettFatt.TabIndex = 18;
      this.bttInserDettFatt.Text = "Salva";
      this.bttInserDettFatt.UseVisualStyleBackColor = true;
      this.bttInserDettFatt.Visible = false;
      this.bttInserDettFatt.Click += new System.EventHandler(this.bttInserDettFatt_Click);
      // 
      // bttTabAutomezzo
      // 
      this.bttTabAutomezzo.Location = new System.Drawing.Point(597, 22);
      this.bttTabAutomezzo.Name = "bttTabAutomezzo";
      this.bttTabAutomezzo.Size = new System.Drawing.Size(25, 20);
      this.bttTabAutomezzo.TabIndex = 56;
      this.bttTabAutomezzo.Text = "...";
      this.bttTabAutomezzo.UseVisualStyleBackColor = true;
      this.bttTabAutomezzo.Click += new System.EventHandler(this.bttTabAutomezzo_Click);
      // 
      // bttTabArt
      // 
      this.bttTabArt.Location = new System.Drawing.Point(403, 86);
      this.bttTabArt.Name = "bttTabArt";
      this.bttTabArt.Size = new System.Drawing.Size(25, 20);
      this.bttTabArt.TabIndex = 57;
      this.bttTabArt.Text = "...";
      this.bttTabArt.UseVisualStyleBackColor = true;
      this.bttTabArt.Click += new System.EventHandler(this.bttTabArt_Click);
      // 
      // bttTabUM
      // 
      this.bttTabUM.Location = new System.Drawing.Point(181, 194);
      this.bttTabUM.Name = "bttTabUM";
      this.bttTabUM.Size = new System.Drawing.Size(25, 20);
      this.bttTabUM.TabIndex = 58;
      this.bttTabUM.Text = "...";
      this.bttTabUM.UseVisualStyleBackColor = true;
      this.bttTabUM.Click += new System.EventHandler(this.bttTabUM_Click);
      // 
      // bttTabIva
      // 
      this.bttTabIva.Location = new System.Drawing.Point(243, 260);
      this.bttTabIva.Name = "bttTabIva";
      this.bttTabIva.Size = new System.Drawing.Size(25, 20);
      this.bttTabIva.TabIndex = 59;
      this.bttTabIva.Text = "...";
      this.bttTabIva.UseVisualStyleBackColor = true;
      this.bttTabIva.Visible = false;
      this.bttTabIva.Click += new System.EventHandler(this.bttTabIva_Click);
      // 
      // bttTabClienti
      // 
      this.bttTabClienti.Location = new System.Drawing.Point(403, 53);
      this.bttTabClienti.Name = "bttTabClienti";
      this.bttTabClienti.Size = new System.Drawing.Size(25, 20);
      this.bttTabClienti.TabIndex = 60;
      this.bttTabClienti.Text = "...";
      this.bttTabClienti.UseVisualStyleBackColor = true;
      this.bttTabClienti.Click += new System.EventHandler(this.bttTabClienti_Click);
      // 
      // frmModDocViaggi
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(627, 433);
      this.Controls.Add(this.bttTabClienti);
      this.Controls.Add(this.bttTabIva);
      this.Controls.Add(this.bttTabUM);
      this.Controls.Add(this.bttTabArt);
      this.Controls.Add(this.bttTabAutomezzo);
      this.Controls.Add(this.label15);
      this.Controls.Add(this.lblTotLordo);
      this.Controls.Add(this.label22);
      this.Controls.Add(this.nudIVA);
      this.Controls.Add(this.cmbCliente);
      this.Controls.Add(this.bttElimina);
      this.Controls.Add(this.txtNote);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.bttEsci);
      this.Controls.Add(this.bttAnnulla);
      this.Controls.Add(this.label21);
      this.Controls.Add(this.lblImportoIva);
      this.Controls.Add(this.label23);
      this.Controls.Add(this.label20);
      this.Controls.Add(this.label19);
      this.Controls.Add(this.cmbIva);
      this.Controls.Add(this.label17);
      this.Controls.Add(this.label16);
      this.Controls.Add(this.lblTotale);
      this.Controls.Add(this.label14);
      this.Controls.Add(this.label13);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.nudPrezzo);
      this.Controls.Add(this.nudQuant);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.cmbUm);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.cmbAut);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.dtpData);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.txtDDT);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.lblKM);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.bttNewDist);
      this.Controls.Add(this.cmbPercorso);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtDescr);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.cmbCodArt);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.bttInserDettFatt);
      this.Controls.Add(this.bttSave);
      this.Name = "frmModDocViaggi";
      this.ShowIcon = false;
      this.Text = "Doc. Viaggi - Nuovo";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmModDocViaggi_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmModDocViaggi_FormClosed);
      this.Load += new System.EventHandler(this.frmModDocViaggi_Load);
      this.Shown += new System.EventHandler(this.frmModDocViaggi_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.nudQuant)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudPrezzo)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudIVA)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCodArt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPercorso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bttNewDist;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblKM;
        private System.Windows.Forms.TextBox txtDDT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbAut;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbUm;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudQuant;
        private System.Windows.Forms.NumericUpDown nudPrezzo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTotale;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbIva;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblImportoIva;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button bttAnnulla;
        private System.Windows.Forms.Button bttSave;
        private System.Windows.Forms.Button bttEsci;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bttElimina;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.NumericUpDown nudIVA;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTotLordo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button bttInserDettFatt;
        private System.Windows.Forms.Button bttTabAutomezzo;
        private System.Windows.Forms.Button bttTabArt;
        private System.Windows.Forms.Button bttTabUM;
        private System.Windows.Forms.Button bttTabIva;
        private System.Windows.Forms.Button bttTabClienti;
    }
}