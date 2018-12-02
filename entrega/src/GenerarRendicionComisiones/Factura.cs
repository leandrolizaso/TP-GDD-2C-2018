using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.GenerarRendicionComisiones
{
    public partial class Factura : Form
    {
        decimal numeroFactura;

        public Factura(int cantidad)
        {
            InitializeComponent();
            numeroFactura = new FacturaDAO().generarFactura(cantidad);
            llenar_grilla();
        }

        private void llenar_grilla()
        {
            var dt = new FacturaDAO().obtenerFactura(numeroFactura);
            datagrid.DataSource = dt;
            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("fact_", "").Replace("ubic_", "").Replace("_", " ").ToUpper();
            }
        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
