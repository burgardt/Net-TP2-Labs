using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        //VARIABLES----------------------------------------------------------------------------------------------------
        private Usuario _UsuarioActual = new Usuario();

        //CONSTRUCTORES--------------------------------------------------------------------------------------------------
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo=modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);
           // this.txtID.Text = UsuarioActual.ID.ToString();

            if (modo == ModoForm.Modificacion)
            {
                this.txtID.Text = UsuarioActual.ID.ToString();
                this.txtNombre.Text = UsuarioActual.Nombre.ToString();
                this.txtApellido.Text = UsuarioActual.Apellido.ToString();
                this.txtEmail.Text = UsuarioActual.Email.ToString();
                this.txtUsuario.Text = UsuarioActual.NombreUsuario.ToString();
                this.txtClave.Text = UsuarioActual.Clave.ToString();
                this.txtConClave.Text = UsuarioActual.Clave.ToString();
                this.chkHabilitado.Checked = UsuarioActual.Habilitado;
                this.btnAceptar.Text = "Guardar";
            }
            else if (modo == ModoForm.Baja)
            {
                this.txtID.Text = UsuarioActual.ID.ToString();
                this.txtID.ReadOnly = true;
                this.txtNombre.Text = UsuarioActual.Nombre.ToString();
                this.txtNombre.ReadOnly = true;
                this.txtApellido.Text = UsuarioActual.Apellido.ToString();
                this.txtApellido.ReadOnly = true;
                this.txtEmail.Text = UsuarioActual.Email.ToString();
                this.txtEmail.ReadOnly = true;
                this.txtUsuario.Text = UsuarioActual.NombreUsuario.ToString();
                this.txtUsuario.ReadOnly = true;
                this.txtClave.Text = UsuarioActual.Clave.ToString();
                this.txtClave.ReadOnly = true;
                this.txtConClave.Text = UsuarioActual.Clave.ToString();
                this.txtConClave.ReadOnly = true;
                this.chkHabilitado.Checked = UsuarioActual.Habilitado;
                this.chkHabilitado.AutoCheck = false;
                this.btnAceptar.Text = "Eliminar";
            }
            else
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }

        //METODOS-----------------------------------------------------------------------------------------------------
        public Usuario UsuarioActual
        {
            set { _UsuarioActual = value; }
            get { return _UsuarioActual; }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Usuario usuario = new Usuario();
                UsuarioActual = usuario;
                UsuarioActual.State = BusinessEntity.States.New;
            }
            else
            {
                UsuarioActual.State = BusinessEntity.States.Modified;
            }

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.Email = this.txtEmail.Text;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            }
        }

        public override void GuardarCambios()
        {
            if (Modo == ModoForm.Modificacion || Modo == ModoForm.Alta)
            {
                MapearADatos();
                UsuarioLogic ul = new UsuarioLogic();
                ul.Save(UsuarioActual);
            }
            else
            {
                UsuarioLogic ul = new UsuarioLogic();
                ul.Delete(UsuarioActual.ID);
            }
        }

        public override bool Validar()
        {   
            bool isEmail = Regex.IsMatch(this.txtEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Console.Write("nombre txt" + txtNombre.Text);
            if (this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty ||
                this.txtEmail.Text == string.Empty || this.txtUsuario.Text == string.Empty ||
                this.txtClave.Text == string.Empty)
            {
                MessageBox.Show("Alguno de los campos esta vacio");
                return false;
            }
            else if (!isEmail)
            {
                MessageBox.Show("Email no tiene un formato valido");
                return false;
            }
            else if (this.txtClave.Text.Length < 8)
            {
                MessageBox.Show("La clave debe contener como minimo 8 caracteres");
                return false;
            }
            else if (this.txtClave.Text != this.txtConClave.Text)
            {
                MessageBox.Show("La confirmacion de la clave no coincide con la clave ingresada");
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
