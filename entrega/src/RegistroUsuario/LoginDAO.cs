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

            //PEL.validar_usuario(@username nvarchar(50),@password nvarchar(255),@usua_id numeric(18,0) output,@mensaje nvarchar(255)) 
            DataTable result = procedure("PEL.validar_usuario", dict);

            Decimal idUsuario = Convert.ToDecimal(result.Rows[0][0]);
            string mensaje = result.Rows[0][1].ToString();

            if (idUsuario == -1) {
                throw new ArgumentException(mensaje);
            }
            return idUsuario;
        }

        public void cambiarPass(decimal user, string password, bool esAdmin) 
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@usuario", user);
            dict.Add("@password", password);

            procedure("PEL.sp_cambiar_pass", dict);

            if (esAdmin) 
            { 
                dict = new Dictionary<string, object>();
                dict.Add("@usuario", user);
                query("update pel.usuario set usua_estado = 'R' where usua_id = @usuario",dict);
                
            }
        }

        public bool esPrimerIngreso(string user, string pass)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@username", user);
            dict.Add("@password", pass);
            DataTable result = procedure("PEL.validar_usuario", dict);

            return Convert.ToDecimal(result.Rows[0][0]) == -2;
            
        }

    }
}