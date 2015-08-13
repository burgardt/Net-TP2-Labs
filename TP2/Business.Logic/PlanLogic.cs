using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class PlanLogic: BusinessLogic
    {
        PlanAdapter _planData;

        public PlanAdapter PlanData
        {
            get { return _planData; }
            set { _planData = value; }
        }

         public PlanLogic()
        {
             PlanData = new PlanAdapter();
        }
        
        //---------------------------------------------------------------------------------------------------------------
         public Plan GetOne(int id)
         {
             Plan plan = new Plan();
             plan = PlanData.GetOne(id);
             return plan;
         }

        //---------------------------------------------------------------------------------------------------------------
         public List<Plan> GetAll()
         {
          
            List<Plan> lista = new List<Plan>();
            lista = PlanData.GetAll();
            return lista;
         }

        //---------------------------------------------------------------------------------------------------------------
         public void Save(Plan plan)
         {
             PlanData.Save(plan);
         }

        //---------------------------------------------------------------------------------------------------------------
         public void Delete(int id)
         {
             PlanData.Delete(id);
         }
    }
}
