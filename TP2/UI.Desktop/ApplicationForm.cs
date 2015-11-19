using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ApplicationForm : Form
    {
        //VARIABLES----------------------------------------------------------------------------------------------------

        public enum ModoForm { Alta, Baja, Modificacion, Consulta };
        private ModoForm _Modo;

        //CONSTRUCTOR---------------------------------------------------------------------------------------------------

        public ApplicationForm()
        {
            InitializeComponent();
        }

        //PROPIEDADES---------------------------------------------------------------------------------------------------

        public ModoForm Modo
        {
            set { _Modo = value; }
            get { return _Modo; }
        }


        //METODOS-----------------------------------------------------------------------------------------------------

        /* MapearDeDatos va a ser utilizado en cada formulario para copiar la
        información de las entidades a los controles del formulario (TextBox,
        ComboBox, etc) para mostrar la infromación de cada entidad
        */
        public virtual void MapearDeDatos()
        {

        }

        /* MapearADatos se va a utilizar para pasar la información de los
        controles a una entidad para luego enviarla a las capas inferiores*/
        public virtual void MapearADatos()
        {

        }

        /*GuardarCambios es el método que se encargará de invocar al método
        correspondiente de la capa de negocio según sea el ModoForm en que se
        encuentre el formulario
         */
        public virtual void GuardarCambios()
        {

        }

        /*Validar será el método que devuelva si los datos son válidos para poder
        registrar los cambios realizados.
         */
        public virtual bool Validar()
        {
            return false;
        }

        public virtual void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        private void ApplicationForm_Load(object sender, EventArgs e)
        {

        }
    }
}