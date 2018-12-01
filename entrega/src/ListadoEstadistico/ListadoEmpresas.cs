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
    public partial class ListadoEmpresas : Form
    {
        DateTime fechaDesde;
        DateTime fechaHasta;


        public ListadoEmpresas(DateTime fechaDesde, DateTime fechaHasta)
        {
            InitializeComponent();
            this.cargarComboBox();
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
        }

        private void cargarComboBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("grad_descripcion");
            dt.Columns.Add("grad_id");
            DataRow row = dt.NewRow();
            row["grad_descripcion"] = "--";
            row["grad_id"] = 0;
            dt.Rows.Add(row);
            dt.Merge(new EmpresasDAO().obtenerDatosGrados(), true, MissingSchemaAction.Ignore);
            grado.DisplayMember = "grad_descripcion";
            grado.ValueMember = "grad_id";
            grado.DataSource = dt;
        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buscar_Click(object sender, EventArgs e)
        {
            DataTable dt = new EmpresasDAO().obtenerEmpresas(fechaDesde, fechaHasta, Convert.ToDecimal(grado.SelectedValue));
            datagrid.DataSource = dt;
            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("publ_", "").Replace("_", " ").ToUpper();
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            datagrid.DataSource = null;
            this.cargarComboBox();
        }

        private void grad_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

    
    }
}
