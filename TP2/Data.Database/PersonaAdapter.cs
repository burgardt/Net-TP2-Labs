using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PersonaAdapter:Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas", SqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona persona = new Persona();
                    persona.ID = (int)drPersonas["id_persona"];
                    persona.Nombre = (string)drPersonas["nombre"];
                    persona.Apellido = (string)drPersonas["apellido"];
                    persona.Direccion = (string)drPersonas["direccion"];
                    persona.Email = (string)drPersonas["email"];
                    persona.Telefono = (string)drPersonas["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    persona.Legajo = (int)drPersonas["legajo"];
                    persona.TipoPersona = (int)drPersonas["tipo_persona"];
                    persona.IDPlan= (int)drPersonas["id_plan"];

                    personas.Add(persona);
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                //Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                //throw ExcepcionManejada;
                return null;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }


        public Persona GetOne(int ID) 
        {
            Persona persona = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas WHERE id_persona=@id", SqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                if (drPersonas.Read())
                {
                    persona.ID = (int)drPersonas["id_persona"];
                    persona.Nombre = (string)drPersonas["nombre"];
                    persona.Apellido = (string)drPersonas["apellido"];
                    persona.Direccion = (string)drPersonas["direccion"];
                    persona.Email = (string)drPersonas["email"];
                    persona.Telefono = (string)drPersonas["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    persona.Legajo = (int)drPersonas["legajo"];
                    persona.TipoPersona = (int)drPersonas["tipo_persona"];
                    persona.IDPlan = (int)drPersonas["id_plan"];
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                //Exception ExcepcionManejada = new Exception("Error al recuperar datos de persona", Ex);
                //throw ExcepcionManejada;
                return null;
            }
            finally
            {
                this.CloseConnection();
            }
            return persona;
        }


        protected void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE personas SET nombre=@nombre, apellido=@apellido," +
                "direccion=@direccion, email=@email, telefono=@telefono, fecha_nac=@fecha_nac, legajo=@legajo, "+
                "tipo_persona=@tipo_persona, id_plan=@id_plan WHERE id_persona=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdUpdate.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdUpdate.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdUpdate.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdUpdate.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdUpdate.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdUpdate.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdUpdate.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdUpdate.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdUpdate.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                //Exception ExcepcionManejada = new Exception("Error al actualizar datos de persona", Ex);
                //throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO personas(nombre, apellido, direccion, " +
                    "email, telefono, fecha_nac, legajo, tipo_persona, id_plan) VALUES(@nombre, @apellido, @direccion, @email, " +
                    "@telefono, @fecha_nac, @legajo, @tipo_persona, @id_plan) SELECT @@identity", SqlConn);
                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdInsert.Parameters.Add("@direccion", SqlDbType.NVarChar, 50).Value = persona.Direccion;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdInsert.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdInsert.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdInsert.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdInsert.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                persona.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                //Exception ExcepcionManejada = new Exception("Error al cargar persona", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM personas WHERE id_persona=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                //Exception ExcepcionManejada = new Exception("Error al eliminar persona", Ex);
                //throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.Deleted)
                this.Delete(persona.ID);
            else if (persona.State == BusinessEntity.States.Modified)
                this.Update(persona);
            else if (persona.State == BusinessEntity.States.New)
                this.insert(persona);
            persona.State = BusinessEntity.States.Unmodified;
        }
    }
}
