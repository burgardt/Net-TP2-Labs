using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class FormUsuarios : ApplicationForm
    {
        //CONSTRUCTORES-------------------------------------------------------------------------------------------------

        public FormUsuarios()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        //METODOS------------------------------------------------------------------------------------------------------
        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetAll();
        }

        //EVENTOS--------------------------------------------------------------------------------------------------------

        private void tscUsuarios_cpUsuarios_Load(object sender, EventArgs e)
        {
        }

        private void tscUsuarios_tspUsuarios_Click(object sender, EventArgs e)
        {
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void formUsuarios_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tscUsuarios_TopToolStripPanel_Click(object sender, EventArgs e)
        {
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop ud = new UsuarioDesktop(ModoForm.Alta);
            ud.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop ud = new UsuarioDesktop(id, ModoForm.Modificacion);
                ud.ShowDialog();
                this.Listar();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Debe seleccionar una fila a modificar");
            }     
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop ud = new UsuarioDesktop(id, ModoForm.Baja);
                ud.ShowDialog();
                this.Listar();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Debe seleccionar una fila a eliminar");
            }
        }
    }
}
