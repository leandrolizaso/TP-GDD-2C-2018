using PalcoNet.AbmEmpresa;
using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.GenerarRendicionComisiones
{
    class FacturaDAO : BaseDAO
    {   
        
        internal decimal generarFactura(int cantidad)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@cantidad", cantidad);
            dict.Add("@empresa", new EmpresaDAO().obtenerEmpresa(Globales.idUsuarioLoggeado));
            dict.Add("@fecha", Globales.getFechaHoy());
            var dt = procedure("PEL.sp_generar_rendiciones", dict);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToDecimal(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }

        internal DataTable obtenerFactura(decimal factura)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@factura", factura);
            return query("select fact_numero, fact_fecha, fact_importe as importe_total, fact_comision as comision_total, (select publ_descripcion from pel.publicacion where publ_id = ubic_publ) as publicacion, ubic_fila, ubic_asiento, ubic_precio, ubic_comision "
                        + "from pel.factura join pel.ubicacion on ubic_factura = fact_id and fact_id = @factura", dict);
        }

    }
}
