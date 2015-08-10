using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;
using Business.Entities;

namespace UI.Consola
{
    public class Usuarios
    {
        UsuarioLogic _usuarioNegocio;

        public UsuarioLogic UsuarioNegocio
        {
            get { return _usuarioNegocio; }
            set { _usuarioNegocio = value; }
        }

        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }

        public void menu()
        {
            Console.Write("Menu:\n1-Listado General\n2-Consulta\n3-Agregar\n4-Modificar\n5-Eliminar\n6-Salir");
            int rta = int.Parse(Console.ReadLine().ToString());
            switch (rta)
            {
                case 1:
                    ListadoGeneral();
                    break;
                case 2:
                    Consultar();
                    break;



            }
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }

        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.WriteLine();
        }

        public void Consultar()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el ID del usuario a consultar");
            int ID = int.Parse(Console.ReadLine());
            this.MostrarDatos(UsuarioNegocio.GetOne(ID));
        }

    }
}
