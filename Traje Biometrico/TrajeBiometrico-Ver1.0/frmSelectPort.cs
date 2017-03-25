using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace TrajeBiometrico_Ver1._0
{
    public partial class frmSelectPort : Form
    {
        frmRegistroPaciente searched;
        frmSesion s;
        public frmSelectPort(frmRegistroPaciente b)
        {
            InitializeComponent();
            this.searched = b;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            searched.Show();
            this.Hide();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(!cmbPorts.SelectedItem.ToString().Equals(""))
            {
                s = new frmSesion(searched.getPrincipal(), searched.getID(), cmbTipoEntre.SelectedItem.ToString(), cmbTipoEntre.SelectedIndex);
                s.setPort(cmbPorts.SelectedItem.ToString());
                s.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Por favor LLene todos los campos solicitados.", "ADVERTENCIA!!!", MessageBoxButtons.OK);
            }
        }

        private void frmSelectPort_Load(object sender, EventArgs e)
        {
            List<string> aux = new List<string>();
            foreach(string port in SerialPort.GetPortNames())
            {
                aux.Add(port);
                cmbTipoEntre.SelectedIndex = 0;
            }
            cmbPorts.DataSource = aux;
        }
    }
}
