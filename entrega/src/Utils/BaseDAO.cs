using System.Data;
using System.Data.SqlClient;

namespace PalcoNet.Utils {
    public class BaseDAO { 

        public SqlDataReader runQuery(string query){
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Conexion.getConnection();

            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

    }
}