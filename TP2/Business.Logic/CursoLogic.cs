using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class CursoLogic:BusinessLogic
    {
         //----------------------------------------------------------------------------------------------------
        CursoAdapter _cursoData;

        public CursoAdapter CursoData
        {
            get { return _cursoData; }
            set { _cursoData = value; }
        }

         //---------------------------------------------------------------------------------------------------
         public CursoLogic()
         {
             CursoData = new CursoAdapter();
         }
        
        //-----------------------------------------------------------------------------------------------------
         public Curso GetOne(int id)
         {
             Curso curso = new Curso();
             curso = CursoData.GetOne(id);
             return curso;
         }

         
         public List<Curso> GetAll()
         {

            List<Curso> lista = new List<Curso>();
            lista = CursoData.GetAll();
            return lista;
          
         }

         
         public void Save(Curso curso)
         {
             CursoData.Save(curso);
         }


         public void Delete(int id)
         {
             CursoData.Delete(id);
         }
    }
}
