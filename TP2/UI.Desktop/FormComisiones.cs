using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class FormComisiones : ApplicationForm
    {
        public FormComisiones()
        {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;
        }

        public struct Fila
        {
            private int _id;
            private string _descripcion;
            private int _anioEspecialidad;
            private string _plan;


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

            public int AnioEspecialidad
            {
                get { return _anioEspecialidad; }
                set { _anioEspecialidad = value; }
            }

            public string Plan
            {
                get { return _plan; }
                set { _plan = value; }
            }
        }

        public void Listar()
        {
            ComisionLogic comisionLogic = new ComisionLogic();
            List<Comision> comisiones = comisionLogic.GetAll();
            PlanLogic planLogic = new PlanLogic();
            List<Fila> filas = new List<Fila>();

            foreach (Comision comision in comisiones)
            {
                Fila fila = new Fila();
                fila.ID = comision.ID;
                fila.Descripcion = comision.Descripcion;
                fila.AnioEspecialidad = comision.AnioEspecialidad;
                fila.Plan = planLogic.GetOne(comision.IDPlan).Descripcion;
                filas.Add(fila);
            }
            this.dgvComisiones.DataSource = filas;
        }

        //EVENTOS
        private void formComisiones_Load(object sender, EventArgs e)
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
            ComisionDesktop comisionDesktop = new ComisionDesktop(ModoForm.Alta);
            comisionDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Fila)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop comisionDesktop = new ComisionDesktop(id, ModoForm.Modificacion);
                comisionDesktop.ShowDialog();
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
                int id = ((Fila)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop comisionDesktop = new ComisionDesktop(id, ModoForm.Baja);
                comisionDesktop.ShowDialog();
                this.Listar();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Debe seleccionar una fila a eliminar");
            }
        }
    }
}
