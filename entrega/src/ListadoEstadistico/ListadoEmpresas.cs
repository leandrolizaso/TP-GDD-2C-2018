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
        string fecha;


        public ListadoEmpresas(string fecha)
        {
            InitializeComponent();
            this.cargarComboBox();
            this.fecha = fecha;
        }

        private void cargarComboBox()
        {   DataTable dt = new EmpresasDAO().obtenerDatosGrados();
            grado.DisplayMember = "grad_descripcion";
            grado.ValueMember = "grad_id";
            grado.DataSource = dt;
        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buscar_Click(object sender, EventArgs e)
        {
            var dt = new EmpresasDAO().obtenerEmpresas(fecha, Convert.ToDecimal(grado.SelectedValue));
            datagrid.DataSource = dt;
            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("empr_", "").Replace("_", " ").ToUpper();
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
