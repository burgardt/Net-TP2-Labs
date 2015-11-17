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
        private Usuario _UsuarioSelec;

        //CONSTRUCTORES--------------------------------------------------------------------------------------------------
        public UsuarioDesktop(int personaId)
        {
            InitializeComponent();
            UsuarioSelec = new Usuario();
            this.txtPersonaId.Text = personaId.ToString();
            this.txtPersonaId.ReadOnly = true;
        }


        public UsuarioDesktop()
        {
            InitializeComponent();
            UsuarioSelec = new Usuario();
            this.txtPersonaId.Text = "0";
            this.lblPersonaId.Visible = false;
            this.txtPersonaId.Visible = false;
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

            UsuarioLogic usuarioLogic = new UsuarioLogic();
            UsuarioSelec = usuarioLogic.GetOne(ID);

            this.txtID.Text = UsuarioSelec.ID.ToString();
            this.txtNombre.Text = UsuarioSelec.Nombre.ToString();
            this.txtApellido.Text = UsuarioSelec.Apellido.ToString();
            this.txtEmail.Text = UsuarioSelec.Email.ToString();
            this.txtUsuario.Text = UsuarioSelec.NombreUsuario.ToString();
            this.txtClave.Text = UsuarioSelec.Clave.ToString();
            this.txtConClave.Text = UsuarioSelec.Clave.ToString();
            this.chkHabilitado.Checked = UsuarioSelec.Habilitado;
            this.txtPersonaId.Text = UsuarioSelec.IdPersona.ToString();

            if (modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (modo == ModoForm.Baja)
            {
                this.txtNombre.ReadOnly = true;
                this.txtApellido.ReadOnly = true;
                this.txtEmail.ReadOnly = true;
                this.txtUsuario.ReadOnly = true;
                this.txtClave.ReadOnly = true;
                this.txtConClave.ReadOnly = true;
                this.chkHabilitado.AutoCheck = false;
                this.txtPersonaId.ReadOnly = true;
                this.btnAceptar.Text = "Eliminar";
            }
            else
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }

        //METODOS-----------------------------------------------------------------------------------------------------
        public Usuario UsuarioSelec
        {
            set { _UsuarioSelec = value; }
            get { return _UsuarioSelec; }
        }

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioSelec.ID.ToString();
            this.txtNombre.Text = this.UsuarioSelec.Nombre;
            this.txtApellido.Text = this.UsuarioSelec.Apellido;
            this.txtEmail.Text = this.UsuarioSelec.Email;
            this.txtUsuario.Text = this.UsuarioSelec.NombreUsuario;
            this.txtClave.Text = this.UsuarioSelec.Clave;
            this.chkHabilitado.Checked = this.UsuarioSelec.Habilitado;
            this.txtPersonaId.Text = this.UsuarioSelec.IdPersona.ToString();
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Usuario usuario = new Usuario();
                UsuarioSelec = usuario;
                UsuarioSelec.State = BusinessEntity.States.New;
            }
            else
            {
                UsuarioSelec.State = BusinessEntity.States.Modified;
            }

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.UsuarioSelec.Nombre = this.txtNombre.Text;
                this.UsuarioSelec.Apellido = this.txtApellido.Text;
                this.UsuarioSelec.Email = this.txtEmail.Text;
                this.UsuarioSelec.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioSelec.Clave = this.txtClave.Text;
                this.UsuarioSelec.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioSelec.IdPersona = int.Parse(this.txtPersonaId.Text);
            }
        }


        public override void GuardarCambios()
        {
            UsuarioLogic usuarioLogic = new UsuarioLogic();
            if (Modo == ModoForm.Modificacion || Modo == ModoForm.Alta)
            {
                MapearADatos();
                usuarioLogic.Save(UsuarioSelec);
            }
            else
            {
                usuarioLogic.Delete(UsuarioSelec.ID);
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
    }
}
