using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.ListadoEstadistico 
{
    class PuntosDAO : BaseDAO
    {
        internal DataTable obtenerListadoPuntos(string fechaDesde, string fechaHasta)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@fecha", Globales.getProperty("Fecha"));
            dict.Add("@fecha_desde", fechaDesde);
            dict.Add("@fecha_hasta", fechaHasta);
            return procedure("PEL.ssp_clientes_puntos_vencidos", dict);
        }
    }
}
