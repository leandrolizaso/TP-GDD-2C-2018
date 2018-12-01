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
            dict.Add("@fecha", Globales.getFechaHoy());
            dict.Add("@fecha_desde", fechaDesde);
            dict.Add("@fecha_hasta", fechaHasta);
            return procedure("PEL.sp_clientes_puntos_vencidos", dict);
        }

        public int obtenerTotal(){
            var dict = new Dictionary<string, object>();
            dict.Add("@fecha", Globales.getFechaHoy());
            dict.Add("@usua_id", Globales.idUsuarioLoggeado);
            return Convert.ToInt32(procedure("PEL.sp_total_puntos", dict).Rows[0][0]);
        }

        public DataTable obtenerPuntos()
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@fecha", Globales.getFechaHoy());
            dict.Add("@usua_id", Globales.idUsuarioLoggeado);
            return procedure("PEL.sp_ver_puntos", dict);
        }

    }
}
