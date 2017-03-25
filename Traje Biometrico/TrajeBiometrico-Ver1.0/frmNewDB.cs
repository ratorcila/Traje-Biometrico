using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrajeBiometrico_Ver1._0
{
    public partial class frmNewDB : Form
    {
        frmPrincipal p;
        public frmNewDB(frmPrincipal prin)
        {
            InitializeComponent();
            p = prin;
            p.Enabled = false;
        }

        private void frmNewDB_FormClosed(object sender, FormClosedEventArgs e)
        {
            p.Enabled = true;
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            p.Enabled = true;
            this.Dispose();
        }

        private Boolean DBExist(String DB) {
            if (System.IO.File.Exists("CDB.bat")){
                string[] lines = System.IO.File.ReadAllLines("CDB.bat");
                foreach (string line in lines)
                {
                    if (line.Equals(DB)) {
                        return true;
                    }
                }
            }
            return false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string txtDB = "",txtPas = "";
            txtDB = txtDataBase.Text;
            txtPas = txtPassword.Text;
            if (txtPas.Equals(txtCpasword.Text))
            {
                if (txtDB.Length > 0 && txtPas.Length > 0)
                {
                    if (!DBExist(txtDB)){
                        string aux="";
                        for (int i=0; i < txtPas.Length ;i++) {
                           aux += (Convert.ToInt32(txtPas.ElementAt(i)+20*2)+"\t");
                        }
                        p.setNewDB_V(txtDB, aux);
                        p.Enabled = true;
                        this.Dispose();
                    }
                    else {
                        MessageBox.Show("La base de datos: "+txtDB+" ya existe", "ADVERTENCIA!", MessageBoxButtons.OK);
                    }
                }
                else{
                    MessageBox.Show("Los campos deben tener contenido", "ADVERTENCIA!", MessageBoxButtons.OK);
                }
            }
            else {
                MessageBox.Show("Las contraseñas no coinciden", "ADVERTENCIA!", MessageBoxButtons.OK);
            }
        }

        private void txtDataBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
