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
    public partial class PlanDesktop : ApplicationForm
    {
        private Plan _PlanSelec = new Plan();
        public List<Especialidad> listaEspecialidades;
        public EspecialidadLogic el;

        public PlanDesktop()
        {
            InitializeComponent();
        }


        public PlanDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
        }


        public PlanDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;

            listaEspecialidades = new List<Especialidad>();
            EspecialidadLogic el = new EspecialidadLogic();
            listaEspecialidades = el.GetAll();

            PlanLogic pl = new PlanLogic();
            PlanSelec = pl.GetOne(ID);

            if (modo == ModoForm.Modificacion)
            {
                this.txtID.Text = PlanSelec.ID.ToString();
                this.txtID.ReadOnly = true;
                this.txtDescripcion.Text = PlanSelec.Descripcion;
                this.cbxEspecialidad.SelectedItem = 1;
                foreach (Especialidad esp in listaEspecialidades)
                {
                    if (PlanSelec.IDEspecialidad == esp.ID)
                    {
                        this.cbxEspecialidad.Text = esp.Descripcion;
                    }
                }
            }
            else if (modo == ModoForm.Baja)
            {
                this.txtID.Text = PlanSelec.ID.ToString();
                this.txtID.ReadOnly = true;
                this.txtDescripcion.Text = PlanSelec.Descripcion;
                this.txtDescripcion.ReadOnly = true;
                foreach (Especialidad esp in listaEspecialidades)
                {
                    if (PlanSelec.IDEspecialidad == esp.ID)
                    {
                        this.cbxEspecialidad.Text = esp.Descripcion;
                    }
                }
                this.cbxEspecialidad.Enabled = false;
            }           
        }

        public Plan PlanSelec
        {
            set { _PlanSelec = value; }
            get { return _PlanSelec; }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanSelec.ID.ToString();
            this.txtDescripcion.Text = this.PlanSelec.Descripcion;
            foreach (Especialidad esp in listaEspecialidades)
            {
                if (PlanSelec.IDEspecialidad == esp.ID)
                {
                    this.cbxEspecialidad.SelectedText = esp.Descripcion;
                }
            }
        }


        public override void MapearADatos()
        {
                if (Modo == ModoForm.Alta)
                {
                    Plan plan = new Plan();
                    PlanSelec = plan;
                    PlanSelec.State = BusinessEntity.States.New;
                }
                else
                {
                    PlanSelec.State = BusinessEntity.States.Modified;
                }

                if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
                {
                    this.PlanSelec.Descripcion = this.txtDescripcion.Text;
                    foreach (Especialidad esp in listaEspecialidades)
                    {
                        if (cbxEspecialidad.SelectedItem.ToString() == esp.Descripcion)
                        {
                            this.PlanSelec.IDEspecialidad = esp.ID;
                        }
                    }
                }
        }


        public override void GuardarCambios()
        {
            if (Modo == ModoForm.Modificacion || Modo == ModoForm.Alta)
            {
                MapearADatos();
                PlanLogic pl = new PlanLogic();
                pl.Save(PlanSelec);
            }
            else
            {
                PlanLogic pl = new PlanLogic();
                pl.Delete(PlanSelec.ID);
            }
        }


        public override bool Validar()
        {
            if (this.txtDescripcion.Text == string.Empty)
            {
                MessageBox.Show("No ha especificado una descripcion para plan");
                return false;
            }
            else if (this.cbxEspecialidad.SelectedIndex == -1 &&  this.cbxEspecialidad.Enabled == true)
            {
                MessageBox.Show("Error al grabar los datos : \nLa especialidad especificada para el plan no es válida.",
                    " Debe seleccionar alguna de las especialidades disponibles");
                return false;
            }
            else
            {
                return true;
            }
                
        }

//EVENTOS-------------------------------------------------------------------------------------------------------------
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void PlanDesktop_Load(object sender, EventArgs e)
        {
            el = new EspecialidadLogic();
            listaEspecialidades = el.GetAll();
            foreach (Especialidad esp in listaEspecialidades)
            {
                this.cbxEspecialidad.Items.Add(esp.Descripcion);
            }
        }
    }
}
