using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    class ModuloUsuarioAdapter:Adapter
    {
        public List<ModuloUsuario> GetAll()
        {
            List<ModuloUsuario> modUsrs = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModUsrs = new SqlCommand("SELECT * FROM modulos_usuarios", SqlConn);
                SqlDataReader drModUsrs = cmdModUsrs.ExecuteReader();
                while (drModUsrs.Read())
                {
                    ModuloUsuario modUsr = new ModuloUsuario();
                    modUsr.ID = (int)drModUsrs["id_modulo_usuario"];
                    modUsr.IdModulo = (int)drModUsrs["id_modulo"];
                    modUsr.IdUsuario = (int)drModUsrs["id_usuario"];
                    modUsr.PermiteAlta = (bool)drModUsrs["alta"];
                    modUsr.PermiteBaja = (bool)drModUsrs["baja"];
                    modUsr.PermiteConsulta = (bool)drModUsrs["consulta"];
                    modUsr.PermiteModificacion = (bool)drModUsrs["modificacion"];
                    modUsrs.Add(modUsr);
                }
                drModUsrs.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de modulos-usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modUsrs;
        }


        public ModuloUsuario GetOne(int ID)
        {
            ModuloUsuario modUsr = new ModuloUsuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModUsrs = new SqlCommand("SELECT * FROM modulos_usuarios WHERE id_modulo_usuario=@id", SqlConn);
                cmdModUsrs.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModUsrs = cmdModUsrs.ExecuteReader();
                if (drModUsrs.Read())
                {
                    modUsr.ID = (int)drModUsrs["id_modulo_usuario"];
                    modUsr.IdModulo = (int)drModUsrs["id_modulo"];
                    modUsr.IdUsuario = (int)drModUsrs["id_usuario"];
                    modUsr.PermiteAlta = (bool)drModUsrs["alta"];
                    modUsr.PermiteBaja = (bool)drModUsrs["baja"];
                    modUsr.PermiteConsulta = (bool)drModUsrs["consulta"];
                    modUsr.PermiteModificacion = (bool)drModUsrs["modificacion"];
                }
                drModUsrs.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de modulos-usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modUsr;
        }


        protected void Update(ModuloUsuario modUsr)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE modulos_usuarios SET id_modulo=@id_modulo," +
                    "id_usuario=@id_usuario, alta=@alta, baja=@baja, modificacion=@modificacion, consulta=@consulta " +
                    "WHERE id_modulo_usuario=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = modUsr.ID;
                cmdUpdate.Parameters.Add("@id_modulo", SqlDbType.Int).Value = modUsr.IdModulo;
                cmdUpdate.Parameters.Add("@id_usuario", SqlDbType.Int).Value = modUsr.IdUsuario;
                cmdUpdate.Parameters.Add("@alta", SqlDbType.Bit).Value = modUsr.PermiteAlta;
                cmdUpdate.Parameters.Add("@baja", SqlDbType.Bit).Value = modUsr.PermiteBaja;
                cmdUpdate.Parameters.Add("@modificacion", SqlDbType.Bit).Value = modUsr.PermiteModificacion;
                cmdUpdate.Parameters.Add("@consulta", SqlDbType.Bit).Value = modUsr.PermiteConsulta;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar datos de modulos-usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void insert(ModuloUsuario modUsr)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO modulos_usuarios(id_modulo, id_usuario, " +
                    "alta, baja, modificacion, consulta) VALUES(@id_modulo, @id_usuario, @alta, @baja, @modificacion,"+
                    " @consulta) SELECT @@identity", SqlConn);
                cmdInsert.Parameters.Add("@id_modulo", SqlDbType.Int).Value = modUsr.IdModulo;
                cmdInsert.Parameters.Add("@id_usuario", SqlDbType.Int).Value = modUsr.IdUsuario;
                cmdInsert.Parameters.Add("@alta", SqlDbType.Bit).Value = modUsr.PermiteAlta;
                cmdInsert.Parameters.Add("@baja", SqlDbType.Bit).Value = modUsr.PermiteBaja;
                cmdInsert.Parameters.Add("@modificacion", SqlDbType.Bit).Value = modUsr.PermiteModificacion;
                cmdInsert.Parameters.Add("@consulta", SqlDbType.Bit).Value = modUsr.PermiteConsulta;
                modUsr.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear modulos-usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM modulos_usuarios WHERE id_modulo_usuario=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar modulo-usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(ModuloUsuario modUsr)
        {
            if (modUsr.State == BusinessEntity.States.Deleted)
                this.Delete(modUsr.ID);
            else if (modUsr.State == BusinessEntity.States.Modified)
                this.Update(modUsr);
            else if (modUsr.State == BusinessEntity.States.New)
                this.insert(modUsr);
            modUsr.State = BusinessEntity.States.Unmodified;
        }
    }
}
