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

        public int totalPaginas(decimal idCliente)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@clie_id", idCliente);
            DataTable result = procedure("PEL.sp_total_crompas", dict);
            int total = Convert.ToInt32(result.Rows[0][0]);
            return total;
        }


    }
}
