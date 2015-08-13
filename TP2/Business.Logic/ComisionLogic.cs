using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic:BusinessLogic
    {
         //----------------------------------------------------------------------------------------------------
        ComisionAdapter _comisionData;

        public ComisionAdapter ComisionData
        {
            get { return _comisionData; }
            set { _comisionData = value; }
        }

         //---------------------------------------------------------------------------------------------------
         public ComisionLogic()
         {
             ComisionData = new ComisionAdapter();
         }
        
        //-----------------------------------------------------------------------------------------------------
         public Comision GetOne(int id)
         {
             Comision comision = new Comision();
             comision = ComisionData.GetOne(id);
             return comision;
         }

         
         public List<Comision> GetAll()
         {

            List<Comision> lista = new List<Comision>();
            lista = ComisionData.GetAll();
            return lista;
          
         }

         
         public void Save(Comision comision)
         {
             ComisionData.Save(comision);
         }


         public void Delete(int id)
         {
             ComisionData.Delete(id);
         }
    }
}
