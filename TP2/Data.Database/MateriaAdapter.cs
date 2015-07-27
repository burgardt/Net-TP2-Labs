using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class MateriaAdapter:Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias", SqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia materia = new Materia();
                    materia.ID = (int)drMaterias["id_materia"];
                    materia.Descripcion = (string)drMaterias["desc_materia"];
                    materia.HSSemanales = (int)drMaterias["hs_semanales"];
                    materia.HSTotales = (int)drMaterias["hs_totales"];
                    materia.IDPlan = (int)drMaterias["id_plan"];
                    materias.Add(materia);
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }


        public Materia GetOne(int ID)
        {
            Materia materia = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias WHERE id_materia=@id", SqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                if (drMaterias.Read())
                {
                    materia.ID = (int)drMaterias["id_materia"];
                    materia.Descripcion = (string)drMaterias["desc_materia"];
                    materia.HSSemanales = (int)drMaterias["hs_semanales"];
                    materia.HSTotales = (int)drMaterias["hs_totales"];
                    materia.IDPlan = (int)drMaterias["id_plan"];
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materia;
        }


        protected void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE materias SET desc_materia=@desc_materia," +
                    "hs_semanales=@hs_semanales, hs_totales=@hs_totales, id_plan=@id_plan " +
                    "WHERE id_materia=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdUpdate.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdUpdate.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmdUpdate.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HSTotales;
                cmdUpdate.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IDPlan; 
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar datos de materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO materias(desc_materia, hs_semanales, " +
                    "hs_totales, id_plan) VALUES(@desc_materia, @hs_semanales, @hs_totales, @id_plan) " +
                    "SELECT @@identity", SqlConn);
                cmdInsert.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdInsert.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmdInsert.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HSTotales;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IDPlan;
                materia.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear materia", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM materias WHERE id_materia=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.Deleted)
                this.Delete(materia.ID);
            else if (materia.State == BusinessEntity.States.Modified)
                this.Update(materia);
            else if (materia.State == BusinessEntity.States.New)
                this.insert(materia);
            materia.State = BusinessEntity.States.Unmodified;
        }
    }
}
