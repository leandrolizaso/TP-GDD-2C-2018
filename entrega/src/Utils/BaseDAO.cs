using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet.Utils {
    public class BaseDAO { 

        public SqlDataReader runQuery(string query, Dictionary<string,object> queryParams){
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Conexion.getConnection();

            foreach (var item in queryParams) {
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            }

            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

    }
}