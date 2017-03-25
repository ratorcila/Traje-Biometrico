namespace TrajeBiometrico_Ver1._0
{
    partial class frmNewDB
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.lbPas = new System.Windows.Forms.Label();
            this.lbNDB = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lbConfirmarPassword = new System.Windows.Forms.Label();
            this.txtCpasword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(199, 151);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(135, 35);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(33, 151);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(135, 35);
            this.btnAceptar.TabIndex = 23;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(153, 67);
            this.txtPassword.MaxLength = 14;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(181, 20);
            this.txtPassword.TabIndex = 20;
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(153, 27);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(181, 20);
            this.txtDataBase.TabIndex = 18;
            this.txtDataBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDataBase_KeyPress);
            // 
            // lbPas
            // 
            this.lbPas.AutoSize = true;
            this.lbPas.Location = new System.Drawing.Point(83, 70);
            this.lbPas.Name = "lbPas";
            this.lbPas.Size = new System.Drawing.Size(64, 13);
            this.lbPas.TabIndex = 16;
            this.lbPas.Text = "Contraseña:";
            // 
            // lbNDB
            // 
            this.lbNDB.AutoSize = true;
            this.lbNDB.Location = new System.Drawing.Point(30, 30);
            this.lbNDB.Name = "lbNDB";
            this.lbNDB.Size = new System.Drawing.Size(117, 13);
            this.lbNDB.TabIndex = 14;
            this.lbNDB.Text = "Nombre base de datos:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lbConfirmarPassword
            // 
            this.lbConfirmarPassword.AutoSize = true;
            this.lbConfirmarPassword.Location = new System.Drawing.Point(37, 109);
            this.lbConfirmarPassword.Name = "lbConfirmarPassword";
            this.lbConfirmarPassword.Size = new System.Drawing.Size(110, 13);
            this.lbConfirmarPassword.TabIndex = 25;
            this.lbConfirmarPassword.Text = "Confirmar contraseña:";
            // 
            // txtCpasword
            // 
            this.txtCpasword.Location = new System.Drawing.Point(153, 106);
            this.txtCpasword.MaxLength = 14;
            this.txtCpasword.Name = "txtCpasword";
            this.txtCpasword.PasswordChar = '*';
            this.txtCpasword.Size = new System.Drawing.Size(181, 20);
            this.txtCpasword.TabIndex = 22;
            // 
            // frmNewDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 214);
            this.Controls.Add(this.txtCpasword);
            this.Controls.Add(this.lbConfirmarPassword);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtDataBase);
            this.Controls.Add(this.lbPas);
            this.Controls.Add(this.lbNDB);
            this.MaximizeBox = false;
            this.Name = "frmNewDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Base de datos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmNewDB_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtDataBase;
        private System.Windows.Forms.Label lbPas;
        private System.Windows.Forms.Label lbNDB;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lbConfirmarPassword;
        private System.Windows.Forms.TextBox txtCpasword;
    }
}