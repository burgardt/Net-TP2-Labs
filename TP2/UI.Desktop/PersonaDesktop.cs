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
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {
        //VARIABLES----------------------------------------------------------------------------------------------------
        private Persona _PersonaActual = new Persona();

       //CONSTRUCTORES--------------------------------------------------------------------------------------------------
        public PersonaDesktop()
        {
            InitializeComponent();
        }

        public PersonaDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
        }

        public PersonaDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo=modo;
            PersonaLogic pl= new PersonaLogic();
            PersonaActual = pl.GetOne(ID);
            this.txtID.Text = PersonaActual.ID.ToString();

            if (modo == ModoForm.Modificacion)
            {
                this.txtNombre.Text = PersonaActual.Nombre.ToString();
                this.txtApellido.Text = PersonaActual.Apellido.ToString();
                this.txtDireccion.Text= PersonaActual.Direccion.ToString();
                this.txtEmail.Text = PersonaActual.Email.ToString();
                this.txtTelefono.Text=PersonaActual.Telefono.ToString();
                this.cbxDia.SelectedValue = PersonaActual.FechaNacimiento.Day;
                this.cbxMes.SelectedValue = PersonaActual.FechaNacimiento.Month;
                this.cbxAnio.SelectedValue = PersonaActual.FechaNacimiento.Year;
                this.txtLegajo.Text = PersonaActual.Legajo.ToString();
                // this.cbxTipo.SelectedIndex = (int)PersonaActual.TipoPersona;
                // this.cbxPlan.
                this.btnAceptar.Text = "Guardar";
            }
            else if (modo == ModoForm.Baja)
            {
                this.txtNombre.Text = PersonaActual.Nombre.ToString();
                this.txtNombre.ReadOnly = true;
                this.txtApellido.Text = PersonaActual.Apellido.ToString();
                this.txtApellido.ReadOnly = true;
                this.txtDireccion.Text= PersonaActual.Direccion.ToString();
                this.txtDireccion.ReadOnly = true;
                this.txtEmail.Text = PersonaActual.Email.ToString();
                this.txtEmail.ReadOnly = true;
                this.txtTelefono.Text=PersonaActual.Telefono.ToString();
                this.txtTelefono.ReadOnly = true;
                this.cbxDia.SelectedValue = PersonaActual.FechaNacimiento.Day;
                this.cbxDia.Enabled = false;
                this.cbxMes.SelectedValue = PersonaActual.FechaNacimiento.Month;
                this.cbxMes.Enabled = false;
                this.cbxAnio.SelectedValue = PersonaActual.FechaNacimiento.Year;
                this.cbxAnio.Enabled = false;
                this.txtLegajo.Text = PersonaActual.Legajo.ToString();
                this.txtLegajo.ReadOnly = true;
                // this.cbxTipo.SelectedIndex = (int)PersonaActual.TipoPersona;
                this.cbxTipo.Enabled = false;
                // this.cbxPlan.
                
                this.btnAceptar.Text = "Eliminar";
            }
            else
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }

        //METODOS-----------------------------------------------------------------------------------------------------
        public Persona PersonaActual
        {
            set { _PersonaActual = value; }
            get { return _PersonaActual; }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = PersonaActual.ID.ToString();
            this.txtNombre.Text = PersonaActual.Nombre.ToString();
            this.txtApellido.Text = PersonaActual.Apellido.ToString();
            this.txtDireccion.Text = PersonaActual.Direccion.ToString();
            this.txtEmail.Text = PersonaActual.Email.ToString();
            this.txtTelefono.Text = PersonaActual.Telefono.ToString();                               
            this.cbxDia.SelectedValue = PersonaActual.FechaNacimiento.Day;
            this.cbxMes.SelectedValue = PersonaActual.FechaNacimiento.Month;
            this.cbxAnio.SelectedValue = PersonaActual.FechaNacimiento.Year;
            this.txtLegajo.Text = PersonaActual.Legajo.ToString();
            // this.cbxTipo.SelectedValue = (int)PersonaActual.TipoPersona;
            // this.cbxPlan.
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Persona persona = new Persona();
                PersonaActual = persona;
                PersonaActual.State = BusinessEntity.States.New;
            }
            else
            {
                PersonaActual.State = BusinessEntity.States.Modified;
            }

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                DateTime fechaNac= new DateTime((int)this.cbxAnio.SelectedValue, (int)this.cbxMes.SelectedValue, (int)this.cbxDia.SelectedValue);
                PersonaActual.Nombre = this.txtNombre.Text;
                PersonaActual.Apellido = this.txtApellido.Text;
                PersonaActual.Direccion = this.txtDireccion.Text;
                PersonaActual.Email = this.txtEmail.Text;
                PersonaActual.Telefono= this.txtDireccion.Text;
                PersonaActual.FechaNacimiento = fechaNac;
                PersonaActual.Legajo = Convert.ToInt32(this.txtLegajo);
                // PersonaActual.TipoPersona
                // PersonaActual.IdPlan

               }
        }

        public override void GuardarCambios()
        {
            if (Modo == ModoForm.Modificacion || Modo == ModoForm.Alta)
            {
                MapearADatos();
                PersonaLogic pl= new PersonaLogic();
                pl.Save(PersonaActual);
            }
            else
            {
                PersonaLogic pl = new PersonaLogic();
                pl.Delete(PersonaActual.ID);
            }
        }

        public override bool Validar()
        {   
            bool isEmail = Regex.IsMatch(this.txtEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            bool isInt = Regex.IsMatch(this.txtLegajo.Text, @"/^[0-9]+$/");
            
            if (this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty ||
                this.txtEmail.Text == string.Empty || this.txtDireccion.Text == string.Empty ||
                this.txtTelefono.Text == string.Empty || this.txtLegajo.Text == string.Empty ||
                this.cbxAnio.SelectedIndex == -1 || this.cbxMes.SelectedIndex == -1 ||
                this.cbxDia.SelectedIndex == -1 || this.cbxPlan.SelectedIndex == -1 ||
                this.cbxPlan.SelectedIndex == -1)
            {
                MessageBox.Show("Alguno de los campos esta vacio o no se han seleccionado valores");
                return false;
            }
            else if (!isEmail)
            {
                MessageBox.Show("Email no tiene un formato valido");
                return false;
            }
            else if (!isInt && this.txtLegajo.Text.Length>8)
            {
                MessageBox.Show("El legajo debe contener solo numeros y no debe superar los 8 caracteres");
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

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }
       
    }
}
