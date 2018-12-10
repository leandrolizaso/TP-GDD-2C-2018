using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Publicacion
{
    public class Ubicacion {

        public Ubicacion(decimal idUbicacion) {
            ubic_id = idUbicacion;
        }

        public decimal ubic_id { get; set; }
        public string ubic_fila { get; set; }
        public decimal ubic_asiento { get; set; }
        public decimal ubic_precio { get; set; }
        public decimal ubic_tipo { get; set; }
        public string tipo_ubic_descripcion { get; set; }

        public Dictionary<string,object> asDictionary(){
            var dict = new Dictionary<string, object>();
            dict.Add("ubic_id", ubic_id);
            dict.Add("ubic_fila", ubic_fila);
            dict.Add("ubic_asiento", ubic_asiento);
            dict.Add("ubic_precio", ubic_precio);
            dict.Add("ubic_tipo", ubic_tipo);
            return dict;
        }
    }
}
