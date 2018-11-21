using PalcoNet.Utils;
using System.Data.SqlClient;

namespace PalcoNet.Registro_de_Usuario {
    public class LoginDAO : BaseDAO{

        public bool esUsuarioActivo(string user, string pass) {
            SqlDataReader reader = runQuery("select 1");
            reader.Dispose();
            return false;
        }

        
    }
}