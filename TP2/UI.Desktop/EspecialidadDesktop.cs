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
        private Especialidad _EspecialidadSelec = new Especialidad();

        public EspecialidadDesktop()
        {
            InitializeComponent();
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
            EspecialidadLogic el = new EspecialidadLogic();
            EspecialidadSelec = el.GetOne(ID);

            if (modo == ModoForm.Modificacion)
            {
                this.txtID.Text = EspecialidadSelec.ID.ToString();
                this.txtID.ReadOnly = true;
                this.txtDescripcion.Text = EspecialidadSelec.Descripcion;
                this.btnAceptar.Text = "Guardar";
            }
            else if (modo == ModoForm.Baja)
            {
                this.txtID.Text = EspecialidadSelec.ID.ToString();
                this.txtID.ReadOnly = true;
                this.txtDescripcion.Text = EspecialidadSelec.Descripcion;
                this.txtDescripcion.ReadOnly = true;
                this.btnAceptar.Text = "Eliminar";
            }
            else
            {
                this.btnAceptar.Text = "Aceptar";
            }
            
        }

        //Metodos

        public Especialidad EspecialidadSelec
        {
            set { _EspecialidadSelec = value; }
            get { return _EspecialidadSelec; }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadSelec.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadSelec.Descripcion;        }

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
            if (Modo == ModoForm.Modificacion || Modo == ModoForm.Alta)
            {
                MapearADatos();
                EspecialidadLogic el = new EspecialidadLogic();
                el.Save(EspecialidadSelec);
            }
            else
            {
                EspecialidadLogic el = new EspecialidadLogic();
                el.Delete(EspecialidadSelec.ID);
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

        private void EspecialidadDesktop_Load(object sender, EventArgs e)
        {

        }
    }
}
