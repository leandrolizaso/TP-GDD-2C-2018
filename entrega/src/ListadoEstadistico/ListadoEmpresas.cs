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
            DataTable dt = new EmpresasDAO().obtenerDatosGrados();
            grado.DisplayMember = "grad_descripcion";
            grado.ValueMember = "grad_id";
            grado.DataSource = dt;
        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buscar_Click(object sender, EventArgs e)
        {
            DataTable dt = new EmpresasDAO().obtenerEmpresas(fechaDesde, fechaHasta, (decimal)grado.SelectedValue);
            datagrid.DataSource = dt;
            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("empr_", "").Replace("_", " ").ToUpper();
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            datagrid.DataSource = null;
            grado.Text = "";
        }

        private void grad_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

    
    }
}
