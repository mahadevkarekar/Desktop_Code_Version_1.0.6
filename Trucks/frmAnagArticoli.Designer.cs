namespace Trucks
{
    partial class frmAnagArticoli
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
            this.bttNuovo = new System.Windows.Forms.Button();
            this.bttEsci = new System.Windows.Forms.Button();
            this.bttElimina = new System.Windows.Forms.Button();
            this.bttModifica = new System.Windows.Forms.Button();
            this.bttStampa = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrezzo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bttClear = new System.Windows.Forms.Button();
            this.bttFind = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.cmbIva = new System.Windows.Forms.ComboBox();
            this.cmbUM = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // bttNuovo
            // 
            this.bttNuovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttNuovo.Location = new System.Drawing.Point(457, 356);
            this.bttNuovo.Name = "bttNuovo";
            this.bttNuovo.Size = new System.Drawing.Size(70, 27);
            this.bttNuovo.TabIndex = 10;
            this.bttNuovo.Text = "Nuovo";
            this.bttNuovo.UseVisualStyleBackColor = true;
            this.bttNuovo.Click += new System.EventHandler(this.bttNuovo_Click);
            // 
            // bttEsci
            // 
            this.bttEsci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttEsci.Location = new System.Drawing.Point(784, 356);
            this.bttEsci.Name = "bttEsci";
            this.bttEsci.Size = new System.Drawing.Size(70, 27);
            this.bttEsci.TabIndex = 13;
            this.bttEsci.Text = "Esci";
            this.bttEsci.UseVisualStyleBackColor = true;
            this.bttEsci.Click += new System.EventHandler(this.bttEsci_Click);
            // 
            // bttElimina
            // 
            this.bttElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttElimina.Location = new System.Drawing.Point(647, 356);
            this.bttElimina.Name = "bttElimina";
            this.bttElimina.Size = new System.Drawing.Size(70, 27);
            this.bttElimina.TabIndex = 12;
            this.bttElimina.Text = "Elimina";
            this.bttElimina.UseVisualStyleBackColor = true;
            this.bttElimina.Click += new System.EventHandler(this.bttElimina_Click);
            // 
            // bttModifica
            // 
            this.bttModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttModifica.Location = new System.Drawing.Point(552, 356);
            this.bttModifica.Name = "bttModifica";
            this.bttModifica.Size = new System.Drawing.Size(70, 27);
            this.bttModifica.TabIndex = 11;
            this.bttModifica.Text = "Modifica";
            this.bttModifica.UseVisualStyleBackColor = true;
            this.bttModifica.Click += new System.EventHandler(this.bttModifica_Click);
            // 
            // bttStampa
            // 
            this.bttStampa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttStampa.Location = new System.Drawing.Point(8, 356);
            this.bttStampa.Name = "bttStampa";
            this.bttStampa.Size = new System.Drawing.Size(70, 27);
            this.bttStampa.TabIndex = 9;
            this.bttStampa.Text = "Stampa";
            this.bttStampa.UseVisualStyleBackColor = true;
            this.bttStampa.Click += new System.EventHandler(this.bttStampa_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToResizeRows = false;
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
            this.ColCodice,
            this.ColDescr,
            this.ColCategoria,
            this.ColUM,
            this.ColPrezzo,
            this.ColIVA});
            this.dgvResult.Location = new System.Drawing.Point(8, 79);
            this.dgvResult.MultiSelect = false;
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(846, 263);
            this.dgvResult.TabIndex = 8;
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
            // ColCodice
            // 
            this.ColCodice.HeaderText = "Codice";
            this.ColCodice.Name = "ColCodice";
            this.ColCodice.ReadOnly = true;
            this.ColCodice.Visible = false;
            this.ColCodice.Width = 140;
            // 
            // ColDescr
            // 
            this.ColDescr.HeaderText = "Descrizione";
            this.ColDescr.Name = "ColDescr";
            this.ColDescr.ReadOnly = true;
            this.ColDescr.Visible = false;
            this.ColDescr.Width = 300;
            // 
            // ColCategoria
            // 
            this.ColCategoria.HeaderText = "Categoria";
            this.ColCategoria.Name = "ColCategoria";
            this.ColCategoria.ReadOnly = true;
            this.ColCategoria.Visible = false;
            this.ColCategoria.Width = 160;
            // 
            // ColUM
            // 
            this.ColUM.HeaderText = "U.M.";
            this.ColUM.Name = "ColUM";
            this.ColUM.ReadOnly = true;
            this.ColUM.Visible = false;
            this.ColUM.Width = 60;
            // 
            // ColPrezzo
            // 
            this.ColPrezzo.HeaderText = "Prezzo";
            this.ColPrezzo.Name = "ColPrezzo";
            this.ColPrezzo.ReadOnly = true;
            this.ColPrezzo.Visible = false;
            // 
            // ColIVA
            // 
            this.ColIVA.HeaderText = "IVA";
            this.ColIVA.Name = "ColIVA";
            this.ColIVA.ReadOnly = true;
            this.ColIVA.Visible = false;
            this.ColIVA.Width = 40;
            // 
            // bttClear
            // 
            this.bttClear.Location = new System.Drawing.Point(567, 46);
            this.bttClear.Name = "bttClear";
            this.bttClear.Size = new System.Drawing.Size(70, 27);
            this.bttClear.TabIndex = 7;
            this.bttClear.Text = "Pulisci";
            this.bttClear.UseVisualStyleBackColor = true;
            this.bttClear.Click += new System.EventHandler(this.bttClear_Click);
            // 
            // bttFind
            // 
            this.bttFind.Location = new System.Drawing.Point(567, 12);
            this.bttFind.Name = "bttFind";
            this.bttFind.Size = new System.Drawing.Size(70, 27);
            this.bttFind.TabIndex = 6;
            this.bttFind.Text = "Cerca";
            this.bttFind.UseVisualStyleBackColor = true;
            this.bttFind.Click += new System.EventHandler(this.bttFind_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(226, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "IVA:";
            // 
            // txtDescr
            // 
            this.txtDescr.Location = new System.Drawing.Point(259, 12);
            this.txtDescr.MaxLength = 13;
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(240, 20);
            this.txtDescr.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(188, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Descrizione:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Categoria:";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(63, 12);
            this.txtCodice.MaxLength = 50;
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(113, 20);
            this.txtCodice.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Codice:";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(63, 46);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(148, 21);
            this.cmbCategoria.TabIndex = 3;
            // 
            // cmbIva
            // 
            this.cmbIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIva.FormattingEnabled = true;
            this.cmbIva.Location = new System.Drawing.Point(259, 46);
            this.cmbIva.Name = "cmbIva";
            this.cmbIva.Size = new System.Drawing.Size(65, 21);
            this.cmbIva.TabIndex = 4;
            // 
            // cmbUM
            // 
            this.cmbUM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUM.FormattingEnabled = true;
            this.cmbUM.Location = new System.Drawing.Point(430, 46);
            this.cmbUM.Name = "cmbUM";
            this.cmbUM.Size = new System.Drawing.Size(69, 21);
            this.cmbUM.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "Unità di Misura:";
            // 
            // frmAnagArticoli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 395);
            this.Controls.Add(this.cmbUM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbIva);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.bttNuovo);
            this.Controls.Add(this.bttEsci);
            this.Controls.Add(this.bttElimina);
            this.Controls.Add(this.bttModifica);
            this.Controls.Add(this.bttStampa);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.bttClear);
            this.Controls.Add(this.bttFind);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDescr);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCodice);
            this.Controls.Add(this.label1);
            this.Name = "frmAnagArticoli";
            this.ShowIcon = false;
            this.Text = "Anagrafica Articoli - Ricerca";
            this.Load += new System.EventHandler(this.frmAnagArticoli_Load);
            this.Shown += new System.EventHandler(this.frmAnagArticoli_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttNuovo;
        private System.Windows.Forms.Button bttEsci;
        private System.Windows.Forms.Button bttElimina;
        private System.Windows.Forms.Button bttModifica;
        private System.Windows.Forms.Button bttStampa;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button bttClear;
        private System.Windows.Forms.Button bttFind;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ComboBox cmbIva;
        private System.Windows.Forms.ComboBox cmbUM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrezzo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIVA;
    }
}