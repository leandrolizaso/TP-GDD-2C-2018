﻿using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Comprar
{
    public class ComprasDAO : BaseDAO {

        public DataTable obtenerCompras(DateTime fechaDesde, DateTime fechaHasta)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@fecha_desde", fechaDesde);
            dict.Add("@fecha_hasta", fechaHasta);
            return procedure("PEL.sp_clientes_mayor_compra", dict);
        }

    }
}
