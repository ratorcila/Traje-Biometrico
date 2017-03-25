/*
 * Created by SharpDevelop.
 * User: edgarsaul
 * Date: 23/08/2016
 * Time: 11:04 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrajeBiometrico_Ver1._0
{
	/// <summary>
	/// Description of frmObtenerID.
	/// </summary>
	public partial class frmObtenerID : Form
	{
		frmPrincipal p;
        private int type;
		public frmObtenerID(frmPrincipal prin,int tipo)
		{
			InitializeComponent();
			p = prin;
            type = tipo;
		}

        void BtnAceptarClick(object sender, EventArgs e)
        {
            string id = "", result = "";
            id = txtID.Text;
            int x = p.buscar(Convert.ToInt32(id));
            if (x > 0)
            {
                if (type == 1)
                {
                    frmRegistroPaciente b = new frmRegistroPaciente(p, id);
                    b.Show();
                }
                else if (type == 2)
                {
                    result = p.eliminarPaciente(Convert.ToInt32(id));
                    if (result.CompareTo("No selected") == 0)
                    {
                        txtID.Text = "";
                        p.Enabled = true;
                        p.mostrarRegistrosPacientes();
                        this.Dispose();
                    }
                    else if (result.CompareTo("¡¡Exito al eliminar!!") == 0)
                    {
                        MessageBox.Show(result);
                        p.Enabled = true;
                        p.mostrarRegistrosPacientes();
                        this.Dispose();
                    }
                    else
                        MessageBox.Show("Hubo un error al intentar eliminar, contacte con el administrador.\n" + result);
                }
                else if (type == 3)
                {
                    frmModificarPaciente b = new frmModificarPaciente(p, id);
                    b.Show();
                }
                this.Dispose();
            }
            else {
                MessageBox.Show("No se encontro el pacinete." ,"Paciente no registrado");
            }
        }
		void BtnCancelarClick(object sender, EventArgs e)
		{
			p.Enabled = true;
			p.mostrarRegistrosPacientes();
			this.Dispose();
		}

        private void frmObtenerID_FormClosed(object sender, FormClosedEventArgs e)
        {
            p.Enabled = true;
            p.mostrarRegistrosPacientes();
            this.Dispose();
        }
    }
}
