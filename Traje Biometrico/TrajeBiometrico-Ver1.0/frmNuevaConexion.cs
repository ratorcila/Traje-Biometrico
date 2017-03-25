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
    public partial class frmNuevaConexion : Form
    {
        frmPrincipal p;
        public frmNuevaConexion(frmPrincipal prin)
        {
            InitializeComponent();
            p = prin;
            p.Enabled = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string db = "", pass = "";
            db = txtDataBase.Text;
            pass = txtPassword.Text;
            if (db.Length <= 0 || pass.Length <= 0) {
                MessageBox.Show("Los campos deben tener contenido", "ADVERTENCIA!", MessageBoxButtons.OK);
            }
            else{
                 string[] lines = System.IO.File.ReadAllLines("CDB.bat");
                Boolean ban = false;
                 for(int x = 0; x < lines.Length; x++){
                    if (lines[x].Equals(db)){
                        ban = true;
                        string aux = "";
                        for (int i = 0; i < pass.Length; i++)
                        {
                            aux += (Convert.ToInt32(pass.ElementAt(i) + 20 * 2) + "\t");
                        }
                        String[] lines1 = System.IO.File.ReadAllLines("RCDB.bat");
                        if (lines1[x].Equals(aux)){
                            p.setConectionValues(db);
                            p.Enabled = true;
                            this.Dispose();
                        }
                        else {
                            MessageBox.Show("La contraseña no es correcta", "Acceso Denegado", MessageBoxButtons.OK);
                        }
                    }
                }
                if (!ban) {
                    MessageBox.Show("La base de datos no esta registrada", "ADVERTENCIA!", MessageBoxButtons.OK);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            p.Enabled = true;
            this.Dispose();
        }

        private void frmNuevaConexion_Load(object sender, EventArgs e)
        {
            txtDataBase.Text = "";
            txtPassword.Text = "";
        }

        private void frmNuevaConexion_FormClosed(object sender, FormClosedEventArgs e)
        {
            p.Enabled = true;
            this.Dispose();
        }
    }
}
