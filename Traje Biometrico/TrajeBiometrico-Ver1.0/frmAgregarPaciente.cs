using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrajeBiometrico_Ver1._0
{
    public partial class frmAgregarPaciente : Form
    {
        frmPrincipal prin;
        public frmAgregarPaciente(frmPrincipal p)
        {
            InitializeComponent();
            prin = p;
            prin.Enabled = false;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            prin.mostrarRegistrosPacientes();
            prin.Enabled = true;
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Boolean error = false;
            string name = "", gender = "";
            int edad = 0;
            double peso = 0, altura = 0;
            if (txtName.Text != "" || txtEstatura.Text != "" || txtPeso.Text != "")
            {
                name = txtName.Text;
                edad = Convert.ToInt32(nudEdad.Value);
                try
                {
                    altura = Convert.ToDouble(txtEstatura.Text);
                }
                catch
                {
                    txtEstatura.Text = "";
                    MessageBox.Show("La altura debe ser solo valores decimales y enteros. Ademas de darse en cm");
                }
                try
                {
                    peso = Convert.ToDouble(txtPeso.Text);
                }
                catch
                {
                    txtPeso.Text = "";
                    MessageBox.Show("El peso debe ser solo valores decimales y enteros. Ademas de darse en kg");
                }
                gender = cmbGenero.SelectedItem.ToString();
                prin.addPacient(name,edad,altura,peso,gender);
                if(error == false)
                {
                    txtName.Text = "";
                    txtEstatura.Text = "";
                    txtPeso.Text = "";
                    nudEdad.Value = 1;
                    cmbGenero.SelectedIndex = 1;
                }
            }
            else
                MessageBox.Show("Por favor llene todos los campos solicitados");
        }
		void FrmAgregarPacienteFormClosing(object sender, FormClosingEventArgs e)
		{
			prin.mostrarRegistrosPacientes();
            prin.Enabled = true;
            this.Dispose();
		}
		void FrmAgregarPacienteLoad(object sender, EventArgs e)
		{
			cmbGenero.SelectedIndex = 0;
		}

        private void cmbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEstatura_TextChanged(object sender, EventArgs e)
        {

        }

        private void nudEdad_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
