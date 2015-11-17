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
    public partial class FormComisiones : ApplicationForm
    {
        public FormComisiones()
        {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            ComisionLogic comisionLogic = new ComisionLogic();
            this.dgvComisiones.DataSource = comisionLogic.GetAll();
        }

        //EVENTOS
        private void formComisiones_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop comisionDesktop = new ComisionDesktop(ModoForm.Alta);
            comisionDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop comisionDesktop = new ComisionDesktop(id, ModoForm.Modificacion);
                comisionDesktop.ShowDialog();
                this.Listar();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Debe seleccionar una fila a modificar");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop comisionDesktop = new ComisionDesktop(id, ModoForm.Baja);
                comisionDesktop.ShowDialog();
                this.Listar();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Debe seleccionar una fila a eliminar");
            }
        }
    }
}
