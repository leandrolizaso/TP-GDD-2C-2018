using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.ListadoEstadistico 
{
    public class PuntosDAO : BaseDAO {

        public DataTable obtenerListadoPuntos(DateTime fechaDesde, DateTime fechaHasta)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@fecha", Globales.getProperty("Fecha"));
            dict.Add("@fecha_desde", fechaDesde);
            dict.Add("@fecha_hasta", fechaHasta);
            return procedure("PEL.ssp_clientes_puntos_vencidos", dict);
        }
    }
}
