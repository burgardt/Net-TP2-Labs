using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic:BusinessLogic
    {
        //----------------------------------------------------------------------------------------------------
        EspecialidadAdapter _especialidadData;

        public EspecialidadAdapter EspecialidadData
        {
            get { return _especialidadData; }
            set { _especialidadData = value; }
        }

         //---------------------------------------------------------------------------------------------------
         public EspecialidadLogic()
         {
             EspecialidadData = new EspecialidadAdapter();
         }
        
        //-----------------------------------------------------------------------------------------------------
         public Especialidad GetOne(int id)
         {
             Especialidad especialidad = new Especialidad();
             especialidad = EspecialidadData.GetOne(id);
             return especialidad;
         }

         
         public List<Especialidad> GetAll()
         {

             List<Especialidad> lista = new List<Especialidad>();
            lista = EspecialidadData.GetAll();
            return lista;
          
         }

         
         public void Save(Especialidad especialidad)
         {
             EspecialidadData.Save(especialidad);
         }

         
         public void Delete(int id)
         {
             EspecialidadData.Delete(id);
         }
    }
}
