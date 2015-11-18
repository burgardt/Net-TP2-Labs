using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class FormMaterias : ApplicationForm
    {
        public FormMaterias()
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
        }


        public struct Fila
        {
            private int _id;
            private string _descripcion;
            private int _hsSemanales;
            private int _hsTotales;
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

            public int HsSemanales
            {
                get { return _hsSemanales; }
                set { _hsSemanales = value; }
            }

            public int HsTotales
            {
                get { return _hsTotales; }
                set { _hsTotales = value; }
            }

            public string Plan
            {
                get { return _plan; }
                set { _plan = value; }
            }
        }


        public void Listar()
        {
            MateriaLogic materiaLogic = new MateriaLogic();
            List<Materia> materias = materiaLogic.GetAll();
            PlanLogic planLogic = new PlanLogic();
            List<Fila> filas = new List<Fila>();

            foreach (Materia materia in materias)
            {
                Fila fila = new Fila();
                fila.ID = materia.ID;
                fila.Descripcion = materia.Descripcion;
                fila.HsSemanales= materia.HSSemanales;
                fila.HsTotales = materia.HSTotales;
                fila.Plan = planLogic.GetOne(materia.IDPlan).Descripcion;
                filas.Add(fila);
            }
            this.dgvMaterias.DataSource = filas;
        }


        private void FormMaterias_Load(object sender, EventArgs e)
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
            MateriaDesktop materiaDesktop = new MateriaDesktop(ModoForm.Alta);
            materiaDesktop.ShowDialog();
            this.Listar();
        }


        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Fila)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop materiaDesktop = new MateriaDesktop(id, ModoForm.Modificacion);
                materiaDesktop.ShowDialog();
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
                int id = ((Fila)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop materiasDesktop = new MateriaDesktop(id, ModoForm.Baja);
                materiasDesktop.ShowDialog();
                this.Listar();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Debe seleccionar una fila a eliminar");
            }
        }
    }
}
