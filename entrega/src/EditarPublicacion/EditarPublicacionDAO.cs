using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet.EditarPublicacion
{
    class EditarPublicacionDAO : BaseDAO
    {
        internal void updatePublicacion(decimal idPublicacion, Dictionary<string, object> dict)
        {
            string queryStr = "update PEL.publicacion set ";
            foreach (var entry in dict)
            {
                queryStr += entry.Key + " = @" + entry.Key + " ,";
            }
            queryStr = queryStr.TrimEnd(',');
            queryStr += "where publ_id = " + idPublicacion;

            Dictionary<string, object> queryParams = new Dictionary<string, object>();
            foreach (var item in dict)
            {
                queryParams.Add("@" + item.Key, item.Value);
            }

            query(queryStr, queryParams);

        }

        public DataTable obtenerEstados(decimal estado) 
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@estado", estado);
            return query("select esta_id, esta_descripcion from pel.estado_publicacion where esta_id > @estado", dict);
           
        }

        public DataTable obtenerRubros()
        {
            var dict = new Dictionary<string, object>();
            return query("select rubr_id, rubr_descripcion from pel.rubro", dict);

        }


        internal decimal obtenerEstado(decimal publ)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@publicacion", publ);
            decimal estado = Convert.ToDecimal(query("select publ_estado from pel.publicacion where publ_id = @publicacion", dict).Rows[0][0]);
            return estado;
        }
    }
}
