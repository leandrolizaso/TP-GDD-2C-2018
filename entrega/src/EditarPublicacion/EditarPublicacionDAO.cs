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

        public DataTable obtenerEstados() 
        {
            var dict = new Dictionary<string, object>();
            return query("select esta_id, esta_descripcion from pel.estado_publicacion", dict);
           
        }

        public DataTable obtenerRubros()
        {
            var dict = new Dictionary<string, object>();
            return query("select rubr_id, rubr_descripcion from pel.rubro", dict);

        }

      
    }
}
