using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet.Utils {
    public class BaseDAO {

        protected DataTable procedure(string procedureName, Dictionary<string, object> procParams) {
            return sqlCommand(procedureName, procParams, CommandType.StoredProcedure);
            
        }

        protected DataTable query(string query, Dictionary<string, object> queryParams) {
            return sqlCommand(query, queryParams, CommandType.Text);
        }

        private DataTable sqlCommand(string text, Dictionary<string, object> parameters, CommandType type) {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = type;
                cmd.Connection = Conexion.getConnection();
                cmd.CommandText = text;

                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    return aDataTableOf(reader);
                }
            }
        }
        
        protected DataTable aDataTableOf(SqlDataReader reader) {
            var dt = new DataTable();
            if (reader.HasRows) {
                dt.Load(reader);
            }
            return dt;
        }
    }
}