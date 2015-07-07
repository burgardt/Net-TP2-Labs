using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Usuario
    {
        private string _NombreUsuario, _Clave, _Nombre, _Apellido, _Email;
        private bool _Habilitado;

        private string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }

        private string Clave
        {
            get { return _Clave; }
            set { _Clave= value; }
        }

        private string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        private string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }
    }
}
