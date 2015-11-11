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
        private Persona _PersonaActual;
        public List<Plan> listaPlanes;
        public PlanLogic pl;

       //CONSTRUCTORES--------------------------------------------------------------------------------------------------
        public PersonaDesktop()
        {
            InitializeComponent();
            _PersonaActual = new Persona();
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
            this.txtNombre.Text = PersonaActual.Nombre.ToString();
            this.txtApellido.Text = PersonaActual.Apellido.ToString();
            this.txtDireccion.Text = PersonaActual.Direccion.ToString();
            this.txtEmail.Text = PersonaActual.Email.ToString();
            this.txtTelefono.Text = PersonaActual.Telefono.ToString();
            this.cbxDia.Text = PersonaActual.FechaNacimiento.Day.ToString();
            this.cbxMes.SelectedIndex = PersonaActual.FechaNacimiento.Month - 1;
            this.cbxAnio.Text = PersonaActual.FechaNacimiento.Year.ToString();
            this.txtLegajo.Text = PersonaActual.Legajo.ToString();
            this.cbxTipo.SelectedIndex = PersonaActual.TipoPersona;
            this.cbxPlan.SelectedValue = PersonaActual.IDPlan;

            if (modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (modo == ModoForm.Baja)
            {
                this.txtNombre.ReadOnly = true;       
                this.txtApellido.ReadOnly = true;
                this.txtDireccion.ReadOnly = true;
                this.txtEmail.ReadOnly = true;
                this.txtTelefono.ReadOnly = true;
                this.cbxDia.Enabled = false;
                this.cbxMes.Enabled = false;
                this.cbxAnio.Enabled = false;
                this.txtLegajo.ReadOnly = true;
                this.cbxTipo.Enabled = false;
                this.cbxPlan.Enabled = false;
                
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


        private void PersonaDesktop_Load(object sender, EventArgs e)
        {
            pl = new PlanLogic();
            listaPlanes = pl.GetAll();

            foreach (Plan plan in listaPlanes)
            {
                this.cbxPlan.DataSource = pl.GetAll();
                this.cbxPlan.ValueMember = "ID";
                this.cbxPlan.DisplayMember = "Descripcion";

            }

            this.cbxAnio.SelectedIndex = 0;
        }


        public override void MapearADatos()
        {
            int anio = int.Parse(this.cbxAnio.Text.ToString());
            int mes = this.cbxMes.SelectedIndex + 1;
            int dia = int.Parse(this.cbxDia.Text.ToString());

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
                
                DateTime fechaNac= new DateTime(anio, mes, dia);
                string[] plan = this.cbxPlan.Text.Split('-');
                PersonaActual.Nombre = this.txtNombre.Text;
                PersonaActual.Apellido = this.txtApellido.Text;
                PersonaActual.Direccion = this.txtDireccion.Text;
                PersonaActual.Email = this.txtEmail.Text;
                PersonaActual.Telefono= this.txtTelefono.Text;
                PersonaActual.FechaNacimiento = fechaNac;
                PersonaActual.Legajo = Convert.ToInt32(int.Parse(this.txtLegajo.Text));
                PersonaActual.IDPlan = int.Parse(this.cbxPlan.SelectedValue.ToString());
                PersonaActual.TipoPersona = this.cbxTipo.SelectedIndex;

               }
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


        public override void GuardarCambios()
        {
            PersonaLogic pl = new PersonaLogic();
            if (Modo == ModoForm.Modificacion || Modo == ModoForm.Alta)
            {
                MapearADatos();
                pl.Save(PersonaActual);

                if (Modo == ModoForm.Alta)
                {
                    UsuarioLogic ul = new UsuarioLogic();
                    List<Usuario> usuarios = ul.GetAll();
                    bool logueaUsuario = true;
                    foreach (Usuario usuario in usuarios)
                    {
                        if (PersonaActual.ID == usuario.IdPersona)
                        {
                            logueaUsuario = false;
                        }
                    }
                    if (logueaUsuario)
                    {
                        MessageBox.Show("La persona no esta registrada como usuario del sistema. Complete los datos de usuario a continuación");
                        UsuarioDesktop ud = new UsuarioDesktop(PersonaActual.ID);
                        ud.ShowDialog();
                    }
                }
            }
            else
            {
                pl.Delete(PersonaActual.ID);
            }
        }


        public override bool Validar()
        {   
            bool isEmail = Regex.IsMatch(this.txtEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            bool isInt = Regex.IsMatch(this.txtLegajo.Text, @"/^[0-9]+$/");
            
            if (this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty ||
                this.txtEmail.Text == string.Empty || this.txtDireccion.Text == string.Empty ||
                this.txtTelefono.Text == string.Empty || this.txtLegajo.Text == string.Empty /*||
                this.cbxAnio.SelectedIndex == -1 || this.cbxMes.SelectedIndex == -1 ||
                this.cbxDia.SelectedIndex == -1 || this.cbxPlan.SelectedIndex == -1 ||
                this.cbxPlan.SelectedIndex == -1*/)
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


        private void cbxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbxMes.SelectedIndex == 0 || this.cbxMes.SelectedIndex == 2 || this.cbxMes.SelectedIndex == 4 ||
                this.cbxMes.SelectedIndex == 6 || this.cbxMes.SelectedIndex == 7 || this.cbxMes.SelectedIndex == 9 ||
                this.cbxMes.SelectedIndex == 11) 
            {
                cbxDia.Items.Clear();
                for (int i = 1; i <= 31; i++)
                {
                    cbxDia.Items.Add(i);
                }
            }
            else if (this.cbxMes.SelectedIndex == 3 || this.cbxMes.SelectedIndex == 5 || this.cbxMes.SelectedIndex == 8 ||
                this.cbxMes.SelectedIndex == 10)
            {
                cbxDia.Items.Clear();
                for (int i = 1; i <= 30; i++)
                {
                    cbxDia.Items.Add(i);
                }
            }
            else if (this.cbxMes.SelectedIndex == 1)
            {
                cbxDia.Items.Clear();
                int anio = int.Parse(this.cbxAnio.SelectedItem.ToString());
                if (anio%4 == 0 && anio%100 != 0)
                {
                    for (int i = 1; i <= 29; i++)
                    {
                        cbxDia.Items.Add(i);
                    }
                }
                else
                {
                    for (int i = 1; i <= 28; i++)
                    {
                        cbxDia.Items.Add(i);
                    }
                }
            }
            else
            {
                cbxDia.Items.Clear();
            }
        }
    }
}
