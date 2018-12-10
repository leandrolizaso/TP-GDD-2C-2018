using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Publicacion
{
    public partial class UbicacionesPublicacion : Form
    {

        public List<Ubicacion> ubicaciones = new List<Ubicacion>();
        private decimal idPublicacion;

        public UbicacionesPublicacion(decimal idPublicacion)
        {
            this.idPublicacion = idPublicacion;
            InitializeComponent();
            setupGrid();
            if (idPublicacion != -1) {
                loadUbicaciones();
            }
        }

        private void loadUbicaciones()
        {
            var dt = new PublicacionDAO().obtenerAllUbicaciones(idPublicacion);

            foreach (DataRow row in dt.Rows)
            {
                Ubicacion u = new Ubicacion(idPublicacion);
                u.ubic_id = Convert.ToDecimal(row["ubic_id"]);
                u.ubic_fila = Convert.ToString(row["ubic_fila"]);
                u.ubic_asiento = Convert.ToDecimal(row["ubic_asiento"]);
                u.ubic_precio = Convert.ToDecimal(row["ubic_precio"]);
                u.ubic_tipo = Convert.ToDecimal(row["ubic_tipo"]);
                ubicaciones.Add(u);
            }
        }

        private void setupGrid()
        {
            datagrid.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "ubic_fila";
            column.Name = "Fila";
            datagrid.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "ubic_asiento";
            column.Name = "Asiento";
            datagrid.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "ubic_precio";
            column.Name = "Precio";
            datagrid.Columns.Add(column);

            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.DataPropertyName = "ubic_tipo";
            combo.Name = "Precio";
            combo.DisplayMember = "tipo_ubic_descripcion";
            combo.ValueMember = "tipo_ubic_id";
            combo.DataSource = new PublicacionDAO().obtenerTiposUbicacion();
            datagrid.Columns.Add(combo);
        }
    }
}
