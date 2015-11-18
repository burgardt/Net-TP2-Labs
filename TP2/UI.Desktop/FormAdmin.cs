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
            FormPersonas formPersonas = new FormPersonas();
            formPersonas.ShowDialog();
        }


        private void aBMCUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuarios formUsuarios = new FormUsuarios(); 
            formUsuarios.ShowDialog();
        }


        private void aBMCEspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEspecialidades formEspecialidades = new FormEspecialidades();
            formEspecialidades.ShowDialog();
        }


        private void aBMPlanesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPlanes formPlanes = new FormPlanes();
            formPlanes.ShowDialog();
        }


        private void aBMComisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormComisiones formComisiones = new FormComisiones();
            formComisiones.ShowDialog();
        }


        private void aBMMateriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMaterias formMaterias = new FormMaterias();
            formMaterias.ShowDialog();
        }


        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
