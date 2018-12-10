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
        private string _ubic_fila;
        private decimal _ubic_asiento { get; set; }
        public bool ubic_sin_numerar { get; set; }
        public decimal ubic_precio { get; set; }
        public decimal ubic_comision { get; set; }
        public decimal ubic_item_factura_cantidad { get; set; }
        public string ubic_item_factura_descripcion { get; set; }
        public decimal ubic_tipo { get; set; }
        private decimal ubic_publ;

        public string get_ubic_fila
        {
            get { return _ubic_fila; }
            set { if(value.Length<=3)_ubic_fila = value; }
        }
    }
}
