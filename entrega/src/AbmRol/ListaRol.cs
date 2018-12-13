using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.AbmRol
{
    public partial class ListaRol : Form
    {
        public ListaRol()
        {
            InitializeComponent();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            var dt = new RolDAO().buscarRoles(rol_nombre.Text);
            
            if (dt.Rows.Count == 0) 
            {
                MessageBox.Show("No se encontraron resultados");
            }

            datagrid.DataSource = dt;

            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("rol", "").Replace("_", " ").ToUpper();
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            rol_nombre.Text = "";
            datagrid.DataSource = null;
        }

        private void crear_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ModificarRol(-1, "").ShowDialog();
            this.Show();
        }

        private void datagrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var id_clickeado = (decimal)datagrid["rol_id", e.RowIndex].Value;
            var nombre = datagrid["rol_nombre", e.RowIndex].Value.ToString();
            this.Hide();
            new ModificarRol(id_clickeado,nombre).ShowDialog();
            this.Show();
        }
    }
}
