using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void aBMCPersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPersonas fp = new FormPersonas();
            fp.ShowDialog();
        }

        private void aBMCUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuarios fu = new FormUsuarios(); 
            fu.ShowDialog();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aBMCEspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEspecialidades fe = new FormEspecialidades();
            fe.ShowDialog();
        }

        private void aBMPlanesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPlanes fp = new FormPlanes();
            fp.ShowDialog();
        }

    }
}
