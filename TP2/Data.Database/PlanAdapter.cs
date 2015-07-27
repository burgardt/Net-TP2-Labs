using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM planes", SqlConn);
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan plan = new Plan();
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                    planes.Add(plan);
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return planes;
        }


        public Plan GetOne(int ID)
        {
            Plan plan = new Plan();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM planes WHERE id_plan= @id", SqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                if (drPlanes.Read())
                {
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return plan;
        }


        protected void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE planes SET" +
                    "desc_plan= @desc_plan, id_especialidad= @id_especialidad WHERE id_plan=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdUpdate.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdUpdate.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar datos de plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO planes(desc_plan, id_especialidad) " +
                    "VALUES(@desc_plan, @id_especialidad) SELECT @@identity", SqlConn);
                cmdInsert.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdInsert.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                plan.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear plan", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM planes WHERE id_plan=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.Deleted)
                this.Delete(plan.ID);
            else if (plan.State == BusinessEntity.States.Modified)
                this.Update(plan);
            else if (plan.State == BusinessEntity.States.New)
                this.insert(plan);
            plan.State = BusinessEntity.States.Unmodified;
        }
    }
}
