using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Comprar
{
    public partial class Compra : Form
    {
        DataTable dt;
        decimal publicacion;

        public Compra(decimal idPublicacion)
        {
            
            InitializeComponent();
            publicacion = idPublicacion;
            dt = new PublicacionDAO().obtenerUbicaciones(idPublicacion);
            datagrid.DataSource = dt;
            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("ubic_", "").Replace("_", " ").ToUpper();
            }
            datagrid.Columns["ubic_id"].Visible = false;
        }

        private void comprar_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
