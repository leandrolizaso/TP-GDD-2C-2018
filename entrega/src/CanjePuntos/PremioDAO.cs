using PalcoNet.AbmCliente;
using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.CanjePuntos 
{
    class PremioDAO : BaseDAO
    {
        internal DataTable obtenerPremios(int puntos)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@puntos", puntos);
            return query("select prem_descripcion, prem_costo_puntos "
                        + "from pel.premio where prem_costo_puntos <= @puntos", dict);
        }

        internal decimal canjearPremio(string premio)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@premio", premio);
            dict.Add("@cliente", new ClienteDAO().obtenerCliente(Globales.idUsuarioLoggeado));
            dict.Add("@fecha",Globales.getFechaHoy());
            var dt = procedure("PEL.sp_canjear_premio", dict);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToDecimal(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }
            

        }

        internal void descontarPuntos(decimal puntos)
        {
                 var dict = new Dictionary<string, object>();
            dict.Add("@puntos_a_gastar", puntos);
            dict.Add("@usua_id", Globales.idUsuarioLoggeado);
            dict.Add("@fecha",Globales.getFechaHoy());
            procedure("PEL.sp_descontar_puntos", dict);
        }

        internal DataTable obtenerPremiosCliente() { 
            var dict = new Dictionary<string, object>();
            dict.Add("@clie_id", new ClienteDAO().obtenerCliente(Globales.idUsuarioLoggeado));
            return query("select (select prem_descripcion from pel.premio where prem_id = canje_premio) as premio, canje_fecha, canje_puntos_gastados "
                        +"from pel.canje where canje_cliente = @clie_id", dict);
        }
    }
}
