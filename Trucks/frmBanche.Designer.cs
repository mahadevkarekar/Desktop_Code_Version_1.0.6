namespace Trucks
{
    partial class frmBanche
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
            this.bttModify = new System.Windows.Forms.Button();
            this.bttNew = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCIN = new System.Windows.Forms.TextBox();
            this.txtSwift = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtCC = new System.Windows.Forms.TextBox();
            this.lblCodice = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtABI = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtIBAN = new System.Windows.Forms.TextBox();
            this.txtCAB = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtBanca = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lstValori = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bttEnd = new System.Windows.Forms.Button();
            this.bttAnnulla = new System.Windows.Forms.Button();
            this.bttDelete = new System.Windows.Forms.Button();
            this.bttSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttModify
            // 
            this.bttModify.Location = new System.Drawing.Point(326, 239);
            this.bttModify.Name = "bttModify";
            this.bttModify.Size = new System.Drawing.Size(67, 24);
            this.bttModify.TabIndex = 11;
            this.bttModify.Text = "Modifica";
            this.bttModify.UseVisualStyleBackColor = true;
            this.bttModify.Click += new System.EventHandler(this.bttModify_Click);
            // 
            // bttNew
            // 
            this.bttNew.Location = new System.Drawing.Point(223, 239);
            this.bttNew.Name = "bttNew";
            this.bttNew.Size = new System.Drawing.Size(67, 24);
            this.bttNew.TabIndex = 10;
            this.bttNew.Text = "Nuovo";
            this.bttNew.UseVisualStyleBackColor = true;
            this.bttNew.Click += new System.EventHandler(this.bttNew_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCIN);
            this.groupBox1.Controls.Add(this.txtSwift);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.txtCC);
            this.groupBox1.Controls.Add(this.lblCodice);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtABI);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtIBAN);
            this.groupBox1.Controls.Add(this.txtCAB);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtBanca);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Location = new System.Drawing.Point(221, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 203);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dettaglio";
            // 
            // txtCIN
            // 
            this.txtCIN.Location = new System.Drawing.Point(43, 172);
            this.txtCIN.MaxLength = 1;
            this.txtCIN.Name = "txtCIN";
            this.txtCIN.ReadOnly = true;
            this.txtCIN.Size = new System.Drawing.Size(28, 20);
            this.txtCIN.TabIndex = 6;
            // 
            // txtSwift
            // 
            this.txtSwift.Location = new System.Drawing.Point(105, 106);
            this.txtSwift.MaxLength = 20;
            this.txtSwift.Name = "txtSwift";
            this.txtSwift.ReadOnly = true;
            this.txtSwift.Size = new System.Drawing.Size(261, 20);
            this.txtSwift.TabIndex = 4;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(15, 175);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(28, 13);
            this.label20.TabIndex = 90;
            this.label20.Text = "CIN:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(15, 109);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(67, 13);
            this.label24.TabIndex = 82;
            this.label24.Text = "Banca Swift:";
            // 
            // txtCC
            // 
            this.txtCC.Location = new System.Drawing.Point(262, 172);
            this.txtCC.MaxLength = 12;
            this.txtCC.Name = "txtCC";
            this.txtCC.ReadOnly = true;
            this.txtCC.Size = new System.Drawing.Size(104, 20);
            this.txtCC.TabIndex = 9;
            // 
            // lblCodice
            // 
            this.lblCodice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCodice.Location = new System.Drawing.Point(18, 46);
            this.lblCodice.Name = "lblCodice";
            this.lblCodice.Size = new System.Drawing.Size(124, 20);
            this.lblCodice.TabIndex = 2;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(234, 175);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 13);
            this.label19.TabIndex = 88;
            this.label19.Text = "C/C:";
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
            // txtABI
            // 
            this.txtABI.Location = new System.Drawing.Point(186, 172);
            this.txtABI.MaxLength = 5;
            this.txtABI.Name = "txtABI";
            this.txtABI.ReadOnly = true;
            this.txtABI.Size = new System.Drawing.Size(45, 20);
            this.txtABI.TabIndex = 8;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(158, 175);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(27, 13);
            this.label18.TabIndex = 86;
            this.label18.Text = "ABI:";
            // 
            // txtIBAN
            // 
            this.txtIBAN.Location = new System.Drawing.Point(105, 79);
            this.txtIBAN.MaxLength = 35;
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.ReadOnly = true;
            this.txtIBAN.Size = new System.Drawing.Size(261, 20);
            this.txtIBAN.TabIndex = 3;
            // 
            // txtCAB
            // 
            this.txtCAB.Location = new System.Drawing.Point(105, 172);
            this.txtCAB.MaxLength = 5;
            this.txtCAB.Name = "txtCAB";
            this.txtCAB.ReadOnly = true;
            this.txtCAB.Size = new System.Drawing.Size(45, 20);
            this.txtCAB.TabIndex = 7;
            this.txtCAB.TextChanged += new System.EventHandler(this.txtCAB_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 13);
            this.label15.TabIndex = 80;
            this.label15.Text = "Codice IBAN:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(77, 175);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 84;
            this.label17.Text = "CAB:";
            // 
            // txtBanca
            // 
            this.txtBanca.Location = new System.Drawing.Point(138, 132);
            this.txtBanca.MaxLength = 30;
            this.txtBanca.Name = "txtBanca";
            this.txtBanca.ReadOnly = true;
            this.txtBanca.Size = new System.Drawing.Size(228, 20);
            this.txtBanca.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 135);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(117, 13);
            this.label16.TabIndex = 82;
            this.label16.Text = "Denominazione Banca:";
            // 
            // lstValori
            // 
            this.lstValori.FormattingEnabled = true;
            this.lstValori.Location = new System.Drawing.Point(1, 25);
            this.lstValori.Name = "lstValori";
            this.lstValori.Size = new System.Drawing.Size(214, 238);
            this.lstValori.TabIndex = 1;
            this.lstValori.SelectedIndexChanged += new System.EventHandler(this.lstValori_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Elenco valori:";
            // 
            // bttEnd
            // 
            this.bttEnd.Location = new System.Drawing.Point(531, 239);
            this.bttEnd.Name = "bttEnd";
            this.bttEnd.Size = new System.Drawing.Size(67, 24);
            this.bttEnd.TabIndex = 15;
            this.bttEnd.Text = "Esci";
            this.bttEnd.UseVisualStyleBackColor = true;
            this.bttEnd.Click += new System.EventHandler(this.bttEnd_Click);
            // 
            // bttAnnulla
            // 
            this.bttAnnulla.Location = new System.Drawing.Point(531, 239);
            this.bttAnnulla.Name = "bttAnnulla";
            this.bttAnnulla.Size = new System.Drawing.Size(67, 24);
            this.bttAnnulla.TabIndex = 13;
            this.bttAnnulla.Text = "Annulla";
            this.bttAnnulla.UseVisualStyleBackColor = true;
            this.bttAnnulla.Visible = false;
            this.bttAnnulla.Click += new System.EventHandler(this.bttAnnulla_Click);
            // 
            // bttDelete
            // 
            this.bttDelete.Location = new System.Drawing.Point(436, 239);
            this.bttDelete.Name = "bttDelete";
            this.bttDelete.Size = new System.Drawing.Size(67, 24);
            this.bttDelete.TabIndex = 14;
            this.bttDelete.Text = "Elimina";
            this.bttDelete.UseVisualStyleBackColor = true;
            this.bttDelete.Click += new System.EventHandler(this.bttDelete_Click);
            // 
            // bttSave
            // 
            this.bttSave.Location = new System.Drawing.Point(436, 239);
            this.bttSave.Name = "bttSave";
            this.bttSave.Size = new System.Drawing.Size(67, 24);
            this.bttSave.TabIndex = 12;
            this.bttSave.Text = "Salva";
            this.bttSave.UseVisualStyleBackColor = true;
            this.bttSave.Visible = false;
            this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
            // 
            // frmBanche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 271);
            this.Controls.Add(this.bttModify);
            this.Controls.Add(this.bttNew);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstValori);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttAnnulla);
            this.Controls.Add(this.bttSave);
            this.Controls.Add(this.bttDelete);
            this.Controls.Add(this.bttEnd);
            this.Name = "frmBanche";
            this.ShowIcon = false;
            this.Text = "Banche Aziendali";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBanche_FormClosing);
            this.Load += new System.EventHandler(this.frmBanche_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttModify;
        private System.Windows.Forms.Button bttNew;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCodice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstValori;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttEnd;
        private System.Windows.Forms.Button bttAnnulla;
        private System.Windows.Forms.Button bttDelete;
        private System.Windows.Forms.Button bttSave;
        private System.Windows.Forms.TextBox txtIBAN;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSwift;
        private System.Windows.Forms.TextBox txtCIN;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtCC;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtABI;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCAB;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtBanca;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label24;
    }
}