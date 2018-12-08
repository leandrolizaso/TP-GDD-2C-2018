using PalcoNet.AbmEmpresa;
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
    public partial class SeleccionarEmpresa : Form
    {
        public SeleccionarEmpresa()
        {
            InitializeComponent();

            var dt = new EmpresaDAO().obtenerEmpresasPorRendir();
            datagrid.DataSource = dt;
            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("empr_", "").Replace("_", " ").ToUpper();
            }

            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }



        }

        private void datagrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal id_clickeado = (decimal)datagrid["empr_id", e.RowIndex].Value;
            this.Hide();
            new GenerarRendicion(id_clickeado).ShowDialog();
            this.Show();
        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
