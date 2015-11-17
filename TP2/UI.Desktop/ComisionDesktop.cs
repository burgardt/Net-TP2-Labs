using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class ComisionDesktop : ApplicationForm
    {
        private Comision _ComisionSelec;
        public List<Plan> listaPlanes;
        public PlanLogic planLogic;

        public ComisionDesktop()
        {
            InitializeComponent();
            ComisionSelec = new Comision();
        }

        public ComisionDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
        }

        public ComisionDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;

            ComisionLogic cl = new ComisionLogic();
            ComisionSelec = cl.GetOne(ID);
            MapearDeDatos();

            if (modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (modo == ModoForm.Baja)
            {
                this.txtDescripcion.ReadOnly = true;
                this.cbxAnioEspecialidad.Enabled = false;
                this.cbxPlan.Enabled = false;
                this.btnAceptar.Text = "Eliminar";
            }
            else
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }


        public Comision ComisionSelec
        {
            get { return _ComisionSelec; }
            set { _ComisionSelec = value; }
        }


        private void ComisionDesktop_Load(object sender, EventArgs e)
        {
            planLogic = new PlanLogic();
            this.cbxPlan.DataSource = planLogic.GetAll();
            this.cbxPlan.ValueMember = "ID";
            this.cbxPlan.DisplayMember = "Descripcion";
        }


        public override void MapearDeDatos()
        {
            this.txtID.Text = ComisionSelec.ID.ToString();
            this.txtDescripcion.Text = ComisionSelec.Descripcion.ToString();
            this.cbxAnioEspecialidad.SelectedIndex = ComisionSelec.AnioEspecialidad - 1;
            this.cbxPlan.SelectedValue = ComisionSelec.IDPlan;
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                ComisionSelec.State = BusinessEntity.States.New;
            }
            else
            {
                ComisionSelec.State = BusinessEntity.States.Modified;
            }

            ComisionSelec.Descripcion = this.txtDescripcion.Text;
            ComisionSelec.AnioEspecialidad = int.Parse(this.cbxAnioEspecialidad.Text);
            ComisionSelec.IDPlan = (int)this.cbxPlan.SelectedValue;
        }


        public override void GuardarCambios()
        {
            ComisionLogic comisionLogic = new ComisionLogic();
            if (Modo == ModoForm.Modificacion || Modo == ModoForm.Alta)
            {
                MapearADatos();
                comisionLogic.Save(ComisionSelec);
            }
            else
            {
                comisionLogic.Delete(ComisionSelec.ID);
            }
        }


        public override bool Validar()
        {
            if (this.txtDescripcion.Text == string.Empty)
            {
                MessageBox.Show("Alguno de los campos esta vacio");
                return false;
            }
            else if (this.cbxPlan.SelectedValue == null || this.cbxAnioEspecialidad.SelectedIndex == -1)
            {
                MessageBox.Show("Algunos valores no han sido seleccionados");
                return false;
            }
            else
            {
                return true;
            }
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
