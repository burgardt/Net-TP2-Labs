using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class DocenteCursoLogic
    {
         //----------------------------------------------------------------------------------------------------
        DocenteCursoAdapter _docenteCursoData;

        public DocenteCursoAdapter DocenteCursoData
        {
            get { return _docenteCursoData; }
            set { _docenteCursoData = value; }
        }

         //---------------------------------------------------------------------------------------------------
         public DocenteCursoLogic()
         {
             DocenteCursoData = new DocenteCursoAdapter();
         }
        
        //-----------------------------------------------------------------------------------------------------
         public DocenteCurso GetOne(int id)
         {
             DocenteCurso docenteCurso = new DocenteCurso();
             docenteCurso = DocenteCursoData.GetOne(id);
             return docenteCurso;
         }

         
         public List<DocenteCurso> GetAll()
         {

            List<DocenteCurso> lista = new List<DocenteCurso>();
            lista = DocenteCursoData.GetAll();
            return lista;
          
         }

         
         public void Save(DocenteCurso docenteCurso)
         {
             DocenteCursoData.Save(docenteCurso);
         }


         public void Delete(int id)
         {
             DocenteCursoData.Delete(id);
         }
    }
}
