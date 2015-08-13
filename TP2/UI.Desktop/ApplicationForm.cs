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

        public virtual void MapearDeDatos()
        {

        }

        public virtual void MapearADatos()
        {

        }

        public virtual void GuardarCambios()
        {

        }

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
