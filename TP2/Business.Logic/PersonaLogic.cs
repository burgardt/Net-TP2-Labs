using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic:BusinessLogic
    {
         //----------------------------------------------------------------------------------------------------
        PersonaAdapter _PersonaData;

        public PersonaAdapter PersonaData
        {
            get { return _PersonaData; }
            set { _PersonaData = value; }
        }

         //---------------------------------------------------------------------------------------------------
         public PersonaLogic()
         {
             PersonaData = new PersonaAdapter();
         }
        
        //-----------------------------------------------------------------------------------------------------
         public Persona GetOne(int id)
         {
             Persona persona = new Persona();
             persona = PersonaData.GetOne(id);
             return persona;
         }

         
         public List<Persona> GetAll()
         {

            List<Persona> lista = new List<Persona>();
            lista = PersonaData.GetAll();
            return lista;
          
         }

         
         public void Save(Persona persona)
         {
             PersonaData.Save(persona);
         }

         
         public void Delete(int id)
         {
             PersonaData.Delete(id);
         }
    }
}
