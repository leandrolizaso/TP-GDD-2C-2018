using PalcoNet.ListadoEstadistico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.CanjePuntos
{
    public partial class CanjePremio : Form
    {
        int totalPuntos;

        public CanjePremio()
        {
            InitializeComponent();
            totalPuntos = new PuntosDAO().obtenerTotal();
            puntos.Text = Convert.ToString(totalPuntos);
            var dt = new PremioDAO().obtenerPremios(totalPuntos);
            datagrid.DataSource = dt;
            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("_", " ").Replace("puntos", " ").ToUpper();
            }

            DataGridViewButtonColumn clm = new DataGridViewButtonColumn();
            clm.HeaderText = "Canjear";
            datagrid.Columns.Add(clm);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buscar_Click(object sender, EventArgs e)
        {

        }

        private void CanjePremio_Load(object sender, EventArgs e)
        {

        }

        private void limpiar_Click(object sender, EventArgs e)
        {

        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void pcnt_from_TextChanged(object sender, EventArgs e)
        {

        }

        private void pcnt_to_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
