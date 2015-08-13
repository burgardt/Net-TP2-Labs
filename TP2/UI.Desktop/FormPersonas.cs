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
    public partial class FormPersonas : ApplicationForm
    {
        public FormPersonas()
        {
            InitializeComponent();
            this.dgvPersonas.AutoGenerateColumns = false;
        }

        //METODOS------------------------------------------------------------------------------------------------------
        public void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            this.dgvPersonas.DataSource= pl.GetAll();
        }

        //EVENTOS--------------------------------------------------------------------------------------------------------

        private void formPersonas_Load(object sender, EventArgs e)
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
           PersonaDesktop ud = new PersonaDesktop(ModoForm.Alta);
            ud.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonaDesktop ud = new PersonaDesktop(id, ModoForm.Modificacion);
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
                int id = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonaDesktop ud = new PersonaDesktop(id, ModoForm.Baja);
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
