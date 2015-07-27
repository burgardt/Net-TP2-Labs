using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    class ModuloAdapter:Adapter
    {
        public List<Modulo> GetAll()
        {
            List<Modulo> modulos = new List<Modulo>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulos = new SqlCommand("SELECT * FROM modulos", SqlConn);
                SqlDataReader drModulos = cmdModulos.ExecuteReader();
                while (drModulos.Read())
                {
                    Modulo modulo = new Modulo();
                    modulo.ID = (int)drModulos["id_modulo"];
                    modulo.Descripcion = (string)drModulos["desc_modulo"];
                    modulos.Add(modulo);
                }
                drModulos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de modulos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulos;
        }


        public Modulo GetOne(int ID)
        {
            Modulo modulo = new Modulo();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulos = new SqlCommand("SELECT * FROM modulos WHERE id_modulo=@id", SqlConn);
                cmdModulos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModulos = cmdModulos.ExecuteReader();
                if (drModulos.Read())
                {
                    modulo.ID = (int)drModulos["id_modulo"];
                    modulo.Descripcion = (string)drModulos["desc_modulo"];
                }
                drModulos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulo;
        }


        protected void Update(Modulo modulo)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE modulos SET desc_modulo=@desc_modulo" +
                    "WHERE id_modulo=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = modulo.ID;
                cmdUpdate.Parameters.Add("@desc_modulo", SqlDbType.VarChar, 50).Value = modulo.Descripcion;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar datos de modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void insert(Modulo modulo)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO modulos(desc_modulo) " +
                    "VALUES(@desc_modulo) SELECT @@identity", SqlConn);
                cmdInsert.Parameters.Add("@id_materia", SqlDbType.VarChar,50).Value = modulo.Descripcion;
                modulo.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear modulo", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM modulos WHERE id_modulo=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Modulo modulo)
        {
            if (modulo.State == BusinessEntity.States.Deleted)
                this.Delete(modulo.ID);
            else if (modulo.State == BusinessEntity.States.Modified)
                this.Update(modulo);
            else if (modulo.State == BusinessEntity.States.New)
                this.insert(modulo);
            modulo.State = BusinessEntity.States.Unmodified;
        }
    }
}
