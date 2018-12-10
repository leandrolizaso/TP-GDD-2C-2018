using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Publicacion
{
    public class Ubicacion {

        public Ubicacion(decimal idPublicacion) {
            this.ubic_publ = idPublicacion;
        }

        public decimal ubic_id { get; set; }
        private string _ubic_fila { get; set; }
        private decimal _ubic_asiento { get; set; }
        public decimal ubic_precio { get; set; }
        public decimal ubic_tipo { get; set; }
        private decimal ubic_publ;

        public Dictionary<string,object> asDictionary(){
            return new Dictionary<string, object>();
        }
    }
}
