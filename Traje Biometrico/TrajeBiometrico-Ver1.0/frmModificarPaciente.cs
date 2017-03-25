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
    public partial class frmModificarPaciente : Form
    {
        frmPrincipal prin;
        int id_paciente;
        DataTable paciente;
        DataRow row;

        public frmModificarPaciente(frmPrincipal p, string id)
        {
            InitializeComponent();
            prin = p;
            prin.Enabled = false;
            id_paciente = Convert.ToInt32(id);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
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
                prin.updatePacient(id_paciente,name, edad, altura, peso, gender);
                prin.mostrarRegistrosPacientes();
                prin.Enabled = true;
                this.Dispose();
            }
            else
                MessageBox.Show("Por favor llene todos los campos solicitados");
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            prin.mostrarRegistrosPacientes();
            prin.Enabled = true;
            this.Dispose();
        }

        private void frmModificarPaciente_Load(object sender, EventArgs e)
        {
            paciente = prin.buscarPaciente(id_paciente);
            row = paciente.Rows[0];
            txtName.Text = row["Nombre"].ToString();
            txtEstatura.Text = row["Altura"].ToString();
            nudEdad.Text = row["Edad"].ToString();
            txtPeso.Text = row["Peso"].ToString();
            if (row["genero"].ToString().Equals("H"))
            {
                cmbGenero.SelectedIndex = 0;
            }
            else
            {
                cmbGenero.SelectedIndex = 1;
            }
        }

        private void frmModificarPaciente_FormClosing(object sender, FormClosingEventArgs e)
        {
            prin.mostrarRegistrosPacientes();
            prin.Enabled = true;
            this.Dispose();
        }
    }
}
