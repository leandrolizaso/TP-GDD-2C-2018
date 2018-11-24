using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet.AbmRol
{
    public class RolDAO : BaseDAO
    {

        public DataTable obtenerListaRoles(Decimal idUsuario)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@user_id", idUsuario);

            return aDataTableOf(query("select rol_id, rol_nombre "
                                        + "from pel.rol_usuario "
                                        + "join pel.rol on rol_id = rol_usua_rol "
                                        + "where rol_usua_usua = 1 "
                                        + "and rol_estado = 'A'", 
                                        dict));
        }

        public DataTable obtenerListaFunciones(Decimal idRol) {
            var dict = new Dictionary<string, object>();
            dict.Add("@rol_id", idRol);

            return aDataTableOf(query("select func_id, func_nombre from pel.rol_funcion "
                                            +"join pel.funcion on func_id = rol_func_func "
                                            +"where rol_func_rol = @rol_id",
                                        dict));

          }

    }
}