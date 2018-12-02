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
        DataTable dt;

        public CanjePremio()
        {
            InitializeComponent();
            totalPuntos = new PuntosDAO().obtenerTotal();
            puntos.Text = Convert.ToString(totalPuntos);
            dt = new PremioDAO().obtenerPremios(totalPuntos);
            datagrid.DataSource = dt;
            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("_", " ").Replace("puntos", " ").ToUpper();
            }

            var clm = new DataGridViewButtonColumn();
            clm.Text = "Canjear";
            clm.UseColumnTextForButtonValue = true;
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
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string premio = Convert.ToString(dt.Rows[e.RowIndex][0]);
                decimal puntos = new PremioDAO().canjearPremio(premio);
                new PremioDAO().descontarPuntos(puntos);
                this.Close();
            }
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
