using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");
        const string consKeyDefaultConnString = "ConnStringLocal";

        private SqlConnection _SqlConn;

        public SqlConnection SqlConn
        {
            set { _SqlConn = value; }
            get { return _SqlConn; }
        }

        protected void OpenConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings[consKeyDefaultConnString].ConnectionString;
            SqlConn = new SqlConnection(cs);
            SqlConn.Open();

        }

        protected void CloseConnection()
        {
            this.SqlConn.Close();
            SqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
