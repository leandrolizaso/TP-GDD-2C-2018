using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.HistorialCliente
{
    public class HistorialDAO : BaseDAO
    {
        internal DataTable obtenerHistorial(decimal idCliente, int pagina)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@clie_id", idCliente);
            dict.Add("@pag", pagina);
            return procedure("PEL.sp_ver_compras", dict);
        }

        public double totalPaginas(decimal idCliente)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@clie_id", idCliente);
            DataTable result = procedure("PEL.sp_total_compras", dict);
            int total = Convert.ToInt32(result.Rows[0][0]);
            return total;
        }

        public decimal obtenerCliente(decimal usuario)
        {   
            var dict = new Dictionary<string, object>();
            dict.Add("@usua_id", usuario);
            DataTable result = query("select clie_id "
                        +"from pel.cliente join pel.usuario on clie_usuario = usua_id where usua_id = @usua_id", dict);
            return Convert.ToDecimal(result.Rows[0][0]);
        
        }
    }
}
