using PalcoNet.Utils;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet.AbmCliente
{
    public class ClienteDAO : BaseDAO
    {

        public DataTable obtenerDatosCliente(decimal idCliente) {
            var dict = new Dictionary<string, object>();
            dict.Add("@clie_id", idCliente);
            return query("select clie_nombre, clie_apellido, clie_tipo_doc, "
                                    +"clie_nro_doc, clie_cuil, clie_mail, clie_telefono, "
                                    +"clie_direccion,clie_fecha_nac, clie_fecha_crea, clie_datos_tarjeta "
                                    +"from pel.cliente where clie_id  = @clie_id", dict);
        }

        public DataTable obtenerClientes(string nombre, string apellido, string dni, string mail)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@nombre", nombre);
            dict.Add("@apellido", apellido);
            dict.Add("@dni", dni);
            dict.Add("@mail", mail);

            return query("select clie_id, clie_nombre, clie_apellido,clie_nro_doc, "
                + "clie_mail, clie_telefono, clie_fecha_nac, clie_direccion, clie_datos_tarjeta "
                + "from PEL.cliente "
                + "where clie_nombre like case when @nombre != '' then '%'+@nombre+'%' else clie_nombre end "
                + "and clie_apellido like case when @apellido != '' then '%'+@apellido+'%' else clie_apellido end "
                + "and clie_nro_doc = isnull(nullif(@dni,''),clie_nro_doc) " //match exacto
                + "and clie_mail like case when @mail != '' then '%'+@mail+'%' else clie_mail end "
                , dict);
        }


        public void actualizarDatosCliente(decimal idCliente, Dictionary<string, object> dict)
        {
            var reader = query(updateClienteString(idCliente, dict), dict);
            reader.Dispose();
        }

        private string updateClienteString(decimal idCliente, Dictionary<string, object> dict) {
            string query = "update PEL.cliente set ";
            foreach (var entry in dict)
            {
                query += entry.Key+" = @"+entry.Key+" ,";
            }
            query = query.TrimEnd(',');
            query += "where clie_id = " + idCliente;
            return query;
        }
    }
}