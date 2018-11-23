using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PalcoNet.Registro_de_Usuario {
    public class LoginDAO : BaseDAO{

        public Decimal esUsuarioActivo(string user, string pass) {
            var dict = new Dictionary<string,object>();
            dict.Add("@user", user);
            dict.Add("@pass", pass);

            SqlDataReader reader = runQuery("select usua_id from pel.usuario where usua_username = @user and usua_password = @pass", dict);

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