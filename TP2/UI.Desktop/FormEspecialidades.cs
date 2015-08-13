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
    public partial class FormEspecialidades : ApplicationForm
    {
        public FormEspecialidades()
        {
            InitializeComponent();
            this.dgvEspecialidades.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop ed = new EspecialidadDesktop(ModoForm.Alta);
            ed.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop ed = new EspecialidadDesktop(id, ModoForm.Modificacion);
                ed.ShowDialog();
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
                int id = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop ed = new EspecialidadDesktop(id, ModoForm.Baja);
                ed.ShowDialog();
                this.Listar();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Debe seleccionar una fila a eliminar");
            }
        }

        private void FormEspecialidad_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
