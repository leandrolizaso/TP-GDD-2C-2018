using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.RegistroUsuario
{
    class UsuarioDAO : BaseDAO
    {
        internal DataTable obtenerUsuarios() 
        {
            var dict = new Dictionary<string, object>();
            return query("select usua_id, usua_username from pel.usuario order by usua_id asc", dict);
        }
    }
}
