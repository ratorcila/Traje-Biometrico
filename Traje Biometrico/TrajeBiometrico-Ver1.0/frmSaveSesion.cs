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
    public partial class CerrarSesion : Form
    {
        frmPrincipal frms;
        public CerrarSesion(frmPrincipal fs)
        {
            InitializeComponent();
            frms = fs;
        }

        private void AceptarBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
