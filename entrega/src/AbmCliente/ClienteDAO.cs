using PalcoNet.Utils;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet.Abm_Cliente
{
    public class ClienteDAO : BaseDAO
    {

        public DataTable obtenerClientes(string nombre, string apellido, string dni, string mail)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@nombre", nombre);
            dict.Add("@apellido", apellido);
            dict.Add("@dni", dni);
            dict.Add("@mail", mail);

            SqlDataReader reader = runQuery("select clie_id, clie_nombre, clie_apellido,clie_nro_doc, "
                + "clie_mail, clie_telefono, clie_fecha_nac, clie_direccion, clie_datos_tarjeta "
                + "from PEL.cliente "
                + "where clie_nombre like case when @nombre != '' then '%'+@nombre+'%' else clie_nombre end "
                + "and clie_apellido like case when @apellido != '' then '%'+@apellido+'%' else clie_apellido end "
                + "and clie_nro_doc = isnull(nullif(@dni,''),clie_nro_doc) " //match exacto
                + "and clie_mail like case when @mail != '' then '%'+@mail+'%' else clie_mail end "
                , dict);

            var dt = new DataTable();

            if (reader.HasRows) {
                dt.Load(reader);
            }

            reader.Dispose();
            return dt;
        }

    }
}