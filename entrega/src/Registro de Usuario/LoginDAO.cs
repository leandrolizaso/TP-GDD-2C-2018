using PalcoNet.Utils;
using System;
using System.Data.SqlClient;

namespace PalcoNet.Registro_de_Usuario {
    public class LoginDAO : BaseDAO{

        public Decimal esUsuarioActivo(string user, string pass) {
            SqlDataReader reader = runQuery("select usua_id from pel.usuario where usua_username = '"+user+"'");

            Decimal idUsuario = -1;

            if (reader.HasRows) {
                reader.Read();
                idUsuario = reader.GetDecimal(0);
            }

            reader.Dispose();
            return idUsuario;
        }

    }
}