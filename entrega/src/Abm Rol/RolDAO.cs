using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet.Abm_Rol
{
    public class RolDAO : BaseDAO
    {

        public DataTable obtenerListaRoles(Decimal idUsuario)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@user_id", idUsuario);

            SqlDataReader reader = runQuery("select rol_id, rol_nombre "
                                        + "from pel.rol_usuario "
                                        + "join pel.rol on rol_id = rol_usua_rol "
                                        + "where rol_usua_usua = 1 "
                                        + "and rol_estado = 'A'", 
                                        dict);

            var dt = new DataTable();

            if (reader.HasRows){
                dt.Load(reader);
            }

            reader.Dispose();
            return dt;
        }

    }
}