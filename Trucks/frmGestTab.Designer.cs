namespace Trucks
{
    partial class frmGestTab
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
            this.lstValori = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbEsenzione = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rdbModPagBanca = new System.Windows.Forms.RadioButton();
            this.rdbModPagCassa = new System.Windows.Forms.RadioButton();
            this.lvlPerc = new System.Windows.Forms.Label();
            this.nudValore = new System.Windows.Forms.NumericUpDown();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValore = new System.Windows.Forms.TextBox();
            this.lblCodice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bttNew = new System.Windows.Forms.Button();
            this.bttModify = new System.Windows.Forms.Button();
            this.bttDelete = new System.Windows.Forms.Button();
            this.bttEnd = new System.Windows.Forms.Button();
            this.bttSave = new System.Windows.Forms.Button();
            this.bttAnnulla = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValore)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Elenco valori:";
            // 
            // lstValori
            // 
            this.lstValori.FormattingEnabled = true;
            this.lstValori.Location = new System.Drawing.Point(10, 32);
            this.lstValori.Name = "lstValori";
            this.lstValori.Size = new System.Drawing.Size(214, 238);
            this.lstValori.TabIndex = 0;
            this.lstValori.SelectedIndexChanged += new System.EventHandler(this.lstValori_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEsenzione);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rdbModPagBanca);
            this.groupBox1.Controls.Add(this.rdbModPagCassa);
            this.groupBox1.Controls.Add(this.lvlPerc);
            this.groupBox1.Controls.Add(this.nudValore);
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtValore);
            this.groupBox1.Controls.Add(this.lblCodice);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(230, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 203);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dettaglio";
            // 
            // cmbEsenzione
            // 
            this.cmbEsenzione.DisplayMember = "Descrizione";
            this.cmbEsenzione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEsenzione.FormattingEnabled = true;
            this.cmbEsenzione.Location = new System.Drawing.Point(165, 95);
            this.cmbEsenzione.Name = "cmbEsenzione";
            this.cmbEsenzione.Size = new System.Drawing.Size(288, 21);
            this.cmbEsenzione.TabIndex = 54;
            this.cmbEsenzione.ValueMember = "Valore";
            this.cmbEsenzione.VisibleChanged += new System.EventHandler(this.cmbEsenzione_VisibleChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Esenzione:";
            // 
            // rdbModPagBanca
            // 
            this.rdbModPagBanca.AutoSize = true;
            this.rdbModPagBanca.Enabled = false;
            this.rdbModPagBanca.Location = new System.Drawing.Point(101, 95);
            this.rdbModPagBanca.Name = "rdbModPagBanca";
            this.rdbModPagBanca.Size = new System.Drawing.Size(56, 17);
            this.rdbModPagBanca.TabIndex = 4;
            this.rdbModPagBanca.Text = "Banca";
            this.rdbModPagBanca.UseVisualStyleBackColor = true;
            this.rdbModPagBanca.Visible = false;
            // 
            // rdbModPagCassa
            // 
            this.rdbModPagCassa.AutoSize = true;
            this.rdbModPagCassa.Checked = true;
            this.rdbModPagCassa.Enabled = false;
            this.rdbModPagCassa.Location = new System.Drawing.Point(18, 95);
            this.rdbModPagCassa.Name = "rdbModPagCassa";
            this.rdbModPagCassa.Size = new System.Drawing.Size(54, 17);
            this.rdbModPagCassa.TabIndex = 3;
            this.rdbModPagCassa.TabStop = true;
            this.rdbModPagCassa.Text = "Cassa";
            this.rdbModPagCassa.UseVisualStyleBackColor = true;
            this.rdbModPagCassa.Visible = false;
            // 
            // lvlPerc
            // 
            this.lvlPerc.AutoSize = true;
            this.lvlPerc.Location = new System.Drawing.Point(109, 95);
            this.lvlPerc.Name = "lvlPerc";
            this.lvlPerc.Size = new System.Drawing.Size(15, 13);
            this.lvlPerc.TabIndex = 7;
            this.lvlPerc.Text = "%";
            this.lvlPerc.Visible = false;
            // 
            // nudValore
            // 
            this.nudValore.DecimalPlaces = 2;
            this.nudValore.Enabled = false;
            this.nudValore.Location = new System.Drawing.Point(18, 92);
            this.nudValore.Name = "nudValore";
            this.nudValore.ReadOnly = true;
            this.nudValore.Size = new System.Drawing.Size(85, 20);
            this.nudValore.TabIndex = 5;
            this.nudValore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudValore.Visible = false;
            this.nudValore.ValueChanged += new System.EventHandler(this.nudValore_ValueChanged);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(18, 140);
            this.txtNote.MaxLength = 50;
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ReadOnly = true;
            this.txtNote.Size = new System.Drawing.Size(576, 57);
            this.txtNote.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Descrizione\\Note";
            // 
            // txtValore
            // 
            this.txtValore.Location = new System.Drawing.Point(18, 92);
            this.txtValore.MaxLength = 50;
            this.txtValore.Name = "txtValore";
            this.txtValore.ReadOnly = true;
            this.txtValore.Size = new System.Drawing.Size(285, 20);
            this.txtValore.TabIndex = 2;
            // 
            // lblCodice
            // 
            this.lblCodice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCodice.Location = new System.Drawing.Point(18, 46);
            this.lblCodice.Name = "lblCodice";
            this.lblCodice.Size = new System.Drawing.Size(124, 20);
            this.lblCodice.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Valore:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Codice:";
            // 
            // bttNew
            // 
            this.bttNew.Location = new System.Drawing.Point(247, 246);
            this.bttNew.Name = "bttNew";
            this.bttNew.Size = new System.Drawing.Size(67, 24);
            this.bttNew.TabIndex = 7;
            this.bttNew.Text = "Nuovo";
            this.bttNew.UseVisualStyleBackColor = true;
            this.bttNew.Click += new System.EventHandler(this.bttNew_Click);
            // 
            // bttModify
            // 
            this.bttModify.Location = new System.Drawing.Point(320, 246);
            this.bttModify.Name = "bttModify";
            this.bttModify.Size = new System.Drawing.Size(67, 24);
            this.bttModify.TabIndex = 8;
            this.bttModify.Text = "Modifica";
            this.bttModify.UseVisualStyleBackColor = true;
            this.bttModify.Click += new System.EventHandler(this.bttModify_Click);
            // 
            // bttDelete
            // 
            this.bttDelete.Location = new System.Drawing.Point(394, 246);
            this.bttDelete.Name = "bttDelete";
            this.bttDelete.Size = new System.Drawing.Size(67, 24);
            this.bttDelete.TabIndex = 5;
            this.bttDelete.Text = "Elimina";
            this.bttDelete.UseVisualStyleBackColor = true;
            this.bttDelete.Click += new System.EventHandler(this.bttDelete_Click);
            // 
            // bttEnd
            // 
            this.bttEnd.Location = new System.Drawing.Point(467, 246);
            this.bttEnd.Name = "bttEnd";
            this.bttEnd.Size = new System.Drawing.Size(67, 24);
            this.bttEnd.TabIndex = 6;
            this.bttEnd.Text = "Esci";
            this.bttEnd.UseVisualStyleBackColor = true;
            this.bttEnd.Click += new System.EventHandler(this.bttEnd_Click);
            // 
            // bttSave
            // 
            this.bttSave.Location = new System.Drawing.Point(393, 246);
            this.bttSave.Name = "bttSave";
            this.bttSave.Size = new System.Drawing.Size(67, 24);
            this.bttSave.TabIndex = 9;
            this.bttSave.Text = "Salva";
            this.bttSave.UseVisualStyleBackColor = true;
            this.bttSave.Visible = false;
            this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
            // 
            // bttAnnulla
            // 
            this.bttAnnulla.Location = new System.Drawing.Point(466, 246);
            this.bttAnnulla.Name = "bttAnnulla";
            this.bttAnnulla.Size = new System.Drawing.Size(67, 24);
            this.bttAnnulla.TabIndex = 10;
            this.bttAnnulla.Text = "Annulla";
            this.bttAnnulla.UseVisualStyleBackColor = true;
            this.bttAnnulla.Visible = false;
            this.bttAnnulla.Click += new System.EventHandler(this.bttAnnulla_Click);
            // 
            // frmGestTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 277);
            this.Controls.Add(this.bttModify);
            this.Controls.Add(this.bttNew);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstValori);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttAnnulla);
            this.Controls.Add(this.bttSave);
            this.Controls.Add(this.bttDelete);
            this.Controls.Add(this.bttEnd);
            this.Name = "frmGestTab";
            this.ShowIcon = false;
            this.Text = "Gestione Tabelle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGestTab_FormClosing);
            this.Load += new System.EventHandler(this.frmGestTab_Load);
            this.Shown += new System.EventHandler(this.frmGestTab_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstValori;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValore;
        private System.Windows.Forms.Label lblCodice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bttNew;
        private System.Windows.Forms.Button bttModify;
        private System.Windows.Forms.Button bttDelete;
        private System.Windows.Forms.Button bttEnd;
        private System.Windows.Forms.Button bttSave;
        private System.Windows.Forms.Button bttAnnulla;
        private System.Windows.Forms.Label lvlPerc;
        private System.Windows.Forms.NumericUpDown nudValore;
        private System.Windows.Forms.RadioButton rdbModPagBanca;
        private System.Windows.Forms.RadioButton rdbModPagCassa;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox cmbEsenzione;
  }
}