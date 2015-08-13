using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class AlumnoInscripcionLogic:BusinessLogic
    {
        //----------------------------------------------------------------------------------------------------
        AlumnoInscripcionAdapter _alumInscripData;

        public AlumnoInscripcionAdapter AlumInscripData
        {
            get { return _alumInscripData; }
            set { _alumInscripData = value; }
        }

         //---------------------------------------------------------------------------------------------------
         public AlumnoInscripcionLogic()
         {
             AlumInscripData = new AlumnoInscripcionAdapter();
         }
        
        //-----------------------------------------------------------------------------------------------------
         public AlumnoInscripcion GetOne(int id)
         {
             AlumnoInscripcion alumInscrip = new AlumnoInscripcion();
             alumInscrip = AlumInscripData.GetOne(id);
             return alumInscrip;
         }

         
         public List<AlumnoInscripcion> GetAll()
         {

            List<AlumnoInscripcion> lista = new List<AlumnoInscripcion>();
            lista = AlumInscripData.GetAll();
            return lista;
          
         }

         
         public void Save(AlumnoInscripcion alumInscrip)
         {
             AlumInscripData.Save(alumInscrip);
         }


         public void Delete(int id)
         {
             AlumInscripData.Delete(id);
         }
    }
}
