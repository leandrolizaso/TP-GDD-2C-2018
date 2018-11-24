using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet.Utils {
    public class BaseDAO {

        protected DataTable procedure(string procedureName, Dictionary<string, object> procParams) {
            using (SqlCommand cmd = new SqlCommand()) {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Conexion.getConnection();
                cmd.CommandText = procedureName;

                foreach (var item in procParams)
                {
                    string[] key = item.Key.Split(' ');
                    string paramName = key[0];
                    string direction = "in";
                    int size = sizeof(int);

                    if(key.Length > 1){
                        direction = key[1];
                    }
                    if (key.Length > 2) {
                        size = Convert.ToInt16(key[2]);
                    } 

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = paramName;

                    switch (direction) {
                        case "in": 
                            param.Direction = ParameterDirection.Input;
                            param.Value = item.Value;
                            break;
                        case "out":
                            param.Direction = ParameterDirection.Output;
                            param.Size = size;
                            break;
                    }

                    cmd.Parameters.Add(param);
                }

                cmd.ExecuteNonQuery();
                return aDataTableOf(cmd.Parameters);
            }
            
        }

    

        protected DataTable query(string query, Dictionary<string, object> queryParams) {
            using(SqlCommand cmd = new SqlCommand()){
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Conexion.getConnection();
                cmd.CommandText = query;

                foreach (var item in queryParams) {
                    cmd.Parameters.AddWithValue(item.Key, item.Value);
                }

                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
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

        private DataTable aDataTableOf(SqlParameterCollection sqlParameterCollection) {
            var dt = new DataTable();

            foreach (SqlParameter param in sqlParameterCollection) {
                dt.Columns.Add(param.ParameterName);
            }
            
            var values = new object[sqlParameterCollection.Count];
            for (var i = 0; i < sqlParameterCollection.Count; i++) {
                values[i] = sqlParameterCollection[i].Value;
            }

            dt.Rows.Add(values);
            return dt;
        }
    }
}