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

        public struct Fila
        {
            private int _id;
            private string _nombre;
            private string _apellido;
            private string _direccion;
            private string _email;
            private string _telefono;
            private DateTime _fechaNacimiento;
            private int _legajo;
            private string _tipoPersona;
            private string _plan;

            public int ID
            {
                get { return _id; }
                set { _id = value; }
            }
            
            public string Nombre
            {
                get { return _nombre; }
                set { _nombre = value; }
            }
            
            public string Apellido
            {
                get { return _apellido; }
                set { _apellido = value; }
            }
            
            public string Direccion
            {
                get { return _direccion; }
                set { _direccion = value; }
            }
   
            public string Email
            {
                get { return _email; }
                set { _email = value; }
            }
    
            public string Telefono
            {
                get { return _telefono; }
                set { _telefono = value; }
            }

            public DateTime FechaNacimiento
            {
                get { return _fechaNacimiento; }
                set { _fechaNacimiento = value; }
            }

            public int Legajo
            {
                get { return _legajo; }
                set { _legajo = value; }
            }

            public string TipoPersona
            {
                get { return _tipoPersona; }
                set { _tipoPersona = value; }
            }

            public string Plan
            {
                get { return _plan; }
                set { _plan = value; }
            }
        }

        //METODOS------------------------------------------------------------------------------------------------------
        public void Listar()
        {
            PersonaLogic personaLogic = new PersonaLogic();
            List<Persona> personas = personaLogic.GetAll();
            PlanLogic planLogic= new PlanLogic();

            List<Fila> filas = new List<Fila>();
            foreach (Persona persona in personas)
            {
                Fila fila = new Fila();
                fila.ID = persona.ID;
                fila.Nombre = persona.Nombre;
                fila.Apellido = persona.Apellido;
                fila.Direccion = persona.Direccion;
                fila.Email = persona.Email;
                fila.Telefono = persona.Telefono;
                fila.FechaNacimiento = persona.FechaNacimiento;
                fila.Legajo = persona.Legajo;
                if (persona.TipoPersona == 0)
                {
                    fila.TipoPersona = "Profesor";
                }
                else if (persona.TipoPersona == 1)
                {
                    fila.TipoPersona = "Alumno";
                }
                else
                {
                    fila.TipoPersona = "Administrador";
                }
                fila.Plan = planLogic.GetOne(persona.IDPlan).Descripcion;
                filas.Add(fila);
            }
            this.dgvPersonas.DataSource = filas;
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
           PersonaDesktop personaDesktop = new PersonaDesktop(ModoForm.Alta);
            personaDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Fila)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonaDesktop personaDesktop = new PersonaDesktop(id, ModoForm.Modificacion);
                personaDesktop.ShowDialog();
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
                int id = ((Fila)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonaDesktop personaDesktop = new PersonaDesktop(id, ModoForm.Baja);
                personaDesktop.ShowDialog();
                this.Listar();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Debe seleccionar una fila a eliminar");
            }
        }
    }
}
