using PalcoNet.AbmCliente;
using PalcoNet.AbmEmpresa;
using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Comprar
{
    class PublicacionDAO : BaseDAO
    {
        internal DataTable obtenerPublicaciones(string categorias, string detalle, DateTime fechaDesde, DateTime fechaHasta, int pagina)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@categorias", categorias);
            dict.Add("@detalle", detalle);
            dict.Add("@desde", fechaDesde);
            dict.Add("@hasta", fechaHasta);
            dict.Add("@pag", pagina);
            return procedure("PEL.sp_ver_publicaciones", dict);
        }
        

        public double totalPaginas(string categorias, string detalle, DateTime fechaDesde, DateTime fechaHasta)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@categorias", categorias);
            dict.Add("@detalle", detalle);
            dict.Add("@desde", fechaDesde);
            dict.Add("@hasta", fechaHasta);
            DataTable result = procedure("PEL.sp_total_publicaciones", dict);
            int total = Convert.ToInt32(result.Rows[0][0]);
            return total;
        }

        internal DataTable obtenerPublicacionesEmpresa(string categorias, string detalle, DateTime fechaDesde, DateTime fechaHasta, int pagina)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@empresa", new EmpresaDAO().obtenerEmpresa(Globales.idUsuarioLoggeado));
            dict.Add("@categorias", categorias);
            dict.Add("@detalle", detalle);
            dict.Add("@desde", fechaDesde);
            dict.Add("@hasta", fechaHasta);
            dict.Add("@pag", pagina);
            return procedure("PEL.sp_ver_publicaciones_empresa", dict);
        }


        public double totalPaginasEmpresa(string categorias, string detalle, DateTime fechaDesde, DateTime fechaHasta)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@empresa", new EmpresaDAO().obtenerEmpresa(Globales.idUsuarioLoggeado));
            dict.Add("@categorias", categorias);
            dict.Add("@detalle", detalle);
            dict.Add("@desde", fechaDesde);
            dict.Add("@hasta", fechaHasta);
            DataTable result = procedure("PEL.sp_total_publicaciones_empresa", dict);
            int total = Convert.ToInt32(result.Rows[0][0]);
            return total;
        }

        internal decimal obtenerPublicacion(string descripcion)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@descripcion", descripcion);
            DataTable result = query("select publ_id from pel.publicacion where publ_descripcion = @descripcion", dict);
            return Convert.ToDecimal(result.Rows[0][0]);
        }

        internal DataTable obtenerUbicaciones(decimal idPublicacion)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@publicacion", idPublicacion);
            return query("select ubic_id, ubic_fila, ubic_asiento, ubic_precio "
                        + "from pel.ubicacion where ubic_publ  = @publicacion and ubic_compra is null order by ubic_precio asc", dict);
        }

        internal void comprarUbicacion(decimal publicacion, string ubicaciones)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@publicacion", publicacion);
            dict.Add("@ubicaciones", ubicaciones);
            dict.Add("@fecha", Globales.getFechaHoy());
            dict.Add("@cliente", new ClienteDAO().obtenerCliente(Globales.idUsuarioLoggeado));
            procedure("PEL.sp_comprar", dict);
        }
    }
}
