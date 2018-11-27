using PalcoNet.Utils;
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
                        +"empr_direccion,empr_cuit, empr_estado "
                        +"from pel.empresa where empr_id = @empr_id", dict);

        }

        public DataTable obtenerEmpresas(string razon, string cuit, string mail)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@razon", razon);
            dict.Add("@cuit", cuit);
            dict.Add("@mail", mail);

            return query("select empr_id, empr_razon_social,empr_mail,"
                        +"empr_telefono,empr_direccion,empr_cuit, empr_estado "
                        +"from pel.empresa "
                        + "where empr_razon_social like case when @razon != '' then '%'+@razon+'%' else empr_razon_social end "
                        + "and empr_cuit = isnull(nullif(@cuit,''),empr_cuit) " //match exacto
                        + "and empr_mail like case when @mail != '' then '%'+@mail+'%' else empr_mail end "
                        , dict);
        }


        public void upsertDatosEmpresa(decimal idEmpresa, Dictionary<string, object> dict)
        {
            string queryStr;
            if (idEmpresa == -1) {
                queryStr = insertEmpresaString(dict);
            } else {
                queryStr = updateEmpresaString(idEmpresa, dict);
            }
            //System.Diagnostics.Debug.WriteLine(queryStr);
            var reader = query(queryStr, dict);
            reader.Dispose();
        }

        private string updateEmpresaString(decimal idEmpresa, Dictionary<string, object> dict) {
            string query = "update PEL.Empresa set ";
            foreach (var entry in dict)
            {
                query += entry.Key+" = @"+entry.Key+" ,";
            }
            query = query.TrimEnd(',');
            query += "where empr_id = " + idEmpresa;
            return query;
        }

        private string insertEmpresaString(Dictionary<string, object> dict)
        {
            string query = "insert PEL.Empresa (";
            foreach (var entry in dict)
            {
                query += entry.Key + " ,";
            }
            query = query.TrimEnd(',');
            query += ") values (";
            foreach (var entry in dict)
            {
                query += "@"+entry.Key + " ,";
            }
            query = query.TrimEnd(',');
            query += ")";
            return query;
        }
    }
}