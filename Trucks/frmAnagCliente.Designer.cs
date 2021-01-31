namespace Trucks
{
    partial class frmAnagCliente
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
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPIVA = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCitta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRagSoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bttFind = new System.Windows.Forms.Button();
            this.bttClear = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRagSoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIndirizzo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCAP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCitta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bttStampa = new System.Windows.Forms.Button();
            this.bttModifica = new System.Windows.Forms.Button();
            this.bttElimina = new System.Windows.Forms.Button();
            this.bttEsci = new System.Windows.Forms.Button();
            this.bttNuovo = new System.Windows.Forms.Button();
            this.txtCodFiscale = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(207, 46);
            this.txtTel.MaxLength = 25;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(104, 20);
            this.txtTel.TabIndex = 4;
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(153, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Telefono:";
            // 
            // txtPIVA
            // 
            this.txtPIVA.Location = new System.Drawing.Point(397, 12);
            this.txtPIVA.MaxLength = 13;
            this.txtPIVA.Name = "txtPIVA";
            this.txtPIVA.Size = new System.Drawing.Size(142, 20);
            this.txtPIVA.TabIndex = 2;
            this.txtPIVA.TextChanged += new System.EventHandler(this.txtPIVA_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(331, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Partita IVA:";
            // 
            // txtCitta
            // 
            this.txtCitta.Location = new System.Drawing.Point(34, 46);
            this.txtCitta.MaxLength = 25;
            this.txtCitta.Name = "txtCitta";
            this.txtCitta.Size = new System.Drawing.Size(104, 20);
            this.txtCitta.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Città:";
            // 
            // txtRagSoc
            // 
            this.txtRagSoc.Location = new System.Drawing.Point(97, 12);
            this.txtRagSoc.MaxLength = 50;
            this.txtRagSoc.Name = "txtRagSoc";
            this.txtRagSoc.Size = new System.Drawing.Size(223, 20);
            this.txtRagSoc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Ragione Sociale:";
            // 
            // bttFind
            // 
            this.bttFind.Location = new System.Drawing.Point(568, 12);
            this.bttFind.Name = "bttFind";
            this.bttFind.Size = new System.Drawing.Size(70, 27);
            this.bttFind.TabIndex = 6;
            this.bttFind.Text = "Cerca";
            this.bttFind.UseVisualStyleBackColor = true;
            this.bttFind.Click += new System.EventHandler(this.bttFind_Click);
            // 
            // bttClear
            // 
            this.bttClear.Location = new System.Drawing.Point(568, 46);
            this.bttClear.Name = "bttClear";
            this.bttClear.Size = new System.Drawing.Size(70, 27);
            this.bttClear.TabIndex = 7;
            this.bttClear.Text = "Pulisci";
            this.bttClear.UseVisualStyleBackColor = true;
            this.bttClear.Click += new System.EventHandler(this.bttClear_Click);
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
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColRagSoc,
            this.ColIndirizzo,
            this.ColCAP,
            this.ColCitta,
            this.ColProv,
            this.ColPIVA,
            this.ColTel,
            this.ColFax});
            this.dgvResult.Location = new System.Drawing.Point(9, 79);
            this.dgvResult.MultiSelect = false;
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(846, 263);
            this.dgvResult.TabIndex = 8;
            this.dgvResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellContentClick);
            this.dgvResult.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellContentDoubleClick);
            this.dgvResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellDoubleClick);
            // 
            // ColID
            // 
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColRagSoc
            // 
            this.ColRagSoc.HeaderText = "Ragione Sociale";
            this.ColRagSoc.Name = "ColRagSoc";
            this.ColRagSoc.ReadOnly = true;
            this.ColRagSoc.Visible = false;
            this.ColRagSoc.Width = 180;
            // 
            // ColIndirizzo
            // 
            this.ColIndirizzo.HeaderText = "Indirizzo";
            this.ColIndirizzo.Name = "ColIndirizzo";
            this.ColIndirizzo.ReadOnly = true;
            this.ColIndirizzo.Visible = false;
            this.ColIndirizzo.Width = 200;
            // 
            // ColCAP
            // 
            this.ColCAP.HeaderText = "CAP";
            this.ColCAP.Name = "ColCAP";
            this.ColCAP.ReadOnly = true;
            this.ColCAP.Visible = false;
            this.ColCAP.Width = 50;
            // 
            // ColCitta
            // 
            this.ColCitta.HeaderText = "Città";
            this.ColCitta.Name = "ColCitta";
            this.ColCitta.ReadOnly = true;
            this.ColCitta.Visible = false;
            this.ColCitta.Width = 105;
            // 
            // ColProv
            // 
            this.ColProv.HeaderText = "Prov.";
            this.ColProv.Name = "ColProv";
            this.ColProv.ReadOnly = true;
            this.ColProv.Visible = false;
            this.ColProv.Width = 40;
            // 
            // ColPIVA
            // 
            this.ColPIVA.HeaderText = "Partita IVA";
            this.ColPIVA.Name = "ColPIVA";
            this.ColPIVA.ReadOnly = true;
            this.ColPIVA.Visible = false;
            this.ColPIVA.Width = 130;
            // 
            // ColTel
            // 
            this.ColTel.HeaderText = "Telefono";
            this.ColTel.Name = "ColTel";
            this.ColTel.ReadOnly = true;
            this.ColTel.Visible = false;
            this.ColTel.Width = 130;
            // 
            // ColFax
            // 
            this.ColFax.HeaderText = "FAX";
            this.ColFax.Name = "ColFax";
            this.ColFax.ReadOnly = true;
            this.ColFax.Visible = false;
            this.ColFax.Width = 130;
            // 
            // bttStampa
            // 
            this.bttStampa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttStampa.Location = new System.Drawing.Point(9, 356);
            this.bttStampa.Name = "bttStampa";
            this.bttStampa.Size = new System.Drawing.Size(70, 27);
            this.bttStampa.TabIndex = 9;
            this.bttStampa.Text = "Stampa";
            this.bttStampa.UseVisualStyleBackColor = true;
            this.bttStampa.Click += new System.EventHandler(this.bttStampa_Click);
            // 
            // bttModifica
            // 
            this.bttModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttModifica.Location = new System.Drawing.Point(553, 356);
            this.bttModifica.Name = "bttModifica";
            this.bttModifica.Size = new System.Drawing.Size(70, 27);
            this.bttModifica.TabIndex = 11;
            this.bttModifica.Text = "Modifica";
            this.bttModifica.UseVisualStyleBackColor = true;
            this.bttModifica.Click += new System.EventHandler(this.bttModifica_Click);
            // 
            // bttElimina
            // 
            this.bttElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttElimina.Location = new System.Drawing.Point(648, 356);
            this.bttElimina.Name = "bttElimina";
            this.bttElimina.Size = new System.Drawing.Size(70, 27);
            this.bttElimina.TabIndex = 12;
            this.bttElimina.Text = "Elimina";
            this.bttElimina.UseVisualStyleBackColor = true;
            this.bttElimina.Click += new System.EventHandler(this.bttElimina_Click);
            // 
            // bttEsci
            // 
            this.bttEsci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttEsci.Location = new System.Drawing.Point(785, 356);
            this.bttEsci.Name = "bttEsci";
            this.bttEsci.Size = new System.Drawing.Size(70, 27);
            this.bttEsci.TabIndex = 13;
            this.bttEsci.Text = "Esci";
            this.bttEsci.UseVisualStyleBackColor = true;
            this.bttEsci.Click += new System.EventHandler(this.bttEsci_Click);
            // 
            // bttNuovo
            // 
            this.bttNuovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttNuovo.Location = new System.Drawing.Point(458, 356);
            this.bttNuovo.Name = "bttNuovo";
            this.bttNuovo.Size = new System.Drawing.Size(70, 27);
            this.bttNuovo.TabIndex = 10;
            this.bttNuovo.Text = "Nuovo";
            this.bttNuovo.UseVisualStyleBackColor = true;
            this.bttNuovo.Click += new System.EventHandler(this.bttNuovo_Click);
            // 
            // txtCodFiscale
            // 
            this.txtCodFiscale.Location = new System.Drawing.Point(397, 46);
            this.txtCodFiscale.MaxLength = 13;
            this.txtCodFiscale.Name = "txtCodFiscale";
            this.txtCodFiscale.Size = new System.Drawing.Size(142, 20);
            this.txtCodFiscale.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Cod. Fiscale:";
            // 
            // frmAnagCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 395);
            this.Controls.Add(this.txtCodFiscale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bttNuovo);
            this.Controls.Add(this.bttEsci);
            this.Controls.Add(this.bttElimina);
            this.Controls.Add(this.bttModifica);
            this.Controls.Add(this.bttStampa);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.bttClear);
            this.Controls.Add(this.bttFind);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPIVA);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCitta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRagSoc);
            this.Controls.Add(this.label1);
            this.Name = "frmAnagCliente";
            this.ShowIcon = false;
            this.Text = "Anagrafica Clienti - Ricerca";
            this.Load += new System.EventHandler(this.frmAnagCliente_Load);
            this.Shown += new System.EventHandler(this.frmAnagCliente_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPIVA;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCitta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRagSoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttFind;
        private System.Windows.Forms.Button bttClear;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button bttStampa;
        private System.Windows.Forms.Button bttModifica;
        private System.Windows.Forms.Button bttElimina;
        private System.Windows.Forms.Button bttEsci;
        private System.Windows.Forms.Button bttNuovo;
        private System.Windows.Forms.TextBox txtCodFiscale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRagSoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIndirizzo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCAP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCitta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFax;
    }
}