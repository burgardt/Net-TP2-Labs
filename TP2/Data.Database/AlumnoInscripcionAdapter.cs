using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter: Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand("SELECT * FROM alumnos_inscripciones", SqlConn);
                SqlDataReader drAlumInscrip = cmdInscripciones.ExecuteReader();
                while (drAlumInscrip.Read())
                {
                    AlumnoInscripcion alumInscrip = new AlumnoInscripcion();
                    alumInscrip.ID = (int)drAlumInscrip["id_inscripcion"];                    
                    alumInscrip.IDAlumno=(int)drAlumInscrip["id_alumno"];
                    alumInscrip.IDCurso = (int)drAlumInscrip["id_curso"];
                    //alumInscrip.Condicion= (int)drAlumInscrip["condicion"];
                    alumInscrip.Nota = (int)drAlumInscrip["nota"];
                    inscripciones.Add(alumInscrip);
                }
                drAlumInscrip.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de alumnos inscriptos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripciones;
        }


        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion alumInscrip = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand("SELECT * FROM cursos WHERE id_inscripcion=@id", SqlConn);
                cmdInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumInscrip = cmdInscripciones.ExecuteReader();
                if (drAlumInscrip.Read())
                {
                    alumInscrip.ID = (int)drAlumInscrip["id_inscripcion"];
                    alumInscrip.IDAlumno = (int)drAlumInscrip["id_alumno"];
                    alumInscrip.IDCurso = (int)drAlumInscrip["id_curso"];
                    //alumInscrip.Condicion= (int)drAlumInscrip["condicion"];
                    alumInscrip.Nota = (int)drAlumInscrip["nota"];
                }
                drAlumInscrip.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de alumno inscripto", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumInscrip;
        }


        protected void Update(AlumnoInscripcion alumInscrip)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE alumnos_inscripciones SET id_alumno=@id_alumno" +
                    "id_curso=@id_curso, condicion=@condicion, nota=@nota WHERE id_inscripcion=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = alumInscrip.ID;
                cmdUpdate.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumInscrip.IDAlumno;
                cmdUpdate.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumInscrip.IDCurso;
                //cmdUpdate.Parameters.Add("@condicion", SqlDbType.VarChar).Value = alumInscrip.Condicion;
                cmdUpdate.Parameters.Add("@nota", SqlDbType.Int).Value = alumInscrip.Nota;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar datos de alumno inscripto", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void insert(AlumnoInscripcion alumInscrip)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO alumnos_inscripcion(id_alumno, id_curso, " +
                    "condicion, nota) VALUES(@id_alumno, @id_curso, @condicion, @nota) SELECT @@identity", SqlConn);
                cmdInsert.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumInscrip.IDAlumno;
                cmdInsert.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumInscrip.IDCurso;
                //cmdInsert.Parameters.Add("@condicion", SqlDbType.VarChar).Value = alumInscrip.Condicion;
                cmdInsert.Parameters.Add("@nota", SqlDbType.Int).Value = alumInscrip.Nota;
                alumInscrip.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear inscripcion de alumno", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM alumnos_inscripciones WHERE id_inscripcion=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar alumno inscripto", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(AlumnoInscripcion alumInscrip)
        {
            if (alumInscrip.State == BusinessEntity.States.Deleted)
                this.Delete(alumInscrip.ID);
            else if (alumInscrip.State == BusinessEntity.States.Modified)
                this.Update(alumInscrip);
            else if (alumInscrip.State == BusinessEntity.States.New)
                this.insert(alumInscrip);
            alumInscrip.State = BusinessEntity.States.Unmodified;
        }
    }
}
