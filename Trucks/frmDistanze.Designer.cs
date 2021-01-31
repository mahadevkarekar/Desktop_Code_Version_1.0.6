namespace Trucks
{
    partial class frmDistanze
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
            this.cmbLocA = new System.Windows.Forms.ComboBox();
            this.cmbLocB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bttLocA = new System.Windows.Forms.Button();
            this.bttLocB = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lstValori = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudKm = new System.Windows.Forms.NumericUpDown();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bttAnnulla = new System.Windows.Forms.Button();
            this.bttEnd = new System.Windows.Forms.Button();
            this.bttDelete = new System.Windows.Forms.Button();
            this.bttModify = new System.Windows.Forms.Button();
            this.bttNew = new System.Windows.Forms.Button();
            this.bttSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKm)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Località di partenza:";
            // 
            // cmbLocA
            // 
            this.cmbLocA.Enabled = false;
            this.cmbLocA.FormattingEnabled = true;
            this.cmbLocA.Location = new System.Drawing.Point(132, 60);
            this.cmbLocA.Name = "cmbLocA";
            this.cmbLocA.Size = new System.Drawing.Size(191, 21);
            this.cmbLocA.TabIndex = 3;
            this.cmbLocA.SelectedIndexChanged += new System.EventHandler(this.cmbLocA_SelectedIndexChanged);
            // 
            // cmbLocB
            // 
            this.cmbLocB.Enabled = false;
            this.cmbLocB.FormattingEnabled = true;
            this.cmbLocB.Location = new System.Drawing.Point(132, 87);
            this.cmbLocB.Name = "cmbLocB";
            this.cmbLocB.Size = new System.Drawing.Size(191, 21);
            this.cmbLocB.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Località di destinazione:";
            // 
            // bttLocA
            // 
            this.bttLocA.Enabled = false;
            this.bttLocA.Location = new System.Drawing.Point(329, 60);
            this.bttLocA.Name = "bttLocA";
            this.bttLocA.Size = new System.Drawing.Size(26, 20);
            this.bttLocA.TabIndex = 4;
            this.bttLocA.Text = "...";
            this.bttLocA.UseVisualStyleBackColor = true;
            this.bttLocA.Click += new System.EventHandler(this.bttLocA_Click);
            // 
            // bttLocB
            // 
            this.bttLocB.Enabled = false;
            this.bttLocB.Location = new System.Drawing.Point(329, 88);
            this.bttLocB.Name = "bttLocB";
            this.bttLocB.Size = new System.Drawing.Size(26, 20);
            this.bttLocB.TabIndex = 6;
            this.bttLocB.Text = "...";
            this.bttLocB.UseVisualStyleBackColor = true;
            this.bttLocB.Click += new System.EventHandler(this.bttLocB_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Distanza:";
            // 
            // lstValori
            // 
            this.lstValori.FormattingEnabled = true;
            this.lstValori.Location = new System.Drawing.Point(8, 36);
            this.lstValori.Name = "lstValori";
            this.lstValori.Size = new System.Drawing.Size(222, 264);
            this.lstValori.TabIndex = 1;
            this.lstValori.SelectedIndexChanged += new System.EventHandler(this.lstValori_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Percorsi:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nudKm);
            this.groupBox1.Controls.Add(this.txtCodice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbLocA);
            this.groupBox1.Controls.Add(this.bttLocB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bttLocA);
            this.groupBox1.Controls.Add(this.cmbLocB);
            this.groupBox1.Location = new System.Drawing.Point(236, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 246);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dettaglio";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(9, 173);
            this.txtNote.MaxLength = 50;
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ReadOnly = true;
            this.txtNote.Size = new System.Drawing.Size(346, 61);
            this.txtNote.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Note:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(162, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Km";
            // 
            // nudKm
            // 
            this.nudKm.DecimalPlaces = 2;
            this.nudKm.Location = new System.Drawing.Point(60, 123);
            this.nudKm.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudKm.Name = "nudKm";
            this.nudKm.ReadOnly = true;
            this.nudKm.Size = new System.Drawing.Size(96, 20);
            this.nudKm.TabIndex = 7;
            this.nudKm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(57, 26);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.ReadOnly = true;
            this.txtCodice.Size = new System.Drawing.Size(69, 20);
            this.txtCodice.TabIndex = 2;
            this.txtCodice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Codice:";
            // 
            // bttAnnulla
            // 
            this.bttAnnulla.Location = new System.Drawing.Point(530, 276);
            this.bttAnnulla.Name = "bttAnnulla";
            this.bttAnnulla.Size = new System.Drawing.Size(67, 24);
            this.bttAnnulla.TabIndex = 12;
            this.bttAnnulla.Text = "Annulla";
            this.bttAnnulla.UseVisualStyleBackColor = true;
            this.bttAnnulla.Visible = false;
            this.bttAnnulla.Click += new System.EventHandler(this.bttAnnulla_Click);
            // 
            // bttEnd
            // 
            this.bttEnd.Location = new System.Drawing.Point(530, 277);
            this.bttEnd.Name = "bttEnd";
            this.bttEnd.Size = new System.Drawing.Size(67, 24);
            this.bttEnd.TabIndex = 13;
            this.bttEnd.Text = "Esci";
            this.bttEnd.UseVisualStyleBackColor = true;
            this.bttEnd.Click += new System.EventHandler(this.bttEnd_Click);
            // 
            // bttDelete
            // 
            this.bttDelete.Location = new System.Drawing.Point(442, 276);
            this.bttDelete.Name = "bttDelete";
            this.bttDelete.Size = new System.Drawing.Size(67, 24);
            this.bttDelete.TabIndex = 12;
            this.bttDelete.Text = "Elimina";
            this.bttDelete.UseVisualStyleBackColor = true;
            this.bttDelete.Click += new System.EventHandler(this.bttDelete_Click);
            // 
            // bttModify
            // 
            this.bttModify.Location = new System.Drawing.Point(353, 276);
            this.bttModify.Name = "bttModify";
            this.bttModify.Size = new System.Drawing.Size(67, 24);
            this.bttModify.TabIndex = 10;
            this.bttModify.Text = "Modifica";
            this.bttModify.UseVisualStyleBackColor = true;
            this.bttModify.Click += new System.EventHandler(this.bttModify_Click);
            // 
            // bttNew
            // 
            this.bttNew.Location = new System.Drawing.Point(263, 276);
            this.bttNew.Name = "bttNew";
            this.bttNew.Size = new System.Drawing.Size(67, 24);
            this.bttNew.TabIndex = 9;
            this.bttNew.Text = "Nuovo";
            this.bttNew.UseVisualStyleBackColor = true;
            this.bttNew.Click += new System.EventHandler(this.bttNew_Click);
            // 
            // bttSave
            // 
            this.bttSave.Location = new System.Drawing.Point(442, 277);
            this.bttSave.Name = "bttSave";
            this.bttSave.Size = new System.Drawing.Size(67, 24);
            this.bttSave.TabIndex = 11;
            this.bttSave.Text = "Salva";
            this.bttSave.UseVisualStyleBackColor = true;
            this.bttSave.Visible = false;
            this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
            // 
            // frmDistanze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 307);
            this.Controls.Add(this.bttModify);
            this.Controls.Add(this.bttNew);
            this.Controls.Add(this.bttSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstValori);
            this.Controls.Add(this.bttAnnulla);
            this.Controls.Add(this.bttEnd);
            this.Controls.Add(this.bttDelete);
            this.Name = "frmDistanze";
            this.ShowIcon = false;
            this.Text = "Gestione Tabelle - Distanze percorsi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDistanze_FormClosing);
            this.Load += new System.EventHandler(this.frmDistanze_Load);
            this.Shown += new System.EventHandler(this.frmDistanze_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLocA;
        private System.Windows.Forms.ComboBox cmbLocB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bttLocA;
        private System.Windows.Forms.Button bttLocB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstValori;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudKm;
        private System.Windows.Forms.TextBox txtCodice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bttAnnulla;
        private System.Windows.Forms.Button bttEnd;
        private System.Windows.Forms.Button bttDelete;
        private System.Windows.Forms.Button bttModify;
        private System.Windows.Forms.Button bttNew;
        private System.Windows.Forms.Button bttSave;
    }
}