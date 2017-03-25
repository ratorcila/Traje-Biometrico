/*
 * Created by SharpDevelop.
 * User: edgarsaul
 * Date: 23/08/2016
 * Time: 10:52 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TrajeBiometrico_Ver1._0
{
	partial class frmRegistroPaciente
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label lbName;
		private System.Windows.Forms.Label lbEdad;
		private System.Windows.Forms.Label lbPeso;
		private System.Windows.Forms.Label lbAltura;
		private System.Windows.Forms.DataGridView dgvSesion;
		private System.Windows.Forms.Label lbID;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem chequeoFisicoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem comenzarSesionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem regresarToolStripMenuItem;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.lbName = new System.Windows.Forms.Label();
            this.lbEdad = new System.Windows.Forms.Label();
            this.lbPeso = new System.Windows.Forms.Label();
            this.lbAltura = new System.Windows.Forms.Label();
            this.dgvSesion = new System.Windows.Forms.DataGridView();
            this.lbID = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chequeoFisicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comenzarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regresarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSesion)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.Location = new System.Drawing.Point(13, 35);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(100, 23);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Nombre: ";
            // 
            // lbEdad
            // 
            this.lbEdad.Location = new System.Drawing.Point(152, 62);
            this.lbEdad.Name = "lbEdad";
            this.lbEdad.Size = new System.Drawing.Size(100, 23);
            this.lbEdad.TabIndex = 1;
            this.lbEdad.Text = "Edad:";
            // 
            // lbPeso
            // 
            this.lbPeso.Location = new System.Drawing.Point(277, 62);
            this.lbPeso.Name = "lbPeso";
            this.lbPeso.Size = new System.Drawing.Size(100, 23);
            this.lbPeso.TabIndex = 2;
            this.lbPeso.Text = "Peso:";
            // 
            // lbAltura
            // 
            this.lbAltura.Location = new System.Drawing.Point(397, 62);
            this.lbAltura.Name = "lbAltura";
            this.lbAltura.Size = new System.Drawing.Size(100, 23);
            this.lbAltura.TabIndex = 3;
            this.lbAltura.Text = "Altura:";
            // 
            // dgvSesion
            // 
            this.dgvSesion.AllowUserToAddRows = false;
            this.dgvSesion.AllowUserToDeleteRows = false;
            this.dgvSesion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSesion.Location = new System.Drawing.Point(12, 88);
            this.dgvSesion.Name = "dgvSesion";
            this.dgvSesion.ReadOnly = true;
            this.dgvSesion.Size = new System.Drawing.Size(484, 177);
            this.dgvSesion.TabIndex = 4;
            // 
            // lbID
            // 
            this.lbID.Location = new System.Drawing.Point(13, 62);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(100, 23);
            this.lbID.TabIndex = 5;
            this.lbID.Text = "ID:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chequeoFisicoToolStripMenuItem,
            this.regresarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(508, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chequeoFisicoToolStripMenuItem
            // 
            this.chequeoFisicoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comenzarSesionToolStripMenuItem});
            this.chequeoFisicoToolStripMenuItem.Name = "chequeoFisicoToolStripMenuItem";
            this.chequeoFisicoToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.chequeoFisicoToolStripMenuItem.Text = "Sesion";
            this.chequeoFisicoToolStripMenuItem.Click += new System.EventHandler(this.chequeoFisicoToolStripMenuItem_Click);
            // 
            // comenzarSesionToolStripMenuItem
            // 
            this.comenzarSesionToolStripMenuItem.Name = "comenzarSesionToolStripMenuItem";
            this.comenzarSesionToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.comenzarSesionToolStripMenuItem.Text = "Nueva";
            this.comenzarSesionToolStripMenuItem.Click += new System.EventHandler(this.comenzarSesionToolStripMenuItem_Click);
            // 
            // regresarToolStripMenuItem
            // 
            this.regresarToolStripMenuItem.Name = "regresarToolStripMenuItem";
            this.regresarToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.regresarToolStripMenuItem.Text = "Regresar";
            this.regresarToolStripMenuItem.Click += new System.EventHandler(this.RegresarToolStripMenuItemClick);
            // 
            // frmRegistroPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 278);
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.dgvSesion);
            this.Controls.Add(this.lbAltura);
            this.Controls.Add(this.lbPeso);
            this.Controls.Add(this.lbEdad);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmRegistroPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Sesiones";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBuscar_FormClosed);
            this.Load += new System.EventHandler(this.FrmBuscarLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSesion)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
