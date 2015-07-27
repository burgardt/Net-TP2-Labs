using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter:Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("SELECT * FROM comisiones", SqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                while (drComisiones.Read())
                {
                    Comision comision = new Comision();
                    comision.ID = (int)drComisiones["id_comision"];
                    comision.Descripcion = (string)drComisiones["desc_comision"];
                    comision.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    comision.IDPlan = (int)drComisiones["id_plan"];
                    comisiones.Add(comision);
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }


        public Comision GetOne(int ID)
        {
            Comision comision = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("SELECT * FROM comisiones WHERE id_comision=@id", SqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                if (drComisiones.Read())
                {
                    comision.ID = (int)drComisiones["id_comision"];
                    comision.Descripcion = (string)drComisiones["desc_materia"];
                    comision.AnioEspecialidad = (int)drComisiones["anio_comision"];
                    comision.IDPlan = (int)drComisiones["id_plan"];
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comision;
        }


        protected void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE comisiones SET desc_comision=@desc_comision," +
                    " id_plan=@id_plan WHERE id_comision=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmdUpdate.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdUpdate.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar datos de comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO comisiones(desc_comision, id_plan) "+
                    "VALUES(@desc_comision, @id_plan) SELECT @@identity", SqlConn);
                cmdInsert.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                comision.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear comision", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM comisiones WHERE id_comision=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.Deleted)
                this.Delete(comision.ID);
            else if (comision.State == BusinessEntity.States.Modified)
                this.Update(comision);
            else if (comision.State == BusinessEntity.States.New)
                this.insert(comision);
            comision.State = BusinessEntity.States.Unmodified;
        }
    }
}
