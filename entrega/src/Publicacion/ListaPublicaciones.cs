using PalcoNet.AbmRol;
using PalcoNet.AbmRubro;
using PalcoNet.Comprar;
using PalcoNet.Publicacion;
using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Publicacion
{
    public partial class ListaPublicaciones : Form
    {

        string rubros;
        private int pagina = 1;
        private int ultimaPagina = 1;
        private bool esEmpresa;
        private bool esAdmin;

        public ListaPublicaciones(bool esEmpr)
        {
            InitializeComponent();
            esEmpresa = esEmpr;
            esAdmin = esAdmin = new RolDAO().esAdmin(Globales.idUsuarioLoggeado);
            rubros = "";
            fecha_desde.Value = Globales.getFechaHoy();
            fecha_hasta.Value = Globales.getFechaHoy();
            pag.Text = Convert.ToString(pagina);

            if (!esEmpresa) 
            {
                fecha_desde.MinDate = Globales.getFechaHoy();
                fecha_hasta.MinDate = Globales.getFechaHoy();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rubrosForm = new Rubro();
            rubrosForm.ShowDialog();
            rubros = rubrosForm.rubros;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            rubros = "";
            nombre.Text = "";
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            if (esEmpresa)
            {
                if (esAdmin)
                {
                    MessageBox.Show("Debe ser una empresa registrada para acceder a esta funcionalidad");
                    return;
                }
                ultimaPagina = Convert.ToInt32(Math.Ceiling((new PublicacionDAO().totalPaginasEmpresa(rubros, nombre.Text, fecha_desde.Value, fecha_hasta.Value)) / 10));
            }
            else
            {

                ultimaPagina = Convert.ToInt32(Math.Ceiling((new PublicacionDAO().totalPaginas(rubros, nombre.Text, fecha_desde.Value, fecha_hasta.Value)) / 10));
                
            }

            this.llenar_grilla();
        }

        private void llenar_grilla()
        {
            try
            {
                pag.Text = Convert.ToString(pagina);
                DataTable dt;

                if (esEmpresa)
                {
                    dt = new PublicacionDAO().obtenerPublicacionesEmpresa(rubros, nombre.Text, fecha_desde.Value, fecha_hasta.Value, pagina);
                }
                else
                {
                    dt = new PublicacionDAO().obtenerPublicaciones(rubros, nombre.Text, fecha_desde.Value, fecha_hasta.Value, pagina);

                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron resultados");
                }

                datagrid.DataSource = dt;
                foreach (DataGridViewColumn column in datagrid.Columns)
                {
                    column.HeaderText = column.HeaderText.Replace("publ_", "").Replace("fecha_ven", "Dia - horario").Replace("_", " ").ToUpper();
                }

                foreach (DataGridViewColumn column in datagrid.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (SqlException ex) {
                MessageBox.Show(SqlExceptionTransformer.obtenerMensajeCustom(ex));
            }
        }

        private void datagrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            decimal idPublicacion = Convert.ToDecimal(datagrid.CurrentRow.Cells["publ_id"].Value.ToString());

            if (esEmpresa)
            {
                new ModificarPublicacion(idPublicacion).ShowDialog();
          
            }
            else 
            {
                if (esAdmin)
                {
                    MessageBox.Show("Debe ser un cliente registrado para acceder a esta funcionalidad");
                    return;
                }
                new Compra(idPublicacion).ShowDialog();
          
            }
           
            buscar_Click(sender, e);
        }

        private void ultimo_Click(object sender, EventArgs e)
        {
            if (ultimaPagina == 0)
            {
                pagina = 1;
            }
            else
            {
                pagina = ultimaPagina;
            }

            this.llenar_grilla();
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            if (pagina < ultimaPagina)
            {
                pagina += 1;
            }
            this.llenar_grilla();
        }

        private void anterior_Click(object sender, EventArgs e)
        {
            if (pagina > 1)
            {
                pagina -= 1;
            }
            this.llenar_grilla();
        }

        private void primera_Click(object sender, EventArgs e)
        {
            pagina = 1;
            this.llenar_grilla();
        }

    }
}
