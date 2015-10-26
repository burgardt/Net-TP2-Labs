using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Usuario> Usuarios = new List<Usuario>();
            UsuarioLogic ul = new UsuarioLogic();
            Usuarios = ul.GetAll();

            foreach (Usuario usuario in Usuarios)
            {
                TableRow row = new TableRow();
                row.ID = usuario.ID.ToString();
                row.CssClass = "usuario";

                TableCell id = new TableCell();
                id.Text = usuario.ID.ToString();
                row.Cells.Add(id);

                TableCell apellidoYNombre = new TableCell();
                apellidoYNombre.Text = usuario.Apellido + ", " + usuario.Nombre;
                row.Cells.Add(apellidoYNombre);

                TableCell nombreUsuario = new TableCell();
                nombreUsuario.Text = usuario.NombreUsuario;
                row.Cells.Add(nombreUsuario);

                TableCell clave = new TableCell();
                clave.Text = usuario.Clave;
                row.Cells.Add(clave);

                TableCell habilitado = new TableCell();
                if (usuario.Habilitado)
                {
                    habilitado.Text = "Si";

                }
                else
                {
                    habilitado.Text = "No";
                }
                row.Cells.Add(habilitado);

                TableCell email = new TableCell();
                email.Text = usuario.Email;
                row.Cells.Add(email);


                tabUsuarios.Rows.Add(row);
            }
        }
    }
}