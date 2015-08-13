using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class FormPlanes : ApplicationForm
    {
        public FormPlanes()
        {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
        }

        //METODOS------------------------------------------------------------------------------------------------------
        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            this.dgvPlanes.DataSource = pl.GetAll();
        }
        //EVENTOS-----------------------------------------------------------------------------------------------------

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop pd = new PlanDesktop(ModoForm.Alta);
            pd.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanDesktop pd= new PlanDesktop(id, ModoForm.Modificacion);
                pd.ShowDialog();
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
                int id = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanDesktop pd= new PlanDesktop(id, ModoForm.Baja);
                pd.ShowDialog();
                this.Listar();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Debe seleccionar una fila a eliminar");
            }
        }

        private void FormPlanes_Load(object sender, EventArgs e)
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


    }
}
