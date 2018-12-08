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
            datagrid.DataSource = new RolDAO().buscarRoles(rol_nombre.Text);

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
            new ModificarRol(-1).ShowDialog();
            this.Show();
        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
