/*
 * Created by SharpDevelop.
 * User: edgarsaul
 * Date: 25/08/2016
 * Time: 12:15 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;

namespace TrajeBiometrico_Ver1._0
{
	public partial class frmSesion : Form
	{
        //atributos clase
        frmPrincipal principal;
        private string puerto;

        //Atributos para graficar el pulso
        Bitmap b;
        Graphics g;
        private int signal, xPulso = 0;
        private Pen red = new Pen(Color.LightBlue, 2.0f);

        //* Atributos para el termometro
        Pen pBlack = new Pen(Color.Black);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        Font font = new Font("Arial", 8);
        Point[] points = { new Point(35, 20), new Point(60, 20) };
        Point[] points1 = { new Point(35, 234), new Point(45, 230), new Point(59, 235) };
        Rectangle rectangle1 = new Rectangle(17, 230, 60, 60);
        Bitmap b1;
        Boolean nt = false;
        Graphics gTerm;
        int tempC = 1, x = 105;
        Color col;


        int MOV = 0;
        // <Atributos para el PH>
        int actualLevel = 0;
        Image i = Image.FromFile(@"flecha.png");

        public frmSesion(frmPrincipal f,int id_paciente,string tipoE, int typeE)
		{
			InitializeComponent();
            
            //Arreglos de datos
			t1.Start();
            pbHumedad.Maximum = 100;

            // Elementos para el termometro
            b1 = new Bitmap(pbTermometro.Width, pbTermometro.Height);
            pbTermometro.DrawToBitmap(b1, pbTermometro.Bounds);
            gTerm = Graphics.FromImage(b1);
            gTerm.Clear(Color.FromKnownColor(KnownColor.Control));
            //fin elementos para el termometro

            //Elementos para el Pulso cardiaco
            b = new Bitmap(pbBMP.Width, pbBMP.Height);
            pbBMP.DrawToBitmap(b, pbBMP.Bounds);
            g = Graphics.FromImage(b);
            g.Clear(Color.White);
            signal = pbBMP.Height / 2;
            //Fin elementos para el pulso cardiaco

            principal = f;
            principal.id = id_paciente;
            principal.tipoEntrenamiento = tipoE;
            principal.typeEnt = typeE;
		}

        public void setPort(string port)
        {
            this.puerto = port;
            try
            {
                PuertoSerie = new SerialPort(puerto, 9600);
                PuertoSerie.DataReceived += PuertoSerie_DataReceived;
                PuertoSerie.Open();
                //graficarTermometro();
                //graficarPulso();
            }
            catch
            {
                MessageBox.Show("No esta conectado al puerto actual.");
            }
            lbStart.Text = "Empezo a las: " + DateTime.Now.ToString("hh:mm:ss");
            CheckForIllegalCrossThreadCalls = false;
        }

		private void PuertoSerie_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string Linea = "", sublinea = "";
            Linea = PuertoSerie.ReadLine();
            Boolean ban = true;

            if (!Linea.Equals("") && Linea.Length > 1)
            {
                for (int i = 1; i < Linea.Length - 1; i++)
                {
                    if (!char.IsDigit(Linea.ElementAt(i)))
                    {
                        ban = false;
                    }
                }
            }
            else {
                ban = false;
            }
            if (!ban){
                ban = true;
            }
            //Corazon
            else if (Linea.StartsWith("A"))
            {
                for (int i = 1; i < Linea.Length; i++)
                {
                    if (Char.IsDigit(Linea.ElementAt(i)))
                    {
                        sublinea += Linea.ElementAt(i);
                    }
                    else
                    {
                        break;
                    }
                }
                signal = Convert.ToInt32(sublinea);
                graficarPulso();
            }
            //temperatura
            else if (Linea.StartsWith("B"))
            {
                for (int i = 1; i < Linea.Length; i++)
                {
                    if (Char.IsDigit(Linea.ElementAt(i)))
                    {
                        sublinea += Linea.ElementAt(i);
                    }
                    else
                    {
                        break;
                    }
                }
                tbTemperatura.Clear();
                tbTemperatura.AppendText(sublinea + " C");
                tempC = Convert.ToInt32(sublinea);
                if (tempC > 40)
                {
                    col = Color.Red;
                }
                else if (tempC < 28)
                {
                    col = Color.DarkBlue;
                }
                else {
                    col = Color.DarkGreen;
                }
                nt = true;
                graficarTermometro();
                timerOpcional();
                principal.temp.Add(tempC);
            }
            //PH
            else if (Linea.StartsWith("C"))
            {
                for (int i = 1; i < Linea.Length; i++)
                {
                    if (Char.IsDigit(Linea.ElementAt(i)))
                    {
                        sublinea += Linea.ElementAt(i);
                    }
                    else
                    {
                        break;
                    }
                }
                setLevel(Convert.ToInt32(sublinea));
                principal.ph.Add(Convert.ToInt32(sublinea));
            }
            //Movimiento
            else if (Linea.StartsWith("D"))
            {
                for (int i = 1; i < Linea.Length; i++)
                {
                    if (Char.IsDigit(Linea.ElementAt(i)))
                    {
                        sublinea += Linea.ElementAt(i);
                    }
                    else
                    {
                        break;
                    }
                }
                MOV = Convert.ToInt32(sublinea);
                principal.mov.Add(Convert.ToInt32(sublinea));
                if (MOV < 100)
                {
                    btnMov.BackColor = Color.Red;
                }
                else
                {
                    btnMov.BackColor = Color.Green;
                }
            }
            //Flexibilidad
            else if (Linea.StartsWith("E"))
            {
                for (int i = 1; i < Linea.Length; i++)
                {
                    if (Char.IsDigit(Linea.ElementAt(i)))
                    {
                        sublinea += Linea.ElementAt(i);
                    }
                    else
                    {
                        break;
                    }
                }
                txtFlex.Clear();
                txtFlex.AppendText(sublinea);
                principal.flexibilidad.Add(Convert.ToInt32(sublinea));
            }
            //Humedad
            else if (Linea.StartsWith("F"))
            {
                for (int i = 1; i < Linea.Length; i++)
                {
                    if (Char.IsDigit(Linea.ElementAt(i)))
                    {
                        sublinea += Linea.ElementAt(i);
                    }
                    else
                    {
                        break;
                    }
                }
                txtHumedad.Clear();
                txtHumedad.AppendText(sublinea);
                setProgressBarLEvel(Convert.ToInt32(sublinea));
                principal.humedad.Add(Convert.ToInt32(sublinea));
            }
            sublinea = "";
        }

		private void setProgressBarLEvel(int hum)
        {
            pbHumedad.Value = hum;
            pbHumedad.Update();
        }

        private float getSignal()
        {
            return signal;
        }

        private void graficarPulso()
        {
            float local = 0;
            local = getSignal();
            txtBPM.Text = Convert.ToString(local);
            txtBPM.Update();
            label1.Update();
            principal.fc.Add(local);
            g.DrawLine(red, xPulso, pbBMP.Height, xPulso, (local));
            xPulso += 3;
            if (xPulso >= pbBMP.Width)
            {
                xPulso = 0;
                pbBMP.Update();
                g.Clear(Color.White);
            }
            pbBMP.Refresh();
        }

        private void nullImage()
        {
            switch (actualLevel)
            {
                case 0:
                    btnNivel0.BackgroundImage = null;
                    break;
                case 1:
                    btnNivel1.BackgroundImage = null;
                    break;
                case 2:
                    btnNivel2.BackgroundImage = null;
                    break;
                case 3:
                    btnNivel3.BackgroundImage = null;
                    break;
                case 4:
                    btnNivel4.BackgroundImage = null;
                    break;
                case 5:
                    btnNivel5.BackgroundImage = null;
                    break;
                case 6:
                    btnNivel6.BackgroundImage = null;
                    break;
                case 7:
                    btnNivel7.BackgroundImage = null;
                    break;
                case 8:
                    btnNivel8.BackgroundImage = null;
                    break;
                case 9:
                    btnNivel9.BackgroundImage = null;
                    break;
                case 10:
                    btnNivel10.BackgroundImage = null;
                    break;
                case 11:
                    btnNivel11.BackgroundImage = null;
                    break;
                case 12:
                    btnNivel12.BackgroundImage = null;
                    break;
                case 13:
                    btnNivel13.BackgroundImage = null;
                    break;
            }
        }

        private void pbBMP_Paint_1(object sender, PaintEventArgs e)
        {
            if (b != null)
                pbBMP.Image = (Image)b.Clone();
        }

        private void pbTermometro_Paint_1(object sender, PaintEventArgs e)
        {
            if (b1 != null)
                pbTermometro.Image = (Image)b1.Clone();
        }


        public void timerOpcional()
        {
            principal.tiempo++;
            lbHoraActual.Text = "Hora actual: " + DateTime.Now.ToString("hh:mm:ss");
            txtSeg.Text = "Tiempo: " + Convert.ToString(principal.tiempo) + " s.";
            txtSeg.Update();
        }

        private void setLevel(int nivel)
        {
            nullImage();
            switch (nivel)
            {
                case 0:
                    actualLevel = 0;
                    btnNivel0.BackgroundImage = i;
                    break;
                case 1:
                    actualLevel = 1;
                    btnNivel1.BackgroundImage = i;
                    break;
                case 2:
                    actualLevel = 2;
                    btnNivel2.BackgroundImage = i;
                    break;
                case 3:
                    actualLevel = 3;
                    btnNivel3.BackgroundImage = i;
                    break;
                case 4:
                    actualLevel = 4;
                    btnNivel4.BackgroundImage = i;
                    break;
                case 5:
                    actualLevel = 5;
                    btnNivel5.BackgroundImage = i;
                    break;
                case 6:
                    actualLevel = 6;
                    btnNivel6.BackgroundImage = i;
                    break;
                case 7:
                    actualLevel = 7;
                    btnNivel7.BackgroundImage = i;
                    break;
                case 8:
                    actualLevel = 8;
                    btnNivel8.BackgroundImage = i;
                    break;
                case 9:
                    actualLevel = 9;
                    btnNivel9.BackgroundImage = i;
                    break;
                case 10:
                    actualLevel = 10;
                    btnNivel10.BackgroundImage = i;
                    break;
                case 11:
                    actualLevel = 11;
                    btnNivel11.BackgroundImage = i;
                    break;
                case 12:
                    actualLevel = 12;
                    btnNivel12.BackgroundImage = i;
                    break;
                case 13:
                    actualLevel = 13;
                    btnNivel13.BackgroundImage = i;
                    break;
            }
        }

        private void t1_Tick(object sender, EventArgs e)
        {
            /*tiempo++;
            lbHoraActual.Text = "Tiempo: " + Convert.ToString(tiempo) + " s.";
            txtSeg.Text = Convert.ToString(tiempo) + " s.";
            txtSeg.Update();
            */
        }

        private void finalizarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PuertoSerie.Close();
            CerrarSesion cs = new CerrarSesion(principal);
            principal.finSesion();
            this.Dispose();
            cs.Show();
        }

        private void labMoviemineto_Click(object sender, EventArgs e){

        }

        private void regresarToolStripMenuItem_Click(object sender, EventArgs e){
            PuertoSerie.Close();
            CerrarSesion cs = new CerrarSesion(principal);
            principal.finSesion();
            this.Dispose();
            cs.Show();
        }

        private void frmSesion_FormClosed(object sender, FormClosedEventArgs e)
        {
            PuertoSerie.Close();
            CerrarSesion cs = new CerrarSesion(principal);
            principal.finSesion();
            this.Dispose();
            cs.Show();
        }

        private void graficarTermometro()
        {
            SolidBrush brushCol = new SolidBrush(col);
            Pen pCol = new Pen(col, 7);
            gTerm.Clear(Color.FromKnownColor(KnownColor.Control));
            x = 105;
            if (nt == true)
            {
                tempC = tempC * 2;
                gTerm.FillRectangle(brushCol, 35, 230 - tempC, 25, tempC);
                gTerm.FillEllipse(brushCol, rectangle1);
                gTerm.DrawEllipse(pBlack, rectangle1);
                gTerm.DrawLine(pCol, 35, 233, 60, 233);
                gTerm.DrawLines(pBlack, points);
                gTerm.DrawLine(pBlack, 35, 20, 35, 235);
                gTerm.DrawLine(pBlack, 60, 20, 60, 235);
                for (int i = 30; i < 240; i = i + 10)
                {
                    gTerm.DrawLine(pBlack, 55, i, 65, i);
                    gTerm.DrawString(Convert.ToString(x = x - 5), font, blackBrush, 65, i - 6);//cadena,eje x, eje Y
                }
            }
            else {
                gTerm.DrawEllipse(pBlack, rectangle1);
                gTerm.DrawCurve(new Pen(Color.FromKnownColor(KnownColor.Control), 3), points1);
                gTerm.DrawLines(pBlack, points);
                gTerm.DrawLine(pBlack, 35, 20, 35, 235);
                gTerm.DrawLine(pBlack, 60, 20, 60, 235);
                for (int i = 30; i < 240; i = i + 10)
                {
                    gTerm.DrawLine(pBlack, 55, i, 65, i);
                    gTerm.DrawString(Convert.ToString(x = x - 5), font, blackBrush, 65, i - 6);//cadena,eje x, eje Y
                }
            }
            pbTermometro.Refresh();
        }

        void FrmSesionLoad(object sender, EventArgs e)
		{
			
		}
	}
}
