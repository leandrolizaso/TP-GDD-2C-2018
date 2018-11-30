using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.EditarPublicacion
{
    class EditarPublicacionDAO
    {
        private string updatePublicacionString(decimal idPublicacion, Dictionary<string, object> dict)
        {
            string query = "update PEL.Publicacion set ";
            foreach (var entry in dict)
            {
                query += entry.Key + " = @" + entry.Key + " ,";
            }
            query = query.TrimEnd(',');
            query += "where publ_id = " + idPublicacion;
            return query;
        }
    }
}
