using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet.RegistroUsuario {
    public class LoginDAO : BaseDAO{

        public Decimal esUsuarioActivo(string user, string pass) {
            var dict = new Dictionary<string,object>();
            dict.Add("@username", user);
            dict.Add("@password", pass);
            dict.Add("@usua_id out 18", 0);
            dict.Add("@mensaje out 255", "");

            //PEL.validar_usuario(@username nvarchar(50),@password nvarchar(255),@usua_id numeric(18,0) output,@mensaje nvarchar(255)) 
            DataTable result = procedure("PEL.validar_usuario", dict);

            Decimal idUsuario = (Decimal)result.Rows[0]["@usua_id"];
            string mensaje = result.Rows[0]["@mensaje"].ToString();

            if (idUsuario < 0) {
                throw new ArgumentException(mensaje);
            }
            return idUsuario;
        }

    }
}