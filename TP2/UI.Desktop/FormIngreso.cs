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

namespace UI.Desktop
{
    public partial class FormIngreso : Form
    {
        public UsuarioLogic ul;

        public FormIngreso()
        {
            InitializeComponent();
            ul = new UsuarioLogic();
        }

        private void FormIngreso_Load(object sender, EventArgs e)
        {
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdUsuario.Text == "admin" && txtClave.Text == "admin")
                {
                    MessageBox.Show("Ha ingresado al sistema como administrador", "Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormAdmin fa = new FormAdmin();
                    fa.ShowDialog();
                    this.Close();
                }
                else
                {
                    Usuario usr = ul.GetOne(int.Parse(txtIdUsuario.Text));
                    if (usr.ID == int.Parse(txtIdUsuario.Text) && usr.Clave == txtClave.Text)
                    {
                        if (usr.Habilitado== true)
                        {
                            MessageBox.Show("Ha ingrsado con exito, bienvenido " + usr.NombreUsuario, "Login",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FormUsr fu = new FormUsr();
                            fu.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El usuario " + usr.NombreUsuario + " no se encuentra habilitado para ingresar al sistema", "Login",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Id de Usuario o clave incorrectos");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Id de usuario debe ser un número entero");
            }
        }
    }
}
