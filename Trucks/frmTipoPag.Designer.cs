namespace Trucks
{
    partial class frmTipoPag
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      this.bttModify = new System.Windows.Forms.Button();
      this.bttNew = new System.Windows.Forms.Button();
      this.grpbDettaglio = new System.Windows.Forms.GroupBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.rdbStampaNo = new System.Windows.Forms.RadioButton();
      this.rdbStampaCl = new System.Windows.Forms.RadioButton();
      this.rdbStampAz = new System.Windows.Forms.RadioButton();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.grpbRipPag = new System.Windows.Forms.GroupBox();
      this.bttPagMod = new System.Windows.Forms.Button();
      this.bttPagDelete = new System.Windows.Forms.Button();
      this.bttPagNew = new System.Windows.Forms.Button();
      this.dgvPagamenti = new System.Windows.Forms.DataGridView();
      this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColDataRif = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColGiorni = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ColPercImp = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.rdbDaFatt = new System.Windows.Forms.RadioButton();
      this.rdbImm = new System.Windows.Forms.RadioButton();
      this.rdbFineMese = new System.Windows.Forms.RadioButton();
      this.txtNote = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.lblCodice = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lstValori = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.bttAnnulla = new System.Windows.Forms.Button();
      this.bttEnd = new System.Windows.Forms.Button();
      this.bttDelete = new System.Windows.Forms.Button();
      this.bttSave = new System.Windows.Forms.Button();
      this.cmbModPag = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.cmbCondPag = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.grpbDettaglio.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.grpbRipPag.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvPagamenti)).BeginInit();
      this.SuspendLayout();
      // 
      // bttModify
      // 
      this.bttModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.bttModify.Location = new System.Drawing.Point(336, 432);
      this.bttModify.Name = "bttModify";
      this.bttModify.Size = new System.Drawing.Size(67, 24);
      this.bttModify.TabIndex = 14;
      this.bttModify.Text = "Modifica";
      this.bttModify.UseVisualStyleBackColor = true;
      this.bttModify.Click += new System.EventHandler(this.bttModify_Click);
      // 
      // bttNew
      // 
      this.bttNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.bttNew.Location = new System.Drawing.Point(263, 432);
      this.bttNew.Name = "bttNew";
      this.bttNew.Size = new System.Drawing.Size(67, 24);
      this.bttNew.TabIndex = 13;
      this.bttNew.Text = "Nuovo";
      this.bttNew.UseVisualStyleBackColor = true;
      this.bttNew.Click += new System.EventHandler(this.bttNew_Click);
      // 
      // grpbDettaglio
      // 
      this.grpbDettaglio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.grpbDettaglio.Controls.Add(this.cmbModPag);
      this.grpbDettaglio.Controls.Add(this.label6);
      this.grpbDettaglio.Controls.Add(this.cmbCondPag);
      this.grpbDettaglio.Controls.Add(this.label7);
      this.grpbDettaglio.Controls.Add(this.groupBox3);
      this.grpbDettaglio.Controls.Add(this.label3);
      this.grpbDettaglio.Controls.Add(this.grpbRipPag);
      this.grpbDettaglio.Controls.Add(this.rdbDaFatt);
      this.grpbDettaglio.Controls.Add(this.rdbImm);
      this.grpbDettaglio.Controls.Add(this.rdbFineMese);
      this.grpbDettaglio.Controls.Add(this.txtNote);
      this.grpbDettaglio.Controls.Add(this.label5);
      this.grpbDettaglio.Controls.Add(this.lblCodice);
      this.grpbDettaglio.Controls.Add(this.label2);
      this.grpbDettaglio.Enabled = false;
      this.grpbDettaglio.Location = new System.Drawing.Point(263, 21);
      this.grpbDettaglio.Name = "grpbDettaglio";
      this.grpbDettaglio.Size = new System.Drawing.Size(465, 405);
      this.grpbDettaglio.TabIndex = 11;
      this.grpbDettaglio.TabStop = false;
      this.grpbDettaglio.Text = "Dettaglio";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.rdbStampaNo);
      this.groupBox3.Controls.Add(this.rdbStampaCl);
      this.groupBox3.Controls.Add(this.rdbStampAz);
      this.groupBox3.Controls.Add(this.label4);
      this.groupBox3.Location = new System.Drawing.Point(19, 211);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(372, 49);
      this.groupBox3.TabIndex = 20;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Opzioni di stampa";
      // 
      // rdbStampaNo
      // 
      this.rdbStampaNo.AutoSize = true;
      this.rdbStampaNo.Location = new System.Drawing.Point(284, 23);
      this.rdbStampaNo.Name = "rdbStampaNo";
      this.rdbStampaNo.Size = new System.Drawing.Size(67, 17);
      this.rdbStampaNo.TabIndex = 8;
      this.rdbStampaNo.Text = "Nessuno";
      this.rdbStampaNo.UseVisualStyleBackColor = true;
      // 
      // rdbStampaCl
      // 
      this.rdbStampaCl.AutoSize = true;
      this.rdbStampaCl.Location = new System.Drawing.Point(200, 23);
      this.rdbStampaCl.Name = "rdbStampaCl";
      this.rdbStampaCl.Size = new System.Drawing.Size(57, 17);
      this.rdbStampaCl.TabIndex = 7;
      this.rdbStampaCl.Text = "Cliente";
      this.rdbStampaCl.UseVisualStyleBackColor = true;
      // 
      // rdbStampAz
      // 
      this.rdbStampAz.AutoSize = true;
      this.rdbStampAz.Checked = true;
      this.rdbStampAz.Location = new System.Drawing.Point(100, 23);
      this.rdbStampAz.Name = "rdbStampAz";
      this.rdbStampAz.Size = new System.Drawing.Size(63, 17);
      this.rdbStampAz.TabIndex = 6;
      this.rdbStampAz.TabStop = true;
      this.rdbStampAz.Text = "Azienda";
      this.rdbStampAz.UseVisualStyleBackColor = true;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(21, 25);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(68, 13);
      this.label4.TabIndex = 20;
      this.label4.Text = "Stampa C/C:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(15, 161);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(82, 13);
      this.label3.TabIndex = 19;
      this.label3.Text = "Tipo Scadenza:";
      // 
      // grpbRipPag
      // 
      this.grpbRipPag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grpbRipPag.Controls.Add(this.bttPagMod);
      this.grpbRipPag.Controls.Add(this.bttPagDelete);
      this.grpbRipPag.Controls.Add(this.bttPagNew);
      this.grpbRipPag.Controls.Add(this.dgvPagamenti);
      this.grpbRipPag.Enabled = false;
      this.grpbRipPag.Location = new System.Drawing.Point(18, 266);
      this.grpbRipPag.Name = "grpbRipPag";
      this.grpbRipPag.Size = new System.Drawing.Size(441, 133);
      this.grpbRipPag.TabIndex = 18;
      this.grpbRipPag.TabStop = false;
      this.grpbRipPag.Text = "Ripartizione Pagamento:";
      // 
      // bttPagMod
      // 
      this.bttPagMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bttPagMod.Location = new System.Drawing.Point(368, 19);
      this.bttPagMod.Name = "bttPagMod";
      this.bttPagMod.Size = new System.Drawing.Size(67, 24);
      this.bttPagMod.TabIndex = 10;
      this.bttPagMod.Text = "Modifica";
      this.bttPagMod.UseVisualStyleBackColor = true;
      this.bttPagMod.Click += new System.EventHandler(this.bttPagMod_Click);
      // 
      // bttPagDelete
      // 
      this.bttPagDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bttPagDelete.Location = new System.Drawing.Point(368, 55);
      this.bttPagDelete.Name = "bttPagDelete";
      this.bttPagDelete.Size = new System.Drawing.Size(67, 24);
      this.bttPagDelete.TabIndex = 11;
      this.bttPagDelete.Text = "Elimina";
      this.bttPagDelete.UseVisualStyleBackColor = true;
      this.bttPagDelete.Click += new System.EventHandler(this.bttPagDelete_Click);
      // 
      // bttPagNew
      // 
      this.bttPagNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bttPagNew.Location = new System.Drawing.Point(368, 91);
      this.bttPagNew.Name = "bttPagNew";
      this.bttPagNew.Size = new System.Drawing.Size(67, 24);
      this.bttPagNew.TabIndex = 12;
      this.bttPagNew.Text = "Nuovo";
      this.bttPagNew.UseVisualStyleBackColor = true;
      this.bttPagNew.Click += new System.EventHandler(this.bttPagNew_Click);
      // 
      // dgvPagamenti
      // 
      this.dgvPagamenti.AllowUserToAddRows = false;
      this.dgvPagamenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgvPagamenti.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dgvPagamenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPagamenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColDataRif,
            this.ColGiorni,
            this.ColPercImp});
      this.dgvPagamenti.Location = new System.Drawing.Point(12, 19);
      this.dgvPagamenti.Name = "dgvPagamenti";
      this.dgvPagamenti.Size = new System.Drawing.Size(343, 108);
      this.dgvPagamenti.TabIndex = 9;
      this.dgvPagamenti.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvPagamenti_EditingControlShowing);
      this.dgvPagamenti.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPagamenti_RowLeave);
      // 
      // ColID
      // 
      this.ColID.HeaderText = "ID";
      this.ColID.Name = "ColID";
      this.ColID.Visible = false;
      // 
      // ColDataRif
      // 
      this.ColDataRif.HeaderText = "Data Iniziale";
      this.ColDataRif.Name = "ColDataRif";
      this.ColDataRif.ReadOnly = true;
      // 
      // ColGiorni
      // 
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
      dataGridViewCellStyle2.Format = "N0";
      dataGridViewCellStyle2.NullValue = null;
      this.ColGiorni.DefaultCellStyle = dataGridViewCellStyle2;
      this.ColGiorni.HeaderText = "Giorni Scadenza";
      this.ColGiorni.MaxInputLength = 6;
      this.ColGiorni.Name = "ColGiorni";
      // 
      // ColPercImp
      // 
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
      dataGridViewCellStyle3.NullValue = null;
      this.ColPercImp.DefaultCellStyle = dataGridViewCellStyle3;
      this.ColPercImp.HeaderText = "% Importo";
      this.ColPercImp.MaxInputLength = 5;
      this.ColPercImp.Name = "ColPercImp";
      // 
      // rdbDaFatt
      // 
      this.rdbDaFatt.AutoSize = true;
      this.rdbDaFatt.Location = new System.Drawing.Point(119, 177);
      this.rdbDaFatt.Name = "rdbDaFatt";
      this.rdbDaFatt.Size = new System.Drawing.Size(84, 17);
      this.rdbDaFatt.TabIndex = 4;
      this.rdbDaFatt.Text = "Data Fattura";
      this.rdbDaFatt.UseVisualStyleBackColor = true;
      this.rdbDaFatt.CheckedChanged += new System.EventHandler(this.rdbDaFatt_CheckedChanged);
      // 
      // rdbImm
      // 
      this.rdbImm.AutoSize = true;
      this.rdbImm.Checked = true;
      this.rdbImm.Location = new System.Drawing.Point(18, 177);
      this.rdbImm.Name = "rdbImm";
      this.rdbImm.Size = new System.Drawing.Size(73, 17);
      this.rdbImm.TabIndex = 3;
      this.rdbImm.TabStop = true;
      this.rdbImm.Text = "Immediata";
      this.rdbImm.UseVisualStyleBackColor = true;
      this.rdbImm.CheckedChanged += new System.EventHandler(this.rdbImm_CheckedChanged);
      // 
      // rdbFineMese
      // 
      this.rdbFineMese.AutoSize = true;
      this.rdbFineMese.Location = new System.Drawing.Point(219, 177);
      this.rdbFineMese.Name = "rdbFineMese";
      this.rdbFineMese.Size = new System.Drawing.Size(74, 17);
      this.rdbFineMese.TabIndex = 5;
      this.rdbFineMese.Text = "Fine Mese";
      this.rdbFineMese.UseVisualStyleBackColor = true;
      this.rdbFineMese.CheckedChanged += new System.EventHandler(this.rdbFineMese_CheckedChanged);
      // 
      // txtNote
      // 
      this.txtNote.Location = new System.Drawing.Point(19, 86);
      this.txtNote.MaxLength = 25;
      this.txtNote.Multiline = true;
      this.txtNote.Name = "txtNote";
      this.txtNote.Size = new System.Drawing.Size(434, 19);
      this.txtNote.TabIndex = 2;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(16, 70);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(171, 13);
      this.label5.TabIndex = 4;
      this.label5.Text = "Descrizione modalita di pagamento";
      // 
      // lblCodice
      // 
      this.lblCodice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblCodice.Location = new System.Drawing.Point(19, 43);
      this.lblCodice.Name = "lblCodice";
      this.lblCodice.Size = new System.Drawing.Size(124, 20);
      this.lblCodice.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(16, 26);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(43, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Codice:";
      // 
      // lstValori
      // 
      this.lstValori.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.lstValori.FormattingEnabled = true;
      this.lstValori.Location = new System.Drawing.Point(10, 25);
      this.lstValori.Name = "lstValori";
      this.lstValori.Size = new System.Drawing.Size(247, 420);
      this.lstValori.TabIndex = 0;
      this.lstValori.SelectedIndexChanged += new System.EventHandler(this.lstValori_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(71, 13);
      this.label1.TabIndex = 9;
      this.label1.Text = "Elenco valori:";
      // 
      // bttAnnulla
      // 
      this.bttAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.bttAnnulla.Location = new System.Drawing.Point(482, 432);
      this.bttAnnulla.Name = "bttAnnulla";
      this.bttAnnulla.Size = new System.Drawing.Size(67, 24);
      this.bttAnnulla.TabIndex = 17;
      this.bttAnnulla.Text = "Annulla";
      this.bttAnnulla.UseVisualStyleBackColor = true;
      this.bttAnnulla.Visible = false;
      this.bttAnnulla.Click += new System.EventHandler(this.bttAnnulla_Click);
      // 
      // bttEnd
      // 
      this.bttEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.bttEnd.Location = new System.Drawing.Point(482, 432);
      this.bttEnd.Name = "bttEnd";
      this.bttEnd.Size = new System.Drawing.Size(67, 24);
      this.bttEnd.TabIndex = 16;
      this.bttEnd.Text = "Esci";
      this.bttEnd.UseVisualStyleBackColor = true;
      this.bttEnd.Click += new System.EventHandler(this.bttEnd_Click);
      // 
      // bttDelete
      // 
      this.bttDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.bttDelete.Location = new System.Drawing.Point(409, 432);
      this.bttDelete.Name = "bttDelete";
      this.bttDelete.Size = new System.Drawing.Size(67, 24);
      this.bttDelete.TabIndex = 14;
      this.bttDelete.Text = "Elimina";
      this.bttDelete.UseVisualStyleBackColor = true;
      this.bttDelete.Click += new System.EventHandler(this.bttDelete_Click);
      // 
      // bttSave
      // 
      this.bttSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.bttSave.Location = new System.Drawing.Point(409, 432);
      this.bttSave.Name = "bttSave";
      this.bttSave.Size = new System.Drawing.Size(67, 24);
      this.bttSave.TabIndex = 15;
      this.bttSave.Text = "Salva";
      this.bttSave.UseVisualStyleBackColor = true;
      this.bttSave.Visible = false;
      this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
      // 
      // cmbModPag
      // 
      this.cmbModPag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbModPag.FormattingEnabled = true;
      this.cmbModPag.Location = new System.Drawing.Point(249, 130);
      this.cmbModPag.Name = "cmbModPag";
      this.cmbModPag.Size = new System.Drawing.Size(204, 21);
      this.cmbModPag.TabIndex = 56;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(246, 114);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(106, 13);
      this.label6.TabIndex = 58;
      this.label6.Text = "Modalità pagamento:";
      // 
      // cmbCondPag
      // 
      this.cmbCondPag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbCondPag.FormattingEnabled = true;
      this.cmbCondPag.Location = new System.Drawing.Point(19, 130);
      this.cmbCondPag.Name = "cmbCondPag";
      this.cmbCondPag.Size = new System.Drawing.Size(204, 21);
      this.cmbCondPag.TabIndex = 55;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(19, 114);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(118, 13);
      this.label7.TabIndex = 57;
      this.label7.Text = "Condizione pagamento:";
      // 
      // frmTipoPag
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(740, 472);
      this.Controls.Add(this.bttModify);
      this.Controls.Add(this.bttNew);
      this.Controls.Add(this.grpbDettaglio);
      this.Controls.Add(this.lstValori);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.bttSave);
      this.Controls.Add(this.bttEnd);
      this.Controls.Add(this.bttDelete);
      this.Controls.Add(this.bttAnnulla);
      this.Name = "frmTipoPag";
      this.ShowIcon = false;
      this.Text = "Tabella - Tipologia Pagamento";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTipoPag_FormClosing);
      this.Load += new System.EventHandler(this.frmTipoPag_Load);
      this.grpbDettaglio.ResumeLayout(false);
      this.grpbDettaglio.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.grpbRipPag.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvPagamenti)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttModify;
        private System.Windows.Forms.Button bttNew;
        private System.Windows.Forms.GroupBox grpbDettaglio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpbRipPag;
        private System.Windows.Forms.DataGridView dgvPagamenti;
        private System.Windows.Forms.RadioButton rdbDaFatt;
        private System.Windows.Forms.RadioButton rdbImm;
        private System.Windows.Forms.RadioButton rdbFineMese;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCodice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstValori;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttAnnulla;
        private System.Windows.Forms.Button bttEnd;
        private System.Windows.Forms.Button bttDelete;
        private System.Windows.Forms.Button bttSave;
        private System.Windows.Forms.RadioButton rdbStampaCl;
        private System.Windows.Forms.RadioButton rdbStampAz;
        private System.Windows.Forms.Button bttPagMod;
        private System.Windows.Forms.Button bttPagDelete;
        private System.Windows.Forms.Button bttPagNew;
        private System.Windows.Forms.RadioButton rdbStampaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDataRif;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGiorni;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPercImp;
    private System.Windows.Forms.ComboBox cmbModPag;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox cmbCondPag;
    private System.Windows.Forms.Label label7;
  }
}