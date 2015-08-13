using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class MateriaLogic:BusinessLogic
    {
         //----------------------------------------------------------------------------------------------------
        MateriaAdapter _materiaData;

        public MateriaAdapter MateriaData
        {
            get { return _materiaData; }
            set { _materiaData = value; }
        }

         //---------------------------------------------------------------------------------------------------
         public MateriaLogic()
         {
             MateriaData = new MateriaAdapter();
         }
        
        //-----------------------------------------------------------------------------------------------------
         public Materia GetOne(int id)
         {
             Materia materia = new Materia();
             materia = MateriaData.GetOne(id);
             return materia;
         }

         
         public List<Materia> GetAll()
         {

            List<Materia> lista = new List<Materia>();
            lista = MateriaData.GetAll();
            return lista;
          
         }

         
         public void Save(Materia materia)
         {
             MateriaData.Save(materia);
         }


         public void Delete(int id)
         {
             MateriaData.Delete(id);
         }
    }
}
