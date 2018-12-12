using PalcoNet.AbmCliente;
using PalcoNet.AbmEmpresa;
using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Publicacion
{
    public class PublicacionDAO : BaseDAO
    {
        public DataTable obtenerPublicacionesNoVendidas(DateTime fechaDesde, DateTime fechaHasta, decimal grado)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@fecha_desde", fechaDesde);
            dict.Add("@fecha_hasta", fechaHasta);
            dict.Add("@grado", grado);
            return procedure("PEL.sp_listado_no_vendidas", dict);
        }

        public DataTable obtenerPublicaciones(string categorias, string detalle, DateTime fechaDesde, DateTime fechaHasta, int pagina)
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

        public DataTable obtenerPublicacionesEmpresa(string categorias, string detalle, DateTime fechaDesde, DateTime fechaHasta, int pagina)
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

        public DataTable obtenerTiposUbicacion() {
            return query("select tipo_ubic_id, tipo_ubic_descripcion from pel.tipo_ubicacion", new Dictionary<string, object>());
        }

        //REVISAR ESTO!
        public decimal obtenerPublicacion(string descripcion)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@descripcion", descripcion);
            DataTable result = query("select publ_id from pel.publicacion where publ_descripcion = @descripcion", dict);
            return Convert.ToDecimal(result.Rows[0][0]);
        }

        public DataTable obtenerPublicacion(decimal idPublicacion)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@publ_id", idPublicacion);
            return query("select * from pel.publicacion where publ_id = @publ_id", dict);
        }

        public DataTable obtenerAllUbicaciones(decimal idPublicacion)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@publicacion", idPublicacion);
            return query("select ubic_id, ubic_fila, ubic_asiento, ubic_precio, ubic_tipo, tipo_ubic_descripcion "
                        + "from pel.ubicacion join pel.tipo_ubicacion on tipo_ubic_id = ubic_tipo "
                        + "where ubic_publ  = @publicacion", dict);
        }

        public DataTable obtenerUbicacionesDisponibles(decimal idPublicacion)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@publicacion", idPublicacion);
            return query("select ubic_id, ubic_fila, ubic_asiento, ubic_precio, tipo_ubic_descripcion "
                        + "from pel.ubicacion join pel.tipo_ubicacion on ubic_tipo = tipo_ubic_id where ubic_publ  = @publicacion and ubic_compra is null order by ubic_precio asc", dict);
        }

        public void comprarUbicacion(decimal publicacion, string ubicaciones)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@publicacion", publicacion);
            dict.Add("@ubicaciones", ubicaciones);
            dict.Add("@fecha", Globales.getFechaHoy());
            dict.Add("@cliente", new ClienteDAO().obtenerCliente(Globales.idUsuarioLoggeado));
            procedure("PEL.sp_comprar", dict);
        }

        public DataTable obtenerEstadosDisponiblesParaEstadoActual(decimal estado)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@estado", estado);
            return query("select esta_id, esta_descripcion from pel.estado_publicacion where esta_id >= @estado", dict);

        }

        public decimal obtenerIdEstadoXIdPublicacion(decimal publ)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("@publicacion", publ);
            decimal estado = Convert.ToDecimal(query("select publ_estado from pel.publicacion where publ_id = @publicacion", dict).Rows[0][0]);
            return estado;
        }

        //Publicacion
        public void upsertPublicacion(decimal idPublicacion, Dictionary<string, object> dict)
        {
            if (idPublicacion == -1)
            {
                insertPublicacion(dict);
            }
            else
            {
                updatePublicacion(idPublicacion, dict);
            }
        }

        public decimal generarIdPublicacion() 
        {   
            var dict = new Dictionary<string, object>();
            return Convert.ToDecimal(query("select next value for PEL.Publicacion_seq", dict).Rows[0][0]);
        }

        private void insertPublicacion(Dictionary<string, object> dict)
        {   
            string queryStr = "insert PEL.publicacion (";
            foreach (var entry in dict)
            {
                queryStr += entry.Key + " ,";
            }
            queryStr = queryStr.TrimEnd(',');
            queryStr += ") values (";
            foreach (var entry in dict)
            {
                queryStr += "@" + entry.Key + " ,";
            }
            queryStr = queryStr.TrimEnd(',');
            queryStr += ")";
            query(queryStr, dict);

        }

        private void updatePublicacion(decimal idPublicacion, Dictionary<string, object> dict)
        {
            string queryStr = "update PEL.publicacion set ";
            foreach (var entry in dict)
            {
                queryStr += entry.Key + " = @" + entry.Key + " ,";
            }
            queryStr = queryStr.TrimEnd(',');
            queryStr += "where publ_id = " + idPublicacion;

            Dictionary<string, object> queryParams = new Dictionary<string, object>();
            foreach (var item in dict)
            {
                queryParams.Add("@" + item.Key, item.Value);
            }

            query(queryStr, queryParams);
         
        }


        //Ubicacion
        public void upsertUbicacion(Dictionary<string, object> dict)
        {
            decimal idUbicacion = Convert.ToDecimal(dict["ubic_id"]);
            if (idUbicacion == -1)
            {
                insertUbicacion(dict);
            }
            else
            {
                updateUbicacion(dict);
            }
        }

        private void insertUbicacion(Dictionary<string, object> dict)
        {
            dict.Remove("ubic_id");

            string queryStr = "insert PEL.ubicacion (";
            foreach (var entry in dict)
            {
                queryStr += entry.Key + " ,";
            }
            queryStr = queryStr.TrimEnd(',');
            queryStr += ") values (";
            foreach (var entry in dict)
            {
                queryStr += "@" + entry.Key + " ,";
            }
            queryStr = queryStr.TrimEnd(',');
            queryStr += ")";
            query(queryStr, dict);
        }

        private void updateUbicacion(Dictionary<string, object> dict)
        {
            string queryStr = "update PEL.ubicacion set ";
            foreach (var entry in dict)
            {
                queryStr += entry.Key + " = @" + entry.Key + " ,";
            }
            queryStr = queryStr.TrimEnd(',');
            queryStr += "where ubic_id = @ubic_id";

            Dictionary<string, object> queryParams = new Dictionary<string, object>();
            foreach (var item in dict)
            {
                queryParams.Add("@" + item.Key, item.Value);
            }

            query(queryStr, queryParams);
        }
    }
}
