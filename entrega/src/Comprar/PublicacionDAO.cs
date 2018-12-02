using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Comprar
{
    class PublicacionDAO : BaseDAO
    {
        internal DataTable obtenerPublicaciones(string categorias, string detalle, DateTime fechaDesde, DateTime fechaHasta, int pagina)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@fecha", Globales.getFechaHoy());
            dict.Add("@categorias", categorias);
            dict.Add("@detalle", detalle);
            dict.Add("@desde", fechaDesde);
            dict.Add("@hasta", fechaHasta);
            dict.Add("@pag", pagina);
            return procedure("PEL.sp_ver_publicaciones", dict);
        }

        public double totalPaginas(string categorias, string detalle, DateTime fechaDesde, DateTime fechaHasta)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@fecha", Globales.getFechaHoy());
            dict.Add("@categorias", categorias);
            dict.Add("@detalle", detalle);
            dict.Add("@desde", fechaDesde);
            dict.Add("@hasta", fechaHasta);
            DataTable result = procedure("PEL.sp_total_publicaciones", dict);
            int total = Convert.ToInt32(result.Rows[0][0]);
            return total;
        }
    }
}
