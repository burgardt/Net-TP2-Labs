﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class FormUsuarios : ApplicationForm
    {
        //CONSTRUCTORES-------------------------------------------------------------------------------------------------

        public FormUsuarios()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        //METODOS------------------------------------------------------------------------------------------------------
        public void Listar()
        {
            UsuarioLogic usuarioLogic = new UsuarioLogic();
            this.dgvUsuarios.DataSource = usuarioLogic.GetAll();
        }

        //EVENTOS--------------------------------------------------------------------------------------------------------
        private void formUsuarios_Load(object sender, EventArgs e)
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
            UsuarioDesktop usuarioDesktop = new UsuarioDesktop(ModoForm.Alta);
            usuarioDesktop.ShowDialog();
            this.Listar();
        }


        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop ud = new UsuarioDesktop(id, ModoForm.Modificacion);
                ud.ShowDialog();
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
                int id = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop ud = new UsuarioDesktop(id, ModoForm.Baja);
                ud.ShowDialog();
                this.Listar();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Debe seleccionar una fila a eliminar");
            }
        }
    }
}
