using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace PalcoNet.AbmCliente
{
    public class ClienteDAO : BaseDAO
    {

        public DataTable obtenerDatosCliente(decimal idCliente) {
            var dict = new Dictionary<string, object>();
            dict.Add("@clie_id", idCliente);
            return query("select clie_nombre, clie_apellido, clie_tipo_doc, "
                        +"clie_nro_doc, clie_cuil, clie_mail, clie_telefono, "
                        +"clie_direccion,clie_fecha_nac, clie_fecha_crea, clie_datos_tarjeta, clie_estado "
                        +"from pel.cliente where clie_id  = @clie_id", dict);
        }

        public DataTable obtenerClientes(string nombre, string apellido, string dni, string mail)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@nombre", nombre);
            dict.Add("@apellido", apellido);
            dict.Add("@dni", dni);
            dict.Add("@mail", mail);

            return query("select clie_id, clie_nombre, clie_apellido,clie_nro_doc, clie_mail, "
                + "clie_telefono, clie_fecha_nac, clie_direccion, clie_datos_tarjeta, clie_estado "
                + "from PEL.cliente "
                + "where clie_nombre like case when @nombre != '' then '%'+@nombre+'%' else clie_nombre end "
                + "and clie_apellido like case when @apellido != '' then '%'+@apellido+'%' else clie_apellido end "
                + "and clie_nro_doc = isnull(nullif(@dni,''),clie_nro_doc) " //match exacto
                + "and clie_mail like case when @mail != '' then '%'+@mail+'%' else clie_mail end "
                , dict);
        }


        public DataTable upsertDatosCliente(decimal idCliente, Dictionary<string, object> dict)
        {
            if (idCliente == -1) {
                return insertCliente(dict);
            } else {
                return updateCliente(idCliente, dict);
            }
        }

        private DataTable updateCliente(decimal idCliente, Dictionary<string, object> dict) {
            dict.Remove("username");
            dict.Remove("password");

            string queryStr = "update PEL.cliente set ";
            foreach (var entry in dict)
            {
                queryStr += entry.Key + " = @" + entry.Key + " ,";
            }
            queryStr = queryStr.TrimEnd(',');
            queryStr += "where clie_id = " + idCliente;

            Dictionary<string, object> queryParams = new Dictionary<string, object>();
            foreach (var item in dict)
            {
                queryParams.Add("@"+item.Key, item.Value);
            }

            return query(queryStr, queryParams);
        }

        private DataTable insertCliente(Dictionary<string, object> dict)
        {
            Dictionary<string, object> procParams = new Dictionary<string,object>();
            foreach (var item in dict) {
                procParams.Add(item.Key.Replace("clie_", "@"), item.Value);
            }
            procParams.Remove("@estado"); //el sp le mete alta

            return procedure("PEL.registrar_usuario_cliente", procParams);
        }

        public decimal obtenerCliente(decimal usuario)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@usua_id", usuario);
            DataTable result = query("select clie_id "
                        + "from pel.cliente join pel.usuario on clie_usuario = usua_id where usua_id = @usua_id", dict);
            return Convert.ToDecimal(result.Rows[0][0]);

        }
    }
}