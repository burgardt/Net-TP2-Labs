using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic:BusinessLogic
    {
        UsuarioAdapter _usuarioData;

        public UsuarioAdapter UsuarioData
        {
            get { return _usuarioData; }
            set { _usuarioData = value; }
        }

         public UsuarioLogic()
        {
             UsuarioData = new UsuarioAdapter();
        }
        
        //---------------------------------------------------------------------------------------------------------------
         public Usuario GetOne(int id)
         {
             // ¿Mas simple? return UsuarioData.GetOne(id);

             Usuario usuario = new Usuario();
             usuario = UsuarioData.GetOne(id);
             return usuario;
         }

        //---------------------------------------------------------------------------------------------------------------
         public List<Usuario> GetAll()
         {

             // ¿Mas simple? return UsuarioData.GetAll();

            List<Usuario> lista = new List<Usuario>();
            lista = UsuarioData.GetAll();
            return lista;
          
         }

        //---------------------------------------------------------------------------------------------------------------
         public void Save(Usuario usuario)
         {
             UsuarioData.Save(usuario);
         }

        //---------------------------------------------------------------------------------------------------------------
         public void Delete(int id)
         {
             UsuarioData.Delete(id);
         }
    }
}
