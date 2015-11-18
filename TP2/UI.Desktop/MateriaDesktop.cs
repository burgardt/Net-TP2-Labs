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
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {
        private Materia _MateriaSelec;
        public List<Plan> listaPlanes;
        public PlanLogic planLogic;

        public MateriaDesktop()
        {
            InitializeComponent();
            MateriaSelec = new Materia();
        }

        public MateriaDesktop(ModoForm modo)
            : this()
        {
            this.Modo = modo;
        }

        public MateriaDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;

            MateriaLogic materiaLogic = new MateriaLogic();
            MateriaSelec = materiaLogic.GetOne(ID);
            MapearDeDatos();

            if (modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (modo == ModoForm.Baja)
            {
                this.txtDescripcion.ReadOnly = true;
                this.txtHsSemanales.ReadOnly = true;
                this.txtHsTotales.ReadOnly = true;
                this.cbxPlan.Enabled = false;
                this.btnAceptar.Text = "Eliminar";
            }
            else
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }


        public Materia MateriaSelec
        {
            get { return _MateriaSelec; }
            set { _MateriaSelec = value; }
        }


        private void MateriaDesktop_Load(object sender, EventArgs e)
        {
            planLogic = new PlanLogic();
            this.cbxPlan.DataSource = planLogic.GetAll();
            this.cbxPlan.ValueMember = "ID";
            this.cbxPlan.DisplayMember = "Descripcion";
        }


        public override void MapearDeDatos()
        {
            this.txtID.Text = MateriaSelec.ID.ToString();
            this.txtDescripcion.Text = MateriaSelec.Descripcion.ToString();
            this.txtHsSemanales.Text = MateriaSelec.HSSemanales.ToString();
            this.txtHsTotales.Text = MateriaSelec.HSTotales.ToString();
            this.cbxPlan.SelectedValue = MateriaSelec.IDPlan;
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                MateriaSelec.State = BusinessEntity.States.New;
            }
            else
            {
                MateriaSelec.State = BusinessEntity.States.Modified;
            }

            MateriaSelec.Descripcion = this.txtDescripcion.Text;
            MateriaSelec.HSSemanales = int.Parse(this.txtHsSemanales.Text);
            MateriaSelec.HSTotales = int.Parse(this.txtHsTotales.Text);
            MateriaSelec.IDPlan = (int)this.cbxPlan.SelectedValue;
        }


        public override void GuardarCambios()
        {
            MateriaLogic materiaLogic = new MateriaLogic();
            if (Modo == ModoForm.Modificacion || Modo == ModoForm.Alta)
            {
                MapearADatos();
                materiaLogic.Save(MateriaSelec);
            }
            else
            {
                materiaLogic.Delete(MateriaSelec.ID);
            }
        }


        public override bool Validar()
        {
            if (this.txtDescripcion.Text == string.Empty || this.txtHsSemanales.Text == string.Empty || this.txtHsTotales.Text == string.Empty)
            {
                MessageBox.Show("Alguno de los campos esta vacio");
                return false;
            }
            else if (!Regex.IsMatch(this.txtHsSemanales.Text, @"^[0-9]*$") || !Regex.IsMatch(this.txtHsTotales.Text, @"^[0-9]*$"))
            {
                MessageBox.Show("Tanto Hs Semanales como Hs Totales deben estar expresados con números enteros");
                return false;
            }
            else if (this.cbxPlan.SelectedValue == null)
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
