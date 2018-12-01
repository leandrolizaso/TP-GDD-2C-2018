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
    }
}
