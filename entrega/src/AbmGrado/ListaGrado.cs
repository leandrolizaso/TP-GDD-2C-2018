using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.AbmGrado
{
    public partial class ListaGrado : Form
    {
        private decimal id_clickeado;

        public ListaGrado()
        {
            InitializeComponent();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            var dt = new GradoDAO().obtenerGrado(nombre.Text, pcnt_from.Text, pcnt_to.Text);
            datagrid.DataSource = dt;
            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("grad_", "").Replace("_", " ").ToUpper();
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            nombre.Text = "";
            pcnt_from.Text = "";
            pcnt_to.Text = "";
            datagrid.DataSource = null;
        }

        private void crear_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ModificarGrado().ShowDialog();
            this.Show();
            buscar_Click(sender, e);
        }

        private void datagrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id_clickeado = (decimal)datagrid["grad_id", e.RowIndex].Value;
            this.Hide();
            new ModificarGrado(id_clickeado).ShowDialog();
            this.Show();
            buscar_Click(sender, e);
        }
    }
}
