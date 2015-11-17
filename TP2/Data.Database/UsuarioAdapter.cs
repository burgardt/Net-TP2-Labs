using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
        public List<Usuario> GetAll()
        // obtiene todas las filas de usuario que se mostraran en la grilla del form usuario
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios", SqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.IdPersona = (int)drUsuarios["id_persona"];

                    usuarios.Add(usr);
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                //Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                //throw ExcepcionManejada;
                return null;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }


        public Usuario GetOne(int ID)
        // recibe un int que representa el id del usuario y devuelve la instancia de usuario correspondiente a ese id 
        {
            Usuario usr = new Usuario();
            
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios WHERE id_usuario=@id",SqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.IdPersona = (int)drUsuarios["id_persona"];
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                //Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
                //throw ExcepcionManejada;
                return null;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }


        protected void Update(Usuario usuario)
        {
            try 
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE usuarios SET nombre_usuario=@nombre_usuario, clave=@clave,"+
                "habilitado=@habilitado, nombre=@nombre, apellido=@apellido, email=@email WHERE id_usuario=@id",SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdUpdate.Parameters.Add("@nombre_usuario", SqlDbType.VarChar,50).Value = usuario.NombreUsuario;
                cmdUpdate.Parameters.Add("@clave", SqlDbType.VarChar,50).Value = usuario.Clave;
                cmdUpdate.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdUpdate.Parameters.Add("@nombre", SqlDbType.VarChar,50).Value = usuario.Nombre;
                cmdUpdate.Parameters.Add("@apellido", SqlDbType.VarChar,50).Value = usuario.Apellido;
                cmdUpdate.Parameters.Add("@email", SqlDbType.VarChar,50).Value = usuario.Email;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                //Exception ExcepcionManejada = new Exception("Error al actualizar datos de usuario", Ex);
                //throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        } 


        protected void insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert= new SqlCommand("INSERT INTO usuarios(nombre_usuario, clave, habilitado, "+
                    "nombre, apellido, email, id_persona) VALUES(@nombre_usuario, @clave, @habilitado, @nombre, @apellido, "+
                    "@email, @id_persona) SELECT @@identity", SqlConn);
                cmdInsert.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdInsert.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdInsert.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdInsert.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPersona;
                usuario.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar()); 
            }
            catch (Exception Ex)
            {
                //Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                //throw ExcepcionManejada;
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
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM usuarios WHERE id_usuario=@id",SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {
                //Exception ExcepcionManejada = new Exception("Error al eliminar usuario", Ex);
                //throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.Deleted)
                this.Delete(usuario.ID);
            else if (usuario.State == BusinessEntity.States.Modified)
                this.Update(usuario);
            else if (usuario.State == BusinessEntity.States.New)
                this.insert(usuario);
            usuario.State = BusinessEntity.States.Unmodified;
        }
    }
}
