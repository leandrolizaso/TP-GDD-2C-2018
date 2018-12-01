using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.ListadoEstadistico
{
    class EmpresasDAO : BaseDAO
    {
        internal DataTable obtenerEmpresas(DateTime fechaDesde, DateTime fechaHasta, decimal grado)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@fecha_desde", fechaDesde);
            dict.Add("@fecha_hasta", fechaHasta);
            dict.Add("@grado", grado);
            return procedure("PEL.sp_listado_no_vendidas", dict);
        }



        internal DataTable obtenerDatosGrados()
        {
            var dict = new Dictionary<string, object>();
            return query("select grad_descripcion, grad_id " + "from pel.grado", dict);
        }
    }
}
