using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet.AbmEmpresa
{
    public class EmpresaDAO : BaseDAO
    {

        public DataTable obtenerDatosEmpresa(decimal idEmpresa) {
            var dict = new Dictionary<string, object>();
            dict.Add("@empr_id", idEmpresa);
            return query("select empr_razon_social, empr_mail, empr_telefono, "
                        +"empr_fecha, empr_direccion, empr_ciudad, empr_codigo_postal, empr_cuit, empr_estado "
                        +"from pel.empresa where empr_id = @empr_id", dict);

        }

        public DataTable obtenerEmpresas(string razon, string cuit, string mail)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@razon", razon);
            dict.Add("@cuit", cuit);
            dict.Add("@mail", mail);

            return query("select empr_id, empr_razon_social,empr_mail,empr_telefono,"
                        + "empr_direccion, empr_ciudad, empr_codigo_postal, empr_cuit, empr_fecha, empr_estado "
                        +"from pel.empresa "
                        + "where empr_razon_social like case when @razon != '' then '%'+@razon+'%' else empr_razon_social end "
                        + "and empr_cuit = isnull(nullif(@cuit,''),empr_cuit) " //match exacto
                        + "and empr_mail like case when @mail != '' then '%'+@mail+'%' else empr_mail end "
                        , dict);
        }


        public DataTable upsertDatosEmpresa(decimal idEmpresa, Dictionary<string, object> dict)
        {
            if (idEmpresa == -1) {
                return insertEmpresa(dict);
            } else {
                return updateEmpresa(idEmpresa, dict);
            }
        }

        private DataTable updateEmpresa(decimal idEmpresa, Dictionary<string, object> dict) {
            dict.Remove("username");
            dict.Remove("password");

            string queryStr = "update PEL.empresa set ";
            foreach (var entry in dict)
            {
                queryStr += entry.Key + " = @" + entry.Key + " ,";
            }
            queryStr = queryStr.TrimEnd(',');
            queryStr += "where empr_id = " + idEmpresa;

            Dictionary<string, object> queryParams = new Dictionary<string, object>();
            foreach (var item in dict)
            {
                queryParams.Add("@" + item.Key, item.Value);
            }

            return query(queryStr, queryParams);

        }

        private DataTable insertEmpresa(Dictionary<string, object> dict)
        {
            Dictionary<string, object> procParams = new Dictionary<string, object>();
            foreach (var item in dict)
            {
                procParams.Add("@"+item.Key.Replace("empr_", ""), item.Value);
            }
            procParams.Remove("@estado"); //el sp le mete alta

            return procedure("PEL.registrar_usuario_empresa", procParams);
        }

        public decimal obtenerEmpresa(decimal usuario)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@usua_id", usuario);
            DataTable result = query("select empr_id "
                        + "from pel.empresa join pel.usuario on empr_usuario = usua_id where usua_id = @usua_id", dict);
            return Convert.ToDecimal(result.Rows[0][0]);

        }
    }
}