using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
namespace PalcoNet.AbmRubro {

    public class RubroDAO : BaseDAO{

        private static int idRubro = 0;

        public DataTable buscarRubroPorDescripcion(string descripcion) {
            var dt = new DataTable(); //las consultas a la base suelen devolver esto

            dt.Columns.Add("rubr_id");
            dt.Columns.Add("rubr_descripcion");

            dt.Rows.Add(new Object[] { ++idRubro, descripcion });

            return dt;
        }

        public DataTable obtenerRubros()
        {
            var dict = new Dictionary<string, object>();
            return query("select rubr_id, rubr_descripcion from pel.rubro", dict);
        }

    }
}