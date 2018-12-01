using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.ListadoEstadistico
{
    public class ComprasDAO : BaseDAO {

        public DataTable obtenerCompras(string fechaDesde, string fechaHasta)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@fecha_desde", fechaDesde);
            dict.Add("@fecha_hasta", fechaHasta);
            return procedure("PEL.sp_clientes_mayor_compra", dict);
        }

    }
}
