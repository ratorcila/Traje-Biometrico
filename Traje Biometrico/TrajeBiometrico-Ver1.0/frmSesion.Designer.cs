/*
 * Created by SharpDevelop.
 * User: edgarsaul
 * Date: 25/08/2016
 * Time: 12:15 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TrajeBiometrico_Ver1._0
{
	partial class frmSesion
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ProgressBar pbHumedad;
		private System.Windows.Forms.Label lbtemp;
		private System.Windows.Forms.TextBox txtHumedad;
		private System.Windows.Forms.Label labHumedad;
		private System.Windows.Forms.TextBox txtFlex;
		private System.Windows.Forms.Label labFlixibilidad;
		private System.Windows.Forms.Button btnMov;
		private System.Windows.Forms.Label labMoviemineto;
		private System.Windows.Forms.Label lbHoraActual;
		private System.Windows.Forms.Label lbStart;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtSeg;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnNivel14;
		private System.Windows.Forms.Button btnNivel0;
		private System.Windows.Forms.Button btnNivel1;
		private System.Windows.Forms.Button btnNivel2;
		private System.Windows.Forms.Button btnNivel3;
		private System.Windows.Forms.Button btnNivel4;
		private System.Windows.Forms.Button btnNivel5;
		private System.Windows.Forms.Button btnNivel6;
		private System.Windows.Forms.Button btnNivel7;
		private System.Windows.Forms.Button btnNivel8;
		private System.Windows.Forms.Button btnNivel9;
		private System.Windows.Forms.Button btnNivel10;
		private System.Windows.Forms.Button btnNivel11;
		private System.Windows.Forms.Button btnNivel12;
		private System.Windows.Forms.Button btnNivel13;
		private System.Windows.Forms.TextBox tbTemperatura;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBPM;
		private System.Windows.Forms.Timer t1;
		private System.IO.Ports.SerialPort PuertoSerie;
		
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
            this.components = new System.ComponentModel.Container();
            this.pbHumedad = new System.Windows.Forms.ProgressBar();
            this.lbtemp = new System.Windows.Forms.Label();
            this.txtHumedad = new System.Windows.Forms.TextBox();
            this.labHumedad = new System.Windows.Forms.Label();
            this.txtFlex = new System.Windows.Forms.TextBox();
            this.labFlixibilidad = new System.Windows.Forms.Label();
            this.btnMov = new System.Windows.Forms.Button();
            this.labMoviemineto = new System.Windows.Forms.Label();
            this.lbHoraActual = new System.Windows.Forms.Label();
            this.lbStart = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSeg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNivel14 = new System.Windows.Forms.Button();
            this.btnNivel0 = new System.Windows.Forms.Button();
            this.btnNivel1 = new System.Windows.Forms.Button();
            this.btnNivel2 = new System.Windows.Forms.Button();
            this.btnNivel3 = new System.Windows.Forms.Button();
            this.btnNivel4 = new System.Windows.Forms.Button();
            this.btnNivel5 = new System.Windows.Forms.Button();
            this.btnNivel6 = new System.Windows.Forms.Button();
            this.btnNivel7 = new System.Windows.Forms.Button();
            this.btnNivel8 = new System.Windows.Forms.Button();
            this.btnNivel9 = new System.Windows.Forms.Button();
            this.btnNivel10 = new System.Windows.Forms.Button();
            this.btnNivel11 = new System.Windows.Forms.Button();
            this.btnNivel12 = new System.Windows.Forms.Button();
            this.btnNivel13 = new System.Windows.Forms.Button();
            this.tbTemperatura = new System.Windows.Forms.TextBox();
            this.pbTermometro = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBPM = new System.Windows.Forms.TextBox();
            this.pbBMP = new System.Windows.Forms.PictureBox();
            this.t1 = new System.Windows.Forms.Timer(this.components);
            this.PuertoSerie = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.finalizarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regresarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbTermometro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBMP)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbHumedad
            // 
            this.pbHumedad.Location = new System.Drawing.Point(328, 244);
            this.pbHumedad.Name = "pbHumedad";
            this.pbHumedad.Size = new System.Drawing.Size(101, 23);
            this.pbHumedad.TabIndex = 124;
            // 
            // lbtemp
            // 
            this.lbtemp.AutoSize = true;
            this.lbtemp.Location = new System.Drawing.Point(197, 355);
            this.lbtemp.Name = "lbtemp";
            this.lbtemp.Size = new System.Drawing.Size(67, 13);
            this.lbtemp.TabIndex = 123;
            this.lbtemp.Text = "Temperatura";
            // 
            // txtHumedad
            // 
            this.txtHumedad.Location = new System.Drawing.Point(380, 205);
            this.txtHumedad.Name = "txtHumedad";
            this.txtHumedad.Size = new System.Drawing.Size(49, 20);
            this.txtHumedad.TabIndex = 122;
            // 
            // labHumedad
            // 
            this.labHumedad.AutoSize = true;
            this.labHumedad.Location = new System.Drawing.Point(325, 208);
            this.labHumedad.Name = "labHumedad";
            this.labHumedad.Size = new System.Drawing.Size(53, 13);
            this.labHumedad.TabIndex = 121;
            this.labHumedad.Text = "Humedad";
            // 
            // txtFlex
            // 
            this.txtFlex.Location = new System.Drawing.Point(328, 72);
            this.txtFlex.Name = "txtFlex";
            this.txtFlex.Size = new System.Drawing.Size(101, 20);
            this.txtFlex.TabIndex = 120;
            // 
            // labFlixibilidad
            // 
            this.labFlixibilidad.AutoSize = true;
            this.labFlixibilidad.Location = new System.Drawing.Point(325, 52);
            this.labFlixibilidad.Name = "labFlixibilidad";
            this.labFlixibilidad.Size = new System.Drawing.Size(58, 13);
            this.labFlixibilidad.TabIndex = 119;
            this.labFlixibilidad.Text = "Flexibilidad";
            // 
            // btnMov
            // 
            this.btnMov.Location = new System.Drawing.Point(328, 131);
            this.btnMov.Name = "btnMov";
            this.btnMov.Size = new System.Drawing.Size(101, 25);
            this.btnMov.TabIndex = 118;
            this.btnMov.UseVisualStyleBackColor = true;
            // 
            // labMoviemineto
            // 
            this.labMoviemineto.AutoSize = true;
            this.labMoviemineto.Location = new System.Drawing.Point(325, 112);
            this.labMoviemineto.Name = "labMoviemineto";
            this.labMoviemineto.Size = new System.Drawing.Size(61, 13);
            this.labMoviemineto.TabIndex = 117;
            this.labMoviemineto.Text = "Movimiento";
            this.labMoviemineto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labMoviemineto.Click += new System.EventHandler(this.labMoviemineto_Click);
            // 
            // lbHoraActual
            // 
            this.lbHoraActual.AutoSize = true;
            this.lbHoraActual.Location = new System.Drawing.Point(12, 285);
            this.lbHoraActual.Name = "lbHoraActual";
            this.lbHoraActual.Size = new System.Drawing.Size(65, 13);
            this.lbHoraActual.TabIndex = 116;
            this.lbHoraActual.Text = "Hora actual:";
            // 
            // lbStart
            // 
            this.lbStart.AutoSize = true;
            this.lbStart.Location = new System.Drawing.Point(13, 256);
            this.lbStart.Name = "lbStart";
            this.lbStart.Size = new System.Drawing.Size(60, 13);
            this.lbStart.TabIndex = 115;
            this.lbStart.Text = "Hora inicio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 114;
            this.label3.Text = "Tiempo transcurrido";
            // 
            // txtSeg
            // 
            this.txtSeg.Enabled = false;
            this.txtSeg.Location = new System.Drawing.Point(119, 311);
            this.txtSeg.Name = "txtSeg";
            this.txtSeg.Size = new System.Drawing.Size(60, 20);
            this.txtSeg.TabIndex = 113;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(463, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 112;
            this.label2.Text = "PH";
            // 
            // btnNivel14
            // 
            this.btnNivel14.BackColor = System.Drawing.Color.DarkBlue;
            this.btnNivel14.Enabled = false;
            this.btnNivel14.Location = new System.Drawing.Point(443, 52);
            this.btnNivel14.Name = "btnNivel14";
            this.btnNivel14.Size = new System.Drawing.Size(62, 21);
            this.btnNivel14.TabIndex = 111;
            this.btnNivel14.Text = "14";
            this.btnNivel14.UseVisualStyleBackColor = false;
            // 
            // btnNivel0
            // 
            this.btnNivel0.BackColor = System.Drawing.Color.Red;
            this.btnNivel0.Enabled = false;
            this.btnNivel0.Location = new System.Drawing.Point(443, 323);
            this.btnNivel0.Name = "btnNivel0";
            this.btnNivel0.Size = new System.Drawing.Size(62, 21);
            this.btnNivel0.TabIndex = 110;
            this.btnNivel0.Text = "0";
            this.btnNivel0.UseVisualStyleBackColor = false;
            // 
            // btnNivel1
            // 
            this.btnNivel1.BackColor = System.Drawing.Color.OrangeRed;
            this.btnNivel1.Enabled = false;
            this.btnNivel1.Location = new System.Drawing.Point(443, 304);
            this.btnNivel1.Name = "btnNivel1";
            this.btnNivel1.Size = new System.Drawing.Size(62, 21);
            this.btnNivel1.TabIndex = 109;
            this.btnNivel1.Text = "1";
            this.btnNivel1.UseVisualStyleBackColor = false;
            // 
            // btnNivel2
            // 
            this.btnNivel2.BackColor = System.Drawing.Color.Orange;
            this.btnNivel2.Enabled = false;
            this.btnNivel2.Location = new System.Drawing.Point(443, 285);
            this.btnNivel2.Name = "btnNivel2";
            this.btnNivel2.Size = new System.Drawing.Size(62, 21);
            this.btnNivel2.TabIndex = 108;
            this.btnNivel2.Text = "2";
            this.btnNivel2.UseVisualStyleBackColor = false;
            // 
            // btnNivel3
            // 
            this.btnNivel3.BackColor = System.Drawing.Color.Yellow;
            this.btnNivel3.Enabled = false;
            this.btnNivel3.Location = new System.Drawing.Point(443, 265);
            this.btnNivel3.Name = "btnNivel3";
            this.btnNivel3.Size = new System.Drawing.Size(62, 21);
            this.btnNivel3.TabIndex = 107;
            this.btnNivel3.Text = "3";
            this.btnNivel3.UseVisualStyleBackColor = false;
            // 
            // btnNivel4
            // 
            this.btnNivel4.BackColor = System.Drawing.Color.GreenYellow;
            this.btnNivel4.Enabled = false;
            this.btnNivel4.Location = new System.Drawing.Point(443, 246);
            this.btnNivel4.Name = "btnNivel4";
            this.btnNivel4.Size = new System.Drawing.Size(62, 21);
            this.btnNivel4.TabIndex = 106;
            this.btnNivel4.Text = "4";
            this.btnNivel4.UseVisualStyleBackColor = false;
            // 
            // btnNivel5
            // 
            this.btnNivel5.BackColor = System.Drawing.Color.YellowGreen;
            this.btnNivel5.Enabled = false;
            this.btnNivel5.Location = new System.Drawing.Point(443, 227);
            this.btnNivel5.Name = "btnNivel5";
            this.btnNivel5.Size = new System.Drawing.Size(62, 21);
            this.btnNivel5.TabIndex = 105;
            this.btnNivel5.Text = "5";
            this.btnNivel5.UseVisualStyleBackColor = false;
            // 
            // btnNivel6
            // 
            this.btnNivel6.BackColor = System.Drawing.Color.LimeGreen;
            this.btnNivel6.Enabled = false;
            this.btnNivel6.Location = new System.Drawing.Point(443, 208);
            this.btnNivel6.Name = "btnNivel6";
            this.btnNivel6.Size = new System.Drawing.Size(62, 21);
            this.btnNivel6.TabIndex = 104;
            this.btnNivel6.Text = "6";
            this.btnNivel6.UseVisualStyleBackColor = false;
            // 
            // btnNivel7
            // 
            this.btnNivel7.BackColor = System.Drawing.Color.Green;
            this.btnNivel7.Enabled = false;
            this.btnNivel7.Location = new System.Drawing.Point(443, 188);
            this.btnNivel7.Name = "btnNivel7";
            this.btnNivel7.Size = new System.Drawing.Size(62, 21);
            this.btnNivel7.TabIndex = 103;
            this.btnNivel7.Text = "7";
            this.btnNivel7.UseVisualStyleBackColor = false;
            // 
            // btnNivel8
            // 
            this.btnNivel8.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnNivel8.Enabled = false;
            this.btnNivel8.Location = new System.Drawing.Point(443, 170);
            this.btnNivel8.Name = "btnNivel8";
            this.btnNivel8.Size = new System.Drawing.Size(62, 21);
            this.btnNivel8.TabIndex = 102;
            this.btnNivel8.Text = "8";
            this.btnNivel8.UseVisualStyleBackColor = false;
            // 
            // btnNivel9
            // 
            this.btnNivel9.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnNivel9.Enabled = false;
            this.btnNivel9.Location = new System.Drawing.Point(443, 150);
            this.btnNivel9.Name = "btnNivel9";
            this.btnNivel9.Size = new System.Drawing.Size(62, 21);
            this.btnNivel9.TabIndex = 101;
            this.btnNivel9.Text = "9";
            this.btnNivel9.UseVisualStyleBackColor = false;
            // 
            // btnNivel10
            // 
            this.btnNivel10.BackColor = System.Drawing.Color.SkyBlue;
            this.btnNivel10.Enabled = false;
            this.btnNivel10.Location = new System.Drawing.Point(443, 131);
            this.btnNivel10.Name = "btnNivel10";
            this.btnNivel10.Size = new System.Drawing.Size(62, 21);
            this.btnNivel10.TabIndex = 100;
            this.btnNivel10.Text = "10";
            this.btnNivel10.UseVisualStyleBackColor = false;
            // 
            // btnNivel11
            // 
            this.btnNivel11.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNivel11.Enabled = false;
            this.btnNivel11.Location = new System.Drawing.Point(443, 112);
            this.btnNivel11.Name = "btnNivel11";
            this.btnNivel11.Size = new System.Drawing.Size(62, 21);
            this.btnNivel11.TabIndex = 99;
            this.btnNivel11.Text = "11";
            this.btnNivel11.UseVisualStyleBackColor = false;
            // 
            // btnNivel12
            // 
            this.btnNivel12.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnNivel12.Enabled = false;
            this.btnNivel12.Location = new System.Drawing.Point(443, 92);
            this.btnNivel12.Name = "btnNivel12";
            this.btnNivel12.Size = new System.Drawing.Size(62, 21);
            this.btnNivel12.TabIndex = 98;
            this.btnNivel12.Text = "12";
            this.btnNivel12.UseVisualStyleBackColor = false;
            // 
            // btnNivel13
            // 
            this.btnNivel13.BackColor = System.Drawing.Color.SlateBlue;
            this.btnNivel13.Enabled = false;
            this.btnNivel13.Location = new System.Drawing.Point(443, 72);
            this.btnNivel13.Name = "btnNivel13";
            this.btnNivel13.Size = new System.Drawing.Size(62, 21);
            this.btnNivel13.TabIndex = 97;
            this.btnNivel13.Text = "13";
            this.btnNivel13.UseVisualStyleBackColor = false;
            // 
            // tbTemperatura
            // 
            this.tbTemperatura.Location = new System.Drawing.Point(270, 352);
            this.tbTemperatura.Name = "tbTemperatura";
            this.tbTemperatura.Size = new System.Drawing.Size(42, 20);
            this.tbTemperatura.TabIndex = 96;
            // 
            // pbTermometro
            // 
            this.pbTermometro.Location = new System.Drawing.Point(233, 42);
            this.pbTermometro.Name = "pbTermometro";
            this.pbTermometro.Size = new System.Drawing.Size(79, 304);
            this.pbTermometro.TabIndex = 95;
            this.pbTermometro.TabStop = false;
            this.pbTermometro.Paint += new System.Windows.Forms.PaintEventHandler(this.pbTermometro_Paint_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 94;
            this.label1.Text = "BPM";
            // 
            // txtBPM
            // 
            this.txtBPM.Enabled = false;
            this.txtBPM.Location = new System.Drawing.Point(53, 211);
            this.txtBPM.Name = "txtBPM";
            this.txtBPM.Size = new System.Drawing.Size(60, 20);
            this.txtBPM.TabIndex = 93;
            // 
            // pbBMP
            // 
            this.pbBMP.Location = new System.Drawing.Point(12, 42);
            this.pbBMP.Name = "pbBMP";
            this.pbBMP.Size = new System.Drawing.Size(200, 154);
            this.pbBMP.TabIndex = 92;
            this.pbBMP.TabStop = false;
            this.pbBMP.Paint += new System.Windows.Forms.PaintEventHandler(this.pbBMP_Paint_1);
            // 
            // t1
            // 
            this.t1.Enabled = true;
            this.t1.Interval = 1000;
            this.t1.Tick += new System.EventHandler(this.t1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.finalizarSesionToolStripMenuItem,
            this.regresarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(532, 24);
            this.menuStrip1.TabIndex = 125;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // finalizarSesionToolStripMenuItem
            // 
            this.finalizarSesionToolStripMenuItem.Name = "finalizarSesionToolStripMenuItem";
            this.finalizarSesionToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.finalizarSesionToolStripMenuItem.Text = "Finalizar Sesion";
            this.finalizarSesionToolStripMenuItem.Click += new System.EventHandler(this.finalizarSesionToolStripMenuItem_Click);
            // 
            // regresarToolStripMenuItem
            // 
            this.regresarToolStripMenuItem.Name = "regresarToolStripMenuItem";
            this.regresarToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.regresarToolStripMenuItem.Text = "Regresar";
            this.regresarToolStripMenuItem.Click += new System.EventHandler(this.regresarToolStripMenuItem_Click);
            // 
            // frmSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 385);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtSeg);
            this.Controls.Add(this.pbHumedad);
            this.Controls.Add(this.lbtemp);
            this.Controls.Add(this.txtHumedad);
            this.Controls.Add(this.labHumedad);
            this.Controls.Add(this.txtFlex);
            this.Controls.Add(this.labFlixibilidad);
            this.Controls.Add(this.btnMov);
            this.Controls.Add(this.labMoviemineto);
            this.Controls.Add(this.lbHoraActual);
            this.Controls.Add(this.lbStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNivel14);
            this.Controls.Add(this.btnNivel0);
            this.Controls.Add(this.btnNivel1);
            this.Controls.Add(this.btnNivel2);
            this.Controls.Add(this.btnNivel3);
            this.Controls.Add(this.btnNivel4);
            this.Controls.Add(this.btnNivel5);
            this.Controls.Add(this.btnNivel6);
            this.Controls.Add(this.btnNivel7);
            this.Controls.Add(this.btnNivel8);
            this.Controls.Add(this.btnNivel9);
            this.Controls.Add(this.btnNivel10);
            this.Controls.Add(this.btnNivel11);
            this.Controls.Add(this.btnNivel12);
            this.Controls.Add(this.btnNivel13);
            this.Controls.Add(this.tbTemperatura);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBPM);
            this.Controls.Add(this.pbBMP);
            this.Controls.Add(this.pbTermometro);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sesion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSesion_FormClosed);
            this.Load += new System.EventHandler(this.FrmSesionLoad);
            ((System.ComponentModel.ISupportInitialize)(this.pbTermometro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBMP)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem finalizarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regresarToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbTermometro;
        private System.Windows.Forms.PictureBox pbBMP;
    }
}
