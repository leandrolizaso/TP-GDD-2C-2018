using System;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet.Utils {
    public static class Conexion {
        public static SqlConnection conn = null;

        public static SqlConnection getConnection() {
            if (conn == null || conn.State == ConnectionState.Closed)
            {
                String strConn = Globales.getUrlDB();
                conn = new SqlConnection();
                conn.ConnectionString = strConn;
                conn.Open();
            }
            return conn;
        }

    }
}