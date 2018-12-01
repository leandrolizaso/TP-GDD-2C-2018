using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.ListadoEstadistico
{
    public partial class ListadoPuntos : Form
    {
        public ListadoPuntos(DateTime fechaDesde, DateTime fechaHasta)
        {
            InitializeComponent();
            var dt = new PuntosDAO().obtenerListadoPuntos(fechaDesde, fechaHasta);
            datagrid.DataSource = dt;
            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("clie_", "").Replace("_", " ").ToUpper();
            }
        }

        private void ListadoPuntos_Load(object sender, EventArgs e)
        {

        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
