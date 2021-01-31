namespace Trucks
{
    partial class frmLogin
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbUser = new System.Windows.Forms.TextBox();
            this.txtbPwd = new System.Windows.Forms.TextBox();
            this.bttOK = new System.Windows.Forms.Button();
            this.bttImp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bttAnnulla = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // txtbUser
            // 
            this.txtbUser.Location = new System.Drawing.Point(84, 18);
            this.txtbUser.MaxLength = 25;
            this.txtbUser.Name = "txtbUser";
            this.txtbUser.Size = new System.Drawing.Size(115, 20);
            this.txtbUser.TabIndex = 2;
            // 
            // txtbPwd
            // 
            this.txtbPwd.Location = new System.Drawing.Point(84, 44);
            this.txtbPwd.MaxLength = 25;
            this.txtbPwd.Name = "txtbPwd";
            this.txtbPwd.PasswordChar = '*';
            this.txtbPwd.Size = new System.Drawing.Size(115, 20);
            this.txtbPwd.TabIndex = 3;
            // 
            // bttOK
            // 
            this.bttOK.Location = new System.Drawing.Point(222, 28);
            this.bttOK.Name = "bttOK";
            this.bttOK.Size = new System.Drawing.Size(67, 27);
            this.bttOK.TabIndex = 6;
            this.bttOK.Text = "Login";
            this.bttOK.UseVisualStyleBackColor = true;
            this.bttOK.Click += new System.EventHandler(this.bttOK_Click);
            // 
            // bttImp
            // 
            this.bttImp.Location = new System.Drawing.Point(121, 91);
            this.bttImp.Name = "bttImp";
            this.bttImp.Size = new System.Drawing.Size(84, 27);
            this.bttImp.TabIndex = 7;
            this.bttImp.Text = "Impostazioni";
            this.bttImp.UseVisualStyleBackColor = true;
            this.bttImp.Click += new System.EventHandler(this.bttImp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bttOK);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtbUser);
            this.groupBox1.Controls.Add(this.txtbPwd);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 79);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // bttAnnulla
            // 
            this.bttAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttAnnulla.Location = new System.Drawing.Point(234, 91);
            this.bttAnnulla.Name = "bttAnnulla";
            this.bttAnnulla.Size = new System.Drawing.Size(67, 27);
            this.bttAnnulla.TabIndex = 9;
            this.bttAnnulla.Text = "Esci";
            this.bttAnnulla.UseVisualStyleBackColor = true;
            this.bttAnnulla.Click += new System.EventHandler(this.bttAnnulla_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(175, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "a Damacon Software";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(9, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 10);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.bttOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 164);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bttAnnulla);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bttImp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRUCKS - Release 1.0.4";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbUser;
        private System.Windows.Forms.TextBox txtbPwd;
        private System.Windows.Forms.Button bttOK;
        private System.Windows.Forms.Button bttImp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bttAnnulla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

