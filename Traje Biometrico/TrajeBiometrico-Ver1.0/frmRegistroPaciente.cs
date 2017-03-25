/*
 * Created by SharpDevelop.
 * User: edgarsaul
 * Date: 23/08/2016
 * Time: 10:52 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace TrajeBiometrico_Ver1._0
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class frmRegistroPaciente : Form
	{
		frmPrincipal prin;
		string id;
		DataTable paciente,sesion;
		DataRow row;
        frmSelectPort sp;
		public frmRegistroPaciente(frmPrincipal p, string ID)
		{
			InitializeComponent();
			this.prin=p;
			this.id=ID;
            sp = new frmSelectPort(this);
        }

        public frmPrincipal getPrincipal()
        {
            return prin;
        }
		
        public int getID()
        {
            return Convert.ToInt32(this.id);
        }

		void FrmBuscarLoad(object sender, EventArgs e){
			int id_paciente = Convert.ToInt32(this.id);
			paciente = prin.buscarPaciente(id_paciente);
			row = paciente.Rows[0];
			lbName.Text = "Nombre: " + row["Nombre"].ToString();
			lbID.Text = "ID: " + id;
			lbAltura.Text = "Altura: " + row["Altura"].ToString();
			lbEdad.Text = "Edad: " + row["Edad"].ToString();
			lbPeso.Text = "Peso: " + row["Peso"].ToString();
			sesion = prin.getSesion(id_paciente);
            int x = prin.buscarS(Convert.ToInt32(id_paciente));
            if (x <= 0)
            {
                dgvSesion.DataSource = sesion.DefaultView;
                MessageBox.Show("No hay ninguna sesion de esta persona");
            }
            else
                dgvSesion.DataSource = sesion.DefaultView;
		}

        private void comenzarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sp.Show();
            this.Hide();
        }

        private void chequeoFisicoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmBuscar_FormClosed(object sender, FormClosedEventArgs e)
        {
            prin.Enabled = true;
            this.Dispose();
        }

        void RegresarToolStripMenuItemClick(object sender, EventArgs e)
		{
			prin.Enabled = true;
			this.Dispose();
		}
	}
}