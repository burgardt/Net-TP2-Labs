using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class AlumnoInscripcion: BusinessEntity
    {
        private int _IDAlumno;
        private int _IDCurso;
        private string _Condicion;
        private int _Nota;

        public int IDAlumno
        {
            get { return _IDAlumno; }
            set { _IDAlumno = value; }
        }

        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }

        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }

        public int Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }
    }
}
