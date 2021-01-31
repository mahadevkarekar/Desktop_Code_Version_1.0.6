namespace Trucks
{
    partial class frmAnagAutomezzi
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTarga = new System.Windows.Forms.TextBox();
            this.txtTelaio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAssicurazione = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpAssScadDal = new System.Windows.Forms.DateTimePicker();
            this.dtpAssScadAl = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.bttCerca = new System.Windows.Forms.Button();
            this.bttClear = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTarga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModello = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTelaio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPortata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAssic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColScadAssic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColScadBollo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bttNuovo = new System.Windows.Forms.Button();
            this.bttEsci = new System.Windows.Forms.Button();
            this.bttElimina = new System.Windows.Forms.Button();
            this.bttModifica = new System.Windows.Forms.Button();
            this.bttStampa = new System.Windows.Forms.Button();
            this.txtModello = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Targa:";
            // 
            // txtTarga
            // 
            this.txtTarga.Location = new System.Drawing.Point(43, 15);
            this.txtTarga.MaxLength = 8;
            this.txtTarga.Name = "txtTarga";
            this.txtTarga.Size = new System.Drawing.Size(64, 20);
            this.txtTarga.TabIndex = 1;
            // 
            // txtTelaio
            // 
            this.txtTelaio.Location = new System.Drawing.Point(163, 15);
            this.txtTelaio.MaxLength = 25;
            this.txtTelaio.Name = "txtTelaio";
            this.txtTelaio.Size = new System.Drawing.Size(137, 20);
            this.txtTelaio.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Telaio:";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(362, 14);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(118, 20);
            this.txtMarca.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Marca:";
            // 
            // txtAssicurazione
            // 
            this.txtAssicurazione.Location = new System.Drawing.Point(80, 41);
            this.txtAssicurazione.Name = "txtAssicurazione";
            this.txtAssicurazione.Size = new System.Drawing.Size(164, 20);
            this.txtAssicurazione.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Assicurazione:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Scadenza Assicurazione dal:";
            // 
            // dtpAssScadDal
            // 
            this.dtpAssScadDal.Checked = false;
            this.dtpAssScadDal.CustomFormat = "dd/MM/yyyy";
            this.dtpAssScadDal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAssScadDal.Location = new System.Drawing.Point(404, 40);
            this.dtpAssScadDal.Name = "dtpAssScadDal";
            this.dtpAssScadDal.ShowCheckBox = true;
            this.dtpAssScadDal.Size = new System.Drawing.Size(97, 20);
            this.dtpAssScadDal.TabIndex = 6;
            // 
            // dtpAssScadAl
            // 
            this.dtpAssScadAl.Checked = false;
            this.dtpAssScadAl.CustomFormat = "dd/MM/yyyy";
            this.dtpAssScadAl.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAssScadAl.Location = new System.Drawing.Point(551, 40);
            this.dtpAssScadAl.Name = "dtpAssScadAl";
            this.dtpAssScadAl.ShowCheckBox = true;
            this.dtpAssScadAl.Size = new System.Drawing.Size(99, 20);
            this.dtpAssScadAl.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(526, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Al:";
            // 
            // bttCerca
            // 
            this.bttCerca.Location = new System.Drawing.Point(666, 12);
            this.bttCerca.Name = "bttCerca";
            this.bttCerca.Size = new System.Drawing.Size(70, 23);
            this.bttCerca.TabIndex = 8;
            this.bttCerca.Text = "Cerca";
            this.bttCerca.UseVisualStyleBackColor = true;
            this.bttCerca.Click += new System.EventHandler(this.bttCerca_Click);
            // 
            // bttClear
            // 
            this.bttClear.Location = new System.Drawing.Point(666, 44);
            this.bttClear.Name = "bttClear";
            this.bttClear.Size = new System.Drawing.Size(70, 23);
            this.bttClear.TabIndex = 9;
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
            this.colID,
            this.ColCodice,
            this.ColTarga,
            this.ColMarca,
            this.colModello,
            this.ColTelaio,
            this.ColPortata,
            this.ColAssic,
            this.ColScadAssic,
            this.ColScadBollo});
            this.dgvResult.Location = new System.Drawing.Point(5, 73);
            this.dgvResult.MultiSelect = false;
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(731, 200);
            this.dgvResult.TabIndex = 10;
            this.dgvResult.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellContentDoubleClick);
            this.dgvResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellDoubleClick);
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // ColCodice
            // 
            this.ColCodice.HeaderText = "Codice";
            this.ColCodice.Name = "ColCodice";
            this.ColCodice.ReadOnly = true;
            this.ColCodice.Visible = false;
            this.ColCodice.Width = 70;
            // 
            // ColTarga
            // 
            this.ColTarga.HeaderText = "Targa";
            this.ColTarga.Name = "ColTarga";
            this.ColTarga.ReadOnly = true;
            this.ColTarga.Visible = false;
            // 
            // ColMarca
            // 
            this.ColMarca.HeaderText = "Marca";
            this.ColMarca.Name = "ColMarca";
            this.ColMarca.ReadOnly = true;
            this.ColMarca.Visible = false;
            this.ColMarca.Width = 140;
            // 
            // colModello
            // 
            this.colModello.HeaderText = "Modello";
            this.colModello.Name = "colModello";
            this.colModello.ReadOnly = true;
            this.colModello.Visible = false;
            this.colModello.Width = 140;
            // 
            // ColTelaio
            // 
            this.ColTelaio.HeaderText = "Telaio";
            this.ColTelaio.Name = "ColTelaio";
            this.ColTelaio.ReadOnly = true;
            this.ColTelaio.Visible = false;
            this.ColTelaio.Width = 120;
            // 
            // ColPortata
            // 
            this.ColPortata.HeaderText = "Portata";
            this.ColPortata.Name = "ColPortata";
            this.ColPortata.ReadOnly = true;
            this.ColPortata.Visible = false;
            this.ColPortata.Width = 50;
            // 
            // ColAssic
            // 
            this.ColAssic.HeaderText = "Assicurazione";
            this.ColAssic.Name = "ColAssic";
            this.ColAssic.ReadOnly = true;
            this.ColAssic.Visible = false;
            this.ColAssic.Width = 140;
            // 
            // ColScadAssic
            // 
            this.ColScadAssic.HeaderText = "Scad. Assic.";
            this.ColScadAssic.Name = "ColScadAssic";
            this.ColScadAssic.ReadOnly = true;
            this.ColScadAssic.Visible = false;
            // 
            // ColScadBollo
            // 
            this.ColScadBollo.HeaderText = "Scad. Bollo";
            this.ColScadBollo.Name = "ColScadBollo";
            this.ColScadBollo.ReadOnly = true;
            this.ColScadBollo.Visible = false;
            // 
            // bttNuovo
            // 
            this.bttNuovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttNuovo.Location = new System.Drawing.Point(286, 287);
            this.bttNuovo.Name = "bttNuovo";
            this.bttNuovo.Size = new System.Drawing.Size(70, 27);
            this.bttNuovo.TabIndex = 12;
            this.bttNuovo.Text = "Nuovo";
            this.bttNuovo.UseVisualStyleBackColor = true;
            this.bttNuovo.Click += new System.EventHandler(this.bttNuovo_Click);
            // 
            // bttEsci
            // 
            this.bttEsci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttEsci.Location = new System.Drawing.Point(666, 287);
            this.bttEsci.Name = "bttEsci";
            this.bttEsci.Size = new System.Drawing.Size(70, 27);
            this.bttEsci.TabIndex = 15;
            this.bttEsci.Text = "Esci";
            this.bttEsci.UseVisualStyleBackColor = true;
            this.bttEsci.Click += new System.EventHandler(this.bttEsci_Click);
            // 
            // bttElimina
            // 
            this.bttElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttElimina.Location = new System.Drawing.Point(476, 287);
            this.bttElimina.Name = "bttElimina";
            this.bttElimina.Size = new System.Drawing.Size(70, 27);
            this.bttElimina.TabIndex = 14;
            this.bttElimina.Text = "Elimina";
            this.bttElimina.UseVisualStyleBackColor = true;
            this.bttElimina.Click += new System.EventHandler(this.bttElimina_Click);
            // 
            // bttModifica
            // 
            this.bttModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttModifica.Location = new System.Drawing.Point(381, 287);
            this.bttModifica.Name = "bttModifica";
            this.bttModifica.Size = new System.Drawing.Size(70, 27);
            this.bttModifica.TabIndex = 13;
            this.bttModifica.Text = "Modifica";
            this.bttModifica.UseVisualStyleBackColor = true;
            this.bttModifica.Click += new System.EventHandler(this.bttModifica_Click);
            // 
            // bttStampa
            // 
            this.bttStampa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttStampa.Location = new System.Drawing.Point(5, 287);
            this.bttStampa.Name = "bttStampa";
            this.bttStampa.Size = new System.Drawing.Size(70, 27);
            this.bttStampa.TabIndex = 11;
            this.bttStampa.Text = "Stampa";
            this.bttStampa.UseVisualStyleBackColor = true;
            this.bttStampa.Click += new System.EventHandler(this.bttStampa_Click);
            // 
            // txtModello
            // 
            this.txtModello.Location = new System.Drawing.Point(532, 14);
            this.txtModello.Name = "txtModello";
            this.txtModello.Size = new System.Drawing.Size(118, 20);
            this.txtModello.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(486, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "Modello:";
            // 
            // frmAnagAutomezzi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 326);
            this.Controls.Add(this.txtModello);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bttNuovo);
            this.Controls.Add(this.bttEsci);
            this.Controls.Add(this.bttElimina);
            this.Controls.Add(this.bttModifica);
            this.Controls.Add(this.bttStampa);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.bttClear);
            this.Controls.Add(this.bttCerca);
            this.Controls.Add(this.dtpAssScadAl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpAssScadDal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAssicurazione);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTelaio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTarga);
            this.Controls.Add(this.label1);
            this.Name = "frmAnagAutomezzi";
            this.ShowIcon = false;
            this.Text = "Anagrafica Automezzi - Ricerca";
            this.Load += new System.EventHandler(this.frmAnagAutomezzi_Load);
            this.Shown += new System.EventHandler(this.frmAnagAutomezzi_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTarga;
        private System.Windows.Forms.TextBox txtTelaio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAssicurazione;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpAssScadDal;
        private System.Windows.Forms.DateTimePicker dtpAssScadAl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bttCerca;
        private System.Windows.Forms.Button bttClear;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button bttNuovo;
        private System.Windows.Forms.Button bttEsci;
        private System.Windows.Forms.Button bttElimina;
        private System.Windows.Forms.Button bttModifica;
        private System.Windows.Forms.Button bttStampa;
        private System.Windows.Forms.TextBox txtModello;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTarga;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModello;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTelaio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPortata;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAssic;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColScadAssic;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColScadBollo;
    }
}