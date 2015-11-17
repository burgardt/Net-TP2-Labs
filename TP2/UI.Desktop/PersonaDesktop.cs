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
        private Persona _PersonaSelec;
        public List<Plan> listaPlanes;
        public PlanLogic planLogic;

       //CONSTRUCTORES--------------------------------------------------------------------------------------------------
        public PersonaDesktop()
        {
            InitializeComponent();
            PersonaSelec = new Persona();
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

            PersonaLogic personaLogic= new PersonaLogic();
            PersonaSelec = personaLogic.GetOne(ID);
            MapearDeDatos();

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


        public Persona PersonaSelec
        {
            set { _PersonaSelec = value; }
            get { return _PersonaSelec; }
        }


        private void PersonaDesktop_Load(object sender, EventArgs e)
        {
            planLogic = new PlanLogic();
            this.cbxPlan.DataSource = planLogic.GetAll();
            this.cbxPlan.ValueMember = "ID";
            this.cbxPlan.DisplayMember = "Descripcion";
        }


        public override void MapearDeDatos()
        {
            this.txtID.Text = PersonaSelec.ID.ToString();
            this.txtNombre.Text = PersonaSelec.Nombre.ToString();
            this.txtApellido.Text = PersonaSelec.Apellido.ToString();
            this.txtDireccion.Text = PersonaSelec.Direccion.ToString();
            this.txtEmail.Text = PersonaSelec.Email.ToString();
            this.txtTelefono.Text = PersonaSelec.Telefono.ToString();
            this.cbxDia.Text = PersonaSelec.FechaNacimiento.Day.ToString();
            this.cbxMes.SelectedIndex = PersonaSelec.FechaNacimiento.Month - 1;
            this.cbxAnio.Text = PersonaSelec.FechaNacimiento.Year.ToString();
            this.txtLegajo.Text = PersonaSelec.Legajo.ToString();
            this.cbxTipo.SelectedIndex = PersonaSelec.TipoPersona;
            this.cbxPlan.SelectedValue = PersonaSelec.IDPlan; //no lo setea preguntar al profE
        }


        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                PersonaSelec.State = BusinessEntity.States.New;
            }
            else
            {
                PersonaSelec.State = BusinessEntity.States.Modified;
            }

            int anio = int.Parse(this.cbxAnio.Text.ToString());
            int mes = this.cbxMes.SelectedIndex + 1;
            int dia = int.Parse(this.cbxDia.Text.ToString());

            DateTime fechaNac= new DateTime(anio, mes, dia);
            PersonaSelec.Nombre = this.txtNombre.Text;
            PersonaSelec.Apellido = this.txtApellido.Text;
            PersonaSelec.Direccion = this.txtDireccion.Text;
            PersonaSelec.Email = this.txtEmail.Text;
            PersonaSelec.Telefono= this.txtTelefono.Text;
            PersonaSelec.FechaNacimiento = fechaNac;
            PersonaSelec.Legajo = Convert.ToInt32(int.Parse(this.txtLegajo.Text));
            PersonaSelec.IDPlan = (int) this.cbxPlan.SelectedValue;
            PersonaSelec.TipoPersona = this.cbxTipo.SelectedIndex;
        }


        public override void GuardarCambios()
        {
            PersonaLogic personaLogic = new PersonaLogic();
            if (Modo == ModoForm.Modificacion || Modo == ModoForm.Alta)
            {
                MapearADatos();
                personaLogic.Save(PersonaSelec);

                if (Modo == ModoForm.Alta)
                {
                    UsuarioLogic usuarioLogic = new UsuarioLogic();
                    List<Usuario> usuarios = usuarioLogic.GetAll();
                    // valida que la persona este logueada como usuario.
                    // igual medio al pedo que valide porque entre siempre
                    bool logueaUsuario = true;
                    foreach (Usuario usuario in usuarios)
                    {
                        if (PersonaSelec.ID == usuario.IdPersona)
                        {
                            logueaUsuario = false;
                        }
                    }
                    if (logueaUsuario)
                    {
                        MessageBox.Show("La persona no esta registrada como usuario del sistema. Complete los datos de usuario a continuación");
                        UsuarioDesktop ud = new UsuarioDesktop(PersonaSelec.ID);
                        ud.ShowDialog();
                    }
                }
            }
            else
            {
                personaLogic.Delete(PersonaSelec.ID);
            }
        }


        public override bool Validar()
        {   
            bool isEmail = Regex.IsMatch(this.txtEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            bool legajoIsInt = Regex.IsMatch(this.txtLegajo.Text, @"/^[0-9]+$/");
            
            if (this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty ||
                this.txtEmail.Text == string.Empty || this.txtDireccion.Text == string.Empty ||
                this.txtTelefono.Text == string.Empty || this.txtLegajo.Text == string.Empty)
            {
                MessageBox.Show("Alguno de los campos esta vacio");
                return false;
            }
            else if (this.cbxAnio.SelectedIndex == -1 || this.cbxMes.SelectedIndex == -1 ||
                this.cbxDia.SelectedIndex == -1 || this.cbxPlan.SelectedValue == null ||
                this.cbxTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Algunos valores no han sido seleccionados");
                return false;
            }
            else if (!isEmail)
            {
                MessageBox.Show("Email no tiene un formato valido");
                return false;
            }
            else if (!legajoIsInt && this.txtLegajo.Text.Length>8)
            {
                MessageBox.Show("El legajo debe contener solo numeros y no debe superar los 8 caracteres");
                return false;
            }
            else if ((cbxMes.SelectedIndex == 3 || cbxMes.SelectedIndex == 5 || cbxMes.SelectedIndex == 8 || cbxMes.SelectedIndex == 10) 
                && cbxDia.Text == "31")
            {
                    MessageBox.Show("la fecha de nacimiento seleccionada no es valida");
                    return false;
            }
            else if (cbxMes.SelectedIndex == 1 && (cbxDia.Text == "29" || cbxDia.Text == "30" || cbxDia.Text == "31"))
            {
                if (cbxDia.Text == "29" && int.Parse(cbxAnio.Text) % 4 == 0 && int.Parse(cbxAnio.Text) % 100 != 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("la fecha de nacimiento seleccionada no es valida");
                    return false;
                }
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
