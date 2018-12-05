using PalcoNet.Utils;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet.AbmGrado
{
    public class GradoDAO : BaseDAO
    {

        public DataTable obtenerAllGrados()
        {
            var dict = new Dictionary<string, object>();
            return query("select grad_descripcion, grad_id " + "from pel.grado where grad_estado = 'A'", dict);
        }

        public DataTable obtenerDatosGrado(decimal idGrado)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@grad_id", idGrado);
            return query("select grad_descripcion, grad_porcentaje, grad_estado "
                        +"from pel.grado where grad_id = @grad_id", dict);
        }

        public DataTable obtenerGrado(string nombre, string pcnt_from, string pcnt_to)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@nombre", nombre);
            dict.Add("@pcnt_from", pcnt_from);
            dict.Add("@pcnt_to", pcnt_to);

            return query("select grad_id, grad_descripcion, grad_porcentaje, grad_estado "
                        + "from pel.grado "
                        + "where grad_descripcion like case when @nombre != '' then '%'+@nombre+'%' else grad_descripcion end "
                        + "and grad_porcentaje >= isnull(nullif(@pcnt_from,''), grad_porcentaje) "
                        + "and grad_porcentaje <= isnull(nullif(@pcnt_to,''), grad_porcentaje) "
                        , dict);
        }

        public void upsertDatosGrado(decimal idGrado, Dictionary<string, object> dict)
        {
            string queryStr;
            if (idGrado == -1)
            {
                queryStr = insertGradoString(dict);
            }
            else
            {
                queryStr = updateGradoString(idGrado, dict);
            }
            var reader = query(queryStr, dict);
            reader.Dispose();
        }

        private string updateGradoString(decimal idGrado, Dictionary<string, object> dict)
        {
            string query = "update PEL.grado set ";
            foreach (var entry in dict)
            {
                query += entry.Key + " = @" + entry.Key + " ,";
            }
            query = query.TrimEnd(',');
            query += "where grad_id = " + idGrado;
            return query;
        }

        private string insertGradoString(Dictionary<string, object> dict)
        {
            string query = "insert PEL.grado (";
            foreach (var entry in dict)
            {
                query += entry.Key + " ,";
            }
            query = query.TrimEnd(',');
            query += ") values (";
            foreach (var entry in dict)
            {
                query += "@" + entry.Key + " ,";
            }
            query = query.TrimEnd(',');
            query += ")";
            return query;
        }
    }
}