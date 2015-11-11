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

        public struct Fila
        {
            private int _id;
            private string _descripcion;
            private string _especialidad;

            public int ID
            {
                get { return _id; }
                set { _id = value; }
            }            
            public string Descripcion
            {
                get { return _descripcion; }
                set { _descripcion = value; }
            }
            public string Especialidad
            {
                get { return _especialidad; }
                set { _especialidad = value; }
            }
        }

        //METODOS------------------------------------------------------------------------------------------------------
        public void Listar()
        {
          
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = new List<Plan>();
            planes = pl.GetAll();

            EspecialidadLogic el = new EspecialidadLogic();
            List<Especialidad> especialidades = new List<Especialidad>();
            especialidades = el.GetAll();

            List<Fila> filas = new List<Fila>();
            foreach (Plan plan in planes)
            {
                Fila fila = new Fila();
                fila.ID = plan.ID;
                fila.Descripcion = plan.Descripcion;
                foreach (Especialidad especialidad in especialidades)
                {
                    if (plan.IDEspecialidad == especialidad.ID)
                    {
                        fila.Especialidad = especialidad.Descripcion;
                    }
                }
                filas.Add(fila);
            }
            
            this.dgvPlanes.DataSource = filas;
           
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
                int id = ((Fila)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
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
                int id = ((Fila)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
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
