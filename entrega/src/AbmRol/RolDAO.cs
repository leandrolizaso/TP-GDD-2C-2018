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

            return query("select rol_id, rol_nombre "
                                        + "from pel.rol_usuario "
                                        + "join pel.rol on rol_id = rol_usua_rol "
                                        + "where rol_usua_usua = @user_id "
                                        + "and rol_estado = 'A'", 
                                        dict);
        }

        public DataTable obtenerListaFunciones(Decimal idRol) {
            var dict = new Dictionary<string, object>();
            dict.Add("@rol_id", idRol);

            return query("select func_id, func_nombre from pel.rol_funcion "
                                            +"join pel.funcion on func_id = rol_func_func "
                                            +"where rol_func_rol = @rol_id",
                                        dict);

          }

        public DataTable obtenerAllFunciones()
        {
            var dict = new Dictionary<string, object>();
            return query("select func_id, func_nombre from pel.funcion", dict);
        }

        public DataTable buscarRoles(string rol_nombre)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@rol_nombre", rol_nombre);

            return query("select rol_id, rol_nombre, rol_estado from pel.rol "
                       + "where rol_nombre like case when @rol_nombre != '' then '%'+@rol_nombre+'%' else rol_nombre end ",
                        dict);
        }


        public void upsertRol(decimal idRol, Dictionary<string, object> dict)
        {
            if (idRol == -1){
                insertRol(dict);
            } else {
                updateRol(idRol, dict);
            }
        }

        private void updateRol(decimal idRol, Dictionary<string, object> dict)
        {
            procedure("PEL.modificar_rol", dict);
        }

        private void insertRol(Dictionary<string, object> dict)
        {
            procedure("PEL.crear_rol", dict);
        }
    }
}