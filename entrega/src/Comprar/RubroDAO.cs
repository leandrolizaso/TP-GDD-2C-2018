using PalcoNet.Utils;
using System;
using System.Data;
namespace PalcoNet.Comprar {

    public class RubroDAO : BaseDAO{

        private static int idRubro = 0;

        public DataTable buscarRubroPorDescripcion(string descripcion) {
            var dt = new DataTable(); //las consultas a la base suelen devolver esto

            dt.Columns.Add("rubr_id");
            dt.Columns.Add("rubr_descripcion");

            dt.Rows.Add(new Object[] { ++idRubro, descripcion });

            return dt;
        }
    }
}