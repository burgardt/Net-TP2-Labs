using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM especialidades", SqlConn);
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                while (drEspecialidades.Read())
                {
                    Especialidad especialidad = new Especialidad();
                    especialidad.ID = (int)drEspecialidades["id_especialidad"];
                    especialidad.Descripcion = (string)drEspecialidades["desc_especialidad"];
                    especialidades.Add(especialidad);
                }
                drEspecialidades.Close();
            }
            catch (Exception Ex)
            {
                //Exception ExcepcionManejada = new Exception("Error al recuperar lista de especialidades", Ex);
                //throw ExcepcionManejada;
                return null;
            }
            finally
            {
                this.CloseConnection();
            }
            return especialidades;
        }


        public Especialidad GetOne(int ID)
        {
            Especialidad especialidad = new Especialidad();
            try
            {
                this.OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM especialidades WHERE id_especialidad=@id", SqlConn);
                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                if (drEspecialidades.Read())
                {
                    especialidad.ID = (int)drEspecialidades["id_especialidad"];
                    especialidad.Descripcion = (string)drEspecialidades["desc_especialidad"];
                }
                drEspecialidades.Close();
            }
            catch (Exception Ex)
            {
                //Exception ExcepcionManejada = new Exception("Error al recuperar datos de especialidad", Ex);
                //throw ExcepcionManejada;
                return null;
            }
            finally
            {
                this.CloseConnection();
            }
            return especialidad;
        }


        protected void Update(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE especialidades SET"+
                    "desc_especialidad=@desc_especialidad WHERE id_especialidad=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.ID;
                cmdUpdate.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                //Exception ExcepcionManejada = new Exception("Error al actualizar datos de especialidad", Ex);
                //throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void insert(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO especialidades(desc_especialidad)" +
                    "VALUES(@desc_especialidad) SELECT @@identity", SqlConn);
                cmdInsert.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.Descripcion; 
                especialidad.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                //Exception ExcepcionManejada = new Exception("Error al crear especialidad", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM especialidades WHERE id_especialidad=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                //Exception ExcepcionManejada = new Exception("Error al eliminar especialidad", Ex);
                //throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == BusinessEntity.States.Deleted)
                this.Delete(especialidad.ID);
            else if (especialidad.State == BusinessEntity.States.Modified)
                this.Update(especialidad);
            else if (especialidad.State == BusinessEntity.States.New)
                this.insert(especialidad);
            especialidad.State = BusinessEntity.States.Unmodified;
        }
    }
}
