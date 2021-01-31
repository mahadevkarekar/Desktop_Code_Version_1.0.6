namespace Trucks
{
    partial class frmModArticoli
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
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCateg = new System.Windows.Forms.ComboBox();
            this.cmbUM = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbIVA = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bttEsci = new System.Windows.Forms.Button();
            this.bttElimina = new System.Windows.Forms.Button();
            this.bttAnnulla = new System.Windows.Forms.Button();
            this.bttSave = new System.Windows.Forms.Button();
            this.nudPrezzo = new System.Windows.Forms.NumericUpDown();
            this.bttTabCateg = new System.Windows.Forms.Button();
            this.bttTabUM = new System.Windows.Forms.Button();
            this.bttTabIva = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrezzo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codice:";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(100, 17);
            this.txtCodice.MaxLength = 10;
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(114, 20);
            this.txtCodice.TabIndex = 1;
            this.txtCodice.TextChanged += new System.EventHandler(this.txtCodice_TextChanged);
            // 
            // txtDescr
            // 
            this.txtDescr.Location = new System.Drawing.Point(100, 43);
            this.txtDescr.MaxLength = 30;
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(311, 20);
            this.txtDescr.TabIndex = 3;
            this.txtDescr.TextChanged += new System.EventHandler(this.txtDescr_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrizione:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Categoria:";
            // 
            // cmbCateg
            // 
            this.cmbCateg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCateg.FormattingEnabled = true;
            this.cmbCateg.Location = new System.Drawing.Point(100, 69);
            this.cmbCateg.Name = "cmbCateg";
            this.cmbCateg.Size = new System.Drawing.Size(276, 21);
            this.cmbCateg.TabIndex = 5;
            this.cmbCateg.SelectedIndexChanged += new System.EventHandler(this.cmbCateg_SelectedIndexChanged);
            // 
            // cmbUM
            // 
            this.cmbUM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUM.FormattingEnabled = true;
            this.cmbUM.Location = new System.Drawing.Point(100, 96);
            this.cmbUM.Name = "cmbUM";
            this.cmbUM.Size = new System.Drawing.Size(76, 21);
            this.cmbUM.TabIndex = 7;
            this.cmbUM.SelectedIndexChanged += new System.EventHandler(this.cmbUM_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Unità di Misura:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Prezzo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "€";
            // 
            // cmbIVA
            // 
            this.cmbIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIVA.FormattingEnabled = true;
            this.cmbIVA.Location = new System.Drawing.Point(318, 122);
            this.cmbIVA.Name = "cmbIVA";
            this.cmbIVA.Size = new System.Drawing.Size(58, 21);
            this.cmbIVA.TabIndex = 10;
            this.cmbIVA.SelectedIndexChanged += new System.EventHandler(this.cmbIVA_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(244, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Aliquota IVA:";
            // 
            // bttEsci
            // 
            this.bttEsci.Location = new System.Drawing.Point(340, 167);
            this.bttEsci.Name = "bttEsci";
            this.bttEsci.Size = new System.Drawing.Size(60, 25);
            this.bttEsci.TabIndex = 15;
            this.bttEsci.Text = "Esci";
            this.bttEsci.UseVisualStyleBackColor = true;
            this.bttEsci.Click += new System.EventHandler(this.bttEsci_Click);
            // 
            // bttElimina
            // 
            this.bttElimina.Location = new System.Drawing.Point(183, 167);
            this.bttElimina.Name = "bttElimina";
            this.bttElimina.Size = new System.Drawing.Size(60, 25);
            this.bttElimina.TabIndex = 14;
            this.bttElimina.Text = "Elimina";
            this.bttElimina.UseVisualStyleBackColor = true;
            this.bttElimina.Click += new System.EventHandler(this.bttElimina_Click);
            // 
            // bttAnnulla
            // 
            this.bttAnnulla.Location = new System.Drawing.Point(100, 167);
            this.bttAnnulla.Name = "bttAnnulla";
            this.bttAnnulla.Size = new System.Drawing.Size(60, 25);
            this.bttAnnulla.TabIndex = 13;
            this.bttAnnulla.Text = "Annulla";
            this.bttAnnulla.UseVisualStyleBackColor = true;
            this.bttAnnulla.Click += new System.EventHandler(this.bttAnnulla_Click);
            // 
            // bttSave
            // 
            this.bttSave.Location = new System.Drawing.Point(17, 167);
            this.bttSave.Name = "bttSave";
            this.bttSave.Size = new System.Drawing.Size(60, 25);
            this.bttSave.TabIndex = 12;
            this.bttSave.Text = "Salva";
            this.bttSave.UseVisualStyleBackColor = true;
            this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
            // 
            // nudPrezzo
            // 
            this.nudPrezzo.DecimalPlaces = 2;
            this.nudPrezzo.Location = new System.Drawing.Point(98, 124);
            this.nudPrezzo.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudPrezzo.Name = "nudPrezzo";
            this.nudPrezzo.Size = new System.Drawing.Size(114, 20);
            this.nudPrezzo.TabIndex = 9;
            this.nudPrezzo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPrezzo.ValueChanged += new System.EventHandler(this.nudPrezzo_ValueChanged);
            // 
            // bttTabCateg
            // 
            this.bttTabCateg.Location = new System.Drawing.Point(382, 69);
            this.bttTabCateg.Name = "bttTabCateg";
            this.bttTabCateg.Size = new System.Drawing.Size(29, 21);
            this.bttTabCateg.TabIndex = 6;
            this.bttTabCateg.Text = "...";
            this.bttTabCateg.UseVisualStyleBackColor = true;
            this.bttTabCateg.Click += new System.EventHandler(this.bttTabCateg_Click);
            // 
            // bttTabUM
            // 
            this.bttTabUM.Location = new System.Drawing.Point(183, 96);
            this.bttTabUM.Name = "bttTabUM";
            this.bttTabUM.Size = new System.Drawing.Size(29, 21);
            this.bttTabUM.TabIndex = 8;
            this.bttTabUM.Text = "...";
            this.bttTabUM.UseVisualStyleBackColor = true;
            this.bttTabUM.Click += new System.EventHandler(this.bttTabUM_Click);
            // 
            // bttTabIva
            // 
            this.bttTabIva.Location = new System.Drawing.Point(382, 122);
            this.bttTabIva.Name = "bttTabIva";
            this.bttTabIva.Size = new System.Drawing.Size(29, 21);
            this.bttTabIva.TabIndex = 11;
            this.bttTabIva.Text = "...";
            this.bttTabIva.UseVisualStyleBackColor = true;
            this.bttTabIva.Click += new System.EventHandler(this.bttTabIva_Click);
            // 
            // frmModArticoli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 213);
            this.Controls.Add(this.bttTabIva);
            this.Controls.Add(this.bttTabUM);
            this.Controls.Add(this.bttTabCateg);
            this.Controls.Add(this.nudPrezzo);
            this.Controls.Add(this.bttEsci);
            this.Controls.Add(this.bttElimina);
            this.Controls.Add(this.bttAnnulla);
            this.Controls.Add(this.bttSave);
            this.Controls.Add(this.cmbIVA);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbUM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbCateg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodice);
            this.Controls.Add(this.label1);
            this.Name = "frmModArticoli";
            this.ShowIcon = false;
            this.Text = "Anagrafica Articoli - Nuovo";
            this.Activated += new System.EventHandler(this.frmModArticoli_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmModArticoli_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmModArticoli_FormClosed);
            this.Load += new System.EventHandler(this.frmModArticoli_Load);
            this.Shown += new System.EventHandler(this.frmModArticoli_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrezzo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodice;
        private System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCateg;
        private System.Windows.Forms.ComboBox cmbUM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbIVA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bttEsci;
        private System.Windows.Forms.Button bttElimina;
        private System.Windows.Forms.Button bttAnnulla;
        private System.Windows.Forms.Button bttSave;
        private System.Windows.Forms.NumericUpDown nudPrezzo;
        private System.Windows.Forms.Button bttTabCateg;
        private System.Windows.Forms.Button bttTabUM;
        private System.Windows.Forms.Button bttTabIva;
    }
}