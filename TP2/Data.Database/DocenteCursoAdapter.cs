using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class DocenteCursoAdapter:Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docCursos = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocCursos = new SqlCommand("SELECT * FROM docentes_cursos", SqlConn);
                SqlDataReader drDocCursos = cmdDocCursos.ExecuteReader();
                while (drDocCursos.Read())
                {
                    DocenteCurso docCurso = new DocenteCurso();
                    docCurso.ID = (int)drDocCursos["id_dictado"];
                    docCurso.IDCurso = (int)drDocCursos["id_curso"];
                    docCurso.IDDocente = (int)drDocCursos["id_docente"];
                    //docCurso.TipoCargo = (int)drDocCursos["cargo"];
                    docCursos.Add(docCurso);
                }
                drDocCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de dictados", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docCursos;
        }


        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso docCurso = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocCursos = new SqlCommand("SELECT * FROM cursos WHERE id_dictado=@id", SqlConn);
                cmdDocCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocCursos = cmdDocCursos.ExecuteReader();
                if (drDocCursos.Read())
                {
                    docCurso.ID = (int)drDocCursos["id_dictado"];
                    docCurso.IDCurso = (int)drDocCursos["id_curso"];
                    docCurso.IDDocente = (int)drDocCursos["id_docente"];
                    //docCurso.TipoCargo = (int)drDocCursos["cargo"];
                }
                drDocCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de dictado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docCurso;
        }


        protected void Update(DocenteCurso docCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE docentes_cursos SET id_curso=@id_curso" +
                    "id_docente=@id_docente, cargo=@cargo WHERE id_dictado=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = docCurso.ID;
                cmdUpdate.Parameters.Add("@id_curso", SqlDbType.Int).Value = docCurso.IDCurso;
                cmdUpdate.Parameters.Add("@id_docente", SqlDbType.Int).Value = docCurso.IDDocente;
                //cmdUpdate.Parameters.Add("@cargo",SqlDbType.Int).Value=
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar datos de dictado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void insert(DocenteCurso docCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO docentes_cursos(id_curso, id_docente, " +
                    "cargo) VALUES(@id_curso, @id_docente, @cargo) SELECT @@identity", SqlConn);
                cmdInsert.Parameters.Add("@id_curso", SqlDbType.Int).Value = docCurso.IDCurso;
                cmdInsert.Parameters.Add("@id_docente", SqlDbType.Int).Value = docCurso.IDDocente;
                // cmdInsert.Parameters.Add("@cargo", SqlDbType.Int).Value = 
                docCurso.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear dictado", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM docentes_cursos WHERE id_dictado=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar dictado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(DocenteCurso docCurso)
        {
            if (docCurso.State == BusinessEntity.States.Deleted)
                this.Delete(docCurso.ID);
            else if (docCurso.State == BusinessEntity.States.Modified)
                this.Update(docCurso);
            else if (docCurso.State == BusinessEntity.States.New)
                this.insert(docCurso);
            docCurso.State = BusinessEntity.States.Unmodified;
        }
    }
}
