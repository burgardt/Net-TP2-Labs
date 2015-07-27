using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter:Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM cursos", SqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso curso = new Curso();
                    curso.ID = (int)drCursos["id_curso"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];
                    cursos.Add(curso);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }


        public Curso GetOne(int ID)
        {
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM cursos WHERE id_curso=@id", SqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                if (drCursos.Read())
                {
                    curso.ID = (int)drCursos["id_curso"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return curso;
        }


        protected void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE cursos SET id_materia=@id_materia" +
                    "id_comision=@id_comision, anio_calendario=@anio_calendario, cupo=@cupo " +
                    "WHERE id_curso=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdUpdate.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdUpdate.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdUpdate.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdUpdate.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar datos de curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO cursos(id_materia, id_comision, " +
                    "anio_calendario, cupo) VALUES(@id_materia, @id_comision, @anio_calendario, @cupo) " +
                    "SELECT @@identity", SqlConn);
                cmdInsert.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdInsert.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdInsert.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdInsert.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                curso.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear curso", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM cursos WHERE id_curso=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.Deleted)
                this.Delete(curso.ID);
            else if (curso.State == BusinessEntity.States.Modified)
                this.Update(curso);
            else if (curso.State == BusinessEntity.States.New)
                this.insert(curso);
            curso.State = BusinessEntity.States.Unmodified;
        }
    }
}
