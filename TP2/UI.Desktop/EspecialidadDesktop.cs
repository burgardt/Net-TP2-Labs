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
    public partial class EspecialidadDesktop : ApplicationForm
    {
        private Especialidad _EspecialidadSelec;

        public EspecialidadDesktop()
        {
            InitializeComponent();
            EspecialidadSelec = new Especialidad();
        }

        public EspecialidadDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
        }

        public EspecialidadDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;

            EspecialidadLogic especialidadLogic = new EspecialidadLogic();
            EspecialidadSelec = especialidadLogic.GetOne(ID);
            MapearDeDatos();


            if (modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (modo == ModoForm.Baja)
            {
                this.txtDescripcion.ReadOnly = true;
                this.btnAceptar.Text = "Eliminar";
            }
            else
            {
                this.btnAceptar.Text = "Aceptar";
            }         
        }


        public Especialidad EspecialidadSelec
        {
            set { _EspecialidadSelec = value; }
            get { return _EspecialidadSelec; }
        }

        private void EspecialidadDesktop_Load(object sender, EventArgs e)
        {

        }


        public override void MapearDeDatos()
        {
            this.txtID.Text = EspecialidadSelec.ID.ToString();
            this.txtDescripcion.Text = EspecialidadSelec.Descripcion;       
        }


        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Especialidad especialidad = new Especialidad();
                EspecialidadSelec= especialidad;
                EspecialidadSelec.State = BusinessEntity.States.New;
            }
            else
            {
               EspecialidadSelec.State = BusinessEntity.States.Modified;
            }

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.EspecialidadSelec.Descripcion = this.txtDescripcion.Text;
            }
        }

        public override void GuardarCambios()
        {
            EspecialidadLogic especialidadLogic = new EspecialidadLogic();
            if (Modo == ModoForm.Modificacion || Modo == ModoForm.Alta)
            {
                MapearADatos();
                especialidadLogic.Save(EspecialidadSelec);
            }
            else
            {
                especialidadLogic.Delete(EspecialidadSelec.ID);
            }
        }


        public override bool Validar()
        { 
            if (this.txtDescripcion.Text == string.Empty)
            {
                MessageBox.Show("No ha especificado una descripcion para la especialidad");
                return false;
            }
            else
                return true;
        }


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
    }
}
