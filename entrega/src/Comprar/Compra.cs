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
            DataGridViewCheckBoxColumn clm = new DataGridViewCheckBoxColumn();
            clm.HeaderText = "Seleccionar";
            datagrid.Columns.Add(clm);
            datagrid.Columns[0].ReadOnly = true;
            datagrid.Columns[1].ReadOnly = true;
            datagrid.Columns[2].ReadOnly = true;
            datagrid.Columns[3].ReadOnly = true;
            datagrid.AllowUserToAddRows = false;

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

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datagrid.Rows)
            {

                if (Convert.ToBoolean(row.Cells[4].Value))
                {
                   //ver que cuales selecciono y realizar la compra
                }

            }

            MessageBox.Show("Compra exitosa");
            this.Close();
        }
    }
}
